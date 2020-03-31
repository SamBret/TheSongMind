using System;
using System.IO;
using System.Windows;
using The_Song_Mind.Pages;

namespace The_Song_Mind.DataModels
{
    public class SongInfo
    {
        #region Public Members

        public string fileName;
        public int keyNote = 12;
        public bool keyMajor;
        public string timeSig;
        public bool lowerExp;
        public int tempo = 100;
        public bool[,] melody;
        public string[] syllables;
        public bool[] rhythm = new bool[16];
        public string lyrics;

        #endregion

        #region Constructor

        public SongInfo(string projectFile)
        {
            // If making new song project
            if (projectFile == "")
            {
                return;
            }

            try
            {
                // Open file to "songFile"
                StreamReader songFile = new StreamReader(projectFile);

                // Assign values from file
                fileName = songFile.ReadLine();
                keyNote = Int32.Parse(songFile.ReadLine());
                keyMajor = songFile.ReadLine() == "true";
                timeSig = songFile.ReadLine();
                tempo = Int32.Parse(songFile.ReadLine());
                string temp = songFile.ReadLine();
                melody = new bool[temp.Length, 22];
                for (int i = 0; i < temp.Length; i++)
                {
                    melody[i, 0] = temp[i] == '1';
                }
                for (int i = 1; i < 22; i++)
                {
                    temp = songFile.ReadLine();
                    for (int j = 0; j < temp.Length; j++)
                    {
                        melody[j,i] = temp[j] == '1';
                    }
                }

                for (int i = 0; i < 16; i++)
                {
                    rhythm[i] = songFile.ReadLine() == "true";
                }

                // lyrics gets all remaining lines
                string currentLine = songFile.ReadLine();
                while (currentLine != null)
                {
                    lyrics += currentLine + Environment.NewLine;
                    currentLine = songFile.ReadLine();
                }

                // Close file
                songFile.Close();

                UpdateSyllables();
            }
            catch
            {
                MessageBox.Show("Invalid or corrupted file, start a new song or open a new file");
                MainMenuPage page = new MainMenuPage();
                MainWindow.ChangePage(page);
            }
        }

        #endregion

        #region Public Helpers

        public void UpdateSyllables()
        {
            try
            {
                string tempLyrics = lyrics.Replace(Environment.NewLine, "    ");
                syllables = tempLyrics.Split('-');
                melody = new bool[syllables.Length, 22];
            }
            catch
            {
                Console.WriteLine("Error: could not update syllables");
            }
        }

        #endregion
    }
}
