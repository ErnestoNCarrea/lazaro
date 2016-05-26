using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Lcc.Entrada.Articulos
{
        public partial class VariacionCantidad : ControlEntrada
        {
                public VariacionCantidad()
                {
                        InitializeComponent();

                        if (Lfx.Workspace.Master != null) {
                                EntradaCantidad.DecimalPlaces = Lbl.Sys.Config.Articulos.Decimales;
                        }
                }

                [EditorBrowsable(EditorBrowsableState.Never),
                        Browsable(false),
                        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
                public string Variacion
                {
                        get
                        {
                                return EntradaVariacion.Text;
                        }
                        set
                        {
                                EntradaVariacion.Text = value;
                        }
                }


                public bool EsNumeroDeSerie
                {
                        get
                        {
                                return EntradaCantidad.TemporaryReadOnly;
                        }
                        set
                        {
                                EntradaCantidad.TemporaryReadOnly = value;
                                EntradaCantidad.Enabled = !value;
                                if (value) {
                                        EntradaCantidad.Text = "1";
                                        EntradaVariacion.ForceCase = Lui.Forms.TextCasing.UpperCase;
                                } else {
                                        EntradaVariacion.ForceCase = Lui.Forms.TextCasing.Automatic;
                                }
                        }
                }


                [EditorBrowsable(EditorBrowsableState.Never),
                        Browsable(false),
                        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
                public decimal Cantidad
                {
                        get
                        {
                                return Lfx.Types.Parsing.ParseStock(EntradaCantidad.Text);
                        }
                        set
                        {
                                EntradaCantidad.Text = Lfx.Types.Formatting.FormatStock(value);
                        }
                }

                public override bool IsEmpty
                {
                        get
                        {
                                return this.Variacion.Length == 0;
                        }
                }

                private void EntradaVariacionCantidad_TextChanged(object sender, EventArgs e)
                {
                        this.Text = EntradaVariacion.Text + ": " + EntradaCantidad.Text;
                        EntradaCantidad.TabStop = EntradaVariacion.Text.Length > 0;
                        this.OnTextChanged(e);
                }

                private void EntradaVariacion_KeyDown(object sender, KeyEventArgs e)
                {
                        if (e.Alt == false && e.Control == false && e.Shift == false) {
                                switch(e.KeyCode){
                                        case Keys.Right:
                                                if (EntradaVariacion.SelectionStart == EntradaVariacion.Text.Length) {
                                                        e.Handled = true;
                                                        SendKeys.Send("{tab}");
                                                }
                                                break;
                                }
                        }
                }

                private void EntradaCantidad_KeyDown(object sender, KeyEventArgs e)
                {
                        if (e.Alt == false && e.Control == false && e.Shift == false) {
                                switch (e.KeyCode) {
                                        case Keys.Left:
                                                if (EntradaCantidad.SelectionStart == 0 && EntradaCantidad.SelectionLength == 0) {
                                                        e.Handled = true;
                                                        SendKeys.Send("+{tab}");
                                                }
                                                break;
                                }
                        }
                }
        }

}
