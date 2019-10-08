using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SubtitlesEditor.LineInfos;
using SubtitlesEditor.Forms;

namespace SubtitlesEditor
{
    public partial class TimeControl : UserControl
    {
        public double SecsToMove { get; set; }
        public ILineInfo LineInfo { get; set; }
        public event LineTimeChanged LineTimeChanged;
        public TimeControl()
        {
            InitializeComponent();
            btnBeginLater.Click += new EventHandler(UpdateDisplay);
            btnEndLater.Click += new EventHandler(UpdateDisplay);
            btnBeginSooner.Click += new EventHandler(UpdateDisplay);
            btnEndSooner.Click += new EventHandler(UpdateDisplay);
            btnLineLater.Click += new EventHandler(UpdateDisplay);
            btnLineSooner.Click += new EventHandler(UpdateDisplay);
        }

        public void Update(ILineInfo lineInfo, string text)
        {
            SetTimeRelatedLabels(lineInfo, text);
            tbBeginTime.Text = lineInfo.Begin;
            tbEndTime.Text = lineInfo.End;
        }
        public void UpdateDisplay(object sender, EventArgs e)
        {
            Update(LineInfo, LineInfo.Line);
        }
        public void SetTimeRelatedLabels(ILineInfo lineInfo, string text)
        {
            int chars;
            if (!String.IsNullOrEmpty(text))
                chars = text.Count(x => (x != ' ' && x != '|'));
            else
                chars = lineInfo.Line.Count(x => (x != ' ' && x != '|'));

            double secs = (lineInfo.TimeToSeconds(lineInfo.End) - lineInfo.TimeToSeconds(lineInfo.Begin));
            lbLineTimeValue.Text = String.Format("{0:0.000}s", secs);
            double cpsRatio = Math.Round(chars / secs, 3);
            if (cpsRatio > 20)
            {
                lbCharsPerSecValue.BackColor = Color.IndianRed;
                lbCharsPerSecValue.BackColor = Color.Red;
            }
            else
            {
                lbCharsPerSecValue.BackColor = SystemColors.Control;
                lbCharsPerSecValue.ForeColor = Color.Black;
            }
            lbCharsPerSecValue.Text = String.Format("{0:0.00}", cpsRatio);
        }
        private void btnBeginSooner_Click(object sender, EventArgs e)
        {
            if (LineInfo != null)
            {
                LineInfo.Begin = LineInfo.MoveTime(LineInfo.Begin, -SecsToMove);
                if (LineTimeChanged != null)
                    LineTimeChanged(this, new LineTimeChangedEventArgs(LineInfo));
            }
        }

        private void btnBeginLater_Click(object sender, EventArgs e)
        {
            if (LineInfo != null)
            {
                LineInfo.Begin = LineInfo.MoveTime(LineInfo.Begin, SecsToMove);
                if (LineTimeChanged != null)
                    LineTimeChanged(this, new LineTimeChangedEventArgs(LineInfo));
            }
        }

        private void btnEndSooner_Click(object sender, EventArgs e)
        {
            if (LineInfo != null)
            {
                LineInfo.End = LineInfo.MoveTime(LineInfo.End, -SecsToMove);
                if (LineTimeChanged != null)
                    LineTimeChanged(this, new LineTimeChangedEventArgs(LineInfo));
            }
        }

        private void btnEndLater_Click(object sender, EventArgs e)
        {
            if (LineInfo != null)
            {
                LineInfo.End = LineInfo.MoveTime(LineInfo.End, SecsToMove);
                if (LineTimeChanged != null)
                    LineTimeChanged(this, new LineTimeChangedEventArgs(LineInfo));
            }

        }

        private void btnLineSooner_Click(object sender, EventArgs e)
        {
            if (LineInfo != null)
            {
                LineInfo.Begin = LineInfo.MoveTime(LineInfo.Begin, -SecsToMove);
                LineInfo.End = LineInfo.MoveTime(LineInfo.End, -SecsToMove);
                if (LineTimeChanged != null)
                    LineTimeChanged(this, new LineTimeChangedEventArgs(LineInfo));
            }

        }

        private void btnLineLater_Click(object sender, EventArgs e)
        {
            if (LineInfo != null)
            {
                LineInfo.Begin = LineInfo.MoveTime(LineInfo.Begin, SecsToMove);
                LineInfo.End = LineInfo.MoveTime(LineInfo.End, SecsToMove);
                if (LineTimeChanged != null)
                    LineTimeChanged(this, new LineTimeChangedEventArgs(LineInfo));
            }


        }

        private void TimeControl_Load(object sender, EventArgs e)
        {
            SecsToMove = 0.2;
        }
    }
    public delegate void LineTimeChanged(object sender, LineTimeChangedEventArgs e);
    public class LineTimeChangedEventArgs : EventArgs
    {
        public LineTimeChangedEventArgs(ILineInfo line)
        {
            this.LineInfo = line;
        }

        public ILineInfo LineInfo { get; set; }
    }
}

