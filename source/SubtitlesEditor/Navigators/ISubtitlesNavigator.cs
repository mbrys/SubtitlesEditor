using System;
namespace SubtitlesEditor.Navigators
{
    public interface ISubtitlesNavigator
    {
        LineInfos.ILineInfo GetFileLine(int lineNumber);
        System.Collections.Generic.List<LineInfos.ILineInfo> Lines { get; set; }
        int LastLineIndex { get; }
    }
}
