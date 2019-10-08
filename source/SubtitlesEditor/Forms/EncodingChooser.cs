using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SubtitlesEditor
{
    public partial class EncodingChooser : Form
    {
        public event EncodingChosenEventHandler EncodingChosen;
        public EncodingChooser(EncodingInfo encoding)
        {
            InitializeComponent();
            foreach (var encode in Encoding.GetEncodings().OrderBy(x => x.DisplayName))
                listBox1.Items.Add(encode.DisplayName);
            SelectEncoding(encoding);
        }

        private void SelectEncoding(EncodingInfo encoding)
        {
            var item = (encoding != null) ? encoding.DisplayName : "Default";
            listBox1.SelectedItem = encoding.DisplayName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (EncodingChosen != null)
            {
                var encoding = Encoding.GetEncodings().Where(x => x.DisplayName == listBox1.SelectedItem.ToString()).FirstOrDefault();
                EncodingChosen(new EncodingEventArgs(encoding));
            }
            this.Close();
        }
    }
    public delegate void EncodingChosenEventHandler(EncodingEventArgs e);
    public class EncodingEventArgs : EventArgs
    {
        EncodingInfo encoding;

        public EncodingInfo Encoding
        {
            get { return encoding; }
        }
        public EncodingEventArgs(EncodingInfo e)
        {
            this.encoding = e;
        }

    }
}
