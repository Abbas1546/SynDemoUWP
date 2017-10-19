using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using SyncfusionUWPApp22.Models;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SyncfusionUWPApp22
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public static SplitView NewSplitView;
        public static ListBox NewSpiltViewPaneListBox;
        public static TextBlock NewLayoutHeader;
        public static Button NewBackButton;
        public static ListBox NewListBox;

        public MainPage()
        {
            this.InitializeComponent();
            FrameNavigationService.CurrentFrame = this.MyFrame;
            SpiltViewPaneListBox.SelectedIndex = 0;
            FrameNavigationService.CurrentFrame.Navigate(typeof(Item1), this);
            layoutheader.Text = "Main Page";
            NewSplitView = MySplitView;
            NewSpiltViewPaneListBox = SpiltViewPaneListBox;
            NewLayoutHeader = layoutheader;
            NewBackButton = backbutton;
            NewListBox = SpiltViewPaneListBox;
            this.backbutton.Visibility = Visibility.Collapsed;
        }
    }
}
