using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Lcc.Entrada
{
        public partial class Telefono : ControlEntrada
        {
                public Telefono()
                {
                        InitializeComponent();

                        EntradaNombre.AutoCompleteStringCollection = new System.Windows.Forms.AutoCompleteStringCollection() {
                                "Trabajo", "Casa", "Móvil", "Fax", "Celular"
                        };
                }

                public override string Text
                {
                        get
                        {
                                string Res = "";

                                if (EntradaNumero.Text.Length > 0) {

                                        if (EntradaNombre.Text.Length > 0)
                                                Res = EntradaNombre.Text + ": ";

                                        if (EntradaCaracteristica.Text.Length > 0)
                                                Res += "(" + EntradaCaracteristica.Text + ") ";

                                        Res += EntradaNumero.Text;
                                }

                                return Res.Trim();
                        }
                        set
                        {
                                if (value == null) {
                                        EntradaNombre.Text = "";
                                        EntradaCaracteristica.Text = "";
                                        EntradaNumero.Text = "";
                                } else {
                                        string[] NombreNumero = value.Split(new char[] { ':' }, 2, StringSplitOptions.RemoveEmptyEntries);
                                        
                                        // No hay nombre, sólo numero
                                        if (NombreNumero.Length < 2)
                                                NombreNumero = new string[] { "", value };

                                        EntradaNombre.Text = NombreNumero[0].Trim();

                                        string Numero = NombreNumero[1].Trim();

                                        string[] CaractNumero = Numero.Split(new char[] { ')' }, 2, StringSplitOptions.RemoveEmptyEntries);

                                        if (CaractNumero.Length < 2)
                                                // No hay característica, sólo numero
                                                CaractNumero = new string[] { "", Numero };
                                        else if (CaractNumero[0].Length >= 1 && CaractNumero[0][0] == '(')
                                                // Hay característica, quito el paréntesis que quedó del split de arriba
                                                CaractNumero[0] = CaractNumero[0].Substring(1, CaractNumero[0].Length - 1);

                                        EntradaCaracteristica.Text = CaractNumero[0].Trim();
                                        EntradaNumero.Text = CaractNumero[1].Trim();
                                }
                        }
                }

                private void Entradas_TextChanged(object sender, EventArgs e)
                {
                        this.OnTextChanged(EventArgs.Empty);
                }
        }
}
