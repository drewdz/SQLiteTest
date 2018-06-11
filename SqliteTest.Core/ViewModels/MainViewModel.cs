using MvvmCross.Commands;
using MvvmCross.ViewModels;
using SqliteTest.Contracts.Models;
using SqliteTest.Core.Models;
using SqliteTest.Core.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace SqliteTest.Core.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        #region Fields

        private readonly IRealmService _RealmService;

        private DateTime _SearchTimestamp = DateTime.MinValue;
        private bool _Searching = false;

        #endregion Fields

        #region Constructors

        public MainViewModel(IRealmService realmService)
        {
            _RealmService = realmService;
        }

        #endregion Constructors

        #region Properties

        private MvxObservableCollection<Grouping<string, Breed>> _Breeds = new MvxObservableCollection<Grouping<string, Breed>>();
        public MvxObservableCollection<Grouping<string, Breed>> Breeds
        {
            get => _Breeds;
            set => SetProperty(ref _Breeds, value);
        }

        private string _SearchText = string.Empty;
        public string SearchText
        {
            get => _SearchText;
            set
            {
                SetProperty(ref _SearchText, value);
                Search();
            }
        }

        #endregion Properties

        #region Commands

        private IMvxCommand _ToolbarCommand = null;
        public IMvxCommand ToolbarCommand => _ToolbarCommand ?? new MvxCommand(() => SearchText = "Chinese Crested");

        #endregion Commands

        #region Lifecycle

        public override void Start()
        {
            base.Start();
            GetBreeds(string.Empty);
        }

        #endregion Lifecycle

        #region Operations

        private async void Search()
        {
            try
            {
                if (_Searching) return;
                _SearchTimestamp = DateTime.Now;
                await Task.Delay(700);
                //  another character has arived in the meantime
                if (DateTime.Now.Subtract(_SearchTimestamp).TotalMilliseconds < 700) return;
                _Searching = true;
                //  do the search
                GetBreeds(SearchText);
            }
            catch (Exception ex)
            {
                /* do nothing for now */
            }
            finally
            {
                _Searching = false;
            }
        }

        private void GetBreeds(string name)
        {
            var breeds = (string.IsNullOrEmpty(name)) ? _RealmService.Breeds.ToList() : _RealmService.Breeds.Where(b => b.Name.Contains(name)).ToList();
            var sorted = from breed in breeds.ToList()
                         orderby breed.Name
                         group breed by breed.NameSort into breedGroup
                         select new Grouping<string, Breed>(breedGroup.Key, breedGroup);

            Breeds = new MvxObservableCollection<Grouping<string, Breed>>(sorted);
        }

        #endregion Operations
    }
}
