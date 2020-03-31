using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using The_Song_Mind.Pages;

namespace The_Song_Mind
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Start main menu page
            MainMenuPage page = new MainMenuPage();
            mainFrame.NavigationService.Navigate(page);
        }

        #region Public Helpers

        /// <summary>
        /// Switch page in frame to <see cref="page"/>
        /// </summary>
        /// <param name="page">The page to change to</param>
        public static void ChangePage(object page)
        {
            // Search for window
            foreach (Window window in Application.Current.Windows)
            {
                // If window is MainWindow
                if (window.GetType() == typeof(MainWindow))
                {
                    // mainFrame navigate to parameter page
                    (window as MainWindow).mainFrame.NavigationService.Navigate(page);
                }
            }
        }

        /// <summary>
        /// Change title of window to <see cref="newTitle"/>
        /// </summary>
        /// <param name="newTitle"></param>
        public static void ChangeTitle(string newTitle)
        {
            try
            {
                // Search for window
                foreach (Window window in Application.Current.Windows)
                {
                    // If window is MainWindow
                    if (window.GetType() == typeof(MainWindow))
                    {
                        // mainFrame navigate to parameter page
                        (window as MainWindow).Title = newTitle;
                    }
                }
            }
            catch
            {
                // Search for window
                foreach (Window window in Application.Current.Windows)
                {
                    // If window is MainWindow
                    if (window.GetType() == typeof(MainWindow))
                    {
                        // mainFrame navigate to parameter page
                        (window as MainWindow).Title = "New Song";
                    }
                }
            }
        }
        #endregion
    }
}
