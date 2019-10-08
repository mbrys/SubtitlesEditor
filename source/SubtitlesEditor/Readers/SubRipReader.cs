using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using SubtitlesEditor.LineInfos;
using SubtitlesEditor.Navigators;

namespace SubtitlesEditor.Readers
{
    public class SubRipReader : ISubtitlesReader
    {
        private ISubtitlesNavigator navigator;
        public SubRipReader(ISubtitlesNavigator navi)
        {
            navigator = navi;
        }
        public ISubtitlesNavigator Navigator
        {
            get { return navigator; }
            set { navigator = value; }
        }
        /// <summary>
        /// Loads file and form collection of ILineInfo from file lines.
        /// </summary>
        /// <param fileName="filePath">File's fullPath</param>
        /// <returns>Collection of ILineInfos</returns>
        public List<ILineInfo> LoadSubsListFromFile(string filePath, Encoding encoding)
        {
            string[] fileLines;
            try
            {
                fileLines = File.ReadAllLines(filePath, encoding);
            }
            catch (IOException)
            {
                fileLines = new string[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return FormLinesList(fileLines);
        }

        private List<ILineInfo> FormLinesList(string[] fileLines)
        {
            var lines = new List<ILineInfo>(fileLines.Length / 4);
            if (fileLines != null)
            {
                for (int i = 0; i < fileLines.Length; )
                {
                    ILineInfo linfo = new SubRipLineInfo();
                    while (i < fileLines.Length && fileLines[i] == "")
                    {
                        i++;
                    }
                    if (i == fileLines.Length)
                        break;

                    var currentLine = fileLines[i++].Trim();
                    if (String.IsNullOrEmpty(currentLine))
                        continue;

                    linfo.LineNumber = Int32.Parse(currentLine);
                    AssignTimeProperies(fileLines[i++], ref linfo);
                    linfo.Line = fileLines[i++];
                    while (i < fileLines.Length && fileLines[i] != "")
                    {
                        linfo.Line += "\r\n" + fileLines[i];
                        i++;
                    }
                    lines.Add(linfo);
                }
            }
            return lines;
        }

        /// <summary>
        /// Extracts begin and end time values from text and assign them to properties of ILineInfo item
        /// </summary>
        /// <param fileName="text">Text to extract values from</param>
        /// <param fileName="linfo">Item to which properties values are assigned</param>
        public void AssignTimeProperies(string time, ref ILineInfo linfo)
        {
            linfo.Begin = time.Substring(0, time.IndexOf("-->")).Trim();
            linfo.End = time.Substring(time.IndexOf("-->") + 3).Trim();
        }
        /// <summary>
        /// Put changed ILineInfo item into list at proper index, and save temporary file
        /// </summary>
        /// <param fileName="li">ILineInfo to update</param>
        public void UpdateLineList(ILineInfo li)
        {
            if (li == null)
                throw new ArgumentNullException("List item cannot be null.");
            int index = navigator.Lines.FindIndex(v => v.LineNumber == li.LineNumber);
            navigator.Lines[index] = li;
            SaveFile("temp.srt");
        }

        /// <summary>
        /// Saves ISubtitlesNavigator's collection to file
        /// </summary>
        /// <param fileName="filePath"></param>
        public void SaveFile(string filePath)
        {
            if (navigator.Lines != null)
            {
                using (StreamWriter sw = new StreamWriter(filePath, false, Encoding.Default))
                {
                    foreach (SubRipLineInfo line in navigator.Lines)
                    {
                        sw.WriteLine(line.LineNumber.ToString());
                        sw.WriteLine(line.TimeInfo);
                        sw.WriteLine(line.Line);
                        sw.WriteLine();
                    }
                }
            }
        }
        /// <summary>
        /// Saves only ISubtitlesNavigator's collection's timestamps to file
        /// </summary>
        /// <param fileName="filePath"></param>
        public void SaveTranslationFile(string filePath)
        {
            if (navigator.Lines != null)
            {
                using (StreamWriter sw = new StreamWriter(filePath, false, Encoding.Default))
                {
                    foreach (SubRipLineInfo line in navigator.Lines)
                    {
                        sw.WriteLine(line.LineNumber.ToString());
                        sw.WriteLine(line.TimeInfo);
                        sw.WriteLine("");
                        sw.WriteLine();
                    }
                }
            }
        }
        /// <summary>
        /// Compares file with temporary file linfo by linfo.
        /// </summary>
        /// <param fileName="filePath">Path of file to compare</param>
        /// <returns>If files differ, returns true. Otherwise returns false</returns>
        public bool IsChanged(string filePath)
        {
            try
            {
                using (StreamReader org = new StreamReader(filePath, Encoding.Default))
                {
                    using (StreamReader temp = new StreamReader("temp.srt", Encoding.Default))
                    {
                        while (org.Peek() != -1 && temp.Peek() != -1)
                        {
                            var originalLine = org.ReadLine();
                            var currentLine = temp.ReadLine();
                            if (!originalLine.Equals(currentLine, StringComparison.InvariantCulture))
                                return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return false;
        }
    }
}
