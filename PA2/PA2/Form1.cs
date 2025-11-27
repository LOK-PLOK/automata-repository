using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PA2
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
                    outputs.Add(string.Empty);
                    continue;
                }

                // Case-sensitive: accept only lowercase 'a' and 'b'. Any other character -> No.
                bool onlyLowerAB = s.All(ch => ch == 'a' || ch == 'b');
                string result;
                if (!onlyLowerAB)
                {
                    result = "No";
                }
                else
                {
                    int aCount = s.Count(ch => ch == 'a');
                    int bCount = s.Count(ch => ch == 'b');

                    bool aEven = (aCount % 2) == 0;
                    bool bOdd = (bCount % 2) == 1;

                    result = (aEven && bOdd) ? "Yes" : "No";
                }

                outputs.Add(result);
            }

            // Show results (preserve blank lines)
            txtOutput.Text = string.Join(Environment.NewLine, outputs);

            // Background color logic Yes = green and No = red
            var nonEmpty = outputs.Where(x => !string.IsNullOrEmpty(x)).ToList();
            if (nonEmpty.Count == 0)
            {
                txtOutput.BackColor = _defaultOutputBack;
                txtOutput.ForeColor = Color.White;
                return;
            }

            bool anyYes = nonEmpty.Any(x => string.Equals(x, "Yes", StringComparison.Ordinal));
            bool anyNo = nonEmpty.Any(x => string.Equals(x, "No", StringComparison.Ordinal));

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
