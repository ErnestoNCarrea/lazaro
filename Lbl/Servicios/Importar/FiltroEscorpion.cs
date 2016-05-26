using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl.Servicios.Importar
{
        /// <summary>
        /// Describe un filtro de importación desde archivos DBF del sistema de Escorpión Sistemas.
        /// </summary>
        public class FiltroEscorpion : FiltroOdbc
        {
                public FiltroEscorpion(Lfx.Data.Connection dataBase, Opciones opciones)
                        : base(dataBase, opciones)
                {
                        this.Nombre = "Escorpión Sistemas";

                        this.Reemplazos.Add(new Reemplazo("NO POSEE", ""));

                        this.MapaDeTablas = new ColeccionMapaDeTablas();

                        if (this.Opciones.ImportarClientes) {
                                this.MapaDeTablas.AddWithValue("Clientes", "clientes.dbf", "personas", "CODIGO");
                                this.MapaDeTablas["clientes.dbf"].Where = "CODIGO>1";   // 1 es consumidor final y lo ignoramos
                                this.MapaDeTablas["clientes.dbf"].TipoElemento = typeof(Lbl.Personas.Persona);
                                this.MapaDeTablas["clientes.dbf"].MapaDeColumnas.AddWithValues(null, "tipo", 1);
                                this.MapaDeTablas["clientes.dbf"].MapaDeColumnas.AddWithValues(null, "estado", 1);
                                this.MapaDeTablas["clientes.dbf"].MapaDeColumnas.AddWithValues("NOMBRE", "nombre_visible", ConversionDeColumna.InterpretarNombreYApellido);
                                this.MapaDeTablas["clientes.dbf"].MapaDeColumnas.AddWithValues("DOMICILIO", "domicilio", ConversionDeColumna.ConvertirAMayusculasYMinusculas);
                                this.MapaDeTablas["clientes.dbf"].MapaDeColumnas.AddWithValues("COD_POS", "id_ciudad", ConversionDeColumna.InterpretarSql);
                                this.MapaDeTablas["clientes.dbf"].MapaDeColumnas["COD_POS"].ParametroConversion = "SELECT id_ciudad FROM ciudades WHERE cp='$VALOR$'";
                                this.MapaDeTablas["clientes.dbf"].MapaDeColumnas.AddWithValues("TELEFONO", "telefono");
                                this.MapaDeTablas["clientes.dbf"].MapaDeColumnas.AddWithValues("CUIT", "cuit");
                                this.MapaDeTablas["clientes.dbf"].MapaDeColumnas.AddWithValues("OBSERVAC", "obs", ConversionDeColumna.ConvertirAMayusculasYMinusculas);

                                this.MapaDeTablas.AddWithValue("Proveedores", "proveedo.dbf", "personas", "CODIGO,CUIT");
                                this.MapaDeTablas["proveedo.dbf"].TipoElemento = typeof(Lbl.Personas.Proveedor);
                                this.MapaDeTablas["proveedo.dbf"].MapaDeColumnas.AddWithValues(null, "tipo", 2);
                                this.MapaDeTablas["proveedo.dbf"].MapaDeColumnas.AddWithValues(null, "estado", 1);
                                this.MapaDeTablas["proveedo.dbf"].MapaDeColumnas.AddWithValues(null, "id_situacion", 2);
                                this.MapaDeTablas["proveedo.dbf"].MapaDeColumnas.AddWithValues("NOMBRE", "nombre_visible", ConversionDeColumna.InterpretarNombreYApellido);
                                this.MapaDeTablas["proveedo.dbf"].MapaDeColumnas.AddWithValues("DOMICILIO", "domicilio", ConversionDeColumna.ConvertirAMayusculasYMinusculas);
                                this.MapaDeTablas["proveedo.dbf"].MapaDeColumnas.AddWithValues("COD_POS", "id_ciudad", ConversionDeColumna.InterpretarSql);
                                this.MapaDeTablas["proveedo.dbf"].MapaDeColumnas["COD_POS"].ParametroConversion = "SELECT id_ciudad FROM ciudades WHERE cp='$VALOR$'";
                                this.MapaDeTablas["proveedo.dbf"].MapaDeColumnas.AddWithValues("TELEFONO", "telefono");
                                this.MapaDeTablas["proveedo.dbf"].MapaDeColumnas.AddWithValues("CUIT", "cuit");
                                this.MapaDeTablas["proveedo.dbf"].MapaDeColumnas.AddWithValues("OBSERVAC", "obs", ConversionDeColumna.ConvertirAMayusculasYMinusculas);
                        }


                        if (this.Opciones.ImportarArticulos) {
                                this.MapaDeTablas.AddWithValue("Categorías de Artículos", "catalogo.dbf", "articulos_categorias", "CODIGO");
                                this.MapaDeTablas["catalogo.dbf"].TipoElemento = typeof(Lbl.Articulos.Categoria);
                                this.MapaDeTablas["catalogo.dbf"].MapaDeColumnas.AddWithValues(null, "estado", 1);
                                this.MapaDeTablas["catalogo.dbf"].MapaDeColumnas.AddWithValues("DESCRIP", "nombre", ConversionDeColumna.ConvertirAMayusculasYMinusculas);

                                this.MapaDeTablas.AddWithValue("Artículos", "listapre.dbf", "articulos", "CODIGO");
                                this.MapaDeTablas["listapre.dbf"].TipoElemento = typeof(Lbl.Articulos.Articulo);
                                this.MapaDeTablas["listapre.dbf"].MapaDeColumnas.AddWithValues(null, "estado", 1);
                                this.MapaDeTablas["listapre.dbf"].MapaDeColumnas.AddWithValues(null, "control_stock", 1);
                                this.MapaDeTablas["listapre.dbf"].MapaDeColumnas.AddWithValues("CODIGO", "codigo1");
                                this.MapaDeTablas["listapre.dbf"].MapaDeColumnas.AddWithValues("U_MEDIDA", "unidad_stock", ConversionDeColumna.ConvertirAMinusculas);
                                this.MapaDeTablas["listapre.dbf"].MapaDeColumnas.AddWithValues("DESCRIP", "nombre", ConversionDeColumna.ConvertirAMayusculasYMinusculas);
                                this.MapaDeTablas["listapre.dbf"].MapaDeColumnas.AddWithValues("STOCK", "stock_actual");
                                this.MapaDeTablas["listapre.dbf"].MapaDeColumnas.AddWithValues("COSTO", "costo");
                                this.MapaDeTablas["listapre.dbf"].MapaDeColumnas.AddWithValues("VALOR1", "pvp");
                                this.MapaDeTablas["listapre.dbf"].MapaDeColumnas.AddWithValues("PROVEEDOR", "id_proveedor", ConversionDeColumna.InterpretarSql);
                                this.MapaDeTablas["listapre.dbf"].MapaDeColumnas["PROVEEDOR"].ParametroConversion = "SELECT id_persona FROM personas WHERE import_id='$VALOR$'";
                                this.MapaDeTablas["listapre.dbf"].MapaDeColumnas.AddWithValues("CATALOGO", "id_categoria", ConversionDeColumna.InterpretarSql);
                                this.MapaDeTablas["listapre.dbf"].MapaDeColumnas["CATALOGO"].ParametroConversion = "SELECT id_categoria FROM articulos_categorias WHERE import_id='$VALOR$'";
                        }

                        if (this.Opciones.ImportarFacturas) {
                                // Movimientos de stock (a.k.a. facturas)
                                this.MapaDeTablas.AddWithValue("Comprobantes", "movimien.dbf", "comprob_detalle", "TIPO,NROCOM");
                                this.MapaDeTablas["movimien.dbf"].TipoElemento = typeof(Lbl.Comprobantes.DetalleArticulo);
                                //this.MapaDeTablas["movimien.dbf"].Limite = 1000;
                                this.MapaDeTablas["movimien.dbf"].ActualizaRegistros = false;
                                this.MapaDeTablas["movimien.dbf"].Where = "TIPO IN ('FCA', 'FCB')";   // Sólo facturas
                                this.Reemplazos.Add(new Reemplazo(1, 999, "movimien.dbf:CLIENTE"));   // En el sistema de Escorpión, Consumidor Final es el cliente 1, en Lázaro es 999
                                this.MapaDeTablas["movimien.dbf"].MapaDeColumnas.AddWithValues("CODIGO", "id_articulo", ConversionDeColumna.InterpretarSql);
                                this.MapaDeTablas["movimien.dbf"].MapaDeColumnas["CODIGO"].ParametroConversion = "SELECT id_articulo FROM articulos WHERE import_id='$VALOR$'";
                                this.MapaDeTablas["movimien.dbf"].MapaDeColumnas.AddWithValues("CANTIDAD", "cantidad");
                                this.MapaDeTablas["movimien.dbf"].MapaDeColumnas.AddWithValues("COSTO", "costo");
                                this.MapaDeTablas["movimien.dbf"].MapaDeColumnas.AddWithValues("PRECIO", "precio");
                                this.MapaDeTablas["movimien.dbf"].MapaDeColumnas.AddWithValues("PRECIO", "importe");
                                this.MapaDeTablas["movimien.dbf"].MapaDeColumnas.AddWithValues(null, "id_comprob", null);

                                this.MapaDeTablas["movimien.dbf"].MapaDeColumnas.AddWithValues("NROCOM", "NROCOM");
                                this.MapaDeTablas["movimien.dbf"].MapaDeColumnas.AddWithValues("FECHA", "FECHA");
                                this.MapaDeTablas["movimien.dbf"].MapaDeColumnas.AddWithValues("CLIENTE", "id_cliente", ConversionDeColumna.InterpretarSql);
                                this.MapaDeTablas["movimien.dbf"].MapaDeColumnas["CLIENTE"].ParametroConversion = "SELECT id_persona FROM personas WHERE import_id='$VALOR$'";
                                this.MapaDeTablas["movimien.dbf"].MapaDeColumnas.AddWithValues("TIPO", "TIPO");
                        }

                        if (this.Opciones.ImportarCtasCtes) {
                                // Cuentas corrientes
                                this.MapaDeTablas.AddWithValue("Cuentas corrientes", "ctasctes.dbf", "ctacte", "TIPO,NROCOM");
                                this.MapaDeTablas["ctasctes.dbf"].Where = "CONDICION='C' OR TIPO='RCB'"; 
                                this.Reemplazos.Add(new Reemplazo(1, 999, "ctascte.dbf:CLIENTE"));         // En el sistema de Escorpión, Consumidor Final es el cliente 1 (y puede tener cuenta corriente!), en Lázaro es 999
                                this.MapaDeTablas["ctasctes.dbf"].TipoElemento = typeof(Lbl.CuentasCorrientes.Movimiento);
                                this.MapaDeTablas["ctasctes.dbf"].MapaDeColumnas.AddWithValues("FECHA", "fecha");
                                this.MapaDeTablas["ctasctes.dbf"].MapaDeColumnas.AddWithValues("IMPORTE", "importe");
                                this.MapaDeTablas["ctasctes.dbf"].MapaDeColumnas.AddWithValues("CLIENTE", "id_cliente", ConversionDeColumna.InterpretarSql);
                                this.MapaDeTablas["ctasctes.dbf"].MapaDeColumnas["CLIENTE"].ParametroConversion = "SELECT id_persona FROM personas WHERE import_id='$VALOR$'";
                        }
                }


                public override void PreImportar()
                {
                        base.PreImportar();

                        using (System.Data.IDbTransaction Trans = this.Connection.BeginTransaction()) {
                                this.Connection.ExecuteSql("UPDATE personas SET import_id=1 WHERE id_persona=999");
                                Trans.Commit();
                        }
                }


                public override void PostImportar()
                {
                        base.PostImportar();

                        using (System.Data.IDbTransaction Trans = this.Connection.BeginTransaction()) {
                                this.Connection.ExecuteSql("UPDATE comprob a SET total=(SELECT SUM(importe) FROM comprob_detalle b WHERE a.id_comprob=b.id_comprob)");
                                this.Connection.ExecuteSql("UPDATE comprob SET totalreal=total, subtotal=total, cancelado=total");
                                Trans.Commit();
                        }
                }


                public override IElementoDeDatos ConvertirRegistroEnElemento(MapaDeTabla mapa, Lfx.Data.Row externalRow, Lfx.Data.Row internalRow)
                {
                        switch (mapa.TablaLazaro) {
                                case "ctacte":
                                        Lbl.IElementoDeDatos ElemMovim = base.ConvertirRegistroEnElemento(mapa, externalRow, internalRow);
                                        Lbl.CuentasCorrientes.Movimiento Movim = ElemMovim as Lbl.CuentasCorrientes.Movimiento;
                                        if (Movim != null) {
                                                if (Movim.IdCliente == 0)
                                                        return null;

                                                Movim.Auto = true;
                                                string TipoComprobVentre = externalRow["original_TIPO"].ToString();
                                                if (TipoComprobVentre == "FCB") {
                                                        TipoComprobVentre = "Factura";
                                                } else if (TipoComprobVentre == "RCB") {
                                                        TipoComprobVentre = "Recibo";
                                                        Movim.Importe = -Movim.Importe;
                                                } else if (TipoComprobVentre == "NCB") {
                                                        TipoComprobVentre = "Nota de Crédito";
                                                        Movim.Importe = -Movim.Importe;
                                                }
                                                Movim.Nombre = TipoComprobVentre + " 0001-" + System.Convert.ToInt32(externalRow["original_NROCOM"]).ToString("00000000");
                                        }
                                        return ElemMovim;

                                case "comprob_detalle":
                                        // Busco una factura a la cual adosar este detalle
                                        string Tipo = externalRow["TIPO"].ToString(), TipoLazaro = null;
                                        bool Compra = false;
                                        int Numero = Lfx.Types.Parsing.ParseInt(externalRow["NROCOM"].ToString());
                                        switch (Tipo) {
                                                case "FCA":
                                                        TipoLazaro = "FA";
                                                        break;
                                                case "FCB":
                                                        TipoLazaro = "FB";
                                                        break;
                                                case "ING":
                                                        TipoLazaro = "FA";
                                                        Compra = true;
                                                        break;
                                                case "DEV":
                                                        TipoLazaro = "NCB";
                                                        break;
                                        }

                                        if (Numero > 0 && TipoLazaro != null) {
                                                // Es una factura válida
                                                Lbl.Comprobantes.Factura Fac;

                                                qGen.Select SelFac = new qGen.Select("comprob");
                                                SelFac.WhereClause = new qGen.Where();
                                                SelFac.WhereClause.AddWithValue("tipo_fac", TipoLazaro);
                                                SelFac.WhereClause.AddWithValue("compra", Compra ? 1 : 0);
                                                SelFac.WhereClause.AddWithValue("numero", Numero);
                                                Lfx.Data.Row FacRow = this.Connection.FirstRowFromSelect(SelFac);

                                                if (FacRow == null) {
                                                        int Cliente = System.Convert.ToInt32(externalRow["CLIENTE"]);
                                                        if (Cliente <= 0)
                                                                Cliente = 999;
                                                        qGen.Insert NewFac = new qGen.Insert("comprob");
                                                        NewFac.Fields.AddWithValue("id_formapago", 1);
                                                        NewFac.Fields.AddWithValue("tipo_fac", TipoLazaro);
                                                        NewFac.Fields.AddWithValue("pv", 1);
                                                        NewFac.Fields.AddWithValue("numero", Numero);
                                                        NewFac.Fields.AddWithValue("situacionorigen", 1);
                                                        NewFac.Fields.AddWithValue("situaciondestino", 999);
                                                        NewFac.Fields.AddWithValue("fecha", System.Convert.ToDateTime(externalRow["FECHA"]));
                                                        NewFac.Fields.AddWithValue("id_vendedor", 1);
                                                        NewFac.Fields.AddWithValue("id_cliente", Cliente);
                                                        NewFac.Fields.AddWithValue("impresa", 1);
                                                        NewFac.Fields.AddWithValue("id_sucursal", 1);
                                                        NewFac.Fields.AddWithValue("estado", 1);
                                                        this.Connection.Execute(NewFac);

                                                        FacRow = this.Connection.FirstRowFromSelect(SelFac);
                                                }

                                                Fac = new Comprobantes.Factura(this.Connection, FacRow);
                                                if (internalRow != null)
                                                        internalRow.Fields.AddWithValue("id_comprob", Fac.Id);
                                                Lbl.IElementoDeDatos Elem = base.ConvertirRegistroEnElemento(mapa, externalRow, internalRow);
                                                Lbl.Comprobantes.DetalleArticulo DetArt = Elem as Lbl.Comprobantes.DetalleArticulo;
                                                if (DetArt != null) {
                                                        if (DetArt.Articulo == null)
                                                                DetArt.Nombre = externalRow["original_CODIGO"].ToString();
                                                        DetArt.IdComprobante = Fac.Id;
                                                }
                                                return Elem;
                                        }
                                        break;
                        }

                        return base.ConvertirRegistroEnElemento(mapa, externalRow, internalRow);
                }
        }
}

