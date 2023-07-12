using Android.OS;
using Android.Views;

namespace Tiny.Toolkits.Android
{


    public static class CommonUtility
    {
        public static void ChangeStatusBarColor(this Activity activity, System.Drawing.Color color)
        { 
            bool isColorDark = color.ToAndroidColor().IsColorDark();

            activity.Window!.SetStatusBarColor(color.ToAndroidColor());

            if (Build.VERSION.SdkInt < BuildVersionCodes.M)
            {
                return;
            }

            activity.Window!.DecorView!.SystemUiVisibility = isColorDark switch
            {
                true => StatusBarVisibility.Visible,
                false => (StatusBarVisibility)SystemUiFlags.LightStatusBar, 
            }; 
             
        }
    }
}