using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Lcc.Entrada.Articulos
{
        public partial class MatrizVariacionCantidad : MatrizControlesEntrada<VariacionCantidad>
        {
                private bool m_EsNumeroDeSerie = false;

                public MatrizVariacionCantidad()
                {
                        InitializeComponent();
                }

                /// <summary>
                /// Determina si se está ingresando un número de serie.
                /// Cuando se ingresa un número de serie, sólo se permiten letras mayúsculas y sólo se admite cantidad 1 (1 elemento por número).
                /// En caso contrario, se trata de variaciones, donde se permiten minúsculas y más de 1 por variación (p. ej. 2 rojos, 4 azules, etc.)
                /// </summary>
                public bool EsNumeroDeSerie
                {
                        get
                        {
                                return m_EsNumeroDeSerie;
                        }
                        set
                        {
                                m_EsNumeroDeSerie = value;
                        }
                }

                protected override VariacionCantidad Agregar()
                {
                        VariacionCantidad Ctrl = base.Agregar();

                        Ctrl.EsNumeroDeSerie = m_EsNumeroDeSerie;

                        return Ctrl;
                }


                public Lbl.Articulos.ColeccionDatosSeguimiento DatosSeguimiento
                {
                        get
                        {
                                Lbl.Articulos.ColeccionDatosSeguimiento Res = new Lbl.Articulos.ColeccionDatosSeguimiento();
                                foreach (VariacionCantidad Ctrl in this.Controles) {
                                        if (Ctrl.IsEmpty == false)
                                                Res.AddWithValue(Ctrl.Variacion, Ctrl.Cantidad);
                                }

                                return Res;
                        }
                        set
                        {
                                this.Controles.Clear();
                                if (value != null) {
                                        foreach (Lbl.Articulos.DatosSeguimiento Dat in value) {
                                                VariacionCantidad Ctl = this.Agregar();
                                                Ctl.Variacion = Dat.Variacion;
                                                Ctl.Cantidad = Dat.Cantidad;
                                        }
                                }
                                this.AutoAgregarOQuitar(true);
                        }
                }
        }
}
