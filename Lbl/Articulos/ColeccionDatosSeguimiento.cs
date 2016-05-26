using System;
using System.Collections.Generic;

namespace Lbl.Articulos
{
        public class ColeccionDatosSeguimiento : List<DatosSeguimiento>
        {
                public ColeccionDatosSeguimiento()
                {
                }

                public ColeccionDatosSeguimiento(string rep)
                {
                        this.FromString(rep);
                }


                public DatosSeguimiento this[string variacion]
                {
                        get
                        {
                                foreach (DatosSeguimiento Dat in this) {
                                        if (Dat.Variacion == variacion)
                                                return Dat;
                                }

                                return null;
                        }
                }


                public void AddWithValue(string variacion, decimal cantidad)
                {
                        this.Add(new DatosSeguimiento(variacion, cantidad));
                }


                public decimal CantidadTotal
                {
                        get
                        {
                                decimal Res = 0;

                                foreach (DatosSeguimiento Dat in this) {
                                        Res += Dat.Cantidad;
                                }

                                return Res;
                        }
                }

                public bool ContainsKey(string variacion)
                {
                        foreach (DatosSeguimiento Dat in this) {
                                if (Dat.Variacion == variacion)
                                        return true;
                        }

                        return false;
                }


                public bool CantidadesSiempreUno()
                {
                        foreach (DatosSeguimiento Dat in this) {
                                if (Dat.Cantidad != 1)
                                        return false;
                        }

                        return true;
                }


                public override string ToString()
                {
                        System.Text.StringBuilder Res = new System.Text.StringBuilder();
                        bool MuestroCantidades = !this.CantidadesSiempreUno();
                        foreach (DatosSeguimiento Dat in this) {
                                if (MuestroCantidades) {
                                        if(Dat.Cantidad != (int)(Dat.Cantidad))
                                                // Cantidad con decimales
                                                Res.Append(Dat.Variacion + ": " + Dat.Cantidad.ToString() + "; ");
                                        else
                                                // Cantidad entera
                                                Res.Append(Dat.Variacion + ": " + ((int)(Dat.Cantidad)).ToString() + "; ");
                                } else {
                                        Res.Append(Dat.Variacion + "; ");
                                }
                        }
                        return Res.ToString().Trim(new char[] { ';', ' ' });
                }


                public void FromString(string rep)
                {
                        this.Clear();
                        if (rep != null) {
                                string[] Lines = rep.Split(new char[] { ';', ',', Lfx.Types.ControlChars.Cr, Lfx.Types.ControlChars.Lf }, StringSplitOptions.RemoveEmptyEntries);
                                foreach (string Line in Lines) {
                                        if (Line.Length > 0) {
                                                string[] Parts = Line.Split(new char[] { ':' }, 2, StringSplitOptions.RemoveEmptyEntries);
                                                if (Parts.Length > 0 && Parts[0].Trim().Length > 0) {
                                                        // Si hay al menos 1 parte, y no está en blanco
                                                        if (Parts.Length == 1) {
                                                                // Una parte, cantidad = 1
                                                                this.AddWithValue(Parts[0].Trim(), 1);
                                                        } else if (Parts.Length > 1) {
                                                                // Dos partes, la segunda es la cantidad
                                                                this.AddWithValue(Parts[0].Trim(), Lfx.Types.Parsing.ParseDecimal(Parts[1]));
                                                        }
                                                }
                                        }
                                }
                        }
                }
        }
}
