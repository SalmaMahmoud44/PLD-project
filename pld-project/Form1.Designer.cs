namespace pld_project
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBox1 = new TextBox();
            listBox1 = new ListBox();
            label1 = new Label();
            label2 = new Label();
            listBox2 = new ListBox();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 12);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(347, 426);
            textBox1.TabIndex = 0;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(385, 62);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(403, 164);
            listBox1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Black", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.DarkCyan;
            label1.Location = new Point(385, 15);
            label1.Name = "label1";
            label1.Size = new Size(128, 41);
            label1.TabIndex = 2;
            label1.Text = "Syntax ";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Black", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.DarkCyan;
            label2.Location = new Point(385, 229);
            label2.Name = "label2";
            label2.Size = new Size(128, 41);
            label2.TabIndex = 3;
            label2.Text = "Lexical ";
            // 
            // listBox2
            // 
            listBox2.FormattingEnabled = true;
            listBox2.Location = new Point(385, 273);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(403, 164);
            listBox2.TabIndex = 4;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightCyan;
            ClientSize = new Size(800, 450);
            Controls.Add(listBox2);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(listBox1);
            Controls.Add(textBox1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private ListBox listBox1;
        private Label label1;
        private Label label2;
        private ListBox listBox2;
    }
}
