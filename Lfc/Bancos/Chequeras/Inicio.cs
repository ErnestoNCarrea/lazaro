using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

namespace Lfc.Bancos.Chequeras
{
	public partial class Inicio: Lfc.FormularioListado
	{
		private enum Estados
		{
                        Todos = -1,
			FueraDeUso = 0,
			Activas = 1
		}
		
		private Estados m_Estado = Estados.Todos;
                private int m_Banco = 0, m_Caja = 0;

                public Inicio()
                {
                        this.Definicion = new Lazaro.Pres.Listings.Listing()
                        {
                                ElementoTipo = typeof(Lbl.Bancos.Chequera),

                                TableName = "chequeras",
                                KeyColumn = new Lazaro.Pres.Field("chequeras.id_chequera", "Cód.", Lfx.Data.InputFieldTypes.Serial, 0),
                                Columns = new Lazaro.Pres.FieldCollection()
			        {
				        new Lazaro.Pres.Field("bancos.nombre", "Banco", 240, new Lazaro.Orm.Data.Relation("chequeras.id_banco", "bancos", "id_banco")),
                                        new Lazaro.Pres.Field("chequeras.cheques_emitidos", "Emitidos", Lfx.Data.InputFieldTypes.Integer, 90),
				        new Lazaro.Pres.Field("chequeras.desde", "Desde", Lfx.Data.InputFieldTypes.Integer, 120),
				        new Lazaro.Pres.Field("chequeras.hasta", "Hasta", Lfx.Data.InputFieldTypes.Integer, 120),
				        new Lazaro.Pres.Field("cajas.nombre", "Caja", 240, new Lazaro.Orm.Data.Relation("chequeras.id_caja", "cajas", "id_caja")),
				        new Lazaro.Pres.Field("chequeras.titular", "Titular", Lfx.Data.InputFieldTypes.Text, 240),
				        new Lazaro.Pres.Field("chequeras.estado", "Estado", Lfx.Data.InputFieldTypes.Text, 80),
			        }
                        };
                }

                public override Lfx.Types.OperationResult OnFilter()
                {
                        Lfx.Types.OperationResult filtrarReturn = base.OnFilter();
                        if (filtrarReturn.Success == true) {
                                using (Bancos.Chequeras.Filtros FormFiltros = new Bancos.Chequeras.Filtros()) {
                                        FormFiltros.Connection = this.Connection;
                                        FormFiltros.EntradaEstado.TextKey = ((int)m_Estado).ToString();
                                        FormFiltros.EntradaBanco.ValueInt = m_Banco;
                                        FormFiltros.EntradaCaja.ValueInt = m_Caja;

                                        FormFiltros.ShowDialog();
                                        if (FormFiltros.DialogResult == DialogResult.OK) {
                                                m_Estado = (Estados)Lfx.Types.Parsing.ParseInt(FormFiltros.EntradaEstado.TextKey);
                                                m_Banco = FormFiltros.EntradaBanco.ValueInt;
                                                m_Caja = FormFiltros.EntradaCaja.ValueInt;
                                                RefreshList();
                                                filtrarReturn.Success = true;
                                        } else {
                                                filtrarReturn.Success = false;
                                        }
                                }
                        }
                        return filtrarReturn;
                }

                protected override void OnBeginRefreshList()
                {
                        this.CustomFilters = new qGen.Where();

                        if (m_Estado != Estados.Todos)
                                this.CustomFilters.AddWithValue("chequeras.estado", (int)m_Estado);

                        if (m_Banco > 0)
                                this.CustomFilters.AddWithValue("chequeras.id_banco", m_Banco);

                        if (m_Caja > 0)
                                this.CustomFilters.AddWithValue("chequeras.id_caja", m_Caja);

                        base.OnBeginRefreshList();
                }

                protected override void OnItemAdded(ListViewItem item, Lfx.Data.Row row)
		{
			switch(row.Fields["chequeras.estado"].ValueInt)
			{
				case 0:
                                        item.SubItems["chequeras.estado"].Text = "Fuera de uso";
                                        break;
				case 1:
                                        item.SubItems["chequeras.estado"].Text = "Activa";
					break;
				default:
                                        item.SubItems["chequeras.estado"].Text = "???";
					break;
			}

                        item.SubItems["chequeras.desde"].Text = row.Fields["chequeras.desde"].ValueInt.ToString("00000000");
                        item.SubItems["chequeras.hasta"].Text = row.Fields["chequeras.hasta"].ValueInt.ToString("00000000");
                        /* item.SubItems["chequeras.id_banco"].Text = this.Connection.Tables["bancos"].FastRows[System.Convert.ToInt32(row["chequeras.id_banco"])].Fields["nombre"].ToString();
                        int IdCaja = row.Fields["id_caja"].ValueInt;
                        if (IdCaja > 0)
                                item.SubItems["chequeras.id_caja"].Text = this.Connection.Tables["cajas"].FastRows[IdCaja].Fields["nombre"].ToString();
                         * */
		}
	}

}
