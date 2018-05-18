using MvvmCross.Forms.Platforms.Uap.Core;
using MvvmCross.Forms.Platforms.Uap.Views;

namespace SqliteTest.Uwp
{
    sealed partial class App
    {
        public App()
        {
            InitializeComponent();
        }
    }

    public abstract class ProxyApp : MvxWindowsApplication<MvxFormsWindowsSetup<Core.App, UI.FormsApp>, Core.App, UI.FormsApp, MainPage>
    {
    }
}
