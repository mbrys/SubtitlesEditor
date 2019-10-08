using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using SubtitlesEditor.LineInfos;

namespace TestSubtitlesEditor
{
    [TestFixture]
    public class TestMicroDVDLineInfo
    {
        private MicroDVDLineInfo lineInfo;
        [SetUp]
        public void Setup()
        {
            lineInfo = new MicroDVDLineInfo();
            MicroDVDLineInfo.FramePerSecond = 25;
        }
        [Test]
        public void SecondsToTime_ValueWith25fpsRatio_ReturnsCorrectValue()
        {
            var parameter = 10;
            var expected = "250";
            var actual = lineInfo.SecondsToTime(parameter);

            Assert.AreEqual(expected, actual, "Czas nie jest wyświetlony prawidłowo");
        }
        [Test]
        public void SecondsToTime_ValueWithFractional_ReturnsCorrectTime()
        {

            var parameter = 10.5;
            var expected = "262";

            var actual = lineInfo.SecondsToTime(parameter);

            Assert.AreEqual(expected, actual, "Czas nie jest wyświetlony prawidłowo");
        }
        [Test]
        public void TimeToSeconds_CorrectlyFormattedTimeAsParameter_ReturnsCorrectAmountOfSeconds()
        {
            var parameter = "100";
            var expected = 4;

            var actual = lineInfo.TimeToSeconds(parameter);

            Assert.AreEqual(expected, actual, "Czas nie jest wyświetlony prawidłowo");
        }

        [Test]
        public void MoveTime_CorrectValuePlusCorrectValue_ReturnsCorrectValue()
        {
            var parameter1 = "100";
            var parameter2 = 10;
            var expected = "350";

            var actual = lineInfo.MoveTime(parameter1, parameter2);

            Assert.AreEqual(expected, actual, "Czas nie został dodany prawidłowo");
        }
        [Test]
        public void MoveTime_ValueMinusGreaterValue_ThrowsException()
        {
            var parameter1 = "{300}";
            var parameter2 = -13;
            var exception = Assert.Throws<ArgumentException>(() => lineInfo.MoveTime(parameter1, parameter2), "Nie został wyrzucony wyjątek o odejmowaniu zbyt wielkiej ilości czasu");
            Assert.AreEqual("Too much time to subtract", exception.Message, "Same exception types, but different messages");
        }
    }
}
