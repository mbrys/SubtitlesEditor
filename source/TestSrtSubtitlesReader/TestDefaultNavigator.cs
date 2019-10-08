using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using SubtitlesEditor.LineInfos;
using SubtitlesEditor.Navigators;

namespace TestSubtitlesEditor
{
    [TestFixture]
    public class TestDefaultpNavigator
    {
        private DefaultNavigator navigator;
        [SetUp]
        public void Setup()
        {
            var moqLineInfo1 = CreateMockLineInfo(1, "Pierwsza linia");
            var moqLineInfo2 = CreateMockLineInfo(2, "Druga linia");
            var moqLineInfo3 = CreateMockLineInfo(3, "Trzecia linia");
            navigator = new DefaultNavigator();
            var lines = new List<ILineInfo>{
                moqLineInfo1.Object,
                moqLineInfo2.Object,
                moqLineInfo3.Object
            };
            navigator.Lines = lines;
        }

        private Mock<ILineInfo> CreateMockLineInfo(int no, string lineText)
        {
            var moqLineInfo = new Mock<ILineInfo>();
            moqLineInfo.Setup(x => x.LineNumber).Returns(no);
            moqLineInfo.Setup(x => x.Line).Returns(lineText);
            moqLineInfo.Setup(x => x.Begin).Returns("beginTime");
            moqLineInfo.Setup(x => x.End).Returns("endTime");
            moqLineInfo.Setup(x => x.TimeInfo).Returns("[beginTime][endTime]");
            return moqLineInfo;
        }
        [TearDown]
        public void Clear()
        {
            foreach (var line in navigator.Lines)
                System.Diagnostics.Debug.WriteLine(line.ToString());
        }
        [Test]
        public void GetFileLine_1stLineInfoIsInValueSet_Returns1stLineInfo()
        {
            var expected = CreateMockLineInfo(1, "Pierwsza linia");

            var actual = navigator.GetFileLine(1);

            Assert.AreEqual(expected.Object.LineNumber, actual.LineNumber);
        }
        [Test]
        public void GetFileLine_2ndLineInfoIsInValueSet_Returns2ndLineInfo()
        {
            var expected = CreateMockLineInfo(2, "Druga linia");

            var actual = navigator.GetFileLine(2);

            Assert.AreEqual(expected.Object.LineNumber, actual.LineNumber);
        }
        [Test]
        public void GetFileLine_3rdLineInfoIsInValueSet_Returns3rdLineInfo()
        {
            var expected = CreateMockLineInfo(3, "Trzecia linia");

            var actual = navigator.GetFileLine(3);

            Assert.AreEqual(expected.Object.LineNumber, actual.LineNumber);
        }
        [Test]
        public void GetFileLine_FourthLineInfoIsRigthAboveTopBoundary_ThrowsExeption()
        {
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => navigator.GetFileLine(4));
            Assert.AreEqual("Requested item don't exist in collection\r\nParameter name: index", exception.Message, exception.Message);
        }
        [Test]
        public void GetFileLine_ZeroLineInfoIsRigthBelowTopBoundary_ThrowsExeption()
        {
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => navigator.GetFileLine(0));
            Assert.AreEqual("Requested item don't exist in collection\r\nParameter name: index", exception.Message,exception.Message);
        }


        [Test]
        public void GetFileLine_NegativeIndex_ThrowException()
        {
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => navigator.GetFileLine(-7));
            Assert.AreEqual("Requested item don't exist in collection\r\nParameter name: index", exception.Message, exception.Message);
        }
    }
}
