using System;
using System.Collections.Generic;
using System.Text;

namespace Lfc.Sucursales
{
        public partial class Editar
        {
		protected override void Dispose(bool disposing)
		{
			if(disposing) {
				if(components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		private System.ComponentModel.IContainer components = null;
		internal Lui.Forms.Label Label1;
		internal Lui.Forms.Label label2;
		internal Lui.Forms.Label label3;
		internal Lcc.Entrada.CodigoDetalle EntradaLocalidad;
		internal Lui.Forms.Label Label9;
                internal Lui.Forms.TextBox EntradaDireccion;
		internal Lcc.Entrada.CodigoDetalle EntradaSituacionOrigen;
		internal Lui.Forms.Label label4;
		internal Lui.Forms.Label label5;
		internal Lui.Forms.Label label6;
		internal Lcc.Entrada.CodigoDetalle EntradaCajaDiaria;
		internal Lcc.Entrada.CodigoDetalle EntradaCajaCheques;
		internal Lui.Forms.TextBox EntradaNombre;

                #region Windows Form Designer generated code
                
                private void InitializeComponent()
		{
                        this.Label1 = new Lui.Forms.Label();
                        this.EntradaNombre = new Lui.Forms.TextBox();
                        this.EntradaDireccion = new Lui.Forms.TextBox();
                        this.label2 = new Lui.Forms.Label();
                        this.label3 = new Lui.Forms.Label();
                        this.EntradaLocalidad = new Lcc.Entrada.CodigoDetalle();
                        this.Label9 = new Lui.Forms.Label();
                        this.EntradaSituacionOrigen = new Lcc.Entrada.CodigoDetalle();
                        this.label4 = new Lui.Forms.Label();
                        this.EntradaCajaDiaria = new Lcc.Entrada.CodigoDetalle();
                        this.label5 = new Lui.Forms.Label();
                        this.EntradaCajaCheques = new Lcc.Entrada.CodigoDetalle();
                        this.label6 = new Lui.Forms.Label();
                        this.EntradaTelefono = new Lcc.Entrada.MatrizTelefonos();
                        this.label7 = new Lui.Forms.Label();
                        this.EntradaNumero = new Lui.Forms.TextBox();
                        this.SuspendLayout();
                        // 
                        // Label1
                        // 
                        this.Label1.Location = new System.Drawing.Point(0, 32);
                        this.Label1.Margin = new System.Windows.Forms.Padding(0);
                        this.Label1.Name = "Label1";
                        this.Label1.Size = new System.Drawing.Size(96, 24);
                        this.Label1.TabIndex = 2;
                        this.Label1.Text = "Nombre";
                        this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaNombre
                        // 
                        this.EntradaNombre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaNombre.ForceCase = Lui.Forms.TextCasing.Automatic;
                        this.EntradaNombre.Location = new System.Drawing.Point(96, 32);
                        this.EntradaNombre.Name = "EntradaNombre";
                        this.EntradaNombre.Size = new System.Drawing.Size(544, 24);
                        this.EntradaNombre.TabIndex = 3;
                        // 
                        // EntradaDireccion
                        // 
                        this.EntradaDireccion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaDireccion.Location = new System.Drawing.Point(96, 64);
                        this.EntradaDireccion.Name = "EntradaDireccion";
                        this.EntradaDireccion.Size = new System.Drawing.Size(544, 24);
                        this.EntradaDireccion.TabIndex = 5;
                        // 
                        // label2
                        // 
                        this.label2.Location = new System.Drawing.Point(0, 64);
                        this.label2.Name = "label2";
                        this.label2.Size = new System.Drawing.Size(96, 24);
                        this.label2.TabIndex = 4;
                        this.label2.Text = "Dirección";
                        this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // label3
                        // 
                        this.label3.Location = new System.Drawing.Point(0, 128);
                        this.label3.Name = "label3";
                        this.label3.Size = new System.Drawing.Size(96, 24);
                        this.label3.TabIndex = 8;
                        this.label3.Text = "Teléfonos";
                        this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaLocalidad
                        // 
                        this.EntradaLocalidad.AutoTab = true;
                        this.EntradaLocalidad.CanCreate = true;
                        this.EntradaLocalidad.Filter = "id_provincia IS NOT NULL";
                        this.EntradaLocalidad.Location = new System.Drawing.Point(96, 96);
                        this.EntradaLocalidad.MaxLength = 200;
                        this.EntradaLocalidad.Name = "EntradaLocalidad";
                        this.EntradaLocalidad.NombreTipo = "Lbl.Entidades.Localidad";
                        this.EntradaLocalidad.Required = true;
                        this.EntradaLocalidad.Size = new System.Drawing.Size(280, 24);
                        this.EntradaLocalidad.TabIndex = 7;
                        this.EntradaLocalidad.Text = "0";
                        // 
                        // Label9
                        // 
                        this.Label9.Location = new System.Drawing.Point(0, 96);
                        this.Label9.Name = "Label9";
                        this.Label9.Size = new System.Drawing.Size(96, 24);
                        this.Label9.TabIndex = 6;
                        this.Label9.Text = "Localidad";
                        this.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaSituacionOrigen
                        // 
                        this.EntradaSituacionOrigen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaSituacionOrigen.AutoTab = true;
                        this.EntradaSituacionOrigen.CanCreate = true;
                        this.EntradaSituacionOrigen.Location = new System.Drawing.Point(148, 272);
                        this.EntradaSituacionOrigen.MaxLength = 200;
                        this.EntradaSituacionOrigen.Name = "EntradaSituacionOrigen";
                        this.EntradaSituacionOrigen.NombreTipo = "Lbl.Articulos.Situacion";
                        this.EntradaSituacionOrigen.Required = true;
                        this.EntradaSituacionOrigen.Size = new System.Drawing.Size(280, 24);
                        this.EntradaSituacionOrigen.TabIndex = 11;
                        this.EntradaSituacionOrigen.Text = "0";
                        // 
                        // label4
                        // 
                        this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                        this.label4.Location = new System.Drawing.Point(44, 272);
                        this.label4.Name = "label4";
                        this.label4.Size = new System.Drawing.Size(104, 24);
                        this.label4.TabIndex = 10;
                        this.label4.Text = "Depósito";
                        this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaCajaDiaria
                        // 
                        this.EntradaCajaDiaria.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaCajaDiaria.AutoTab = true;
                        this.EntradaCajaDiaria.CanCreate = true;
                        this.EntradaCajaDiaria.Filter = "estado=1";
                        this.EntradaCajaDiaria.Location = new System.Drawing.Point(148, 300);
                        this.EntradaCajaDiaria.MaxLength = 200;
                        this.EntradaCajaDiaria.Name = "EntradaCajaDiaria";
                        this.EntradaCajaDiaria.NombreTipo = "Lbl.Cajas.Caja";
                        this.EntradaCajaDiaria.Required = true;
                        this.EntradaCajaDiaria.Size = new System.Drawing.Size(280, 24);
                        this.EntradaCajaDiaria.TabIndex = 13;
                        this.EntradaCajaDiaria.Text = "0";
                        // 
                        // label5
                        // 
                        this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                        this.label5.Location = new System.Drawing.Point(44, 300);
                        this.label5.Name = "label5";
                        this.label5.Size = new System.Drawing.Size(104, 24);
                        this.label5.TabIndex = 12;
                        this.label5.Text = "Caja Efectivo";
                        this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaCajaCheques
                        // 
                        this.EntradaCajaCheques.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaCajaCheques.AutoTab = true;
                        this.EntradaCajaCheques.CanCreate = true;
                        this.EntradaCajaCheques.Filter = "estado=1";
                        this.EntradaCajaCheques.Location = new System.Drawing.Point(148, 328);
                        this.EntradaCajaCheques.MaxLength = 200;
                        this.EntradaCajaCheques.Name = "EntradaCajaCheques";
                        this.EntradaCajaCheques.NombreTipo = "Lbl.Cajas.Caja";
                        this.EntradaCajaCheques.Required = true;
                        this.EntradaCajaCheques.Size = new System.Drawing.Size(280, 24);
                        this.EntradaCajaCheques.TabIndex = 15;
                        this.EntradaCajaCheques.Text = "0";
                        // 
                        // label6
                        // 
                        this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                        this.label6.Location = new System.Drawing.Point(44, 328);
                        this.label6.Name = "label6";
                        this.label6.Size = new System.Drawing.Size(104, 24);
                        this.label6.TabIndex = 14;
                        this.label6.Text = "Caja Cheques";
                        this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaTelefono
                        // 
                        this.EntradaTelefono.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaTelefono.AutoScrollMargin = new System.Drawing.Size(4, 4);
                        this.EntradaTelefono.Location = new System.Drawing.Point(96, 128);
                        this.EntradaTelefono.Name = "EntradaTelefono";
                        this.EntradaTelefono.Size = new System.Drawing.Size(540, 136);
                        this.EntradaTelefono.TabIndex = 9;
                        // 
                        // label7
                        // 
                        this.label7.Location = new System.Drawing.Point(0, 0);
                        this.label7.Margin = new System.Windows.Forms.Padding(0);
                        this.label7.Name = "label7";
                        this.label7.Size = new System.Drawing.Size(96, 24);
                        this.label7.TabIndex = 0;
                        this.label7.Text = "Número";
                        this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaNumero
                        // 
                        this.EntradaNumero.DataType = Lui.Forms.DataTypes.Integer;
                        this.EntradaNumero.Location = new System.Drawing.Point(96, 0);
                        this.EntradaNumero.MaxLength = 4;
                        this.EntradaNumero.Name = "EntradaNumero";
                        this.EntradaNumero.Size = new System.Drawing.Size(80, 24);
                        this.EntradaNumero.TabIndex = 1;
                        this.EntradaNumero.Text = "0";
                        // 
                        // Editar
                        // 
                        this.Controls.Add(this.label7);
                        this.Controls.Add(this.EntradaNumero);
                        this.Controls.Add(this.Label1);
                        this.Controls.Add(this.EntradaCajaCheques);
                        this.Controls.Add(this.label6);
                        this.Controls.Add(this.EntradaCajaDiaria);
                        this.Controls.Add(this.label5);
                        this.Controls.Add(this.EntradaSituacionOrigen);
                        this.Controls.Add(this.label4);
                        this.Controls.Add(this.EntradaLocalidad);
                        this.Controls.Add(this.Label9);
                        this.Controls.Add(this.label3);
                        this.Controls.Add(this.EntradaDireccion);
                        this.Controls.Add(this.label2);
                        this.Controls.Add(this.EntradaNombre);
                        this.Controls.Add(this.EntradaTelefono);
                        this.Name = "Editar";
                        this.Size = new System.Drawing.Size(640, 424);
                        this.ResumeLayout(false);

		}

		#endregion

                private Lcc.Entrada.MatrizTelefonos EntradaTelefono;
                internal Lui.Forms.Label label7;
                internal Lui.Forms.TextBox EntradaNumero;

        }
}
