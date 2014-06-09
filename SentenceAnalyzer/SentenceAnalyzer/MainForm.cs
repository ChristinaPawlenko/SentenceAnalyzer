using Common.Model;
using SentenceAnalyzer.Library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            // todo: remove stub

            var words = new WordCollection();
            words.Load(Properties.Settings.Default.WordsDictionaryPath);

            //var s = new Sentence("'Oh, you cannot help that,' said the Cat: 'we are all mad here. I am mad. You are mad.'");
            var s = new Sentence("Honestly I and my brother are big friends.");
            s.SplitByWords(words);
           
            SetColor(Color.Red, new Chunk(5, 10, ""), new Chunk(15, 23, ""));
            rtbSentenceContainer.Focus();

            lblSubjectText.Text = "word1, word1, word1, word1, word1, word1, word1";
            lblPredicateText.Text = "word2, word2, word2, word2, word2, word2, word2";
            llblTense.Links[0].LinkData = Properties.Settings.Default.FuturePerfectContinuousUrl;
            llblDirection.Links[0].LinkData = Properties.Settings.Default.AffirmativeUrl;

            pnlInfo.Visible = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            rtbSentenceContainer.Text = string.Empty;
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
