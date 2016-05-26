using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lfc.Comprobantes.Plantillas
{
        public partial class EditarCampo : Lui.Forms.DialogForm
	{
                public Lbl.Impresion.Campo Campo { get; set; }

		public EditarCampo()
		{
			InitializeComponent();
                        this.CancelCommandButton.Visible = false;
		}


                public EditarCampo(Lbl.Impresion.Campo campo)
                        : this()
                {
                        this.Campo = campo;

                        this.EntradaTexto.Text = this.Campo.Valor;
                        this.EntradaPreimpreso.ValueInt = this.Campo.Preimpreso ? 1 : 0;
                        if (this.Campo.Formato == null || this.Campo.Formato.Length == 0)
                                this.EntradaFormato.TextKey = "*";
                        else
                                this.EntradaFormato.TextKey = this.Campo.Formato;
                        this.EntradaX.ValueInt = this.Campo.Rectangle.X;
                        this.EntradaY.ValueInt = this.Campo.Rectangle.Y;
                        this.EntradaAncho.ValueInt = this.Campo.Rectangle.Width;
                        this.EntradaAlto.ValueInt = this.Campo.Rectangle.Height;
                        this.EntradaAlienacionHorizontal.TextKey = this.Campo.Alignment.ToString();
                        this.EntradaAlienacionVertical.TextKey = this.Campo.LineAlignment.ToString();
                        this.EntradaAjusteTexto.TextKey = this.Campo.Wrap ? "1" : "0";
                        this.EntradaAnchoBorde.ValueInt = this.Campo.AnchoBorde;
                        if (this.Campo.Font != null) {
                                Ignorar_EntradaFuenteFuenteTamano_TextChanged++;
                                this.EntradaFuenteNombre.TextKey = this.Campo.Font.Name;
                                this.EntradaFuenteTamano.ValueDecimal = Convert.ToDecimal(this.Campo.Font.Size);
                                Ignorar_EntradaFuenteFuenteTamano_TextChanged--;
                        } else {
                                this.EntradaFuenteNombre.TextKey = "*";
                                this.EntradaFuenteTamano.ValueDecimal = 10;
                        }

                        this.ActualizarMuestra();
                }


                private int Ignorar_EntradaFuenteFuenteTamano_TextChanged = 0;
                private void EntradaFuenteFuenteTamano_TextChanged(object sender, EventArgs e)
                {
                        if (Ignorar_EntradaFuenteFuenteTamano_TextChanged > 0)
                                return;
                        EntradaFuenteTamano.Enabled = (EntradaFuenteNombre.TextKey != "*");
                        if (this.EntradaFuenteNombre.TextKey != "*" && this.EntradaFuenteTamano.ValueDecimal > 1) {
                                this.Campo.Font = new Font(this.EntradaFuenteNombre.TextKey, ((float)(this.EntradaFuenteTamano.ValueDecimal)));
                        } else {
                                this.Campo.Font = null;
                        }
                        this.ActualizarMuestra();
                }

                private void BotonColorFondo_Click(object sender, EventArgs e)
                {
                        ColorDialog ColDlg = new ColorDialog();
                        ColDlg.Color = this.Campo.ColorFondo;
                        if (ColDlg.ShowDialog() == DialogResult.OK) {
                                this.Campo.ColorFondo = Color.FromArgb(255, ColDlg.Color);
                                ActualizarMuestra();
                        }
                }

                private void BotonColorTexto_Click(object sender, EventArgs e)
                {
                        ColorDialog ColDlg = new ColorDialog();
                        ColDlg.Color = this.Campo.ColorTexto;
                        if (ColDlg.ShowDialog() == DialogResult.OK) {
                                this.Campo.ColorTexto = Color.FromArgb(255, ColDlg.Color);
                                ActualizarMuestra();
                        }
                }

                private void BotonColorBorde_Click(object sender, EventArgs e)
                {
                        ColorDialog ColDlg = new ColorDialog();
                        ColDlg.Color = this.Campo.ColorBorde;
                        if (ColDlg.ShowDialog() == DialogResult.OK) {
                                this.Campo.ColorBorde = Color.FromArgb(255, ColDlg.Color);
                                if (this.Campo.ColorBorde != Color.Transparent && this.Campo.AnchoBorde == 0)
                                        EntradaAnchoBorde.ValueInt = 1;
                                else
                                        ActualizarMuestra();
                        }
                }

                private void EntradaTexto_TextChanged(object sender, EventArgs e)
                {
                        EntradaFormato.Enabled = EntradaTexto.Text.StartsWith("{") && EntradaTexto.Text.EndsWith("}");
                }

                private void ActualizarMuestra()
                {
                        if (this.Campo.Font == null) {
                                EtiquetaMuestra.Font = PanelMuestra.Font;
                        } else {
                                EtiquetaMuestra.Font = this.Campo.Font;
                        }

                        PanelMuestraBorde.Padding = new Padding((this.Campo.AnchoBorde + 1) / 2);
                        PanelMuestraBorde.BackColor = this.Campo.ColorBorde;
                        if (this.Campo.ColorFondo == Color.Transparent || this.Campo.ColorFondo.A == 0)
                                // Esto es para simular el fondo blanco, ya que si le doy transparente se ve el PanelBorde
                                EtiquetaMuestra.BackColor = Color.White;
                        else
                                EtiquetaMuestra.BackColor = this.Campo.ColorFondo;
                        EtiquetaMuestra.ForeColor = this.Campo.ColorTexto;
                        switch(this.Campo.LineAlignment) {
                                case StringAlignment.Near:
                                        switch(this.Campo.Alignment) {
                                                case StringAlignment.Near:
                                                        EtiquetaMuestra.TextAlign = ContentAlignment.TopLeft;
                                                        break;
                                                case StringAlignment.Center:
                                                        EtiquetaMuestra.TextAlign = ContentAlignment.TopCenter;
                                                        break;
                                                case StringAlignment.Far:
                                                        EtiquetaMuestra.TextAlign = ContentAlignment.TopRight;
                                                        break;
                                        }
                                        break;

                                case StringAlignment.Center:
                                        switch (this.Campo.Alignment) {
                                                case StringAlignment.Near:
                                                        EtiquetaMuestra.TextAlign = ContentAlignment.MiddleLeft;
                                                        break;
                                                case StringAlignment.Center:
                                                        EtiquetaMuestra.TextAlign = ContentAlignment.MiddleCenter;
                                                        break;
                                                case StringAlignment.Far:
                                                        EtiquetaMuestra.TextAlign = ContentAlignment.MiddleRight;
                                                        break;
                                        }
                                        break;

                                case StringAlignment.Far:
                                        switch (this.Campo.Alignment) {
                                                case StringAlignment.Near:
                                                        EtiquetaMuestra.TextAlign = ContentAlignment.BottomLeft;
                                                        break;
                                                case StringAlignment.Center:
                                                        EtiquetaMuestra.TextAlign = ContentAlignment.BottomCenter;
                                                        break;
                                                case StringAlignment.Far:
                                                        EtiquetaMuestra.TextAlign = ContentAlignment.BottomRight;
                                                        break;
                                        }
                                        break;
                        }

                        if (this.Campo.Wrap) {
                                EtiquetaMuestra.Text = @"Lorem ipsum ad his scripta
blandit partiendo,
eum fastidii accumsan
euripidis in,
eum liber hendrerit an";
                        } else {
                                EtiquetaMuestra.Text = "Texto de muestra";
                        }
                }

                public override Lfx.Types.OperationResult Ok()
                {
                        if (this.EntradaFormato.TextKey == "*")
                                this.Campo.Formato = null;
                        else
                                this.Campo.Formato = this.EntradaFormato.TextKey;
                        this.Campo.Rectangle = new Rectangle(this.EntradaX.ValueInt, this.EntradaY.ValueInt, this.EntradaAncho.ValueInt, this.EntradaAlto.ValueInt);
                        this.Campo.Valor = this.EntradaTexto.Text;
                        if (this.EntradaFuenteNombre.TextKey != "*" && this.EntradaFuenteTamano.ValueDecimal > 1) {
                                this.Campo.Font = new Font(this.EntradaFuenteNombre.TextKey, ((float)(this.EntradaFuenteTamano.ValueDecimal)));
                        } else {
                                this.Campo.Font = null;
                        }
                        switch (this.EntradaAlienacionHorizontal.TextKey) {
                                case "Far":
                                        this.Campo.Alignment = StringAlignment.Far;
                                        break;
                                case "Center":
                                        this.Campo.Alignment = StringAlignment.Center;
                                        break;
                                default:
                                        this.Campo.Alignment = StringAlignment.Near;
                                        break;
                        }
                        switch (this.EntradaAlienacionVertical.TextKey) {
                                case "Far":
                                        this.Campo.LineAlignment = StringAlignment.Far;
                                        break;
                                case "Center":
                                        this.Campo.LineAlignment = StringAlignment.Center;
                                        break;
                                default:
                                        this.Campo.LineAlignment = StringAlignment.Near;
                                        break;
                        }
                        this.Campo.Wrap = this.EntradaAjusteTexto.TextKey == "1";

                        return base.Ok();
                }

                private void EntradaAnchoBorde_TextChanged(object sender, EventArgs e)
                {
                        this.Campo.AnchoBorde = this.EntradaAnchoBorde.ValueInt;
                        this.ActualizarMuestra();
                }

                private void EntradaAlienacionHorizontal_TextChanged(object sender, EventArgs e)
                {
                        switch (this.EntradaAlienacionHorizontal.TextKey) {
                                case "Far":
                                        this.Campo.Alignment = StringAlignment.Far;
                                        break;
                                case "Center":
                                        this.Campo.Alignment = StringAlignment.Center;
                                        break;
                                default:
                                        this.Campo.Alignment = StringAlignment.Near;
                                        break;
                        }
                        this.ActualizarMuestra();
                }



                private void EntradaAlienacionVertical_TextChanged(object sender, EventArgs e)
                {
                        switch (this.EntradaAlienacionVertical.TextKey) {
                                case "Far":
                                        this.Campo.LineAlignment = StringAlignment.Far;
                                        break;
                                case "Center":
                                        this.Campo.LineAlignment = StringAlignment.Center;
                                        break;
                                default:
                                        this.Campo.LineAlignment = StringAlignment.Near;
                                        break;
                        }
                        this.ActualizarMuestra();
                }


                private void EntradaAjusteTexto_TextChanged(object sender, EventArgs e)
                {
                        this.Campo.Wrap = EntradaAjusteTexto.ValueInt == 1;
                        this.ActualizarMuestra();
                }


                private void BotonColorFondoPredet_Click(object sender, EventArgs e)
                {
                        this.Campo.ColorFondo = Color.Transparent;
                        this.ActualizarMuestra();
                }

                private void EntradaPreimpreso_TextChanged(object sender, EventArgs e)
                {
                        Campo.Preimpreso = EntradaPreimpreso.ValueInt != 0;
                }
	}
}

