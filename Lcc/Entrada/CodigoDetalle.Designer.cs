using System;
using System.Collections.Generic;
using System.Text;

namespace Lcc.Entrada
{
        public partial class CodigoDetalle
        {
                #region Código generado por el Diseñador de Windows Forms

                // Limpiar los recursos que se estén utilizando.
                protected override void Dispose(bool disposing)
                {
                        if (disposing) {
                                if (components != null) {
                                        components.Dispose();
                                }
                        }
                        base.Dispose(disposing);
                }


                // Requerido por el Diseñador de Windows Forms
                private System.ComponentModel.IContainer components = null;

                private void InitializeComponent()
                {
                        this.components = new System.ComponentModel.Container();
                        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CodigoDetalle));
                        this.EntradaCodigo = new System.Windows.Forms.TextBox();
                        this.MiContextMenu = new System.Windows.Forms.ContextMenu();
                        this.MenuItemBuscadorRapido = new System.Windows.Forms.MenuItem();
                        this.MenuItem2 = new System.Windows.Forms.MenuItem();
                        this.MenuItemCopiarCodigo = new System.Windows.Forms.MenuItem();
                        this.MenuItemCopiarNombre = new System.Windows.Forms.MenuItem();
                        this.MenuItem3 = new System.Windows.Forms.MenuItem();
                        this.MenuItemPegar = new System.Windows.Forms.MenuItem();
                        this.MenuItem5 = new System.Windows.Forms.MenuItem();
                        this.MenuItemEditar = new System.Windows.Forms.MenuItem();
                        this.Label1 = new System.Windows.Forms.Label();
                        this.EntradaFreeText = new System.Windows.Forms.TextBox();
                        this.TimerActualizar = new System.Windows.Forms.Timer(this.components);
                        this.BotonBuscar = new System.Windows.Forms.PictureBox();
                        ((System.ComponentModel.ISupportInitialize)(this.BotonBuscar)).BeginInit();
                        this.SuspendLayout();
                        // 
                        // EntradaCodigo
                        // 
                        this.EntradaCodigo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
                        this.EntradaCodigo.BorderStyle = System.Windows.Forms.BorderStyle.None;
                        this.EntradaCodigo.ContextMenu = this.MiContextMenu;
                        this.EntradaCodigo.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
                        this.EntradaCodigo.Location = new System.Drawing.Point(4, 4);
                        this.EntradaCodigo.MaxLength = 32;
                        this.EntradaCodigo.Name = "EntradaCodigo";
                        this.EntradaCodigo.Size = new System.Drawing.Size(52, 18);
                        this.EntradaCodigo.TabIndex = 0;
                        this.EntradaCodigo.TextChanged += new System.EventHandler(this.EntradaCodigo_TextChanged);
                        this.EntradaCodigo.DoubleClick += new System.EventHandler(this.TextBox1_DoubleClick);
                        this.EntradaCodigo.GotFocus += new System.EventHandler(this.TextBox1_GotFocus);
                        this.EntradaCodigo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox1_KeyDown);
                        this.EntradaCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox1_KeyPress);
                        this.EntradaCodigo.LostFocus += new System.EventHandler(this.TextBox1_LostFocus);
                        // 
                        // MiContextMenu
                        // 
                        this.MiContextMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MenuItemBuscadorRapido,
            this.MenuItem2,
            this.MenuItemCopiarCodigo,
            this.MenuItemCopiarNombre,
            this.MenuItem3,
            this.MenuItemPegar,
            this.MenuItem5,
            this.MenuItemEditar});
                        this.MiContextMenu.Popup += new System.EventHandler(this.ContextMenu_Popup);
                        // 
                        // MenuItemBuscadorRapido
                        // 
                        this.MenuItemBuscadorRapido.DefaultItem = true;
                        this.MenuItemBuscadorRapido.Index = 0;
                        this.MenuItemBuscadorRapido.Text = "Seleccionar de una Lista";
                        this.MenuItemBuscadorRapido.Click += new System.EventHandler(this.MenuItemBuscadorRapido_Click);
                        // 
                        // MenuItem2
                        // 
                        this.MenuItem2.Index = 1;
                        this.MenuItem2.Text = "-";
                        // 
                        // MenuItemCopiarCodigo
                        // 
                        this.MenuItemCopiarCodigo.Index = 2;
                        this.MenuItemCopiarCodigo.Text = "Copiar el Código";
                        this.MenuItemCopiarCodigo.Click += new System.EventHandler(this.MenuItemCopiarCodigo_Click);
                        // 
                        // MenuItemCopiarNombre
                        // 
                        this.MenuItemCopiarNombre.Index = 3;
                        this.MenuItemCopiarNombre.Text = "Copiar el Nombre";
                        this.MenuItemCopiarNombre.Click += new System.EventHandler(this.MenuItemCopiarNombre_Click);
                        // 
                        // MenuItem3
                        // 
                        this.MenuItem3.Index = 4;
                        this.MenuItem3.Text = "-";
                        // 
                        // MenuItemPegar
                        // 
                        this.MenuItemPegar.Index = 5;
                        this.MenuItemPegar.Text = "Pegar";
                        this.MenuItemPegar.Click += new System.EventHandler(this.MenuItemPegar_Click);
                        // 
                        // MenuItem5
                        // 
                        this.MenuItem5.Index = 6;
                        this.MenuItem5.Text = "-";
                        // 
                        // MenuItemEditar
                        // 
                        this.MenuItemEditar.Index = 7;
                        this.MenuItemEditar.Text = "Editar";
                        this.MenuItemEditar.Click += new System.EventHandler(this.MenuItemEditar_Click);
                        // 
                        // Label1
                        // 
                        this.Label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.Label1.AutoEllipsis = true;
                        this.Label1.ContextMenu = this.MiContextMenu;
                        this.Label1.Location = new System.Drawing.Point(60, 4);
                        this.Label1.Margin = new System.Windows.Forms.Padding(3);
                        this.Label1.Name = "Label1";
                        this.Label1.Size = new System.Drawing.Size(466, 16);
                        this.Label1.TabIndex = 50;
                        this.Label1.UseMnemonic = false;
                        this.Label1.Click += new System.EventHandler(this.Label1_Click);
                        this.Label1.DoubleClick += new System.EventHandler(this.Label1_DoubleClick);
                        // 
                        // EntradaFreeText
                        // 
                        this.EntradaFreeText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaFreeText.BorderStyle = System.Windows.Forms.BorderStyle.None;
                        this.EntradaFreeText.ContextMenu = this.MiContextMenu;
                        this.EntradaFreeText.Location = new System.Drawing.Point(60, 4);
                        this.EntradaFreeText.MaxLength = 200;
                        this.EntradaFreeText.Name = "EntradaFreeText";
                        this.EntradaFreeText.Size = new System.Drawing.Size(466, 18);
                        this.EntradaFreeText.TabIndex = 1;
                        this.EntradaFreeText.Visible = false;
                        this.EntradaFreeText.WordWrap = false;
                        this.EntradaFreeText.TextChanged += new System.EventHandler(this.EntradaFreeText_TextChanged);
                        this.EntradaFreeText.GotFocus += new System.EventHandler(this.EntradaFreeText_GotFocus);
                        this.EntradaFreeText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EntradaFreeText_KeyDown);
                        this.EntradaFreeText.LostFocus += new System.EventHandler(this.EntradaFreeText_LostFocus);
                        // 
                        // TimerActualizar
                        // 
                        this.TimerActualizar.Interval = 200;
                        this.TimerActualizar.Tick += new System.EventHandler(this.TimerActualizar_Tick);
                        // 
                        // BotonBuscar
                        // 
                        this.BotonBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                        this.BotonBuscar.BackColor = System.Drawing.Color.White;
                        this.BotonBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
                        this.BotonBuscar.Image = ((System.Drawing.Image)(resources.GetObject("BotonBuscar.Image")));
                        this.BotonBuscar.Location = new System.Drawing.Point(509, 4);
                        this.BotonBuscar.Name = "BotonBuscar";
                        this.BotonBuscar.Size = new System.Drawing.Size(18, 18);
                        this.BotonBuscar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
                        this.BotonBuscar.TabIndex = 51;
                        this.BotonBuscar.TabStop = false;
                        this.BotonBuscar.Visible = false;
                        this.BotonBuscar.Click += new System.EventHandler(this.BotonBuscar_Click);
                        // 
                        // CodigoDetalle
                        // 
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
                        this.Controls.Add(this.BotonBuscar);
                        this.Controls.Add(this.EntradaCodigo);
                        this.Controls.Add(this.EntradaFreeText);
                        this.Controls.Add(this.Label1);
                        this.Name = "CodigoDetalle";
                        this.Size = new System.Drawing.Size(530, 24);
                        this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DetailBox_KeyPress);
                        ((System.ComponentModel.ISupportInitialize)(this.BotonBuscar)).EndInit();
                        this.ResumeLayout(false);
                        this.PerformLayout();

                }

                #endregion

                protected System.Windows.Forms.TextBox EntradaCodigo;
                protected System.Windows.Forms.Label Label1;
                protected System.Windows.Forms.TextBox EntradaFreeText;
                protected System.Windows.Forms.MenuItem MenuItemCopiarCodigo;
                protected System.Windows.Forms.MenuItem MenuItemCopiarNombre;
                protected System.Windows.Forms.MenuItem MenuItem3;
                protected System.Windows.Forms.MenuItem MenuItemPegar;
                protected System.Windows.Forms.MenuItem MenuItem5;
                protected System.Windows.Forms.MenuItem MenuItemEditar;
                protected System.Windows.Forms.MenuItem MenuItemBuscadorRapido;
                protected System.Windows.Forms.MenuItem MenuItem2;
                protected System.Windows.Forms.ContextMenu MiContextMenu;
                protected System.Windows.Forms.Timer TimerActualizar;
                private System.Windows.Forms.PictureBox BotonBuscar;
        }
}
