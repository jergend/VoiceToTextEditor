namespace Voice_to_Text
{
    partial class ReplaceForm
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
            this.uxFindTextBox = new System.Windows.Forms.TextBox();
            this.uxFindButton = new System.Windows.Forms.Button();
            this.uxCancelButton = new System.Windows.Forms.Button();
            this.uxMatchCaseBox = new System.Windows.Forms.CheckBox();
            this.uxReplaceButton = new System.Windows.Forms.Button();
            this.uxReplaceAllButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.uxReplaceTextBox = new System.Windows.Forms.TextBox();
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
            // uxFindTextBox
            // 
            this.uxFindTextBox.Location = new System.Drawing.Point(81, 21);
            this.uxFindTextBox.Name = "uxFindTextBox";
            this.uxFindTextBox.Size = new System.Drawing.Size(175, 20);
            this.uxFindTextBox.TabIndex = 1;
            this.uxFindTextBox.TextChanged += new System.EventHandler(this.uxFindTextBox_TextChanged);
            // 
            // uxFindButton
            // 
            this.uxFindButton.Location = new System.Drawing.Point(262, 18);
            this.uxFindButton.Name = "uxFindButton";
            this.uxFindButton.Size = new System.Drawing.Size(75, 23);
            this.uxFindButton.TabIndex = 2;
            this.uxFindButton.Text = "Find Next";
            this.uxFindButton.UseVisualStyleBackColor = true;
            this.uxFindButton.Click += new System.EventHandler(this.uxFindButton_Click);
            // 
            // uxCancelButton
            // 
            this.uxCancelButton.Location = new System.Drawing.Point(262, 105);
            this.uxCancelButton.Name = "uxCancelButton";
            this.uxCancelButton.Size = new System.Drawing.Size(75, 23);
            this.uxCancelButton.TabIndex = 6;
            this.uxCancelButton.Text = "Cancel";
            this.uxCancelButton.UseVisualStyleBackColor = true;
            this.uxCancelButton.Click += new System.EventHandler(this.uxCancelButton_Click);
            // 
            // uxMatchCaseBox
            // 
            this.uxMatchCaseBox.AutoSize = true;
            this.uxMatchCaseBox.Location = new System.Drawing.Point(6, 121);
            this.uxMatchCaseBox.Name = "uxMatchCaseBox";
            this.uxMatchCaseBox.Size = new System.Drawing.Size(82, 17);
            this.uxMatchCaseBox.TabIndex = 7;
            this.uxMatchCaseBox.Text = "Match case";
            this.uxMatchCaseBox.UseVisualStyleBackColor = true;
            // 
            // uxReplaceButton
            // 
            this.uxReplaceButton.Enabled = false;
            this.uxReplaceButton.Location = new System.Drawing.Point(262, 47);
            this.uxReplaceButton.Name = "uxReplaceButton";
            this.uxReplaceButton.Size = new System.Drawing.Size(75, 23);
            this.uxReplaceButton.TabIndex = 4;
            this.uxReplaceButton.Text = "Replace";
            this.uxReplaceButton.UseVisualStyleBackColor = true;
            this.uxReplaceButton.Click += new System.EventHandler(this.uxReplaceButton_Click);
            // 
            // uxReplaceAllButton
            // 
            this.uxReplaceAllButton.Enabled = false;
            this.uxReplaceAllButton.Location = new System.Drawing.Point(262, 76);
            this.uxReplaceAllButton.Name = "uxReplaceAllButton";
            this.uxReplaceAllButton.Size = new System.Drawing.Size(75, 23);
            this.uxReplaceAllButton.TabIndex = 5;
            this.uxReplaceAllButton.Text = "Replace All";
            this.uxReplaceAllButton.UseVisualStyleBackColor = true;
            this.uxReplaceAllButton.Click += new System.EventHandler(this.uxReplaceAllButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Replace with:";
            // 
            // uxReplaceTextBox
            // 
            this.uxReplaceTextBox.Location = new System.Drawing.Point(81, 47);
            this.uxReplaceTextBox.Name = "uxReplaceTextBox";
            this.uxReplaceTextBox.Size = new System.Drawing.Size(175, 20);
            this.uxReplaceTextBox.TabIndex = 3;
            // 
            // ReplaceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 169);
            this.Controls.Add(this.uxReplaceTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.uxReplaceAllButton);
            this.Controls.Add(this.uxReplaceButton);
            this.Controls.Add(this.uxMatchCaseBox);
            this.Controls.Add(this.uxCancelButton);
            this.Controls.Add(this.uxFindButton);
            this.Controls.Add(this.uxFindTextBox);
            this.Controls.Add(this.label1);
            this.Name = "ReplaceForm";
            this.Text = "Replace";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox uxFindTextBox;
        private System.Windows.Forms.Button uxFindButton;
        private System.Windows.Forms.Button uxCancelButton;
        private System.Windows.Forms.CheckBox uxMatchCaseBox;
        private System.Windows.Forms.Button uxReplaceButton;
        private System.Windows.Forms.Button uxReplaceAllButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox uxReplaceTextBox;
    }
}