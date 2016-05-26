using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

namespace Lfc.Tareas
{
        public partial class Articulos : Lui.Forms.DialogForm
        {
                private Lbl.Tareas.Tarea m_Tarea;

                public Articulos()
                {
                        InitializeComponent();
                }

                public void ActualizarElemento()
                {
                        m_Tarea.Articulos = MatrizArticulos.ObtenerArticulos(m_Tarea.Connection);
                        m_Tarea.Articulos.HayCambios = true;
                        m_Tarea.DescuentoArticulos = EntradaDescuento.ValueDecimal;
                }

                public void ActualizarControl()
                {
                        EtiquetaTitulo.Text = "Artículos de " + m_Tarea.ToString();
                        this.Text = EtiquetaTitulo.Text;
                        MatrizArticulos.CargarArticulos(m_Tarea.Articulos);
                        EntradaDescuento.ValueDecimal = m_Tarea.DescuentoArticulos;
                }

                public Lbl.Tareas.Tarea Tarea
                {
                        get
                        {
                                return m_Tarea;
                        }
                        set
                        {
                                m_Tarea = value;
                                this.ActualizarControl();
                        }
                }


                private void ProductArray_TotalChanged(System.Object sender, System.EventArgs e)
                {
                        EntradaSubTotal.Text = Lfx.Types.Formatting.FormatCurrency(MatrizArticulos.Total, Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales);
                }


                private void EntradaSubTotal_TextChanged(object sender, System.EventArgs e)
                {
                        EntradaTotal.ValueDecimal = EntradaSubTotal.ValueDecimal * (1 - EntradaDescuento.ValueDecimal / 100);
                }

                public override Lfx.Types.OperationResult Ok()
                {
                        this.ActualizarElemento();
                        return base.Ok();
                }
        }
}