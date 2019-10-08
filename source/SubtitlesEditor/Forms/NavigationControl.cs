using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SubtitlesEditor.LineInfos;
using SubtitlesEditor.Properties;

namespace SubtitlesEditor.Forms
{
    public partial class NavigationControl : UserControl
    {
        public event LineSelectedEventHandler LineSelected;
        public NavigationControl()
        {
            InitializeComponent();
        }
        public void Actualize()
        {

        }
        private void cmbLines_SelectedIndexChanged(object sender, EventArgs e)
        {
            int lineNumber = ((ILineInfo)cmbLines.SelectedItem).LineNumber;
            if (LineSelected != null)
            {
                LineSelected(this, new LineSelectedEventArgs(lineNumber));
            }
            Settings.Default.LineNumber = lineNumber;
            //try
            //{
            //    linfo = navigator.GetFileLine(lineNumber);
            //    Settings.Default.LineNumber = linfo.LineNumber;
            //    Settings.Default.Save();
            //}
            //catch (ArgumentOutOfRangeException)
            //{

            //}
            //ActualizeGUI();
        }
        public int SelectedIndex
        {
            set { cmbLines.SelectedIndex = value; }
        }
        public List<ILineInfo> Lines
        {
            set
            {
                cmbLines.SelectedIndexChanged -= cmbLines_SelectedIndexChanged;
                cmbLines.DataSource = value;//.Select(v => v.LineNumber + ": " + v.Line);
                cmbLines.SelectedIndexChanged += cmbLines_SelectedIndexChanged;
            }
        }
        public string SelectedLine
        {
            get { return cmbLines.SelectedItem.ToString(); }
        }
    }
    public delegate void LineSelectedEventHandler(object sender, LineSelectedEventArgs args);
    public class LineSelectedEventArgs
    {
        public LineSelectedEventArgs(int index)
        {
            this.LineNumber = index;
        }
        public int LineNumber { get; set; }
    }
}