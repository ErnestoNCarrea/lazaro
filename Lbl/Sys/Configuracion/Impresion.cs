using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl.Sys.Configuracion
{
        public class Impresion : SeccionConfiguracion
        {
                private ColeccionGenerica<Lbl.Impresion.Impresora> m_Impresoras = null;

                public Impresion()
                {
                }

                public ColeccionGenerica<Lbl.Impresion.Impresora> Impresoras
                {
                        get
                        {
                                if (m_Impresoras == null) {
                                        System.Data.DataTable TablaImpresoras = this.Connection.Select("SELECT * FROM impresoras");
                                        m_Impresoras = new Lbl.ColeccionGenerica<Lbl.Impresion.Impresora>(this.Connection, TablaImpresoras);
                                }
                                return m_Impresoras;
                        }
                }
        }
}
