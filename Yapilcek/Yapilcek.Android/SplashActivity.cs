
using Android.App;
using Android.Content;
using Android.OS;
using Android.Content.PM;
using System.Threading.Tasks;

namespace Yapilcek.Droid
{
    [Activity(Label = "Yapilcek", MainLauncher = true, NoHistory = true, Theme = "@style/MainTheme.Splash",
    ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Task startup = new Task(SimulateStartup);
            startup.RunSynchronously();
        }

        public override void OnBackPressed() { }

        private async void SimulateStartup()
        {
            await Task.Delay(2000);
            StartActivity(new Intent(Application.Context, typeof(MainActivity)));
        }
    }
}