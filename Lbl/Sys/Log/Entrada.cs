using Lazaro.Orm.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl.Sys.Log
{
        [Lbl.Atributos.Nomenclatura(NombreSingular = "Entrada de Registro de Actividades")]
        [Lbl.Atributos.Datos(TablaDatos = "sys_log", CampoId = "id_log")]
        [Lbl.Atributos.Presentacion()]
        public class Entrada : Lbl.ElementoDeDatos
        {
                //Heredar constructor
                public Entrada(Lfx.Data.IConnection dataBase, int itemId)
			: base(dataBase, itemId) { }

                public Entrada(Lfx.Data.IConnection dataBase, Lfx.Data.Row row)
                        : base(dataBase, row) { }


                [Column(Name = "fecha")]
                public DateTime Fecha
                {
                        get
                        {
                                return this.GetFieldValue<DateTime>("fecha");
                        }
                }


                public string ComandoTexto
                {
                        get
                        {
                                return this.GetFieldValue<string>("comando");
                        }
                }


                public string Carga
                {
                        get
                        {
                                return this.GetFieldValue<string>("extra1");
                        }
                }


                public int IdUsuario
                {
                        get
                        {
                                return this.GetFieldValue<int>("usuario");
                        }
                }

                public string Tabla
                {
                        get
                        {
                                return this.GetFieldValue<string>("tabla");
                        }
                }

                public Acciones Comando
                {
                        get
                        {
                                string CmdTxt = this.GetFieldValue<string>("comando");
                                try {
                                        return (Acciones)(System.Enum.Parse(typeof(Acciones), CmdTxt));
                                } catch {
                                        return Acciones.Other;
                                }
                        }
                }


                public string ExplainSave(bool multiLine)
                {
                        string Cambios = this.GetFieldValue<string>("extra1");

                        if (this.Comando != Acciones.Save)
                                return Cambios == null ? "" : Cambios;

                        if (Cambios == null)
                                return "sin cambios";

                        IList<string> Campos = Lfx.Types.Strings.SplitDelimitedString(Cambios, ";", "\'" );
                        StringBuilder Res = new StringBuilder();

                        Lfx.Data.TableStructure EstrucTabla;
                        if (Lfx.Workspace.Master.Structure.Tables.ContainsKey(this.Tabla))
                                EstrucTabla = Lfx.Workspace.Master.Structure.Tables[this.Tabla];
                        else
                                EstrucTabla = null;

                        foreach (string Campo in Campos) {
                                IList<string> Partes = Campo.Split(new char[] { '=' });

                                if (Partes.Count == 1)
                                        Partes = new List<string>() { "", Campo };

                                string NombreCampo = Partes[0].Trim();

                                if (EstrucTabla != null && EstrucTabla.Columns.ContainsKey(NombreCampo)) {
                                        NombreCampo = EstrucTabla.Columns[NombreCampo].Label;
                                        if (NombreCampo == null || NombreCampo == string.Empty)
                                                NombreCampo = Partes[0];
                                } else {
                                        NombreCampo = NombreCampo.ToTitleCase();
                                }

                                string ValorCampo = Partes[1];
                                ValorCampo = ValorCampo.Replace("NULL->", "");
                                ValorCampo = ValorCampo.Replace("->", " se cambió por ");
                                if (multiLine)
                                        Res.AppendLine(NombreCampo + ": " + ValorCampo + ".");
                                else
                                        Res.Append(NombreCampo + ": " + ValorCampo + "; ");
                        }

                        return Res.ToString();
                }


                public override string ToString()
                {
                        string Res = this.GetFieldValue<string>("extra1");
                        if (Res == null) {
                                return "sin cambios";
                        } else {
                                Res = Res.Replace("NULL->", ": ");
                                Res = Res.Replace("->", " se cambió por ");
                        }
                        return Res;
                }
        }
}
