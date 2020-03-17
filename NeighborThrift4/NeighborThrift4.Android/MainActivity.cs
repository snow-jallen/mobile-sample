﻿using System.IO;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using NeighborThrift4.Services;
using Prism;
using Prism.Ioc;

namespace NeighborThrift4.Droid
{
    [Activity(Label = "NeighborThrift4", Icon = "@mipmap/ic_launcher", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
		internal static MainActivity Instance { get; private set; }
		protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App(new AndroidInitializer()));
			Instance = this;
        }

		public static readonly int PickImageId = 1000;

		public TaskCompletionSource<Stream> PickImageTaskCompletionSource { set; get; }

		protected override void OnActivityResult(int requestCode, Result resultCode, Intent intent)
		{
			base.OnActivityResult(requestCode, resultCode, intent);

			if (requestCode == PickImageId)
			{
				if ((resultCode == Result.Ok) && (intent != null))
				{
					Android.Net.Uri uri = intent.Data;
					Stream stream = ContentResolver.OpenInputStream(uri);

					// Set the Stream as the completion of the Task
					PickImageTaskCompletionSource.SetResult(stream);
				}
				else
				{
					PickImageTaskCompletionSource.SetResult(null);
				}
			}
		}
	}


    public class AndroidInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
			containerRegistry.Register<IPhotoPickerService, PhotoPickerService>();
        }
    }
}

