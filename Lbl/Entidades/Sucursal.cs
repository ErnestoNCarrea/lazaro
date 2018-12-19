using Lazaro.Orm;
using Lazaro.Orm.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl.Entidades
{
        /// <summary>
        /// Representa una sucursal de la empresa.
        /// </summary>
        [Lbl.Atributos.Nomenclatura(NombreSingular = "Sucursal")]
        [Lbl.Atributos.Datos(TablaDatos = "sucursales", CampoId = "id_sucursal")]
        [Lbl.Atributos.Presentacion()]

        [Entity(TableName = "sucursales", IdFieldName = "id_sucursal")]
        public class Sucursal : ElementoDeDatos
	{
                private int m_Numero;
                private Lbl.Entidades.Localidad m_Localidad = null;
                private Lbl.Cajas.Caja m_CajaDiaria = null, m_CajaCheques = null;
                private Lbl.Articulos.Situacion m_SituacionOrigen = null;

		//Heredar constructor
		public Sucursal(Lfx.Data.IConnection dataBase)
                        : base(dataBase) { }

		public Sucursal(Lfx.Data.IConnection dataBase, int itemId)
			: base(dataBase, itemId) { }

                public Sucursal(Lfx.Data.IConnection dataBase, Lfx.Data.Row row)
                        : base(dataBase, row) { }


                /// <summary>
                /// Obtiene o establece el nombre del elemento.
                /// </summary>
                [Column(Name = "nombre", Type = ColumnTypes.VarChar, Length = 200, Nullable = false)]
                public string Nombre
                {
                        get
                        {
                                return this.GetFieldValue<string>(CampoNombre);
                        }
                        set
                        {
                                this.Registro[CampoNombre] = value;
                        }
                }


                public override Lfx.Types.OperationResult Guardar()
                {
                        qGen.IStatement Comando;

                        if (this.Existe == false) {
                                Comando = new qGen.Insert(this.TablaDatos);
                                Comando.ColumnValues.AddWithValue("fecha", new qGen.SqlExpression("NOW()"));
                        } else {
                                Comando = new qGen.Update(this.TablaDatos);
                                Comando.WhereClause = new qGen.Where(this.CampoId, this.Id);
                        }

                        if (this.Numero > 0)
                        {
                                Comando.ColumnValues.AddWithValue("id_sucursal", this.Numero);
                                this.m_ItemId = this.Numero;
                        }

                        Comando.ColumnValues.AddWithValue("nombre", this.Nombre);
                        Comando.ColumnValues.AddWithValue("direccion", this.Direccion);
                        Comando.ColumnValues.AddWithValue("telefono", this.Telefono);

                        if (this.Localidad == null)
                                Comando.ColumnValues.AddWithValue("id_ciudad", null);
                        else
                                Comando.ColumnValues.AddWithValue("id_ciudad", this.Localidad.Id);

                        if (this.CajaDiaria == null)
                                Comando.ColumnValues.AddWithValue("id_caja_diaria", null);
                        else
                                Comando.ColumnValues.AddWithValue("id_caja_diaria", this.CajaDiaria.Id);

                        if (this.CajaCheques == null)
                                Comando.ColumnValues.AddWithValue("id_caja_cheques", null);
                        else
                                Comando.ColumnValues.AddWithValue("id_caja_cheques", this.CajaCheques.Id);

                        if (this.SituacionOrigen == null)
                                Comando.ColumnValues.AddWithValue("situacionorigen", null);
                        else
                                Comando.ColumnValues.AddWithValue("situacionorigen", this.SituacionOrigen.Id);

                        this.AgregarTags(Comando);

                        this.Connection.ExecuteNonQuery(Comando);

                        return base.Guardar();
                }

                public override void Crear()
                {
                        base.Crear();

                        this.CajaDiaria = new Cajas.Caja(this.Connection, 999);
                        this.SituacionOrigen = new Articulos.Situacion(this.Connection, 1);
                        this.Localidad = new Localidad(this.Connection, Lfx.Workspace.Master.CurrentConfig.Empresa.IdLocalidad);
                }


                public int Numero
                {
                        get
                        {
                                if (m_Numero == 0)
                                        m_Numero = this.Id;
                                return m_Numero;
                        }
                        set
                        {
                                m_Numero = value;
                        }
                }


                [Column(Name = "id_caja_diaria")]
                public Cajas.Caja CajaDiaria
                {
                        get
                        {
                                if (m_CajaDiaria == null && this.GetFieldValue<int>("id_caja_diaria") != 0)
                                        m_CajaDiaria = new Cajas.Caja(this.Connection, this.GetFieldValue<int>("id_caja_diaria"));
                                return m_CajaDiaria;
                        }
                        set
                        {
                                m_CajaDiaria = value;
                                this.SetFieldValue("id_caja_diaria", value);
                        }
                }


                [Column(Name = "id_caja_cheques")]
                public Cajas.Caja CajaCheques
                {
                        get
                        {
                                if (m_CajaCheques == null && this.GetFieldValue<int>("id_caja_cheques") != 0)
                                        m_CajaCheques = new Cajas.Caja(this.Connection, this.GetFieldValue<int>("id_caja_cheques"));
                                return m_CajaCheques;
                        }
                        set
                        {
                                m_CajaCheques = value;
                                this.SetFieldValue("id_caja_cheques", value);
                        }
                }


                [Column(Name = "situacionorigen")]
                public Articulos.Situacion SituacionOrigen
                {
                        get
                        {
                                if (m_SituacionOrigen == null && this.GetFieldValue<int>("situacionorigen") != 0)
                                        m_SituacionOrigen = new Articulos.Situacion(this.Connection, this.GetFieldValue<int>("situacionorigen"));
                                return m_SituacionOrigen;
                        }
                        set
                        {
                                m_SituacionOrigen = value;
                                this.SetFieldValue("situacionorigen", value);
                        }
                }


                [Column(Name = "id_ciudad")]
                public Lbl.Entidades.Localidad Localidad
                {
                        get
                        {
                                if (m_Localidad == null && this.GetFieldValue<int>("id_ciudad") > 0)
                                        m_Localidad = new Lbl.Entidades.Localidad(this.Connection, this.GetFieldValue<int>("id_ciudad"));

                                return m_Localidad;
                        }
                        set
                        {
                                m_Localidad = value;
                                this.SetFieldValue("id_ciudad", m_Localidad);
                        }
                }


                [Column(Name = "direccion")]
                public string Direccion
                {
                        get
                        {
                                return this.GetFieldValue<string>("direccion");
                        }
                        set
                        {
                                this.Registro["direccion"] = value;
                        }
                }


                [Column(Name = "telefono")]
                public string Telefono
                {
                        get
                        {
                                return this.GetFieldValue<string>("telefono");
                        }
                        set
                        {
                                this.Registro["telefono"] = value;
                        }
                }


	}
}
