using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

namespace Lazaro.WinMain.Misc
{
	public class Calculadora : Lui.Forms.Form
	{

		#region Código generado por el Diseñador de Windows Forms

		public Calculadora()
			: base()
		{


			// Necesario para admitir el Diseñador de Windows Forms
			InitializeComponent();

			// agregar código de constructor después de llamar a InitializeComponent
			EntradaHistorial.BackColor = this.DisplayStyle.BackgroundColor;

		}

		// Limpiar los recursos que se estén utilizando.
		protected override void Dispose(bool disposing)
		{
			if(disposing) {
				if(components != null) {
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
		internal System.Windows.Forms.TextBox EntradaHistorial;
                internal Lui.Forms.TextBox EntradaFormula;
                internal Lui.Forms.Label EtiquetaResultado;

		private void InitializeComponent()
		{
                        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Calculadora));
                        this.EntradaHistorial = new System.Windows.Forms.TextBox();
                        this.EntradaFormula = new Lui.Forms.TextBox();
                        this.EtiquetaResultado = new Lui.Forms.Label();
                        this.SuspendLayout();
                        // 
                        // EntradaHistorial
                        // 
                        this.EntradaHistorial.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaHistorial.BorderStyle = System.Windows.Forms.BorderStyle.None;
                        this.EntradaHistorial.Font = new System.Drawing.Font("Bitstream Vera Sans Mono", 10F);
                        this.EntradaHistorial.Location = new System.Drawing.Point(24, 72);
                        this.EntradaHistorial.Multiline = true;
                        this.EntradaHistorial.Name = "EntradaHistorial";
                        this.EntradaHistorial.Size = new System.Drawing.Size(272, 240);
                        this.EntradaHistorial.TabIndex = 0;
                        this.EntradaHistorial.TabStop = false;
                        this.EntradaHistorial.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                        this.EntradaHistorial.WordWrap = false;
                        // 
                        // EntradaFormula
                        // 
                        this.EntradaFormula.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaFormula.AutoNav = false;
                        this.EntradaFormula.Location = new System.Drawing.Point(24, 320);
                        this.EntradaFormula.Name = "EntradaFormula";
                        this.EntradaFormula.Size = new System.Drawing.Size(272, 29);
                        this.EntradaFormula.TabIndex = 1;
                        this.EntradaFormula.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.Big;
                        this.EntradaFormula.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFormula_KeyDown);
                        // 
                        // EtiquetaResultado
                        // 
                        this.EtiquetaResultado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EtiquetaResultado.Location = new System.Drawing.Point(24, 24);
                        this.EtiquetaResultado.Name = "EtiquetaResultado";
                        this.EtiquetaResultado.Size = new System.Drawing.Size(272, 47);
                        this.EtiquetaResultado.TabIndex = 3;
                        this.EtiquetaResultado.Text = "0.00 ";
                        this.EtiquetaResultado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                        this.EtiquetaResultado.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.Bigger;
                        // 
                        // Calculadora
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
                        this.ClientSize = new System.Drawing.Size(319, 372);
                        this.Controls.Add(this.EtiquetaResultado);
                        this.Controls.Add(this.EntradaFormula);
                        this.Controls.Add(this.EntradaHistorial);
                        this.ForeColor = System.Drawing.SystemColors.ControlText;
                        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
                        this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
                        this.Name = "Calculadora";
                        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                        this.Text = "Calculadora";
                        this.TopMost = true;
                        this.Activated += new System.EventHandler(this.FormCalculadora_Enter);
                        this.Deactivate += new System.EventHandler(this.FormCalculadora_Leave);
                        this.Load += new System.EventHandler(this.FormCalculadora_Load);
                        this.Enter += new System.EventHandler(this.FormCalculadora_Enter);
                        this.Leave += new System.EventHandler(this.FormCalculadora_Leave);
                        this.ResumeLayout(false);
                        this.PerformLayout();

		}


		#endregion

		public void Imprimir(string Texto)
		{
			string Temp = EntradaHistorial.Text + Environment.NewLine + Texto;
			if(Temp.Length > 32000) {
				EntradaHistorial.Text = Temp.Substring(0, 32000);
			} else {
				EntradaHistorial.Text = Temp;
			}
			EntradaHistorial.SelectionStart = EntradaHistorial.Text.Length;
			EntradaHistorial.SelectionLength = 0;
			EntradaHistorial.ScrollToCaret();
		}


		private void txtFormula_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			switch(e.KeyCode) {
				case Keys.Return:
					e.Handled = true;
					Calcular();
					break;
				case Keys.V:
					if(e.Control == true) {
						e.Handled = true;
						Calcular();
                                                try {
                                                        Clipboard.SetDataObject(EntradaFormula.Text);
                                                } catch {
                                                        // Error de portapapeles
                                                }
						this.Hide();
						System.Windows.Forms.SendKeys.Send("^V");
						this.Close();
					}
					break;
				case Keys.Escape:
					e.Handled = true;
					this.Close();
					break;
			}

		}


		private void Calcular()
		{
			string Texto = EntradaFormula.Text.Trim();
			string sResultado = "";
			string sResultado2 = "";

			try {
				decimal dResultado = decimal.Parse(Lfx.Types.Evaluator.Evaluate(Texto), System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture);
				sResultado = dResultado.ToString(System.Globalization.CultureInfo.InvariantCulture);
				sResultado2 = sResultado;
			}
			catch(Exception ex) {
				sResultado = ex.Message;
				sResultado2 = Texto;
			}

			EntradaFormula.Text = "";
			Imprimir(Texto + " =");
			EntradaFormula.Text = sResultado;
			EtiquetaResultado.Text = sResultado2;
			Imprimir(sResultado2);

			EntradaFormula.SelectionStart = EntradaFormula.Text.Length;
			EntradaFormula.SelectionLength = 0;
		}


		private void FormCalculadora_Load(object sender, System.EventArgs e)
		{
			for(int i = 1; i <= 20; i++) {
				Imprimir("");
			}
		}


                protected override void OnResizeEnd(EventArgs e)
                {
                        base.OnResizeEnd(e);
                        EntradaHistorial.ScrollToCaret();
                }


		private void FormCalculadora_Enter(object sender, System.EventArgs e)
		{
            try {
                // Esto a veces da una excepción en Windows 10.
                this.Opacity = 1;
            } catch (Exception) {
                // Nada
            }
        }


		private void FormCalculadora_Leave(object sender, System.EventArgs e)
		{
            try {
                // Esto a veces da una excepción en Windows 10.
                this.Opacity = 0.5;
            } catch (Exception) {
                // Nada
            }
		}
	}
}
