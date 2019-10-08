using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SubtitlesEditor.Forms;
using SubtitlesEditor.Navigators;
using SubtitlesEditor.Readers;

namespace SubtitlesEditor
{
    public class FileHelper
    {
        ISubtitlesNavigator navigator;
        ISubtitlesReader reader;
        public FileHelper(ISubtitlesReader reader)
        {
            this.navigator = reader.Navigator;
            this.reader = reader;
            if (navigator.Lines == null)
                navigator.Lines = new List<LineInfos.ILineInfo>();
        }
        public void LoadLines(string fullPath, Encoding enc)
        {
            navigator.Lines = reader.LoadSubsListFromFile(fullPath, enc);
        }

        public LineInfos.ILineInfo GetLine(int number)
        {
            return navigator.GetFileLine(number);
        }
        public int LastLineIndex
        {
            get { return navigator.LastLineIndex; }
        }
        public ISubtitlesReader Reader
        {
            get { return reader; }
        }
        public List<LineInfos.ILineInfo> Lines
        {
            get { return navigator.Lines; }
        }

        public void UpdateLineList(LineInfos.ILineInfo li)
        {
            reader.UpdateLineList(li);
        }

        public void SaveFile(string path)
        {
            reader.SaveFile(path);
        }
        public bool IsChanged(string filePath)
        {
            return reader.IsChanged(filePath);
        }

        internal void SaveTranslationFile(string trPath)
        {
            reader.SaveTranslationFile(trPath);
        }
    }
}
