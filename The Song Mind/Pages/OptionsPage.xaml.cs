using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using The_Song_Mind.DataModels;

namespace The_Song_Mind.Pages
{
    /// <summary>
    /// Interaction logic for OptionsPage.xaml
    /// </summary>
    public partial class OptionsPage : Page
    {
        #region Private Members

        private Options options;

        private int selectedShortcut = 0;

        #endregion

        #region Constructor

        public OptionsPage()
        {
            InitializeComponent();
            options = new Options();
            VolumeSlider.Value = options.volume;
            CutShortcut.Content = "Cut Shortcut: " + options.cutShortcut;
            CopyShortcut.Content = "Copy Shortcut: " + options.copyShortcut;
            PasteShortcut.Content = "Paste Shortcut: " + options.pasteShortcut;
            DuplicateShortcut.Content = "Duplicate Shortcut: " + options.duplicateShortcut;
            UndoShortcut.Content = "Undo Shortcut: " + options.undoShortcut;
            RedoShortcut.Content = "Redo Shortcut: " + options.redoShortcut;
        }

        #endregion

        #region Input Events

        #region Key Press Event

        /// <summary>
        /// Event handler for key presses
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments of key press</param>
        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            // Do nothing if not shortcut currently selected
            if (selectedShortcut == 0)
            {
                return;
            }

            // Find selected shortcut
            if (selectedShortcut == 1)
            {
                options.cutShortcut = e.Key.ToString().ToLower();
                CutShortcut.Content = "Cut Shortcut: " + options.cutShortcut;
                RemoveShortcutFromOther(1, e.Key.ToString().ToLower());
            }
            else if (selectedShortcut == 2)
            {
                options.copyShortcut = e.Key.ToString().ToLower();
                CopyShortcut.Content = "Copy Shortcut: " + options.copyShortcut;
            }
            else if (selectedShortcut == 3)
            {
                options.pasteShortcut = e.Key.ToString().ToLower();
                PasteShortcut.Content = "Paste Shortcut: " + options.pasteShortcut;
            }
            else if (selectedShortcut == 4)
            {
                options.duplicateShortcut = e.Key.ToString().ToLower();
                DuplicateShortcut.Content = "Duplicate Shortcut: " + options.duplicateShortcut;
            }
            else if (selectedShortcut == 5)
            {
                options.undoShortcut = e.Key.ToString().ToLower();
                UndoShortcut.Content = "Undo Shortcut: " + options.undoShortcut;
            }
            else if (selectedShortcut == 6)
            {
                options.redoShortcut = e.Key.ToString().ToLower();
                RedoShortcut.Content = "Redo Shortcut: " + options.redoShortcut;
            }
        }

        #endregion

        #region Save Changes Event

        /// <summary>
        /// Save all of options values to file
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            FileStream fileStream;
            StreamWriter optionsFile;
            Random random = new Random();
            try
            {
                fileStream = File.Open("options.txt", FileMode.Create);
                optionsFile = new StreamWriter(fileStream);
                optionsFile.WriteLine(options.volume);
                optionsFile.WriteLine(options.cutShortcut);
                optionsFile.WriteLine(options.copyShortcut);
                optionsFile.WriteLine(options.pasteShortcut);
                optionsFile.WriteLine(options.duplicateShortcut);
                optionsFile.WriteLine(options.undoShortcut);
                optionsFile.WriteLine(options.redoShortcut);
                optionsFile.Close();
            }
            catch (IOException error)
            {
                Console.WriteLine("File could not be opened: " + error);
            }
        }

        #endregion

        #region Volume Event

        /// <summary>
        /// Event when slider value has changed
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        public void Volume_ValueChanged(object sender, RoutedEventArgs e)
        {
            // Update volume accordingly
            options.volume = Convert.ToInt32(VolumeSlider.Value);
        }

        #endregion

        #region Shortcut Events

        /// <summary>
        /// Event when cut shortcut button clicked
        /// </summary>
        private void CutShortcut_Click(object sender, RoutedEventArgs e)
        {
            CutShortcut_Run();
        }

        /// <summary>
        /// Event when copy shortcut button clicked
        /// </summary>
        private void CopyShortcut_Click(object sender, RoutedEventArgs e)
        {
            CopyShortcut_Run();
        }

        /// <summary>
        /// Event when paste shortcut button clicked
        /// </summary>
        private void PasteShortcut_Click(object sender, RoutedEventArgs e)
        {
            PasteShortcut_Run();
        }

        /// <summary>
        /// Event when duplicate shortcut button clicked
        /// </summary>
        private void DuplicateShortcut_Click(object sender, RoutedEventArgs e)
        {
            DuplicateShortcut_Run();
        }

        /// <summary>
        /// Event when undo shortcut button clicked
        /// </summary>
        private void UndoShortcut_Click(object sender, RoutedEventArgs e)
        {
            UndoShortcut_Run();
        }

        /// <summary>
        /// Event when redo shortcut button clicked
        /// </summary>
        private void RedoShortcut_Click(object sender, RoutedEventArgs e)
        {
            RedoShortcut_Run();
        }

        /// <summary>
        /// Cut shortcut button main method
        /// </summary>
        private void CutShortcut_Run()
        {
            selectedShortcut = 0;
            FlushShortcuts();
            CutShortcut.Content = "Cut Shortcut: [input key]";
            selectedShortcut = 1;
        }

        /// <summary>
        /// Copy shortcut button main method
        /// </summary>
        private void CopyShortcut_Run()
        {
            selectedShortcut = 0;
            FlushShortcuts();
            CopyShortcut.Content = "Copy Shortcut: [input key]";
            selectedShortcut = 2;
        }

        /// <summary>
        /// Paste shortcut button main method
        /// </summary>
        private void PasteShortcut_Run()
        {
            selectedShortcut = 0;
            FlushShortcuts();
            PasteShortcut.Content = "Paste Shortcut: [input key]";
            selectedShortcut = 3;
        }

        /// <summary>
        /// Duplicate shortcut button main method
        /// </summary>
        private void DuplicateShortcut_Run()
        {
            selectedShortcut = 0;
            FlushShortcuts();
            DuplicateShortcut.Content = "Duplicate Shortcut: [input key]";
            selectedShortcut = 4;
        }

        /// <summary>
        /// Undo shortcut button main method
        /// </summary>
        private void UndoShortcut_Run()
        {
            selectedShortcut = 0;
            FlushShortcuts();
            UndoShortcut.Content = "Undo Shortcut: [input key]";
            selectedShortcut = 5;
        }

        /// <summary>
        /// Redo shortcut button main method
        /// </summary>
        private void RedoShortcut_Run()
        {
            selectedShortcut = 0;
            FlushShortcuts();
            RedoShortcut.Content = "Redo Shortcut: [input key]";
            selectedShortcut = 6;
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

        #endregion

        #region Private Helpers

        /// <summary>
        /// Stop all shortcut buttons from wanting input
        /// </summary>
        private void FlushShortcuts()
        {
            CutShortcut.Content = "Cut Shortcut: " + options.cutShortcut;
            CopyShortcut.Content = "Copy Shortcut: " + options.copyShortcut;
            PasteShortcut.Content = "Paste Shortcut: " + options.pasteShortcut;
            DuplicateShortcut.Content = "Duplicate Shortcut: " + options.duplicateShortcut;
            UndoShortcut.Content = "Undo Shortcut: " + options.undoShortcut;
            RedoShortcut.Content = "Redo Shortcut: " + options.redoShortcut;
        }

        /// <summary>
        /// Remove key from a different shortcut if there is a collision and allow input for new shortcut
        /// </summary>
        /// <param name="shortcut">Number corresponding to specific shortcut</param>
        /// <param name="key">The key to remove from other shortcut</param>
        private void RemoveShortcutFromOther(int shortcut, string key)
        {
            for (int i = 1; i < 7; i++)
            {
                // Does not affect desired shortcut
                if (i == shortcut)
                {
                    continue;
                }

                if (i == 1 && options.cutShortcut == key)
                {
                    CutShortcut_Run();
                    break;
                }
                else if (i == 2 && options.copyShortcut == key)
                {
                    CopyShortcut_Run();
                    break;
                }
                else if (i == 3 && options.pasteShortcut == key)
                {
                    PasteShortcut_Run();
                    break;
                }
                else if (i == 4 && options.duplicateShortcut == key)
                {
                    DuplicateShortcut_Run();
                    break;
                }
                else if (i == 5 && options.undoShortcut == key)
                {
                    UndoShortcut_Run();
                    break;
                }
                else if (i == 6 && options.pasteShortcut == key)
                {
                    RedoShortcut_Run();
                    break;
                }
            }
        }

        #endregion
    }
}
