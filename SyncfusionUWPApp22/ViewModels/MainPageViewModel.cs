using SyncfusionUWPApp22.Models;
using System.Windows.Input;
using Syncfusion.UI.Xaml.Utils;
using System;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace SyncfusionUWPApp22.ViewModels
{
    /// <summary>
    /// ViewModel class of MainWindow
    /// </summary>
    public class MainPageViewModel
    {
        private ICommand hamburgerMenuButtonCommand;
        private ICommand backButtonCommand;
        private ICommand splitViewPaneClosed;
        private ICommand listBoxSelectionChanged;

        /// <summary>
        /// Command for HamburgerMenuButton
        /// </summary>
        public ICommand HamburgerMenuCommand
        {
            get
            {
                return hamburgerMenuButtonCommand ?? (hamburgerMenuButtonCommand = new CommandHandler(() => HamburgerMenuButtonClicked(), true));
            }
        }

        /// <summary>
        /// Command for BackButton
        /// </summary>
        public ICommand BackButtonCommand
        {
            get
            {
                return backButtonCommand ?? (backButtonCommand = new CommandHandler(() => BackButtonClicked(), true));
            }
        }

        /// <summary>
        /// Command for SplitViewPaneClosed event
        /// </summary>
        public ICommand SplitViewPaneClosedCommand
        {
            get
            {
                return splitViewPaneClosed ?? (splitViewPaneClosed = new CommandHandler(() => SplitViewPaneClosed(), true));
            }
        }

        /// <summary>
        /// Command for ListBoxSelectionChanged event
        /// </summary>
        public ICommand ListBoxSelectionChangedCommand
        {
            get
            {
                return listBoxSelectionChanged ?? (listBoxSelectionChanged = new CommandHandler(() => ListBoxSelectionChanged(), true));
            }
        }

        /// <summary>
        /// Operations on clicking HamburgerMenu button
        /// </summary>
        public void HamburgerMenuButtonClicked()
        {
            MainPage.NewSplitView.IsPaneOpen = !MainPage.NewSplitView.IsPaneOpen;

            if (MainPage.NewSplitView.IsPaneOpen)
                MainPage.NewSplitView.Content.Opacity = 0.4;
        }

        /// <summary>
        /// Operations on clicking back button
        /// </summary>
        public void BackButtonClicked()
        {
            FrameNavigationService.GoBack();
        }

        /// <summary>
        /// Operations on SplitViewPaneClosed
        /// </summary>
        public void SplitViewPaneClosed()
        {
            MainPage.NewSplitView.Content.Opacity = 1;
        }

        /// <summary>
        /// Operations on ListBoxSelectionChanged
        /// </summary>
        private void ListBoxSelectionChanged()
        {
            if (FrameNavigationService.CurrentFrame == null)
                return;
            var listBox = MainPage.NewListBox;
            if (DeviceFamily.GetDeviceFamily() == Devices.Desktop)
            {
                MainPage.NewSplitView.Content = FrameNavigationService.CurrentFrame;

                if (listBox.SelectedIndex == 0)
                {
                    MainPage.NewLayoutHeader.Text = "Main Page";
                    FrameNavigationService.CurrentFrame.Navigate(typeof(Item1), this);
                    if (MainPage.NewSplitView.IsPaneOpen)
                        MainPage.NewSplitView.IsPaneOpen = false;
                    MainPage.NewBackButton.Visibility = Visibility.Visible;
                }
                else if (listBox.SelectedIndex == 1)
                {
                    MainPage.NewLayoutHeader.Text = "Page with Tab";
                    FrameNavigationService.CurrentFrame.Navigate(typeof(Item2), this);
                    if (MainPage.NewSplitView.IsPaneOpen)
                        MainPage.NewSplitView.IsPaneOpen = false;
                    MainPage.NewBackButton.Visibility = Visibility.Visible;
                }
                else if (listBox.SelectedIndex == 2)
                {
                    MainPage.NewLayoutHeader.Text = "Page with ListView";
                    FrameNavigationService.CurrentFrame.Navigate(typeof(Item3), this);
                    if (MainPage.NewSplitView.IsPaneOpen)
                        MainPage.NewSplitView.IsPaneOpen = false;
                    MainPage.NewBackButton.Visibility = Visibility.Visible;
                }
            }
            else
            {
                if (listBox.SelectedIndex == 0)
                {

                    FrameNavigationService.Header.Text = "Main Page";
                    FrameNavigationService.CurrentFrame.Navigate(typeof(Item1), this);
                    if (MainPage.NewSplitView.IsPaneOpen)
                        MainPage.NewSplitView.IsPaneOpen = false;

                }

                else if (listBox.SelectedIndex == 1)
                {
                    FrameNavigationService.Header.Text = "Page with Tab";
                    FrameNavigationService.CurrentFrame.Navigate(typeof(Item2), this);
                    if (MainPage.NewSplitView.IsPaneOpen)
                        MainPage.NewSplitView.IsPaneOpen = false;
                }
                else if (listBox.SelectedIndex == 2)
                {
                    MainPage.NewLayoutHeader.Text = "Page with ListView";
                    FrameNavigationService.CurrentFrame.Navigate(typeof(Item3), this);
                    if (MainPage.NewSplitView.IsPaneOpen)
                        MainPage.NewSplitView.IsPaneOpen = false;
                }
                if (!MainPage.NewSplitView.IsPaneOpen)
                {
                    MainPage.NewSpiltViewPaneListBox.SelectedIndex = -1;
                }
            }
        }

        /// <summary>
        /// Operations on OnListSelectionChanged
        /// </summary>
        private static void OnListSelectionChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            int a = (int)e.NewValue;
            MainPage main = d as MainPage;
            MainPage.NewSpiltViewPaneListBox.SelectedIndex = a;
            if (a == 0)
                FrameNavigationService.Header.Text = "Main Page";
            else if (a == 1)
                FrameNavigationService.Header.Text = "Page with Tab";
            else if (a == 2)
                FrameNavigationService.Header.Text = "Page with ListView";
        }
    }
}
