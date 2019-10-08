using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SubtitlesEditor.LineInfos;

namespace SubtitlesEditor.LineInfos
{
    public class MicroDVDLineInfo : ILineInfo
    {
        private static double framesPerSecond;
        private string line;
        private string begin;
        private int lineNumber;
        private string end;

        public static double FramePerSecond
        {
            get { return MicroDVDLineInfo.framesPerSecond; }
            set { MicroDVDLineInfo.framesPerSecond = value; }
        }
        public string Line
        {
            get { return line; }
            set { line = value; }
        }
        public string Begin
        {
            get { return begin; }
            set { begin = value; }
        }
        public string End
        {
            get { return end; }
            set { end = value; }
        }
        public int LineNumber
        {
            get { return lineNumber; }
            set { lineNumber = value; }
        }

        public override string ToString()
        {
            return lineNumber + ": " + line;
        }
        //public override string ToString()
        //{
        //    return lineNumber + " || {" + begin + "}{" + end + "} || " + linfo;
        //}
        public override bool Equals(object o)
        {
            var other = o as MicroDVDLineInfo;
            if (other == null) { return false; }
            return this.line == other.line
              && this.lineNumber == other.lineNumber
              && this.end == other.end
              && this.begin == other.begin;
        }

        public override int GetHashCode() { return 1; }


        public string TimeInfo
        {
            get { return "{" + begin + "}{" + end + "}"; }
        }


        public string SecondsToTime(double seconds)
        {
            return Math.Round(seconds * framesPerSecond).ToString();
        }


        public double TimeToSeconds(string time)
        {
            time = time.Trim(new char[] { '{', '}' });
            return Double.Parse(time) / framesPerSecond;
        }


        public string MoveTime(string oldTime, double secs)
        {
            var newTime = TimeToSeconds(oldTime) + secs;
            if (newTime < 0)
                throw new ArgumentException("Too much time to subtract");
            return SecondsToTime(newTime);
        }
    }
}
