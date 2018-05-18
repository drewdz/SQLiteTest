using MvvmCross.Forms.Platforms.Android.Core;
using MvvmCross.Logging;

namespace SqliteTest.Droid
{
    public class Setup : MvxFormsAndroidSetup<Core.App, SqliteTest.UI.FormsApp>
    {
        //public override MvxLogProviderType GetDefaultLogProviderType()
        //    => MvxLogProviderType.Serilog;

        //protected override IMvxLogProvider CreateLogProvider()
        //{
        //    Log.Logger = new LoggerConfiguration()
        //        .MinimumLevel.Debug()
        //        .WriteTo.AndroidLog()
        //        .CreateLogger();
        //    return base.CreateLogProvider();
        //}
    }
}