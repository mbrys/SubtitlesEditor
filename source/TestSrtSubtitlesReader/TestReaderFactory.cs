using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.IO;
using System.Reflection;
using SubtitlesEditor.Readers;
using SubtitlesEditor.Navigators;
namespace TestSubtitlesEditor
{
    [TestFixture]
    public class TestReaderFactory
    {
        private string mplFilePath = Path.Combine(Path.GetTempPath(), "testMpl2.txt");
        private string microDVDFilePath = Path.Combine(Path.GetTempPath(), "test.sub");
        private string srtFilePath = Path.Combine(Path.GetTempPath(), "test.srt");
        private string unknownFilePath = Path.Combine(Path.GetTempPath(), "file.txt");

        [SetUp]
        public void Setup()
        {
            Assembly a = Assembly.GetExecutingAssembly();
            using (Stream s = a.GetManifestResourceStream("TestSubtitlesEditor.testMpl2.txt"))
            {
                using (StreamReader sr = new StreamReader(s))
                {
                    using (StreamWriter sw = File.CreateText(mplFilePath))
                    {
                        sw.Write(sr.ReadToEnd());
                        sw.Flush();
                    }
                }
            }
            using (Stream s = a.GetManifestResourceStream("TestSubtitlesEditor.test.sub"))
            {
                using (StreamReader sr = new StreamReader(s))
                {
                    using (StreamWriter sw = File.CreateText(microDVDFilePath))
                    {
                        sw.Write(sr.ReadToEnd());
                        sw.Flush();
                    }
                }
            }
            using (Stream s = a.GetManifestResourceStream("TestSubtitlesEditor.test.srt"))
            {
                using (StreamReader sr = new StreamReader(s))
                {
                    using (StreamWriter sw = File.CreateText(srtFilePath))
                    {
                        sw.Write(sr.ReadToEnd());
                        sw.Flush();
                    }
                }
            }
            using (Stream s = a.GetManifestResourceStream("TestSubtitlesEditor.file.txt"))
            {
                using (StreamReader sr = new StreamReader(s))
                {
                    using (StreamWriter sw = File.CreateText(unknownFilePath))
                    {
                        sw.Write(sr.ReadToEnd());
                        sw.Flush();
                    }
                }
            }
        }
        [TearDown]
        public void TearDown()
        {
            if (File.Exists(mplFilePath))
            {
                File.Delete(mplFilePath);
            }
            if (File.Exists(microDVDFilePath))
            {
                File.Delete(microDVDFilePath);
            }
            if (File.Exists(srtFilePath))
            {
                File.Delete(srtFilePath);
            }
            if (File.Exists(unknownFilePath))
            {
                File.Delete(unknownFilePath);
            }
        }
        [Test]
        public void GetReader_Mpl2File_CreatesMpl2Reader()
        {
            ISubtitlesNavigator nav = new DefaultNavigator();
            var expected = typeof(Mpl2Reader);
            var actual = ReaderFactory.CreateReader(mplFilePath, ref nav).GetType();
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void GetReader_MicroDVDFile_CreatesMicroDVDReader()
        {
            ISubtitlesNavigator nav = new DefaultNavigator();
            var expected = typeof(MicroDVDReader);
            var actual = ReaderFactory.CreateReader(microDVDFilePath, ref nav).GetType();
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void GetReader_SrtFile_CreatesSrtReader()
        {
            ISubtitlesNavigator nav = new DefaultNavigator();
            var expected = typeof(SubRipReader);
            var actual = ReaderFactory.CreateReader(srtFilePath, ref nav).GetType();
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void GetReader_UnknownFile_ReturnsNull()
        {
            ISubtitlesNavigator nav = new DefaultNavigator();
            var actual = ReaderFactory.CreateReader(unknownFilePath, ref nav);
            Assert.IsNull(actual, "Unknown file reader should be null");
        }
    }
}
