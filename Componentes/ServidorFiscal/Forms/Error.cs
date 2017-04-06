using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

namespace ServidorFiscal
{
	public class FormError : Lui.Forms.DialogForm
	{

		#region Código generado por el Diseñador de Windows Forms

		public FormError()
			: base()
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

		// NOTA: el Diseñador de Windows Forms requiere el siguiente procedimiento
		// Puede modificarse utilizando el Diseñador de Windows Forms. 
		// No lo modifique con el editor de código.
		internal Lui.Forms.Label Label1;
		internal Lui.Forms.Label Label2;
		internal Lui.Forms.Label Label3;
		internal Lui.Forms.Label Label5;
		internal Lui.Forms.Label Label6;
		internal Lui.Forms.Label EtiquetaError;
		internal Lui.Forms.Label EtiquetaLugar;
		internal Lui.Forms.Label EtiquetaMensaje;
		internal Lui.Forms.Label EtiquetaEstadoImpresora;
		internal Lui.Forms.Label EtiquetaEstadoFiscal;
		internal Lui.Forms.Label Label8;
		internal Lui.Forms.Label EtiquetaCampos;
		internal Lui.Forms.Label EtiquetaComando;
		internal Lui.Forms.Label Label4;
		private PictureBox pictureBox1;
		internal Lui.Forms.Label DialogCaption;
                internal Lui.Forms.Label label9;
		internal Lui.Forms.Label Label7;

		private void InitializeComponent()
		{
                        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormError));
                        this.Label1 = new Lui.Forms.Label();
                        this.Label2 = new Lui.Forms.Label();
                        this.Label3 = new Lui.Forms.Label();
                        this.Label5 = new Lui.Forms.Label();
                        this.Label6 = new Lui.Forms.Label();
                        this.EtiquetaError = new Lui.Forms.Label();
                        this.EtiquetaLugar = new Lui.Forms.Label();
                        this.EtiquetaMensaje = new Lui.Forms.Label();
                        this.EtiquetaEstadoImpresora = new Lui.Forms.Label();
                        this.EtiquetaEstadoFiscal = new Lui.Forms.Label();
                        this.EtiquetaCampos = new Lui.Forms.Label();
                        this.Label8 = new Lui.Forms.Label();
                        this.EtiquetaComando = new Lui.Forms.Label();
                        this.Label4 = new Lui.Forms.Label();
                        this.Label7 = new Lui.Forms.Label();
                        this.pictureBox1 = new System.Windows.Forms.PictureBox();
                        this.DialogCaption = new Lui.Forms.Label();
                        this.label9 = new Lui.Forms.Label();
                        ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
                        this.SuspendLayout();
                        // 
                        // Label1
                        // 
                        this.Label1.Location = new System.Drawing.Point(104, 104);
                        this.Label1.Name = "Label1";
                        this.Label1.Size = new System.Drawing.Size(72, 20);
                        this.Label1.TabIndex = 51;
                        this.Label1.Text = "Error";
                        this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        this.Label1.UseMnemonic = false;
                        // 
                        // Label2
                        // 
                        this.Label2.Location = new System.Drawing.Point(104, 128);
                        this.Label2.Name = "Label2";
                        this.Label2.Size = new System.Drawing.Size(72, 20);
                        this.Label2.TabIndex = 52;
                        this.Label2.Text = "Lugar";
                        this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        this.Label2.UseMnemonic = false;
                        // 
                        // Label3
                        // 
                        this.Label3.Location = new System.Drawing.Point(104, 152);
                        this.Label3.Name = "Label3";
                        this.Label3.Size = new System.Drawing.Size(72, 20);
                        this.Label3.TabIndex = 53;
                        this.Label3.Text = "Mensaje";
                        this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        this.Label3.UseMnemonic = false;
                        // 
                        // Label5
                        // 
                        this.Label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                        this.Label5.Location = new System.Drawing.Point(203, 216);
                        this.Label5.Name = "Label5";
                        this.Label5.Size = new System.Drawing.Size(149, 24);
                        this.Label5.TabIndex = 55;
                        this.Label5.Text = "Estado Impresora";
                        this.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        this.Label5.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.GroupHeader2;
                        this.Label5.UseMnemonic = false;
                        // 
                        // Label6
                        // 
                        this.Label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                        this.Label6.Location = new System.Drawing.Point(388, 216);
                        this.Label6.Name = "Label6";
                        this.Label6.Size = new System.Drawing.Size(124, 24);
                        this.Label6.TabIndex = 56;
                        this.Label6.Text = "Estado Fiscal";
                        this.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        this.Label6.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.GroupHeader2;
                        this.Label6.UseMnemonic = false;
                        // 
                        // EtiquetaError
                        // 
                        this.EtiquetaError.Location = new System.Drawing.Point(176, 104);
                        this.EtiquetaError.Name = "EtiquetaError";
                        this.EtiquetaError.Size = new System.Drawing.Size(180, 20);
                        this.EtiquetaError.TabIndex = 57;
                        this.EtiquetaError.Text = ".";
                        // 
                        // EtiquetaLugar
                        // 
                        this.EtiquetaLugar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EtiquetaLugar.Location = new System.Drawing.Point(176, 128);
                        this.EtiquetaLugar.Name = "EtiquetaLugar";
                        this.EtiquetaLugar.Size = new System.Drawing.Size(432, 20);
                        this.EtiquetaLugar.TabIndex = 58;
                        this.EtiquetaLugar.Text = ".";
                        // 
                        // EtiquetaMensaje
                        // 
                        this.EtiquetaMensaje.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EtiquetaMensaje.Location = new System.Drawing.Point(176, 152);
                        this.EtiquetaMensaje.Name = "EtiquetaMensaje";
                        this.EtiquetaMensaje.Size = new System.Drawing.Size(432, 56);
                        this.EtiquetaMensaje.TabIndex = 59;
                        this.EtiquetaMensaje.Text = ".";
                        // 
                        // EtiquetaEstadoImpresora
                        // 
                        this.EtiquetaEstadoImpresora.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                        this.EtiquetaEstadoImpresora.Location = new System.Drawing.Point(203, 240);
                        this.EtiquetaEstadoImpresora.Name = "EtiquetaEstadoImpresora";
                        this.EtiquetaEstadoImpresora.Size = new System.Drawing.Size(178, 97);
                        this.EtiquetaEstadoImpresora.TabIndex = 61;
                        this.EtiquetaEstadoImpresora.Text = ".";
                        this.EtiquetaEstadoImpresora.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.Small;
                        // 
                        // EtiquetaEstadoFiscal
                        // 
                        this.EtiquetaEstadoFiscal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EtiquetaEstadoFiscal.Location = new System.Drawing.Point(388, 240);
                        this.EtiquetaEstadoFiscal.Name = "EtiquetaEstadoFiscal";
                        this.EtiquetaEstadoFiscal.Size = new System.Drawing.Size(220, 97);
                        this.EtiquetaEstadoFiscal.TabIndex = 62;
                        this.EtiquetaEstadoFiscal.Text = ".";
                        this.EtiquetaEstadoFiscal.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.Small;
                        // 
                        // EtiquetaCampos
                        // 
                        this.EtiquetaCampos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                        this.EtiquetaCampos.Location = new System.Drawing.Point(104, 240);
                        this.EtiquetaCampos.Name = "EtiquetaCampos";
                        this.EtiquetaCampos.Size = new System.Drawing.Size(92, 97);
                        this.EtiquetaCampos.TabIndex = 64;
                        this.EtiquetaCampos.Text = ".";
                        this.EtiquetaCampos.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.Small;
                        // 
                        // Label8
                        // 
                        this.Label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                        this.Label8.Location = new System.Drawing.Point(104, 216);
                        this.Label8.Name = "Label8";
                        this.Label8.Size = new System.Drawing.Size(96, 24);
                        this.Label8.TabIndex = 63;
                        this.Label8.Text = "Campos";
                        this.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        this.Label8.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.GroupHeader2;
                        this.Label8.UseMnemonic = false;
                        // 
                        // EtiquetaComando
                        // 
                        this.EtiquetaComando.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EtiquetaComando.Location = new System.Drawing.Point(432, 104);
                        this.EtiquetaComando.Name = "EtiquetaComando";
                        this.EtiquetaComando.Size = new System.Drawing.Size(176, 20);
                        this.EtiquetaComando.TabIndex = 66;
                        this.EtiquetaComando.Text = ".";
                        // 
                        // Label4
                        // 
                        this.Label4.Location = new System.Drawing.Point(363, 104);
                        this.Label4.Name = "Label4";
                        this.Label4.Size = new System.Drawing.Size(69, 20);
                        this.Label4.TabIndex = 65;
                        this.Label4.Text = "Comando";
                        this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        this.Label4.UseMnemonic = false;
                        // 
                        // Label7
                        // 
                        this.Label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.Label7.Location = new System.Drawing.Point(104, 343);
                        this.Label7.Name = "Label7";
                        this.Label7.Size = new System.Drawing.Size(504, 24);
                        this.Label7.TabIndex = 67;
                        this.Label7.Text = "Se va a anular el comprobante que se estaba imprimiendo.";
                        this.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        this.Label7.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.Warning;
                        // 
                        // pictureBox1
                        // 
                        this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
                        this.pictureBox1.Location = new System.Drawing.Point(24, 24);
                        this.pictureBox1.Name = "pictureBox1";
                        this.pictureBox1.Size = new System.Drawing.Size(64, 64);
                        this.pictureBox1.TabIndex = 68;
                        this.pictureBox1.TabStop = false;
                        // 
                        // DialogCaption
                        // 
                        this.DialogCaption.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.DialogCaption.Location = new System.Drawing.Point(104, 24);
                        this.DialogCaption.Name = "DialogCaption";
                        this.DialogCaption.Size = new System.Drawing.Size(504, 32);
                        this.DialogCaption.TabIndex = 69;
                        this.DialogCaption.Text = "Error de impresora fiscal";
                        this.DialogCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        this.DialogCaption.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.MainHeader;
                        // 
                        // label9
                        // 
                        this.label9.Location = new System.Drawing.Point(104, 56);
                        this.label9.Name = "label9";
                        this.label9.Size = new System.Drawing.Size(504, 32);
                        this.label9.TabIndex = 70;
                        this.label9.Text = "Lázaro encontró un error mientras se comunicaba con la impresora fiscal.";
                        this.label9.UseMnemonic = false;
                        // 
                        // FormError
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
                        this.ClientSize = new System.Drawing.Size(634, 451);
                        this.Controls.Add(this.label9);
                        this.Controls.Add(this.DialogCaption);
                        this.Controls.Add(this.Label7);
                        this.Controls.Add(this.EtiquetaComando);
                        this.Controls.Add(this.Label4);
                        this.Controls.Add(this.EtiquetaCampos);
                        this.Controls.Add(this.Label8);
                        this.Controls.Add(this.EtiquetaEstadoFiscal);
                        this.Controls.Add(this.EtiquetaEstadoImpresora);
                        this.Controls.Add(this.EtiquetaMensaje);
                        this.Controls.Add(this.EtiquetaLugar);
                        this.Controls.Add(this.EtiquetaError);
                        this.Controls.Add(this.Label6);
                        this.Controls.Add(this.Label5);
                        this.Controls.Add(this.Label3);
                        this.Controls.Add(this.Label2);
                        this.Controls.Add(this.Label1);
                        this.Controls.Add(this.pictureBox1);
                        this.ForeColor = System.Drawing.Color.Black;
                        this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
                        this.Name = "FormError";
                        this.Text = "Error de impresora fiscal";
                        this.Controls.SetChildIndex(this.pictureBox1, 0);
                        this.Controls.SetChildIndex(this.Label1, 0);
                        this.Controls.SetChildIndex(this.Label2, 0);
                        this.Controls.SetChildIndex(this.Label3, 0);
                        this.Controls.SetChildIndex(this.Label5, 0);
                        this.Controls.SetChildIndex(this.Label6, 0);
                        this.Controls.SetChildIndex(this.EtiquetaError, 0);
                        this.Controls.SetChildIndex(this.EtiquetaLugar, 0);
                        this.Controls.SetChildIndex(this.EtiquetaMensaje, 0);
                        this.Controls.SetChildIndex(this.EtiquetaEstadoImpresora, 0);
                        this.Controls.SetChildIndex(this.EtiquetaEstadoFiscal, 0);
                        this.Controls.SetChildIndex(this.Label8, 0);
                        this.Controls.SetChildIndex(this.EtiquetaCampos, 0);
                        this.Controls.SetChildIndex(this.Label4, 0);
                        this.Controls.SetChildIndex(this.EtiquetaComando, 0);
                        this.Controls.SetChildIndex(this.Label7, 0);
                        this.Controls.SetChildIndex(this.DialogCaption, 0);
                        this.Controls.SetChildIndex(this.label9, 0);
                        ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
                        this.ResumeLayout(false);

		}


		#endregion

		internal void Mostrar(Lazaro.Base.Util.Impresion.Comprobantes.Fiscal.Respuesta Res)
		{
			switch (Res.Error)
			{
				case Lazaro.Base.Util.Impresion.Comprobantes.Fiscal.ErroresFiscales.Ok:
					EtiquetaError.Text = "OK???";
					break;
				case Lazaro.Base.Util.Impresion.Comprobantes.Fiscal.ErroresFiscales.ErrorBCC:
					EtiquetaError.Text = "BCC";
					break;
				case Lazaro.Base.Util.Impresion.Comprobantes.Fiscal.ErroresFiscales.Error:
					EtiquetaError.Text = "Error genérico";
					break;
				case Lazaro.Base.Util.Impresion.Comprobantes.Fiscal.ErroresFiscales.ErrorFiscal:
					EtiquetaError.Text = "Error fiscal";
					break;
				case Lazaro.Base.Util.Impresion.Comprobantes.Fiscal.ErroresFiscales.ErrorImpresora:
					EtiquetaError.Text = "Error impresora";
					break;
				case Lazaro.Base.Util.Impresion.Comprobantes.Fiscal.ErroresFiscales.NAK:
					EtiquetaError.Text = "NAK";
					break;
				case Lazaro.Base.Util.Impresion.Comprobantes.Fiscal.ErroresFiscales.TimeOut:
					EtiquetaError.Text = "Timeout";
					break;
			}

			EtiquetaLugar.Text = Res.Lugar;
			EtiquetaMensaje.Text = Res.Mensaje;
			EtiquetaComando.Text = Res.CodigoComando.ToString();
                        if (Res.Campos != null)
                                EtiquetaCampos.Text = string.Join(Environment.NewLine, Res.Campos.ToArray());
			EtiquetaEstadoImpresora.Text = Res.ExplicarEstadoImpresora();
			EtiquetaEstadoFiscal.Text = Res.ExplicarEstadoFiscal();
			CancelCommandButton.Visible = false;
		}
	}
}
