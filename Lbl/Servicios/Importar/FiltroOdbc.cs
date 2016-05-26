using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl.Servicios.Importar
{
        /// <summary>
        /// Filtro de importación desde on origen ODBC.
        /// </summary>
        public class FiltroOdbc : Filtro
        {
                public string Dsn { get; set; }

                public FiltroOdbc(Lfx.Data.Connection dataBase, Opciones opciones)
                        : base(dataBase, opciones) { }


                public override void PreImportar()
                {
                        if (ConexionExterna != null) {
                                if (ConexionExterna.State == System.Data.ConnectionState.Open)
                                        ConexionExterna.Close();
                                ConexionExterna.Dispose();
                        }

                        ConexionExterna = new System.Data.Odbc.OdbcConnection();
                        ConexionExterna.ConnectionString = @"dsn=" + this.Dsn + ";";
                        ConexionExterna.Open();

                        base.PreImportar();
                }


                public override void PostImportar()
                {
                        if (ConexionExterna != null) {
                                if (ConexionExterna.State == System.Data.ConnectionState.Open)
                                        ConexionExterna.Close();
                                ConexionExterna.Dispose();
                                ConexionExterna = null;
                        }

                        base.PostImportar();
                }
        }
}
