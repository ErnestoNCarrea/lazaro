using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Lbl
{
        public interface IElementoDeDatos : IEquatable<ElementoDeDatos>
        {
                Lfx.Data.Connection Connection { get; set;  }
                int Id { get; }
                string TablaDatos { get; }
                string TablaImagenes { get; }
                string CampoId { get; }
                string CampoNombre { get; }

                Lfx.Data.Row Registro { get; }
                T GetFieldValue<T>(string fieldName);
                void SetFieldValue(string fieldName, object newVal);

                bool Existe { get; }
                bool Modificado { get; }

                ColeccionGenerica<Etiqueta> Etiquetas { get; set; }

                void Crear();
                Lfx.Types.OperationResult Cargar();
                void GuardarEtiquetas();
                void AgregarComentario(string texto);
                Lfx.Types.OperationResult Guardar();
        }
}
