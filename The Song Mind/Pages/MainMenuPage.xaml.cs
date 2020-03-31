using Microsoft.Win32;
using System.Windows;
using System.Windows.Controls;

namespace The_Song_Mind.Pages
{
    /// <summary>
    /// Interaction logic for MainMenuPage.xaml
    /// </summary>
    public partial class MainMenuPage : Page
    {
        public MainMenuPage()
        {
            InitializeComponent();
        }

        #region Button Events

        /// <summary>
        /// Go to New Song Page
        /// </summary>
        /// <param name="sender">Event Sender (ie. button)</param>
        /// <param name="e">Event arguments</param>
        private void NewSong_Click(object sender, RoutedEventArgs e)
        {
            Page1 page = new Page1();
            MainWindow.ChangePage(page);
        }

        /// <summary>
        /// Go to Main Development Page with opened song project file
        /// </summary>
        /// <param name="sender">Event Sender (ie. button)</param>
        /// <param name="e">Event arguments</param>
        private void ContinueSong_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if ((bool)openFileDialog.ShowDialog())
            {
                // Go to Main Development Page
                MainDevPage page = new MainDevPage(null, openFileDialog.FileName);
                MainWindow.ChangePage(page);
            }
        }

        /// <summary>
        /// Go to Options Page
        /// </summary>
        /// <param name="sender">Event Sender (ie. button)</param>
        /// <param name="e">Event arguments</param>
        private void Options_Click(object sender, RoutedEventArgs e)
        {
            OptionsPage page = new OptionsPage();
            MainWindow.ChangePage(page);
        }

        #endregion
    }
}
