using System;
using System.Collections.Generic;
using System.Drawing;
using System.Xml;

namespace Lbl.Impresion
{
        /// <summary>
        /// Define una plantilla que se utiliza para imprimir un ElementoDeDatos.
        /// </summary>
        [Lbl.Atributos.Nomenclatura(NombreSingular = "Plantilla", Grupo = "Comprobantes")]
        [Lbl.Atributos.Datos(TablaDatos = "sys_plantillas", CampoId = "id_plantilla", TablaImagenes = "sys_plantillas_imagenes")]
        [Lbl.Atributos.Presentacion(PanelExtendido = Lbl.Atributos.PanelExtendido.Automatico)]
	public class Plantilla : ElementoDeDatos, IElementoConImagen
	{
                public IList<Campo> Campos;
                public System.Drawing.Font Font;

		//Heredar constructor
		public Plantilla(Lfx.Data.Connection dataBase)
                        : base(dataBase) { }

                public Plantilla(Lfx.Data.Connection dataBase, Lfx.Data.Row row)
                        : base(dataBase, row) { }

                public Plantilla(Lfx.Data.Connection dataBase, int itemId)
                        : base(dataBase, itemId) { }


                public override void Crear()
                {
                        base.Crear();

                        this.TamanoPapel = "a4";
                        this.Campos = new List<Campo>();
                        this.Margenes = null;
                }


                public int Copias
                {
                        get
                        {
                                return System.Convert.ToInt32(this.Registro["copias"]);
                        }
                        set
                        {
                                this.Registro["copias"] = value;
                        }
                }


                public System.Drawing.Printing.Margins Margenes
                {
                        get
                        {
                                if (System.Convert.ToInt32(this.Registro["margen_izquierda"]) == -1)
                                        return null;
                                else
                                        return new System.Drawing.Printing.Margins(System.Convert.ToInt32(this.Registro["margen_izquierda"]),
                                                System.Convert.ToInt32(this.Registro["margen_derecha"]),
                                                System.Convert.ToInt32(this.Registro["margen_arriba"]),
                                                System.Convert.ToInt32(this.Registro["margen_abajo"]));
                        }
                        set
                        {
                                if (value == null) {
                                        this.Registro["margen_izquierda"] = -1;
                                        this.Registro["margen_derecha"] = -1;
                                        this.Registro["margen_arriba"] = -1;
                                        this.Registro["margen_abajo"] = -1;
                                } else {
                                        this.Registro["margen_izquierda"] = value.Left;
                                        this.Registro["margen_derecha"] = value.Right;
                                        this.Registro["margen_arriba"] = value.Top;
                                        this.Registro["margen_abajo"] = value.Bottom;
                                }
                        }
                }


                public TipoPlantilla Tipo
                {
                        get
                        {
                                return ((TipoPlantilla)(this.GetFieldValue<int>("tipo")));
                        }
                        set
                        {
                                this.Registro["tipo"] = (int)(value);
                        }
                }


                public int Bandeja
                {
                        get
                        {
                                return System.Convert.ToInt32(this.Registro["bandeja"]);
                        }
                        set
                        {
                                this.Registro["bandeja"] = value;
                        }
                }


                public string Codigo
                {
                        get
                        {
                                return this.GetFieldValue<string>("codigo");
                        }
                        set
                        {
                                this.Registro["codigo"] = value;
                        }
                }


		public bool Landscape
		{
			get
			{
				return System.Convert.ToBoolean(this.Registro["landscape"]);
			}
			set
			{
				this.Registro["landscape"] = value ? 1 : 0;
			}
		}


                public string TamanoPapel
                {
                        get
                        {
                                return this.GetFieldValue<string>("tamanopapel");
                        }
                        set
                        {
                                this.Registro["tamanopapel"] = value;
                        }
                }


                public System.Xml.XmlDocument Definicion
                {
                        get
                        {
                                XmlDocument Res = new XmlDocument();
                                if (this.Registro["defxml"] != null)
                                        Res.LoadXml(this.Registro["defxml"].ToString());
                                return Res;
                        }
                        set
                        {
                                this.Registro["defxml"] = value.OuterXml;
                        }
                }


                public virtual byte[] Archivo
                {
                        get
                        {
                                return this.GetFieldValue<byte[]>("def");
                        }
                        set
                        {
                                this.SetFieldValue("def", value);
                        }
                }


                public override Lfx.Types.OperationResult Guardar()
                {
                        XmlDocument XmlDef = new XmlDocument();
                        XmlElement Plant = XmlDef.CreateElement("Plantilla");
                        XmlDef.AppendChild(Plant);

                        XmlAttribute Attr = XmlDef.CreateAttribute("Copias");
                        Attr.Value = this.Copias.ToString();
                        Plant.Attributes.Append(Attr);

                        if (this.Font != null) {
                                Attr = XmlDef.CreateAttribute("Fuente");
                                Attr.Value = this.Font.Name;
                                Plant.Attributes.Append(Attr);

                                Attr = XmlDef.CreateAttribute("TamanoFuente");
                                Attr.Value = this.Font.Size.ToString("#.00");
                                Plant.Attributes.Append(Attr);
                        }

                        foreach (Campo Cam in this.Campos) {
                                XmlElement CampoXml = XmlDef.CreateElement("Campo");
                                Plant.AppendChild(CampoXml);

                                Attr = XmlDef.CreateAttribute("Valor");
                                Attr.Value = Cam.Valor;
                                CampoXml.Attributes.Append(Attr);

                                if (Cam.Formato != null && Cam.Formato.Length > 0) {
                                        Attr = XmlDef.CreateAttribute("Formato");
                                        Attr.Value = Cam.Formato;
                                        CampoXml.Attributes.Append(Attr);
                                }

                                Attr = XmlDef.CreateAttribute("X");
                                Attr.Value = Cam.Rectangle.X.ToString();
                                CampoXml.Attributes.Append(Attr);

                                Attr = XmlDef.CreateAttribute("Y");
                                Attr.Value = Cam.Rectangle.Y.ToString();
                                CampoXml.Attributes.Append(Attr);

                                Attr = XmlDef.CreateAttribute("Ancho");
                                Attr.Value = Cam.Rectangle.Width.ToString();
                                CampoXml.Attributes.Append(Attr);

                                Attr = XmlDef.CreateAttribute("Alto");
                                Attr.Value = Cam.Rectangle.Height.ToString();
                                CampoXml.Attributes.Append(Attr);

                                Attr = XmlDef.CreateAttribute("Alineacion");
                                Attr.Value = Cam.Alignment.ToString();
                                CampoXml.Attributes.Append(Attr);

                                Attr = XmlDef.CreateAttribute("AlineacionRenglon");
                                Attr.Value = Cam.LineAlignment.ToString();
                                CampoXml.Attributes.Append(Attr);

                                Attr = XmlDef.CreateAttribute("AnchoBorde");
                                Attr.Value = Cam.AnchoBorde.ToString();
                                CampoXml.Attributes.Append(Attr);

                                Attr = XmlDef.CreateAttribute("ColorBorde");
                                if (Cam.ColorBorde != Color.Transparent)
                                        Attr.Value = Cam.ColorBorde.ToArgb().ToString();
                                CampoXml.Attributes.Append(Attr);

                                Attr = XmlDef.CreateAttribute("ColorFondo");
                                if (Cam.ColorFondo != Color.Transparent)
                                        Attr.Value = Cam.ColorFondo.ToArgb().ToString();
                                CampoXml.Attributes.Append(Attr);

                                Attr = XmlDef.CreateAttribute("ColorTexto");
                                if (Cam.ColorTexto != Color.Black)
                                        Attr.Value = Cam.ColorTexto.ToArgb().ToString();
                                CampoXml.Attributes.Append(Attr);

                                Attr = XmlDef.CreateAttribute("Wrap");
                                Attr.Value = Cam.Wrap ? "1" : "0";
                                CampoXml.Attributes.Append(Attr);

                                Attr = XmlDef.CreateAttribute("Preimpreso");
                                Attr.Value = Cam.Preimpreso ? "1" : "0";
                                CampoXml.Attributes.Append(Attr);

                                if (Cam.Font != null) {
                                        Attr = XmlDef.CreateAttribute("Fuente");
                                        Attr.Value = Cam.Font.Name;
                                        CampoXml.Attributes.Append(Attr);

                                        Attr = XmlDef.CreateAttribute("TamanoFuente");
                                        Attr.Value = Cam.Font.Size.ToString("#.00");
                                        CampoXml.Attributes.Append(Attr);
                                }
                        }

                        this.Definicion = XmlDef;

			qGen.TableCommand Comando;

                        if (this.Existe == false) {
                                Comando = new qGen.Insert(this.Connection, this.TablaDatos);
                                Comando.Fields.AddWithValue("fecha", qGen.SqlFunctions.Now);
                        } else {
                                Comando = new qGen.Update(this.Connection, this.TablaDatos);
                                Comando.WhereClause = new qGen.Where(this.CampoId, this.Id);
                        }

                        Comando.Fields.AddWithValue("codigo", this.Codigo);
                        Comando.Fields.AddWithValue("nombre", this.Nombre);
                        Comando.Fields.AddWithValue("def", this.Registro["def"]);
                        Comando.Fields.AddWithValue("defxml", this.Registro["defxml"]);
                        Comando.Fields.AddWithValue("tamanopapel", this.TamanoPapel);
			Comando.Fields.AddWithValue("landscape", this.Landscape ? 1 : 0);
                        Comando.Fields.AddWithValue("copias", this.Copias);
                        Comando.Fields.AddWithValue("tipo", ((int)(this.Tipo)));
                        Comando.Fields.AddWithValue("bandeja", this.Bandeja);
                        
                        System.Drawing.Printing.Margins Margen = this.Margenes;
                        if (Margen == null) {
                                Comando.Fields.AddWithValue("margen_izquierda", -1);
                                Comando.Fields.AddWithValue("margen_derecha", -1);
                                Comando.Fields.AddWithValue("margen_arriba", -1);
                                Comando.Fields.AddWithValue("margen_abajo", -1);
                        } else {
                                Comando.Fields.AddWithValue("margen_izquierda", Margen.Left);
                                Comando.Fields.AddWithValue("margen_derecha", Margen.Right);
                                Comando.Fields.AddWithValue("margen_arriba", Margen.Top);
                                Comando.Fields.AddWithValue("margen_abajo", Margen.Bottom);
                        }


                        Comando.Fields.AddWithValue("obs", this.Obs);
                        Comando.Fields.AddWithValue("estado", this.Estado);

                        this.Connection.Execute(Comando);

                        return base.Guardar();
                }

                public void CargarXml(string defXml)
                {
                        XmlDocument Doc = new XmlDocument();
                        try {
                                Doc.LoadXml(defXml);
                                this.CargarXml(Doc);
                        } catch {
                                // No pude cargar el XML
                        }
                }

                public void CargarXml(XmlDocument xmlDoc)
                {
                        this.Campos.Clear();
                        XmlNode Plant = xmlDoc.SelectSingleNode("/Plantilla");
                        if (Plant.Attributes["Fuente"] != null && Plant.Attributes["TamanoFuente"] != null) {
                                float TamanoFuente = ((float)(Lfx.Types.Parsing.ParseDecimal(Plant.Attributes["TamanoFuente"].Value)));
                                this.Font = new System.Drawing.Font(Plant.Attributes["Fuente"].Value, TamanoFuente);
                        }
                        foreach (XmlNode Cam in Plant.ChildNodes) {
                                if (Cam.Name == "Campo") {
                                        Campo NuevoCampo = new Campo();
                                        NuevoCampo.Valor = Cam.Attributes["Valor"].Value;
                                        if (Cam.Attributes["Formato"] != null)
                                                NuevoCampo.Formato = Cam.Attributes["Formato"].Value;
                                        if (Cam.Attributes["AnchoBorde"] != null)
                                                NuevoCampo.AnchoBorde = Lfx.Types.Parsing.ParseInt(Cam.Attributes["AnchoBorde"].Value);
                                        if (Cam.Attributes["ColorBorde"] != null) {
                                                Color Col = System.Drawing.Color.FromArgb(Lfx.Types.Parsing.ParseInt(Cam.Attributes["ColorBorde"].Value));
                                                // Quito el canal alfa
                                                NuevoCampo.ColorBorde = System.Drawing.Color.FromArgb(255, Col);
                                        }
                                        if (Cam.Attributes["ColorTexto"] != null) {
                                                Color Col = System.Drawing.Color.FromArgb(Lfx.Types.Parsing.ParseInt(Cam.Attributes["ColorTexto"].Value));
                                                // Quito el canal alfa
                                                NuevoCampo.ColorTexto = System.Drawing.Color.FromArgb(255, Col);
                                        }
                                        if (Cam.Attributes["ColorFondo"] != null) {
                                                Color Col = System.Drawing.Color.FromArgb(Lfx.Types.Parsing.ParseInt(Cam.Attributes["ColorFondo"].Value));
                                                // Quito el canal alfa
                                                if (Col == Color.FromArgb(0, 0, 0, 0))
                                                        NuevoCampo.ColorFondo = Color.Transparent;
                                                else
                                                        NuevoCampo.ColorFondo = System.Drawing.Color.FromArgb(255, Col);
                                        }
                                        NuevoCampo.Rectangle.X = Lfx.Types.Parsing.ParseInt(Cam.Attributes["X"].Value);
                                        NuevoCampo.Rectangle.Y = Lfx.Types.Parsing.ParseInt(Cam.Attributes["Y"].Value);
                                        NuevoCampo.Rectangle.Width = Lfx.Types.Parsing.ParseInt(Cam.Attributes["Ancho"].Value);
                                        NuevoCampo.Rectangle.Height = Lfx.Types.Parsing.ParseInt(Cam.Attributes["Alto"].Value);
                                        if (Cam.Attributes["AlineacionRenglon"] != null) {
                                                switch (Cam.Attributes["AlineacionRenglon"].Value) {
                                                        case "Far":
                                                                NuevoCampo.LineAlignment = System.Drawing.StringAlignment.Far;
                                                                break;
                                                        case "Center":
                                                                NuevoCampo.LineAlignment = System.Drawing.StringAlignment.Center;
                                                                break;
                                                        default:
                                                                NuevoCampo.LineAlignment = System.Drawing.StringAlignment.Near;
                                                                break;
                                                }
                                        }
                                        if (Cam.Attributes["Alineacion"] != null) {
                                                switch (Cam.Attributes["Alineacion"].Value) {
                                                        case "Far":
                                                                NuevoCampo.Alignment = System.Drawing.StringAlignment.Far;
                                                                break;
                                                        case "Center":
                                                                NuevoCampo.Alignment = System.Drawing.StringAlignment.Center;
                                                                break;
                                                        default:
                                                                NuevoCampo.Alignment = System.Drawing.StringAlignment.Near;
                                                                break;
                                                }
                                        }
                                        if (Cam.Attributes["Fuente"] != null && Cam.Attributes["TamanoFuente"] != null) {
                                                float TamanoFuenteCampo = ((float)(Lfx.Types.Parsing.ParseDecimal(Cam.Attributes["TamanoFuente"].Value)));
                                                NuevoCampo.Font = new System.Drawing.Font(Cam.Attributes["Fuente"].Value, TamanoFuenteCampo);
                                        }
                                        if (Cam.Attributes["Wrap"] != null)
                                                NuevoCampo.Wrap = Lfx.Types.Parsing.ParseInt(Cam.Attributes["Wrap"].Value) != 0;

                                        if (Cam.Attributes["Preimpreso"] != null)
                                                NuevoCampo.Preimpreso = Lfx.Types.Parsing.ParseInt(Cam.Attributes["Preimpreso"].Value) != 0;
                                        this.Campos.Add(NuevoCampo);
                                }
                        }
                }

                public override void OnLoad()
                {
                        this.Campos = new List<Campo>();
                        if (Registro["defxml"] != null && System.Convert.ToString(Registro["defxml"]).Length > 5) {
                                //Tiene definición XML... la cargo
                                this.CargarXml(Registro["defxml"].ToString());
                        } else {
                                this.Font = new System.Drawing.Font("Bitsream Vera Sans Mono", 10);
                        }

                        base.OnLoad();
                }


                private static Dictionary<string, Plantilla> m_TodasPorCodigo = null;
                public static Dictionary<string, Plantilla> TodasPorCodigo
                {
                        get
                        {
                                if (m_TodasPorCodigo == null || m_TodasPorCodigo.Count == 0) {
                                        m_TodasPorCodigo = new Dictionary<string, Plantilla>();
                                        qGen.Select Sel = new qGen.Select("sys_plantillas");
                                        System.Data.DataTable Tabla = Lfx.Workspace.Master.MasterConnection.Select(Sel);
                                        foreach (System.Data.DataRow Reg in Tabla.Rows) {
                                                m_TodasPorCodigo.Add(System.Convert.ToString(Reg["codigo"]), new Plantilla(Lfx.Workspace.Master.MasterConnection, (Lfx.Data.Row)Reg));
                                        }
                                }
                                return m_TodasPorCodigo;
                        }
                }
	}
}
