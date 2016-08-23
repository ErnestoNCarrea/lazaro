using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Lazaro.WinMain.Config
{
        public partial class Preferencias : Lui.Forms.Form
        {
                private bool m_PrimeraVez = false;
                private int CurrentTab = 1;
                private const int TabCount = 4;
                private int IdPaisOriginal = 0;
                private Lbl.Sys.Blob Logo { get; set; }

                public Preferencias()
                {
                        InitializeComponent();
                }


                protected override void OnLoad(System.EventArgs e)
                {
                        base.OnLoad(e);
                        CargarConfig();
                }

                private void BotonCancelar_Click(object sender, System.EventArgs e)
                {
                        this.DialogResult = DialogResult.Cancel;
                        this.Close();
                }


                private void BotonAceptar_Click(object sender, System.EventArgs e)
                {
                        if (GuardarConfig() == false) {
                                this.DialogResult = DialogResult.OK;
                                this.Close();
                                Lfx.Workspace.Master.RunTime.Toast("Algunos cambios tendrán efecto la próxima vez que ingrese Lázaro. Si lo desea puede salir de Lázaro y volver a ingresar. También puede ser necesario que lo haga en otros equipos en la red.", "Aviso");
                        }
                }


                /// <summary>
                /// Indica si se está mostrando las preferencias en el primer inicio
                /// </summary>
                public bool PrimeraVez
                {
                        get
                        {
                                return m_PrimeraVez;
                        }
                        set
                        {
                                m_PrimeraVez = value;
                                BotonSiguiente.Visible = !value;
                                EntradaPais.ReadOnly = !value;
                                BotonCambiarPais.Visible = EntradaPais.ReadOnly;
                        }
                }


                private void CargarConfig()
                {
                        if (Lfx.Workspace.Master == null)
                                return;

                        string[] ListaCodigos = new string[5];
                        ListaCodigos[0] = "Código autonumérico incorporado|0";
                        DataTable Codigos = this.Connection.Select("SELECT * FROM articulos_codigos ORDER BY id_codigo LIMIT 4");
                        foreach (System.Data.DataRow Codigo in Codigos.Rows) {
                                ListaCodigos[System.Convert.ToInt32(Codigo["id_codigo"])] += System.Convert.ToString(Codigo["nombre"]) + "|" + System.Convert.ToString(Codigo["id_codigo"]);
                        }
                        EntradaArticulosCodigoPredet.SetData = ListaCodigos;
                        EntradaArticulosCodigoPredet.TextKey = Lfx.Workspace.Master.CurrentConfig.ReadGlobalSetting<string>("Sistema.Stock.CodigoPredet", "*");

                        EntradaStockMultideposito.TextKey = Lfx.Workspace.Master.CurrentConfig.ReadGlobalSetting<string>("Sistema.Stock.Multideposito", "0");
                        EntradaStockDepositoPredet.Text = Lfx.Workspace.Master.CurrentConfig.ReadGlobalSetting<string>("Sistema.Stock.DepositoPredet", "0");
                        EntradaStockDepositoPredetSuc.Text = Lfx.Workspace.Master.CurrentConfig.ReadGlobalSetting<string>("Sistema.Stock.DepositoPredet", "0");
                        EntradaStockDecimales.TextKey = Lfx.Workspace.Master.CurrentConfig.ReadGlobalSetting<string>("Sistema.Stock.Decimales", "0");

                        EntradaEmpresaNombre.Text = Lbl.Sys.Config.Empresa.Nombre;
                        EntradaEmpresaRazonSocial.Text = Lbl.Sys.Config.Empresa.RazonSocial;
                        if (Lbl.Sys.Config.Empresa.ClaveTributaria == null)
                                EntradaEmpresaClaveTributaria.Text = "";
                        else
                                EntradaEmpresaClaveTributaria.Text = Lbl.Sys.Config.Empresa.ClaveTributaria.ToString();
                        EntradaEmpresaSituacion.ValueInt = Lbl.Sys.Config.Empresa.SituacionTributaria;
                        EntradaEmpresaEmail.Text = Lbl.Sys.Config.Empresa.Email;
                        EntradaEmpresaId.ValueInt = Lbl.Sys.Config.Empresa.Id;
                        EntradaIngresosBrutos.Text = Lbl.Sys.Config.Empresa.NumeroIngresosBrutos;
                        if (Lbl.Sys.Config.Empresa.InicioDeActividades == null) {
                                EntradaInicioActividades.Text = "";
                        } else {
                                EntradaInicioActividades.Text = Lbl.Sys.Config.Empresa.InicioDeActividades.ToString(Lfx.Types.Formatting.DateTime.ShortDatePattern);
                        }

                        EntradaBackup.TextKey = Lfx.Workspace.Master.CurrentConfig.ReadGlobalSetting<string>("Sistema.Backup.Tipo", "0");
                        EntradaModoPantalla.TextKey = Lfx.Workspace.Master.CurrentConfig.ReadGlobalSetting<string>("Sistema.Apariencia.ModoPantalla", "maximizado");
                        EntradaActualizaciones.TextKey = Lfx.Workspace.Master.CurrentConfig.ReadGlobalSetting<string>("Sistema.Actualizaciones.Nivel", "stable");

                        EntradaPV.Text = Lfx.Workspace.Master.CurrentConfig.ReadGlobalSetting<string>("Sistema.Documentos.PV", "1");
                        EntradaPVABC.Text = Lfx.Workspace.Master.CurrentConfig.ReadGlobalSetting<string>("Sistema.Documentos.ABC.PV", "0");
                        EntradaPVNC.Text = Lfx.Workspace.Master.CurrentConfig.ReadGlobalSetting<string>("Sistema.Documentos.NC.PV", "0");
                        EntradaPVND.Text = Lfx.Workspace.Master.CurrentConfig.ReadGlobalSetting<string>("Sistema.Documentos.ND.PV", "0");
                        EntradaPVR.Text = Lfx.Workspace.Master.CurrentConfig.ReadGlobalSetting<string>("Sistema.Documentos.R.PV", "0");
                        EntradaPVRC.Text = Lfx.Workspace.Master.CurrentConfig.ReadGlobalSetting<string>("Sistema.Documentos.RC.PV", "0");

                        EntradaClientePredet.Text = Lfx.Workspace.Master.CurrentConfig.ReadGlobalSetting<string>("Sistema.Documentos.ClientePredet", "");
                        EntradaFormaPagoPredet.Text = Lfx.Workspace.Master.CurrentConfig.ReadGlobalSetting<string>("Sistema.Documentos.FormaPagoPredet", "");

                        EntradaCambiaPrecioComprob.Value = Lfx.Workspace.Master.CurrentConfig.ReadGlobalSetting<string>("Sistema.Documentos.CambiaPrecioItemFactura", "1") == "1";

                        EntradaLimiteCredito.Text = Lfx.Workspace.Master.CurrentConfig.ReadGlobalSetting<string>("Sistema.Cuentas.LimiteCreditoPredet", "0");

                        int PaisActual = Lfx.Workspace.Master.CurrentConfig.ReadGlobalSetting<int>("Sistema.Pais", 0);
                        IdPaisOriginal = PaisActual;
                        if (PaisActual == 0)
                                this.PrimeraVez = true;
                        else
                                this.PrimeraVez = false;

                        EntradaPais.ValueInt = PaisActual == 0 ? 1 : PaisActual;
                        EntradaProvincia.ValueInt = Lfx.Workspace.Master.CurrentConfig.ReadGlobalSetting<int>("Sistema.Provincia", 0);
                        EntradaLocalidad.ValueInt = Lfx.Workspace.Master.CurrentConfig.ReadGlobalSetting<int>("Sistema.Localidad", 0);

                        EntradaMonedaUnidadMonetariaMinima.ValueDecimal = Lbl.Sys.Config.Moneda.UnidadMonetariaMinima;
                        EntradaMonedaDecimalesCosto.TextKey = Lbl.Sys.Config.Moneda.DecimalesCosto.ToString();
                        EntradaMonedaDecimalesUnitarios.TextKey = Lbl.Sys.Config.Moneda.Decimales.ToString();
                        EntradaMonedaDecimalesFinal.TextKey = Lbl.Sys.Config.Moneda.DecimalesFinal.ToString();

                        EntradaSucursal.ValueInt = Lfx.Workspace.Master.CurrentConfig.Empresa.SucursalActual;

                        this.Logo = new Lbl.Sys.Blob(this.Connection, 1);
                        EntradaLogo.Elemento = Logo;
                        EntradaLogo.ActualizarControl();
                }


                private bool GuardarConfig()
                {
                        if (EntradaEmpresaEmail.Text.Length <= 5 || EntradaEmpresaEmail.Text.IndexOf('@') <= 0 || EntradaEmpresaEmail.Text.IndexOf('.') <= 0) {
                                Lui.Forms.MessageBox.Show("Por favor escriba una dirección de correo electrónico (e-mail) válida.", "Validación");
                                return true;
                        }


                        if (EntradaEmpresaNombre.Text.Length <= 5 || EntradaEmpresaNombre.Text == "Nombre de la empresa") {
                                Lui.Forms.MessageBox.Show("Por favor escriba el nombre de la empresa.", "Validación");
                                return true;
                        }


                        Lbl.Entidades.Pais NuevoPais = EntradaPais.Elemento as Lbl.Entidades.Pais;
                        if (NuevoPais == null || NuevoPais.Existe == false) {
                                Lui.Forms.MessageBox.Show("Por favor seleccione el país.", "Validación");
                                return true;
                        }

                        var Trans = this.Connection.BeginTransaction();

                        if (NuevoPais.Id != IdPaisOriginal) {
                                Lbl.Sys.Config.CambiarPais(NuevoPais);
                        }

                        int Sucursal = EntradaSucursal.ValueInt;

                        Lfx.Workspace.Master.CurrentConfig.WriteGlobalSetting("Sistema.Stock.CodigoPredet", EntradaArticulosCodigoPredet.TextKey, 0);
                        Lfx.Workspace.Master.CurrentConfig.WriteGlobalSetting("Sistema.Stock.Multideposito", EntradaStockMultideposito.TextKey, 0);
                        Lfx.Workspace.Master.CurrentConfig.WriteGlobalSetting("Sistema.Stock.Decimales", EntradaStockDecimales.TextKey, 0);
                        Lfx.Workspace.Master.CurrentConfig.WriteGlobalSetting("Sistema.Stock.DepositoPredet", EntradaStockDepositoPredet.Text, 0); ;
                        if (EntradaStockDepositoPredetSuc.ValueInt > 0)
                                Lfx.Workspace.Master.CurrentConfig.WriteGlobalSetting("Sistema.Stock.DepositoPredet", EntradaStockDepositoPredetSuc.Text, Sucursal);
                        else
                                Lfx.Workspace.Master.CurrentConfig.DeleteGlobalSetting("Sistema.Stock.DepositoPredet", Sucursal);

                        Lbl.Sys.Config.Empresa.Nombre = EntradaEmpresaNombre.Text;
                        Lbl.Sys.Config.Empresa.RazonSocial = EntradaEmpresaRazonSocial.Text;
                        if (EntradaEmpresaClaveTributaria.Text.Length > 0)
                                Lbl.Sys.Config.Empresa.ClaveTributaria = new Lbl.Personas.Claves.Cuit(EntradaEmpresaClaveTributaria.Text);
                        else
                                Lbl.Sys.Config.Empresa.ClaveTributaria = null;
                        Lbl.Sys.Config.Empresa.SituacionTributaria = EntradaEmpresaSituacion.ValueInt;
                        Lbl.Sys.Config.Empresa.Email = EntradaEmpresaEmail.Text;
                        Lbl.Sys.Config.Empresa.Id = EntradaEmpresaId.ValueInt;
                        Lbl.Sys.Config.Empresa.NumeroIngresosBrutos = EntradaIngresosBrutos.Text;
                        Lbl.Sys.Config.Empresa.InicioDeActividades = Lfx.Types.Parsing.ParseDate(EntradaInicioActividades.Text);

                        Lfx.Workspace.Master.CurrentConfig.WriteGlobalSetting("Sistema.Backup.Tipo", EntradaBackup.TextKey, Lfx.Environment.SystemInformation.MachineName);
                        if (EntradaModoPantalla.TextKey == "*")
                                Lfx.Workspace.Master.CurrentConfig.DeleteGlobalSetting("Sistema.Apariencia.ModoPantalla", Lfx.Environment.SystemInformation.MachineName);
                        else
                                Lfx.Workspace.Master.CurrentConfig.WriteGlobalSetting("Sistema.Apariencia.ModoPantalla", EntradaModoPantalla.TextKey, Lfx.Environment.SystemInformation.MachineName);
                        Lfx.Workspace.Master.CurrentConfig.WriteGlobalSetting("Sistema.Actualizaciones.Nivel", EntradaActualizaciones.TextKey);

                        if (this.Logo.ImagenCambio) {
                                if (this.Logo.Existe == false) {
                                        this.Logo.SetId(1);
                                }
                                this.Logo.Guardar();
                        }

                        //Guardo información sobre los PV
                        Lfx.Workspace.Master.CurrentConfig.WriteGlobalSetting("Sistema.Documentos.PV", EntradaPV.Text, Sucursal);
                        Lfx.Workspace.Master.CurrentConfig.WriteGlobalSetting("Sistema.Documentos.ABC.PV", EntradaPVABC.Text, Sucursal);
                        Lfx.Workspace.Master.CurrentConfig.WriteGlobalSetting("Sistema.Documentos.NC.PV", EntradaPVNC.Text, Sucursal);
                        Lfx.Workspace.Master.CurrentConfig.WriteGlobalSetting("Sistema.Documentos.ND.PV", EntradaPVND.Text, Sucursal);
                        Lfx.Workspace.Master.CurrentConfig.WriteGlobalSetting("Sistema.Documentos.R.PV", EntradaPVR.Text, Sucursal);
                        Lfx.Workspace.Master.CurrentConfig.WriteGlobalSetting("Sistema.Documentos.RC.PV", EntradaPVRC.Text, System.Environment.MachineName);

                        Lfx.Workspace.Master.CurrentConfig.WriteGlobalSetting("Sistema.Documentos.ClientePredet", EntradaClientePredet.Text);
                        Lfx.Workspace.Master.CurrentConfig.WriteGlobalSetting("Sistema.Documentos.FormaPagoPredet", EntradaFormaPagoPredet.Text);

                        Lfx.Workspace.Master.CurrentConfig.WriteGlobalSetting("Sistema.Documentos.CambiaPrecioItemFactura", EntradaCambiaPrecioComprob.Value ? 1 : 0);

                        Lfx.Workspace.Master.CurrentConfig.WriteGlobalSetting("Sistema.Cuentas.LimiteCreditoPredet", EntradaLimiteCredito.ValueDecimal);

                        Lfx.Workspace.Master.CurrentConfig.WriteGlobalSetting("Sistema.Provincia", EntradaProvincia.ValueInt);
                        Lfx.Workspace.Master.CurrentConfig.WriteGlobalSetting("Sistema.Localidad", EntradaLocalidad.ValueInt);

                        EntradaMonedaUnidadMonetariaMinima.ValueDecimal = Lbl.Sys.Config.Moneda.UnidadMonetariaMinima;

                        Lfx.Workspace.Master.CurrentConfig.WriteGlobalSetting("Sistema.Moneda.Decimales", EntradaMonedaDecimalesUnitarios.ValueInt);
                        Lfx.Workspace.Master.CurrentConfig.WriteGlobalSetting("Sistema.Moneda.DecimalesCosto", EntradaMonedaDecimalesCosto.ValueInt);
                        Lfx.Workspace.Master.CurrentConfig.WriteGlobalSetting("Sistema.Moneda.DecimalesFinal", EntradaMonedaDecimalesFinal.ValueInt);
                        Lbl.Sys.Config.Moneda.Decimales = EntradaMonedaDecimalesUnitarios.ValueInt;
                        Lbl.Sys.Config.Moneda.DecimalesCosto = EntradaMonedaDecimalesCosto.ValueInt;
                        Lbl.Sys.Config.Moneda.DecimalesFinal = EntradaMonedaDecimalesFinal.ValueInt;

                        Lfx.Workspace.Master.CurrentConfig.Empresa.SucursalActual = EntradaSucursal.ValueInt;


                        Lfx.Workspace.Master.CurrentConfig.WriteGlobalSetting("Sistema.Configurado", "1", 0);

                        if (this.PrimeraVez) {
                                // Hago cambios referentes al país donde está configurado el sistema

                                Lbl.Entidades.Pais Pais = EntradaPais.Elemento as Lbl.Entidades.Pais;
                                if (Pais != null) {
                                        Lbl.Sys.Config.CambiarPais(Pais);
                                }

                                // Cambio la sucursal 1 y el cliente consumidor final a la localidad proporcionada
                                Lbl.Entidades.Localidad Loc = EntradaLocalidad.Elemento as Lbl.Entidades.Localidad;
                                if (Loc != null) {
                                        Lbl.Entidades.Sucursal Suc1 = new Lbl.Entidades.Sucursal(this.Connection, 1);
                                        Suc1.Localidad = Loc;
                                        Suc1.Guardar();

                                        Lbl.Personas.Persona ConsFinal = new Lbl.Personas.Persona(this.Connection, 999);
                                        ConsFinal.Localidad = Loc;
                                        ConsFinal.Guardar();
                                }

                                Lbl.Sys.Config.Cargar();

                                this.PrimeraVez = false;
                        }

                        Trans.Commit();
                        Trans.Dispose();

                        return false;
                }


                private void BotonSiguiente_Click(object sender, System.EventArgs e)
                {
                        CurrentTab += 1;
                        if (CurrentTab > TabCount)
                                CurrentTab = 1;

                        FrmGeneral.Visible = CurrentTab == 1;
                        FrmArticulos.Visible = CurrentTab == 2;
                        FrmComprobantes.Visible = CurrentTab == 3;
                        FrmAvanzado.Visible = CurrentTab == 4;

                        LabelTab1.Left = CurrentTab == 1 ? 16 : 12;
                        LabelTab2.Left = CurrentTab == 2 ? 16 : 12;
                        LabelTab3.Left = CurrentTab == 3 ? 16 : 12;
                        LabelTab4.Left = CurrentTab == 4 ? 16 : 12;
                }

                private void EntradaProvincia_TextChanged(object sender, System.EventArgs e)
                {
                        if (EntradaProvincia.ValueInt != 0)
                                EntradaLocalidad.Filter = "id_provincia=" + EntradaProvincia.ValueInt.ToString();
                        else
                                EntradaLocalidad.Filter = "";
                }

                private void EntradaPais_TextChanged(object sender, System.EventArgs e)
                {
                        Lbl.Entidades.Pais Pais = EntradaPais.Elemento as Lbl.Entidades.Pais;
                        if (Pais != null) {
                                if (Pais.ClavePersonasJuridicas != null)
                                        EtiquetaClaveTributaria.Text = Pais.ClavePersonasJuridicas.ToString();
                                else
                                        EtiquetaClaveTributaria.Text = "Clave tributaria";
                                EntradaProvincia.Filter = "id_provincia IS NULL AND id_pais=" + Pais.Id.ToString();
                        } else {
                                EtiquetaClaveTributaria.Text = "Clave tributaria";
                                EntradaProvincia.Filter = "id_provincia IS NULL";
                        }
                }

                private void BotonCambiarPais_Click(object sender, System.EventArgs e)
                {
                        using (Lui.Forms.YesNoDialog Pregunta = new Lui.Forms.YesNoDialog("Al cambiar el país, Lázaro cambiará varios ajustes del sistema como la moneda, las tasas del IVA y los tipos de comprobante. ¿Está seguro de que quiere cambiar el país?", "Cambiar país")) {
                                Pregunta.DialogButtons = Lui.Forms.DialogButtons.YesNo;
                                if (Pregunta.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                                        EntradaPais.ReadOnly = false;
                                        BotonCambiarPais.Visible = false;
                                        EntradaPais.Focus();
                                }
                        }
                }
        }
}