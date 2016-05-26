using System.Collections.Generic;
using System.Text;

namespace Lbl.Comprobantes
{
        public class ColeccionDetalleArticulos : Lbl.ColeccionGenerica<DetalleArticulo>
        {
                private Lbl.ElementoDeDatos m_ElementoPadre = null;

                public ColeccionDetalleArticulos(Lfx.Data.Connection dataBase)
                        : base(dataBase) { }

                public ColeccionDetalleArticulos(Lbl.ElementoDeDatos elementoPadre)
                        : base(elementoPadre.Connection)
                {
                        this.ElementoPadre = elementoPadre;
                }


                public Lbl.ElementoDeDatos ElementoPadre
                {
                        get
                        {
                                return m_ElementoPadre;
                        }
                        set
                        {
                                m_ElementoPadre = value;
                                foreach (Lbl.Comprobantes.DetalleArticulo det in this)
                                        det.ElementoPadre = m_ElementoPadre;
                        }
                }

                public new void Add(Lbl.Comprobantes.DetalleArticulo detalle)
                {
                        detalle.ElementoPadre = this.ElementoPadre;
                        base.Add(detalle);
                }
                

                public new void AddRange(IEnumerable<Lbl.Comprobantes.DetalleArticulo> detalles)
                {
                        foreach (Lbl.Comprobantes.DetalleArticulo det in detalles)
                                det.ElementoPadre = this.ElementoPadre;
                        base.AddRange(detalles);
                }
                

                public void AddWithValue(Lbl.Articulos.Articulo articulo, decimal cantidad, decimal unitario, string obs)
                {
                        DetalleArticulo Det = new DetalleArticulo(this.ElementoPadre);
                        Det.Articulo = articulo;
                        Det.Cantidad = cantidad;
                        Det.Unitario = unitario;
                        Det.Obs = obs;
                }

                public ColeccionDetalleArticulos Clone(Lbl.ElementoDeDatos elementoPadre)
                {
                        ColeccionDetalleArticulos Res = new ColeccionDetalleArticulos(elementoPadre);
                        foreach (DetalleArticulo Det in this) {
                                Res.Add(Det.Clone());
                        }
                        return Res;
                }

                new public ColeccionDetalleArticulos Clone()
                {
                        return this.Clone(this.ElementoPadre);
                }


                /// <summary>
                /// Unifica la lista de articulos. Cuando un artículo aparece 2 o más veces, que una sola instancia
                /// con la sumatoria de las cantidades (Si la lista consta de "2 manzanas, 3 naranjas y 1 manzana",
                /// esta función devuelve "3 manzanas y 3 naranjas").
                /// </summary>
                public ColeccionDetalleArticulos Unificar()
                {
                        ColeccionDetalleArticulos Res = new ColeccionDetalleArticulos(this.ElementoPadre);
                        foreach (DetalleArticulo Det in this) {
                                bool Encontre = false;
                                foreach (DetalleArticulo Det2 in Res) {
                                        if (Det2.IdArticulo == Det.IdArticulo
                                                && Det2.Unitario == Det.Unitario
                                                && Det2.Obs == Det.Obs
                                                && Det2.Nombre == Det.Nombre) {
                                                //Si ya existe, sumo la cantidad
                                                Encontre = true;
                                                Det2.Cantidad += Det.Cantidad;
                                        }
                                }

                                //Si no existe, lo agrego
                                if (Encontre == false)
                                        Res.Add(Det);
                        }
                        return Res;
                }


                public decimal ImporteTotal
                {
                        get
                        {
                                decimal Res = 0;
                                foreach (DetalleArticulo Det in this) {
                                        Res += Det.ImporteAImprimir;
                                }
                                return Res;
                        }
                }


                /// <summary>
                /// Hace una lista de movimientos necesarios para convertir "original" en "this".
                /// </summary>
                public ColeccionDetalleArticulos Diferencia(ColeccionDetalleArticulos original)
                {
                        ColeccionDetalleArticulos Desde;
                        if (original == null)
                                Desde = new ColeccionDetalleArticulos(this.ElementoPadre);
                        else
                                Desde = original.Unificar();
                        ColeccionDetalleArticulos Hacia = this.Unificar();

                        ColeccionDetalleArticulos Res = new ColeccionDetalleArticulos(this.ElementoPadre);

                        foreach (DetalleArticulo DetHacia in Hacia) {
                                bool Encontre = false;
                                if (DetHacia.IdArticulo > 0) {
                                        foreach (DetalleArticulo DetDesde in Desde) {
                                                if (DetDesde.IdArticulo == DetHacia.IdArticulo) {
                                                        //Si existe lo modifico
                                                        DetalleArticulo Nuevo = DetDesde.Clone();
                                                        Nuevo.Cantidad = DetHacia.Cantidad - DetDesde.Cantidad;
                                                        if (Nuevo.Cantidad != 0)
                                                                Res.Add(Nuevo);
                                                        Encontre = true;
                                                        break;
                                                }
                                        }
                                }


                                //Si no existe (o no tiene código de artículo) lo agrego
                                if (Encontre == false)
                                        Res.Add(DetHacia.Clone());
                        }

                        //Ahora quito los que ya no están
                        foreach (DetalleArticulo DetDesde in Desde) {
                                bool Encontre = false;
                                foreach (DetalleArticulo DetHacia in Hacia) {
                                        if (DetHacia.IdArticulo == DetDesde.IdArticulo) {
                                                Encontre = true;
                                                break;
                                        }
                                }
                                if (Encontre == false) {
                                        //La cantidad negativa para quitar
                                        DetalleArticulo Nuevo = DetDesde.Clone();
                                        Nuevo.Cantidad = -DetDesde.Cantidad;
                                        Res.Add(Nuevo);
                                }                                        
                        }

                        return Res;
                }

                public Lbl.Articulos.ColeccionDatosSeguimiento DatosSeguimiento
                {
                        get
                        {
                                Lbl.Articulos.ColeccionDatosSeguimiento Res = new Lbl.Articulos.ColeccionDatosSeguimiento();
                                foreach (Lbl.Comprobantes.DetalleArticulo Art in this) {
                                        if (Art.DatosSeguimiento != null)
                                                Res.AddRange(Art.DatosSeguimiento);
                                }
                                return Res;
                        }
                }

                public override string ToString()
                {
                        string Res = null;
                        foreach (DetalleArticulo Det in this) {
                                if (Res == null)
                                        Res = Det.ToString();
                                else
                                        Res += System.Environment.NewLine + Det.ToString();
                        }
                        return Res;
                }
        }
}
