namespace Lazaro.WinMain.Config
{
	public partial class Preferencias
	{
                #region Código generado por el Diseñador de Windows Forms

		// Limpiar los recursos que se están utilizando.
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}


		private System.ComponentModel.IContainer components = null;

		private void InitializeComponent()
		{
                        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Preferencias));
                        this.BotonAceptar = new Lui.Forms.Button();
                        this.CancelCommandButton = new Lui.Forms.Button();
                        this.EntradaEmpresaSituacion = new Lcc.Entrada.CodigoDetalle();
                        this.Label19 = new Lui.Forms.Label();
                        this.EntradaEmpresaClaveTributaria = new Lui.Forms.TextBox();
                        this.EtiquetaClaveTributaria = new Lui.Forms.Label();
                        this.EntradaEmpresaNombre = new Lui.Forms.TextBox();
                        this.Label17 = new Lui.Forms.Label();
                        this.FrmGeneral = new Lui.Forms.Frame();
                        this.label36 = new Lui.Forms.Label();
                        this.EntradaSucursal = new Lcc.Entrada.CodigoDetalle();
                        this.BotonCambiarPais = new Lui.Forms.Button();
                        this.label33 = new Lui.Forms.Label();
                        this.EntradaEmpresaId = new Lui.Forms.TextBox();
                        this.EntradaPais = new Lcc.Entrada.CodigoDetalle();
                        this.label2 = new Lui.Forms.Label();
                        this.EntradaEmpresaRazonSocial = new Lui.Forms.TextBox();
                        this.label1 = new Lui.Forms.Label();
                        this.EntradaProvincia = new Lcc.Entrada.CodigoDetalle();
                        this.EntradaLocalidad = new Lcc.Entrada.CodigoDetalle();
                        this.label32 = new Lui.Forms.Label();
                        this.label31 = new Lui.Forms.Label();
                        this.EntradaEmpresaEmail = new Lui.Forms.TextBox();
                        this.label28 = new Lui.Forms.Label();
                        this.EntradaActualizaciones = new Lui.Forms.ComboBox();
                        this.label30 = new Lui.Forms.Label();
                        this.EntradaAislacion = new Lui.Forms.ComboBox();
                        this.EntradaModoPantalla = new Lui.Forms.ComboBox();
                        this.EntradaBackup = new Lui.Forms.ComboBox();
                        this.label29 = new Lui.Forms.Label();
                        this.label27 = new Lui.Forms.Label();
                        this.label14 = new Lui.Forms.Label();
                        this.EntradaStockDecimales = new Lui.Forms.ComboBox();
                        this.Label25 = new Lui.Forms.Label();
                        this.Label24 = new Lui.Forms.Label();
                        this.EntradaStockDepositoPredet = new Lcc.Entrada.CodigoDetalle();
                        this.EntradaStockMultideposito = new Lui.Forms.ComboBox();
                        this.Label23 = new Lui.Forms.Label();
                        this.EntradaArticulosCodigoPredet = new Lui.Forms.ComboBox();
                        this.Label20 = new Lui.Forms.Label();
                        this.EntradaPV = new Lui.Forms.TextBox();
                        this.Label9 = new Lui.Forms.Label();
                        this.EntradaPVND = new Lui.Forms.TextBox();
                        this.Label10 = new Lui.Forms.Label();
                        this.Label8 = new Lui.Forms.Label();
                        this.Label7 = new Lui.Forms.Label();
                        this.EntradaPVNC = new Lui.Forms.TextBox();
                        this.EntradaPVABC = new Lui.Forms.TextBox();
                        this.Label6 = new Lui.Forms.Label();
                        this.Label5 = new Lui.Forms.Label();
                        this.Label4 = new Lui.Forms.Label();
                        this.Label16 = new Lui.Forms.Label();
                        this.EntradaClientePredet = new Lcc.Entrada.CodigoDetalle();
                        this.Label15 = new Lui.Forms.Label();
                        this.EntradaFormaPagoPredet = new Lcc.Entrada.CodigoDetalle();
                        this.BotonSiguiente = new Lui.Forms.Button();
                        this.FrmArticulos = new Lui.Forms.Frame();
                        this.label35 = new Lui.Forms.Label();
                        this.EntradaMonedaDecimalesCosto = new Lui.Forms.ComboBox();
                        this.EntradaMonedaDecimalesUnitarios = new Lui.Forms.ComboBox();
                        this.label34 = new Lui.Forms.Label();
                        this.EntradaMonedaDecimalesFinal = new Lui.Forms.ComboBox();
                        this.label18 = new Lui.Forms.Label();
                        this.EntradaMonedaUnidadMonetariaMinima = new Lui.Forms.TextBox();
                        this.label26 = new Lui.Forms.Label();
                        this.EntradaStockDepositoPredetSuc = new Lcc.Entrada.CodigoDetalle();
                        this.label22 = new Lui.Forms.Label();
                        this.FrmComprobantes = new Lui.Forms.Frame();
                        this.EntradaPVRC = new Lui.Forms.TextBox();
                        this.label3 = new Lui.Forms.Label();
                        this.label11 = new Lui.Forms.Label();
                        this.EntradaLimiteCredito = new Lui.Forms.TextBox();
                        this.label21 = new Lui.Forms.Label();
                        this.EntradaCambiaPrecioComprob = new Lui.Forms.YesNo();
                        this.label13 = new Lui.Forms.Label();
                        this.EntradaPVR = new Lui.Forms.TextBox();
                        this.label12 = new Lui.Forms.Label();
                        this.FrmAvanzado = new Lui.Forms.Frame();
                        this.buttonPanel1 = new Lui.Forms.ButtonPanel();
                        this.FrmGeneral.SuspendLayout();
                        this.FrmArticulos.SuspendLayout();
                        this.FrmComprobantes.SuspendLayout();
                        this.FrmAvanzado.SuspendLayout();
                        this.buttonPanel1.SuspendLayout();
                        this.SuspendLayout();
                        // 
                        // BotonAceptar
                        // 
                        this.BotonAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                        this.BotonAceptar.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.BotonAceptar.Image = null;
                        this.BotonAceptar.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.BotonAceptar.Location = new System.Drawing.Point(388, 12);
                        this.BotonAceptar.Margin = new System.Windows.Forms.Padding(6, 0, 0, 0);
                        this.BotonAceptar.MaximumSize = new System.Drawing.Size(108, 40);
                        this.BotonAceptar.MinimumSize = new System.Drawing.Size(96, 32);
                        this.BotonAceptar.Name = "BotonAceptar";
                        this.BotonAceptar.Size = new System.Drawing.Size(108, 40);
                        this.BotonAceptar.SubLabelPos = Lui.Forms.SubLabelPositions.None;
                        this.BotonAceptar.Subtext = "F9";
                        this.BotonAceptar.TabIndex = 1;
                        this.BotonAceptar.Text = "Guardar";
                        this.BotonAceptar.Click += new System.EventHandler(this.BotonAceptar_Click);
                        // 
                        // CancelCommandButton
                        // 
                        this.CancelCommandButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                        this.CancelCommandButton.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.CancelCommandButton.Image = null;
                        this.CancelCommandButton.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.CancelCommandButton.Location = new System.Drawing.Point(502, 12);
                        this.CancelCommandButton.Margin = new System.Windows.Forms.Padding(6, 0, 0, 0);
                        this.CancelCommandButton.MaximumSize = new System.Drawing.Size(108, 40);
                        this.CancelCommandButton.MinimumSize = new System.Drawing.Size(96, 32);
                        this.CancelCommandButton.Name = "CancelCommandButton";
                        this.CancelCommandButton.Size = new System.Drawing.Size(108, 40);
                        this.CancelCommandButton.SubLabelPos = Lui.Forms.SubLabelPositions.None;
                        this.CancelCommandButton.Subtext = "Esc";
                        this.CancelCommandButton.TabIndex = 2;
                        this.CancelCommandButton.Text = "Cancelar";
                        this.CancelCommandButton.Click += new System.EventHandler(this.BotonCancelar_Click);
                        // 
                        // EntradaEmpresaSituacion
                        // 
                        this.EntradaEmpresaSituacion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaEmpresaSituacion.AutoTab = true;
                        this.EntradaEmpresaSituacion.CanCreate = true;
                        this.EntradaEmpresaSituacion.Location = new System.Drawing.Point(208, 176);
                        this.EntradaEmpresaSituacion.MaxLength = 200;
                        this.EntradaEmpresaSituacion.Name = "EntradaEmpresaSituacion";
                        this.EntradaEmpresaSituacion.NombreTipo = "Lbl.Impuestos.SituacionTributaria";
                        this.EntradaEmpresaSituacion.Required = true;
                        this.EntradaEmpresaSituacion.Size = new System.Drawing.Size(256, 24);
                        this.EntradaEmpresaSituacion.TabIndex = 10;
                        this.EntradaEmpresaSituacion.Text = "0";
                        // 
                        // Label19
                        // 
                        this.Label19.Location = new System.Drawing.Point(24, 176);
                        this.Label19.Name = "Label19";
                        this.Label19.Size = new System.Drawing.Size(184, 24);
                        this.Label19.TabIndex = 9;
                        this.Label19.Text = "Condición IVA";
                        this.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaEmpresaClaveTributaria
                        // 
                        this.EntradaEmpresaClaveTributaria.Location = new System.Drawing.Point(208, 144);
                        this.EntradaEmpresaClaveTributaria.MaxLength = 50;
                        this.EntradaEmpresaClaveTributaria.Name = "EntradaEmpresaClaveTributaria";
                        this.EntradaEmpresaClaveTributaria.Size = new System.Drawing.Size(172, 24);
                        this.EntradaEmpresaClaveTributaria.TabIndex = 8;
                        // 
                        // EtiquetaClaveTributaria
                        // 
                        this.EtiquetaClaveTributaria.Location = new System.Drawing.Point(24, 144);
                        this.EtiquetaClaveTributaria.Name = "EtiquetaClaveTributaria";
                        this.EtiquetaClaveTributaria.Size = new System.Drawing.Size(184, 24);
                        this.EtiquetaClaveTributaria.TabIndex = 7;
                        this.EtiquetaClaveTributaria.Text = "Clave tributaria";
                        this.EtiquetaClaveTributaria.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaEmpresaNombre
                        // 
                        this.EntradaEmpresaNombre.ForceCase = Lui.Forms.TextCasing.Automatic;
                        this.EntradaEmpresaNombre.Location = new System.Drawing.Point(208, 80);
                        this.EntradaEmpresaNombre.MaxLength = 200;
                        this.EntradaEmpresaNombre.Name = "EntradaEmpresaNombre";
                        this.EntradaEmpresaNombre.Size = new System.Drawing.Size(368, 24);
                        this.EntradaEmpresaNombre.TabIndex = 4;
                        // 
                        // Label17
                        // 
                        this.Label17.Location = new System.Drawing.Point(24, 80);
                        this.Label17.Name = "Label17";
                        this.Label17.Size = new System.Drawing.Size(184, 24);
                        this.Label17.TabIndex = 3;
                        this.Label17.Text = "Nombre";
                        this.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // FrmGeneral
                        // 
                        this.FrmGeneral.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.FrmGeneral.Controls.Add(this.label36);
                        this.FrmGeneral.Controls.Add(this.EntradaSucursal);
                        this.FrmGeneral.Controls.Add(this.BotonCambiarPais);
                        this.FrmGeneral.Controls.Add(this.label33);
                        this.FrmGeneral.Controls.Add(this.EntradaEmpresaId);
                        this.FrmGeneral.Controls.Add(this.EntradaPais);
                        this.FrmGeneral.Controls.Add(this.Label17);
                        this.FrmGeneral.Controls.Add(this.label2);
                        this.FrmGeneral.Controls.Add(this.EntradaEmpresaNombre);
                        this.FrmGeneral.Controls.Add(this.EntradaEmpresaRazonSocial);
                        this.FrmGeneral.Controls.Add(this.label1);
                        this.FrmGeneral.Controls.Add(this.EntradaEmpresaClaveTributaria);
                        this.FrmGeneral.Controls.Add(this.EtiquetaClaveTributaria);
                        this.FrmGeneral.Controls.Add(this.EntradaProvincia);
                        this.FrmGeneral.Controls.Add(this.EntradaLocalidad);
                        this.FrmGeneral.Controls.Add(this.label32);
                        this.FrmGeneral.Controls.Add(this.label31);
                        this.FrmGeneral.Controls.Add(this.EntradaEmpresaEmail);
                        this.FrmGeneral.Controls.Add(this.EntradaEmpresaSituacion);
                        this.FrmGeneral.Controls.Add(this.Label19);
                        this.FrmGeneral.Controls.Add(this.label28);
                        this.FrmGeneral.Location = new System.Drawing.Point(16, 16);
                        this.FrmGeneral.Name = "FrmGeneral";
                        this.FrmGeneral.Size = new System.Drawing.Size(600, 368);
                        this.FrmGeneral.TabIndex = 0;
                        this.FrmGeneral.Text = "Datos de la empresa";
                        // 
                        // label36
                        // 
                        this.label36.Location = new System.Drawing.Point(24, 336);
                        this.label36.Name = "label36";
                        this.label36.Size = new System.Drawing.Size(184, 24);
                        this.label36.TabIndex = 19;
                        this.label36.Text = "Sucursal";
                        this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaSucursal
                        // 
                        this.EntradaSucursal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaSucursal.AutoTab = true;
                        this.EntradaSucursal.CanCreate = false;
                        this.EntradaSucursal.Location = new System.Drawing.Point(208, 336);
                        this.EntradaSucursal.MaxLength = 200;
                        this.EntradaSucursal.Name = "EntradaSucursal";
                        this.EntradaSucursal.NombreTipo = "Lbl.Entidades.Sucursal";
                        this.EntradaSucursal.Required = true;
                        this.EntradaSucursal.Size = new System.Drawing.Size(296, 24);
                        this.EntradaSucursal.TabIndex = 20;
                        this.EntradaSucursal.Text = "0";
                        // 
                        // BotonCambiarPais
                        // 
                        this.BotonCambiarPais.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.BotonCambiarPais.Image = null;
                        this.BotonCambiarPais.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.BotonCambiarPais.Location = new System.Drawing.Point(496, 40);
                        this.BotonCambiarPais.Margin = new System.Windows.Forms.Padding(6, 0, 0, 0);
                        this.BotonCambiarPais.MaximumSize = new System.Drawing.Size(108, 40);
                        this.BotonCambiarPais.MinimumSize = new System.Drawing.Size(80, 24);
                        this.BotonCambiarPais.Name = "BotonCambiarPais";
                        this.BotonCambiarPais.Size = new System.Drawing.Size(80, 24);
                        this.BotonCambiarPais.SubLabelPos = Lui.Forms.SubLabelPositions.None;
                        this.BotonCambiarPais.Subtext = "F9";
                        this.BotonCambiarPais.TabIndex = 2;
                        this.BotonCambiarPais.Text = "Cambiar";
                        this.BotonCambiarPais.Visible = false;
                        this.BotonCambiarPais.Click += new System.EventHandler(this.BotonCambiarPais_Click);
                        // 
                        // label33
                        // 
                        this.label33.Location = new System.Drawing.Point(24, 40);
                        this.label33.Name = "label33";
                        this.label33.Size = new System.Drawing.Size(184, 24);
                        this.label33.TabIndex = 0;
                        this.label33.Text = "País";
                        this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaEmpresaId
                        // 
                        this.EntradaEmpresaId.DataType = Lui.Forms.DataTypes.Integer;
                        this.EntradaEmpresaId.Location = new System.Drawing.Point(208, 304);
                        this.EntradaEmpresaId.MaxLength = 3;
                        this.EntradaEmpresaId.Name = "EntradaEmpresaId";
                        this.EntradaEmpresaId.Size = new System.Drawing.Size(48, 24);
                        this.EntradaEmpresaId.TabIndex = 18;
                        this.EntradaEmpresaId.Text = "0";
                        // 
                        // EntradaPais
                        // 
                        this.EntradaPais.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaPais.AutoTab = true;
                        this.EntradaPais.CanCreate = false;
                        this.EntradaPais.Location = new System.Drawing.Point(208, 40);
                        this.EntradaPais.MaxLength = 200;
                        this.EntradaPais.Name = "EntradaPais";
                        this.EntradaPais.NombreTipo = "Lbl.Entidades.Pais";
                        this.EntradaPais.Required = true;
                        this.EntradaPais.Size = new System.Drawing.Size(280, 24);
                        this.EntradaPais.TabIndex = 1;
                        this.EntradaPais.Text = "0";
                        this.EntradaPais.TextChanged += new System.EventHandler(this.EntradaPais_TextChanged);
                        // 
                        // label2
                        // 
                        this.label2.Location = new System.Drawing.Point(24, 304);
                        this.label2.Name = "label2";
                        this.label2.Size = new System.Drawing.Size(184, 24);
                        this.label2.TabIndex = 17;
                        this.label2.Text = "Id de empresa";
                        this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaEmpresaRazonSocial
                        // 
                        this.EntradaEmpresaRazonSocial.ForceCase = Lui.Forms.TextCasing.Automatic;
                        this.EntradaEmpresaRazonSocial.Location = new System.Drawing.Point(208, 112);
                        this.EntradaEmpresaRazonSocial.MaxLength = 200;
                        this.EntradaEmpresaRazonSocial.Name = "EntradaEmpresaRazonSocial";
                        this.EntradaEmpresaRazonSocial.Size = new System.Drawing.Size(368, 24);
                        this.EntradaEmpresaRazonSocial.TabIndex = 6;
                        // 
                        // label1
                        // 
                        this.label1.Location = new System.Drawing.Point(24, 112);
                        this.label1.Name = "label1";
                        this.label1.Size = new System.Drawing.Size(184, 24);
                        this.label1.TabIndex = 5;
                        this.label1.Text = "Razón social";
                        this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaProvincia
                        // 
                        this.EntradaProvincia.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaProvincia.AutoTab = true;
                        this.EntradaProvincia.CanCreate = true;
                        this.EntradaProvincia.Filter = "id_provincia IS NULL";
                        this.EntradaProvincia.Location = new System.Drawing.Point(208, 240);
                        this.EntradaProvincia.MaxLength = 200;
                        this.EntradaProvincia.Name = "EntradaProvincia";
                        this.EntradaProvincia.NombreTipo = "Lbl.Entidades.Localidad";
                        this.EntradaProvincia.Required = true;
                        this.EntradaProvincia.Size = new System.Drawing.Size(332, 24);
                        this.EntradaProvincia.TabIndex = 14;
                        this.EntradaProvincia.Text = "0";
                        this.EntradaProvincia.TextChanged += new System.EventHandler(this.EntradaProvincia_TextChanged);
                        // 
                        // EntradaLocalidad
                        // 
                        this.EntradaLocalidad.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaLocalidad.AutoTab = true;
                        this.EntradaLocalidad.CanCreate = true;
                        this.EntradaLocalidad.Filter = "id_provincia IS NOT NULL";
                        this.EntradaLocalidad.Location = new System.Drawing.Point(208, 272);
                        this.EntradaLocalidad.MaxLength = 200;
                        this.EntradaLocalidad.Name = "EntradaLocalidad";
                        this.EntradaLocalidad.NombreTipo = "Lbl.Entidades.Localidad";
                        this.EntradaLocalidad.Required = true;
                        this.EntradaLocalidad.Size = new System.Drawing.Size(332, 24);
                        this.EntradaLocalidad.TabIndex = 16;
                        this.EntradaLocalidad.Text = "0";
                        // 
                        // label32
                        // 
                        this.label32.Location = new System.Drawing.Point(24, 272);
                        this.label32.Name = "label32";
                        this.label32.Size = new System.Drawing.Size(184, 24);
                        this.label32.TabIndex = 15;
                        this.label32.Text = "Localidad o población";
                        this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // label31
                        // 
                        this.label31.Location = new System.Drawing.Point(24, 240);
                        this.label31.Name = "label31";
                        this.label31.Size = new System.Drawing.Size(184, 24);
                        this.label31.TabIndex = 13;
                        this.label31.Text = "Provincia o estado";
                        this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaEmpresaEmail
                        // 
                        this.EntradaEmpresaEmail.ForceCase = Lui.Forms.TextCasing.LowerCase;
                        this.EntradaEmpresaEmail.Location = new System.Drawing.Point(208, 208);
                        this.EntradaEmpresaEmail.MaxLength = 200;
                        this.EntradaEmpresaEmail.Name = "EntradaEmpresaEmail";
                        this.EntradaEmpresaEmail.Size = new System.Drawing.Size(352, 24);
                        this.EntradaEmpresaEmail.TabIndex = 12;
                        // 
                        // label28
                        // 
                        this.label28.Location = new System.Drawing.Point(24, 208);
                        this.label28.Name = "label28";
                        this.label28.Size = new System.Drawing.Size(184, 24);
                        this.label28.TabIndex = 11;
                        this.label28.Text = "Correo electrónico";
                        this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaActualizaciones
                        // 
                        this.EntradaActualizaciones.AlwaysExpanded = true;
                        this.EntradaActualizaciones.AutoSize = true;
                        this.EntradaActualizaciones.Location = new System.Drawing.Point(240, 272);
                        this.EntradaActualizaciones.Name = "EntradaActualizaciones";
                        this.EntradaActualizaciones.SetData = new string[] {
        "Estables|stable",
        "Preliminares|gama",
        "En prueba|beta"};
                        this.EntradaActualizaciones.Size = new System.Drawing.Size(132, 57);
                        this.EntradaActualizaciones.TabIndex = 21;
                        this.EntradaActualizaciones.TextKey = "stable";
                        // 
                        // label30
                        // 
                        this.label30.Location = new System.Drawing.Point(8, 272);
                        this.label30.Name = "label30";
                        this.label30.Size = new System.Drawing.Size(232, 24);
                        this.label30.TabIndex = 20;
                        this.label30.Text = "Recibir actualizaciones";
                        this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaAislacion
                        // 
                        this.EntradaAislacion.AlwaysExpanded = true;
                        this.EntradaAislacion.AutoSize = true;
                        this.EntradaAislacion.Location = new System.Drawing.Point(240, 216);
                        this.EntradaAislacion.Name = "EntradaAislacion";
                        this.EntradaAislacion.SetData = new string[] {
        "Mejor consitencia|Serializable",
        "Mejor concurrencia|RepeatableRead"};
                        this.EntradaAislacion.Size = new System.Drawing.Size(196, 40);
                        this.EntradaAislacion.TabIndex = 19;
                        this.EntradaAislacion.TextKey = "Serializable";
                        // 
                        // EntradaModoPantalla
                        // 
                        this.EntradaModoPantalla.AlwaysExpanded = true;
                        this.EntradaModoPantalla.AutoSize = true;
                        this.EntradaModoPantalla.Location = new System.Drawing.Point(240, 112);
                        this.EntradaModoPantalla.Name = "EntradaModoPantalla";
                        this.EntradaModoPantalla.SetData = new string[] {
        "Predeterminado|*",
        "Ventana normal|normal",
        "Ventana maximizada|maximizado",
        "Pantalla completa|completo",
        "Ventanas flotantes|flotante"};
                        this.EntradaModoPantalla.Size = new System.Drawing.Size(196, 91);
                        this.EntradaModoPantalla.TabIndex = 17;
                        this.EntradaModoPantalla.TextKey = "*";
                        // 
                        // EntradaBackup
                        // 
                        this.EntradaBackup.AlwaysExpanded = true;
                        this.EntradaBackup.AutoSize = true;
                        this.EntradaBackup.Location = new System.Drawing.Point(240, 40);
                        this.EntradaBackup.Name = "EntradaBackup";
                        this.EntradaBackup.SetData = new string[] {
        "Nunca|0",
        "Cuando se solicita|1",
        "Automáticamente|2"};
                        this.EntradaBackup.Size = new System.Drawing.Size(196, 57);
                        this.EntradaBackup.TabIndex = 0;
                        this.EntradaBackup.TextKey = "0";
                        // 
                        // label29
                        // 
                        this.label29.Location = new System.Drawing.Point(8, 216);
                        this.label29.Name = "label29";
                        this.label29.Size = new System.Drawing.Size(232, 24);
                        this.label29.TabIndex = 18;
                        this.label29.Text = "Nivel de aislamiento de clientes";
                        this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // label27
                        // 
                        this.label27.Location = new System.Drawing.Point(8, 112);
                        this.label27.Name = "label27";
                        this.label27.Size = new System.Drawing.Size(232, 24);
                        this.label27.TabIndex = 16;
                        this.label27.Text = "Modo de uso de la pantalla";
                        this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // label14
                        // 
                        this.label14.Location = new System.Drawing.Point(8, 40);
                        this.label14.Name = "label14";
                        this.label14.Size = new System.Drawing.Size(232, 24);
                        this.label14.TabIndex = 14;
                        this.label14.Text = "Realizar copias de seguridad";
                        this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaStockDecimales
                        // 
                        this.EntradaStockDecimales.AlwaysExpanded = false;
                        this.EntradaStockDecimales.Location = new System.Drawing.Point(184, 104);
                        this.EntradaStockDecimales.Name = "EntradaStockDecimales";
                        this.EntradaStockDecimales.SetData = new string[] {
        "Sin decimales|0",
        "Un decimal|1",
        "Dos decimales|2",
        "Tres decimales|3",
        "Cuatro decimales|4"};
                        this.EntradaStockDecimales.Size = new System.Drawing.Size(160, 24);
                        this.EntradaStockDecimales.TabIndex = 5;
                        this.EntradaStockDecimales.TextKey = "0";
                        // 
                        // Label25
                        // 
                        this.Label25.Location = new System.Drawing.Point(8, 104);
                        this.Label25.Name = "Label25";
                        this.Label25.Size = new System.Drawing.Size(176, 24);
                        this.Label25.TabIndex = 4;
                        this.Label25.Text = "Precisión de existencias";
                        this.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // Label24
                        // 
                        this.Label24.Location = new System.Drawing.Point(8, 136);
                        this.Label24.Name = "Label24";
                        this.Label24.Size = new System.Drawing.Size(176, 24);
                        this.Label24.TabIndex = 6;
                        this.Label24.Text = "Deposito predeterminado";
                        this.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaStockDepositoPredet
                        // 
                        this.EntradaStockDepositoPredet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaStockDepositoPredet.AutoTab = true;
                        this.EntradaStockDepositoPredet.CanCreate = true;
                        this.EntradaStockDepositoPredet.Location = new System.Drawing.Point(184, 136);
                        this.EntradaStockDepositoPredet.MaxLength = 200;
                        this.EntradaStockDepositoPredet.Name = "EntradaStockDepositoPredet";
                        this.EntradaStockDepositoPredet.NombreTipo = "Lbl.Articulos.Situacion";
                        this.EntradaStockDepositoPredet.Required = false;
                        this.EntradaStockDepositoPredet.Size = new System.Drawing.Size(396, 24);
                        this.EntradaStockDepositoPredet.TabIndex = 7;
                        this.EntradaStockDepositoPredet.Text = "0";
                        // 
                        // EntradaStockMultideposito
                        // 
                        this.EntradaStockMultideposito.AlwaysExpanded = false;
                        this.EntradaStockMultideposito.Location = new System.Drawing.Point(184, 72);
                        this.EntradaStockMultideposito.Name = "EntradaStockMultideposito";
                        this.EntradaStockMultideposito.SetData = new string[] {
        "Simple|0",
        "Multidepósito|1"};
                        this.EntradaStockMultideposito.Size = new System.Drawing.Size(224, 24);
                        this.EntradaStockMultideposito.TabIndex = 3;
                        this.EntradaStockMultideposito.TextKey = "0";
                        // 
                        // Label23
                        // 
                        this.Label23.Location = new System.Drawing.Point(8, 72);
                        this.Label23.Name = "Label23";
                        this.Label23.Size = new System.Drawing.Size(176, 24);
                        this.Label23.TabIndex = 2;
                        this.Label23.Text = "Control de existencias";
                        this.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaArticulosCodigoPredet
                        // 
                        this.EntradaArticulosCodigoPredet.AlwaysExpanded = false;
                        this.EntradaArticulosCodigoPredet.Location = new System.Drawing.Point(184, 40);
                        this.EntradaArticulosCodigoPredet.Name = "EntradaArticulosCodigoPredet";
                        this.EntradaArticulosCodigoPredet.SetData = new string[] {
        "Autonumérico incorporado|0",
        "Cód. 1|1",
        "Cód. 2|2",
        "Cód. 3|3",
        "Cód. 4|4"};
                        this.EntradaArticulosCodigoPredet.Size = new System.Drawing.Size(224, 24);
                        this.EntradaArticulosCodigoPredet.TabIndex = 1;
                        this.EntradaArticulosCodigoPredet.TextKey = "0";
                        // 
                        // Label20
                        // 
                        this.Label20.Location = new System.Drawing.Point(8, 40);
                        this.Label20.Name = "Label20";
                        this.Label20.Size = new System.Drawing.Size(176, 24);
                        this.Label20.TabIndex = 0;
                        this.Label20.Text = "Código predeterminado";
                        this.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaPV
                        // 
                        this.EntradaPV.DataType = Lui.Forms.DataTypes.Integer;
                        this.EntradaPV.Location = new System.Drawing.Point(244, 104);
                        this.EntradaPV.Name = "EntradaPV";
                        this.EntradaPV.Size = new System.Drawing.Size(56, 24);
                        this.EntradaPV.TabIndex = 5;
                        this.EntradaPV.Text = "0";
                        // 
                        // Label9
                        // 
                        this.Label9.Location = new System.Drawing.Point(304, 188);
                        this.Label9.Name = "Label9";
                        this.Label9.Size = new System.Drawing.Size(284, 24);
                        this.Label9.TabIndex = 14;
                        this.Label9.Text = "(0 para utilizar el mismo que para facturas)";
                        this.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        this.Label9.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.Small;
                        // 
                        // EntradaPVND
                        // 
                        this.EntradaPVND.DataType = Lui.Forms.DataTypes.Integer;
                        this.EntradaPVND.Location = new System.Drawing.Point(244, 188);
                        this.EntradaPVND.Name = "EntradaPVND";
                        this.EntradaPVND.Size = new System.Drawing.Size(56, 24);
                        this.EntradaPVND.TabIndex = 13;
                        this.EntradaPVND.Text = "0";
                        // 
                        // Label10
                        // 
                        this.Label10.Location = new System.Drawing.Point(8, 188);
                        this.Label10.Name = "Label10";
                        this.Label10.Size = new System.Drawing.Size(236, 24);
                        this.Label10.TabIndex = 12;
                        this.Label10.Text = "PV para notas de débito A, B y C";
                        this.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // Label8
                        // 
                        this.Label8.Location = new System.Drawing.Point(304, 160);
                        this.Label8.Name = "Label8";
                        this.Label8.Size = new System.Drawing.Size(284, 24);
                        this.Label8.TabIndex = 11;
                        this.Label8.Text = "(0 para utilizar el mismo que para facturas)";
                        this.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        this.Label8.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.Small;
                        // 
                        // Label7
                        // 
                        this.Label7.Location = new System.Drawing.Point(304, 132);
                        this.Label7.Name = "Label7";
                        this.Label7.Size = new System.Drawing.Size(284, 24);
                        this.Label7.TabIndex = 8;
                        this.Label7.Text = "(0 para utilizar el predeterminado)";
                        this.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        this.Label7.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.Small;
                        // 
                        // EntradaPVNC
                        // 
                        this.EntradaPVNC.DataType = Lui.Forms.DataTypes.Integer;
                        this.EntradaPVNC.Location = new System.Drawing.Point(244, 160);
                        this.EntradaPVNC.Name = "EntradaPVNC";
                        this.EntradaPVNC.Size = new System.Drawing.Size(56, 24);
                        this.EntradaPVNC.TabIndex = 10;
                        this.EntradaPVNC.Text = "0";
                        // 
                        // EntradaPVABC
                        // 
                        this.EntradaPVABC.DataType = Lui.Forms.DataTypes.Integer;
                        this.EntradaPVABC.Location = new System.Drawing.Point(244, 132);
                        this.EntradaPVABC.Name = "EntradaPVABC";
                        this.EntradaPVABC.Size = new System.Drawing.Size(56, 24);
                        this.EntradaPVABC.TabIndex = 7;
                        this.EntradaPVABC.Text = "0";
                        // 
                        // Label6
                        // 
                        this.Label6.Location = new System.Drawing.Point(8, 160);
                        this.Label6.Name = "Label6";
                        this.Label6.Size = new System.Drawing.Size(236, 24);
                        this.Label6.TabIndex = 9;
                        this.Label6.Text = "PV para notas de crédito A, B y C";
                        this.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // Label5
                        // 
                        this.Label5.Location = new System.Drawing.Point(8, 132);
                        this.Label5.Name = "Label5";
                        this.Label5.Size = new System.Drawing.Size(236, 24);
                        this.Label5.TabIndex = 6;
                        this.Label5.Text = "PV para facturas A, B y C";
                        this.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // Label4
                        // 
                        this.Label4.Location = new System.Drawing.Point(8, 104);
                        this.Label4.Name = "Label4";
                        this.Label4.Size = new System.Drawing.Size(236, 24);
                        this.Label4.TabIndex = 4;
                        this.Label4.Text = "PV predeterminado";
                        this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // Label16
                        // 
                        this.Label16.Location = new System.Drawing.Point(8, 40);
                        this.Label16.Name = "Label16";
                        this.Label16.Size = new System.Drawing.Size(208, 24);
                        this.Label16.TabIndex = 0;
                        this.Label16.Text = "Cliente predeterminado";
                        this.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaClientePredet
                        // 
                        this.EntradaClientePredet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaClientePredet.AutoTab = true;
                        this.EntradaClientePredet.CanCreate = true;
                        this.EntradaClientePredet.Location = new System.Drawing.Point(216, 40);
                        this.EntradaClientePredet.MaxLength = 200;
                        this.EntradaClientePredet.Name = "EntradaClientePredet";
                        this.EntradaClientePredet.NombreTipo = "Lbl.Personas.Persona";
                        this.EntradaClientePredet.PlaceholderText = "Ninguno";
                        this.EntradaClientePredet.Required = false;
                        this.EntradaClientePredet.Size = new System.Drawing.Size(384, 24);
                        this.EntradaClientePredet.TabIndex = 1;
                        this.EntradaClientePredet.Text = "0";
                        // 
                        // Label15
                        // 
                        this.Label15.Location = new System.Drawing.Point(8, 68);
                        this.Label15.Name = "Label15";
                        this.Label15.Size = new System.Drawing.Size(208, 24);
                        this.Label15.TabIndex = 2;
                        this.Label15.Text = "Forma de pago predeterminada";
                        this.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaFormaPagoPredet
                        // 
                        this.EntradaFormaPagoPredet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaFormaPagoPredet.AutoTab = true;
                        this.EntradaFormaPagoPredet.CanCreate = true;
                        this.EntradaFormaPagoPredet.Filter = "estado=1";
                        this.EntradaFormaPagoPredet.Location = new System.Drawing.Point(216, 68);
                        this.EntradaFormaPagoPredet.MaxLength = 200;
                        this.EntradaFormaPagoPredet.Name = "EntradaFormaPagoPredet";
                        this.EntradaFormaPagoPredet.NombreTipo = "Lbl.Pagos.FormaDePago";
                        this.EntradaFormaPagoPredet.PlaceholderText = "Ninguna";
                        this.EntradaFormaPagoPredet.Required = false;
                        this.EntradaFormaPagoPredet.Size = new System.Drawing.Size(224, 24);
                        this.EntradaFormaPagoPredet.TabIndex = 3;
                        this.EntradaFormaPagoPredet.Text = "0";
                        // 
                        // BotonSiguiente
                        // 
                        this.BotonSiguiente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                        this.BotonSiguiente.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.BotonSiguiente.Image = null;
                        this.BotonSiguiente.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.BotonSiguiente.Location = new System.Drawing.Point(274, 12);
                        this.BotonSiguiente.Margin = new System.Windows.Forms.Padding(6, 0, 0, 0);
                        this.BotonSiguiente.MaximumSize = new System.Drawing.Size(108, 40);
                        this.BotonSiguiente.MinimumSize = new System.Drawing.Size(96, 32);
                        this.BotonSiguiente.Name = "BotonSiguiente";
                        this.BotonSiguiente.Size = new System.Drawing.Size(108, 40);
                        this.BotonSiguiente.SubLabelPos = Lui.Forms.SubLabelPositions.None;
                        this.BotonSiguiente.Subtext = "F9";
                        this.BotonSiguiente.TabIndex = 0;
                        this.BotonSiguiente.Text = "Más...";
                        this.BotonSiguiente.Click += new System.EventHandler(this.BotonSiguiente_Click);
                        // 
                        // FrmArticulos
                        // 
                        this.FrmArticulos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.FrmArticulos.Controls.Add(this.Label20);
                        this.FrmArticulos.Controls.Add(this.EntradaArticulosCodigoPredet);
                        this.FrmArticulos.Controls.Add(this.label35);
                        this.FrmArticulos.Controls.Add(this.EntradaMonedaDecimalesCosto);
                        this.FrmArticulos.Controls.Add(this.EntradaMonedaDecimalesUnitarios);
                        this.FrmArticulos.Controls.Add(this.Label25);
                        this.FrmArticulos.Controls.Add(this.label34);
                        this.FrmArticulos.Controls.Add(this.EntradaMonedaDecimalesFinal);
                        this.FrmArticulos.Controls.Add(this.label18);
                        this.FrmArticulos.Controls.Add(this.EntradaStockDecimales);
                        this.FrmArticulos.Controls.Add(this.EntradaMonedaUnidadMonetariaMinima);
                        this.FrmArticulos.Controls.Add(this.label26);
                        this.FrmArticulos.Controls.Add(this.EntradaStockDepositoPredetSuc);
                        this.FrmArticulos.Controls.Add(this.Label23);
                        this.FrmArticulos.Controls.Add(this.Label24);
                        this.FrmArticulos.Controls.Add(this.EntradaStockMultideposito);
                        this.FrmArticulos.Controls.Add(this.label22);
                        this.FrmArticulos.Controls.Add(this.EntradaStockDepositoPredet);
                        this.FrmArticulos.Location = new System.Drawing.Point(16, 16);
                        this.FrmArticulos.Name = "FrmArticulos";
                        this.FrmArticulos.Size = new System.Drawing.Size(600, 368);
                        this.FrmArticulos.TabIndex = 0;
                        this.FrmArticulos.Text = "Existencias y precios";
                        this.FrmArticulos.Visible = false;
                        // 
                        // label35
                        // 
                        this.label35.Location = new System.Drawing.Point(8, 216);
                        this.label35.Name = "label35";
                        this.label35.Size = new System.Drawing.Size(176, 24);
                        this.label35.TabIndex = 10;
                        this.label35.Text = "Precios de costo";
                        this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaMonedaDecimalesCosto
                        // 
                        this.EntradaMonedaDecimalesCosto.AlwaysExpanded = false;
                        this.EntradaMonedaDecimalesCosto.Location = new System.Drawing.Point(184, 216);
                        this.EntradaMonedaDecimalesCosto.Name = "EntradaMonedaDecimalesCosto";
                        this.EntradaMonedaDecimalesCosto.SetData = new string[] {
        "Sin decimales|0",
        "Un decimal|1",
        "Dos decimales|2",
        "Tres decimales|3",
        "Cuatro decimales|4"};
                        this.EntradaMonedaDecimalesCosto.Size = new System.Drawing.Size(160, 24);
                        this.EntradaMonedaDecimalesCosto.TabIndex = 11;
                        this.EntradaMonedaDecimalesCosto.TextKey = "0";
                        // 
                        // EntradaMonedaDecimalesUnitarios
                        // 
                        this.EntradaMonedaDecimalesUnitarios.AlwaysExpanded = false;
                        this.EntradaMonedaDecimalesUnitarios.Location = new System.Drawing.Point(184, 248);
                        this.EntradaMonedaDecimalesUnitarios.Name = "EntradaMonedaDecimalesUnitarios";
                        this.EntradaMonedaDecimalesUnitarios.SetData = new string[] {
        "Sin decimales|0",
        "Un decimal|1",
        "Dos decimales|2",
        "Tres decimales|3",
        "Cuatro decimales|4"};
                        this.EntradaMonedaDecimalesUnitarios.Size = new System.Drawing.Size(160, 24);
                        this.EntradaMonedaDecimalesUnitarios.TabIndex = 13;
                        this.EntradaMonedaDecimalesUnitarios.TextKey = "0";
                        // 
                        // label34
                        // 
                        this.label34.Location = new System.Drawing.Point(8, 248);
                        this.label34.Name = "label34";
                        this.label34.Size = new System.Drawing.Size(176, 24);
                        this.label34.TabIndex = 12;
                        this.label34.Text = "Precios unitarios";
                        this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaMonedaDecimalesFinal
                        // 
                        this.EntradaMonedaDecimalesFinal.AlwaysExpanded = false;
                        this.EntradaMonedaDecimalesFinal.Location = new System.Drawing.Point(184, 280);
                        this.EntradaMonedaDecimalesFinal.Name = "EntradaMonedaDecimalesFinal";
                        this.EntradaMonedaDecimalesFinal.SetData = new string[] {
        "Sin decimales|0",
        "Un decimal|1",
        "Dos decimales|2",
        "Tres decimales|3",
        "Cuatro decimales|4"};
                        this.EntradaMonedaDecimalesFinal.Size = new System.Drawing.Size(160, 24);
                        this.EntradaMonedaDecimalesFinal.TabIndex = 15;
                        this.EntradaMonedaDecimalesFinal.TextKey = "0";
                        // 
                        // label18
                        // 
                        this.label18.Location = new System.Drawing.Point(8, 280);
                        this.label18.Name = "label18";
                        this.label18.Size = new System.Drawing.Size(176, 24);
                        this.label18.TabIndex = 14;
                        this.label18.Text = "Total del comprobante";
                        this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaMonedaUnidadMonetariaMinima
                        // 
                        this.EntradaMonedaUnidadMonetariaMinima.DataType = Lui.Forms.DataTypes.Currency;
                        this.EntradaMonedaUnidadMonetariaMinima.Location = new System.Drawing.Point(240, 312);
                        this.EntradaMonedaUnidadMonetariaMinima.Name = "EntradaMonedaUnidadMonetariaMinima";
                        this.EntradaMonedaUnidadMonetariaMinima.Size = new System.Drawing.Size(92, 24);
                        this.EntradaMonedaUnidadMonetariaMinima.TabIndex = 17;
                        this.EntradaMonedaUnidadMonetariaMinima.Text = "0.00";
                        // 
                        // label26
                        // 
                        this.label26.Location = new System.Drawing.Point(8, 168);
                        this.label26.Name = "label26";
                        this.label26.Size = new System.Drawing.Size(176, 24);
                        this.label26.TabIndex = 8;
                        this.label26.Text = "Deposito sucursal";
                        this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaStockDepositoPredetSuc
                        // 
                        this.EntradaStockDepositoPredetSuc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaStockDepositoPredetSuc.AutoTab = true;
                        this.EntradaStockDepositoPredetSuc.CanCreate = true;
                        this.EntradaStockDepositoPredetSuc.Location = new System.Drawing.Point(184, 168);
                        this.EntradaStockDepositoPredetSuc.MaxLength = 200;
                        this.EntradaStockDepositoPredetSuc.Name = "EntradaStockDepositoPredetSuc";
                        this.EntradaStockDepositoPredetSuc.NombreTipo = "Lbl.Articulos.Situacion";
                        this.EntradaStockDepositoPredetSuc.Required = false;
                        this.EntradaStockDepositoPredetSuc.Size = new System.Drawing.Size(396, 24);
                        this.EntradaStockDepositoPredetSuc.TabIndex = 9;
                        this.EntradaStockDepositoPredetSuc.Text = "0";
                        // 
                        // label22
                        // 
                        this.label22.Location = new System.Drawing.Point(8, 312);
                        this.label22.Name = "label22";
                        this.label22.Size = new System.Drawing.Size(236, 24);
                        this.label22.TabIndex = 16;
                        this.label22.Text = "Denominación monetaria mínima";
                        this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // FrmComprobantes
                        // 
                        this.FrmComprobantes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.FrmComprobantes.Controls.Add(this.Label16);
                        this.FrmComprobantes.Controls.Add(this.EntradaPVRC);
                        this.FrmComprobantes.Controls.Add(this.label3);
                        this.FrmComprobantes.Controls.Add(this.label11);
                        this.FrmComprobantes.Controls.Add(this.EntradaLimiteCredito);
                        this.FrmComprobantes.Controls.Add(this.label21);
                        this.FrmComprobantes.Controls.Add(this.EntradaCambiaPrecioComprob);
                        this.FrmComprobantes.Controls.Add(this.label13);
                        this.FrmComprobantes.Controls.Add(this.EntradaPVR);
                        this.FrmComprobantes.Controls.Add(this.label12);
                        this.FrmComprobantes.Controls.Add(this.EntradaPV);
                        this.FrmComprobantes.Controls.Add(this.Label9);
                        this.FrmComprobantes.Controls.Add(this.EntradaPVND);
                        this.FrmComprobantes.Controls.Add(this.Label10);
                        this.FrmComprobantes.Controls.Add(this.Label8);
                        this.FrmComprobantes.Controls.Add(this.Label7);
                        this.FrmComprobantes.Controls.Add(this.EntradaPVNC);
                        this.FrmComprobantes.Controls.Add(this.EntradaPVABC);
                        this.FrmComprobantes.Controls.Add(this.Label6);
                        this.FrmComprobantes.Controls.Add(this.Label5);
                        this.FrmComprobantes.Controls.Add(this.Label4);
                        this.FrmComprobantes.Controls.Add(this.EntradaFormaPagoPredet);
                        this.FrmComprobantes.Controls.Add(this.EntradaClientePredet);
                        this.FrmComprobantes.Controls.Add(this.Label15);
                        this.FrmComprobantes.Location = new System.Drawing.Point(16, 16);
                        this.FrmComprobantes.Name = "FrmComprobantes";
                        this.FrmComprobantes.Size = new System.Drawing.Size(600, 368);
                        this.FrmComprobantes.TabIndex = 0;
                        this.FrmComprobantes.Text = "Comprobantes";
                        this.FrmComprobantes.Visible = false;
                        // 
                        // EntradaPVRC
                        // 
                        this.EntradaPVRC.DataType = Lui.Forms.DataTypes.Integer;
                        this.EntradaPVRC.Location = new System.Drawing.Point(244, 244);
                        this.EntradaPVRC.Name = "EntradaPVRC";
                        this.EntradaPVRC.Size = new System.Drawing.Size(56, 24);
                        this.EntradaPVRC.TabIndex = 19;
                        this.EntradaPVRC.Text = "0";
                        // 
                        // label3
                        // 
                        this.label3.Location = new System.Drawing.Point(8, 244);
                        this.label3.Name = "label3";
                        this.label3.Size = new System.Drawing.Size(236, 24);
                        this.label3.TabIndex = 18;
                        this.label3.Text = "PV para recibos";
                        this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // label11
                        // 
                        this.label11.Location = new System.Drawing.Point(304, 216);
                        this.label11.Name = "label11";
                        this.label11.Size = new System.Drawing.Size(284, 24);
                        this.label11.TabIndex = 17;
                        this.label11.Text = "(0 para utilizar el mismo que para facturas)";
                        this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        this.label11.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.Small;
                        // 
                        // EntradaLimiteCredito
                        // 
                        this.EntradaLimiteCredito.DataType = Lui.Forms.DataTypes.Currency;
                        this.EntradaLimiteCredito.Location = new System.Drawing.Point(244, 320);
                        this.EntradaLimiteCredito.Name = "EntradaLimiteCredito";
                        this.EntradaLimiteCredito.Size = new System.Drawing.Size(124, 24);
                        this.EntradaLimiteCredito.TabIndex = 23;
                        this.EntradaLimiteCredito.Text = "0.00";
                        // 
                        // label21
                        // 
                        this.label21.Location = new System.Drawing.Point(8, 320);
                        this.label21.Name = "label21";
                        this.label21.Size = new System.Drawing.Size(236, 24);
                        this.label21.TabIndex = 22;
                        this.label21.Text = "Límite de crédito predeterminado";
                        this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaCambiaPrecioComprob
                        // 
                        this.EntradaCambiaPrecioComprob.Location = new System.Drawing.Point(416, 284);
                        this.EntradaCambiaPrecioComprob.Name = "EntradaCambiaPrecioComprob";
                        this.EntradaCambiaPrecioComprob.Size = new System.Drawing.Size(64, 24);
                        this.EntradaCambiaPrecioComprob.TabIndex = 21;
                        this.EntradaCambiaPrecioComprob.Value = true;
                        // 
                        // label13
                        // 
                        this.label13.Location = new System.Drawing.Point(8, 284);
                        this.label13.Name = "label13";
                        this.label13.Size = new System.Drawing.Size(408, 24);
                        this.label13.TabIndex = 20;
                        this.label13.Text = "Permite cambiar precio del artículo durante la facturación";
                        this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaPVR
                        // 
                        this.EntradaPVR.DataType = Lui.Forms.DataTypes.Integer;
                        this.EntradaPVR.Location = new System.Drawing.Point(244, 216);
                        this.EntradaPVR.Name = "EntradaPVR";
                        this.EntradaPVR.Size = new System.Drawing.Size(56, 24);
                        this.EntradaPVR.TabIndex = 16;
                        this.EntradaPVR.Text = "0";
                        // 
                        // label12
                        // 
                        this.label12.Location = new System.Drawing.Point(8, 216);
                        this.label12.Name = "label12";
                        this.label12.Size = new System.Drawing.Size(236, 24);
                        this.label12.TabIndex = 15;
                        this.label12.Text = "PV para remitos";
                        this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // FrmAvanzado
                        // 
                        this.FrmAvanzado.Controls.Add(this.label14);
                        this.FrmAvanzado.Controls.Add(this.EntradaBackup);
                        this.FrmAvanzado.Controls.Add(this.label27);
                        this.FrmAvanzado.Controls.Add(this.EntradaModoPantalla);
                        this.FrmAvanzado.Controls.Add(this.label29);
                        this.FrmAvanzado.Controls.Add(this.EntradaAislacion);
                        this.FrmAvanzado.Controls.Add(this.EntradaActualizaciones);
                        this.FrmAvanzado.Controls.Add(this.label30);
                        this.FrmAvanzado.Location = new System.Drawing.Point(16, 16);
                        this.FrmAvanzado.Name = "FrmAvanzado";
                        this.FrmAvanzado.Size = new System.Drawing.Size(600, 368);
                        this.FrmAvanzado.TabIndex = 8;
                        this.FrmAvanzado.Text = "Avanzado";
                        this.FrmAvanzado.Visible = false;
                        // 
                        // buttonPanel1
                        // 
                        this.buttonPanel1.Controls.Add(this.CancelCommandButton);
                        this.buttonPanel1.Controls.Add(this.BotonAceptar);
                        this.buttonPanel1.Controls.Add(this.BotonSiguiente);
                        this.buttonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
                        this.buttonPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
                        this.buttonPanel1.Location = new System.Drawing.Point(0, 384);
                        this.buttonPanel1.Name = "buttonPanel1";
                        this.buttonPanel1.Padding = new System.Windows.Forms.Padding(12);
                        this.buttonPanel1.Size = new System.Drawing.Size(634, 64);
                        this.buttonPanel1.TabIndex = 100;
                        // 
                        // Preferencias
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
                        this.ClientSize = new System.Drawing.Size(634, 448);
                        this.Controls.Add(this.buttonPanel1);
                        this.Controls.Add(this.FrmGeneral);
                        this.Controls.Add(this.FrmComprobantes);
                        this.Controls.Add(this.FrmArticulos);
                        this.Controls.Add(this.FrmAvanzado);
                        this.ForeColor = System.Drawing.SystemColors.ControlText;
                        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
                        this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
                        this.Name = "Preferencias";
                        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                        this.Text = "Preferencias";
                        this.FrmGeneral.ResumeLayout(false);
                        this.FrmGeneral.PerformLayout();
                        this.FrmArticulos.ResumeLayout(false);
                        this.FrmArticulos.PerformLayout();
                        this.FrmComprobantes.ResumeLayout(false);
                        this.FrmComprobantes.PerformLayout();
                        this.FrmAvanzado.ResumeLayout(false);
                        this.FrmAvanzado.PerformLayout();
                        this.buttonPanel1.ResumeLayout(false);
                        this.ResumeLayout(false);

		}
		#endregion

                private Lui.Forms.Button BotonAceptar;
                private Lui.Forms.Button CancelCommandButton;
                private Lui.Forms.Label Label16;
                private Lcc.Entrada.CodigoDetalle EntradaClientePredet;
                private Lui.Forms.Label Label15;
                private Lcc.Entrada.CodigoDetalle EntradaFormaPagoPredet;
                private Lui.Forms.Label Label17;
                private Lui.Forms.TextBox EntradaEmpresaNombre;
                private Lui.Forms.Label EtiquetaClaveTributaria;
                private Lui.Forms.Label Label19;
                private Lui.Forms.TextBox EntradaEmpresaClaveTributaria;
                private Lcc.Entrada.CodigoDetalle EntradaEmpresaSituacion;
                private Lui.Forms.Label Label9;
                private Lui.Forms.TextBox EntradaPVND;
                private Lui.Forms.Label Label10;
                private Lui.Forms.Label Label8;
                private Lui.Forms.Label Label7;
                private Lui.Forms.TextBox EntradaPVNC;
                private Lui.Forms.TextBox EntradaPVABC;
                private Lui.Forms.Label Label6;
                private Lui.Forms.Label Label5;
                private Lui.Forms.Label Label4;
                private Lui.Forms.Label Label20;
                private Lui.Forms.TextBox EntradaPV;
                private Lui.Forms.ComboBox EntradaArticulosCodigoPredet;
                private Lui.Forms.ComboBox EntradaStockMultideposito;
                private Lui.Forms.Label Label23;
                private Lui.Forms.Label Label24;
                private Lcc.Entrada.CodigoDetalle EntradaStockDepositoPredet;
                private Lui.Forms.Label Label25;
                private Lui.Forms.ComboBox EntradaStockDecimales;
                private Lui.Forms.Button BotonSiguiente;
                private Lui.Forms.Frame FrmArticulos;
                private Lui.Forms.Frame FrmComprobantes;
                private Lui.Forms.ComboBox EntradaBackup;
                private Lui.Forms.Label label14;
                private Lui.Forms.TextBox EntradaLimiteCredito;
                private Lui.Forms.Label label21;
                private Lui.Forms.TextBox EntradaMonedaUnidadMonetariaMinima;
                private Lui.Forms.Label label22;
                private Lui.Forms.ComboBox EntradaModoPantalla;
                private Lui.Forms.Label label27;
                private Lui.Forms.TextBox EntradaEmpresaEmail;
                private Lui.Forms.Label label28;
                private Lui.Forms.ComboBox EntradaAislacion;
                private Lui.Forms.Label label29;
                private Lui.Forms.ComboBox EntradaActualizaciones;
                private Lui.Forms.Label label30;
                private Lui.Forms.TextBox EntradaEmpresaRazonSocial;
                private Lui.Forms.Label label1;
                private Lui.Forms.TextBox EntradaPVRC;
                private Lui.Forms.Label label3;
                private Lui.Forms.TextBox EntradaEmpresaId;
                private Lui.Forms.Label label2;
                private Lui.Forms.Frame FrmGeneral;
                private Lui.Forms.Label label26;
                private Lcc.Entrada.CodigoDetalle EntradaStockDepositoPredetSuc;
                private Lui.Forms.Label label11;
                private Lui.Forms.Label label12;
                private Lui.Forms.TextBox EntradaPVR;
                private Lui.Forms.YesNo EntradaCambiaPrecioComprob;
                private Lui.Forms.Label label13;
                private Lcc.Entrada.CodigoDetalle EntradaProvincia;
                private Lui.Forms.Label label31;
                private Lui.Forms.Frame FrmAvanzado;
                private Lcc.Entrada.CodigoDetalle EntradaLocalidad;
                private Lui.Forms.Label label32;
                private Lcc.Entrada.CodigoDetalle EntradaPais;
                private Lui.Forms.Label label33;
                private Lui.Forms.ComboBox EntradaMonedaDecimalesFinal;
                private Lui.Forms.Label label18;
                private Lui.Forms.ComboBox EntradaMonedaDecimalesUnitarios;
                private Lui.Forms.Label label34;
                private Lui.Forms.ComboBox EntradaMonedaDecimalesCosto;
                private Lui.Forms.Label label35;
                private Lui.Forms.ButtonPanel buttonPanel1;
                private Lui.Forms.Button BotonCambiarPais;
                private Lui.Forms.Label label36;
                private Lcc.Entrada.CodigoDetalle EntradaSucursal;
	}
}
