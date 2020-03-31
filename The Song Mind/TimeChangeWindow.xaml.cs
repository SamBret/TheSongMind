using System.Windows;
using System.Windows.Controls.Primitives;
using The_Song_Mind.DataModels;

namespace The_Song_Mind
{
    /// <summary>
    /// Interaction logic for TimeChangeWindow.xaml
    /// </summary>
    public partial class TimeChangeWindow : Window
    {

        #region Private Members

        // Create object for song info storage
        SongInfo songInfo;

        #endregion

        public TimeChangeWindow(SongInfo songInfo)
        {
            InitializeComponent();
            this.songInfo = songInfo;
        }

        #region TimeSig Events

        /// <summary>
        /// Event when time signature button pressed
        /// </summary>
        /// <param name="sender">Button clicked</param>
        /// <param name="e">Event Arguments</param>
        private void Time_Sig_Checked(object sender, RoutedEventArgs e)
        {
            // Cast sender to 'button'
            ToggleButton button = (ToggleButton)sender;

            // Sets timeSig accordingly
            songInfo.timeSig = button.Name;

            // Ensure only one can be active
            UncheckAllTimeSigsExcept(songInfo.timeSig);
        }

        /// <summary>
        /// Event when active button pressed
        /// </summary>
        /// <param name="sender">Button clicked</param>
        /// <param name="e">Event Arguments</param>
        private void Time_Sig_Unchecked(object sender, RoutedEventArgs e)
        {
            // Revert to unusable value
            songInfo.timeSig = "";
        }

        #endregion

        #region Confirm Event

        /// <summary>
        /// Event when Create New Song button clicked
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event Arguments</param>
        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            if (AllFieldsFilled())
            {
                Close();
            }
        }

        #endregion

        #region Private Helpers

        /// <summary>
        /// Ensure only specified button in Time Sigs is checked
        /// </summary>
        /// <param name="timeSig">Time signature to keep checked</param>
        private void UncheckAllTimeSigsExcept(string timeSig)
        {
            if (timeSig != "TF")
            {
                TF.IsChecked = false;
            }
            if (timeSig != "HF")
            {
                HF.IsChecked = false;
            }
            if (timeSig != "FF")
            {
                FF.IsChecked = false;
            }
            if (timeSig != "SE")
            {
                SE.IsChecked = false;
            }
            if (timeSig != "NE")
            {
                NE.IsChecked = false;
            }
            if (timeSig != "WE")
            {
                WE.IsChecked = false;
            }
        }

        /// <summary>
        /// Check if confirm button should appear and if so make it appear
        /// </summary>
        private bool AllFieldsFilled()
        {
            if (songInfo.timeSig != "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion
    }
}
