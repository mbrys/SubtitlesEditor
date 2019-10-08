using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SubtitlesEditor.Navigators;

namespace SubtitlesEditor.Navigators
{
    public class Mpl2Navigator : ISubtitlesNavigator
    {
        public LineInfos.ILineInfo GetFileLine(int lineNumber)
        {
            throw new NotImplementedException();
        }

        public LineInfos.ILineInfo GetFileNextLine(int lineNumber)
        {
            throw new NotImplementedException();
        }

        public LineInfos.ILineInfo GetFilePrevLine(int lineNumber)
        {
            throw new NotImplementedException();
        }

        public List<LineInfos.ILineInfo> Lines
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int LastLineIndex
        {
            get { throw new NotImplementedException(); }
        }
    }
}
