using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

namespace Lfc.Sucursales
{
        public partial class Editar : Lcc.Edicion.ControlEdicion
	{
		public Editar()
		{
                        ElementoTipo = typeof(Lbl.Entidades.Sucursal);

			InitializeComponent();
		}

                public override void ActualizarControl()
                {
                        Lbl.Entidades.Sucursal Suc = this.Elemento as Lbl.Entidades.Sucursal;

                        EntradaNumero.ValueInt = Suc.Numero;
                        EntradaNombre.Text = Suc.Nombre;
                        EntradaDireccion.Text = Suc.Direccion;
                        EntradaTelefono.Text = Suc.Telefono;
                        EntradaLocalidad.Elemento = Suc.Localidad;
                        EntradaSituacionOrigen.Elemento = Suc.SituacionOrigen;
                        EntradaCajaDiaria.Elemento = Suc.CajaDiaria;
                        EntradaCajaCheques.Elemento = Suc.CajaCheques;

                        base.ActualizarControl();
                }


                public override void ActualizarElemento()
                {
                        Lbl.Entidades.Sucursal Suc = this.Elemento as Lbl.Entidades.Sucursal;

                        Suc.Numero = EntradaNumero.ValueInt;
                        Suc.Nombre = EntradaNombre.Text;
                        Suc.Direccion = EntradaDireccion.Text;
                        Suc.Telefono = EntradaTelefono.Text;
                        Suc.Localidad = EntradaLocalidad.Elemento as Lbl.Entidades.Localidad;
                        Suc.SituacionOrigen = EntradaSituacionOrigen.Elemento as Lbl.Articulos.Situacion;
                        Suc.CajaDiaria = EntradaCajaDiaria.Elemento as Lbl.Cajas.Caja;
                        Suc.CajaCheques = EntradaCajaCheques.Elemento as Lbl.Cajas.Caja;

                        base.ActualizarElemento();
                }


                public override Lfx.Types.OperationResult ValidarControl()
                {
                        qGen.Select SelMismoNumero = new qGen.Select("sucursales");
                        SelMismoNumero.Fields = "id_sucursal";
                        SelMismoNumero.WhereClause = new qGen.Where();
                        SelMismoNumero.WhereClause.AddWithValue("id_sucursal", EntradaNumero.ValueInt);
                        if (this.Elemento.Existe)
                                SelMismoNumero.WhereClause.AddWithValue("id_sucursal", qGen.ComparisonOperators.NotEqual, this.Elemento.Id);
                        if (this.Connection.FieldInt(SelMismoNumero) != 0)
                                return new Lfx.Types.FailureOperationResult("Ya existe una sucursal con ese número.");
                        
                        return base.ValidarControl();
                }
	}
}