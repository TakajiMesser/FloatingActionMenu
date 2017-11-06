using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Widget;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace Sample
{
    [Activity(Label = "FloatingActionMenu Sample", ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize, HardwareAccelerated = true, MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            var toolbar = FindViewById<Toolbar>(Resource.Id.main_toolbar);
            SetSupportActionBar(toolbar);

            var exampleOne = FindViewById<RelativeLayout>(Resource.Id.example_one);
            exampleOne.Click += (s, e) =>
            {
                //StartActivity(new Intent(this, typeof(TripActivity)));
            };

            SetUpFloatingActionMenu();
        }

        private void SetUpFloatingActionMenu()
        {
            var fabOne = FindViewById<FloatingActionButton>(Resource.Id.fab_one);
            fabOne.Click += (s, e) => Toast.MakeText(this, "Button one clicked", ToastLength.Short).Show();

            var fabTwo = FindViewById<FloatingActionButton>(Resource.Id.fab_two);
            fabTwo.Click += (s, e) => Toast.MakeText(this, "Button two clicked", ToastLength.Short).Show();

            var fabThree = FindViewById<FloatingActionButton>(Resource.Id.fab_three);
            fabOne.Click += (s, e) => Toast.MakeText(this, "Button three clicked", ToastLength.Short).Show();
        }
    }
}

