using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Lfc.Misc
{
        public partial class Desduplicar : Lui.Forms.DialogForm
        {
                private Lbl.Personas.Persona PersonaOriginal = null, PersonaDuplicada = null;

                public Desduplicar()
                {
                        if (Lbl.Sys.Config.Actual.UsuarioConectado.TienePermiso(typeof(Lbl.Personas.Persona), Lbl.Sys.Permisos.Operaciones.Administrar) == false) {
                                this.DialogResult = System.Windows.Forms.DialogResult.Abort;
                                this.Close();
                                return;
                        }

                        InitializeComponent();
                }

                public override Lfx.Types.OperationResult Ok()
                {
                        if (Lbl.Sys.Config.Actual.UsuarioConectado.TieneAccesoGlobal() == false)
                                return new Lfx.Types.FailureOperationResult("Necesita permiso de administrador para desduplicar elementos.");

                        if (EntradaElementoDuplicado.ValueInt == 0)
                                return new Lfx.Types.FailureOperationResult("Debe seleccionar un elemento para eliminar.");

                        if (EntradaElementoOriginal.ValueInt == 0)
                                return new Lfx.Types.FailureOperationResult("Debe seleccionar un elemento para reemplazar al elemento eliminado.");

                        if (EntradaElementoOriginal.TextDetail != EntradaElementoDuplicado.TextDetail)
                                return new Lfx.Types.FailureOperationResult("Los elementos deben tener el mismo nombre.");

                        Lbl.Servicios.Desduplicador Desdup = new Lbl.Servicios.Desduplicador(this.Connection, EntradaElementoOriginal.Relation.ReferenceTable, EntradaElementoOriginal.Relation.ReferenceColumn, EntradaElementoOriginal.ValueInt, EntradaElementoDuplicado.ValueInt);
                        Desdup.Desduplicar();


                        return base.Ok();
                }

                private void EntradaElementoOriginal_TextChanged(object sender, EventArgs e)
                {
                        if (EntradaElementoOriginal.ValueInt == 0) {
                                PersonaOriginal = null;
                                EntradaCtaCte1.Text = "0";
                        } else {
                                PersonaOriginal = EntradaElementoOriginal.Elemento as Lbl.Personas.Persona;
                                EntradaCtaCte1.Text = Lfx.Types.Formatting.FormatCurrency(PersonaOriginal.CuentaCorriente.ObtenerSaldo(false), Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales);
                        }
                }

                private void EntradaElementoDuplicado_TextChanged(object sender, EventArgs e)
                {
                        if (EntradaElementoDuplicado.ValueInt == 0) {
                                PersonaDuplicada = null;
                                EntradaCtaCte2.Text = "0";
                        } else {
                                PersonaDuplicada = EntradaElementoDuplicado.Elemento as Lbl.Personas.Persona;
                                EntradaCtaCte2.Text = Lfx.Types.Formatting.FormatCurrency(PersonaDuplicada.CuentaCorriente.ObtenerSaldo(false), Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales);
                        }
                }

                private void EntradaCtaCte1CtaCte2_TextChanged(object sender, EventArgs e)
                {
                        decimal Cta1 = 0, Cta2 = 0;
                        
                        if (PersonaOriginal != null)
                                Cta1 = EntradaCtaCte1.ValueDecimal;

                        if (PersonaDuplicada != null)
                                Cta2 = EntradaCtaCte2.ValueDecimal;

                        EntradaCtaCteFinal.Text = Lfx.Types.Formatting.FormatCurrency(Cta1 + Cta2, Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales);
                }
        }
}
