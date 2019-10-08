using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SubtitlesEditor.Navigators;
using SubtitlesEditor.LineInfos;

namespace SubtitlesEditor.Navigators
{
    public class DefaultNavigator : ISubtitlesNavigator
    {
        public DefaultNavigator()
        { }
        public ILineInfo GetFileLine(int lineNumber)
        {
            int ind = lines.FindIndex(v => v.LineNumber == lineNumber);
            return GetLine(ind);
        }
        //public ILineInfo GetFileNextLine(int lineNumber)
        //{
        //    int ind = lines.FindIndex(v => v.LineNumber == (lineNumber + 1));
        //    return GetLine(ind);
        //}
        //public ILineInfo GetFilePrevLine(int lineNumber)
        //{
        //    int ind = lines.FindIndex(v => v.LineNumber == (lineNumber - 1));
        //    return GetLine(ind);
        //}
        private ILineInfo GetLine(int index)
        {
            if (index == -1)
                throw new ArgumentOutOfRangeException("index","Requested item don't exist in collection");
            return lines[index];

        }
        private List<ILineInfo> lines;

        public List<ILineInfo> Lines
        {
            get { return lines; }
            set { lines = value; }
        }


        public int LastLineIndex
        {
            get { return lines.Count - 1; }
        }
    }
}
