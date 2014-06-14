using System.Globalization;
using SentenceAnalyzer.Library;
using SentenceAnalyzer.Library.Rules;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;

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
            try
            {
                if (!string.IsNullOrWhiteSpace(rtbSentenceContainer.Text))
                {
                    rtbSentenceContainer.Text = rtbSentenceContainer.Text.Trim();
                    rtbSentenceContainer.Text = rtbSentenceContainer.Text[0].ToString(CultureInfo.InvariantCulture).ToUpper() + rtbSentenceContainer.Text.Substring(1);
                }

                // Load Dictionary
                var words = new WordCollection();
                words.Load(Properties.Settings.Default.WordsDictionaryPath);

                // Create sentance
                var sentence = new Sentence(rtbSentenceContainer.Text);
                sentence.SplitByWords(words);

                // Find appropriate rule
                var rule = Rules.FindRule(sentence);

                // Get Info
                var info = rule.Explain(sentence);

                // Highlight subject and Predicate
                SetColor(Color.Blue, info.Subject);
                //SetColor(Color.Green, info.Predicate);

                // Set Labels
                SetLabels(info.Tense, info.Direction);
                lblSubjectText.Text = info.Subject.Substring;
                //lblPredicateText.Text = string.Join(", ", info.Predicate.Select(x => x.Substring)).Trim(',', ' ');

                rtbSentenceContainer.Focus();
                pnlInfo.Visible = true;
            }
            catch
            {
                pnlInfo.Visible = false;
                MessageBox.Show("Unsuccessful analyzing of sentence because of some reason", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void SetLabels(string tense, string direction)
        {
            llblTense.Text = tense;
            llblDirection.Text = direction;

            llblTense.Links.Clear();
            llblDirection.Links.Clear();

            switch (tense)
            {
                case "Present Simple":
                    llblTense.Links.Add(0, tense.Length, Properties.Settings.Default.SimplePresentUrl);
                    break;
                case "PresentContinuousUrl": 
                    llblTense.Links.Add(0, tense.Length, Properties.Settings.Default.PresentContinuousUrl); 
                    break;
                case "PresentPerfectUrl": 
                    llblTense.Links.Add(0, tense.Length, Properties.Settings.Default.PresentPerfectUrl); 
                    break;
                case "PresentPerfectContinuousUrl": 
                    llblTense.Links.Add(0, tense.Length, Properties.Settings.Default.PresentPerfectContinuousUrl); 
                    break;
                case "SimplePastUrl": 
                    llblTense.Links.Add(0, tense.Length, Properties.Settings.Default.SimplePastUrl); 
                    break;
                case "PastContinuousUrl": 
                    llblTense.Links.Add(0, tense.Length, Properties.Settings.Default.PastContinuousUrl); 
                    break;
                case "PastPerfectUrl": 
                    llblTense.Links.Add(0, tense.Length, Properties.Settings.Default.PastPerfectUrl); 
                    break;
                case "PastPerfectContinuousUrl": 
                    llblTense.Links.Add(0, tense.Length, Properties.Settings.Default.PastPerfectContinuousUrl); 
                    break;
                case "SimpleFutureUrl": 
                    llblTense.Links.Add(0, tense.Length, Properties.Settings.Default.SimpleFutureUrl); 
                    break;
                case "FutureContinuousUrl": 
                    llblTense.Links.Add(0, tense.Length, Properties.Settings.Default.FutureContinuousUrl); 
                    break;
                case "FuturePerfectUrl": 
                    llblTense.Links.Add(0, tense.Length, Properties.Settings.Default.FuturePerfectUrl); 
                    break;
                case "FuturePerfectContinuousUrl": 
                    llblTense.Links.Add(0, tense.Length, Properties.Settings.Default.FuturePerfectContinuousUrl); 
                    break;
            }

            switch (direction)
            {
                case "Affirmative":
                    llblDirection.Links.Add(0, tense.Length, Properties.Settings.Default.AffirmativeUrl); 
                    break;
                case "Negative":
                    llblDirection.Links.Add(0, tense.Length, Properties.Settings.Default.NegativeUrl); 
                    break;
                case "Interrogative":
                    llblDirection.Links.Add(0, tense.Length, Properties.Settings.Default.InterrogativeUrl); 
                    break;
            }
        }
    }
}
