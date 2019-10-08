using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SubtitlesEditor.Forms;
using SubtitlesEditor.LineInfos;
using SubtitlesEditor.Navigators;
using SubtitlesEditor.Properties;
using SubtitlesEditor.Readers;

namespace SubtitlesEditor
{

    public partial class MainForm : Form
    {
        private ILineInfo lineInfo;
        private FileHelper fileHelper;

        private bool translationMode;
        private FileHelper translationHelper;
        private ILineInfo translationLineInfo;
        private string translationPath;

        private string fullPath;
        private string fileName;
        private string extension;
        private EncodingInfo encoding;
        public MainForm()
        {
            InitializeComponent();

            this.Icon = Resources.icon;
            this.timeControl1.LineTimeChanged += new LineTimeChanged(timeControl1_LineTimeChanged);
            this.navigationControl1.LineSelected += new LineSelectedEventHandler(navigationControl1_LineSelected);
            translationMode = false;
            fullPath = Settings.Default.FilePath;
            extension = Settings.Default.Extension;
            encoding = Encoding.GetEncodings().SingleOrDefault(x => x.DisplayName == Settings.Default.Encoding);
            //Initialize comboBox with horizontal or vertical view
            cmbOrientation.DataSource = Enum.GetValues(typeof(Orientation));
            cmbOrientation.SelectedIndex = 0;
            try
            {
                LoadLastFile();
            }
            catch (Exception)
            {
                MessageBox.Show("Some kind of madness...");
            }
            //UpdateGUI();
        }
        //TODO: encoding problem with ♪ and d

        private void LoadLastFile()
        {
            if (!string.IsNullOrEmpty(fullPath) && File.Exists(fullPath))
            {
                try
                {
                    fileHelper = new FileHelper(GetReader(fullPath));
                    var enc = (encoding != null) ? encoding.GetEncoding() : Encoding.Default;
                    LoadFile(Settings.Default.LineNumber, enc);
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message); }
            }
        }

        private void LoadFile(int lineNumber, Encoding enc)
        {
            fileHelper.LoadLines(fullPath, enc);
            navigationControl1.Lines = fileHelper.Lines;
            extension = fullPath.Substring(fullPath.LastIndexOf('.'));
            Settings.Default.Extension = extension;
            Settings.Default.FilePath = fullPath;
            fileName = fullPath.Substring(fullPath.LastIndexOf('\\') + 1);
            Settings.Default.Save();
            LoadOriginalAndTranslatedLineInfos(lineNumber);
            if (translationMode && translationLineInfo != null)
                timeControl1.LineInfo = translationLineInfo;
            else
                timeControl1.LineInfo = lineInfo;
        }

        private void LoadOriginalAndTranslatedLineInfos(int lineNumber)
        {
            LoadLine(out lineInfo, fileHelper.GetLine, lineNumber);
            if (translationMode && translationHelper != null)
                LoadLine(out translationLineInfo, translationHelper.GetLine, lineNumber);

        }

        private void SaveFile(FileHelper helper, ILineInfo linfo, string path, bool saveCurrentLine)
        {
            if (saveCurrentLine)
                SaveTextInCurrentLine(linfo, tbLineText.Text.Trim());
            helper.UpdateLineList(linfo);
            helper.SaveFile(path);
        }

        private static ISubtitlesReader GetReader(string filepath)
        {
            ISubtitlesNavigator defaultNav = new DefaultNavigator();
            var temp = ReaderFactory.CreateReader(filepath, ref defaultNav);
            return temp;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Left | Keys.Control:

                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        public void UpdateGUI()
        {
            if (lineInfo != null)
            {
                this.timeControl1.Update(lineInfo, tbLineText.Text);
                if (translationMode)
                {
                    tbLineTranslation.Text = lineInfo.Line;
                    tbLineText.Text = translationLineInfo != null ? translationLineInfo.Line : "";
                }
                else
                    tbLineText.Text = lineInfo.Line;
                var percentage = string.Format("{0:0.0}", (lineInfo.LineNumber / (decimal)(fileHelper.LastLineIndex + 1)) * 100) + "%";
                this.Text = fileName + "Progress: " + percentage + " (" + lineInfo.LineNumber + " / " + (fileHelper.LastLineIndex + 1) + ")";
                int index = fileHelper.Lines.FindIndex(v => v.LineNumber == lineInfo.LineNumber);
                EnableProperButtons(index);
                navigationControl1.SelectedIndex = index;
                Settings.Default.Save();
            }
        }

        public void EnableProperButtons(int index)
        {
            if (index == 0)
            {
                btnPrevLine.Enabled = false;
                btnNextLine.Enabled = true;
            }
            else if (index >= fileHelper.LastLineIndex)
            {
                btnPrevLine.Enabled = true;
                btnNextLine.Enabled = false;
            }
            else
            {
                btnPrevLine.Enabled = true;
                btnNextLine.Enabled = true;
            }
        }


        private void LoadLine(out ILineInfo lineInfo, Func<int, ILineInfo> func, int funcParam)
        {
            lineInfo = null;
            try
            {
                lineInfo = func(funcParam);
                Settings.Default.LineNumber = lineInfo.LineNumber;
                Settings.Default.Save();
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show("Nie udało się wczytać linii.\r\n" + ex.Message);
            }
            UpdateGUI();
            tbLineText.Focus();
        }

        private void SaveTextInCurrentLine(ILineInfo linfo, string newLineText)
        {
            if (newLineText != "" && linfo.Line != newLineText)
            {
                linfo.Line = newLineText;
            }
        }

        private void chbTranslation_CheckedChanged(object sender, EventArgs e)
        {
            translationMode = chbTranslation.Checked;
            if (chbTranslation.Checked == true)
            {
                translationPath = fullPath.Substring(0, fullPath.Length - 4) + "-trnslt" + extension;
                translationHelper = CreateTranslationHelper(translationPath, fullPath, encoding);
            }
            SetTranslationView(translationMode);
            LoadOriginalAndTranslatedLineInfos(lineInfo != null ? lineInfo.LineNumber : 1);
            UpdateGUI();
        }

        private void SetTranslationView(bool condition)
        {
            if (!condition)
            {
                SaveTextInCurrentLine(translationLineInfo, tbLineText.Text.Trim());
                tbLineText.Clear();
                translationHelper.UpdateLineList(translationLineInfo);
            }
            splitContainer1.Panel2Collapsed = !condition;
            if (condition)
                splitContainer1.Panel2.Show();
            else
                splitContainer1.Panel2.Hide();
            duplicateTextToolStripMenuItem.Enabled = condition;
        }

        private static FileHelper CreateTranslationHelper(string trPath, string origPath, EncodingInfo enc)
        {
            FileHelper helper;
            var reader = GetReader(trPath);
            try
            {
                if (reader != null)
                {
                    helper = new FileHelper(reader);
                    if (helper != null)
                        helper.LoadLines(trPath, (enc != null) ? enc.GetEncoding() : Encoding.Default);
                }
                else
                {
                    var temp = GetReader(origPath);
                    var tempHelper = new FileHelper(temp);
                    tempHelper.LoadLines(origPath, Encoding.Default);
                    tempHelper.SaveTranslationFile(trPath);
                    helper = new FileHelper(GetReader(trPath));
                    //helper.SaveTranslationFile(trPath);
                }
            }
            catch (Exception)
            {
                return null;
            }
            return helper;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFile(fileHelper, lineInfo, fullPath, true);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fullPath = saveFileDialog1.FileName;
                SaveFile(fileHelper, lineInfo, fullPath, true);
                Settings.Default.FilePath = fullPath;
                Settings.Default.Save();
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (lineInfo != null && fileHelper != null)
            {
                if (translationMode)
                {
                    SaveTextInCurrentLine(translationLineInfo, tbLineText.Text.Trim());
                    translationHelper.UpdateLineList(translationLineInfo);
                }
                else
                {
                    SaveTextInCurrentLine(lineInfo, tbLineText.Text.Trim());
                    fileHelper.UpdateLineList(lineInfo);
                }

                // Create new stopwatch
                System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
                stopwatch.Start();
                if (fileHelper.IsChanged(fullPath))
                {
                    stopwatch.Stop();
                    DialogResult result = MessageBox.Show($"Document {fullPath} has been changed. Do you want to save it now? Elapsed time: {stopwatch.ElapsedMilliseconds}ms", "Closing", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk);
                    if (result == DialogResult.Yes)
                    {
                        fileHelper.SaveFile(fullPath);
                    }
                    else if (result == DialogResult.Cancel)
                        e.Cancel = true;
                }
                else
                {
                    if (MessageBox.Show("Are you sure to quit?", "Closing", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.No)
                        e.Cancel = true;
                    else
                    {
                        if (lineInfo != null)
                        {
                            Settings.Default.LineNumber = lineInfo.LineNumber;
                            Settings.Default.Save();
                        }
                    }
                }
            }
        }

        void timeControl1_LineTimeChanged(object sender, LineTimeChangedEventArgs e)
        {
            if (translationMode && translationHelper != null)
                translationHelper.UpdateLineList(e.LineInfo);
            else
                fileHelper.UpdateLineList(e.LineInfo);
            UpdateGUI();
        }

        private void btnPrevLine_Click(object sender, EventArgs e)
        {
            if (translationMode)
            {
                SaveTextInCurrentLine(translationLineInfo, tbLineText.Text.Trim());
                translationHelper.UpdateLineList(translationLineInfo);
            }
            else
                SaveTextInCurrentLine(lineInfo, tbLineText.Text.Trim());
            fileHelper.UpdateLineList(lineInfo);
            LoadOriginalAndTranslatedLineInfos(lineInfo.LineNumber - 1);

        }

        private void btnNextLine_Click(object sender, EventArgs e)
        {
            if (translationMode)
            {
                SaveTextInCurrentLine(translationLineInfo, tbLineText.Text.Trim());
                translationHelper.UpdateLineList(translationLineInfo);
            }
            else
                SaveTextInCurrentLine(lineInfo, tbLineText.Text.Trim());
            fileHelper.UpdateLineList(lineInfo);
            LoadOriginalAndTranslatedLineInfos(lineInfo.LineNumber + 1);
        }
        private void duplicateTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tbLineText.Text = tbLineTranslation.Text;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            splitContainer1.Orientation = (Orientation)cmbOrientation.SelectedItem;
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void navigationControl1_LineSelected(object sender, LineSelectedEventArgs args)
        {
            try
            {
                if (lineInfo.LineNumber != args.LineNumber)
                {
                    LoadOriginalAndTranslatedLineInfos(args.LineNumber);
                    EnableProperButtons(args.LineNumber);
                    navigationControl1.Focus();
                }
            }
            catch (ArgumentOutOfRangeException)
            {

            }
            UpdateGUI();
        }

        private void openSubsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    fullPath = openFileDialog1.FileName;
                    extension = fullPath.Substring(fullPath.LastIndexOf('.'));
                    fileHelper = new FileHelper(GetReader(fullPath));
                    var enc = (encoding != null) ? encoding.GetEncoding() : Encoding.Default;
                    LoadFile(1, enc);
                }
                catch (IOException ex)
                {
                    MessageBox.Show("I/O error during loading file");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error during loading file");
                }
            }
        }
        private void tbLineText_TextChanged(object sender, EventArgs e)
        {
            this.timeControl1.SetTimeRelatedLabels(lineInfo, tbLineText.Text);
        }

        private void chooseEncodingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EncodingChooser chooser = new EncodingChooser(encoding != null
                                        ? encoding
                                        : Encoding.GetEncodings().SingleOrDefault(x => x.DisplayName == Encoding.UTF8.EncodingName));
            chooser.EncodingChosen += new EncodingChosenEventHandler(chooser_EncodingChosen);
            chooser.ShowDialog();
        }
        private void chooser_EncodingChosen(EncodingEventArgs e)
        {
            encoding = e.Encoding;
            Settings.Default.Encoding = encoding.DisplayName;
            Settings.Default.Save();
            LoadLastFile();
            UpdateGUI();
            this.Focus();
        }

        private void saveTranslationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFile(translationHelper, translationLineInfo, translationPath, false);
        }
    }
}
