using System;
using System.Collections.Generic;
using System.Text;

namespace Lfc.Articulos.Marcas
{
        public partial class Editar
        {
                #region Código generado por el Diseñador de Windows Forms

                protected override void Dispose(bool disposing)
                {
                        if (disposing) {
                                if (components != null) {
                                        components.Dispose();
                                }
                        }

                        base.Dispose(disposing);
                }

                private System.ComponentModel.IContainer components = null;

                private void InitializeComponent()
                {
                        this.EntradaProveedor = new Lcc.Entrada.CodigoDetalle();
                        this.Label14 = new Lui.Forms.Label();
                        this.EntradaUrl = new Lui.Forms.TextBox();
                        this.Label12 = new Lui.Forms.Label();
                        this.EntradaNombre = new Lui.Forms.TextBox();
                        this.Label5 = new Lui.Forms.Label();
                        this.EntradaObs = new Lui.Forms.TextBox();
                        this.Label13 = new Lui.Forms.Label();
                        this.SuspendLayout();
                        // 
                        // EntradaProveedor
                        // 
                        this.EntradaProveedor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaProveedor.AutoTab = true;
                        this.EntradaProveedor.CanCreate = true;
                        this.EntradaProveedor.Filter = "(tipo&2)=2";
                        this.EntradaProveedor.Location = new System.Drawing.Point(88, 64);
                        this.EntradaProveedor.MaxLength = 200;
                        this.EntradaProveedor.Name = "EntradaProveedor";
                        this.EntradaProveedor.PlaceholderText = "Sin especificar";
                        this.EntradaProveedor.ReadOnly = false;
                        this.EntradaProveedor.Required = false;
                        this.EntradaProveedor.Size = new System.Drawing.Size(364, 24);
                        this.EntradaProveedor.TabIndex = 5;
                        this.EntradaProveedor.NombreTipo = "Lbl.Personas.Proveedor";
                        this.EntradaProveedor.Text = "0";
                        // 
                        // Label14
                        // 
                        this.Label14.Location = new System.Drawing.Point(0, 64);
                        this.Label14.Name = "Label14";
                        this.Label14.Size = new System.Drawing.Size(88, 24);
                        this.Label14.TabIndex = 4;
                        this.Label14.Text = "Proveedor";
                        this.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaUrl
                        // 
                        this.EntradaUrl.Location = new System.Drawing.Point(88, 32);
                        this.EntradaUrl.MaxLength = 200;
                        this.EntradaUrl.Name = "EntradaUrl";
                        this.EntradaUrl.PlaceholderText = "Dirección de la página web de la marca";
                        this.EntradaUrl.ReadOnly = false;
                        this.EntradaUrl.Size = new System.Drawing.Size(444, 24);
                        this.EntradaUrl.TabIndex = 3;
                        // 
                        // Label12
                        // 
                        this.Label12.Location = new System.Drawing.Point(0, 32);
                        this.Label12.Name = "Label12";
                        this.Label12.Size = new System.Drawing.Size(88, 24);
                        this.Label12.TabIndex = 2;
                        this.Label12.Text = "URL";
                        this.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaNombre
                        // 
                        this.EntradaNombre.ForceCase = Lui.Forms.TextCasing.Automatic;
                        this.EntradaNombre.Location = new System.Drawing.Point(88, 0);
                        this.EntradaNombre.MaxLength = 200;
                        this.EntradaNombre.Name = "EntradaNombre";
                        this.EntradaNombre.ReadOnly = false;
                        this.EntradaNombre.Size = new System.Drawing.Size(444, 24);
                        this.EntradaNombre.TabIndex = 1;
                        // 
                        // Label5
                        // 
                        this.Label5.Location = new System.Drawing.Point(0, 0);
                        this.Label5.Name = "Label5";
                        this.Label5.Size = new System.Drawing.Size(88, 24);
                        this.Label5.TabIndex = 0;
                        this.Label5.Text = "Nombre";
                        this.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaObs
                        // 
                        this.EntradaObs.ForceCase = Lui.Forms.TextCasing.Automatic;
                        this.EntradaObs.Location = new System.Drawing.Point(88, 96);
                        this.EntradaObs.MultiLine = true;
                        this.EntradaObs.Name = "EntradaObs";
                        this.EntradaObs.ReadOnly = false;
                        this.EntradaObs.Size = new System.Drawing.Size(444, 112);
                        this.EntradaObs.TabIndex = 7;
                        // 
                        // Label13
                        // 
                        this.Label13.Location = new System.Drawing.Point(0, 96);
                        this.Label13.Name = "Label13";
                        this.Label13.Size = new System.Drawing.Size(88, 24);
                        this.Label13.TabIndex = 6;
                        this.Label13.Text = "Observaciones";
                        this.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // Editar
                        // 
                        this.Controls.Add(this.EntradaObs);
                        this.Controls.Add(this.Label13);
                        this.Controls.Add(this.EntradaProveedor);
                        this.Controls.Add(this.Label14);
                        this.Controls.Add(this.EntradaUrl);
                        this.Controls.Add(this.Label12);
                        this.Controls.Add(this.EntradaNombre);
                        this.Controls.Add(this.Label5);
                        this.Name = "Editar";
                        this.Size = new System.Drawing.Size(556, 297);
                        this.ResumeLayout(false);

                }

                #endregion

                internal Lcc.Entrada.CodigoDetalle EntradaProveedor;
                internal Lui.Forms.Label Label14;
                internal Lui.Forms.TextBox EntradaUrl;
                internal Lui.Forms.Label Label12;
                internal Lui.Forms.TextBox EntradaNombre;
                internal Lui.Forms.Label Label5;
                internal Lui.Forms.TextBox EntradaObs;
                internal Lui.Forms.Label Label13;
        }
}
