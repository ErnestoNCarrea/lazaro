using System.Drawing;
using System.Windows.Forms;

namespace Lui.Forms
{
        public enum DialogButtons
        {
                YesNo = 0,
                AcceptCancel = 1
        }


        public partial class YesNoDialog : DialogForm
        {
                protected internal DialogButtons m_DialogButtons = DialogButtons.YesNo;


                public YesNoDialog(string messageText, string messageCaption)
                {
                        this.DisplayStyle = Lazaro.Pres.DisplayStyles.Template.Current.White;
                        InitializeComponent();
                        this.MessageCaption = messageCaption;
                        this.MessageText = messageText;
                }


                public DialogButtons DialogButtons
                {
                        get
                        {
                                return m_DialogButtons;
                        }
                        set
                        {
                                m_DialogButtons = value;

                                switch (m_DialogButtons) {
                                        case DialogButtons.YesNo:
                                                OkButton.Text = "Sí";
                                                CancelCommandButton.Text = "No";
                                                CancelCommandButton.Visible = true;
                                                break;

                                        case DialogButtons.AcceptCancel:
                                                OkButton.Text = "Aceptar";
                                                CancelCommandButton.Text = "Cancelar";
                                                CancelCommandButton.Visible = true;
                                                break;
                                }
                        }
                }


                public string MessageCaption
                {
                        get
                        {
                                return DialogCaption.Text;
                        }
                        set
                        {
                                DialogCaption.Text = value;
                                if (value.Length > 30)
                                        this.Text = "Pregunta";
                                else
                                        this.Text = value;
                        }
                }


                public string MessageText
                {
                        get
                        {
                                return DialogText.Text;
                        }
                        set
                        {
                                DialogText.Text = value;
                        }
                }


                private void YesNoDialogForm_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
                {
                        if (e.Control == true && e.Alt == false && e.Shift == false && e.KeyCode == Keys.C) {
                                try {
                                        Clipboard.SetDataObject(DialogText.Text);
                                } catch {
                                        // Error de portapapeles
                                }
                        }
                }


                protected override void OnResize(System.EventArgs e)
                {
                        base.OnResize(e);
                        if (this.Created) {
                                this.DialogText.MaximumSize = new Size(DialogCaption.Right - DialogText.Left, 0);
                                this.DialogText.AutoSize = true;
                                this.Height = this.DialogText.Bottom + this.LowerPanel.Height + 32 + (this.Height - this.ClientRectangle.Height);
                        }
                }


                protected override void OnLoad(System.EventArgs e)
                {
                        base.OnLoad(e);
                        this.Size = new Size(480, 320);
                        this.CenterToParent();
                }
        }
}