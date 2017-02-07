using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Lazaro.Orm;
using Lazaro.Orm.Attributes;

namespace Lbl
{
        /// <summary>
        /// Proporciona acceso a los datos con alto nivel de abstracción.
        /// Normalmente refleja un registro de la base de datos como un objeto con propiedades y métodos.
        /// </summary>
        [Serializable]
        public abstract class ElementoDeDatos : System.MarshalByRefObject, IElementoDeDatos
	{
                public Lfx.Data.IConnection Connection { get; set; }

                public object Tag { get; set; }

                [Column(Type = ColumnTypes.Serial, Id = true)]
                protected int m_ItemId = 0;

                [NonSerialized]
		protected Lfx.Data.Row m_Registro = null, m_RegistroOriginal = null;

                protected System.Drawing.Image m_Imagen = null;
                protected bool m_ImagenCambio = false;

                [NonSerialized]
                protected ColeccionGenerica<Etiqueta> m_Etiquetas = null, m_EtiquetasOriginal = null;

		protected ElementoDeDatos(Lfx.Data.IConnection conn)
		{
			this.Connection = conn;
		}

                protected ElementoDeDatos(Lfx.Data.IConnection conn, int itemId)
                        : this(conn)
                {
                        m_ItemId = itemId;
                        this.Cargar();
                }

                protected ElementoDeDatos(Lfx.Data.IConnection conn, Lfx.Data.Row row)
                        : this(conn)
                {
                        this.FromRow(row);
                }

                /// <summary>
                /// Instancia un ElementoDeDatos desde un registro de la base de datos.
                /// </summary>
                protected void FromRow(Lfx.Data.Row row)
                {
                        this.m_Etiquetas = null;
                        this.m_ImagenCambio = false;
                        this.m_Imagen = null;

                        m_Registro = row;
                        if (m_Registro != null) {
                                m_ItemId = System.Convert.ToInt32(m_Registro[this.CampoId]);
                                m_Registro.IsNew = row.IsNew;
                                m_Registro.IsModified = row.IsModified;
                                m_RegistroOriginal = m_Registro.Clone();
                                this.OnLoad();
                        } else {
                                m_ItemId = 0;
                                m_Registro = new Lfx.Data.Row();
                                m_RegistroOriginal = m_Registro.Clone();
                        }
                }

		#region Propiedades

                /// <summary>
                /// El valor de la clave primaria.
                /// </summary>
		public int Id
		{
			get
			{
                                return m_ItemId;
			}
		}

                /// <summary>
                /// Permite especificar un id arbitrario, sólo para entidades nuevas.
                /// </summary>
                public void SetId(int id)
                {
                        if (this.Existe) {
                                throw new InvalidOperationException("No se puede cambiar el id de una entidad existente.");
                        }
                        this.m_ItemId = id;
                }

                /// <summary>
                /// Obtiene una copia de this.Registro como fue cargado desde la base de datos (sin las modificaciones que se puedan haber hecho y que aun no hayan sido guardadas).
                /// </summary>
                public virtual Lfx.Data.Row RegistroOriginal
                {
                        get
                        {
                                return m_RegistroOriginal;
                        }
                }

                /// <summary>
                /// Devuelve este elemento como un registro (Lfx.DataRow). Puede ser un registro existente en la base de datos
                /// o uno nuevo.
                /// </summary>
		public virtual Lfx.Data.Row Registro
		{
			get
			{
                                if (m_Registro == null) {
                                        m_Etiquetas = null;
                                        Lfx.Data.Row Reg = null;
                                        if (this.Id != 0) {
                                                if ((this.Connection.InTransaction == false || Lfx.Workspace.Master.Tables[this.TablaDatos].AlwaysCache)
                                                        && this.CampoId == Lfx.Workspace.Master.Tables[this.TablaDatos].PrimaryKey
                                                        && this.Connection.InTransaction == false) {
                                                        // Si estoy accediendo a través de una clave primaria y no estoy en una transacción
                                                        // puedo usar directamente Connection.Tables.FastRows, que es cacheable
                                                        Reg = Lfx.Workspace.Master.Tables[this.TablaDatos].FastRows[this.Id];
                                                } else {
                                                        //De lo contrario uso Connection.Row que termina en un SELECT común
                                                        Reg = this.Connection.Row(this.TablaDatos, this.CampoId, this.Id);
                                                }
                                        }

                                        this.FromRow(Reg);
                                }
				return m_Registro;
			}
		}

                /// <summary>
                /// Se dispara cuando el elemento es cargado desde la base de datos.
                /// </summary>
                public virtual void OnLoad()
                {
                        m_Imagen = null;
                        m_ImagenCambio = false;
                }

                /// <summary>
                /// Devuelve el nombre de la tabla en la base de datos correspondiente a este elemento.
                /// </summary>
                public string TablaDatos
		{
			get
                        {
                                Lbl.Atributos.Datos AtrDatos = this.GetType().GetAttribute<Lbl.Atributos.Datos>();
                                return AtrDatos.TablaDatos;
                        }
		}

                /// <summary>
                /// Devuelve el nombre de la tabla en la base de datos correspondiente a las imágenes de este elemento.
                /// Puede ser la misma que la tabla de datos.
                /// </summary>
                public string TablaImagenes
                {
                        get
                        {
                                Lbl.Atributos.Datos AtrDatos = this.GetType().GetAttribute<Lbl.Atributos.Datos>();
                                if (AtrDatos.TablaImagenes == null)
                                        return AtrDatos.TablaDatos;
                                else
                                        return AtrDatos.TablaImagenes;
                        }
                }

                /// <summary>
                /// Obtiene el nombre del campo que es clave primaria en la tabla de datos.
                /// </summary>
                public string CampoId
		{
                        get
                        {
                                Lbl.Atributos.Datos AtrDatos = this.GetType().GetAttribute<Lbl.Atributos.Datos>();
                                return AtrDatos.CampoId;
                        }
		}

                /// <summary>
                /// Obtiene el nombre del campo detalle en la tabla de datos.
                /// </summary>
                public string CampoNombre
		{
			get
			{
                                Lbl.Atributos.Datos AtrDatos = this.GetType().GetAttribute<Lbl.Atributos.Datos>();
                                return AtrDatos.CampoNombre;
			}
		}


		//Campos estándar
		
                /// <summary>
                /// Obtiene o establece el nombre del elemento. Normalmente es el valor guadado en el el campo CampoNombre.
                /// </summary>
		public virtual string Nombre
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

                /// <summary>
                /// Obtiene o establece un texto que representa las observaciones del elemento.
                /// </summary>
		public virtual string Obs
		{
			get
			{
				if(this.Registro["obs"] == null || this.Registro["obs"] == DBNull.Value)
					return null;
				else
					return this.Registro["obs"].ToString();
			}
			set
			{
                                string NuevaObs = value;

                                if (NuevaObs != null) {
                                        if (NuevaObs.Length >= 2 && NuevaObs.Substring(NuevaObs.Length - 2, 2) == Lfx.Types.ControlChars.CrLf)
                                                //Quito el CrLf al final
                                                NuevaObs = NuevaObs.Substring(0, NuevaObs.Length - 2);
                                        else if (NuevaObs.Length >= 1 && NuevaObs.Substring(NuevaObs.Length - 1, 1) == Lfx.Types.ControlChars.Lf.ToString())
                                                //Quito el Lf al final (para Unix)
                                                NuevaObs = NuevaObs.Substring(0, NuevaObs.Length - 1);

                                        if (NuevaObs.Length > 5 && NuevaObs.Substring(0, 5) == " /// ")
                                                NuevaObs = NuevaObs.Substring(5, NuevaObs.Length - 5);
                                }

                                this.Registro["obs"] = NuevaObs;
			}
		}


                public DateTime Fecha
                {
                        get
                        {
                                return this.GetFieldValue<DateTime>("fecha");
                        }
                }


                /// <summary>
                /// Devuelve o establece el estado del elemento. El valor de esta propiedad tiene diferentes significados para cada clase derivada.
                /// </summary>
		public virtual int Estado
		{
			get
			{
				return this.GetFieldValue<int>("estado");
			}
			set
			{
				this.Registro["estado"] = value;
			}
		}


                /// <summary>
                /// Devuelve o establece el estado del elemento. El valor de esta propiedad tiene diferentes significados para cada clase derivada.
                /// </summary>
                public virtual Lbl.Estados EstadoEstandar
                {
                        get
                        {
                                return this.GetFieldValue<Lbl.Estados>("estado");
                        }
                        set
                        {
                                this.Registro["estado"] = (int)(value);
                        }
                }


                /// <summary>
                /// Devuelve o establece las marcas del elemento (destacado, protegido, etc.)
                /// </summary>
                public virtual Marcas Marcas
                {
                        get
                        {
                                return (Marcas)(this.GetFieldValue<int>("marcas"));
                        }
                        set
                        {
                                this.Registro["marcas"] = (int)value;
                        }
                }


                /// <summary>
                /// Devuelve True si se agregó, quitó o cambió la imagen del elemento.
                /// </summary>
                public bool ImagenCambio
                {
                        get
                        {
                                return m_ImagenCambio;
                        }
                }

                /// <summary>
                /// Devuelve o establece la imagen asociada con este elemento.
                /// </summary>
                public virtual System.Drawing.Image Imagen
                {
                        get
                        {
                                if (m_Imagen == null && m_ImagenCambio == false) {
                                        // FIXME: Para los artículos sin imagen, evitar hacer esta consulta cada vez que se accede a la propiedad
                                        Lfx.Data.Row Imagen = null;
                                        if (Lfx.Workspace.Master.Tables[this.TablaImagenes].PrimaryKey == null || this.Connection.InTransaction) {
                                                Imagen = Connection.Row(this.TablaImagenes, "imagen", this.CampoId, this.Id);
                                        } else {
                                                Imagen = Lfx.Workspace.Master.Tables[this.TablaImagenes].FastRows[this.Id];
                                        }

                                        if (Imagen != null && Imagen["imagen"] != null && ((byte[])(Imagen["imagen"])).Length > 5) {
                                                byte[] ByteArr = ((byte[])(Imagen["imagen"]));
                                                System.IO.MemoryStream loStream = new System.IO.MemoryStream(ByteArr);
                                                try {
                                                        this.m_Imagen = System.Drawing.Image.FromStream(loStream);
                                                        m_ImagenCambio = false;
                                                } catch {
                                                        this.m_Imagen = null;
                                                }
                                        }
                                }
                                return m_Imagen;
                        }
                        set
                        {
                                if (m_Imagen != value)
                                        m_ImagenCambio = true;
                                m_Imagen = value;
                        }
                }

		#endregion

		#region Métodos

                /// <summary>
                /// Crea un nuevo elemento nuevo, con sus valores predeterminados.
                /// </summary>
		public virtual void Crear()
		{
                        m_ItemId = 0;
			m_Registro = new Lfx.Data.Row();
                        m_RegistroOriginal = null;
                        m_Etiquetas = null;
                        if (this is ICamposBaseEstandar) {
                                this.Estado = 1;
                                this.SetFieldValue("fecha", this.Connection.ServerDateTime);
                        }
		}

                /// <summary>
                /// Agrega un comentario al historial de este elemento. El comentario se guarda inmediatamente en el historial.
                /// Sólo se pueden agregar comentarios al elemento una vez que este fue guardado.
                /// </summary>
                /// <param name="texto">El texto del comentario.</param>
                public void AgregarComentario(string texto)
                {
                        if (this.Existe == false)
                                throw new Lfx.Types.DomainException("No se pueden agregar comentarios a un elemento que aun no ha sido guardado.");

                        qGen.Insert NuevoCom = new qGen.Insert("sys_log");
                        NuevoCom.ColumnValues.AddWithValue("estacion", Lfx.Environment.SystemInformation.MachineName);
                        NuevoCom.ColumnValues.AddWithValue("tabla", this.TablaDatos);
                        NuevoCom.ColumnValues.AddWithValue("comando", "Comment");
                        NuevoCom.ColumnValues.AddWithValue("item_id", this.Id);
                        NuevoCom.ColumnValues.AddWithValue("usuario", Lbl.Sys.Config.Actual.UsuarioConectado.Id);
                        NuevoCom.ColumnValues.AddWithValue("fecha", new qGen.SqlExpression("NOW()"));
                        NuevoCom.ColumnValues.AddWithValue("extra1", texto);

                        this.Connection.Execute(NuevoCom);
                }


                /// <summary>
                /// Actualiza el Id del elemento, sólo después de crear.
                /// </summary>
                protected void ActualizarId()
                {
                        if (this.Id == 0)
                                m_ItemId = this.Connection.FieldInt("SELECT LAST_INSERT_ID()");
                }


                /// <summary>
                /// Guarda todos los cambios en la base de datos. Si se trata de un elemento nuevo, se agrega un registro a la base de datos.
                /// Si se trata de un elemento existente, se modifica el registro original.
                /// </summary>
		public virtual Lfx.Types.OperationResult Guardar()
		{
                        if (this.Id == 0) {
                                // Acabo de insertar, averiguo mi propio id
                                 this.ActualizarId();
                        } else {
                                // Es un registro antiguo, lo elimino de la caché
                                Lfx.Workspace.Master.Tables[this.TablaDatos].FastRows.RemoveFromCache(this.Id);
                        }
                        this.Registro.IsModified = false;
                        this.Registro.IsNew = false;

                        if (this.m_ImagenCambio) {
                                // Hay cambios en el campo imagen
                                if (this.Imagen == null) {
                                        // Eliminó la imagen
                                        if (this.TablaImagenes == this.TablaDatos) {
                                                // La imagen reside en un campo de la misma tabla
                                                qGen.Update ActualizarImagen = new qGen.Update(this.TablaImagenes);
                                                ActualizarImagen.ColumnValues.AddWithValue("imagen", null);
                                                ActualizarImagen.WhereClause = new qGen.Where(this.CampoId, this.Id);
                                                this.Connection.Execute(ActualizarImagen);
                                        } else {
                                                // Usa una tabla separada para las imágenes
                                                qGen.Delete EliminarImagen = new qGen.Delete(this.TablaImagenes);
                                                EliminarImagen.WhereClause = new qGen.Where(this.CampoId, this.Id);
                                                this.Connection.Execute(EliminarImagen);
                                        }
                                        Lbl.Sys.Config.ActionLog(this.Connection, Sys.Log.Acciones.Save, this, "Se eliminó la imagen");
                                } else {
                                        // Cargar imagen nueva
                                        using (System.IO.MemoryStream ByteStream = new System.IO.MemoryStream()) {
                                                System.Drawing.Imaging.ImageCodecInfo CodecInfo = null;
                                                System.Drawing.Imaging.ImageCodecInfo[] Codecs = System.Drawing.Imaging.ImageCodecInfo.GetImageEncoders();
                                                foreach (System.Drawing.Imaging.ImageCodecInfo Codec in Codecs) {
                                                        if (Codec.MimeType == "image/jpeg")
                                                                CodecInfo = Codec;
                                                }

                                                if (CodecInfo == null) {
                                                        this.Imagen.Save(ByteStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                                                } else {
                                                        System.Drawing.Imaging.Encoder QualityEncoder = System.Drawing.Imaging.Encoder.Quality;
                                                        using (System.Drawing.Imaging.EncoderParameters EncoderParams = new System.Drawing.Imaging.EncoderParameters(1)) {
                                                                EncoderParams.Param[0] = new System.Drawing.Imaging.EncoderParameter(QualityEncoder, 33L);

                                                                this.Imagen.Save(ByteStream, CodecInfo, EncoderParams);
                                                        }
                                                }
                                                byte[] ImagenBytes = ByteStream.ToArray();

                                                qGen.IStatement CambiarImagen;
                                                if (this.TablaImagenes != this.TablaDatos) {
                                                        qGen.Delete EliminarImagen = new qGen.Delete(this.TablaImagenes);
                                                        EliminarImagen.WhereClause = new qGen.Where(this.CampoId, this.Id);
                                                        this.Connection.Execute(EliminarImagen);

                                                        CambiarImagen = new qGen.Insert(this.TablaImagenes);
                                                        CambiarImagen.ColumnValues.AddWithValue(this.CampoId, this.Id);
                                                } else {
                                                        CambiarImagen = new qGen.Update(this.TablaImagenes);
                                                        CambiarImagen.WhereClause = new qGen.Where(this.CampoId, this.Id);
                                                }

                                                CambiarImagen.ColumnValues.AddWithValue("imagen", ImagenBytes);
                                                this.Connection.Execute(CambiarImagen);
                                                Lbl.Sys.Config.ActionLog(this.Connection, Sys.Log.Acciones.Save, this, "Se cargó una imagen nueva");
                                        }
                                }
                        }

                        this.GuardarEtiquetas();
                        this.GuardarLog();
                        Lfx.Workspace.Master.NotifyTableChange(this.TablaDatos, this.Id);

                        this.m_RegistroOriginal = this.m_Registro.Clone();
                        this.m_EtiquetasOriginal = this.m_Etiquetas.Clone();
                        this.m_ImagenCambio = false;

                        return new Lfx.Types.SuccessOperationResult();
		}

                /// <summary>
                /// Guarda los cambios que se hayan efectuado en las etiquetas.
                /// </summary>
                public void GuardarEtiquetas()
                {
                        if (this.Existe == false)
                                throw new Lfx.Types.DomainException("No se pueden agregar etiquetas a un elemento que aun no ha sido guardado.");

                        // Elimino las etiquetas que ya no están.
                        ColeccionGenerica<Etiqueta> ListaEtiquetas = this.Etiquetas.Quitados(m_EtiquetasOriginal);
                        if (ListaEtiquetas != null && ListaEtiquetas.Count > 0) {
                                qGen.Delete EliminarEtiquetas = new qGen.Delete("sys_labels_values");
                                EliminarEtiquetas.WhereClause = new qGen.Where("item_id", this.Id);
                                EliminarEtiquetas.WhereClause.Add(new qGen.ComparisonCondition("id_label", qGen.ComparisonOperators.In, ListaEtiquetas.GetAllIds()));
                                this.Connection.Execute(EliminarEtiquetas);
                        }

                        // Agrego las etiquetas nuevas.
                        ListaEtiquetas = this.Etiquetas.Agregados(m_EtiquetasOriginal);
                        if (ListaEtiquetas != null && ListaEtiquetas.Count > 0) {
                                foreach (ElementoDeDatos El in ListaEtiquetas) {
                                        qGen.Insert CrearEtiquetas = new qGen.Insert("sys_labels_values");
                                        CrearEtiquetas.ColumnValues.AddWithValue("id_label", El.Id);
                                        CrearEtiquetas.ColumnValues.AddWithValue("item_id", this.Id);
                                        this.Connection.Execute(CrearEtiquetas);
                                }
                        }
                }

                /// <summary>
                /// Guarda una entrada en el registro del sistema, indicando los cambios que se realizaron en este elemento.
                /// </summary>
                private void GuardarLog()
                {
                        System.Text.StringBuilder Extra1 = null;
                        try {
                                // Genero una lista de cambios
                                foreach (Lazaro.Orm.Data.ColumnValue Fl in this.m_Registro.Fields) {
                                        object ValorOriginal = null, ValorNuevo = this.m_Registro[Fl.ColumnName];
                                        if (this.m_RegistroOriginal != null && this.m_RegistroOriginal.Fields != null)
                                                ValorOriginal = this.m_RegistroOriginal[Fl.ColumnName];

                                        if (Lfx.Types.Object.CompareByValue(ValorOriginal, ValorNuevo) != 0 && Fl.ColumnName != "contrasena") {
                                                if (Extra1 == null)
                                                        Extra1 = new StringBuilder();
                                                else
                                                        Extra1.Append("; ");

                                                Extra1.Append(Fl.ColumnName + "=");
                                                if (ValorOriginal != null)
                                                        Extra1.Append("\'" + this.Connection.EscapeString(ValorOriginal.ToString()) + "\'->");
                                                else
                                                        Extra1.Append("NULL->");

                                                if (ValorNuevo != null)
                                                        Extra1.Append("\'" + this.Connection.EscapeString(ValorNuevo.ToString()) + "\'");
                                                else
                                                        Extra1.Append("NULL");
                                        }
                                }
                        } catch {
                                if (Lfx.Workspace.Master.DebugMode)
                                        throw;
                        }

                        try {
                                //System.Console.WriteLine(Extra1);
                                Lbl.Sys.Config.ActionLog(this.Connection, Sys.Log.Acciones.Save, this, Extra1 == null ? null : Extra1.ToString());
                        } catch {
                                if (Lfx.Workspace.Master.DebugMode)
                                        throw;
                        }
                }

                /// <summary>
                /// Agrega los campos personalizados (tags) al comando, antes de guardar.
                /// </summary>
                /// <param name="comando">El parámetro al cual agregar los campos.</param>
                protected virtual void AgregarTags(qGen.IStatement comando)
		{
			this.AgregarTags(comando, this.Registro, this.TablaDatos);
		}

                /// <summary>
                /// Agrega los campos personalizados de las clases derivadas al comando, antes de guardar.
                /// </summary>
                /// <param name="comando">El parámetro al cual agregar los campos.</param>
                protected virtual void PreGuardar(qGen.IStatement comando)
                {
                        return;
                }

                protected virtual void AgregarTags(qGen.IStatement comando, Lfx.Data.Row registro, string tabla)
                {
                        Lfx.Data.Table Tabla = Lfx.Workspace.Master.Tables[tabla];
                        if (Tabla.Tags != null && Tabla.Tags.Count > 0) {
                                foreach (Lfx.Data.Tag Tg in Tabla.Tags) {
                                        if (Tg.Nullable == false && registro[Tg.FieldName] == null) {
                                                switch (Tg.FieldType) {
                                                        case Lazaro.Orm.ColumnTypes.Currency:
                                                        case Lazaro.Orm.ColumnTypes.Integer:
                                                        case Lazaro.Orm.ColumnTypes.SmallInt:
                                                        case Lazaro.Orm.ColumnTypes.MediumInt:
                                                        case Lazaro.Orm.ColumnTypes.TinyInt:
                                                        case Lazaro.Orm.ColumnTypes.Numeric:
                                                                comando.ColumnValues.AddWithValue(Tg.FieldName, System.Convert.ToInt32(Tg.DefaultValue));
                                                                break;
                                                        default:
                                                                comando.ColumnValues.AddWithValue(Tg.FieldName, "");
                                                                break;
                                                }
                                        } else {
                                                comando.ColumnValues.AddWithValue(Tg.FieldName, registro[Tg.FieldName]);
                                        }
                                }
                        }
                }

                /// <summary>
                /// Devuelve Verdadero si el elemento representa un registro existente en la base de datos o False en caso contrario.
                /// </summary>
		public bool Existe
		{
                        get
                        {
                                return !Registro.IsNew;
                        }
		}

                public bool Modificado
                {
                        get
                        {
                                return this.Registro.IsModified || this.ImagenCambio;
                        }
                }


                /// <summary>
                /// Obtiene el valor de un campo del registro asociado.
                /// </summary>
                /// <typeparam name="T">El tipo de datos a utilizar para el valor devuelto.</typeparam>
                /// <param name="fieldName">El nombre del campo.</param>
                /// <returns>El valor del campo.</returns>
                public T GetFieldValue<T>(string fieldName)
                {
                        if (typeof(T).BaseType == typeof(Lbl.ElementoDeDatos) || typeof(T).GetInterface("Lbl.IElementoDeDatos") != null) {
                                // Si intento obtener un ElementoDeDatos (por ejemplo, la propiedad Persona.Localidad)
                                // tengo que instanciar un elemento.
                                int ItemId = this.GetFieldValue<int>(fieldName);
                                if (ItemId == 0) {
                                        object Res = null;
                                        return (T)Res;
                                } else {
                                        object Res = Lbl.Instanciador.Instanciar(typeof(T), this.Connection, this.GetFieldValue<int>(fieldName));
                                        return (T)Res;
                                }
                        } else if (typeof(T) == typeof(DbDateTime)) {
                                if (this.Registro[fieldName] == null) {
                                        return default(T);
                                } else {
                                        object Res;
                                        if (this.Registro[fieldName] is DbDateTime)
                                                Res = (DbDateTime)(this.Registro[fieldName]);
                                        else
                                                Res = new DbDateTime(this.GetFieldValue<DateTime>(fieldName));
                                        return (T)Res;
                                }
                        } else {
                                // De lo contrario, asumo que es un tipo intrínseco y lo convierto con System.Convert.
                                if (this.Registro[fieldName] == null) {
                                        return default(T);
                                } else {
                                        try {
                                                return (T)(System.Convert.ChangeType(this.Registro[fieldName], typeof(T)));
                                        } catch {
                                                return default(T); 
                                        }
                                }
                        }
                }

                /// <summary>
                /// Establece el valor de un campo del registro asociado.
                /// </summary>
                /// <param name="fieldName">El nombre del campo.</param>
                /// <param name="newVal">El valor a asignar.</param>
                public void SetFieldValue(string fieldName, object newVal)
                {
                        if (newVal == null) {
                                // null es null
                                this.Registro[fieldName] = null;
                        } else if (newVal is Lbl.IElementoDeDatos) {
                                // Si es un ElementoDeDatos, no guardo el objeto, sino su Id.
                                this.Registro[fieldName] = ((Lbl.IElementoDeDatos)(newVal)).Id;
                        } else {
                                // De lo contrario, asumo que es un tipo intrínseco y guardo su valor
                                this.Registro[fieldName] = newVal;
                        }
                }

                /// <summary>
                /// Devuelve el valor de un campo, convertido a Lfx.Types.LDateTime.
                /// </summary>
                /// <param name="fieldName">El nombre del campo.</param>
                /// <returns>El valor</returns>
                protected DbDateTime FieldDateTime(string fieldName)
		{
			if(this.Registro[fieldName] == null)
				return null;
                        if (this.Registro[fieldName] is DbDateTime)
                                return this.Registro[fieldName] as DbDateTime;
			else
				return new DbDateTime(System.Convert.ToDateTime(this.Registro[fieldName]));
		}

                /// <summary>
                /// Devuelve una representación de este elemento en formato de texto legible. Por ejemplo "Factura B 0001-000123".
                /// </summary>
                /// <returns></returns>
		public override string ToString()
		{
			return this.GetFieldValue<string>(this.CampoNombre);
		}


                public bool Equals(ElementoDeDatos other)
                {
                        if (object.ReferenceEquals(other, null))
                                return false;

                        return this.Id == other.Id;
                }


                /// <summary>
                /// Carga (o vuelve a cargar) el elemento desde su registro asociado en la base de datos.
                /// </summary>
		public virtual Lfx.Types.OperationResult Cargar()
		{
                        if (m_ItemId == 0) {
                                throw new InvalidOperationException("No se puede cargar el registro desde la tabla " + this.TablaDatos + " porque no tiene Id.");
                        } else {
                                // Quito el registro de la caché
                                Lfx.Workspace.Master.Tables[this.TablaDatos].FastRows.RemoveFromCache(this.Id);
                        }

                        // En realidad, lo único que hago es vaciar los valores en memoria y dejo que this.Registro.Get() lo cargue.
			this.m_Registro = null;
                        this.m_RegistroOriginal = null;
                        this.m_Etiquetas = null;
                        this.m_ImagenCambio = false;
                        this.m_Imagen = null;
                        // Fuerzo la carga.
                        Lfx.Data.Row Dummy = this.Registro;

			if (Dummy == null)
                                return new Lfx.Types.FailureOperationResult("No se pudo cargar el registro");
                        else
				return new Lfx.Types.SuccessOperationResult();
		}


		#endregion
                
                /// <summary>
                /// Obtiene o establece las etiquetas del elemento.
                /// </summary>
                public ColeccionGenerica<Etiqueta> Etiquetas
                {
                        get
                        {
                                if (m_Etiquetas == null) {
                                        m_Etiquetas = new ColeccionGenerica<Etiqueta>();
                                        if (this.Existe) {
                                                Lbl.ListaIds IdsEtiquetas = new ListaIds(this.Connection.Select("SELECT id_label FROM sys_labels_values WHERE id_label IN (SELECT id_label FROM sys_labels WHERE tablas='" + this.TablaDatos + "') AND item_id=" + this.Id.ToString()));
                                                foreach(int IdEtiqueta in IdsEtiquetas) {
                                                        m_Etiquetas.Add(Lbl.Etiqueta.Todas.GetById(IdEtiqueta));
                                                }
                                        }
                                        this.m_EtiquetasOriginal = m_Etiquetas.Clone();
                                }
                                return m_Etiquetas;
                        }
                        set
                        {
                                m_Etiquetas = value;
                        }
                }

                /// <summary>
                /// Obtiene una lista de todos los elementos de esta tabla
                /// </summary>
                /// <returns>Una colección con los id y nombre de todos los elementos de la tabla</returns>
                public ColeccionCodigoDetalle ObtenerTodos(qGen.Where filter)
                {
                        qGen.Select Sel = new qGen.Select(this.TablaDatos);
                        Sel.Columns = new List<string> { this.CampoId, this.CampoNombre };
                        if (filter != null)
                                Sel.WhereClause = filter;
                        System.Data.DataTable Tabla = this.Connection.Select(Sel);
                        return new ColeccionCodigoDetalle(Tabla);
                }
	}
}