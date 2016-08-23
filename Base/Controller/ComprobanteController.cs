using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lazaro.Base.Controller
{
        public class ComprobanteController : BaseController, IConElemento, IConImprimir
        {
                protected static Afip.Ws.FacturaElectronica.ServicioFacturaElectronica CliFe = null;

                public Lbl.IElementoDeDatos Elemento { get; set; }

                public ComprobanteController() { }

                public ComprobanteController(System.Data.IDbTransaction trans)
                        : base(trans)
                { }

                public Lbl.Comprobantes.Comprobante Comprobante
                {
                        get
                        {
                                return this.Elemento as Lbl.Comprobantes.Comprobante;
                        }
                }

                public Lfx.Types.OperationResult Imprimir()
                {
                        return this.Imprimir(this.Comprobante, null);
                }


                public Lfx.Types.OperationResult ImprimirLote(Lbl.Comprobantes.Lote lote, Lbl.Impresion.Impresora impresora)
                {
                        return new Lfx.Types.CancelOperationResult();
                }

                public Lfx.Types.OperationResult Imprimir(Lbl.Comprobantes.Comprobante comprobante, Lbl.Impresion.Impresora impresora)
                {
                        if(impresora == null) {
                                impresora = Util.Comprobantes.Impresion.ObtenerImpresora(comprobante);
                        }

                        var Reimpresion = comprobante.Impreso;
                        var ClaseImpr = Util.Comprobantes.Impresion.ObtenerClaseImpresora(comprobante);

                        if (ClaseImpr != Lbl.Impresion.ClasesImpresora.FiscalAfip && ClaseImpr != Lbl.Impresion.ClasesImpresora.ElectronicaAfip && impresora != null) {
                                ClaseImpr = impresora.Clase;

                                if (comprobante.Tipo.EsFacturaNCoND && impresora.EsVistaPrevia) {
                                        return new Lfx.Types.FailureOperationResult("Este tipo de comprobante no puede ser previsualizado");
                                }
                        }

                        switch (ClaseImpr) {
                                case Lbl.Impresion.ClasesImpresora.ElectronicaAfip:
                                        if (Reimpresion) {
                                                this.GenerarPdf(comprobante as Lbl.Comprobantes.ComprobanteConArticulos);
                                                return new Lfx.Types.SuccessOperationResult();
                                        } else {
                                                return this.ImprimirFacturaElectronicaAfip(comprobante as Lbl.Comprobantes.ComprobanteConArticulos);
                                        }

                                case Lbl.Impresion.ClasesImpresora.FiscalAfip:
                                        if (Reimpresion)
                                                return new Lfx.Types.FailureOperationResult("No se permiten reimpresiones fiscales");

                                        // Primero hago un COMMIT, porque si no el otro proceso no va a poder hacer movimientos
                                        if (this.Transaction != null) {
                                                this.Transaction.Commit();
                                                this.Transaction.Dispose();
                                                this.Transaction = null;
                                        }

                                        // Lo mando a imprimir al servidor fiscal
                                        string Estacion = null;
                                        if (ClaseImpr == Lbl.Impresion.ClasesImpresora.FiscalAfip)
                                                Estacion = Lbl.Comprobantes.PuntoDeVenta.TodosPorNumero[comprobante.PV].Estacion;

                                        if (Estacion == null && impresora != null)
                                                Estacion = impresora.Estacion;

                                        if (Estacion != null)
                                                Lfx.Workspace.Master.DefaultScheduler.AddTask("IMPRIMIR " + comprobante.Id.ToString(), "fiscal" + comprobante.PV.ToString(), Estacion);
                                        else
                                                throw new Exception("No se ha definido el equipo al cual está conectada la impresora remota");

                                        //Espero hasta que la factura está impresa o hasta que pasen X segundos
                                        System.DateTime FinEsperaFiscal = System.DateTime.Now.AddSeconds(90);
                                        int NumeroFiscal = 0;
                                        while (System.DateTime.Now < FinEsperaFiscal && NumeroFiscal == 0) {
                                                System.Threading.Thread.Sleep(1000);
                                                NumeroFiscal = comprobante.Connection.FieldInt("SELECT numero FROM comprob WHERE impresa<>0 AND id_comprob=" + comprobante.Id.ToString());
                                        }
                                        if (NumeroFiscal == 0) {
                                                // Llegó el fin del tiempo de espera y no imprimió
                                                return new Lfx.Types.FailureOperationResult("Se superó el tiempo de espera para recibir respuesta del Servidor Fiscal.");
                                        } else {
                                                comprobante.Cargar();
                                                // Tengo número de factura. Imprimió Ok
                                                return new Lfx.Types.SuccessOperationResult();
                                        }

                                case Lbl.Impresion.ClasesImpresora.Nula:
                                        if (Reimpresion == false && comprobante.Tipo.NumerarAlImprimir)
                                                new Lbl.Comprobantes.Numerador(comprobante).Numerar(true);

                                        return new Lfx.Types.SuccessOperationResult();

                                case Lbl.Impresion.ClasesImpresora.Papel:
                                        if (impresora == null || impresora.EsLocal) {
                                                var Impresor = Lazaro.Base.Util.Impresion.Instanciador.InstanciarImpresor(comprobante, this.Transaction);
                                                return Impresor.Imprimir();
                                        } else {
                                                if (Reimpresion)
                                                        throw new Lfx.Types.DomainException("No se permiten reimpresiones remotas");

                                                // Primero hago un COMMIT, porque si no el otro proceso no va a poder hacer movimientos
                                                if (this.Transaction != null) {
                                                        this.Transaction.Commit();
                                                        this.Transaction.Dispose();
                                                        this.Transaction = null;
                                                }

                                                // Lo mando a imprimir a la estación remota
                                                Lfx.Workspace.Master.DefaultScheduler.AddTask("IMPRIMIR " + comprobante.GetType().ToString() + " " + comprobante.Id.ToString() + " EN " + impresora.Dispositivo, "lazaro", impresora.Estacion);

                                                if (Reimpresion == false) {
                                                        //Espero hasta que la factura está impresa o hasta que pasen X segundos
                                                        System.DateTime FinEspera = System.DateTime.Now.AddSeconds(90);
                                                        int Impreso = 0;
                                                        while (System.DateTime.Now < FinEspera && Impreso == 0) {
                                                                System.Threading.Thread.Sleep(1000);
                                                                Impreso = comprobante.Connection.FieldInt("SELECT impresa FROM comprob WHERE impresa<>0 AND id_comprob=" + comprobante.Id.ToString());
                                                        }
                                                        if (Impreso == 0) {
                                                                // Llegó el fin del tiempo de espera y no imprimió
                                                                return new Lfx.Types.FailureOperationResult("Se superó el tiempo de espera para recibir respuesta del sistema remoto.");
                                                        } else {
                                                                comprobante.Cargar();
                                                                // Tengo número de factura. Imprimió Ok
                                                                return new Lfx.Types.SuccessOperationResult();
                                                        }
                                                }

                                                return new Lfx.Types.SuccessOperationResult();
                                        }

                                default:
                                        throw new NotImplementedException("No se reconoce el tipo de impresora " + ClaseImpr.ToString());
                        }
                }


                public Lfx.Types.OperationResult ImprimirFacturaElectronicaAfip(Lbl.Comprobantes.ComprobanteConArticulos comprobante)
                {
                        Lfx.Types.OperationResult Res = this.IniciarWsAfip();
                        if(Res.Success == false) {
                                return Res;
                        }

                        var TiposComprob = CliFe.ObtenerTiposDeComprobante();
                        foreach (Afip.Ws.AfipFe.CbteTipo Cbe in TiposComprob) {
                                System.Console.WriteLine(Cbe.Desc + " = " + Cbe.Id.ToString());
                        }

                        var TipoComprob = Afip.Ws.FacturaElectronica.Tablas.ComprobantesTiposPorLetra[comprobante.Tipo.Nomenclatura];
                        var UltimoComprob = CliFe.UltimoComprobante(comprobante.PV, TipoComprob);

                        int ProximoNumero = UltimoComprob.CbteNro + 1;

                        //Lfx.Workspace.Master.RunTime.Toast(UltimoComprob.CbteNro.ToString(), "Último comprobante de este PV");

                        var SolCae = Util.Comprobantes.ClienteAfipWsfe.CrearSolicitudCae(comprobante, ProximoNumero);

                        var Cae = CliFe.SolictarCae(SolCae);
                        // TODO: tratamiento de errores

                        foreach(var Comprob in SolCae.Comprobantes) {
                                if(Comprob.Cae != null) {
                                        new Lbl.Comprobantes.Numerador(comprobante).Numerar(Comprob.Numero, Comprob.Cae.CodigoCae, Comprob.Cae.Vencimiento, true);
                                        this.GenerarPdf(comprobante);
                                }
                        }

                        
                        if(Cae) {
                                // La solicitud tuvo éxito (total o parcial)
                                return new Lfx.Types.SuccessOperationResult();
                        } else {
                                // La solicitud de CAE fue rechazada
                                if (SolCae.Observaciones.Count > 0) {
                                        return new Lfx.Types.FailureOperationResult(SolCae.Observaciones[0].Mensaje);
                                } else {
                                        return new Lfx.Types.FailureOperationResult("La solicitud de CAE fue rechazada");
                                }
                        }
                }

                /// <summary>
                /// Generar un PDF a partir de un comprobante y guardarlo en la carpeta predeterminada de comprobantes.
                /// </summary>
                public void GenerarPdf(Lbl.Comprobantes.ComprobanteConArticulos comprobante)
                {
                        var Generador = new Util.Comprobantes.GeneradorPdf(comprobante);

                        var Carpeta = System.IO.Path.Combine(Lbl.Sys.Config.CarpetaEmpresa, "Comprobantes", "PV" + comprobante.PV.ToString());

                        Lfx.Environment.Folders.EnsurePathExists(Carpeta);

                        Generador.GenerarYGuardar(System.IO.Path.Combine(Carpeta, comprobante.ToString() + ".pdf"));
                }


                /// <summary>
                /// Prepara el cliente de WS de AFIP, prueba el estado de los servicios y obtiene un ticket de acceso.
                /// </summary>
                /// <returns>SuccessOperationResult si todo salió bien.</returns>
                protected Lfx.Types.OperationResult IniciarWsAfip()
                {
                        // Inicio un cliente si es necesario
                        if (CliFe == null) {
                                CliFe = new Afip.Ws.FacturaElectronica.ServicioFacturaElectronica();
                        }

                        // Pruebo el estado de los servicios web
                        var Estado = CliFe.ProbarEstadoServicios();
                        if (Estado == false) {
                                return new Lfx.Types.FailureOperationResult("Los servicios web de AFIP no están funcionando");
                        }

                        // Si no estoy autenticado o la autenticación está vencida, pido un TA
                        if (CliFe.TieneTicketDeAccesoValido() == false) {
                                var CliWsass = new Afip.Ws.Autenticacion.ServicioAutenticacion();
                                CliWsass.RutaCertificado = System.IO.Path.Combine(Lbl.Sys.Config.CarpetaEmpresa, "AFIP", "Certificado.p12");
                                var TicketAcceso = CliWsass.Autenticar();

                                if (TicketAcceso == null) {
                                        return new Lfx.Types.FailureOperationResult("Error solicitando Ticket de Acceso a los servicios web de AFIP");
                                } else {
                                        CliFe.Cuit = Lbl.Sys.Config.Empresa.ClaveTributaria.ToString();
                                        CliFe.TicketAcceso = TicketAcceso;
                                }
                        }

                        return new Lfx.Types.SuccessOperationResult();
                }
        }
}