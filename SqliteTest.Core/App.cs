using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.ViewModels;

using SqliteTest.Core.ViewModels;

namespace SqliteTest.Core
{
    public class App : MvxApplication
    {
        /// <summary>
        /// Breaking change in v6: This method is called on a background thread. Use
        /// Startup for any UI bound actions
        /// </summary>
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            RegisterAppStart<MainViewModel>();
        }

        /// <summary>
        /// Do any UI bound startup actions here
        /// </summary>
        /// <param name="hint"></param>
        public override void Startup(object hint)
        {
            //Mvx.LazyConstructAndRegisterSingleton<Services.IRealmService>(() => new Services.RealmService());
            base.Startup(hint);
        }

        /// <summary>
        /// If the application is restarted (eg primary activity on Android 
        /// can be restarted) this method will be called before Startup
        /// is called again
        /// </summary>
        public override void Reset()
        {
            base.Reset();
        }
    }
}
