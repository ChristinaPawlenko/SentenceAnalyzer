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
            SetColor(Color.Red, "artem", "mitya");
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

        private void SetColor(Color color, params string[] words)
        {
            foreach (var word in words)
            {
                if (string.IsNullOrWhiteSpace(word)) continue;
                int pos = rtbSentenceContainer.Find(word, RichTextBoxFinds.WholeWord);
                while(pos > 0)
                {
                    rtbSentenceContainer.SelectionStart = pos;
                    rtbSentenceContainer.SelectionLength = word.Length;
                    rtbSentenceContainer.SelectionColor = color;

                    pos = rtbSentenceContainer.Find(word, pos + 1, RichTextBoxFinds.WholeWord);
                }
            }
        }

        private void LinkedLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var url = e.Link.LinkData as string;
            if (!string.IsNullOrWhiteSpace(url))
            {
                Process.Start(url);
            }
        }
    }
}
