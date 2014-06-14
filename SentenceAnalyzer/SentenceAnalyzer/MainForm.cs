using System.Globalization;
using SentenceAnalyzer.Library;
using SentenceAnalyzer.Library.Rules;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace SentenceAnalyzer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnAnalyze_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(rtbSentenceContainer.Text))
            {
                rtbSentenceContainer.Text = rtbSentenceContainer.Text.Trim();
                rtbSentenceContainer.Text = rtbSentenceContainer.Text[0].ToString(CultureInfo.InvariantCulture).ToUpper() + rtbSentenceContainer.Text.Substring(1);
            }
            
            // todo: remove stub

            var words = new WordCollection();
            words.Load(Properties.Settings.Default.WordsDictionaryPath);


            var s = new Sentence(rtbSentenceContainer.Text);
            s.SplitByWords(words);

            var rule = Rules.FindRule(s);

            var info = rule.Explain(s);

            llblTense.Text = info.Tense;
            llblDirection.Text = info.Direction;

            rtbSentenceContainer.Focus();

            pnlInfo.Visible = rule != null;
            if (rule != null)
            {
                llblTense.Text = rule.Name;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            rtbSentenceContainer.Text = string.Empty;
            pnlInfo.Visible = false;
            rtbSentenceContainer.Focus();
        }

        private void SetColor(Color color, params Chunk[] chunks)
        {
            // store cursor position
            var bkpPos = rtbSentenceContainer.SelectionStart;

            // clear formatting
            rtbSentenceContainer.SelectionStart = 0;
            rtbSentenceContainer.SelectionLength = rtbSentenceContainer.Text.Length;
            rtbSentenceContainer.SelectionColor = Color.Black;

            // mark all chunks
            foreach (var chunk in chunks)
            {
                rtbSentenceContainer.SelectionStart = chunk.StartPosition;
                rtbSentenceContainer.SelectionLength = chunk.Length;
                rtbSentenceContainer.SelectionColor = color;
            }

            // Set default parameters
            rtbSentenceContainer.SelectionLength = 0;
            rtbSentenceContainer.SelectionStart = bkpPos;
            rtbSentenceContainer.SelectionColor = Color.Black;
        }

        private void LinkedLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var url = e.Link.LinkData as string;
            if (!string.IsNullOrWhiteSpace(url))
            {
                // open page in a dafault browser
                Process.Start(url);
            }
        }
    }
}
