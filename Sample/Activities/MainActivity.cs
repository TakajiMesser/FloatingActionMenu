using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Messert.Controls.Droid;
using AlertDialog = Android.Support.V7.App.AlertDialog;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace Sample.Activities
{
    [Activity(Label = "FloatingActionMenu Sample", ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize, HardwareAccelerated = true, MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            var toolbar = FindViewById<Toolbar>(Resource.Id.main_toolbar);
            SetSupportActionBar(toolbar);

            SupportActionBar.SetHomeAsUpIndicator(Resource.Drawable.ic_menu_home);
            SupportActionBar.SetDisplayShowHomeEnabled(true);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);

            var fam = FindViewById<FloatingActionMenu>(Resource.Id.fam);

            var exampleOne = FindViewById<RelativeLayout>(Resource.Id.example_one);
            exampleOne.Click += (s, e) =>
            {
                fam.OpenDirection = FloatingActionMenu.OPEN_UP;
                fam.SetLabelDirection(FloatingActionMenu.LABEL_LEFT);
            };

            var exampleTwo = FindViewById<RelativeLayout>(Resource.Id.example_two);
            exampleTwo.Click += (s, e) =>
            {
                fam.OpenDirection = FloatingActionMenu.OPEN_LEFT;
                fam.SetLabelDirection(FloatingActionMenu.LABEL_TOP);
            };

            SetUpFloatingActionMenu();
        }

        private void SetUpFloatingActionMenu()
        {
            var fabOne = FindViewById<FloatingActionButton>(Resource.Id.fab_one);
            fabOne.Click += (s, e) => DisplayMessage("Button one clicked");

            var fabTwo = FindViewById<FloatingActionButton>(Resource.Id.fab_two);
            fabTwo.Click += (s, e) => DisplayMessage("Button two clicked");

            var fabThree = FindViewById<FloatingActionButton>(Resource.Id.fab_three);
            fabThree.Click += (s, e) => DisplayMessage("Button three clicked");
        }

        private void DisplayMessage(string message)
        {
            var dialog = new AlertDialog.Builder(this, Resource.Style.AlertsDialogTheme)
                .SetMessage(message)
                .SetCancelable(true)
                .SetNegativeButton("OK", (sender, args) => { })
                .Create();

            dialog.Window.SetBackgroundDrawable(new ColorDrawable(Android.Graphics.Color.Transparent));
            dialog.Window.SetElevation(16.0f);

            dialog.Show();
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.action_menu, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    return true;
                case Resource.Id.action_settings:
                    StartActivity(new Intent(this, typeof(SettingsActivity)));
                    return true;
                default:
                    return base.OnOptionsItemSelected(item);
            }
        }

        public override void OnBackPressed()
        {
            if (FragmentManager.BackStackEntryCount > 1)
            {
                FragmentManager.PopBackStack();
            }
            else
            {
                StartActivity(new Intent(Intent.ActionMain)
                    .AddCategory(Intent.CategoryHome));
            }
        }
    }
}

