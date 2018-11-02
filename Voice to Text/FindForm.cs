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
    public partial class FindForm : Form
    {
        MainForm mf;
        Regex regex;
        Match match;

        bool isFirstFind = true;

        public FindForm(MainForm form)
        {
            InitializeComponent();
            mf = form;
        }

        private void uxFindTextBox_TextChanged(object sender, EventArgs e)
        {
            if (uxFindTextBox.Text.Length != 0)
            {
                uxFindButton.Enabled = true;
            }
        }

        private void uxFindButton_Click(object sender, EventArgs e)
        {
            if(isFirstFind)
            {
                regex = GetRegExpression();
                match = regex.Match(mf.TextBox.Text);
                isFirstFind = false;
            }
            else
            {
                match = regex.Match(mf.TextBox.Text, match.Index + 1);
            }

            if(match.Success)
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
    }
}
