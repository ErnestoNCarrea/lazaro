using System;
using System.Collections.Generic;
using System.Text;

namespace Lcc.Entrada
{
        [Serializable]
        public class MatrizTelefonos : MatrizControlesEntrada<Telefono>
        {
                public override string Text
                {
                        get
                        {
                                List<string> Tels = new List<string>();
                                foreach (Telefono TelCtrl in this.Controles) {
                                        if (TelCtrl.IsEmpty == false)
                                                Tels.Add("\"" + TelCtrl.Text + "\"");
                                }

                                return string.Join("; ", Tels.ToArray());
                        }
                        set
                        {
                                if (value == null) {
                                        this.Count = 0;
                                        this.AutoAgregarOQuitar(false);
                                } else {
                                        IList<string> Tels = Lfx.Types.Strings.SplitDelimitedString(value, ";", "\"");
                                        this.Count = Tels.Count;
                                        int i = 0;
                                        foreach (string Tel in Tels) {
                                                if (Tel.Length > 0)
                                                        this.Controles[i++].Text = Tel.Trim(new char[] { ' ', '"' });
                                        }
                                }
                        }
                }

                private void InitializeComponent()
                {
                        this.SuspendLayout();
                        // 
                        // MatrizTelefonos
                        // 
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
                        this.Name = "MatrizTelefonos";
                        this.ResumeLayout(false);

                }
        }
}
