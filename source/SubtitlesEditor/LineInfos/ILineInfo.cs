using System;
namespace SubtitlesEditor.LineInfos
{
    public interface ILineInfo
    {
        string Begin { get; set; }
        string End { get; set; }
        bool Equals(object o);
        int GetHashCode();
        string Line { get; set; }
        int LineNumber { get; set; }
        string TimeInfo { get; }
        string SecondsToTime(double seconds);
        double TimeToSeconds(string time);
        string MoveTime(string oldTime, double secs);
    }
}
