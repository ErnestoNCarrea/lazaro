using System;
using System.ComponentModel;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Lui.Forms
{
        public class LinkLabel : System.Windows.Forms.LinkLabel
        {
                public LinkLabel()
                {
                        base.Font = Lazaro.Pres.DisplayStyles.Template.Current.DefaultFont;
                        this.Cursor = Cursors.Hand;
                        this.TextAlign = ContentAlignment.MiddleCenter;
                        this.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
                        base.LinkColor = Color.RoyalBlue;
                        base.ActiveLinkColor = base.LinkColor;
                        base.BackColor = Color.Transparent;
                }


                protected override void OnEnter(EventArgs e)
                {
                        base.LinkColor = Color.White;
                        base.ActiveLinkColor = base.LinkColor;
                        base.BackColor = Color.RoyalBlue;
                        base.OnEnter(e);
                }


                protected override void OnLeave(EventArgs e)
                {
                        base.LinkColor = Color.RoyalBlue;
                        base.ActiveLinkColor = base.LinkColor;
                        base.BackColor = Color.Transparent;
                        base.OnLeave(e);
                }


                protected override bool IsInputKey(Keys keyData)
                {
                        switch (keyData) {
                                case Keys.Up:
                                case Keys.Down:
                                case Keys.Left:
                                case Keys.Right:
                                        return true;
                                default:
                                        return base.IsInputKey(keyData);
                        }
                }


                protected override void OnKeyDown(System.Windows.Forms.KeyEventArgs e)
                {
                        if (e.Alt == false && e.Shift == false && e.Control == false) {
                                switch (e.KeyCode) {
                                        case Keys.Up:
                                        case Keys.Left:
                                                e.Handled = true;
                                                System.Windows.Forms.SendKeys.Send("+{tab}");
                                                break;
                                        case Keys.Down:
                                        case Keys.Right:
                                                e.Handled = true;
                                                System.Windows.Forms.SendKeys.Send("{tab}");
                                                break;
                                }
                        }
                        base.OnKeyDown(e);
                }


                [EditorBrowsable(EditorBrowsableState.Never),
                        System.ComponentModel.Browsable(false),
                        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
                new public Font Font
                {
                        get
                        {
                                return base.Font;
                        }
                }


                [EditorBrowsable(EditorBrowsableState.Never),
                        System.ComponentModel.Browsable(false),
                        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
                new public Color BackColor
                {
                        get
                        {
                                return base.BackColor;
                        }
                }

                [EditorBrowsable(EditorBrowsableState.Never),
                        System.ComponentModel.Browsable(false),
                        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
                new public Color LinkColor
                {
                        get
                        {
                                return base.LinkColor;
                        }
                }
        }
}
