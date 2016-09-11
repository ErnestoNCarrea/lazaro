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

                        Lfx.Types.OperationResult ResultadoImprimir;
                        Lbl.Comprobantes.ComprobanteConArticulos ComprobConArt = comprobante as Lbl.Comprobantes.ComprobanteConArticulos;

                        switch (ClaseImpr) {
                                case Lbl.Impresion.ClasesImpresora.ElectronicaAfip:
                                        if(ComprobConArt == null) {
                                                throw new InvalidOperationException("El comprobante no es una factura");
                                        }
                                        if (Reimpresion) {
                                                this.GenerarPdf(ComprobConArt);
                                                return new Lfx.Types.SuccessOperationResult();
                                        } else {
                                                ResultadoImprimir = this.ImprimirFacturaElectronicaAfip(comprobante as Lbl.Comprobantes.ComprobanteConArticulos);
                                                if (ResultadoImprimir.Success == true) {
                                                        //Resto el stock si corresponde
                                                        ComprobConArt.MoverExistencias(false);

                                                        // Asentar pagos si corresponde
                                                        ComprobConArt.AsentarPago(false);
                                                }
                                                return ResultadoImprimir;
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
                                        if (Reimpresion == false && comprobante.Tipo.NumerarAlImprimir) {
                                                new Lbl.Comprobantes.Numerador(comprobante).Numerar(true);
                                        }

                                        if (Reimpresion == false) {
                                                //Resto el stock si corresponde
                                                ComprobConArt.MoverExistencias(false);

                                                // Asentar pagos si corresponde
                                                ComprobConArt.AsentarPago(false);
                                        }

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

                        var TipoComprob = Afip.Ws.FacturaElectronica.Tablas.ComprobantesTiposPorLetra[comprobante.Tipo.Nomenclatura];
                        var UltimoComprob = CliFe.UltimoComprobante(comprobante.PV, TipoComprob);

                        int ProximoNumero = UltimoComprob.CbteNro + 1;

                        var SolCae = Util.Comprobantes.ClienteAfipWsfe.CrearSolicitudCae(comprobante, ProximoNumero);

                        var CantidadImpresos = CliFe.SolictarCae(SolCae);
                        // TODO: tratamiento de errores

                        foreach(var Comprob in SolCae.Comprobantes) {
                                if(Comprob.Cae != null && string.IsNullOrWhiteSpace(Comprob.Cae.CodigoCae) == false) {
                                        new Lbl.Comprobantes.Numerador(comprobante).Numerar(Comprob.Numero, Comprob.Cae.CodigoCae, Comprob.Cae.Vencimiento, true);
                                        this.GenerarPdf(comprobante);
                                }
                        }

                        
                        if(CantidadImpresos > 0) {
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

                        var VariantePv = Lbl.Comprobantes.PuntoDeVenta.TodosPorNumero[comprobante.PV].Variante;
                        if (VariantePv > 0) {
                                Generador.Variante = (Util.Comprobantes.Variantes)VariantePv;
                        }

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
                        /* var Estado = CliFe.ProbarEstadoServicios();
                        if (Estado == false) {
                                return new Lfx.Types.FailureOperationResult("Los servicios web de AFIP no están funcionando");
                        } */

                        // Si no estoy autenticado o la autenticación está vencida, pido un TA
                        if (CliFe.TieneTicketDeAccesoValido() == false) {
                                var TicketAcceso = this.ObtenerTicketDeAcceso();

                                if (TicketAcceso == null) {
                                        return new Lfx.Types.FailureOperationResult("Error solicitando Ticket de Acceso a los servicios web de AFIP");
                                } else {
                                        CliFe.Cuit = Lbl.Sys.Config.Empresa.ClaveTributaria.ToString();
                                        CliFe.TicketAcceso = TicketAcceso;
                                }
                        }

                        return new Lfx.Types.SuccessOperationResult();
                }

                /// <summary>
                /// Guarda un ticket de acceso en la base de datos, para reusarlo mientras sea válido.
                /// </summary>
                protected void GuardarTicketDeAcceso(Afip.Ws.Autenticacion.TicketAcceso ta)
                {
                        try {
                                // Generar una cadena con el TA
                                var CadenaTa = ta.Token + "|lazaro_separador|" + ta.Sign + "|lazaro_separador|" + Lfx.Types.Formatting.FormatDateTimeSql(ta.GenerationTime) + "|lazaro_separador|" + Lfx.Types.Formatting.FormatDateTimeSql(ta.ExpirationTime);

                                // Escribirlo en un archivo en el disco
                                var RutaTa = System.IO.Path.Combine(Lfx.Environment.Folders.TemporaryFolder, "ticketacceso.dat");
                                System.IO.File.WriteAllText(RutaTa, CadenaTa);

                                // Guardarlo en la base de datos
                                Lfx.Workspace.Master.CurrentConfig.WriteGlobalSetting("AFIP.TicketAcceso", CadenaTa);
                        } catch { 
                                // Nada
                        }
                }

                /// <summary>
                /// Obtiene un ticket de acceso guardado en la base de datos o solicita uno nuevo a AFIP.
                /// </summary>
                /// <returns>Un ticket de acceso válido o null en caso de error.</returns>
                protected Afip.Ws.Autenticacion.TicketAcceso ObtenerTicketDeAcceso()
                {
                        var RutaTa = System.IO.Path.Combine(Lfx.Environment.Folders.TemporaryFolder, "ticketacceso.dat");

                        // Buscar un ticket guardado en un archivo local
                        if (System.IO.File.Exists(RutaTa)) {
                                // Existe un archivo... lo uso
                                var CadenaTaArchivo = System.IO.File.ReadAllText(RutaTa);
                                var TicketGuardadoEnArchivo = this.DecodificarTicketDeAcceso(CadenaTaArchivo);

                                if (TicketGuardadoEnArchivo != null && TicketGuardadoEnArchivo.EsValido()) {
                                        // El ticket todavía es válido... lo uso
                                        return TicketGuardadoEnArchivo;
                                }

                        }

                        // Buscar un ticket guardado en la base de datos
                        var CadenaDb = Lfx.Workspace.Master.CurrentConfig.ReadGlobalSetting<string>("AFIP.TicketAcceso", null);
                        var TicketGuardadoEnDb = this.DecodificarTicketDeAcceso(CadenaDb);
                        if (TicketGuardadoEnDb != null && TicketGuardadoEnDb.EsValido()) {
                                // El ticket todavía es válido... lo uso
                                return TicketGuardadoEnDb;
                        }

                        // Parece que no hay un ticket o ya no es válido. Pedir uno nuevo.
                        var CliWsass = new Afip.Ws.Autenticacion.ServicioAutenticacion();
                        CliWsass.RutaCertificado = System.IO.Path.Combine(Lbl.Sys.Config.CarpetaEmpresa, "AFIP", "Certificado.p12");
                        var Ta = CliWsass.Autenticar();

                        // Guardar el ticket para reusar
                        this.GuardarTicketDeAcceso(Ta);

                        return Ta;
                }

                protected Afip.Ws.Autenticacion.TicketAcceso DecodificarTicketDeAcceso(string cadenaTa)
                {
                        try {
                                if (string.IsNullOrWhiteSpace(cadenaTa) == false) {
                                        // Hay un ticket guardado en la configuración
                                        var Partes = cadenaTa.Split(new string[] { "|lazaro_separador|" }, StringSplitOptions.None);
                                        if (Partes.Length == 4) {
                                                var Ta = new Afip.Ws.Autenticacion.TicketAcceso();
                                                Ta.Token = Partes[0];
                                                Ta.Sign = Partes[1];
                                                Ta.GenerationTime = Lfx.Types.Parsing.ParseSqlDateTime(Partes[2]);
                                                Ta.ExpirationTime = Lfx.Types.Parsing.ParseSqlDateTime(Partes[3]);

                                                return Ta;
                                        }
                                }
                        } catch {
                                // Nada...
                        }

                        return null;
                }
        }
}