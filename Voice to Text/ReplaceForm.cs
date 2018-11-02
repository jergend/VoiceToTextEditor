using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Voice_to_Text
{
    public partial class ReplaceForm : Form
    {
        MainForm mf;
        Regex regex;
        Match match;

        bool isFirstFind = true;

        public ReplaceForm(MainForm form)
        {
            InitializeComponent();
            mf = form;
        }

        private void uxFindTextBox_TextChanged(object sender, EventArgs e)
        {
            if (uxFindTextBox.Text.Length != 0)
            {
                uxFindButton.Enabled = true;
                uxReplaceButton.Enabled = true;
                uxReplaceAllButton.Enabled = true;
            }
        }

        private void uxFindButton_Click(object sender, EventArgs e)
        {
            FindText();
        }

        private void uxReplaceButton_Click(object sender, EventArgs e)
        {
            Regex regexTemp = GetRegExpression();
            Match matchTemp = regexTemp.Match(mf.TextBox.Text);

            if(matchTemp.Success)
            {
                if(matchTemp.Value == mf.TextBox.SelectedText)
                {
                    mf.TextBox.SelectedText = uxReplaceTextBox.Text;
                }
            }

            FindText();
        }

        private void uxReplaceAllButton_Click(object sender, EventArgs e)
        {
            Regex replaceRegex = GetRegExpression();
            string replacedString;

            int selectedPos = mf.TextBox.SelectionStart;

            replacedString = replaceRegex.Replace(mf.TextBox.Text, uxReplaceTextBox.Text);

            if(mf.TextBox.Text != replacedString)
            {
                mf.TextBox.Text = replacedString;

                mf.TextBox.SelectionStart = selectedPos;
            }
            else
            {
                MessageBox.Show(String.Format("Cannot find \"" + uxFindTextBox.Text + "\""),
                    Application.ProductName, MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }

            mf.TextBox.Focus();
        }

        private void uxCancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private Regex GetRegExpression()
        {
            Regex result;
            string regExString = uxFindTextBox.Text;

            regExString = Regex.Escape(regExString);

            if(uxMatchCaseBox.Checked)
            {
                result = new Regex(regExString);
            }
            else
            {
                result = new Regex(regExString, RegexOptions.IgnoreCase);
            }

            return result;
        }

        private void FindText()
        {
            if (isFirstFind)
            {
                regex = GetRegExpression();
                match = regex.Match(mf.TextBox.Text);
                isFirstFind = false;
            }
            else
            {
                match = regex.Match(mf.TextBox.Text, match.Index + 1);
            }

            if (match.Success)
            {
                mf.TextBox.SelectionStart = match.Index;
                mf.TextBox.SelectionLength = match.Length;
                mf.TextBox.Focus();
            }
            else
            {
                MessageBox.Show(String.Format("Cannot find \"" + uxFindTextBox.Text + "\""),
                    Application.ProductName, MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                isFirstFind = true;
            }
        }
    }
}
