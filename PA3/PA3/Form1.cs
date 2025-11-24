using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PA3
{
    public partial class Form1 : Form
    {
        private readonly Color _defaultOutputBack = Color.FromArgb(37, 37, 38);

        public Form1()
        {
            InitializeComponent();
            txtOutput.BackColor = _defaultOutputBack;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            var lines = txtInput.Lines ?? Array.Empty<string>();
            var outputs = new List<string>(lines.Length);

            foreach (var raw in lines)
            {
                var s = (raw ?? string.Empty).Trim();
                if (s.Length == 0)
                {
                    // preserve blank lines in the output area
                    outputs.Add(string.Empty);
                    continue;
                }

                // Accept only a, b, c (case-insensitive). Any other character -> NO.
                bool onlyABC = s.All(ch =>
                {
                    var lower = char.ToLowerInvariant(ch);
                    return lower == 'a' || lower == 'b' || lower == 'c';
                });

                string result;
                if (!onlyABC)
                {
                    result = "NO";
                }
                else
                {
                    // check form a^n b^n c^n with all counts equal and ordering a...b...c...
                    int i = 0;
                    while (i < s.Length && char.ToLowerInvariant(s[i]) == 'a') i++;
                    int aCount = i;

                    int j = i;
                    while (j < s.Length && char.ToLowerInvariant(s[j]) == 'b') j++;
                    int bCount = j - i;

                    int k = j;
                    while (k < s.Length && char.ToLowerInvariant(s[k]) == 'c') k++;
                    int cCount = k - j;

                    // must consume entire string and counts must be equal (n >= 1 allowed)
                    if (k != s.Length)
                    {
                        result = "NO";
                    }
                    else if (aCount == bCount && bCount == cCount)
                    {
                        result = "YES";
                    }
                    else
                    {
                        result = "NO";
                    }
                }

                outputs.Add(result);
            }

            // Show results (preserve blank lines)
            txtOutput.Text = string.Join(Environment.NewLine, outputs);

            // Background color logic YES = green and NO = red
            var nonEmpty = outputs.Where(x => !string.IsNullOrEmpty(x)).ToList();
            if (nonEmpty.Count == 0)
            {
                txtOutput.BackColor = _defaultOutputBack;
                txtOutput.ForeColor = Color.White;
                return;
            }

            bool anyYes = nonEmpty.Any(x => string.Equals(x, "YES", StringComparison.OrdinalIgnoreCase));
            bool anyNo = nonEmpty.Any(x => string.Equals(x, "NO", StringComparison.OrdinalIgnoreCase));

            if (anyYes && !anyNo)
            {
                txtOutput.BackColor = Color.FromArgb(46, 204, 113); // green
                txtOutput.ForeColor = Color.White;
            }
            else if (anyNo && !anyYes)
            {
                txtOutput.BackColor = Color.FromArgb(255, 69, 58); // red
                txtOutput.ForeColor = Color.White;
            }
            else
            {
                // mixed results -> neutral background
                txtOutput.BackColor = _defaultOutputBack;
                txtOutput.ForeColor = Color.White;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtInput.Clear();
            txtOutput.Text = string.Empty;
            txtOutput.BackColor = _defaultOutputBack;
            txtOutput.ForeColor = Color.White;
        }

        private void txtInput_TextChanged(object sender, EventArgs e)
        {
            // Optional
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Optional 
        }
    }
}
