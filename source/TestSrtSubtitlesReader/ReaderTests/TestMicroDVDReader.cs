using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Moq;
using NUnit.Framework;
using SubtitlesEditor.LineInfos;
using SubtitlesEditor.Navigators;
using SubtitlesEditor.Readers;
using System.Text;

namespace TestSubtitlesEditor
{
    [TestFixture]
    public class TestMicroDVDReader
    {
        private string testFilePath = Path.Combine(Path.GetTempPath(), "test.sub");
        private string issuedTestFilePath = Path.Combine(Path.GetTempPath(), "testIssued.sub");
        private string issuedTestFilePathWithTags = Path.Combine(Path.GetTempPath(), "testIssuedWithTags.sub");
        private MicroDVDReader mDVDReader;
        private List<ILineInfo> lines;
        [SetUp]
        public void Setup()
        {
            lines = new List<SubtitlesEditor.LineInfos.ILineInfo>{
                new MicroDVDLineInfo{LineNumber=1,Line="Pierwsza linia",Begin="1", End="50"},
                new MicroDVDLineInfo{LineNumber=2,Line="Druga linia",Begin="100", End="200"},
                new MicroDVDLineInfo{LineNumber=3,Line="Trzecia linia",Begin="200", End="500"}
            };
            Assembly a = Assembly.GetExecutingAssembly();
            using (Stream s = a.GetManifestResourceStream("TestSubtitlesEditor.test.sub"))
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
            using (Stream s = a.GetManifestResourceStream("TestSubtitlesEditor.testIssued.sub"))
            {
                using (StreamReader sr = new StreamReader(s))
                {
                    using (StreamWriter sw = File.CreateText(issuedTestFilePath))
                    {
                        sw.Write(sr.ReadToEnd());
                        sw.Flush();
                    }
                }
            }
            using (Stream s = a.GetManifestResourceStream("TestSubtitlesEditor.testIssuedWithTags.sub"))
            {
                using (StreamReader sr = new StreamReader(s))
                {
                    using (StreamWriter sw = File.CreateText(issuedTestFilePathWithTags))
                    {
                        sw.Write(sr.ReadToEnd());
                        sw.Flush();
                    }
                }
            }
            var moqNavi = new Mock<ISubtitlesNavigator>();
            moqNavi.Setup(x => x.GetFileLine(2)).Returns(lines[1]);
            moqNavi.Setup(x => x.LastLineIndex).Returns(3);
            moqNavi.Setup(x => x.Lines).Returns(lines);
            this.mDVDReader = new MicroDVDReader(moqNavi.Object);
        }
        [TearDown]
        public void TearDown()
        {
            if (File.Exists(testFilePath))
            {
                File.Delete(testFilePath);
            }
            if (File.Exists(issuedTestFilePath))
            {
                File.Delete(issuedTestFilePath);
            }
        }
        [Test]
        public void LoadFps_FpsInFirstLineOfFile_ReturnsCorrectFps()
        {
            var expected = 25.123;
            var actual = mDVDReader.LoadFps("{1}{1} 25.123");
            Assert.AreEqual(expected, actual, "Nie pobrano prawidłowego fps");
        }
        [Test]
        public void LoadFps_FpsInLineWithOtherParameters_ReturnsCorrectFps()
        {
            var expected = 25.5;
            var actual = mDVDReader.LoadFps("{1}{64} cośtam cośtam 25.5fps bla bla");
            Assert.AreEqual(expected, actual, "Nie pobrano prawidłowego fps");
        }
        [Test]
        public void LoadFps_NoFpsInLine_ReturnsSafeValue()
        {
            var expected = -1.0;
            var actual = mDVDReader.LoadFps("{1}{64} cośtam cośtam fps bla bla");
            Assert.AreEqual(expected, actual, "Nie pobrano prawidłowego fps");
        }
        [Test]
        public void LoadSubsFromFile_ProperMDVDFile_ReturnsLineInfoList()
        {
            var actual = mDVDReader.LoadSubsListFromFile(testFilePath, Encoding.Default);
            CollectionAssert.AreEqual(lines, actual, "Niepoprawnie wczytana lista z poprawnego pliku .txt(mDVD)");
        }
        [Test]
        public void LoadSubsFromFile_NotProperMDVDFile_ReturnsLineInfoList()
        {
            var actual = mDVDReader.LoadSubsListFromFile(issuedTestFilePath, Encoding.Default);
            CollectionAssert.AreEqual(lines, actual, "Niepoprawnie wczytana lista z niepoprawnego pliku .txt(mDVD)");
        }
        [Test]
        public void LoadSubsFromFile_MDVDFileWithTags_ReturnsLineInfoList()
        {
            var text = "Druga{color:#1234} linia";
            var li = new MicroDVDLineInfo { LineNumber = 2, Line = text, Begin = "100", End = "200" };
            lines[1] = li;
            var actual = mDVDReader.LoadSubsListFromFile(issuedTestFilePathWithTags, Encoding.Default);
            CollectionAssert.AreEqual(lines, actual, "Niepoprawnie wczytana lista z niepoprawnego pliku .txt(mDVD)");
        }
        [Test]
        public void LoadSubsFromFile_FileNotExist_ReturnEmptyCollection()
        {
            var actual = mDVDReader.LoadSubsListFromFile(testFilePath + "xy", Encoding.Default);
            Assert.IsEmpty(actual, "Nie zwrócono pustej listy z nieistniejącego pliku");
        }
        [Test]
        public void AssignTimeProperies_FramesWithWhitespaceInBetween_SetCorrectValues()
        {
            var expectedBeginTime = "100";
            var expectedEndTime = "200";
            var lineInfo = lines[0];


            mDVDReader.AssignTimeProperies("{100} {200} ", ref lineInfo);
            var actualBeginTime = lineInfo.Begin;
            var actualEndTime = lineInfo.End;

            Assert.AreEqual(expectedBeginTime, actualBeginTime, "Czas wyświetlenia linii niezgodny");
            Assert.AreEqual(expectedEndTime, actualEndTime, "Czas znikniecia linii niezgodny");
        }
        [Test]
        public void AssignTimeProperies_FramesWithWhitespaceInBetween_ReturnsCorrectIndex()
        {
            var expectedIndex = 10;
            var lineInfo = lines[0];

            var actualIndex = mDVDReader.GetIndexOfLastTimecodeChar("{100} {200} ");

            Assert.AreEqual(expectedIndex, actualIndex, "Niepoprawny index ostatniego znaku znacznika czasu");
        }
        [Test]
        public void AssignTimeProperies_CorrectFrames_ReturnsCorrectIndex()
        {
            var expectedIndex = 9;
            var lineInfo = lines[0];

            var actualIndex = mDVDReader.GetIndexOfLastTimecodeChar("{100}{200}");

            Assert.AreEqual(expectedIndex, actualIndex, "Niepoprawny index ostatniego znaku znacznika czasu");
        }
        [Test]
        public void IsChanged_SameFile_ReturnsFalse()
        {
            var filePath = testFilePath;
            var filePath2 = testFilePath;

            var actual = mDVDReader.IsChanged(filePath, filePath2);

            Assert.IsFalse(actual);
        }
        [Test]
        public void IsChanged_DifferentFiles_ReturnsTrue()
        {
            var filePath = testFilePath;
            var filePath2 = issuedTestFilePath;

            var actual = mDVDReader.IsChanged(filePath, filePath2);

            Assert.IsTrue(actual);
        }
    }
}
