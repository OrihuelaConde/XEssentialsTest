using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreBluetooth;
using Foundation;
using UIKit;
using Xamarin.Essentials;

namespace XEssentialsTest.iOS.Extensions
{
    public partial class BLEPermission : Permissions.BasePlatformPermission
    {
        protected override Func<IEnumerable<string>> RequiredInfoPlistKeys =>
                () => new string[] { "NSBluetoothAlwaysUsageDescription" };

        public override Task<PermissionStatus> CheckStatusAsync()
        {
            EnsureDeclared();

            return Task.FromResult(CheckPermissionsStatus());
        }

        public override async Task<PermissionStatus> RequestAsync()
        {
            EnsureDeclared();

            var status = CheckPermissionsStatus();
            if (status == PermissionStatus.Granted)
                return status;

            EnsureMainThread();

            return await RequestPermissionAsync();
        }

        internal void EnsureMainThread()
        {
            if (!MainThread.IsMainThread)
                throw new PermissionException("Permission request must be invoked on main thread.");
        }

        internal PermissionStatus CheckPermissionsStatus()
        {
            var status = CBManager.Authorization;
            return status switch
            {
                CBManagerAuthorization.AllowedAlways => PermissionStatus.Granted,
                CBManagerAuthorization.Denied => PermissionStatus.Denied,
                CBManagerAuthorization.Restricted => PermissionStatus.Restricted,
                _ => PermissionStatus.Unknown,
            };
        }

        internal async Task<PermissionStatus> RequestPermissionAsync()
        {
            try
            {
                using var CBCentralManager = new CBCentralManager();
                return CheckPermissionsStatus();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get Bluetooth LE permission: " + ex);
                return PermissionStatus.Unknown;
            }
        }
    }
}