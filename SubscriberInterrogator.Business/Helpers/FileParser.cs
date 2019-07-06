using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace SubscriberInterrogator.Business.Helpers
{
    /// <summary>
    /// File process
    /// </summary>
    public class FileParser
    {
        /// <summary>
        /// Parse file
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static List<string> ParseFile(string filePath)
        {
            List<string> fileLines = new List<string>();
            StreamReader reader = File.OpenText(filePath);
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                fileLines.Add(line);
            }
            return fileLines;
        }


    }
}
