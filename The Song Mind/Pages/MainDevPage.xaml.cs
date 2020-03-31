using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;
using The_Song_Mind.DataModels;

namespace The_Song_Mind.Pages
{
    /// <summary>
    /// Interaction logic for MainDevPage.xaml
    /// </summary>
    public partial class MainDevPage : Page
    {
        SongInfo songInfo;
        Polygon playShape;
        Polyline pauseShape;
        DispatcherTimer scrollTimer;
        DispatcherTimer metronomeTimer;
        MediaPlayer sound = new MediaPlayer();
        int metronomeCount;
        int barLength;

        #region Constructors

        public MainDevPage(SongInfo newSongInfo, string projectFile)
        {
            if (newSongInfo == null)
            {
                songInfo = new SongInfo(projectFile);
                int tempTempo = songInfo.tempo;
                InitializeComponent();
                songInfo.tempo = tempTempo;
                AddElements();
                return;
            }

            songInfo = newSongInfo;

            InitializeComponent();
            AddElements();
        }

        /// <summary>
        /// Construct part of page not in .xaml
        /// </summary>
        private void AddElements()
        {
            // Decode timeSig
            if (songInfo.timeSig[0] == 'T')
            {
                barLength = 2;
            }
            else if (songInfo.timeSig[0] == 'H')
            {
                barLength = 3;
            }
            else if (songInfo.timeSig[0] == 'F')
            {
                barLength = 4;
            }
            else if (songInfo.timeSig[0] == 'S')
            {
                barLength = 6;
            }
            else if (songInfo.timeSig[0] == 'N')
            {
                barLength = 9;
            }
            else if (songInfo.timeSig[0] == 'W')
            {
                barLength = 12;
            }
            else
            {
                barLength = 4;
            }

            // Update on screen values
            MainWindow.ChangeTitle(songInfo.fileName);
            TempoSlider.Value = songInfo.tempo;
            TempoReadout.Text = songInfo.tempo.ToString() + "bpm";
            Lyrics.Text = songInfo.lyrics;

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

            // Construct rectangles for metronome
            InitMetronome();
        }

        public void InitMetronome()
        {
            for (int i = 0; i < barLength; i++)
            {
                // Add new column to grid
                ColumnDefinition column = new ColumnDefinition();
                column.Width = new GridLength(1, GridUnitType.Star);
                BarCounter.ColumnDefinitions.Add(column);

                // Create rectangle
                Rectangle rectangle = new Rectangle();
                rectangle.Name = "Beat" + i;
                rectangle.StrokeThickness = 5;
                BrushConverter converter = new BrushConverter();
                rectangle.Stroke = (Brush)converter.ConvertFromString("Black");
                rectangle.Fill = (Brush)converter.ConvertFrom("White");

                // Add to view
                Grid.SetColumn(rectangle, i);
                BarCounter.Children.Add(rectangle);
            }
        }

        #endregion

        #region Events

        #region Drop Down Events

        /// <summary>
        /// Event when file expander expanded
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        public void File_Expanded(object sender, RoutedEventArgs e)
        {
            // Collapse edit expander
            EditDropDown.IsExpanded = false;
        }

        /// <summary>
        /// Event when edit expander expanded
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        public void Edit_Expanded(object sender, RoutedEventArgs e)
        {
            // Collapse file expander
            FileDropDown.IsExpanded = false;
        }

        #endregion

        #region Tempo Event

        /// <summary>
        /// Event when tempo slider value is changed
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        public void Tempo_ValueChanged(object sender, RoutedEventArgs e)
        {
            // Update tempo accordingly
            songInfo.tempo = Convert.ToInt32(TempoSlider.Value);

            // Update text block to read correct tempo
            TempoReadout.Text = songInfo.tempo.ToString() + "bpm";
        }

        #endregion

        #region Lyrics Event

        /// <summary>
        /// Event when lyrics box is edited
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Lyrics_Changed(object sender, TextChangedEventArgs e)
        {
            // Update Syllables for melody dev
            songInfo.UpdateSyllables();

            SongViewLyrics.Text = "";
            foreach (string i in songInfo.syllables)
            {
                //Update lyrics in song view onto one line
                SongViewLyrics.Text += i.Replace(Environment.NewLine, "    ");
            }

            // Update songInfo accordingly
            songInfo.lyrics = Lyrics.Text;
        }

        #endregion

        #region Button Events

        #region File Events

        /// <summary>
        /// Event when open button clicked
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        private void Open_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult confirmation = MessageBox.Show("Are you sure you want to open a different project? Any unsaved changes will be lost", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (confirmation == MessageBoxResult.Yes)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();

                if ((bool)openFileDialog.ShowDialog())
                {
                    // Refresh page with loaded song in place
                    MainDevPage page = new MainDevPage(null, openFileDialog.FileName);
                    MainWindow.ChangePage(page);
                }
            }

            // Close file tab
            FileDropDown.IsExpanded = false;
        }

        /// <summary>
        /// Event when save button clicked
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            // Save file with given filename
            SaveFile(songInfo.fileName);

            // Close file tab
            FileDropDown.IsExpanded = false;
        }

        /// <summary>
        /// Event when save as button clicked
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        private void SaveAs_Click(object sender, RoutedEventArgs e)
        {
            // Open file explorer for saving
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
            {
                // Store file name in file
                songInfo.fileName = saveFileDialog.FileName;

                // Save file at specified path
                SaveFile(saveFileDialog.FileName);
            }

            // Close file tab
            FileDropDown.IsExpanded = false;
        }

        #endregion

        #region Edit Events

        /// <summary>
        /// Event when key button pressed
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        private void Key_Click(object sender, RoutedEventArgs e)
        {
            KeyChangeWindow window = new KeyChangeWindow(songInfo);
            window.Show();
        }

        /// <summary>
        /// Event when time signature button pressed
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        private void TimeSig_Click(object sender, RoutedEventArgs e)
        {
            TimeChangeWindow window = new TimeChangeWindow(songInfo);
            window.Show();
        }

        #endregion

        #region Back Event

        /// <summary>
        /// Event when back button clicked
        /// </summary>
        /// <param name="sender">The event sender</param>
        /// <param name="e">Event arguments</param>
        public void Back_Click(object sender, RoutedEventArgs e)
        {
            //Change page back
            MainMenuPage page = new MainMenuPage();
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
            playShape.Fill = (Brush)new BrushConverter().ConvertFrom("#BEE6FD");
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
            scrollTimer = new DispatcherTimer();

            // Set interval for scroll inversely proportional to tempo
            scrollTimer.Interval = TimeSpan.FromMilliseconds(100 / songInfo.tempo);

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
            Scroll.ScrollToHorizontalOffset(Scroll.HorizontalOffset + 1);
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

        #region Metronome Events

        /// <summary>
        /// Event when metronome button checked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Metronome_Checked(object sender, RoutedEventArgs e)
        {
            // Change reading to "On"
            Metronome.Content = "On";

            metronomeTimer = new DispatcherTimer();

            // Set interval to be on beat
            metronomeTimer.Interval = TimeSpan.FromMilliseconds(60000 / songInfo.tempo);

            // Run metronome_Tick every interval
            metronomeTimer.Tick += metronome_Tick;

            // Set metronomeCount to zero
            metronomeCount = 0;

            // Start metronome
            metronomeTimer.Start();
        }

        /// <summary>
        /// Event on metronome beat
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void metronome_Tick(object sender, EventArgs e)
        {
            if (metronomeCount == barLength)
            {
                metronomeCount = 0;
            }

            // Light up correct rectangle
            BrushConverter converter = new BrushConverter();
            ((Rectangle)GetChild(BarCounter, metronomeCount, 0)).Fill = (Brush)converter.ConvertFrom("#BEE6FD");
            ((Rectangle)GetChild(BarCounter, (metronomeCount + 3) % 4, 0)).Fill = (Brush)converter.ConvertFrom("White");


            if (metronomeCount == 0)
            {
                // Play strong beat
                sound.Open(new Uri("C:\\Users\\samja\\Documents\\Programming\\WPF Apps\\TheSongMind\\The Song Mind\\The Song Mind\\bin\\Debug\\StrongBeat.wav"));
                sound.Play();
            }
            else
            {
                // Play weak beat
                sound.Open(new Uri("C:\\Users\\samja\\Documents\\Programming\\WPF Apps\\TheSongMind\\The Song Mind\\The Song Mind\\bin\\Debug\\WeakBeat.wav"));
                sound.Play();
            }

            metronomeCount += 1;
        }

        /// <summary>
        /// Event when metronome button unchecked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Metronome_Unchecked(object sender, RoutedEventArgs e)
        {
            // Change reading to "Off"
            Metronome.Content = "Off";

            // Remove fill on rectangle
            BrushConverter converter = new BrushConverter();
            ((Rectangle)GetChild(BarCounter, 0, 0)).Fill = (Brush)converter.ConvertFrom("White");
            ((Rectangle)GetChild(BarCounter, 1, 0)).Fill = (Brush)converter.ConvertFrom("White");
            ((Rectangle)GetChild(BarCounter, 2, 0)).Fill = (Brush)converter.ConvertFrom("White");
            ((Rectangle)GetChild(BarCounter, 3, 0)).Fill = (Brush)converter.ConvertFrom("White");


            // Stop metronome
            metronomeTimer.Stop();
        }

        #endregion

        #region Melodies Event

        /// <summary>
        /// Event when melodies button pressed
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        public void Melodies_Click(object sender, RoutedEventArgs e)
        {
            MelodyDevPage page = new MelodyDevPage(songInfo);
            MainWindow.ChangePage(page);
        }

        #endregion

        #region Rhythms Event

        /// <summary>
        /// Event when rhythms button pressed
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        public void Rhythms_Click(object sender, RoutedEventArgs e)
        {
            RhythmDevPage page = new RhythmDevPage(songInfo);
            MainWindow.ChangePage(page);
        }

        #endregion

        #endregion

        #endregion

        #region Private Helpers

        /// <summary>
        /// Save song project information to file
        /// </summary>
        /// <param name="fileName">File path to save to</param>
        private void SaveFile(string fileName)
        {
            FileStream fileStream;
            StreamWriter saveFile;
            try
            {
                // Make file for writing
                fileStream = File.Open(fileName, FileMode.Create);
                saveFile = new StreamWriter(fileStream);

                // Write values
                saveFile.WriteLine(fileName);
                saveFile.WriteLine(songInfo.keyNote);
                saveFile.WriteLine(songInfo.keyMajor);
                saveFile.WriteLine(songInfo.timeSig);
                saveFile.WriteLine(songInfo.tempo);
                string temp = "";
                for (int i = 0; i < 22; i++)
                {
                    temp = "";
                    for (int j = 0; j < songInfo.syllables.Length; j++)
                    {
                        temp += songInfo.melody[j, i] ? "1" : "0";
                    }
                    saveFile.WriteLine(temp);
                }
                for (int i = 0; i < 16; i++)
                {
                    saveFile.WriteLine(songInfo.rhythm[i] ? "true" : "false");
                }

                saveFile.WriteLine(songInfo.lyrics); // at bottom to allow for as many lines as required

                // Close file
                saveFile.Close();
            }
            catch (IOException error)
            {
                Console.WriteLine("Could not save file: " + error);
            }
        }

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
