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
	public class Sucursal : ElementoDeDatos
	{
                private int m_Numero;
                private Lbl.Entidades.Localidad m_Localidad = null;
                private Lbl.Cajas.Caja m_CajaDiaria = null, m_CajaCheques = null;
                private Lbl.Articulos.Situacion m_SituacionOrigen = null;

		//Heredar constructor
		public Sucursal(Lfx.Data.Connection dataBase)
                        : base(dataBase) { }

		public Sucursal(Lfx.Data.Connection dataBase, int itemId)
			: base(dataBase, itemId) { }

                public Sucursal(Lfx.Data.Connection dataBase, Lfx.Data.Row row)
                        : base(dataBase, row) { }


                public override Lfx.Types.OperationResult Guardar()
                {
                        qGen.TableCommand Comando;

                        if (this.Existe == false) {
                                Comando = new qGen.Insert(this.Connection, this.TablaDatos);
                                Comando.Fields.AddWithValue("fecha", qGen.SqlFunctions.Now);
                        } else {
                                Comando = new qGen.Update(this.Connection, this.TablaDatos);
                                Comando.WhereClause = new qGen.Where(this.CampoId, this.Id);
                        }

                        if (this.Numero > 0)
                                Comando.Fields.AddWithValue("id_sucursal", this.Numero);

                        Comando.Fields.AddWithValue("nombre", this.Nombre);
                        Comando.Fields.AddWithValue("direccion", this.Direccion);
                        Comando.Fields.AddWithValue("telefono", this.Telefono);

                        if (this.Localidad == null)
                                Comando.Fields.AddWithValue("id_ciudad", null);
                        else
                                Comando.Fields.AddWithValue("id_ciudad", this.Localidad.Id);

                        if (this.CajaDiaria == null)
                                Comando.Fields.AddWithValue("id_caja_diaria", null);
                        else
                                Comando.Fields.AddWithValue("id_caja_diaria", this.CajaDiaria.Id);

                        if (this.CajaCheques == null)
                                Comando.Fields.AddWithValue("id_caja_cheques", null);
                        else
                                Comando.Fields.AddWithValue("id_caja_cheques", this.CajaCheques.Id);

                        if (this.SituacionOrigen == null)
                                Comando.Fields.AddWithValue("situacionorigen", null);
                        else
                                Comando.Fields.AddWithValue("situacionorigen", this.SituacionOrigen.Id);

                        this.AgregarTags(Comando);

                        this.Connection.Execute(Comando);

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
