using System;

namespace Lfc.Reportes
{
        public partial class Patrimonio : Lui.Forms.ChildForm
        {
                public Patrimonio()
                {
                        if (Lbl.Sys.Config.Actual.UsuarioConectado.TienePermiso(typeof(Lbl.Cajas.Caja), Lbl.Sys.Permisos.Operaciones.Administrar) == false) {
                                this.DialogResult = System.Windows.Forms.DialogResult.Abort;
                                this.Close();
                                return;
                        }

                        InitializeComponent();
                }

                protected override void OnLoad(EventArgs e)
                {
                        base.OnLoad(e);
                        if (this.Connection != null)
                                this.MostrarDatos();
                }

                private void MostrarDatos()
                {
                        decimal ActivosCajas = 0;
                        decimal PasivosCajas = 0;
			
                        System.Data.DataTable Cajas = this.Connection.Select("SELECT * FROM cajas WHERE estado>0");
                        foreach(System.Data.DataRow Rw in Cajas.Rows) {
                                Lbl.Cajas.Caja Cta = new Lbl.Cajas.Caja(this.Connection, (Lfx.Data.Row)Rw);
                                decimal Saldo = Cta.ObtenerSaldo(false);
                                if (Saldo > 0)
                                        ActivosCajas += Saldo;
                                else
                                        PasivosCajas += Math.Abs(Saldo);
                        }

                        EntradaActivosCajas.Text = Lfx.Types.Formatting.FormatCurrency(ActivosCajas, Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales);
                        EntradaPasivosCajas.Text = Lfx.Types.Formatting.FormatCurrency(PasivosCajas, Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales);

                        decimal ActivosStock = Connection.FieldDecimal("SELECT SUM(costo*stock_actual) FROM articulos WHERE costo>0 AND stock_actual>0");
                        EntradaActivosStock.Text = Lfx.Types.Formatting.FormatCurrency(ActivosStock, Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales);

                        decimal Activos = ActivosCajas + ActivosStock;
                        EntradaActivosSubtotal.Text = Lfx.Types.Formatting.FormatCurrency(Activos, Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales);

                        decimal FuturosTarjetas = 0.92m * Connection.FieldDecimal("SELECT SUM(importe) FROM tarjetas_cupones WHERE estado=10 OR (estado=0 AND fecha>DATE_SUB(NOW(), INTERVAL 45 DAY))");
                                                //Tarjetas resta el 8% (estimado) de comisiones
                        decimal Facturas = Connection.FieldDecimal("SELECT SUM(total)-SUM(cancelado) FROM comprob WHERE tipo_fac IN ('FA', 'FB', 'FC', 'FE', 'FM') AND impresa>0 AND numero>0 AND anulada=0 AND fecha >= '" + Lfx.Types.Formatting.FormatDateSql(DateTime.Now.AddYears(-2)) + "'");
                        EntradaCC.Text = Lfx.Types.Formatting.FormatCurrency(Facturas, Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales);

                        decimal FuturosPedidos = Connection.FieldDecimal("SELECT SUM(total-gastosenvio) FROM comprob WHERE tipo_fac='PD' AND anulada=0 AND compra>0 AND estado=50");
                        EntradaFuturosTarjetas.Text = Lfx.Types.Formatting.FormatCurrency(FuturosTarjetas, Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales);
                        EntradaFuturosPedidos.Text = Lfx.Types.Formatting.FormatCurrency(FuturosPedidos, Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales);
                        
                        decimal Futuros = FuturosTarjetas + FuturosPedidos + Facturas;
                        EntradaFuturosSubtotal.Text = Lfx.Types.Formatting.FormatCurrency(Futuros, Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales);

                        EntradaActivosActualesFuturos.Text = Lfx.Types.Formatting.FormatCurrency(Activos + Futuros, Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales);

                        decimal PasivosCheques = Connection.FieldDecimal("SELECT SUM(importe) FROM bancos_cheques WHERE emitido>0 AND estado=0");
                        EntradaPasivosCheques.Text = Lfx.Types.Formatting.FormatCurrency(PasivosCheques, Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales);

                        decimal PasivosStock = Math.Abs(Connection.FieldDecimal("SELECT SUM(costo*stock_actual) FROM articulos WHERE costo>0 AND stock_actual<0"));
                        EntradaPasivosStock.Text = Lfx.Types.Formatting.FormatCurrency(PasivosStock, Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales);

                        decimal Pasivos = PasivosCajas + PasivosCheques + PasivosStock;
                        EntradaPasivosSubtotal.Text = Lfx.Types.Formatting.FormatCurrency(Pasivos, Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales);

                        EntradaPatrimonioActual.Text = Lfx.Types.Formatting.FormatCurrency(Activos - Pasivos, Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales);
                        EntradaPatrimonioFuturo.Text = Lfx.Types.Formatting.FormatCurrency(Activos + Futuros - Pasivos, Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales);
                }
        }
}