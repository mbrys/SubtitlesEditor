using System;

namespace SubtitlesEditor.LineInfos
{
    public class SubRipLineInfo : ILineInfo
    {
        private string line;
        private string begin;
        private string end;
        private int lineNumber;

        public string Line
        { get { return line; } set { line = value; } }
        public string Begin
        { get { return begin; } set { begin = value; } }
        public string End
        { get { return end; } set { end = value; } }
        public int LineNumber
        { get { return lineNumber; } set { lineNumber = value; } }

        public override string ToString()
        {
            return lineNumber + ": " + line;
        }
        public override bool Equals(object o)
        {
            var other = o as SubRipLineInfo;
            if (other == null) { return false; }
            return this.line == other.line
              && this.lineNumber == other.lineNumber
              && this.begin == other.begin;
        }

        public override int GetHashCode() { return 1; }


        public string TimeInfo
        {
            get { return begin + " --> " + end; }
        }

        public string SecondsToTime(double seconds)
        {
            double miliseconds = (seconds - Math.Floor(seconds)) * 1000;
            seconds = Math.Floor(seconds);
            int hours = 0;
            while (seconds - 3600 >= 0)
            {
                hours++;
                seconds -= 3600;
            }
            int minutes = 0;
            while (seconds - 60 >= 0)
            {
                minutes++;
                seconds -= 60;
            }
            return String.Format("{0:00}:{1:00}:{2:00},{3:000}", hours, minutes, seconds, miliseconds);
        }


        public double TimeToSeconds(string time)
        {
            if (String.IsNullOrEmpty(time))
                throw new ArgumentException($"Value of parameter cannot be null or empty", time);

            time.Replace(',', '.');
            string[] times = time.Split(':');
            if (times.Length != 3)
                return 0;

            double seconds = 0.0;
            seconds += Double.Parse(times[0]) * 3600;
            seconds += Double.Parse(times[1]) * 60;
            seconds += Double.Parse(times[2]);
            return seconds;
        }

        public string MoveTime(string oldTime, double secs)
        {
            double newBegin = TimeToSeconds(oldTime) + secs;
            if (newBegin < 0)
                throw new ArgumentException("Too much time to subtract");
            return SecondsToTime(newBegin);
        }

    }
}
