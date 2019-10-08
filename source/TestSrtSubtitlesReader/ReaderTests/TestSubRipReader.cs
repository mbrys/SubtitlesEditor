using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using SubtitlesEditor;
using Moq;
using System.Reflection;
using System.IO;
using SubtitlesEditor.Readers;
using SubtitlesEditor.LineInfos;
using SubtitlesEditor.Navigators;

namespace TestSubtitlesEditor
{
    [TestFixture]
    public class TestSubRipReader
    {
        private string testFilePath = Path.Combine(Path.GetTempPath(), "test.srt");
        private SubRipReader srtReader;
        private List<SubtitlesEditor.LineInfos.ILineInfo> lines;
        [SetUp]
        public void Setup()
        {
            lines = new List<SubtitlesEditor.LineInfos.ILineInfo>{
                new SubRipLineInfo{LineNumber=1,Line="Pierwsza linia",Begin="beginTime", End="endTime"},
                new SubRipLineInfo{LineNumber=2,Line="Druga linia",Begin="beginTime", End="endTime"},
                new SubRipLineInfo{LineNumber=3,Line="Trzecia linia",Begin="beginTime", End="endTime"}
            };
            Assembly a = Assembly.GetExecutingAssembly();
            using (Stream s = a.GetManifestResourceStream("TestSubtitlesEditor.test.srt"))
            {
                using (StreamReader sr = new StreamReader(s))
                {
                    using (StreamWriter sw = File.CreateText(testFilePath))
                    {
                        sw.Write(sr.ReadToEnd());
                        sw.Flush();
                    }
                }
            }
            var moqNavi = new Mock<ISubtitlesNavigator>();
            moqNavi.Setup(x => x.GetFileLine(2)).Returns(new SubRipLineInfo { LineNumber = 2, Line = "Druga linia", Begin = "beginTime", End = "endTime" });
            moqNavi.Setup(x => x.LastLineIndex).Returns(3);
            moqNavi.Setup(x => x.Lines).Returns(lines);
            this.srtReader = new SubRipReader(moqNavi.Object);
        }
        [TearDown]
        public void TearDown()
        {
            if (File.Exists(testFilePath))
            {
                File.Delete(testFilePath);
            }
        }
        //public void ActualizeLineList(SubRipLineInfo li);
        //void SaveFile(string filePath);
        //bool IsChanged(string filePath);
        [Test]
        public void LoadSubsFromFile_ProperSrtFile_ReturnsLineInfoList()
        {
            var actual = srtReader.LoadSubsListFromFile(testFilePath, Encoding.Default);
            CollectionAssert.AreEqual(lines, actual, "Niepoprawnie wczytana lista z poprawnego pliku .srt");
        }
        [Test]
        public void LoadSubsFromFile_FileNotExist_ReturnEmptyCollection()
        {
            var actual = srtReader.LoadSubsListFromFile(testFilePath + "xy", Encoding.Default);
            Assert.IsEmpty(actual, "Nie zwrócono pustej listy z nieistniejącego pliku");
        }
        [Test]
        public void AssignTimeProperies_Begin0End1second_SetCorrectValues()
        {
            var expectedBeginTime = "00:00:00,000";
            var expectedEndTime = "00:00:01,000";
            var lineInfo = lines[0];
            srtReader.AssignTimeProperies("00:00:00,000 --> 00:00:01,000", ref lineInfo);

            var actualBeginTime = lineInfo.Begin;
            var actualEndTime = lineInfo.End;

            Assert.AreEqual(expectedBeginTime, actualBeginTime, "Czas pokazania niezgodny");
            Assert.AreEqual(expectedEndTime, actualEndTime, "Czas znikniecia niezgodny");
        }
    }
}
