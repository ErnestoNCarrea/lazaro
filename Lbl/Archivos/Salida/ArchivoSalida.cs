using System;
using System.Collections.Generic;
using Lbl.Archivos;

namespace Lbl.Archivos.Salida
{
        /// <summary>
        /// Describe un archivo de salida, o sea uno que el sistema genera.
        /// </summary>
        public abstract class ArchivoSalida : Lbl.Archivos.Archivo, Lbl.Archivos.Salida.IArchivoSalida
        {
                public System.Collections.Generic.List<Registro> Registros;

                public ArchivoSalida()
                        : base()
                {
                        this.Registros = new List<Registro>();
                }

                public virtual void Escribir(string nombreArchivo)
                {
                        using (System.IO.FileStream Archivo = new System.IO.FileStream(nombreArchivo, System.IO.FileMode.Create, System.IO.FileAccess.Write))
                        using (System.IO.StreamWriter Escritor = new System.IO.StreamWriter(Archivo, System.Text.Encoding.Default)) {
                                Escribir(Escritor);
                                Escritor.Close();
                                Archivo.Close();
                        }
                }

                /// <summary>
                /// Carga datos desde un StreamReader.
                /// </summary>
                public virtual void Escribir(System.IO.StreamWriter stream)
                {
                        string Renglon = this.GenerarEncabezado(this.LineCounter++);
                        if (string.IsNullOrEmpty(Renglon) == false) {
                                stream.WriteLine(Renglon);
                        }

                        foreach (Registro Reg in this.Registros) {
                                this.LineCounter++;
                                Renglon = Reg.ToString();
                                if (string.IsNullOrEmpty(Renglon) == false) {
                                        stream.WriteLine(Renglon);
                                }
                                if (this.Progreso != null) {
                                        this.Progreso.Advance(1);
                                }
                        }

                        Renglon = this.GenerarPie(this.LineCounter++);
                        if (string.IsNullOrEmpty(Renglon) == false) {
                                stream.WriteLine(Renglon);
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
