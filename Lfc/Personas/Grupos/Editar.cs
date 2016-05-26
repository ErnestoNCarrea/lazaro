using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Lfc.Personas.Grupos
{
        public partial class Editar : Lcc.Edicion.ControlEdicion
        {

                public Editar()
                {
                        ElementoTipo = typeof(Lbl.Personas.Grupo);

                        InitializeComponent();
                }

                public override void ActualizarControl()
                {
                        Lbl.Personas.Grupo Gru = this.Elemento as Lbl.Personas.Grupo;

                        EntradaNombre.Text = Gru.Nombre;
                        EntradaDescuento.ValueDecimal = Gru.Descuento;
                        EntradaPredet.TextKey = Gru.Predeterminado ? "1" : "0";
                        EntradaGrupo.Elemento = Gru.Parent;
                        if (this.Elemento.Existe)
                                EntradaGrupo.Filter = "id_grupo<>" + this.Elemento.Id;

                        base.ActualizarControl();
                }

                public override void ActualizarElemento()
                {
                        Lbl.Personas.Grupo Gru = this.Elemento as Lbl.Personas.Grupo;

                        Gru.Nombre = EntradaNombre.Text;
                        Gru.Descuento = EntradaDescuento.ValueDecimal;
                        Gru.Predeterminado = EntradaPredet.TextKey == "1";
                        Gru.Parent = EntradaGrupo.Elemento as Lbl.Personas.Grupo;

                        base.ActualizarElemento();
                }


                public override Lazaro.Pres.DisplayStyles.IDisplayStyle HeaderDisplayStyle
                {
                        get
                        {
                                return Lazaro.Pres.DisplayStyles.Template.Current.Personas;
                        }
                }
        }
}
