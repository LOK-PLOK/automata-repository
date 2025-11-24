
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PA1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            var input = txtInput.Text ?? string.Empty;
            var result = Regex.Replace(input, @"\S+", m => new string(m.Value.Reverse().ToArray()));
            txtOutput.Text = result;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtInput.Clear();
            txtOutput.Clear();
        }

        private void txtInput_TextChanged(object sender, EventArgs e)
        {
            // Optional: add live validation here
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Optional: initialization code
        }
    }
}
