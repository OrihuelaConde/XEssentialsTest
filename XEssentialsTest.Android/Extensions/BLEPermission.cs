using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Essentials;

namespace XEssentialsTest.Droid.Extensions
{
    public partial class BLEPermission : Permissions.BasePlatformPermission
    {
        public override (string androidPermission, bool isRuntime)[] RequiredPermissions =>
            new (string, bool)[]
            {
                (Manifest.Permission.AccessCoarseLocation, true),
                (Manifest.Permission.AccessFineLocation, true),
                (Manifest.Permission.Bluetooth, true),
                (Manifest.Permission.BluetoothAdmin, true)
            };
    }
}