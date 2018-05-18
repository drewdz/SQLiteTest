using MvvmCross.ViewModels;
using SqliteTest.Contracts.Models;
using SqliteTest.Core.Models;
using SqliteTest.Core.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace SqliteTest.Core.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        #region Fields

        private readonly IRealmService _RealmService;

        #endregion Fields

        #region Constructors

        public MainViewModel(IRealmService realmService)
        {
            _RealmService = realmService;
        }

        #endregion Constructors

        #region Properties

        public MvxObservableCollection<Grouping<string, Breed>> Breeds { get; set; }

        #endregion Properties

        #region Lifecycle

        public override void Start()
        {
            base.Start();
            var breeds = _RealmService.Breeds.ToList();
            var sorted = from breed in _RealmService.Breeds.ToList()
                         orderby breed.Name
                         group breed by breed.NameSort into breedGroup
                         select new Grouping<string, Breed>(breedGroup.Key, breedGroup);

            Breeds = new MvxObservableCollection<Grouping<string, Breed>>(sorted);
        }

        #endregion Lifecycle
    }
}
