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
                    outputs.Add(string.Empty);
                    continue;
                }

                // Case-sensitive: accept only lowercase 'a', 'b', 'c'. Any other character -> NO.
                bool onlyLowerABC = s.All(ch => ch == 'a' || ch == 'b' || ch == 'c');

                string result = "NO";
                if (onlyLowerABC && IsAnBnCn_WithStacks(s))
                {
                    result = "YES";
                }

                outputs.Add(result);
            }

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

        private static bool IsAnBnCn_WithStacks(string s)
        {
            var stackA = new Stack<char>();
            var stackB = new Stack<char>();
            int section = 0; 

            foreach (var ch in s)
            {
                switch (ch)
                {
                    case 'a':
                        // 'a' allowed only in a-section
                        if (section != 0)
                        {
                            return false;
                        }

                        stackA.Push('a');
                        break;

                    case 'b':
                        // 'b' not allowed after entering c-section
                        if (section == 2)
                        {
                            return false;
                        }

                        section = 1; // enter b-section
                        if (stackA.Count == 0)
                        {
                            // more b's than a's
                            return false;
                        }

                        stackA.Pop();
                        stackB.Push('b');
                        break;

                    case 'c':
                        // enter c-section
                        section = 2;
                        if (stackB.Count == 0)
                        {
                            // more c's than b's
                            return false;
                        }

                        stackB.Pop();
                        break;

                    default:
                        return false; 
                }
            }

            return stackA.Count == 0 && stackB.Count == 0 && section == 2;
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
