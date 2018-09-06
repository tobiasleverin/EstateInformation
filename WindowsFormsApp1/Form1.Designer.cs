namespace SequenceVerification
{
    partial class VerificationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.VerifyBtn = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.InputLbl = new System.Windows.Forms.Label();
            this.ResultLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(33, 46);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(262, 439);
            this.textBox1.TabIndex = 0;
            // 
            // VerifyBtn
            // 
            this.VerifyBtn.Location = new System.Drawing.Point(613, 515);
            this.VerifyBtn.Name = "VerifyBtn";
            this.VerifyBtn.Size = new System.Drawing.Size(75, 23);
            this.VerifyBtn.TabIndex = 1;
            this.VerifyBtn.Text = "Verifiera";
            this.VerifyBtn.UseVisualStyleBackColor = true;
            this.VerifyBtn.Click += new System.EventHandler(this.VerifyBtn_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(415, 46);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(273, 439);
            this.textBox2.TabIndex = 2;
            // 
            // InputLbl
            // 
            this.InputLbl.AutoSize = true;
            this.InputLbl.Location = new System.Drawing.Point(30, 30);
            this.InputLbl.Name = "InputLbl";
            this.InputLbl.Size = new System.Drawing.Size(31, 13);
            this.InputLbl.TabIndex = 3;
            this.InputLbl.Text = "Input";
            this.InputLbl.Click += new System.EventHandler(this.label1_Click);
            // 
            // ResultLbl
            // 
            this.ResultLbl.AutoSize = true;
            this.ResultLbl.Location = new System.Drawing.Point(412, 27);
            this.ResultLbl.Name = "ResultLbl";
            this.ResultLbl.Size = new System.Drawing.Size(37, 13);
            this.ResultLbl.TabIndex = 4;
            this.ResultLbl.Text = "Result";
            this.ResultLbl.Click += new System.EventHandler(this.label2_Click);
            // 
            // VerificationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 568);
            this.Controls.Add(this.ResultLbl);
            this.Controls.Add(this.InputLbl);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.VerifyBtn);
            this.Controls.Add(this.textBox1);
            this.Name = "VerificationForm";
            this.Text = "VerifcationForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button VerifyBtn;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label InputLbl;
        private System.Windows.Forms.Label ResultLbl;
    }
}

