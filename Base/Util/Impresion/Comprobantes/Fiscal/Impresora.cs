using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Permissions;

namespace Lazaro.Base.Util.Impresion.Comprobantes.Fiscal
{
        public class Impresora
        {
                protected Lbl.Impresion.ModelosFiscales m_Modelo = Lbl.Impresion.ModelosFiscales.Desconocido;
                private Lbl.Comprobantes.PuntoDeVenta m_PuntoDeVenta = null;
                private System.Text.Encoding DefaultEncoding = System.Text.Encoding.GetEncoding(1252);

                private const int FIRST_SEQ = 0x20;
                private int SeqNum;
                private System.IO.Ports.SerialPort PuertoSerie = new System.IO.Ports.SerialPort();
                private Lfx.Workspace m_Workspace;
                private EstadoServidorFiscal m_EstadoServidor = EstadoServidorFiscal.Esperando;
                private System.Text.StringBuilder m_TextEmulacion;
                public Lfx.Data.IConnection DataBase;

                public event NotificacionEventHandler Notificacion;

                protected int m_LongitudMaximaDeLinea = 20;

                public Impresora(Lfx.Workspace workspace)
                {
                        Lfx.Workspace.Master = workspace;
                        this.DataBase = Lfx.Workspace.Master.GetNewConnection("Servidor fiscal") as Lfx.Data.Connection;
                        m_EstadoServidor = EstadoServidorFiscal.Esperando;
                }

                ~Impresora()
                {
                        this.Terminar();
                }


                public Lbl.Impresion.ModelosFiscales Modelo
                {
                        get
                        {
                                return m_Modelo;
                        }
                        set
                        {
                                this.m_Modelo = value;
                                switch(this.m_Modelo) {
                                        case Lbl.Impresion.ModelosFiscales.HasarTiquedora:
                                                m_LongitudMaximaDeLinea = 20;
                                                break;
                                        default:
                                                m_LongitudMaximaDeLinea = 50;
                                                break;
                                }
                        }
                }


                public Lbl.Comprobantes.PuntoDeVenta PuntoDeVenta
                {
                        get
                        {
                                return m_PuntoDeVenta;
                        }
                        set
                        {
                                m_PuntoDeVenta = value;
                                if (value != null) {
                                        if (this.PuertoSerie.IsOpen) {
                                                this.PuertoSerie.Close();
                                                System.Threading.Thread.Sleep(100);
                                        }

                                        this.Modelo = m_PuntoDeVenta.FiscalModeloImpresora;
                                        this.PuertoSerie.PortName = "COM" + m_PuntoDeVenta.FiscalPuerto;
                                        if (m_PuntoDeVenta.FiscalBps == 0)
                                                this.PuertoSerie.BaudRate = 9600;
                                        else
                                                this.PuertoSerie.BaudRate = m_PuntoDeVenta.FiscalBps;
                                }
                        }
                }


                public int NumeroPV
                {
                        get
                        {
                                if (this.PuntoDeVenta == null)
                                        return 0;
                                else
                                        return this.PuntoDeVenta.Numero;
                        }
                }

                public string NombreModelo
                {
                        get
                        {
                                switch (this.Modelo) {
                                        case Lbl.Impresion.ModelosFiscales.EpsonTiquedora:
                                        case Lbl.Impresion.ModelosFiscales.EpsonGenerico:
                                                return "Epson genérico";
                                        case Lbl.Impresion.ModelosFiscales.HasarTiquedora:
                                        case Lbl.Impresion.ModelosFiscales.HasarGenerico:
                                                return "Hasar genérico";
                                        case Lbl.Impresion.ModelosFiscales.Emulacion:
                                                return "Emulación";
                                        default:
                                                return "Desconocido";
                                }
                        }
                }

                public void Terminar()
                {
                        this.Cerrar();
                        this.DataBase.Dispose();
                }

                public void Cerrar()
                {
                        switch (Modelo) {
                                case Lbl.Impresion.ModelosFiscales.Emulacion:
                                        m_TextEmulacion = null;
                                        break;
                                default:
                                        if (PuertoSerie != null && PuertoSerie.IsOpen)
                                                PuertoSerie.Close();
                                        break;
                        }
                }

                public Lazaro.Base.Util.Impresion.Comprobantes.Fiscal.Respuesta Inicializar()
                {
                        switch (Modelo) {
                                case Lbl.Impresion.ModelosFiscales.Emulacion:
                                        if (m_TextEmulacion == null) {
                                                m_TextEmulacion = new System.Text.StringBuilder("Emulación iniciada" + System.Environment.NewLine);
                                                NotificacionEventHandler NotifHandler = Notificacion;
                                                if (NotifHandler != null)
                                                        NotifHandler(this, new ImpresoraEventArgs(ImpresoraEventArgs.EventTypes.Inicializada));
                                        }
                                        break;
                                default:
                                        if (PuertoSerie.IsOpen == false) {
                                                PuertoSerie.ReadTimeout = 8000;
                                                PuertoSerie.WriteTimeout = 5000;
                                                PuertoSerie.DataBits = 8;
                                                PuertoSerie.StopBits = System.IO.Ports.StopBits.One;
                                                PuertoSerie.Parity = System.IO.Ports.Parity.None;
                                                PuertoSerie.Encoding = DefaultEncoding;
                                                SeqNum = FIRST_SEQ;

                                                if (Modelo != Lbl.Impresion.ModelosFiscales.HasarGenerico && Modelo != Lbl.Impresion.ModelosFiscales.HasarTiquedora) {
                                                        PuertoSerie.Handshake = System.IO.Ports.Handshake.XOnXOff;
                                                        PuertoSerie.RtsEnable = true;
                                                }

                                                try {
                                                        PuertoSerie.Open();
                                                } catch (Exception ex) {
                                                        Respuesta Res = new Respuesta(ErroresFiscales.Error);
                                                        Res.Lugar = "Fiscal.ConexionImpresora.Inicializar()";
                                                        Res.Mensaje = ex.ToString();
                                                        return Res;
                                                }

                                                PuertoSerie.PinChanged += new System.IO.Ports.SerialPinChangedEventHandler(Impresora_PinChanged);
                                                PuertoSerie.ErrorReceived += new System.IO.Ports.SerialErrorReceivedEventHandler(Impresora_ErrorReceived);

                                                if (Modelo == Lbl.Impresion.ModelosFiscales.HasarGenerico || Modelo == Lbl.Impresion.ModelosFiscales.HasarTiquedora) {
                                                        System.Threading.Thread.Sleep(100);
                                                        //Configuración inicial Hasar
                                                        Lazaro.Base.Util.Impresion.Comprobantes.Fiscal.Respuesta Res = ObtenerEstadoImpresora();

                                                        if (Res.EstadoFiscal.DocumentoFiscalAbierto)
                                                                Res = CancelarDocumentoFiscal();
                                                        else if (Res.EstadoFiscal.DocumentoAbierto)
                                                                Res = CancelarDocumentoFiscal();

                                                }

                                                NotificacionEventHandler NotifHandler = Notificacion;
                                                if (NotifHandler != null)
                                                        NotifHandler(this, new ImpresoraEventArgs(ImpresoraEventArgs.EventTypes.Inicializada));
                                        }
                                        break;
                        }

                        return new Respuesta(ErroresFiscales.Ok);
                }

                void Impresora_ErrorReceived(object sender, System.IO.Ports.SerialErrorReceivedEventArgs e)
                {
                        System.Threading.Thread.Sleep(40);
                }

                void Impresora_PinChanged(object sender, System.IO.Ports.SerialPinChangedEventArgs e)
                {
                        System.Threading.Thread.Sleep(40);
                }

                public EstadoServidorFiscal EstadoServidor
                {
                        get
                        {
                                return m_EstadoServidor;
                        }
                        set
                        {
                                m_EstadoServidor = value;
                        }
                }

                public string PortName
                {
                        get
                        {
                                return PuertoSerie.PortName;
                        }
                }

                public int BaudRate
                {
                        get
                        {
                                return PuertoSerie.BaudRate;
                        }
                }

                public Lfx.Workspace Workspace
                {
                        get
                        {
                                return m_Workspace;
                        }
                        set
                        {
                                m_Workspace = value;
                        }
                }

                public Lazaro.Base.Util.Impresion.Comprobantes.Fiscal.Respuesta Cierre(string Tipo, bool Imprimir)
                {
                        switch (Modelo) {
                                case Lbl.Impresion.ModelosFiscales.EpsonTiquedora:
                                case Lbl.Impresion.ModelosFiscales.EpsonGenerico:
                                case Lbl.Impresion.ModelosFiscales.Emulacion:
                                        string ParametroImprimir = "N";

                                        if (Imprimir)
                                                ParametroImprimir = "P";

                                        return Enviar(new Comando(CodigosComandosFiscales.EpsonCierreJornada, Tipo, ParametroImprimir));
                                case Lbl.Impresion.ModelosFiscales.HasarTiquedora:
                                case Lbl.Impresion.ModelosFiscales.HasarGenerico:
                                        return Enviar(new Comando(CodigosComandosFiscales.HasarCierreJornada, Tipo));
                        }

                        return new Lazaro.Base.Util.Impresion.Comprobantes.Fiscal.Respuesta(ErroresFiscales.Error);
                }

                public Lazaro.Base.Util.Impresion.Comprobantes.Fiscal.Respuesta CancelarDocumentoFiscal()
                {
                        switch (Modelo) {
                                case Lbl.Impresion.ModelosFiscales.EpsonTiquedora:
                                case Lbl.Impresion.ModelosFiscales.EpsonGenerico:
                                case Lbl.Impresion.ModelosFiscales.Emulacion:
                                        return Enviar(new Comando(CodigosComandosFiscales.EpsonDocumentoFiscalPagosYDescuentos, "Cancelando", "000010000", "C"));
                                case Lbl.Impresion.ModelosFiscales.HasarTiquedora:
                                case Lbl.Impresion.ModelosFiscales.HasarGenerico:
                                        return Enviar(new Comando(CodigosComandosFiscales.HasarDocumentoFiscalCancelar));
                        }

                        return new Lazaro.Base.Util.Impresion.Comprobantes.Fiscal.Respuesta();
                }

                [EnvironmentPermissionAttribute(SecurityAction.LinkDemand, Unrestricted = true)]
                public Lazaro.Base.Util.Impresion.Comprobantes.Fiscal.Respuesta ImprimirComprobante(int idComprob)
                {
                        try {
                                using (System.Diagnostics.Process Yo = System.Diagnostics.Process.GetCurrentProcess()) {
                                        Yo.PriorityClass = System.Diagnostics.ProcessPriorityClass.AboveNormal;
                                }
                        } catch {
                                // No siempre puedo elevar mi propia prioridad (creo que sólo en Windows XP o en Vista/7 sin UAC)
                        }

                        // *** Inicializar la impresora fiscal
                        Lazaro.Base.Util.Impresion.Comprobantes.Fiscal.Respuesta Res = this.Inicializar();

                        if (Res.Error != ErroresFiscales.Ok)
                                return Res;

                        NotificacionEventHandler NotifHandler = Notificacion;
                        if (NotifHandler != null)
                                NotifHandler(this, new ImpresoraEventArgs(ImpresoraEventArgs.EventTypes.InicioImpresion));

                        // *** Obtener datos previos
                        Lbl.Comprobantes.ComprobanteConArticulos Comprob = new Lbl.Comprobantes.ComprobanteConArticulos(DataBase, idComprob);

                        if (Comprob.Impreso)
                                return new Respuesta(ErroresFiscales.Ok);

                        string TipoDocumento = null;
                        string Letra = null;

                        switch (Modelo) {
                                case Lbl.Impresion.ModelosFiscales.EpsonTiquedora:
                                        if (Comprob.Tipo.EsNotaDebito) {
                                                TipoDocumento = "D";
                                        } else if (Comprob.Tipo.EsNotaCredito) {
                                                TipoDocumento = "M";
                                        } else {
                                                TipoDocumento = "T";
                                        }
                                        break;
                                default:

                                        if (Comprob.Tipo.EsNotaDebito) {
                                                TipoDocumento = "D";
                                        } else if (Comprob.Tipo.EsNotaCredito) {
                                                TipoDocumento = "C";
                                        } else if (Comprob.Tipo.EsTicket) {
                                                TipoDocumento = "T";
                                        } else {
                                                TipoDocumento = "F";
                                        }
                                        break;
                        }

                        switch (Comprob.Tipo.Nomenclatura) {
                                case "FM":
                                case "NDM":
                                case "NCM":
                                        Letra = "M";
                                        break;
                                case "FA":
                                case "NDA":
                                        Letra = "A";
                                        break;
                                case "NCA":
                                        if (Modelo == Lbl.Impresion.ModelosFiscales.HasarTiquedora)
                                                Letra = "R";
                                        else
                                                Letra = "A";
                                        break;

                                case "FB":
                                case "NDB":
                                        Letra = "B";
                                        break;
                                case "NCB":
                                        if (Modelo == Lbl.Impresion.ModelosFiscales.HasarTiquedora)
                                                Letra = "S";
                                        else
                                                Letra = "B";
                                        break;

                                case "FC":
                                case "NDC":
                                        Letra = "C";
                                        break;
                                case "NCC":
                                        if (Modelo == Lbl.Impresion.ModelosFiscales.HasarTiquedora)
                                                Letra = "S";
                                        else
                                                Letra = "C";
                                        break;

                                case "FE":
                                case "NDE":
                                case "NCE":
                                        Letra = "E";
                                        break;
                        }

                        string ClienteTipoDoc = "DNI";
                        string ClienteNumDoc = Comprob.Cliente.NumeroDocumento.Replace("-", "").Replace(".", "");

                        if (Comprob.Cliente.TipoDocumento != null) {
                                switch (Comprob.Cliente.TipoDocumento.Id) {
                                        case 1:
                                                ClienteTipoDoc = "DNI";
                                                break;
                                        case 2:
                                                ClienteTipoDoc = "LE";
                                                break;
                                        case 3:
                                                ClienteTipoDoc = "LC";
                                                break;
                                        case 4:
                                                ClienteTipoDoc = "CI";
                                                break;
                                        case 5:
                                                if (ClienteNumDoc.Length > 0)
                                                        ClienteTipoDoc = "CUIL";
                                                break;
                                        case 6:
                                                if (ClienteNumDoc.Length > 0)
                                                        ClienteTipoDoc = "CUIT";
                                                break;
                                        default:
                                                ClienteTipoDoc = "DNI";
                                                break;
                                }
                        }

                        if (Comprob.Cliente.SituacionTributaria != null) {
                                switch (Comprob.Cliente.SituacionTributaria.Id) {
                                        case 1:
                                                ClienteNumDoc = Comprob.Cliente.NumeroDocumento.Replace("-", "").Replace(" ", "").Replace(".", "");
                                                ClienteTipoDoc = "DNI";
                                                break;
                                        case 2:
                                                ClienteTipoDoc = "CUIT";
                                                ClienteNumDoc = Comprob.Cliente.ClaveTributaria.ToString().Replace("-", "");
                                                break;
                                        case 3:
                                                ClienteTipoDoc = "CUIT";
                                                ClienteNumDoc = Comprob.Cliente.ClaveTributaria.ToString().Replace("-", "");
                                                break;
                                        case 4:
                                                ClienteTipoDoc = "CUIT";
                                                ClienteNumDoc = Comprob.Cliente.ClaveTributaria.ToString().Replace("-", "");
                                                break;
                                        case 5:
                                                ClienteTipoDoc = "CUIT";
                                                ClienteNumDoc = Comprob.Cliente.ClaveTributaria.ToString().Replace("-", "");
                                                break;
                                }
                        }

                        Comando ComandoAEnviar;

                        string TextoRemitoLinea1 = "";
                        string TextoRemitoLinea2 = "";

                        if (Comprob.IdRemito == 0) {
                                if (Comprob.Obs == null) {
                                        TextoRemitoLinea1 = "";
                                } else if (Comprob.Obs.Length > 40) {
                                        TextoRemitoLinea1 = Comprob.Obs.Substring(0, 40);
                                        int RestoObs = Comprob.Obs.Length - 40;
                                        if (RestoObs > 40)
                                                RestoObs = 40;
                                        TextoRemitoLinea2 = Comprob.Obs.Substring(40, RestoObs);
                                } else {
                                        TextoRemitoLinea1 = Comprob.Obs;
                                }
                        } else {
                                TextoRemitoLinea1 = "Remito(s) " + Comprob.IdRemito.ToString();
                        }

                        string Domicilio = Comprob.Cliente.Domicilio;
                        string ClienteLocalidad = "";
                        if (Comprob.Cliente.Localidad != null)
                                ClienteLocalidad = Comprob.Cliente.Localidad.ToString();

                        //si hay un documento abierto (fiscal, no fiscal o no fiscal homologado) lo cancelo
                        Res = ObtenerEstadoImpresora();
                        if (Res.EstadoFiscal.DocumentoAbierto) {
                                Res = CancelarDocumentoFiscal();
                                System.Threading.Thread.Sleep(500);
                        }
                        // *** Abrir Documento
                        if (NotifHandler != null)
                                NotifHandler(this, new ImpresoraEventArgs("Abrir documento fiscal"));

                        switch (Modelo) {
                                case Lbl.Impresion.ModelosFiscales.EpsonTiquedora:
                                case Lbl.Impresion.ModelosFiscales.EpsonGenerico:
                                case Lbl.Impresion.ModelosFiscales.Emulacion:
                                        string ClienteLinea1 = "";
                                        string ClienteLinea2 = "";

                                        if (Comprob.Cliente.ToString().Length > 40) {
                                                ClienteLinea1 = Comprob.Cliente.ToString().Substring(0, 40);
                                                ClienteLinea2 = Comprob.Cliente.ToString().Substring(40, Comprob.Cliente.ToString().Length - 40);
                                        } else {
                                                ClienteLinea1 = Comprob.Cliente.ToString();
                                                ClienteLinea2 = "";
                                        }

                                        if (Domicilio.Length > 40)
                                                Domicilio = Domicilio.Substring(0, 40);

                                        if (ClienteLocalidad.Length > 40)
                                                ClienteLocalidad = ClienteLocalidad.Substring(0, 40);

                                        string ClienteSituacionEpson = "";
                                        switch (Comprob.Cliente.SituacionTributaria.Id) {
                                                case 1:
                                                        ClienteSituacionEpson = "F";
                                                        break;
                                                case 2:
                                                        ClienteSituacionEpson = "I";
                                                        break;
                                                case 3:
                                                        ClienteSituacionEpson = "R";
                                                        break;
                                                case 4:
                                                        ClienteSituacionEpson = "M";
                                                        break;
                                                case 5:
                                                        ClienteSituacionEpson = "E";
                                                        break;
                                                default:
                                                        ClienteSituacionEpson = "S";
                                                        break;
                                        }
                                        if (Modelo == Lbl.Impresion.ModelosFiscales.EpsonTiquedora) {
                                                // La impresora epson TMU220 no acepta vacios por eso cambio por un punto.
                                                string Vacio=".";
                                                        if (TextoRemitoLinea1=="")
                                                        TextoRemitoLinea1 = ".";
                                                        if (TextoRemitoLinea2 == "")
                                                        TextoRemitoLinea2 = ".";
                                                
                                                ComandoAEnviar = new Comando(CodigosComandosFiscales.EpsonDocumentoFiscalAbrir,
                                                         TipoDocumento,
                                                         "C",
                                                         Letra,
                                                         "1",
                                                         "P",
                                                         "10",
                                                         "I",
                                                        FiscalizarTexto(ClienteSituacionEpson),
                                                        FiscalizarTexto(ClienteLinea1),
                                                        FiscalizarTexto(ClienteLinea2),
                                                        FiscalizarTexto(ClienteTipoDoc),
                                                        FiscalizarTexto(ClienteNumDoc),
                                                        "N",
                                                        FiscalizarTexto(Domicilio),
                                                        FiscalizarTexto(ClienteLocalidad),
                                                        Vacio,
                                                        FiscalizarTexto(TextoRemitoLinea1),
                                                        FiscalizarTexto(TextoRemitoLinea2),
                                                        "C");
                                        } else {
                                                ComandoAEnviar = new Comando(CodigosComandosFiscales.EpsonDocumentoFiscalAbrir,
                                                        TipoDocumento,
                                                        "C",
                                                        Letra,
                                                        "1",
                                                        "F",
                                                        "12",
                                                        "I",
                                                        FiscalizarTexto(ClienteSituacionEpson),
                                                        FiscalizarTexto(ClienteLinea1),
                                                        FiscalizarTexto(ClienteLinea2),
                                                        FiscalizarTexto(ClienteTipoDoc),
                                                        FiscalizarTexto(ClienteNumDoc),
                                                        "N",
                                                        FiscalizarTexto(Domicilio),
                                                        FiscalizarTexto(ClienteLocalidad),
                                                        "",
                                                        FiscalizarTexto(TextoRemitoLinea1),
                                                        FiscalizarTexto(TextoRemitoLinea2),
                                                        "C");
                                        }
                                                Res = Enviar(ComandoAEnviar);
                                        
                                        break;

                                case Lbl.Impresion.ModelosFiscales.HasarTiquedora:
                                case Lbl.Impresion.ModelosFiscales.HasarGenerico:
                                        if (Comprob.Cliente.Id != 999) {
                                                //Sólo envío comando SetCustomerData (HasarDocumentoSetDatosCliente)
                                                //si el cliente NO es consumidor final
                                                string ClienteSituacionHasar = "";
                                                switch (Comprob.Cliente.SituacionTributaria.Id) {
                                                        case 1:
                                                                ClienteSituacionHasar = "C";
                                                                break;
                                                        case 2:
                                                                ClienteSituacionHasar = "I";
                                                                break;
                                                        case 3:
                                                                // No existente en los modelos SMH/P- 715F, SMH/P-PR5F, SMH/P-441F y SMH/P-451F 
                                                                ClienteSituacionHasar = "N";
                                                                break;
                                                        case 4:
                                                                // No existente en el modelo SMH/P-PR4F
                                                                ClienteSituacionHasar = "M";
                                                                break;
                                                        case 5:
                                                                ClienteSituacionHasar = "E";
                                                                break;
                                                        case 6:
                                                                ClienteSituacionHasar = "A";
                                                                break;
                                                        case 7:
                                                                ClienteSituacionHasar = "T";
                                                                break;
                                                }

                                                string TipoDocumentoClienteHasar = " ";
                                                switch (ClienteTipoDoc) {
                                                        case "CUIT":
                                                                TipoDocumentoClienteHasar = "C";
                                                                break;
                                                        case "CUIL":
                                                                TipoDocumentoClienteHasar = "L";
                                                                break;
                                                        case "LE":
                                                                TipoDocumentoClienteHasar = "0";
                                                                break;
                                                        case "LC":
                                                                TipoDocumentoClienteHasar = "1";
                                                                break;
                                                        case "DNI":
                                                                TipoDocumentoClienteHasar = "2";
                                                                break;
                                                        case "PP":
                                                                TipoDocumentoClienteHasar = "3";
                                                                break;
                                                        case "CI":
                                                                TipoDocumentoClienteHasar = "4";
                                                                break;
                                                        default:
                                                                TipoDocumentoClienteHasar = " ";// Sin clasificador
                                                                break;
                                                }

                                                string NombreClienteHasar = Comprob.Cliente.ToString();
                                                // Comando  SetCustomerData (Manual Comandos Hasar)
                                                ComandoAEnviar = new Comando(CodigosComandosFiscales.HasarDocumentoSetDatosCliente,
                                                        FiscalizarTexto(NombreClienteHasar, 30),
                                                        ClienteNumDoc,
                                                        ClienteSituacionHasar,
                                                        TipoDocumentoClienteHasar,
                                                        FiscalizarTexto(Domicilio, 40));
                                                Res = Enviar(ComandoAEnviar);
                                        }

                                        //Abrir documento   

                                        string TipoDocumentoHasar = "B";
                                        if (TipoDocumento == "D" && Letra == "A")
                                                TipoDocumentoHasar = "D";	//ND A
                                        else if (TipoDocumento == "D")
                                                TipoDocumentoHasar = "E";	//ND B Y C
                                        else if (TipoDocumento == "F" && Letra == "A")
                                                TipoDocumentoHasar = "A";	//Fac A
                                        else if (TipoDocumento == "F")
                                                TipoDocumentoHasar = "B";	//Fac B y C
                                        else if (TipoDocumento == "T")
                                                TipoDocumentoHasar = "T";	//Ticket


                                        if (Modelo == Lbl.Impresion.ModelosFiscales.HasarTiquedora) {
                                                string NombreFantasiaHasar = Lbl.Sys.Config.Empresa.Nombre.ToUpper();
                                                int EspaciosParaCentrado = NombreFantasiaHasar.Length;
                                                int EspaciosAIncertar;
                                                Comando EstablecerTituloTiquet;
                                                if (NombreFantasiaHasar.Length <= 20) {
                                                        if (NombreFantasiaHasar.Length >= 19) {
                                                                // El caracter especial ô indica que la imprecion debe ser con doble ancho, en dicho caso La cantidad maxima de caracteres se reduce de 40 a 20 
                                                                EstablecerTituloTiquet = new Comando(CodigosComandosFiscales.HasarDocumentoFiscalNombreFantasia,
                                                                "2",
                                                                'ô' + NombreFantasiaHasar);
                                                                Res = Enviar(EstablecerTituloTiquet);
                                                        }
                                                        if (NombreFantasiaHasar.Length < 19) {
                                                                EspaciosParaCentrado = (20 - NombreFantasiaHasar.Length) / 2;
                                                                EspaciosAIncertar = NombreFantasiaHasar.Length + EspaciosParaCentrado;
                                                                NombreFantasiaHasar = NombreFantasiaHasar.PadLeft(EspaciosAIncertar, ' ');
                                                                // El caracter especial ô indica que la imprecion debe ser con doble ancho, en dicho caso La cantidad maxima de caracteres se reduce de 40 a 20 
                                                                EstablecerTituloTiquet = new Comando(CodigosComandosFiscales.HasarDocumentoFiscalNombreFantasia,
                                                                "2",
                                                                'ô' + NombreFantasiaHasar);
                                                                Res = Enviar(EstablecerTituloTiquet);
                                                        }


                                                } else {
                                                        EstablecerTituloTiquet = new Comando(CodigosComandosFiscales.HasarDocumentoFiscalNombreFantasia,
                                                                        "2",
                                                                        NombreFantasiaHasar);
                                                        Res = Enviar(EstablecerTituloTiquet);

                                                }


                                                //N° de línea de encabezamiento (1-10) o cola (11-20)
                                                //0: borra encabezamiento y cola,  -1: borra encabezamiento,  -2: borra cola. 
                                                Comando EstablecerEncabezadoCola = new Comando(CodigosComandosFiscales.HasarDocumentoEstablecerEncabezadoCola,
                                                                "12",
                                                                "        Gracias por su compra");
                                                Res = Enviar(EstablecerEncabezadoCola);
                                        }

                                        if (Letra == "S" || Letra == "R") {
                                                // Para notas de Crédito primero tengo que acentar los datos del comprobante original y luego abrir el documento 
                                                string ComprobanteOriginal = Comprob.ComprobanteOriginal.Nombre;
                                                string[] partes = ComprobanteOriginal.Split(new char[] { '-' });
                                                ComprobanteOriginal = partes[1];
                                                // El segundo parámetro corresponde al numero de línea donde se va a imprimir la información del comprobante original 
                                                // 0: Borra ambas líneas
                                                Comando ComandoEnviar = new Comando(CodigosComandosFiscales.HasarDocumentoFiscalCargarComprobanteOriginal, "1",
                                                          ComprobanteOriginal);
                                                Res = Enviar(ComandoEnviar);

                                                ComandoEnviar = new Comando(CodigosComandosFiscales.HasarDocumentoNoFiscalHomologadoAbrir, Letra, "T"
                                                        );
                                                Res = Enviar(ComandoEnviar);


                                        } else {
                                                // El segundo parámetro corresponde al numero de línea donde se va a imprimir la información del comprobante original 
                                                // 0: Borra ambas líneas
                                                // Borro cualquier línea que haya quedado de una nota de crédito anterior 
                                                Comando ComandoEnviar = new Comando(CodigosComandosFiscales.HasarDocumentoFiscalCargarComprobanteOriginal, "0",
                                                          "1234");
                                                Res = Enviar(ComandoEnviar);
                                                // Comando OpenFiscalReceipt (Manual de comandos Hasar) 
                                                ComandoAEnviar = new Comando(CodigosComandosFiscales.HasarDocumentoFiscalAbrir,
                                                        TipoDocumentoHasar,
                                                        "T");
                                                Res = Enviar(ComandoAEnviar);
                                        }
                                        break;
                        }

                        if (Res.Error != ErroresFiscales.Ok) {
                                Res.Lugar = "DocumentoFiscalAbrir";
                                return Res;
                        }

                        // *** Imprimir Detalles
                        foreach (Lbl.Comprobantes.DetalleArticulo Detalle in Comprob.Articulos) {
                                string StrCodigo = Lfx.Workspace.Master.CurrentConfig.Productos.CodigoPredeterminado();

                                if (Detalle.Articulo != null) {
                                        if (StrCodigo == "id_articulo")
                                                StrCodigo = Detalle.Articulo.Id.ToString();
                                        else
                                                StrCodigo = DataBase.FieldString("SELECT " + StrCodigo + " FROM articulos WHERE id_articulo=" + Detalle.Articulo.Id.ToString());
                                }

                                if (StrCodigo.Length > 0)
                                        StrCodigo = "(" + StrCodigo + ") ";

                                decimal Cantidad = Detalle.Cantidad;
                                decimal Unitario = Detalle.ImporteUnitarioFinalAImprimir;
                                decimal PctIva = 0;
                                if (Comprob.Cliente.PagaIva == Lbl.Impuestos.SituacionIva.Exento) {
                                        PctIva = 0;
                                } else {
                                        var Alicuota = Detalle.Alicuota;
                                        if (Alicuota != null) {
                                                PctIva = Alicuota.Porcentaje;
                                        }
                                }

                                //Si es cantidad negativa, pongo precio negativo y cantidad positiva
                                if (Cantidad < 0) {
                                        Cantidad = -Cantidad;
                                        Unitario = -Unitario;
                                }

                                string ItemNombre = Detalle.Nombre;
                                string ParametroSumaResta;
                                switch (Modelo) {
                                        case Lbl.Impresion.ModelosFiscales.EpsonTiquedora:
                                                ParametroSumaResta = "M";
                                                if (Unitario < 0)
                                                        ParametroSumaResta = "R";
                                                
                                                ComandoAEnviar = new Comando(CodigosComandosFiscales.EpsonDocumentoFiscalItem,
                                                        FiscalizarTexto(ItemNombre,18),
                                                        FormatearNumeroEpson(Cantidad, 3).PadLeft(8, '0'),
                                                        FormatearNumeroEpson(Math.Abs(Unitario), 2).PadLeft(9, '0'),
                                                        FormatearNumeroEpson(PctIva, 2).PadLeft(4, '0'), /* IVA */
                                                        ParametroSumaResta,
                                                        "00001",
                                                        "00000000",
                                                        "",
                                                        "",
                                                        "",
                                                        "0000",
                                                        "000000000000000");
                                                Res = Enviar(ComandoAEnviar);
                                                Res = Enviar(new Comando(CodigosComandosFiscales.EpsonDocumentoFiscalSubtotal, "P", ""));
                                                break;

                                        case Lbl.Impresion.ModelosFiscales.EpsonGenerico:
                                        case Lbl.Impresion.ModelosFiscales.Emulacion:
                                                ParametroSumaResta = "M";
                                                if (Unitario < 0)
                                                        ParametroSumaResta = "R";

                                                ComandoAEnviar = new Comando(CodigosComandosFiscales.EpsonDocumentoFiscalItem,
                                                        FiscalizarTexto(ItemNombre).PadRight(54).Substring(0, 54),
                                                        FormatearNumeroEpson(Cantidad, 3).PadLeft(8, '0'),
                                                        FormatearNumeroEpson(Math.Abs(Unitario), 2).PadLeft(9, '0'),
                                                        FormatearNumeroEpson(PctIva, 2).PadLeft(4, '0'), /* IVA */
                                                        ParametroSumaResta,
                                                        "00001",
                                                        "00000000",
                                                        "",
                                                        "",
                                                        "",
                                                        "0000",
                                                        "000000000000000");
                                                Res = Enviar(ComandoAEnviar);
                                                
                                                break;

                                        case Lbl.Impresion.ModelosFiscales.HasarTiquedora:
                                        case Lbl.Impresion.ModelosFiscales.HasarGenerico:
                                                if (Detalle.DatosSeguimiento != null && Detalle.DatosSeguimiento.Count > 0) {
                                                        ComandoAEnviar = new Comando(CodigosComandosFiscales.HasarDocumentoFiscalTexto,
                                                                FiscalizarTexto(Detalle.DatosSeguimiento.ToString(), m_LongitudMaximaDeLinea),
                                                                "0"
                                                                );
                                                        Res = Enviar(ComandoAEnviar);
                                                        if (Res.Error != ErroresFiscales.Ok) {
                                                                Res.Lugar = "DocumentoFiscalText";
                                                                return Res;
                                                        }
                                                }

                                                if (Unitario < 0) {
                                                        ComandoAEnviar = new Comando(CodigosComandosFiscales.HasarDocumentoFiscalDescuentoGeneral,
                                                                FiscalizarTexto(ItemNombre, m_LongitudMaximaDeLinea),
                                                                FormatearNumeroHasar(Math.Abs(Unitario), 2),
                                                                "m",
                                                                "0",
                                                                "T");
                                                } else {
                                                        ComandoAEnviar = new Comando(CodigosComandosFiscales.HasarDocumentoFiscalItem,
                                                                FiscalizarTexto(ItemNombre, m_LongitudMaximaDeLinea),
                                                                FormatearNumeroHasar(Cantidad, 2),
                                                                FormatearNumeroHasar(Unitario, 2),
                                                                FormatearNumeroHasar(PctIva, 2), /* IVA */
                                                                "M",
                                                                "0.0", /* Impuestos Interno s */
                                                                "0", /* Campo Display */
                                                                Comprob.Tipo.DiscriminaIva ? "B"  : "T" /* Precio total o base */
                                                                );
                                                }
                                                Res = Enviar(ComandoAEnviar);
                                                break;
                                }

                                if (Res.Error != ErroresFiscales.Ok) {
                                        Res.Lugar = "DocumentoFiscalItem";
                                        return Res;
                                }
                        }

                        // Calculo el total real, tomando en cuenta el redondeo y los decimales
                        if (Comprob.Descuento > 0) {
                                decimal MontoDescuento = Comprob.Subtotal * (Comprob.Descuento / 100);

                                switch (Modelo) {
                                        case Lbl.Impresion.ModelosFiscales.EpsonTiquedora:
                                        case Lbl.Impresion.ModelosFiscales.EpsonGenerico:
                                        case Lbl.Impresion.ModelosFiscales.Emulacion:
                                                ComandoAEnviar = new Comando(CodigosComandosFiscales.EpsonDocumentoFiscalPagosYDescuentos,
                                                        "Descuento " + Lfx.Types.Formatting.FormatCurrencyForPrint(Comprob.Descuento, 2) + "%",
                                                        FormatearNumeroEpson(MontoDescuento, 2).PadLeft(12, '0'),
                                                        "D");
                                                Res = Enviar(ComandoAEnviar);
                                                break;

                                        case Lbl.Impresion.ModelosFiscales.HasarTiquedora:
                                        case Lbl.Impresion.ModelosFiscales.HasarGenerico:
                                                ComandoAEnviar = new Comando(CodigosComandosFiscales.HasarDocumentoFiscalDescuentoGeneral,
                                                        "Descuento " + Lfx.Types.Formatting.FormatCurrencyForPrint(Comprob.Descuento, 2) + "%",
                                                        FormatearNumeroHasar(MontoDescuento, 2),
                                                        "m",
                                                        "0",
                                                        "B");
                                                Res = Enviar(ComandoAEnviar);
                                                break;
                                }

                                if (Res.Error != ErroresFiscales.Ok) {
                                        Res.Lugar = "DocumentoFiscalPagosYDescuentos:Descuento";
                                        return Res;
                                }
                        }

                        if (Math.Abs(Comprob.TotalSinRedondeo - Comprob.Total) >= 0.001m) {
                                switch (Modelo) {
                                        case Lbl.Impresion.ModelosFiscales.EpsonTiquedora:
                                        case Lbl.Impresion.ModelosFiscales.EpsonGenerico:
                                        case Lbl.Impresion.ModelosFiscales.Emulacion:
                                                ComandoAEnviar = new Comando(CodigosComandosFiscales.EpsonDocumentoFiscalPagosYDescuentos,
                                                        "Ajustes por Redondeo",
                                                        FormatearNumeroEpson((Comprob.Total - Comprob.TotalSinRedondeo), 2).PadLeft(12, '0'),
                                                        "D");
                                                Res = Enviar(ComandoAEnviar);
                                                break;

                                        case Lbl.Impresion.ModelosFiscales.HasarTiquedora:
                                        case Lbl.Impresion.ModelosFiscales.HasarGenerico:
                                                ComandoAEnviar = new Comando(CodigosComandosFiscales.HasarDocumentoFiscalDescuentoGeneral,
                                                        "Ajustes por Redondeo",
                                                        FormatearNumeroHasar((Comprob.Total - Comprob.TotalSinRedondeo), 2),
                                                        "m",
                                                        "0",
                                                        "B");
                                                Res = Enviar(ComandoAEnviar);
                                                break;
                                }

                                if (Res.Error != ErroresFiscales.Ok) {
                                        // Error, pero continúo
                                        // Res.Lugar = "DocumentoFiscalPagosYDescuentos:Redondeo"
                                        // If Not (OFormFiscalEstado Is Nothing) Then OFormFiscalEstado.Listo()
                                        // Return Res
                                }
                        }

                        //Recargos
                        if (Comprob.Recargo > 0) {
                                switch (Modelo) {
                                        case Lbl.Impresion.ModelosFiscales.EpsonTiquedora:
                                        case Lbl.Impresion.ModelosFiscales.EpsonGenerico:
                                        case Lbl.Impresion.ModelosFiscales.Emulacion:
                                                ComandoAEnviar = new Comando(CodigosComandosFiscales.EpsonDocumentoFiscalPagosYDescuentos,
                                                        "Recargo " + Lfx.Types.Formatting.FormatCurrencyForPrint(Comprob.Recargo, Lfx.Workspace.Master.CurrentConfig.Moneda.DecimalesCosto) + "%",
                                                        FormatearNumeroEpson(Comprob.Subtotal * (Comprob.Recargo / 100), 2).PadLeft(12, '0'),
                                                        "R");
                                                Res = Enviar(ComandoAEnviar);
                                                break;

                                        case Lbl.Impresion.ModelosFiscales.HasarTiquedora:
                                        case Lbl.Impresion.ModelosFiscales.HasarGenerico:
                                                ComandoAEnviar = new Comando(CodigosComandosFiscales.HasarDocumentoFiscalDevolucionesYRecargos,
                                                        "Recargo " + Lfx.Types.Formatting.FormatCurrencyForPrint(Comprob.Recargo, Lfx.Workspace.Master.CurrentConfig.Moneda.DecimalesCosto) + "%",
                                                        FormatearNumeroHasar(Comprob.Subtotal * (Comprob.Recargo / 100), 2).PadLeft(10, '0'),
                                                        "M",
                                                        "00000000000",
                                                        "0",
                                                        "T",
                                                        "B");
                                                Res = Enviar(ComandoAEnviar);
                                                break;

                                }

                                if (Res.Error != ErroresFiscales.Ok) {
                                        Res.Lugar = "DocumentoFiscalPagosYDescuentos:Interes";
                                        return Res;
                                }
                        }

                        // Pago
                        switch (Modelo) {
                                case Lbl.Impresion.ModelosFiscales.EpsonTiquedora:
                                case Lbl.Impresion.ModelosFiscales.EpsonGenerico:
                                case Lbl.Impresion.ModelosFiscales.Emulacion:
                                        ComandoAEnviar = new Comando(CodigosComandosFiscales.EpsonDocumentoFiscalPagosYDescuentos,
                                                FiscalizarTexto(Comprob.FormaDePago.ToString(), 50),
                                                FormatearNumeroEpson(Comprob.Total, 2).PadLeft(12, '0'),
                                                "T");
                                        Res = Enviar(ComandoAEnviar);
                                        break;

                                case Lbl.Impresion.ModelosFiscales.HasarTiquedora:
                                case Lbl.Impresion.ModelosFiscales.HasarGenerico:
                                        ComandoAEnviar = new Comando(CodigosComandosFiscales.HasarDocumentoFiscalPago,
                                                FiscalizarTexto(Comprob.FormaDePago.ToString(), 50),
                                                FormatearNumeroHasar(Comprob.Total, 2),
                                                "T",
                                                "0");
                                        Res = Enviar(ComandoAEnviar);
                                        break;
                        }


                        if (Res.Error != ErroresFiscales.Ok) {
                                Res.Lugar = "DocumentoFiscalPagosYDescuentos:Pago";
                                return Res;
                        }

                        // *** Cerrar Documento
                        switch (Modelo) {
                                case Lbl.Impresion.ModelosFiscales.EpsonTiquedora:
                                        Res = Enviar(new Comando(CodigosComandosFiscales.EpsonDocumentoFiscalCerrar, TipoDocumento, Letra, ""));
                                        break;
                                case Lbl.Impresion.ModelosFiscales.EpsonGenerico:
                                case Lbl.Impresion.ModelosFiscales.Emulacion:
                                        Res = Enviar(new Comando(CodigosComandosFiscales.EpsonDocumentoFiscalCerrar, TipoDocumento, Letra, "Final"));
                                        break;

                                case Lbl.Impresion.ModelosFiscales.HasarTiquedora:
                                case Lbl.Impresion.ModelosFiscales.HasarGenerico:
                                        if (Letra == "S" || Letra == "R") {
                                                // Si es nota de credito cierro dicha nota 
                                                Res = Enviar(new Comando(CodigosComandosFiscales.HasarDocumentoNoFiscalHomologadoCerrar, "1", ""));
                                        } else {

                                                // Comando CloseFiscalReceipt (Manual de comandos hasar)
                                                Res = Enviar(new Comando(CodigosComandosFiscales.HasarDocumentoFiscalCerrar, "1"));

                                        }
                                        break;

                        }

                        if (Res.Error != ErroresFiscales.Ok) {
                                Res.Lugar = "DocumentoFiscalCerrar";
                                return Res;
                        } else {
                                if (NotifHandler != null)
                                        NotifHandler(this, new ImpresoraEventArgs("Asentando el movimiento"));

                                IDbTransaction Trans = null;
                                try {
                                        Trans = Comprob.Connection.BeginTransaction(IsolationLevel.Serializable);

                                        // Marco la factura como impresa y numerada
                                        new Lbl.Comprobantes.Numerador(Comprob).Numerar(Res.NumeroComprobante, true);

                                        // Mover stock si corresponde
                                        Comprob.MoverExistencias(false);

                                        // Asentar pagos si corresponde
                                        Comprob.AsentarPago(false);

                                        Trans.Commit();
                                } catch (Exception ex) {
                                        Res = new Respuesta(ErroresFiscales.Error);
                                        Res.Mensaje = ex.ToString();
                                        if (Trans != null)
                                                Trans.Rollback();
                                }

                                if (NotifHandler != null)
                                        NotifHandler(this, new ImpresoraEventArgs("Se imprimió el comprobante"));
                                return Res;
                        }
                }

                private void SendToPrinter(byte[] command)
                {
                        PuertoSerie.Write(command, 0, command.Length);
                        System.Threading.Thread.Sleep(150);
                        if (Modelo == Lbl.Impresion.ModelosFiscales.EpsonGenerico || Modelo == Lbl.Impresion.ModelosFiscales.EpsonTiquedora)
                                PuertoSerie.DtrEnable = true;
                }

                private void SendToPrinter(string command)
                {
                        SendToPrinter(DefaultEncoding.GetBytes(command));
                }

                private Lazaro.Base.Util.Impresion.Comprobantes.Fiscal.Respuesta EnviarAEmulacion(Comando comando)
                {
                        Respuesta Res = new Respuesta(ErroresFiscales.Ok);

                        Res.CodigoComando = comando.CodigoComando;
                        Res.Secuencia = comando.Secuencia;

                        Res.Campos = new List<string>();
                        Res.Campos.Add("0080");		//Estado Impresora
                        Res.Campos.Add("0600");		//Estado Fiscal

                        m_TextEmulacion.AppendLine("CMD " + comando.CodigoComando.ToString() + System.Environment.NewLine);

                        System.Threading.Thread.Sleep(200);

                        switch (comando.CodigoComando) {
                                case CodigosComandosFiscales.EpsonDocumentoFiscalCerrar:
                                        int LastComprob = Lfx.Workspace.Master.CurrentConfig.ReadGlobalSetting<int>("ServidorFiscal.UltimoComprobEmulacionPV" + this.PuntoDeVenta.Numero.ToString(), 0) + 1;
                                        Res.Campos.Add(LastComprob.ToString("00000000"));
                                        Lfx.Workspace.Master.CurrentConfig.WriteGlobalSetting("ServidorFiscal", "UltimoComprobEmulacionPV" + this.PuntoDeVenta.Numero.ToString(), LastComprob.ToString());
                                        System.Console.WriteLine(m_TextEmulacion.ToString());
                                        m_TextEmulacion = new System.Text.StringBuilder();
                                        break;
                        }

                        Log(Res);
                        return Res;
                }

                private Lazaro.Base.Util.Impresion.Comprobantes.Fiscal.Respuesta Enviar(Comando comando)
                {
                        Lazaro.Base.Util.Impresion.Comprobantes.Fiscal.Respuesta Res = Inicializar();

                        if (Res.Error != ErroresFiscales.Ok)
                                return Res;

                        comando.Secuencia = SeqNum;
                        SeqNum += 2;
                        if (SeqNum > 0X7F)
                                SeqNum = FIRST_SEQ;

                        NotificacionEventHandler NotifHandler = Notificacion;
                        if (NotifHandler != null)
                                NotifHandler(this, new ImpresoraEventArgs("Enviando datos"));

                        Log(comando);

                        if (Modelo == Lbl.Impresion.ModelosFiscales.Emulacion)
                                return EnviarAEmulacion(comando);

                        int IntentosEnviar = 0, IntentosRecibir = 0;

                        byte[] BytesCadena = DefaultEncoding.GetBytes(comando.ProtocoloBinario());

                        SendToPrinter(BytesCadena);
                        IntentosEnviar++;

                        if (NotifHandler != null)
                                NotifHandler(this, new ImpresoraEventArgs("Esperando respuesta"));

                        DateTime TActual = System.DateTime.Now.AddTicks(System.Convert.ToInt64(TimeSpan.TicksPerSecond * 300));
                        string CaracteresRecibidos = "";
                        bool TengoSTX = false, TengoETX = false;

                        do {
                                try {
                                        if (Modelo != Lbl.Impresion.ModelosFiscales.HasarGenerico && Modelo != Lbl.Impresion.ModelosFiscales.HasarTiquedora) {
                                                PuertoSerie.DtrEnable = true;
                                                System.Threading.Thread.Sleep(20);
                                        }
                                        string CaracteresLeidos = ((char)PuertoSerie.ReadChar()).ToString();
                                        foreach (char CaracterRecibido in CaracteresLeidos) {
                                                if (CaracterRecibido == CaracteresDeControl.PROTO_ACK) {
                                                        // ACK. Todo bien
                                                } else if (CaracterRecibido == CaracteresDeControl.PROTO_NAK) {
                                                        // NAK. Reenviar
                                                        if (IntentosEnviar < 4) {
                                                                if (NotifHandler != null)
                                                                        NotifHandler(this, new ImpresoraEventArgs("Reenviando"));

                                                                System.Threading.Thread.Sleep(250);
                                                                SendToPrinter(BytesCadena);
                                                                IntentosEnviar++;
                                                                CaracteresRecibidos = "";
                                                        } else {
                                                                break;
                                                        }
                                                } else if (CaracterRecibido == CaracteresDeControl.PROTO_DC2 || CaracterRecibido == CaracteresDeControl.PROTO_DC4) {
                                                        // DC2 o DC4, esperar otros 800 ms
                                                        if (NotifHandler != null)
                                                                NotifHandler(this, new ImpresoraEventArgs("Imprimiendo"));

                                                        TActual = System.DateTime.Now.AddTicks(System.Convert.ToInt64(TimeSpan.TicksPerSecond * 80));
                                                        //CaracteresRecibidos = CaracteresRecibidos.Substring(0, CaracteresRecibidos.Length - 1);
                                                } else if (CaracterRecibido == CaracteresDeControl.PROTO_ETX) {
                                                        // En of frame. Leo el BCC y me voy
                                                        CaracteresRecibidos += CaracterRecibido;
                                                        byte[] ReadBytes = new byte[4];
                                                        PuertoSerie.Read(ReadBytes, 0, 4);
                                                        string BCC = DefaultEncoding.GetString(ReadBytes);
                                                        CaracteresRecibidos += BCC;
                                                        TengoETX = true;
                                                        PuertoSerie.DtrEnable = false;
                                                } else {
                                                        if (CaracterRecibido == CaracteresDeControl.PROTO_STX)
                                                                TengoSTX = true;

                                                        // Cualquier otro caracter, lo guardo en el buffer
                                                        // (sólo si ya recibí un STX)
                                                        if (TengoSTX)
                                                                CaracteresRecibidos += CaracterRecibido;
                                                }
                                        }
                                } catch //(Exception ex)
                                {
                                        // DEBUG: Esto no siempre es un Timeout (pero siempre es un error de comunicación)
                                        CaracteresRecibidos = "TIMEOUT";
                                        break;
                                }

                                if (System.DateTime.Now > TActual)
                                        break;

                                if (TengoETX) {
                                        //Impresora.DiscardInBuffer();
                                        //Impresora.DiscardOutBuffer();
                                        //string Dummy = Impresora.ReadExisting();
                                        // Analizo la respuesta
                                        Lazaro.Base.Util.Impresion.Comprobantes.Fiscal.Respuesta Respuesta = AnalizarRespuesta(CaracteresRecibidos);
                                        Log(Respuesta);
                                        if (Respuesta.CodigoComando != comando.CodigoComando || Respuesta.Secuencia != comando.Secuencia) {
                                                //La respuesta no corresponde al comando enviado
                                                //(posiblemente es una respuesta a un comando viejo)
                                                //En caso de que el comando sea solicitud de estado, ignoro el problema
                                                //en las impresoras Hasar, ya que todas las respuestas a cualquier comando
                                                //contienen los códigos de estado y la tiqueadora Hasar 715F suele
                                                //colgarse respondiendo a un comando viejo
                                                if (IntentosRecibir++ < 5) {
                                                        //Respuesta recibida
                                                        System.Threading.Thread.Sleep(100);

                                                        //No es respuesta a este comando o a este número de secuencia
                                                        //Envío un NAK

                                                        string Nak = "" + (char)CaracteresDeControl.PROTO_ACK;
                                                        SendToPrinter(Nak);

                                                        //Pongo nuevamente en espera
                                                        TActual = System.DateTime.Now.AddTicks(System.Convert.ToInt64(TimeSpan.TicksPerSecond * 300));
                                                        CaracteresRecibidos = "";
                                                        TengoSTX = false;
                                                        TengoETX = false;
                                                } else {
                                                        return new Respuesta(ErroresFiscales.Error);
                                                }
                                        } else {
                                                //Es respuesta correcta a este comando
                                                switch (Modelo) {
                                                        //Las fiscales Hasar esperan un ACK a la respuesta
                                                        case Lbl.Impresion.ModelosFiscales.HasarTiquedora:
                                                        case Lbl.Impresion.ModelosFiscales.HasarGenerico:
                                                                string Ack = "" + (char)CaracteresDeControl.PROTO_ACK;
                                                                SendToPrinter(Ack);
                                                                break;
                                                }
                                                return Respuesta;
                                        }
                                }
                        } while (true);

                        return AnalizarRespuesta(CaracteresRecibidos);
                }

                protected Lazaro.Base.Util.Impresion.Comprobantes.Fiscal.Respuesta AnalizarRespuesta(string respuesta)
                {
                        Lazaro.Base.Util.Impresion.Comprobantes.Fiscal.Respuesta Res = new Lazaro.Base.Util.Impresion.Comprobantes.Fiscal.Respuesta();
                        Res.ProtocoloBinario = respuesta;
                        Res.ModeloImpresora = Modelo;

                        if (respuesta == null) {
                                //Nada
                        } else if (respuesta == new string((char)0x15, 1)) {
                                Res.Error = ErroresFiscales.NAK;
                        } else if (respuesta == "TIMEOUT") {
                                Res.Error = ErroresFiscales.TimeOut;
                        } else if (respuesta.Length > 5) {
                                Res.Error = ErroresFiscales.Ok;

                                if (respuesta.Length > 1)
                                        Res.Secuencia = DefaultEncoding.GetBytes(System.Convert.ToString(respuesta[1]))[0];

                                if (respuesta.Length > 2)
                                        Res.CodigoComando = (Fiscal.CodigosComandosFiscales)DefaultEncoding.GetBytes(System.Convert.ToString(respuesta[2]))[0];

                                string Carga = "";

                                if (respuesta.Length > 5)
                                        Carga = respuesta.Substring(4, respuesta.Length - 9);

                                Res.Campos = new List<string>();

                                while (Carga.Length > 0) {
                                        Res.Campos.Add(Lfx.Types.Strings.GetNextToken(ref Carga, new string((char)0x1C, 1)));
                                }

                                switch (Modelo) {
                                        case Lbl.Impresion.ModelosFiscales.EpsonTiquedora:
                                        case Lbl.Impresion.ModelosFiscales.EpsonGenerico:
                                        case Lbl.Impresion.ModelosFiscales.Emulacion:
                                        case Lbl.Impresion.ModelosFiscales.HasarTiquedora:
                                        case Lbl.Impresion.ModelosFiscales.HasarGenerico:
                                                if (Res.Campos.Count >= 1)
                                                        Res.EstadoImpresora.CodigoEstado = int.Parse(System.Convert.ToString(Res.Campos[0]), System.Globalization.NumberStyles.AllowHexSpecifier);
                                                else
                                                        Res.EstadoImpresora.CodigoEstado = 0;

                                                if (Res.Campos.Count >= 2)
                                                        Res.EstadoFiscal.CodigoEstado = int.Parse(System.Convert.ToString(Res.Campos[1]), System.Globalization.NumberStyles.AllowHexSpecifier);
                                                else
                                                        Res.EstadoFiscal.CodigoEstado = 0;

                                                //FormEstado.lblEstadoFiscal.Text = "I: " + Res.EstadoImpresora.CodigoEstado.ToString("X4") + " / F: " + Res.EstadoFiscal.CodigoEstado.ToString("X4");

                                                if (Modelo == Lbl.Impresion.ModelosFiscales.HasarGenerico || Modelo == Lbl.Impresion.ModelosFiscales.HasarTiquedora) {
                                                        //Hasar enciende el bit 15 (error) en caso de que no haya cajón
                                                        //de dinero. Es un error que vamos a ignorar
                                                        if (Res.EstadoImpresora.Bit(14)) {
                                                                //Apago 14 y 15
                                                                Res.EstadoImpresora.CodigoEstado = Res.EstadoImpresora.CodigoEstado & 0x1FFF;
                                                                //Enciendo 15 si hay otro error además del cajón
                                                                if ((Res.EstadoImpresora.CodigoEstado & 0x13E) != 0)
                                                                        Res.EstadoImpresora.CodigoEstado = Res.EstadoImpresora.CodigoEstado | (long)Math.Pow(2, 15);
                                                        }
                                                }

                                                switch (Modelo) {
                                                        case Lbl.Impresion.ModelosFiscales.EpsonTiquedora:
                                                        case Lbl.Impresion.ModelosFiscales.EpsonGenerico:
                                                        case Lbl.Impresion.ModelosFiscales.Emulacion:
                                                        case Lbl.Impresion.ModelosFiscales.HasarTiquedora:
                                                        case Lbl.Impresion.ModelosFiscales.HasarGenerico:
                                                                if ((Res.EstadoImpresora.CodigoEstado & 0X8000) != 0)
                                                                        Res.Error = ErroresFiscales.ErrorImpresora;
                                                                else if ((Res.EstadoFiscal.CodigoEstado & 0X80FF) != 0)
                                                                        Res.Error = ErroresFiscales.ErrorFiscal;

                                                                if (( this.Modelo == Lbl.Impresion.ModelosFiscales.EpsonGenerico || this.Modelo == Lbl.Impresion.ModelosFiscales.EpsonTiquedora ) && Res.EstadoFiscal.HacerCierreZ) {
                                                                        //Sólo para Epson, bit 11 indica que es necesario hacer un cierre Z
                                                                        Res.HacerCierreZ = true;
                                                                }
                                                                break;
                                                }
                                                break;
                                }
                        } else {
                                Res.Error = ErroresFiscales.Error;
                                Res.Mensaje = "Sin datos";
                        }

                        return Res;
                }

                private static string FormatearNumeroEpson(decimal Numero, int Decimales)
                {
                        return Math.Round(Math.Abs(Numero) * new System.Decimal(Math.Pow(10, Decimales))).ToString(System.Globalization.CultureInfo.InvariantCulture);
                }

                private static string FormatearNumeroHasar(decimal Numero, int Decimales)
                {
                        string Formato = "0." + "".PadRight(Decimales, '0');
                        return Math.Abs(Numero).ToString(Formato, System.Globalization.CultureInfo.InvariantCulture);
                }

                private void Log(Respuesta respuesta)
                {
                        Log(respuesta.ToString());
                }
                private void Log(Comando comando)
                {
                        Log(comando.ToString());
                }
                private void Log(string texto)
                {
                        System.IO.StreamWriter wr = new System.IO.StreamWriter(new System.IO.FileStream(Lfx.Environment.Folders.ApplicationDataFolder + "fiscal.log", System.IO.FileMode.Append), DefaultEncoding);
                        wr.Write(texto);
                        wr.Close();
                }

                private static string FiscalizarTexto(string cadena)
                {
                        return FiscalizarTexto(cadena, 0);
                }

                private static string FiscalizarTexto(string cadena, int longitudMax)
                {
                        string sRes = null;
                        sRes = cadena.Replace("á", "a");
                        sRes = sRes.Replace("é", "e");
                        sRes = sRes.Replace("í", "i");
                        sRes = sRes.Replace("ó", "o");
                        sRes = sRes.Replace("ú", "u");
                        sRes = sRes.Replace("ü", "u");
                        sRes = sRes.Replace("ñ", "n");

                        sRes = sRes.Replace("Á", "A");
                        sRes = sRes.Replace("É", "E");
                        sRes = sRes.Replace("Í", "I");
                        sRes = sRes.Replace("Ó", "O");
                        sRes = sRes.Replace("Ú", "U");
                        sRes = sRes.Replace("Ü", "U");
                        sRes = sRes.Replace("Ñ", "N");

                        for (int i = 0; i <= 31; i++) {
                                sRes = sRes.Replace((char)i, '#');
                        }

                        for (int i = 127; i <= 255; i++) {
                                sRes = sRes.Replace((char)i, '#');
                        }

                        if (longitudMax > 0 && sRes.Length > longitudMax)
                                sRes = sRes.Substring(0, longitudMax);

                        return sRes;
                }

                public Lazaro.Base.Util.Impresion.Comprobantes.Fiscal.Respuesta ObtenerEstadoImpresora()
                {
                        switch (Modelo) {
                                case Lbl.Impresion.ModelosFiscales.EpsonTiquedora:
                                case Lbl.Impresion.ModelosFiscales.EpsonGenerico:
                                case Lbl.Impresion.ModelosFiscales.Emulacion:
                                        return Enviar(new Comando(CodigosComandosFiscales.EpsonSolicitudEstado, "N"));
                                case Lbl.Impresion.ModelosFiscales.HasarTiquedora:
                                case Lbl.Impresion.ModelosFiscales.HasarGenerico:
                                        return Enviar(new Comando(CodigosComandosFiscales.HasarSolicitudEstado));
                                default:
                                        return new Respuesta(ErroresFiscales.Error);
                        }
                }
        }
}
