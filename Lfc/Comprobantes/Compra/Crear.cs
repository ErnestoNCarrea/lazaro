using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

namespace Lfc.Comprobantes.Compra
{
	public class Crear : Lui.Forms.DialogForm
	{
		public string TipoComprob = "FP";

		#region Código generado por el Diseñador de Windows Forms

		public Crear()
			:
		    base()
		{

			// Necesario para admitir el Diseñador de Windows Forms
			InitializeComponent();

			// agregar código de constructor después de llamar a InitializeComponent

		}

		// Limpiar los recursos que se estén utilizando.
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
			}

			base.Dispose(disposing);
		}

		// Requerido por el Diseñador de Windows Forms
		private System.ComponentModel.IContainer components = null;
		internal Lui.Forms.Button BotonPedido;
		internal Lui.Forms.Button BotonRequerimiento;
		internal Lui.Forms.Button BotonRemito;
                internal Lui.Forms.Button BotonNotaDeCredito;
		internal Lui.Forms.Button BotonFactura;

		private void InitializeComponent()
		{
                        this.BotonRemito = new Lui.Forms.Button();
                        this.BotonPedido = new Lui.Forms.Button();
                        this.BotonRequerimiento = new Lui.Forms.Button();
                        this.BotonFactura = new Lui.Forms.Button();
                        this.BotonNotaDeCredito = new Lui.Forms.Button();
                        this.SuspendLayout();
                        // 
                        // BotonRemito
                        // 
                        this.BotonRemito.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.BotonRemito.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.BotonRemito.ForeColor = System.Drawing.Color.Black;
                        this.BotonRemito.Image = null;
                        this.BotonRemito.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.BotonRemito.Location = new System.Drawing.Point(32, 160);
                        this.BotonRemito.Name = "BotonRemito";
                        this.BotonRemito.Size = new System.Drawing.Size(412, 52);
                        this.BotonRemito.SubLabelPos = Lui.Forms.SubLabelPositions.LongBottom;
                        this.BotonRemito.Subtext = "Para asentar un remito de proveedor.";
                        this.BotonRemito.TabIndex = 2;
                        this.BotonRemito.Text = "Remito";
                        this.BotonRemito.Click += new System.EventHandler(this.BotonArribo_Click);
                        // 
                        // BotonPedido
                        // 
                        this.BotonPedido.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.BotonPedido.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.BotonPedido.ForeColor = System.Drawing.Color.Black;
                        this.BotonPedido.Image = null;
                        this.BotonPedido.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.BotonPedido.Location = new System.Drawing.Point(32, 96);
                        this.BotonPedido.Name = "BotonPedido";
                        this.BotonPedido.Size = new System.Drawing.Size(412, 52);
                        this.BotonPedido.SubLabelPos = Lui.Forms.SubLabelPositions.LongBottom;
                        this.BotonPedido.Subtext = "Para asentar un pedido realizado.";
                        this.BotonPedido.TabIndex = 1;
                        this.BotonPedido.Text = "Pedido";
                        this.BotonPedido.Click += new System.EventHandler(this.BotonPedido_Click);
                        // 
                        // BotonRequerimiento
                        // 
                        this.BotonRequerimiento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.BotonRequerimiento.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.BotonRequerimiento.ForeColor = System.Drawing.Color.Black;
                        this.BotonRequerimiento.Image = null;
                        this.BotonRequerimiento.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.BotonRequerimiento.Location = new System.Drawing.Point(32, 32);
                        this.BotonRequerimiento.Name = "BotonRequerimiento";
                        this.BotonRequerimiento.Size = new System.Drawing.Size(412, 52);
                        this.BotonRequerimiento.SubLabelPos = Lui.Forms.SubLabelPositions.LongBottom;
                        this.BotonRequerimiento.Subtext = "Para solicitar internamente un pedido.";
                        this.BotonRequerimiento.TabIndex = 0;
                        this.BotonRequerimiento.Text = "Nota de Pedido";
                        this.BotonRequerimiento.Click += new System.EventHandler(this.BotonRequerimiento_Click);
                        // 
                        // BotonFactura
                        // 
                        this.BotonFactura.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.BotonFactura.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.BotonFactura.ForeColor = System.Drawing.Color.Black;
                        this.BotonFactura.Image = null;
                        this.BotonFactura.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.BotonFactura.Location = new System.Drawing.Point(32, 224);
                        this.BotonFactura.Name = "BotonFactura";
                        this.BotonFactura.Size = new System.Drawing.Size(412, 52);
                        this.BotonFactura.SubLabelPos = Lui.Forms.SubLabelPositions.LongBottom;
                        this.BotonFactura.Subtext = "Para asentar una factura de compra.";
                        this.BotonFactura.TabIndex = 3;
                        this.BotonFactura.Text = "Factura";
                        this.BotonFactura.Click += new System.EventHandler(this.BotonFactura_Click);
                        // 
                        // BotonNotaDeCredito
                        // 
                        this.BotonNotaDeCredito.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.BotonNotaDeCredito.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.BotonNotaDeCredito.ForeColor = System.Drawing.Color.Black;
                        this.BotonNotaDeCredito.Image = null;
                        this.BotonNotaDeCredito.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.BotonNotaDeCredito.Location = new System.Drawing.Point(32, 288);
                        this.BotonNotaDeCredito.Name = "BotonNotaDeCredito";
                        this.BotonNotaDeCredito.Size = new System.Drawing.Size(412, 52);
                        this.BotonNotaDeCredito.SubLabelPos = Lui.Forms.SubLabelPositions.LongBottom;
                        this.BotonNotaDeCredito.Subtext = "Para asentar una Nota de Crédito de proveedor.";
                        this.BotonNotaDeCredito.TabIndex = 4;
                        this.BotonNotaDeCredito.Text = "Nota de Crédito";
                        this.BotonNotaDeCredito.Click += new System.EventHandler(this.BotonNotaDeCredito_Click);
                        // 
                        // Crear
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
                        this.ClientSize = new System.Drawing.Size(474, 426);
                        this.Controls.Add(this.BotonNotaDeCredito);
                        this.Controls.Add(this.BotonRequerimiento);
                        this.Controls.Add(this.BotonPedido);
                        this.Controls.Add(this.BotonRemito);
                        this.Controls.Add(this.BotonFactura);
                        this.ForeColor = System.Drawing.Color.Black;
                        this.Name = "Crear";
                        this.Text = "Crear comprobante de compra";
                        this.Activated += new System.EventHandler(this.FormPedidosCrear_Activated);
                        this.Load += new System.EventHandler(this.Crear_Load);
                        this.Controls.SetChildIndex(this.BotonFactura, 0);
                        this.Controls.SetChildIndex(this.BotonRemito, 0);
                        this.Controls.SetChildIndex(this.BotonPedido, 0);
                        this.Controls.SetChildIndex(this.BotonRequerimiento, 0);
                        this.Controls.SetChildIndex(this.BotonNotaDeCredito, 0);
                        this.ResumeLayout(false);

		}

		#endregion

		private void BotonRequerimiento_Click(object sender, System.EventArgs e)
		{
			TipoComprob = "NP";
			this.DialogResult = DialogResult.OK;
			this.Hide();
		}

		private void BotonPedido_Click(object sender, System.EventArgs e)
		{
                        TipoComprob = "PD";
			this.DialogResult = DialogResult.OK;
			this.Hide();
		}

		private void BotonArribo_Click(System.Object sender, System.EventArgs e)
		{
                        TipoComprob = "PD";
			this.DialogResult = DialogResult.OK;
			this.Hide();
		}

		private void BotonFactura_Click(object sender, System.EventArgs e)
		{
                        TipoComprob = "FP";
			this.DialogResult = DialogResult.OK;
			this.Hide();
		}



                private void BotonNotaDeCredito_Click(object sender, EventArgs e)
                {
                        TipoComprob = "NCA";
                        this.DialogResult = DialogResult.OK;
                        this.Hide();
                }

		private void FormPedidosCrear_Activated(object sender, System.EventArgs e)
		{
			switch (TipoComprob)
			{
				case "NP":
					this.BotonRequerimiento.Focus();
					break;

				case "PD":
					this.BotonPedido.Focus();
					break;

				case "RP":
                                case "R":
					this.BotonRemito.Focus();
					break;

				case "FP":
                                case "A":
                                case "B":
                                case "C":
                                case "E":
                                case "M":
                                case "FA":
                                case "FB":
                                case "FC":
                                case "FE":
                                case "FM":
					this.BotonFactura.Focus();
					break;

                                case "NCA":
                                case "NCB":
                                case "NCC":
                                case "NCE":
                                case "NCM":
                                        this.BotonNotaDeCredito.Focus();
                                        break;
                        }
		}

		private void Crear_Load(object sender, EventArgs e)
		{
			OkButton.Visible = false;
		}
	}
}
