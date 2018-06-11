using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;

using SqliteTest.Core.ViewModels;
using Xamarin.Forms;

namespace SqliteTest.UI.Pages
{
    [MvxContentPagePresentation(WrapInNavigationPage = true)]
    public partial class MainPage : MvxContentPage<MainViewModel>
    {
        public MainPage()
        {
            InitializeComponent();
        }
    }
}