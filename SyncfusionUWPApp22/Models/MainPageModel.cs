using Windows.System.Profile;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace SyncfusionUWPApp22.Models
{
    /// <summary>
    /// FrameNavigationService class for navigation
    /// </summary>
    public class FrameNavigationService
    {

        public static Button BackButton;
        public static TextBlock Header;

        public static Frame currentFrame;

        /// <summary>
        /// To get the current frame
        /// </summary>
        public static Frame CurrentFrame
        {
            get
            {
                return currentFrame;
            }
            set
            {
                currentFrame = value;
            }
        }

        /// <summary>
        /// Go back in the frame
        /// </summary>
        public static void GoBack()
        {
            if (CurrentFrame.CanGoBack)
            {
                CurrentFrame.GoBack();
            }

            if (!CurrentFrame.CanGoBack)
            {
                if (BackButton != null)
                    BackButton.Visibility = Visibility.Collapsed;
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
            }
        }
    }

    public static class DeviceFamily
    {
        public static Devices GetDeviceFamily()
        {
            if (AnalyticsInfo.VersionInfo.DeviceFamily == "Windows.Mobile")
                return Devices.Mobile;
            return Devices.Desktop;
        }
    }

    /// <summary>
    /// Enum for devices
    /// </summary>
    public enum Devices
    {
        Desktop,
        Mobile
    }
}
