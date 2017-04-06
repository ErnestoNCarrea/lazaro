using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl.Comprobantes
{
        public class Pago : ElementoDeDatos
        {
                public Lbl.Pagos.FormaDePago FormaDePago;
                private decimal m_Importe = 0;
                public Cajas.Caja CajaOrigen;
                public Bancos.Cheque Cheque;
                public Cajas.Concepto Concepto;
                public Pagos.Valor Valor;
                public string ConceptoTexto;
                public Comprobantes.Recibo Recibo;

                //Heredar constructor
                public Pago(Lfx.Data.IConnection dataBase)
                        : base(dataBase) { }

                public Pago(Lfx.Data.IConnection dataBase, Lbl.Pagos.FormaDePago formaDePago)
                        : this(dataBase)
                {
                        this.FormaDePago = formaDePago;
                }

                public Pago(Lfx.Data.IConnection dataBase, Lbl.Pagos.TiposFormasDePago tipoFormaDePago)
                        : this(dataBase)
                {
                        FormaDePago = new Lbl.Pagos.FormaDePago(dataBase, tipoFormaDePago);
                        FormaDePago.Cargar();
                }

                public Pago(Lfx.Data.IConnection dataBase, Lbl.Pagos.TiposFormasDePago formaDePago, decimal importe)
                        : this(dataBase, formaDePago)
                {
                        this.Importe = importe;
                }

                public Pago(Bancos.Cheque cheque)
                        : this(cheque.Connection, cheque.Emitido ? Lbl.Pagos.TiposFormasDePago.ChequePropio : Lbl.Pagos.TiposFormasDePago.ChequeTerceros)
                {
                        if (cheque.ReciboPago != null)
                                this.Recibo = cheque.ReciboPago;
                        else if (cheque.ReciboCobro != null)
                                this.Recibo = cheque.ReciboCobro;
                        this.Cheque = cheque;
                }

                public Pago(Pagos.Valor valor)
                        : this(valor.Connection, valor.FormaDePago.Tipo)
                {
                        if (valor.Recibo != null)
                                this.Recibo = valor.Recibo;
                        this.Valor = valor;
                }

                public decimal Importe
                {
                        get
                        {
                                switch (FormaDePago.Tipo) {
                                        case Lbl.Pagos.TiposFormasDePago.ChequePropio:
                                        case Lbl.Pagos.TiposFormasDePago.ChequeTerceros:
                                                if (Cheque == null)
                                                        return 0;
                                                else
                                                        return Cheque.Importe;
                                        case Lbl.Pagos.TiposFormasDePago.OtroValor:
                                                if (Valor == null)
                                                        return 0;
                                                else
                                                        return Valor.Importe;
                                        default:
                                                return this.m_Importe;
                                }
                        }
                        set
                        {
                                switch (FormaDePago.Tipo) {
                                        case Lbl.Pagos.TiposFormasDePago.ChequePropio:
                                        case Lbl.Pagos.TiposFormasDePago.ChequeTerceros:
                                                Cheque.Importe = value;
                                                break;
                                        case Lbl.Pagos.TiposFormasDePago.OtroValor:
                                                Valor.Importe = value;
                                                break;
                                        default:
                                                this.m_Importe = value;
                                                break;
                                }
                        }
                }

                public void Anular()
                {
                        string DescripConcepto = "Anulación";

                        if (Recibo != null)
                                DescripConcepto = "Anulación " + Recibo.ToString();

                        Personas.Persona Cliente = null;
                        Comprobantes.ComprobanteConArticulos Factura = null;
                        if (this.Recibo != null) {
                                if (Recibo.Cliente != null)
                                        Cliente = Recibo.Cliente;
                                if (Recibo.Facturas != null && Recibo.Facturas.Count > 0)
                                        Factura = Recibo.Facturas[0].Comprobante;
                        }

                        switch (this.FormaDePago.Tipo) {
                                case Lbl.Pagos.TiposFormasDePago.Efectivo:
                                        Lbl.Cajas.Caja Caja = new Lbl.Cajas.Caja(Connection, Lfx.Workspace.Master.CurrentConfig.Empresa.CajaDiaria);
                                        Caja.Movimiento(true, this.Concepto, DescripConcepto, Cliente, this.Importe, null, Factura, this.Recibo, null);
                                        break;
                                case Pagos.TiposFormasDePago.ChequeTerceros:
                                case Lbl.Pagos.TiposFormasDePago.ChequePropio:
                                        if (this.Cheque != null)
                                                this.Cheque.Anular();
                                        break;
                                case Lbl.Pagos.TiposFormasDePago.OtroValor:
                                        if (this.Valor != null)
                                                this.Valor.Anular();
                                        break;
                                case Lbl.Pagos.TiposFormasDePago.Caja:
                                        this.CajaOrigen.Movimiento(true, this.Concepto, DescripConcepto, Cliente, this.Importe, null, Factura, this.Recibo, null);
                                        break;
                        }
                }


                public string Obs
                {
                        get
                        {
                                switch (FormaDePago.Tipo) {
                                        case Lbl.Pagos.TiposFormasDePago.ChequePropio:
                                        case Lbl.Pagos.TiposFormasDePago.ChequeTerceros:
                                                if (Cheque != null)
                                                        return Cheque.Obs;
                                                break;
                                        case Lbl.Pagos.TiposFormasDePago.OtroValor:
                                                if (Valor != null)
                                                        return Valor.Obs;
                                                break;
                                }
                                return null;
                        }
                        set
                        {
                                switch (FormaDePago.Tipo) {
                                        case Lbl.Pagos.TiposFormasDePago.ChequePropio:
                                        case Lbl.Pagos.TiposFormasDePago.ChequeTerceros:
                                                if (Cheque != null)
                                                        Cheque.Obs = value;
                                                break;
                                        case Lbl.Pagos.TiposFormasDePago.OtroValor:
                                                if (Valor != null)
                                                        Valor.Obs = value;
                                                break;
                                }
                        }
                }


                public override string ToString()
                {
                        switch (FormaDePago.Tipo) {
                                case Lbl.Pagos.TiposFormasDePago.Efectivo:
                                        return "Efectivo";
                                case Lbl.Pagos.TiposFormasDePago.CuentaCorriente:
                                        return "Cuenta corriente";
                                case Lbl.Pagos.TiposFormasDePago.ChequePropio:
                                case Lbl.Pagos.TiposFormasDePago.ChequeTerceros:
                                        if (Cheque == null)
                                                return "Cheque";
                                        else
                                                return Cheque.ToString();
                                case Lbl.Pagos.TiposFormasDePago.Caja:
                                        if (CajaOrigen == null)
                                                return "Débito de cuenta";
                                        else
                                                return "Débito de " + CajaOrigen.ToString();
                                case Lbl.Pagos.TiposFormasDePago.OtroValor:
                                        if (Valor == null)
                                                return FormaDePago.ToString();
                                        else
                                                return Valor.ToString();
                                default:
                                        return "No especificado";
                        }
                }
        }

        public class ColeccionDePagos : List<Pago>
        {
                public decimal ImporteTotal
                {
                        get
                        {
                                decimal Res = 0;
                                foreach (Lbl.Comprobantes.Pago Pg in this) {
                                        Res += Pg.Importe;
                                }
                                return Res;
                        }
                }


                public override string ToString()
                {
                        string Res = null;
                        foreach (Pago Pg in this) {
                                if (Res == null)
                                        Res = Pg.ToString();
                                else
                                        Res += System.Environment.NewLine + Pg.ToString();
                        }
                        return Res;
                }
        }
}
