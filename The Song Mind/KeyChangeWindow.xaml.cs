using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using The_Song_Mind.DataModels;

namespace The_Song_Mind
{
    /// <summary>
    /// Interaction logic for KeyChangeWindow.xaml
    /// </summary>
    public partial class KeyChangeWindow : Window
    {
        #region Private Members

        // Create object for song info storage
        SongInfo songInfo;

        #endregion

        public KeyChangeWindow(SongInfo songInfo)
        {
            InitializeComponent();
            this.songInfo = songInfo;
        }

        #region KeyNote Events

        /// <summary>
        /// Event when key note button pressed
        /// </summary>
        /// <param name="sender">Button clicked</param>
        /// <param name="e">Event Arguments</param>
        private void Key_Note_Checked(object sender, RoutedEventArgs e)
        {
            // Cast sender to 'button'
            ToggleButton button = (ToggleButton)sender;

            // Sets keyNote accordingly
            songInfo.keyNote = Grid.GetColumn(button);

            // Ensure only one can be active
            UncheckAllKeyNotesExcept(songInfo.keyNote);
        }

        /// <summary>
        /// Event when active button pressed
        /// </summary>
        /// <param name="sender">Button clicked</param>
        /// <param name="e">Event Arguments</param>
        private void Key_Note_Unchecked(object sender, RoutedEventArgs e)
        {
            // Revert to unusable value
            songInfo.keyNote = 12;
        }

        #endregion

        #region KeyTonal Events

        /// <summary>
        /// Event when major button is pressed
        /// </summary>
        /// <param name="sender">Event Sender</param>
        /// <param name="e">Event Arguments</param>
        private void Major_Checked(object sender, RoutedEventArgs e)
        {
            // Deselect minor
            Minor.IsChecked = false;

            // Set tonality to major
            songInfo.keyMajor = true;

            // Set key signatures correctly
            SetKeySigs(songInfo.keyMajor);
        }

        /// <summary>
        /// Event when active major button is pressed
        /// </summary>
        /// <param name="sender">Event Sender</param>
        /// <param name="e">Event Arguments</param>
        private void Major_Unchecked(object sender, RoutedEventArgs e)
        {
            // Toggle to minor
            Minor.IsChecked = true;
        }

        /// <summary>
        /// Event when minor button is pressed
        /// </summary>
        /// <param name="sender">Event Sender</param>
        /// <param name="e">Event Arguments</param>
        private void Minor_Checked(object sender, RoutedEventArgs e)
        {
            // Deselect major
            Major.IsChecked = false;

            // Set tonality to minor
            songInfo.keyMajor = false;

            // Set key signatures correctly
            SetKeySigs(songInfo.keyMajor);
        }

        /// <summary>
        /// Event when active minor button is pressed
        /// </summary>
        /// <param name="sender">Event Sender</param>
        /// <param name="e">Event Arguments</param>
        private void Minor_Unchecked(object sender, RoutedEventArgs e)
        {
            // Toggle to major
            Major.IsChecked = true;
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
        /// Ensure only specified button in Key Notes is checked
        /// </summary>
        /// <param name="note">Note to keep checked</param>
        private void UncheckAllKeyNotesExcept(int note)
        {
            if (note != 0)
            {
                AKey.IsChecked = false;
            }
            if (note != 1)
            {
                BbKey.IsChecked = false;
            }
            if (note != 2)
            {
                BKey.IsChecked = false;
            }
            if (note != 3)
            {
                CKey.IsChecked = false;
            }
            if (note != 4)
            {
                DbKey.IsChecked = false;
            }
            if (note != 5)
            {
                DKey.IsChecked = false;
            }
            if (note != 6)
            {
                EbKey.IsChecked = false;
            }
            if (note != 7)
            {
                EKey.IsChecked = false;
            }
            if (note != 8)
            {
                FKey.IsChecked = false;
            }
            if (note != 9)
            {
                GbKey.IsChecked = false;
            }
            if (note != 10)
            {
                GKey.IsChecked = false;
            }
            if (note != 11)
            {
                AbKey.IsChecked = false;
            }
        }

        /// <summary>
        /// Check if confirm button should appear and if so make it appear
        /// </summary>
        private bool AllFieldsFilled()
        {
            if (songInfo.keyNote != 12 & ((bool)Major.IsChecked ^ (bool)Minor.IsChecked))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Change key signatures of specific scales for musical accuracy
        /// </summary>
        /// <param name="Major">Changing to major or minor</param>
        private void SetKeySigs(bool Major)
        {
            if (Major)
            {
                DbKey.Content = "Db";
                GbKey.Content = "Gb";
                AbKey.Content = "Ab";
            }
            else
            {
                DbKey.Content = "C#";
                GbKey.Content = "F#";
                AbKey.Content = "G#";
            }
        }

        #endregion
    }
}
