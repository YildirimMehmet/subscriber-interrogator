using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace SubscriberInterrogator.Business.Helpers
{
    /// <summary>
    /// File chooser
    /// </summary>
    public class FileChooser
    {
        /// <summary>
        /// Default const
        /// </summary>
        public FileChooser()
        {

        }
    
        /// <summary>
        /// Save file
        /// </summary>
        /// <param name="fileName"></param>
        public void SaveFile(string fileName)
        {
            string targetPath = @"Datas";
            Directory.CreateDirectory(targetPath);
            File.Copy(fileName, Path.Combine(targetPath,$"{DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss")}.txt"));
        }

        /// <summary>
        /// Choose file
        /// </summary>
        /// <returns></returns>
        public string ChooseFile()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();        
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "Text files (*.txt)|*.txt";
            openFileDialog1.FilterIndex = 0;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                SaveFile(openFileDialog1.FileName);
                return openFileDialog1.FileName;              
            }
            return string.Empty;
        }
    }
}
