using System.Collections.Generic;
using System.Windows.Forms;

namespace Lfc
{
        public partial class FormularioFiltros : Lui.Forms.DialogForm
        {
                public FormularioFiltros()
                {
                        InitializeComponent();
                }


                public void FromFilters(Lazaro.Pres.Filters.FilterCollection filtros)
                {
                        this.ControlFiltros.FromFilters(filtros);
                }

                
                public override Lfx.Types.OperationResult Ok()
                {
                        this.ControlFiltros.ActualizarFiltros();
                        
                        return base.Ok();
                }

                private void ControlFiltros_StyleChanged(object sender, System.EventArgs e)
                {
                        int NewHeight = ControlFiltros.Height + ControlFiltros.Top + PanelFiltros.Top + LowerPanel.Height + (this.Height - this.ClientSize.Height);
                        if (this.Height < NewHeight)
                                this.Height = NewHeight;
                }
        }
}