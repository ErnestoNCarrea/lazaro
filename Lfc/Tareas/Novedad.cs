namespace Lfc.Tareas
{
        public partial class Novedad : Lui.Forms.DialogForm
        {
                public Novedad()
                {
                        InitializeComponent();

                        if (Lbl.Sys.Config.Actual != null && Lbl.Sys.Config.Actual.UsuarioConectado != null)
                                EntradaEncargado.Elemento = Lbl.Sys.Config.Actual.UsuarioConectado.Persona;
                }

                public override Lfx.Types.OperationResult Ok()
                {
                        if (EntradaTicket.ValueInt == 0)
                                return new Lfx.Types.FailureOperationResult("Escriba el código de Ticket");

                        using (System.Data.IDbTransaction Trans = this.Connection.BeginTransaction()) {
                                var InsertarNovedad = new qGen.Insert("tickets_eventos");
                                InsertarNovedad.ColumnValues.AddWithValue("id_ticket", EntradaTicket.ValueInt);
                                InsertarNovedad.ColumnValues.AddWithValue("id_tecnico", EntradaEncargado.ValueInt);
                                InsertarNovedad.ColumnValues.AddWithValue("minutos_tecnico", Lfx.Types.Parsing.ParseInt(EntradaMinutos.Text));
                                InsertarNovedad.ColumnValues.AddWithValue("privado", EntradaCondicion.TextKey);
                                InsertarNovedad.ColumnValues.AddWithValue("descripcion", EntradaDescripcion.Text);
                                InsertarNovedad.ColumnValues.AddWithValue("fecha", new qGen.SqlExpression("NOW()"));
                                this.Connection.ExecuteNonQuery(InsertarNovedad);
                                Trans.Commit();
                        }

                        return base.Ok();
                }
        }
}