using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using The_Song_Mind.DataModels;

namespace The_Song_Mind.Pages
{
    /// <summary>
    /// Interaction logic for RhythmDevPage.xaml
    /// </summary>
    public partial class RhythmDevPage : Page
    {

        SongInfo songInfo;
        bool[] rhythm1 = { true, false, false, false, true, false, false, true, false, true, true, false, true, false, true, true };
        bool[] rhythm2 = { true, false, false, false, true, false, true, false, false, false, true, false, true, false, true, false };
        bool[] rhythm3 = { true, false, true, false, true, false, true, false, true, false, true, false, true, false, true, false };
        bool[] rhythm4 = { true, false, true, false, true, true, true, true, true, false, true, false, true, true, true, true };

        #region Constructor

        public RhythmDevPage(SongInfo songInfo)
        {
            this.songInfo = songInfo;
            InitializeComponent();
            for (int i = 0; i < 16; i++)
            {
                ((ToggleButton)GetChild(rhythmGrid, i, 1)).IsChecked = songInfo.rhythm[i];
            }
        }


        #endregion

        #region Rhythm Events

        /// <summary>
        /// Event when 1st rhythm button clicked
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        private void Rhythm1_Click(object sender, RoutedEventArgs e)
        {
            PlaceRhythm(rhythm1);
        }

        /// <summary>
        /// Event when 2nd rhythm button clicked
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        private void Rhythm2_Click(object sender, RoutedEventArgs e)
        {
            PlaceRhythm(rhythm2);
        }

        /// <summary>
        /// Event when 3rd rhythm button clicked
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        private void Rhythm3_Click(object sender, RoutedEventArgs e)
        {
            PlaceRhythm(rhythm3);
        }

        /// <summary>
        /// Event when 4th rhythm button clicked
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        private void Rhythm4_Click(object sender, RoutedEventArgs e)
        {
            PlaceRhythm(rhythm4);
        }

        void PlaceRhythm(bool[] rhythm)
        {
            if (MessageBox.Show("Use rhythm? (Doing this will wipe any current rhythm entirely)", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                for (int i = 0; i < 16; i++)
                {
                    ((ToggleButton)rhythmGrid.FindName("Beat" + (i + 1))).IsChecked = rhythm[i];
                    songInfo.rhythm[i] = rhythm[i];
                }
            }
        }

        #endregion

        #region Beat Event

        /// <summary>
        /// Event when a beat is toggled
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        private void Beat_Click(object sender, RoutedEventArgs e)
        {
            if (((ToggleButton)sender).Name.Length == 5)
            {
                songInfo.rhythm[Int32.Parse(((ToggleButton)sender).Name[4].ToString()) - 1] = (bool)((ToggleButton)sender).IsChecked;
            }
            else
            {
                songInfo.rhythm[Int32.Parse(((ToggleButton)sender).Name.Substring(4, 2)) - 1] = (bool)((ToggleButton)sender).IsChecked;
            }
        }

        #endregion

        #region Back Event

        /// <summary>
        /// Event when back button pressed
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            // Change page back
            MainDevPage page = new MainDevPage(songInfo, "");
            MainWindow.ChangePage(page);
        }

        #endregion

        #region Private Helpers

        /// <summary>
        /// Access element in grid
        /// </summary>
        /// <param name="grid">Grid to search</param>
        /// <param name="row">Specified row</param>
        /// <param name="column">Specified column</param>
        /// <returns></returns>
        private static UIElement GetChild(Grid grid, int column, int row)
        {
            foreach (UIElement child in grid.Children)
            {
                if (Grid.GetRow(child) == row && Grid.GetColumn(child) == column && child.GetType().ToString() == "System.Windows.Controls.Primitives.ToggleButton")
                {
                    return child;
                }
            }
            return null;
        }

        #endregion
    }
}
