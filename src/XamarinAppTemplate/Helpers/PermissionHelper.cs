using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace XamarinAppTemplate.Helpers
{
    public class PermissionHelper
    {
        public static async Task<bool> RequestLocationPermission()
        {
            try
            {
                var status = await CrossPermissions.Current.CheckPermissionStatusAsync<LocationAlwaysPermission>();

                if (status != PermissionStatus.Granted)
                {
                    var shouldDisplay = await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.LocationAlways);

                    status = await CrossPermissions.Current.RequestPermissionAsync<LocationAlwaysPermission>();
                }

                if (status == PermissionStatus.Granted)
                {
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
