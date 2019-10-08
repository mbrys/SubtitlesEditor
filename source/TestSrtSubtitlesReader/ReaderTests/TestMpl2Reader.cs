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
    public class TestMpl2Reader
    {
        private string testFilePath = Path.Combine(Path.GetTempPath(), "testMpl2.txt");
        private string issuedTestFilePath = Path.Combine(Path.GetTempPath(), "testMpl2issued.txt");
        private Mpl2Reader mpl2Reader;
        private List<SubtitlesEditor.LineInfos.ILineInfo> lines;
        [SetUp]
        public void Setup()
        {
            lines = new List<SubtitlesEditor.LineInfos.ILineInfo>{
                new Mpl2LineInfo{LineNumber=1,Line="Pierwsza linia",Begin="1", End="50"},
                new Mpl2LineInfo{LineNumber=2,Line="Druga linia",Begin="100", End="200"},
                new Mpl2LineInfo{LineNumber=3,Line="Trzecia linia",Begin="200", End="500"}
            };
            Assembly a = Assembly.GetExecutingAssembly();
            using (Stream s = a.GetManifestResourceStream("TestSubtitlesEditor.testMpl2.txt"))
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
            using (Stream s = a.GetManifestResourceStream("TestSubtitlesEditor.testMpl2issued.txt"))
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
            var moqNavi = new Mock<ISubtitlesNavigator>();
            moqNavi.Setup(x => x.GetFileLine(2)).Returns(lines[1]);
            moqNavi.Setup(x => x.LastLineIndex).Returns(3);
            moqNavi.Setup(x => x.Lines).Returns(lines);
            this.mpl2Reader = new Mpl2Reader(moqNavi.Object);
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
        public void LoadSubsFromFile_ProperMpl2File_ReturnsLineInfoList()
        {
            var actual = mpl2Reader.LoadSubsListFromFile(testFilePath, Encoding.Default);
            CollectionAssert.AreEqual(lines, actual, "Niepoprawnie wczytana lista z poprawnego pliku .txt(mpl2)");
        }
        [Test]
        public void LoadSubsFromFile_NotProperMpl2File_ReturnsLineInfoList()
        {
            var actual = mpl2Reader.LoadSubsListFromFile(issuedTestFilePath, Encoding.Default);
            CollectionAssert.AreEqual(lines, actual, "Niepoprawnie wczytana lista z niepoprawnego pliku .txt(mpl2)");
        }
        [Test]
        public void LoadSubsFromFile_FileNotExist_ReturnEmptyCollection()
        {
            var actual = mpl2Reader.LoadSubsListFromFile(testFilePath + "xy", Encoding.Default);
            Assert.IsEmpty(actual, "Nie zwrócono pustej listy z nieistniejącego pliku");
        }
        [Test]
        public void AssignTimeProperies_Begin0End1second_SetCorrectValues()
        {
            var expectedBeginTime = "100";
            var expectedEndTime = "200";
            var lineInfo = lines[0];
            mpl2Reader.AssignTimeProperies("[100] [200] ", ref lineInfo);

            var actualBeginTime = lineInfo.Begin;
            var actualEndTime = lineInfo.End;

            Assert.AreEqual(expectedBeginTime, actualBeginTime, "Czas pokazania niezgodny");
            Assert.AreEqual(expectedEndTime, actualEndTime, "Czas znikniecia niezgodny");
        }
        [Test]
        public void IsChanged_SameFile_ReturnsFalse()
        {
            var filePath = testFilePath;
            var filePath2 = testFilePath;

            var actual = mpl2Reader.IsChanged(filePath, filePath2);

            Assert.IsFalse(actual);
        }
        [Test]
        public void IsChanged_DifferentFiles_ReturnsTrue()
        {
            var filePath = testFilePath;
            var filePath2 = issuedTestFilePath;

            var actual = mpl2Reader.IsChanged(filePath, filePath2);

            Assert.IsTrue(actual);
        }
    }
}
