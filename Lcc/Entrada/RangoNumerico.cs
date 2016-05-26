using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Lcc.Entrada
{
        public partial class RangoNumerico : Lui.Forms.Control
        {
                public decimal Min { get; set; }
                public decimal Max { get; set; }


                public RangoNumerico()
                {
                        InitializeComponent();
                }


                public int DecimalPlaces
                {
                        get
                        {
                                return EntradaValor1.DecimalPlaces;
                        }
                        set
                        {
                                EntradaValor1.DecimalPlaces = value;
                                EntradaValor2.DecimalPlaces = value;
                                if (value == 0) {
                                        EntradaValor1.DataType = Lui.Forms.DataTypes.Integer;
                                        EntradaValor2.DataType = Lui.Forms.DataTypes.Integer;
                                } else {
                                        EntradaValor1.DataType = Lui.Forms.DataTypes.Float;
                                        EntradaValor2.DataType = Lui.Forms.DataTypes.Float;
                                }
                        }
                }


                public decimal Valule1
                {
                        get
                        {
                                return EntradaValor1.ValueDecimal;
                        }
                        set
                        {
                                EntradaValor1.ValueDecimal = value;
                        }
                }


                public decimal Valule2
                {
                        get
                        {
                                return EntradaValor2.ValueDecimal;
                        }
                        set
                        {
                                EntradaValor2.ValueDecimal = value;
                        }
                }
        }
}
