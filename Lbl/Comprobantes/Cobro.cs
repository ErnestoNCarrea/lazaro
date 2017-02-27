using Lazaro.Orm.Attributes;
using System;
using System.Collections.Generic;

namespace Lbl.Comprobantes
{
        public class Cobro : ElementoDeDatos
        {
                public Lbl.Pagos.FormaDePago FormaDePago;
                private decimal m_Importe = 0;
                public Cajas.Caja CajaDestino;
                public Pagos.Cupon Cupon;
                public Bancos.Cheque Cheque;
                public Cajas.Concepto Concepto;
                public Pagos.Valor Valor;
                public string ConceptoTexto;
                public Comprobantes.Recibo Recibo;

                //Heredar constructor
                public Cobro(Lfx.Data.IConnection dataBase) : base(dataBase) { }

                public Cobro(Lfx.Data.IConnection dataBase, Lbl.Pagos.FormaDePago formaDePago)
                        : this(dataBase)
                {
                        FormaDePago = formaDePago;
                }

                public Cobro(Lfx.Data.IConnection dataBase, Lbl.Pagos.TiposFormasDePago tipoFormaDePago)
                        : this(dataBase)
                {
                        switch(tipoFormaDePago) {
                                case Lbl.Pagos.TiposFormasDePago.Efectivo:
                                        FormaDePago = new Lbl.Pagos.FormaDePago(dataBase, 1);
                                        break;
                                case Lbl.Pagos.TiposFormasDePago.ChequePropio:
                                        FormaDePago = new Lbl.Pagos.FormaDePago(dataBase, 2);
                                        break;
                                case Lbl.Pagos.TiposFormasDePago.CuentaCorriente:
                                        FormaDePago = new Lbl.Pagos.FormaDePago(dataBase, 3);
                                        break;
                                case Lbl.Pagos.TiposFormasDePago.Tarjeta:
                                        FormaDePago = new Lbl.Pagos.FormaDePago(dataBase, 4);
                                        break;
                                case Lbl.Pagos.TiposFormasDePago.Caja:
                                        FormaDePago = new Lbl.Pagos.FormaDePago(dataBase, 6);
                                        break;
                                case Lbl.Pagos.TiposFormasDePago.ChequeTerceros:
                                        FormaDePago = new Lbl.Pagos.FormaDePago(dataBase, 8);
                                        break;
                                default:
                                        FormaDePago = new Lbl.Pagos.FormaDePago(dataBase, (int)tipoFormaDePago);
                                        break;
                        }
                }

                public Cobro(Lfx.Data.IConnection dataBase, Lbl.Pagos.TiposFormasDePago formaDePago, decimal importe)
                        : this(dataBase, formaDePago)
                {
                        this.Importe = importe;
                }

                public Cobro(Bancos.Cheque cheque)
                        : this(cheque.Connection, Lbl.Pagos.TiposFormasDePago.ChequeTerceros)
                {
                        this.Cheque = cheque;
                }

                public Cobro(Pagos.Cupon cupon)
                        : this(cupon.Connection, cupon.FormaDePago)
                {
                        this.Cupon = cupon;
                }

                public Cobro(Pagos.Valor valor)
                        : this(valor.Connection, valor.FormaDePago.Tipo)
                {
                        this.Valor = valor;
                }


                /// <summary>
                /// Obtiene o establece un texto que representa las observaciones del elemento.
                /// </summary>
                [Column(Name = "obs")]
                public string Obs
                {
                        get
                        {
                                if (this.Registro["obs"] == null || this.Registro["obs"] == DBNull.Value)
                                        return null;
                                else
                                        return this.Registro["obs"].ToString();
                        }
                        set
                        {
                                this.Registro["obs"] = value.Trim(new char[] { '\n', '\r', ' ' });
                        }
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
                                        case Lbl.Pagos.TiposFormasDePago.Tarjeta:
                                                if (Cupon == null)
                                                        return 0;
                                                else
                                                        return Cupon.Importe;
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
                                        case Lbl.Pagos.TiposFormasDePago.Tarjeta:
                                                Cupon.Importe = value;
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
                        if (Recibo != null) {
                                if (Recibo.Cliente != null)
                                        Cliente = Recibo.Cliente;
                                if (Recibo.Facturas != null && Recibo.Facturas.Count > 0)
                                        Factura = Recibo.Facturas[0].Comprobante;
                        }

                        switch (FormaDePago.Tipo) {
                                case Lbl.Pagos.TiposFormasDePago.Efectivo:
                                        Lbl.Cajas.Caja Caja = new Lbl.Cajas.Caja(Connection, Lfx.Workspace.Master.CurrentConfig.Empresa.CajaDiaria);
                                        Caja.Movimiento(true, this.Concepto, DescripConcepto, Cliente, -this.Importe, "", Factura, this.Recibo, "");
                                        break;
                                case Lbl.Pagos.TiposFormasDePago.ChequePropio:
                                        if (this.Cheque != null)
                                                this.Cheque.Anular();
                                        break;
                                case Lbl.Pagos.TiposFormasDePago.Tarjeta:
                                        if (this.Cupon != null)
                                                this.Cupon.Anular();
                                        break;
                                case Lbl.Pagos.TiposFormasDePago.OtroValor:
                                        if (this.Valor != null)
                                                this.Valor.Anular();
                                        break;
                                case Lbl.Pagos.TiposFormasDePago.Caja:
                                        this.CajaDestino.Movimiento(true, this.Concepto, DescripConcepto, Cliente, -this.Importe, null, Factura, this.Recibo, null);
                                        break;
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
                                        if (Cheque == null)
                                                return "Cheque";
                                        else
                                                return Cheque.ToString();
                                case Lbl.Pagos.TiposFormasDePago.Caja:
                                        if (CajaDestino == null)
                                                return "Acreditación en cuenta";
                                        else
                                                return "Acreditación en " + CajaDestino.ToString();
                                case Lbl.Pagos.TiposFormasDePago.Tarjeta:
                                        if (Cupon == null)
                                                return "Tarjeta de crédito/débito";
                                        else
                                                return Cupon.ToString();
                                case Lbl.Pagos.TiposFormasDePago.OtroValor:
                                        if (Valor == null)
                                                return FormaDePago.ToString();
                                        else
                                                return Valor.ToString();
                                default:
                                        return this.FormaDePago.ToString();
                        }
                }
        }

        public class ColeccionDeCobros : List<Cobro>
        {
                public decimal ImporteTotal
                {
                        get
                        {
                                decimal Res = 0;
                                foreach (Lbl.Comprobantes.Cobro Pg in this) {
                                        Res += Pg.Importe;
                                }
                                return Res;
                        }
                }

                public override string ToString()
                {
                        string Res = null;
                        foreach (Cobro Cb in this) {
                                if (Res == null)
                                        Res = Cb.ToString();
                                else
                                        Res += System.Environment.NewLine + Cb.ToString();
                        }
                        return Res;
                }
        }
}