using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Song_Mind.DataModels
{
    public class Options
    {
        #region Public Members

        public int volume;
        public string cutShortcut;
        public string copyShortcut;
        public string pasteShortcut;
        public string duplicateShortcut;
        public string undoShortcut;
        public string redoShortcut;

        #endregion

        #region Constructor

        public Options()
        {
            LoadOptions();
        }

        #endregion

        #region Load Options

        /// <summary>
        /// Load Options from options.txt
        /// </summary>
        public void LoadOptions()
        {
            // Open file to "optionsFile"
            StreamReader optionsFile = new StreamReader("options.txt");

            // Test if file is empty
            string firstLine = optionsFile.ReadLine();
            if (firstLine == null)
            {
                // Assign default values if empty
                volume = 5;
                cutShortcut = "x";
                copyShortcut = "c";
                pasteShortcut = "v";
                duplicateShortcut = "d";
                undoShortcut = "z";
                redoShortcut = "y";
                return;
            }

            // Assign saved values
            volume = Int32.Parse(firstLine);
            cutShortcut = optionsFile.ReadLine();
            copyShortcut = optionsFile.ReadLine();
            pasteShortcut = optionsFile.ReadLine();
            duplicateShortcut = optionsFile.ReadLine();
            undoShortcut = optionsFile.ReadLine();
            redoShortcut = optionsFile.ReadLine();

            // Close file
            optionsFile.Close();
        }

        #endregion
    }
}
