using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using SubtitlesEditor.LineInfos;

namespace TestSubtitlesEditor
{
    [TestFixture]
    public class TestMpl2LineInfo
    {
        private Mpl2LineInfo lineInfo;
        [SetUp]
        public void Setup()
        {
            lineInfo = new Mpl2LineInfo();
        }
        [Test]
        public void SecondsToTime_ValueWithMilisecondsAsParameter_ReturnsDeciseconds()
        {
            var parameter = 3661.001;
            var expected = "36610";
            var actual = lineInfo.SecondsToTime(parameter);

            Assert.AreEqual(expected, actual, "Czas nie jest wyświetlony prawidłowo");
        }
        [Test]
        public void SecondsToTime_ProperValueAsParameter_ReturnsCorrectTime()
        {
            var parameter = 360642.2;
            var expected = "3606422";

            var actual = lineInfo.SecondsToTime(parameter);

            Assert.AreEqual(expected, actual, "Czas nie jest wyświetlony prawidłowo");
        }
        [Test]
        public void TimeToSeconds_CorrectlyFormattedTimeAsParameter_ReturnsCorrectAmountOfSeconds()
        {
            var parameter = "117029";
            var expected = 11702.9;

            var actual = lineInfo.TimeToSeconds(parameter);

            Assert.AreEqual(expected, actual, "Czas nie jest wyświetlony prawidłowo");
        }

        [Test]
        public void MoveTime_CorrectValuePlusCorrectValue_ReturnsCorrectValue()
        {
            var parameter1 = "12345";
            var parameter2 = 125.2;
            var expected = "13597";

            var actual = lineInfo.MoveTime(parameter1, parameter2);

            Assert.AreEqual(expected, actual, "Czas nie został dodany prawidłowo");
        }
        [Test]
        public void MoveTime_ValueMinusGreaterValue_ThrowsException()
        {
            var parameter1 = "[1245]";
            var parameter2 = -125.0;
            var exception = Assert.Throws<ArgumentException>(() => lineInfo.MoveTime(parameter1, parameter2), "Nie został wyrzucony wyjątek o odejmowaniu zbyt wielkiej ilości czasu");
            Assert.AreEqual("Too much time to subtract", exception.Message, "Same exception types, but different messages");
        }
    }
}
