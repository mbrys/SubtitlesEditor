﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using SubtitlesEditor.LineInfos;
using SubtitlesEditor.Navigators;

namespace SubtitlesEditor.Readers
{
    public class Mpl2Reader : ISubtitlesReader
    {
        private ISubtitlesNavigator navigator;
        private string tempFilePath = "tempMpl2.txt";
        public Mpl2Reader(ISubtitlesNavigator navi)
        {
            navigator = navi;
        }
        public ISubtitlesNavigator Navigator
        {
            get { return navigator; }
            set { navigator = value; }
        }
        /// <summary>
        /// Puts changed ILineInfo item into list at proper index, and save temporary file
        /// </summary>
        /// <param fileName="li">ILineInfo to update</param>
        public void UpdateLineList(ILineInfo li)
        {
            if (li == null)
                throw new ArgumentNullException("List item cannot be null.");
            int index = navigator.Lines.FindIndex(v => v.LineNumber == li.LineNumber);
            navigator.Lines[index] = li;
            SaveFile(tempFilePath);
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
            int lineCounter = 1;
            var lines = new List<ILineInfo>(fileLines.Length);
            if (fileLines != null)
            {
                for (int i = 0; i < fileLines.Length; )
                {
                    ILineInfo linfo = new Mpl2LineInfo();
                    while (i < fileLines.Length && (fileLines[i] == "" || fileLines[i] == Environment.NewLine))
                    {
                        i++;
                    }
                    if (i == fileLines.Length)
                        break;
                    if (fileLines[i].Length != 0)
                    {
                        linfo.LineNumber = lineCounter++;
                        AssignTimeProperies(fileLines[i], ref linfo);
                        int index = GetIndexOfLastTimecodeChar(fileLines[i]);
                        linfo.Line = fileLines[i++].Trim().Substring(index + 1).Trim();
                        lines.Add(linfo);
                    }
                }
            }
            return lines;
        }
        /// <summary>
        /// Extracts begin and end time values from text and assign them to properties of ILineInfo item
        /// </summary>
        /// <param fileName="text">Text to extract values from</param>
        /// <param fileName="linfo">Item to which properties values are assigned</param>
        public void AssignTimeProperies(string text, ref ILineInfo linfo)
        {
            linfo.Begin = text.Substring(1, text.IndexOf(']') - 1).Trim();
            int i;
            for (i = 1; i < text.Length; i++)
                if (text[i] == '[')
                    break;
            int start = i + 1;
            for (; i < text.Length; i++)
                if (text[i] == ']')
                    break;
            int end = i;
            linfo.End = text.Substring(start, end - start).Trim();
        }
        /// <summary>
        /// Find index of last character used to describe timecode in text
        /// </summary>
        /// <param fileName="text">Text to extract values from</param>
        /// <returns>LineNumber of last char in timecode</returns>
        public int GetIndexOfLastTimecodeChar(string text)
        {

            int i = -1;
            if (text.Length > 0)
            {
                for (i = 1; i < text.Length; i++)
                    if (text[i] == '[')
                        break;
                int start = i + 1;
                for (; i < text.Length; i++)
                    if (text[i] == ']')
                        break;
            }
            return i;
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
                    foreach (Mpl2LineInfo line in navigator.Lines)
                    {
                        sw.Write("[" + line.Begin + "]");
                        sw.Write("[" + line.End + "]");
                        sw.Write(line.Line + sw.NewLine);
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
                    foreach (Mpl2LineInfo line in navigator.Lines)
                    {
                        sw.Write("[" + line.Begin + "]");
                        sw.Write("[" + line.End + "]" + sw.NewLine);
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
            return IsChanged(filePath, tempFilePath);
        }
        /// <summary>
        /// Compare two files linfo by linfo.
        /// </summary>
        /// <param fileName="filePath">Path of first file to compare</param>
        /// <param fileName="tempFilePath">Path of second file to compare</param>
        /// <returns>If files differ, returns true. Otherwise returns false</returns>
        public bool IsChanged(string filePath, string tempFilePath)
        {
            string variable;
            string variable2;
            try
            {
                using (StreamReader org = new StreamReader(filePath, Encoding.Default))
                {
                    using (StreamReader temp = new StreamReader(tempFilePath, Encoding.Default))
                    {
                        while (org.Peek() != -1 && temp.Peek() != -1)
                        {
                            variable = org.ReadLine();
                            variable2 = temp.ReadLine();
                            if (!(variable.Equals(variable2, StringComparison.CurrentCulture)))
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
