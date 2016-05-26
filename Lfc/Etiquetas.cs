using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Lfc
{
        public partial class Etiquetas : Lui.Forms.DialogForm
        {
                public Etiquetas()
                {
                        InitializeComponent();
                }

                public Lbl.IElementoDeDatos Elemento
                {
                        get
                        {
                                return EntradaEtiquetas.Elemento;
                        }
                        set
                        {
                                this.Text = value.ToString();
                                EntradaEtiquetas.Elemento = value;
                                EntradaComentarios.Elemento = value;
                                EntradaEtiquetas.ActualizarControl();
                                EntradaComentarios.ActualizarControl();
                        }
                }

                public override Lfx.Types.OperationResult Ok()
                {
                        using (IDbTransaction Trans = this.Elemento.Connection.BeginTransaction()) {
                                this.Elemento.GuardarEtiquetas();
                                Trans.Commit();
                        }

                        return base.Ok();
                }
        }
}
