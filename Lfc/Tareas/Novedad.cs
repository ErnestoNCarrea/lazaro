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
                                qGen.Insert InsertarNovedad = new qGen.Insert(Connection, "tickets_eventos");
                                InsertarNovedad.Fields.AddWithValue("id_ticket", EntradaTicket.ValueInt);
                                InsertarNovedad.Fields.AddWithValue("id_tecnico", EntradaEncargado.ValueInt);
                                InsertarNovedad.Fields.AddWithValue("minutos_tecnico", Lfx.Types.Parsing.ParseInt(EntradaMinutos.Text));
                                InsertarNovedad.Fields.AddWithValue("privado", EntradaCondicion.TextKey);
                                InsertarNovedad.Fields.AddWithValue("descripcion", EntradaDescripcion.Text);
                                InsertarNovedad.Fields.AddWithValue("fecha", qGen.SqlFunctions.Now);
                                this.Connection.Execute(InsertarNovedad);
                                Trans.Commit();
                        }

                        return base.Ok();
                }
        }
}