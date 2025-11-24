namespace PA1
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblInput;
        private Label lblOutput;
        private TextBox txtInput;
        private TextBox txtOutput;
        private Button btnStart;
        private Button btnClear;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code    

        private void InitializeComponent()
        {
            lblInput = new Label();
            txtInput = new TextBox();
            btnStart = new Button();
            btnClear = new Button();
            lblOutput = new Label();
            txtOutput = new TextBox();
            SuspendLayout();

            // styling para sa lblInput
            lblInput.AutoSize = true;
            lblInput.Font = new Font("JetBrains Mono", 12F);
            lblInput.ForeColor = Color.White;
            lblInput.Location = new Point(20, 20);
            lblInput.Name = "lblInput";
            lblInput.Size = new Size(70, 21);
            lblInput.TabIndex = 0;
            lblInput.Text = "Input:";

            // styling para sa txtInput
            txtInput.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            txtInput.BackColor = Color.FromArgb(37, 37, 38);
            txtInput.Font = new Font("JetBrains Mono", 12F);
            txtInput.ForeColor = Color.White;
            txtInput.Location = new Point(20, 50);
            txtInput.Multiline = true;
            txtInput.Name = "txtInput";
            txtInput.ScrollBars = ScrollBars.Vertical;
            txtInput.Size = new Size(300, 140);
            txtInput.TabIndex = 1;
            txtInput.TextChanged += txtInput_TextChanged;

            // styling para sa btnStart
            btnStart.Anchor = AnchorStyles.Top;
            btnStart.BackColor = Color.FromArgb(10, 132, 255);
            btnStart.FlatAppearance.BorderSize = 0;
            btnStart.FlatStyle = FlatStyle.Flat;
            btnStart.Font = new Font("JetBrains Mono", 12F);
            btnStart.ForeColor = Color.White;
            btnStart.Location = new Point(340, 60);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(100, 44);
            btnStart.TabIndex = 2;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = false;
            btnStart.Click += btnStart_Click;

            // styling para sa btnClear
            btnClear.Anchor = AnchorStyles.Top;
            btnClear.BackColor = Color.FromArgb(255, 59, 48);
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("JetBrains Mono", 12F);
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(340, 120);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(100, 44);
            btnClear.TabIndex = 3;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;

            // styling para sa lblOutput
            lblOutput.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblOutput.AutoSize = true;
            lblOutput.Font = new Font("JetBrains Mono", 12F);
            lblOutput.ForeColor = Color.White;
            lblOutput.Location = new Point(460, 20);
            lblOutput.Name = "lblOutput";
            lblOutput.Size = new Size(80, 21);
            lblOutput.TabIndex = 4;
            lblOutput.Text = "Output:";

            // styling para sa txtOutput
            txtOutput.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            txtOutput.BackColor = Color.FromArgb(37, 37, 38);
            txtOutput.Font = new Font("JetBrains Mono", 12F);
            txtOutput.ForeColor = Color.White;
            txtOutput.Location = new Point(460, 50);
            txtOutput.Multiline = true;
            txtOutput.Name = "txtOutput";
            txtOutput.ReadOnly = true;
            txtOutput.ScrollBars = ScrollBars.Vertical;
            txtOutput.Size = new Size(300, 140);
            txtOutput.TabIndex = 5;

            // Combine tanant para kay Form1
            BackColor = Color.FromArgb(30, 30, 30);
            ClientSize = new Size(780, 220);
            Controls.Add(lblInput);
            Controls.Add(txtInput);
            Controls.Add(btnStart);
            Controls.Add(btnClear);
            Controls.Add(lblOutput);
            Controls.Add(txtOutput);
            Font = new Font("JetBrains Mono", 12F);
            ForeColor = Color.White;
            MinimumSize = new Size(640, 240);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Word Reverser";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
