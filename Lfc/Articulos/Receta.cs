using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Lfc.Articulos
{
        public partial class Receta : Lui.Forms.DialogForm
        {
                private Lbl.Articulos.Articulo m_Articulo;
                private bool m_ReadOnly = true;

                public Receta()
                {
                        InitializeComponent();
                }

                public bool ReadOnly
                {
                        get
                        {
                                return m_ReadOnly;
                        }
                        set
                        {
                                m_ReadOnly = value;
                                //ProductArray.Enabled = !this.ReadOnly;
                                MatrizArticulos.TemporaryReadOnly = m_ReadOnly;
                        }
                }

                public Lbl.Articulos.Articulo Articulo
                {
                        get
                        {
                                return m_Articulo;
                        }
                        set
                        {
                                m_Articulo = value;

                                if (m_Articulo != null) {
                                        MatrizArticulos.Count = Articulo.Receta.Count;

                                        for (int i = 0; i < Articulo.Receta.Count; i++) {
                                                if (Articulo.Receta[i].Articulo == null)
                                                        MatrizArticulos.ChildControls[i].Text = MatrizArticulos.FreeTextCode;
                                                else
                                                        MatrizArticulos.ChildControls[i].Elemento = Articulo.Receta[i].Articulo;

                                                MatrizArticulos.ChildControls[i].Cantidad = Articulo.Receta[i].Cantidad;
                                        }
                                }
                        }
                }

                public override Lfx.Types.OperationResult Ok()
                {
                        this.Articulo.Receta.Clear();

                        for (int i = 0; i <= MatrizArticulos.Count - 1; i++) {
                                if (MatrizArticulos.ChildControls[i].Text == MatrizArticulos.FreeTextCode || MatrizArticulos.ChildControls[i].Elemento != null) {
                                        Lbl.Articulos.ItemReceta Itm = new Lbl.Articulos.ItemReceta(MatrizArticulos.ChildControls[i].Articulo, MatrizArticulos.ChildControls[i].Cantidad);
                                        this.Articulo.Receta.Add(Itm);
                                }
                        }

                        return base.Ok();
                }
        }
}
