using System.Collections.Generic;
using SubtitlesEditor.Navigators;

namespace SubtitlesEditor.Readers
{
    public interface ISubtitlesReader
    {
        ISubtitlesNavigator Navigator { get; set; }
        void UpdateLineList(LineInfos.ILineInfo li);
        List<LineInfos.ILineInfo> LoadSubsListFromFile(string filePath, System.Text.Encoding encoding);
        void SaveFile(string filePath);
        void SaveTranslationFile(string filePath);
        bool IsChanged(string filePath);
    }
}
