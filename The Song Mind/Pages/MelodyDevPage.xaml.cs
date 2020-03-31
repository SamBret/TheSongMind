using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;
using The_Song_Mind.DataModels;

namespace The_Song_Mind.Pages
{

    /// <summary>
    /// Interaction logic for MelodyDevPage.xaml
    /// </summary>
    public partial class MelodyDevPage : Page
    {
        SongInfo songInfo;
        Polygon playShape;
        Polyline pauseShape;
        DispatcherTimer scrollTimer;

        #region Constructors

        public MelodyDevPage(SongInfo songInfo)
        {
            this.songInfo = songInfo;
            InitializeComponent();
            AddElements();
        }

        private void AddElements()
        {
            // Draw play icon
            playShape = new Polygon();
            Point PointA1 = new Point(4, 5);
            Point PointA2 = new Point(44, 28);
            Point PointA3 = new Point(4, 51);
            PointCollection pointCollection1 = new PointCollection
            {
                PointA1,
                PointA2,
                PointA3
            };
            playShape.Points = pointCollection1;

            // Add play icon to play button
            Play.Content = playShape;

            // Draw pause icon
            pauseShape = new Polyline();
            Point PointB1 = new Point(4, 47);
            Point PointB2 = new Point(4, 1);
            Point PointB3 = new Point(32, 1);
            Point PointB4 = new Point(32, 47);
            PointCollection pointCollection2 = new PointCollection
            {
                PointB1,
                PointB2,
                PointB3,
                PointB4
            };
            pauseShape.Points = pointCollection2;

            // Add pause icon to pause button
            Pause.Content = pauseShape;

            // All notes
            string[] notes = { "A", "Bb", "B", "C", "Db", "D", "Eb", "E", "F", "Gb", "G", "Ab" };

            // Switch to minor
            if (!songInfo.keyMajor)
            {
                notes[4] = "C#";
                notes[9] = "F#";
                notes[11] = "G#";
            }

            // Note in scale
            int count = 0;

            // Set notes on side to correct values
            for (int i = 0; i < 37; i++)
            {
                if (songInfo.keyMajor && ((i % 12 == 1) || (i % 12 == 3) || (i % 12 == 6) || (i % 12 == 8) || (i % 12 == 10)))
                {
                    continue;
                }
                if (!songInfo.keyMajor && ((i % 12 == 1) || (i % 12 == 4) || (i % 12 == 6) || (i % 12 == 9) || (i % 12 == 11)))
                {
                    continue;
                }
                ((TextBlock)Notes.FindName("Note" + count)).Text = notes[(i + songInfo.keyNote) % 12] + (count / 7 + 1).ToString();
                count++;
            }

            for (int i = 0; i < songInfo.syllables.Length; i++)
            {
                // add lyrics to screen
                lyrics.Text += songInfo.syllables[i].Replace(Environment.NewLine, "    ");

                // make columns based on lyric syllables
                ColumnDefinition column = new ColumnDefinition();
                column.Width = new GridLength(songInfo.syllables[i].Length * 48);
                melodyGrid.ColumnDefinitions.Add(column);

                // iterate through rows of column i
                for (int j = 0; j < 22; j++)
                {
                    // make new togglebutton
                    ToggleButton toggleButton = new ToggleButton();
                    string iString, jString;
                    // give togglebutton name
                    iString = i.ToString().Length == 1 ? "0" + i : i.ToString();
                    jString = j.ToString().Length == 1 ? "0" + j : j.ToString();
                    toggleButton.Name = "Pitch" + jString + "Time" + iString;
                    // give togglebutton event handlers
                    toggleButton.Checked += new RoutedEventHandler(NoteButton_Checked);
                    toggleButton.Unchecked += new RoutedEventHandler(NoteButton_Unchecked);
                    // give togglebutton data from file
                    toggleButton.IsChecked = songInfo.melody[i, j];

                    // add new togglebutton to next point in grid
                    Grid.SetColumn(toggleButton, i);
                    Grid.SetRow(toggleButton, j);
                    melodyGrid.Children.Add(toggleButton);
                }
            }
        }

        #endregion

        #region Events

        #region Scroll Event

        /// <summary>
        /// Event when changing scroll on ScrollButtons
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        public void ButtonScrollChanged(object sender, RoutedEventArgs e)
        {
            // Match scroll of lyrics to scroll of button grid
            ScrollLyrics.ScrollToHorizontalOffset(ScrollButtons.HorizontalOffset);

            // Match scroll of notes to scroll of button grid
            ScrollNotes.ScrollToVerticalOffset(ScrollButtons.VerticalOffset);
        }

        #endregion

        #region Note Event

        /// <summary>
        /// Event when note button checked
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        public void NoteButton_Checked(object sender, RoutedEventArgs e)
        {
            // Remove repeats
            string buttonName = ((ToggleButton)sender).Name;
            
            // Set value in songInfo melody to corresponding note
            songInfo.melody[Int32.Parse(buttonName.Substring(11, 2)), Int32.Parse(buttonName.Substring(5, 2))] = true;
        }

        /// <summary>
        /// Event when note button checked
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        public void NoteButton_Unchecked(object sender, RoutedEventArgs e)
        {
            // Remove repeats
            string buttonName = ((ToggleButton)sender).Name;

            // Set value in songInfo melody to corresponding note
            songInfo.melody[Int32.Parse(buttonName.Substring(11, 2)), Int32.Parse(buttonName.Substring(5, 2))] = false;
        }

        #endregion

        #region Back Event

        /// <summary>
        /// Event when back button clicked
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

        #region Play Events

        /// <summary>
        /// Event when mouse enters play button
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        public void Play_MouseEnter(object sender, MouseEventArgs e)
        {
            // Change play shape fill to match play button fill
            playShape.Fill = (Brush)(new BrushConverter().ConvertFrom("#BEE6FD"));
        }

        /// <summary>
        /// Event when mouse leaves play button
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        public void Play_MouseLeave(object sender, MouseEventArgs e)
        {
            // Change play shape fill to white
            playShape.Fill = (Brush)(new BrushConverter().ConvertFrom("White"));
        }

        /// <summary>
        /// Event when play button pressed
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        public void Play_Click(object sender, RoutedEventArgs e)
        {
            scrollTimer = new DispatcherTimer
            {
                // Set interval for scroll inversely proportional to tempo
                Interval = TimeSpan.FromMilliseconds(100 / songInfo.tempo)
            };

            // Run scroll_Tick every interval
            scrollTimer.Tick += Scroll_Tick;

            // Start timer
            scrollTimer.Start();
        }

        /// <summary>
        /// Event for handling scroll
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Scroll_Tick(object sender, EventArgs e)
        {
            // Scroll every interval
            ScrollButtons.ScrollToHorizontalOffset(ScrollButtons.HorizontalOffset + 1);
        }

        #endregion

        #region Pause Event

        /// <summary>
        /// Event when pause button pressed
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        public void Pause_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Stop scrolling/timer
                scrollTimer.Stop();
            }
            catch
            {
                Console.WriteLine("Pause pressed before play");
            }
        }

        #endregion

        #region Random Melody Event

        /// <summary>
        /// Event when random melody button clicked
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        public void RandomMelody_Click(object sender, RoutedEventArgs e)
        {
            ToggleButton toggleButton;
            if (MessageBox.Show("Generate Random Melody? (Doing this will wipe any current melody entirely)", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                // Wipe previous melody
                for (int i = 0; i < songInfo.syllables.Length; i++)
                {
                    for (int j = 0; j < 22; j++)
                    {
                        Console.WriteLine("i: {0}, j: {1}", i, j);
                        toggleButton = (ToggleButton)GetChild(melodyGrid, i, j);
                        toggleButton.IsChecked = false;
                    }
                }

                Random rand = new Random();
                int[] roots = { 0, 7, 14, 21 };
                int rootNote = roots[rand.Next(0, 4)];
                toggleButton = (ToggleButton)GetChild(melodyGrid, 0, rootNote);
                toggleButton.IsChecked = true;
                for (int i = 1; i < songInfo.syllables.Length - 1; i++)
                {
                    toggleButton = (ToggleButton)GetChild(melodyGrid, i, (rootNote + rand.Next(-7, 7) + 22) % 22);
                    toggleButton.IsChecked = true;
                }
                toggleButton = (ToggleButton)GetChild(melodyGrid, songInfo.syllables.Length - 1, rootNote);
                toggleButton.IsChecked = true;
            }
        }

        #endregion

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
                if (Grid.GetRow(child) == row && Grid.GetColumn(child) == column)
                {
                    return child;
                }
            }
            return null;
        }

        #endregion
    }

}
