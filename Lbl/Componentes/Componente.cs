using System;
using System.Collections.Generic;

namespace Lbl.Componentes
{
        /// <summary>
        /// Representa un componente.
        /// </summary>
        [Lbl.Atributos.Nomenclatura(NombreSingular = "Componente", Grupo = "Sistema")]
        [Lbl.Atributos.Datos(TablaDatos = "sys_components", CampoId = "id_component")]
        [Lbl.Atributos.Presentacion()]
        public class Componente : ElementoDeDatos, Lfx.Components.IComponent
        {
                public Lfx.Components.FunctionInfoCollection Funciones { get; set; }
                public Lfx.Components.RegisteredTypeCollection TiposRegistrados { get; set; }
                public System.Reflection.Assembly Assembly { get; set; }
                public IList<Lfx.Components.MenuEntry> MenuEntries { get; set; }
                public string CifFileName { get; set; }
                public bool Disabled { get; set; }

                //Heredar constructor
                public Componente(Lfx.Data.IConnection dataBase)
                        : base(dataBase) { }

                public Componente(Lfx.Data.IConnection dataBase, int itemId)
                        : base(dataBase, itemId) { }

                public Componente(Lfx.Data.IConnection dataBase, Lfx.Data.Row row)
                        : base(dataBase, row) { }


                /// <summary>
                /// Espacio de nombres bajo el cual opera el componente.
                /// </summary>
                public string EspacioNombres
                {
                        get
                        {
                                return this.GetFieldValue<string>("espacio");
                        }
                        set
                        {
                                this.SetFieldValue("espacio", value);
                        }
                }


                /// <summary>
                /// Dirección de la página web del componente.
                /// </summary>
                public string Url
                {
                        get
                        {
                                return this.GetFieldValue<string>("url");
                        }
                        set
                        {
                                this.SetFieldValue("url", value);
                        }
                }


                /// <summary>
                /// Dirección donde se pueden descargar actualizaciones del componente.
                /// </summary>
                public string UrlActualizaciones
                {
                        get
                        {
                                return this.GetFieldValue<string>("url_act");
                        }
                        set
                        {
                                this.SetFieldValue("url_act", value);
                        }
                }


                /// <summary>
                /// Versión instalada del componente.
                /// </summary>
                public DateTime Version
                {
                        get
                        {
                                return this.GetFieldValue<DateTime>("version");
                        }
                        set
                        {
                                this.SetFieldValue("version", value);
                        }
                }



                public DateTime ObtenerVersionActual()
                {
                        if (this.Assembly == null)
                                return DateTime.MinValue;

                        return System.IO.File.GetLastWriteTime(this.Assembly.Location);
                }


                /// <summary>
                /// Estructura adicional de base de datos requerida por este componente.
                /// </summary>
                public string Estructura
                {
                        get
                        {
                                return this.GetFieldValue<string>("estructura");
                        }
                        set
                        {
                                this.SetFieldValue("estructura", value);
                        }
                }


                /// <summary>
                /// Archivo CIF, que contiene información sobre menús y funciones.
                /// </summary>
                public string Cif
                {
                        get
                        {
                                return this.GetFieldValue<string>("cif");
                        }
                        set
                        {
                                this.SetFieldValue("cif", value);
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

                        Comando.ColumnValues.AddWithValue("nombre", this.Nombre);
                        Comando.ColumnValues.AddWithValue("obs", this.Obs);

                        Comando.ColumnValues.AddWithValue("espacio", this.EspacioNombres);
                        Comando.ColumnValues.AddWithValue("version", this.Version);
                        Comando.ColumnValues.AddWithValue("estructura", this.Estructura);
                        Comando.ColumnValues.AddWithValue("cif", this.Cif);

                        Comando.ColumnValues.AddWithValue("url", this.Url);
                        Comando.ColumnValues.AddWithValue("url_act", this.UrlActualizaciones);

                        this.AgregarTags(Comando);

                        this.Connection.ExecuteNonQuery(Comando);

                        return base.Guardar();
                }


                public void LoadCif()
                {
                        // Cargo el archivo CIF
                        using (System.IO.Stream CifXml = this.Assembly.GetManifestResourceStream(this.EspacioNombres + ".cif.xml")) {
                                if (CifXml != null) {
                                        // FIXME: puedo cargarlo con un lector de texto
                                        using (System.IO.StreamReader Lector = new System.IO.StreamReader(CifXml)) {
                                                this.Cif = Lector.ReadToEnd();
                                                Lector.Close();
                                        }
                                }
                        }

                        if (this.Cif == null)
                                return;

                        System.Xml.XmlDocument DocumentoCif = new System.Xml.XmlDocument();
                        DocumentoCif.LoadXml(this.Cif);
                        System.Xml.XmlNodeList ListaComponentes = DocumentoCif.GetElementsByTagName("Component");
                        //Abro el/los nodo(s) de componentes
                        foreach (System.Xml.XmlNode Componente in ListaComponentes) {
                                System.Xml.XmlNodeList NodosMenu = DocumentoCif.GetElementsByTagName("MenuItem");
                                foreach (System.Xml.XmlNode NodoMenu in NodosMenu) {
                                        if (this.MenuEntries == null)
                                                this.MenuEntries = new List<Lfx.Components.MenuEntry>();

                                        Lfx.Components.MenuEntry Menu = new Lfx.Components.MenuEntry();
                                        Menu.Name = NodoMenu.Attributes["name"].Value;
                                        if (NodoMenu.Attributes["position"] == null)
                                                Menu.Parent = "Componentes";
                                        else
                                                Menu.Parent = NodoMenu.Attributes["position"].Value;

                                        if (NodoMenu.Attributes["function"] != null)
                                                Menu.Function = NodoMenu.Attributes["function"].Value;

                                        this.MenuEntries.Add(Menu);
                                }

                                // Cargo las funciones personalizadas
                                System.Xml.XmlNodeList NodosFunciones = DocumentoCif.GetElementsByTagName("Function");
                                foreach (System.Xml.XmlNode NodoFuncion in NodosFunciones) {
                                        Lfx.Components.FunctionInfo Func = new Lfx.Components.FunctionInfo(this);
                                        Func.Nombre = NodoFuncion.Attributes["name"].Value;
                                        if (Func.Nombre != null && Func.Nombre.Length > 0 && Func.Nombre != "-") {
                                                if (NodoFuncion.Attributes["autorun"] != null && NodoFuncion.Attributes["autorun"].Value == "1")
                                                        Func.AutoRun = true;

                                                this.Funciones.Add(Func);
                                        }
                                }
                        }
                }

                public Lfx.Types.OperationResult Load()
                {
                        if (this.Assembly == null) {
                                string[] WhereToLook;

                                if (Lfx.Workspace.Master.DebugMode) {
                                        WhereToLook = new string[] {
                                                System.IO.Path.Combine(Lfx.Environment.Folders.ApplicationFolder, @"../../../Componentes/bin/dev/" + this.EspacioNombres + ".dll"),
                                                System.IO.Path.Combine(Lfx.Environment.Folders.ComponentsFolder, this.EspacioNombres + System.IO.Path.DirectorySeparatorChar + this.EspacioNombres + ".dll"),
					        Lfx.Environment.Folders.ComponentsFolder + this.EspacioNombres + ".dll",
					        Lfx.Environment.Folders.ApplicationFolder + this.EspacioNombres + ".dll"
				};
                                } else {
                                        WhereToLook = new string[] {
                                                Lfx.Environment.Folders.ComponentsFolder + this.EspacioNombres + System.IO.Path.DirectorySeparatorChar + this.EspacioNombres + ".dll",
					        Lfx.Environment.Folders.ComponentsFolder + this.EspacioNombres + ".dll",
					        Lfx.Environment.Folders.ApplicationFolder + this.EspacioNombres + ".dll"
				        };
                                }

                                foreach (string Archivo in WhereToLook) {
                                        if (System.IO.File.Exists(Archivo)) {
                                                try {
                                                        this.Assembly = System.Reflection.Assembly.LoadFrom(Archivo);
                                                        break;
                                                } catch {
                                                        // Nada
                                                }
                                        }
                                }
                        }

                        if (this.Assembly == null) {
                                return new Lfx.Types.FailureOperationResult("No se puede cargar el componente " + this.Nombre);
                        } else {
                                // Cargo las estructuras de datos adicionales que el componente necesita
                                using (System.IO.Stream DbStructXml = this.Assembly.GetManifestResourceStream(this.EspacioNombres + ".dbstruct.xml")) {
                                        if (DbStructXml != null) {
                                                // FIXME: puedo cargarlo con un lector de texto
                                                using (System.IO.StreamReader Lector = new System.IO.StreamReader(DbStructXml)) {
                                                        this.Estructura = Lector.ReadToEnd();
                                                        Lector.Close();
                                                }
                                        }
                                }

                                this.TiposRegistrados = new Lfx.Components.RegisteredTypeCollection();
                                this.Funciones = new Lfx.Components.FunctionInfoCollection();

                                // Creo la función Try, que la tienen que definir todos los componentes
                                Lfx.Components.FunctionInfo TryFunc = new Lfx.Components.FunctionInfo(this);
                                TryFunc.Nombre = "Try";
                                this.Funciones.Add(TryFunc);

                                // Creo la función Register, que la tienen que definir todos los componentes
                                Lfx.Components.FunctionInfo RegisterFunc = new Lfx.Components.FunctionInfo(this);
                                RegisterFunc.Nombre = "Register";
                                this.Funciones.Add(RegisterFunc);

                                // Creo la función GetTypes, que la tienen que definir todos los componentes
                                Lfx.Components.FunctionInfo GetTypesFunc = new Lfx.Components.FunctionInfo(this);
                                GetTypesFunc.Nombre = "GetTypes";
                                this.Funciones.Add(GetTypesFunc);

                                this.LoadCif();

                                // Agrego los tipos registrados
                                this.Funciones["Register"].Run();

                                Lfx.Components.RegisteredTypeCollection Col = this.Funciones["GetTypes"].Run() as Lfx.Components.RegisteredTypeCollection;
                                if (Col != null)
                                        this.TiposRegistrados.AddRange(Col);

                                return new Lfx.Types.SuccessOperationResult();
                        }
                }


                private static ColeccionGenerica<Componente> m_Todos = null;
                public static ColeccionGenerica<Componente> Todos()
                {
                        if (m_Todos == null) {
                                System.Data.DataTable Comps = Lfx.Workspace.Master.MasterConnection.Select("SELECT * FROM sys_components");
                                m_Todos = new ColeccionGenerica<Componente>(Lfx.Workspace.Master.MasterConnection, Comps);
                        }
                        return m_Todos;
                }
        }
}