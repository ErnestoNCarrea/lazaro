using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

namespace Lui.Forms
{
	public partial class ChildForm : Lui.Forms.Form
	{
                public int Uid;
                private ToolStrip m_ParentToolStrip = null;
                private ToolStripButton m_MyToolStripButton = null;

		public ChildForm()
		{
			InitializeComponent();

                        this.Uid = new Random().Next();
		}

                protected override void Dispose(bool disposing)
                {
                        if (disposing) {
                                if (components != null) {
                                        components.Dispose();
                                }
                        }

                        if (m_MyToolStripButton != null) {
                                m_MyToolStripButton.Dispose();
                                m_MyToolStripButton = null;
                        }

                        base.Dispose(disposing);
                }


                protected ToolStripButton MyToolStripButton
                {
                        get
                        {
                                return m_MyToolStripButton;
                        }
                }


                private ToolStrip ParentToolStrip
                {
                        get
                        {
                                if (m_ParentToolStrip == null && this.MdiParent != null) {
                                        foreach (System.Windows.Forms.Control TmpCtl in this.MdiParent.Controls) {
                                                if (TmpCtl is System.Windows.Forms.ToolStrip && TmpCtl.Name == "BarraTareas")
                                                        m_ParentToolStrip = (ToolStrip)TmpCtl;
                                        }
                                }
                                return m_ParentToolStrip;
                        }
                }


                private void ChildForm_Load(object sender, System.EventArgs e)
                {
                        m_MyToolStripButton = new ToolStripButton(this.Text);
                        m_MyToolStripButton.Margin = new System.Windows.Forms.Padding(2);
                        m_MyToolStripButton.Tag = this.Uid;
                        m_MyToolStripButton.Checked = true;
                        if (m_MyToolStripButton.Image != null)
                                m_MyToolStripButton.Image.Dispose();
                        m_MyToolStripButton.Image = this.Icon.ToBitmap();
                        if (this.ParentToolStrip != null)
                                this.ParentToolStrip.Items.Add(m_MyToolStripButton);

                        if (this.MdiParent != null)
                                this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
                }


                protected override void OnActivated(EventArgs e)
                {
                        try {
                                if (this.ParentToolStrip != null && this.ParentToolStrip.Items != null) {
                                        foreach (System.Windows.Forms.ToolStripButton Btn in this.ParentToolStrip.Items) {
                                                Btn.Checked = ((int)Btn.Tag) == this.Uid;
                                        }
                                }
                        } catch {
                                // Nada
                        }
                        base.OnActivated(e);
                }


                protected override void OnTextChanged(System.EventArgs e)
		{
                        if (this.MyToolStripButton != null) {
                                this.MyToolStripButton.Text = this.Text;
                                this.MyToolStripButton.Image = this.Icon.ToBitmap();
                        }

                        base.OnTextChanged(e);
		}


                protected override void OnFormClosing(FormClosingEventArgs e)
                {
                        if (e.Cancel == false) {
                                if (this.ParentToolStrip != null && this.ParentToolStrip.Items != null && this.MyToolStripButton != null)
                                        this.ParentToolStrip.Items.Remove(this.MyToolStripButton);
                        }
                        base.OnFormClosing(e);
		}

                public override string StockImage
                {
                        get
                        {
                                return base.StockImage;
                        }
                        set
                        {
                                base.StockImage = value;
                                if (value != null && this.MyToolStripButton != null) {
                                        this.MyToolStripButton.Image = (Image)(global::Lui.Properties.Resources.ResourceManager.GetObject(value));
                                }
                        }
                }
	}
}
