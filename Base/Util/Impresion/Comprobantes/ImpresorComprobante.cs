using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text.RegularExpressions;

namespace Lazaro.Base.Util.Impresion.Comprobantes
{
        public class ImpresorComprobante : ImpresorElemento
	{
                /// <summary>
                /// Indica si el comprobante fue impreso por esta misma instancia del sistema
                /// Para saber si tengo que asentar movimientos. Si lo imprimo yo, asiento los movimientos
                /// Si lo imprime otro (sea un ServidorFiscal o un Lázaro en otro equipo), no asiento los 
                /// movimientos ya que los asienta quien lo imprime
                /// </summary>
                public bool ImprimiLocal { get; set; }

                /// <summary>
                /// Indica que se trata de una reimpresión. En ese caso, no se asientan movimientos de existencias
                /// ni de dinero, ya que se asentaron en la impresión original.
                /// </summary>
                public bool Reimpresion { get; set; }

                public ImpresorComprobante(Lbl.ElementoDeDatos elemento, IDbTransaction transaction)
                        : base(elemento, transaction) { }

                public Lbl.Comprobantes.Comprobante Comprobante
                {
                        get
                        {
                                return this.Elemento as Lbl.Comprobantes.Comprobante;
                        }
                        set
                        {
                                this.Elemento = value;
                        }
                }


                protected override Lbl.Impresion.Plantilla ObtenerPlantilla()
		{
                        if (Lbl.Impresion.Plantilla.TodasPorCodigo.ContainsKey(this.Comprobante.Tipo.Nomenclatura)) {
                                // Busco una plantilla para el tipo exacto
                                return Lbl.Impresion.Plantilla.TodasPorCodigo[this.Comprobante.Tipo.Nomenclatura];
                        } else if (this.Comprobante.Tipo.EsFacturaNCoND && Lbl.Impresion.Plantilla.TodasPorCodigo.ContainsKey("F" + this.Comprobante.Tipo.Letra)) {
                                // En caso de NC y ND, pruebo utilizando la plantilla de facturas
                                return Lbl.Impresion.Plantilla.TodasPorCodigo["F" + this.Comprobante.Tipo.Letra];
                        } else {
                                return base.ObtenerPlantilla();
                        }
		}


                protected override Lbl.Impresion.Impresora ObtenerImpresora()
                {
                        // Primero busco una una impresora específica para este comprobante
                        Lbl.Impresion.Impresora Res = this.Comprobante.ObtenerImpresora();

                        // Si no hay, devuelvo la impresora para este tipo de elemento
                        if (Res == null)
                                return base.ObtenerImpresora();
                        else
                                return Res;
                }


                public override Lbl.Comprobantes.Tipo ObtenerTipo()
                {
                        return Comprobante.Tipo;
                }


                public override Lfx.Types.OperationResult Imprimir()
                {
                        if (this.Comprobante.Impreso && this.Reimpresion == false)
                                this.Reimpresion = true;

                        if (this.Impresora == null)
                                this.Impresora = this.ObtenerImpresora();

                        Lbl.Impresion.ClasesImpresora ClaseImpr;
                        if (Lbl.Comprobantes.PuntoDeVenta.TodosPorNumero.ContainsKey(this.Comprobante.PV)) {
                                switch(Lbl.Comprobantes.PuntoDeVenta.TodosPorNumero[this.Comprobante.PV].Tipo) {
                                        case Lbl.Comprobantes.TipoPv.Talonario:
                                                ClaseImpr = Lbl.Impresion.ClasesImpresora.Papel;
                                                break;
                                        case Lbl.Comprobantes.TipoPv.ControladorFiscal:
                                                ClaseImpr = Lbl.Impresion.ClasesImpresora.FiscalAfip;
                                                break;
                                        case Lbl.Comprobantes.TipoPv.ElectronicoAfip:
                                                ClaseImpr = Lbl.Impresion.ClasesImpresora.ElectronicaAfip;
                                                break;
                                        default:
                                                ClaseImpr = Lbl.Impresion.ClasesImpresora.Nula;
                                                break;
                                }
                        } else {
                                ClaseImpr = Lbl.Impresion.ClasesImpresora.Papel;
                        }

                        if (ClaseImpr != Lbl.Impresion.ClasesImpresora.FiscalAfip && ClaseImpr != Lbl.Impresion.ClasesImpresora.ElectronicaAfip && this.Impresora != null) {
                                ClaseImpr = this.Impresora.Clase;

                                if (this.Comprobante.Tipo.EsFacturaNCoND && this.Impresora.EsVistaPrevia)
                                        return new Lfx.Types.FailureOperationResult("Este tipo de comprobante no puede ser previsualizado");
                        }

                        switch (ClaseImpr) {
                                case Lbl.Impresion.ClasesImpresora.ElectronicaAfip:
                                        if (this.Reimpresion)
                                                return new Lfx.Types.FailureOperationResult("No se permiten reimpresiones de comprobantes eletrónicos");

                                        // TODO: Implementar factura electrónica de AFIP
                                        // var ImpresorWsfe = new ImpresorWsfe();
                                        // ImpresorWsfe.Imprimir(this.Comprobante);

                                        return new Lfx.Types.FailureOperationResult("Factura electrónica no implementada");

                                case Lbl.Impresion.ClasesImpresora.FiscalAfip:
                                        if (this.Reimpresion)
                                                return new Lfx.Types.FailureOperationResult("No se permiten reimpresiones fiscales");

                                        // Primero hago un COMMIT, porque si no el otro proceso no va a poder hacer movimientos
                                        if (this.Transaction != null) {
                                                this.Transaction.Commit();
                                                this.Transaction.Dispose();
                                                this.Transaction = null;
                                        }
                                        ImprimiLocal = false;

                                        // Lo mando a imprimir al servidor fiscal
                                        string Estacion = null;
                                        if (ClaseImpr == Lbl.Impresion.ClasesImpresora.FiscalAfip)
                                                Estacion = Lbl.Comprobantes.PuntoDeVenta.TodosPorNumero[this.Comprobante.PV].Estacion;

                                        if (Estacion == null && Impresora != null)
                                                Estacion = Impresora.Estacion;

                                        if (Estacion != null)
                                                Lfx.Workspace.Master.DefaultScheduler.AddTask("IMPRIMIR " + this.Elemento.Id.ToString(), "fiscal" + this.Comprobante.PV.ToString(), Estacion);
                                        else
                                                throw new Exception("No se ha definido el equipo al cual está conectada la impresora remota");

                                        //Espero hasta que la factura está impresa o hasta que pasen X segundos
                                        System.DateTime FinEsperaFiscal = System.DateTime.Now.AddSeconds(90);
                                        int NumeroFiscal = 0;
                                        while (System.DateTime.Now < FinEsperaFiscal && NumeroFiscal == 0) {
                                                System.Threading.Thread.Sleep(1000);
                                                NumeroFiscal = this.Connection.FieldInt("SELECT numero FROM comprob WHERE impresa<>0 AND id_comprob=" + this.Elemento.Id.ToString());
                                        }
                                        if (NumeroFiscal == 0) {
                                                // Llegó el fin del tiempo de espera y no imprimió
                                                return new Lfx.Types.FailureOperationResult("Se superó el tiempo de espera para recibir respuesta del Servidor Fiscal.");
                                        } else {
                                                this.Elemento.Cargar();
                                                // Tengo número de factura. Imprimió Ok
                                                return new Lfx.Types.SuccessOperationResult();
                                        }
                                        
                                case Lbl.Impresion.ClasesImpresora.Nula:
                                        if (this.Reimpresion == false && this.Comprobante.Tipo.NumerarAlImprimir)
                                                new Lbl.Comprobantes.Numerador(this.Comprobante).Numerar(true);
                                        
                                        ImprimiLocal = true;

                                        return new Lfx.Types.SuccessOperationResult();

                                case Lbl.Impresion.ClasesImpresora.Papel:
                                        if (this.Impresora == null || this.Impresora.EsLocal) {
                                                if (this.Reimpresion == false && this.Comprobante.Tipo.NumerarAlImprimir)
                                                        new Lbl.Comprobantes.Numerador(this.Comprobante).Numerar(true);

                                                this.Plantilla = this.ObtenerPlantilla();
                                                if (this.Plantilla != null) {
                                                        this.DefaultPageSettings.Landscape = Plantilla.Landscape;
                                                        this.PrinterSettings.Copies = ((short)this.Plantilla.Copias);
                                                }

                                                //Elimina la ventana de "Imprimiendo página 1 de x"
                                                this.PrintController = new System.Drawing.Printing.StandardPrintController();

                                                ImprimiLocal = true;
                                                return base.Imprimir();
                                        } else {
                                                if (this.Reimpresion)
                                                        throw new Lfx.Types.DomainException("No se permiten reimpresiones remotas");

                                                // Primero hago un COMMIT, porque si no el otro proceso no va a poder hacer movimientos
                                                if (this.Transaction != null) {
                                                        this.Transaction.Commit();
                                                        this.Transaction.Dispose();
                                                        this.Transaction = null;
                                                }
                                                ImprimiLocal = false;

                                                // Lo mando a imprimir a la estación remota
                                                Lfx.Workspace.Master.DefaultScheduler.AddTask("IMPRIMIR " + this.Elemento.GetType().ToString() + " " + this.Elemento.Id.ToString() + " EN " + this.Impresora.Dispositivo, "lazaro", Impresora.Estacion);

                                                if (this.Reimpresion == false) {
                                                        //Espero hasta que la factura está impresa o hasta que pasen X segundos
                                                        System.DateTime FinEspera = System.DateTime.Now.AddSeconds(90);
                                                        int Impreso = 0;
                                                        while (System.DateTime.Now < FinEspera && Impreso == 0) {
                                                                System.Threading.Thread.Sleep(1000);
                                                                Impreso = this.Connection.FieldInt("SELECT impresa FROM comprob WHERE impresa<>0 AND id_comprob=" + this.Elemento.Id.ToString());
                                                        }
                                                        if (Impreso == 0) {
                                                                // Llegó el fin del tiempo de espera y no imprimió
                                                                return new Lfx.Types.FailureOperationResult("Se superó el tiempo de espera para recibir respuesta del sistema remoto.");
                                                        } else {
                                                                this.Elemento.Cargar();
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



                public override string ObtenerValorCampo(string nombreCampo, string formato)
                {
                        switch (nombreCampo.ToUpperInvariant()) {
                                case "TOTAL.ENLETRAS":
                                        return Lfx.Types.Formatting.SpellNumber(this.Comprobante.Total);

                                case "TIPO":
                                case "COMPROB.TIPO":
                                        return this.Comprobante.Tipo.ToString();

                                case "NUMERO":
                                case "COMPROB.NUMERO":
                                        return this.Comprobante.Numero.ToString();

                                case "CLIENTE":
                                case "CLIENTE.NOMBRE":
                                        return this.Comprobante.Cliente.ToString();

                                case "LOCALIDAD":
                                case "LOCALIDAD.NOMBRE":
                                case "CLIENTE.LOCALIDAD":
                                case "CLIENTE.LOCALIDAD.NOMBRE":
                                        if (this.Comprobante.Cliente.Localidad == null)
                                                return "";
                                        else
                                                return this.Comprobante.Cliente.Localidad.ToString();

                                case "DOMICILIO":
                                case "CLIENTE.DOMICILIO":
                                        if (this.Comprobante.Cliente.Domicilio != null && this.Comprobante.Cliente.Domicilio.Length > 0)
                                                return this.Comprobante.Cliente.Domicilio;
                                        else
                                                return this.Comprobante.Cliente.DomicilioLaboral;

                                case "CLIENTE.DOCUMENTO":
                                        if (this.Comprobante.Cliente.ClaveTributaria != null)
                                                return this.Comprobante.Cliente.ClaveTributaria.ToString();
                                        else
                                                return this.Comprobante.Cliente.NumeroDocumento;
                                case "CUIT":
                                case "CLIENTE.CUIT":
                                        if (this.Comprobante.Cliente.ClaveTributaria != null)
                                                return this.Comprobante.Cliente.ClaveTributaria.ToString();
                                        else
                                                return "";

                                case "IVA":
                                case "CLIENTE.IVA":
                                        if (this.Comprobante.Cliente.SituacionTributaria == null)
                                                return "Consumidor Final";
                                        else
                                                return this.Comprobante.Cliente.SituacionTributaria.ToString();

                                case "CLIENTE.ID":
                                        return this.Comprobante.Cliente.Id.ToString();

                                case "VENDEDOR":
                                case "VENDEDOR.NOMBRE":
                                        return this.Comprobante.Vendedor.ToString();

                                default:
                                        return base.ObtenerValorCampo(nombreCampo, formato);
                        }
                }
	}
}
