using Android.App;
using Android.Content.PM;
using Android.OS;
using MvvmCross.Forms.Platforms.Android.Views;
using SqliteTest.Core.ViewModels;

namespace SqliteTest.Droid
{
    [Activity(
            Label = "Sqlite Test",
            Icon = "@mipmap/icon",
            Theme = "@style/AppTheme",
            // MainLauncher = true, // No Splash Screen: Uncomment this lines if removing splash screen
            ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
            LaunchMode = LaunchMode.SingleTask)]
    public class MainActivity : MvxFormsAppCompatActivity<DummyViewModel>
    // No Splash Screen: use this base instead
    // MvxFormsAppCompatActivity<Setup, Core.App, FormsApp, DummyViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            base.OnCreate(bundle);
        }
    }
}

