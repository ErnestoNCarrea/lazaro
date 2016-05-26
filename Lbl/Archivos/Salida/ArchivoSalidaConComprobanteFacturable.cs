using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl.Archivos.Salida
{
        /// <summary>
        /// Describe un archivo de salida, o sea uno que el sistema genera.
        /// </summary>
        public abstract class ArchivoSalidaConComprobantesFacturables : Lbl.Archivos.ArchivoConComprobantesFacturables, Lbl.Archivos.Salida.IArchivoSalida
        {
                public bool CrLfFinal = true;

                public ArchivoSalidaConComprobantesFacturables()
                        : base()
                { }

                public ArchivoSalidaConComprobantesFacturables(Lfx.Types.OperationProgress progreso)
                        : base(progreso) { }

                public abstract List<string> FormatearRegistro(int lineNumber, Lbl.Comprobantes.ComprobanteFacturable Comp);

                public virtual void Escribir(string nombreArchivo)
                {
                        using (System.IO.FileStream Archivo = new System.IO.FileStream(nombreArchivo, System.IO.FileMode.Create, System.IO.FileAccess.Write))
                        using (System.IO.StreamWriter Escritor = new System.IO.StreamWriter(Archivo, System.Text.Encoding.Default)) {
                                this.Escribir(Escritor);
                                Escritor.Close();
                                Archivo.Close();
                        }
                }

                /// <summary>
                /// Carga datos desde un StreamReader.
                /// </summary>
                public virtual void Escribir(System.IO.StreamWriter stream)
                {
                        this.LineCounter = 0;
                        this.EscribirEncabezado(stream);
                        
                        foreach (Lbl.Comprobantes.ComprobanteFacturable Com in this.Comprobantes) {
                                this.EscribirComprobante(stream, Com);
                                if(this.Progreso != null) {
                                        this.Progreso.Advance(1);
                                }
                        }

                        this.EscribirPie(stream);
                }

                public virtual void EscribirComprobante(System.IO.StreamWriter stream, Lbl.Comprobantes.ComprobanteFacturable Com)
                {
                        List<string> Renglones = this.FormatearRegistro(this.LineCounter++, Com);
                        if (Renglones != null) {
                                foreach (string Renglon in Renglones) {
                                        if (string.IsNullOrEmpty(Renglon) == false) {
                                                stream.WriteLine(Renglon);
                                        }
                                }
                        }
                }

                protected virtual void EscribirEncabezado(System.IO.StreamWriter stream)
                {
                        string Renglon = this.GenerarEncabezado(this.LineCounter++);
                        if (string.IsNullOrEmpty(Renglon) == false) {
                                stream.WriteLine(Renglon);
                        }
                        this.LineCounter++;
                }

                protected virtual void EscribirPie(System.IO.StreamWriter stream)
                {
                        string Renglon = this.GenerarPie(this.LineCounter++);
                        if (string.IsNullOrEmpty(Renglon) == false) {
                                if (this.CrLfFinal) {
                                        stream.WriteLine(Renglon);
                                } else {
                                        stream.Write(Renglon);
                                }
                        }
                }


                /// <summary>
                /// La implementación predeterminada no genera encabezado.
                /// </summary>
                public virtual string GenerarEncabezado(int lineNumber)
                {
                        return null;
                }

                /// <summary>
                /// La implementación predeterminada no genera pie.
                /// </summary>
                public virtual string GenerarPie(int lineNumber)
                {
                        return null;
                }
        }
}
