using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;

using SqliteTest.Core.ViewModels;

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