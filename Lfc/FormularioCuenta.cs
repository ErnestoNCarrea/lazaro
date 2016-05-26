using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

namespace Lfc
{
        public partial class FormularioCuenta : FormularioListadoBase
        {
                private Lbl.Personas.Persona m_Cliente = null;
                private Lfx.Types.DateRange m_Fechas = new Lfx.Types.DateRange("dia-0");

                public FormularioCuenta()
                {
                        InitializeComponent();
                        this.Contadores.Add(new Contador("Transporte", Lui.Forms.DataTypes.Currency));
                        this.Contadores.Add(new Contador("Ingresos", Lui.Forms.DataTypes.Currency));
                        this.Contadores.Add(new Contador("Egresos", Lui.Forms.DataTypes.Currency));
                        this.Contadores.Add(new Contador("Saldo", Lui.Forms.DataTypes.Currency));
                }


                public Lfx.Types.DateRange Fechas
                {
                        get
                        {
                                return m_Fechas;
                        }
                        set
                        {
                                m_Fechas = value;
                                if (this.Definicion.Filters.ContainsKey("cajas_movim.fecha"))
                                        this.Definicion.Filters["cajas_movim.fecha"].Value = value;
                        }
                }


                public Lbl.Personas.Persona Cliente
                {
                        get
                        {
                                return m_Cliente;
                        }
                        set
                        {
                                m_Cliente = value;
                        }
                }

                protected override void OnTextChanged(EventArgs e)
                {
                        if (EtiquetaTitulo != null)
                                EtiquetaTitulo.Text = this.Text;
                        base.OnTextChanged(e);
                }
        }
}