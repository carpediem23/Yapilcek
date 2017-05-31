
using Android.App;
using Android.Content.PM;
using Android.OS;
using Yapilcek.Droid.Dependencies;

namespace Yapilcek.Droid
{
    [Activity(Label = "Yapilcek", Icon = "@drawable/yapilcek_icon", Theme = "@style/MainTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            Xamarin.Forms.DependencyService.Register<DatabaseConnection>();
            LoadApplication(new App());
        }
    }
}

