using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using SubtitlesEditor.LineInfos;

namespace TestSubtitlesEditor
{
    [TestFixture]
    public class TestSubRipLineInfo
    {
        private SubRipLineInfo lineInfo;
        [SetUp]
        public void Setup()
        {
            lineInfo = new SubRipLineInfo();
        }
        [Test]
        public void SecondsToTime_1h1m1s1msAsParameter_ReturnsCorrectTime()
        {
            var parameter = 3661.001;
            var expected = "01:01:01,001";
            var actual = lineInfo.SecondsToTime(parameter);

            Assert.AreEqual(expected, actual, "Czas nie jest wyświetlony prawidłowo");
        }
        [Test]
        public void SecondsToTime_100h10m40s243msAsParameter_ReturnsCorrectTime()
        {
            var parameter = 360642.243;
            var expected = "100:10:42,243";
            var actual = lineInfo.SecondsToTime(parameter);

            Assert.AreEqual(expected, actual, "Czas nie jest wyświetlony prawidłowo");
        }
        [Test]
        public void TimeToSeconds_CorrectlyFormattedTimeAsParameter_Returns3661s001()
        {
            var parameter = "03:15:02,921";
            var expected = 11702.921;
            var actual = lineInfo.TimeToSeconds(parameter);

            Assert.AreEqual(expected, actual, "Czas nie jest wyświetlony prawidłowo");
        }

        [Test]
        public void MoveTime_1m1s612msPlus125s_Returns3m6s612ms()
        {
            var parameter1 = "00:01:01,612";
            var parameter2 = 125.0;
            var expected = "00:03:06,612";
            var actual = lineInfo.MoveTime(parameter1, parameter2);

            Assert.AreEqual(expected, actual, "Czas nie został dodany prawidłowo");
        }
        [Test]
        public void MoveTime_1m1s612msMinus125s_Returns3m6s612ms()
        {
            var parameter1 = "00:01:01,612";
            var parameter2 = -125.0;

            var exception = Assert.Throws<ArgumentException>(() => lineInfo.MoveTime(parameter1, parameter2), "Nie został wyrzucony wyjątek o odejmowaniu zbyt wielkiej ilości czasu");
            Assert.AreEqual("Too much time to subtract", exception.Message, "Same exception types, but different messages");
        }
    }
}
