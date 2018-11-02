using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Voice_to_Text
{
    public class myComboBox : ComboBox
    {
        private string oldText;

        public myComboBox()
        {
            oldText = this.Text;
        }

        public void Copy()
        {
            if (this.SelectedText != string.Empty)
            {
                Clipboard.SetText(this.SelectedText);
            }
        }

        public void Cut()
        {
            if (this.SelectedText != string.Empty)
            {
                //set old text of combox, this value is need when undo
                this.oldText = this.Text;

                string copied = this.SelectedText;
                int sPos = this.SelectionStart;
                this.SelectedText = this.SelectedText.Replace(copied, "");
                this.SelectionStart = sPos;
                Clipboard.SetText(copied);
            }
        }

        public void Paste()
        {
            this.oldText = this.Text;
            string txtInClip = Clipboard.GetText();
            int sPos = this.SelectionStart;

            if (this.SelectedText != string.Empty)
            {
                this.SelectedText = this.SelectedText.Replace(this.SelectedText,
                    txtInClip);
            }
            else
            {
                this.Text = this.Text.Insert(this.SelectionStart, txtInClip);
                this.SelectionStart = sPos + txtInClip.Length;
            }
        }

        public void Undo()

        {
            if (this.oldText != string.Empty)
            {
                this.Text = this.oldText;
            }
        }
    }
}
