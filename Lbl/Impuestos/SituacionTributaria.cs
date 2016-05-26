using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl.Impuestos
{
        /// <summary>
        /// Representa la situación de una persona frente al fisco.
        /// </summary>
        [Lbl.Atributos.Nomenclatura(NombreSingular = "Situación tributaria", Grupo = "Impuestos")]
        [Lbl.Atributos.Datos(TablaDatos = "situaciones", CampoId = "id_situacion")]
        [Lbl.Atributos.Presentacion()]
	public class SituacionTributaria : ElementoDeDatos
	{
		public SituacionTributaria(Lfx.Data.Connection dataBase)
                        : base(dataBase) { }

                public SituacionTributaria(Lfx.Data.Connection dataBase, Lfx.Data.Row row)
                        : base(dataBase, row) { }

		public SituacionTributaria(Lfx.Data.Connection dataBase, int itemId)
                        : base(dataBase, itemId) { }


                public string Abreviatura
                {
                        get
                        {
                                return this.GetFieldValue<string>("abrev");
                        }
                        set
                        {
                                this.Registro["abrev"] = value;
                        }
                }

                public string Comprobante
                {
                        get
                        {
                                return this.GetFieldValue<string>("comprob");
                        }
                        set
                        {
                                this.Registro["comprob"] = value;
                        }
                }

                public string Comprobante2
                {
                        get
                        {
                                return this.GetFieldValue<string>("comprob2");
                        }
                        set
                        {
                                this.Registro["comprob2"] = value;
                        }
                }

                public string ObtenerLetraPredeterminada()
                {
                        if (Lbl.Sys.Config.Pais.Id == 1) {
                                if (Lbl.Sys.Config.Empresa.SituacionTributaria == 2) {
                                        //Si soy responsable inscripto, facturo según la siguiente tabla
                                        switch (this.Id) {
                                                case 2:
                                                case 3:
                                                        return "A";
                                                default:
                                                        return "B";
                                        }
                                } else {
                                        //De lo contrario, C para todo el mundo
                                        return "C";
                                }
                        } else {
                                // TODO: poder seleccionar el tipo de factura predeterminado para cada país
                                return "A";
                        }
                }

                public override Lfx.Types.OperationResult Guardar()
                {
                        qGen.TableCommand Comando;

                        if (this.Existe == false) {
                                Comando = new qGen.Insert(this.Connection, this.TablaDatos);
                        } else {
                                Comando = new qGen.Update(this.Connection, this.TablaDatos);
                                Comando.WhereClause = new qGen.Where(this.CampoId, this.Id);
                        }

                        Comando.Fields.AddWithValue("nombre", this.Nombre);
                        Comando.Fields.AddWithValue("abrev", this.Abreviatura);
                        Comando.Fields.AddWithValue("comprob", this.Comprobante);
                        Comando.Fields.AddWithValue("comprob2", this.Comprobante2);

                        this.AgregarTags(Comando);

                        this.Connection.Execute(Comando);

                        return base.Guardar();
                }

                private static Lbl.ColeccionGenerica<SituacionTributaria> m_Todas = null;
                public static Lbl.ColeccionGenerica<SituacionTributaria> Todas
                {
                        get
                        {
                                if (m_Todas == null)
                                        m_Todas = new Lbl.ColeccionGenerica<SituacionTributaria>(Lfx.Workspace.Master.MasterConnection, Lfx.Workspace.Master.MasterConnection.Select("SELECT * FROM situaciones"));

                                return m_Todas;
                        }
                }

                /// <summary>
                /// Devuelve True si esta situación tributaria es de consumidor final.
                /// </summary>
                public bool EsConsumidorFinal
                {
                        get
                        {
                                return this.Id == 1;
                        }
                }
	}
}
