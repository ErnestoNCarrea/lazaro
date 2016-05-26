using System;
using System.Collections.Generic;

namespace Lcc.Entrada
{
        [Serializable]
        public class MatrizTextos : MatrizControlesEntrada<CampoTexto>
        {
                public override string Text
                {
                        get
                        {
                                List<string> Lineas = new List<string>();
                                foreach (CampoTexto Campo in this.Controles) {
                                        if (Campo.IsEmpty == false)
                                                Lineas.Add(Campo.Text);
                                }

                                return string.Join(System.Environment.NewLine, Lineas.ToArray());
                        }
                        set
                        {
                                if (value == null) {
                                        this.Count = 0;
                                        this.AutoAgregarOQuitar(false);
                                } else {
                                        string[] Textos = value.Split(new char[] { Lfx.Types.ControlChars.Cr, Lfx.Types.ControlChars.Lf }, StringSplitOptions.RemoveEmptyEntries);
                                        this.Count = Textos.Length;
                                        int i = 0;
                                        foreach (string Texto in Textos) {
                                                this.Controles[i++].Text = Texto;
                                        }
                                }
                        }
                }
        }
}
