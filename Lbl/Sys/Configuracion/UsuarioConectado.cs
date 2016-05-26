using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl.Sys.Configuracion
{
        public class UsuarioConectado : SeccionConfiguracion
        {
                public Personas.Usuario Usuario;
                private Personas.Persona m_Persona;

                public UsuarioConectado(Lbl.Personas.Usuario usuario)
                {
                        this.Usuario = usuario;
                }

                public int Id
                {
                        get
                        {
                                if (Usuario == null)
                                        return 0;
                                else
                                        return Usuario.Id;
                        }
                }

                public string Nombre
                {
                        get
                        {
                                if (this.Usuario == null)
                                        return "";
                                else
                                        return this.Usuario.Nombre;
                        }
                }

                public Lbl.Personas.Persona Persona
                {
                        get
                        {
                                if (m_Persona == null && this.Id > 0)
                                        m_Persona = new Personas.Persona(this.DataBase, this.Id);
                                
                                return m_Persona;
                        }
                }

                public bool TieneAccesoGlobal()
                {
                        if (this.Usuario == null)
                                return true;    // FIXME: tengo que decir que si por los módulos que no se loguean
                        else
                                return this.Usuario.Pemisos.TieneAccesoGlobal();
                }

                public bool TienePermiso(string nombre, Sys.Permisos.Operaciones operacion)
                {
                        if (this.Usuario == null)
                                return true;    // FIXME: tengo que decir que si por los módulos que no se loguean
                        else
                                return this.Usuario.Pemisos.TienePermiso(nombre, operacion);
                }

                public bool TienePermiso(IElementoDeDatos elemento, Sys.Permisos.Operaciones operacion)
                {
                        if (this.Usuario == null)
                                return true;    // FIXME: tengo que decir que si por los módulos que no se loguean
                        else
                                return this.Usuario.Pemisos.TienePermiso(elemento, operacion);
                }

                public bool TienePermiso(Type tipo, Sys.Permisos.Operaciones operacion)
                {
                        if (this.Usuario == null)
                                return true;    // FIXME: tengo que decir que si por los módulos que no se loguean
                        else
                                return this.Usuario.Pemisos.TienePermiso(tipo, operacion);
                }
        }
}
