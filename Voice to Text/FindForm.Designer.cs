namespace Voice_to_Text
{
    partial class FindForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.uxFindButton = new System.Windows.Forms.Button();
            this.uxCancelButton = new System.Windows.Forms.Button();
            this.uxMatchCaseBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Find what:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(80, 21);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(282, 20);
            this.textBox1.TabIndex = 1;
            // 
            // uxFindButton
            // 
            this.uxFindButton.Location = new System.Drawing.Point(382, 19);
            this.uxFindButton.Name = "uxFindButton";
            this.uxFindButton.Size = new System.Drawing.Size(75, 23);
            this.uxFindButton.TabIndex = 2;
            this.uxFindButton.Text = "Find Next";
            this.uxFindButton.UseVisualStyleBackColor = true;
            // 
            // uxCancelButton
            // 
            this.uxCancelButton.Location = new System.Drawing.Point(382, 48);
            this.uxCancelButton.Name = "uxCancelButton";
            this.uxCancelButton.Size = new System.Drawing.Size(75, 23);
            this.uxCancelButton.TabIndex = 3;
            this.uxCancelButton.Text = "Cancel";
            this.uxCancelButton.UseVisualStyleBackColor = true;
            // 
            // uxMatchCaseBox
            // 
            this.uxMatchCaseBox.AutoSize = true;
            this.uxMatchCaseBox.Location = new System.Drawing.Point(6, 86);
            this.uxMatchCaseBox.Name = "uxMatchCaseBox";
            this.uxMatchCaseBox.Size = new System.Drawing.Size(82, 17);
            this.uxMatchCaseBox.TabIndex = 4;
            this.uxMatchCaseBox.Text = "Match case";
            this.uxMatchCaseBox.UseVisualStyleBackColor = true;
            // 
            // FindForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 115);
            this.Controls.Add(this.uxMatchCaseBox);
            this.Controls.Add(this.uxCancelButton);
            this.Controls.Add(this.uxFindButton);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "FindForm";
            this.Text = "Find";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button uxFindButton;
        private System.Windows.Forms.Button uxCancelButton;
        private System.Windows.Forms.CheckBox uxMatchCaseBox;
    }
}