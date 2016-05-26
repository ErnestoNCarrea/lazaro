using System;
using System.Collections.Generic;

namespace Lbl.Notificaciones
{
        public class ColeccionUsuarioConectado : Dictionary<int, UsuarioConectado>
        {
                public void Add(UsuarioConectado usuario)
                {
                        this.Add(usuario.Id, usuario);
                }

                /* public bool ContainsKey(int key)
                {
                        foreach (UsuarioConectado Usu in this) {
                                if (Usu.Id == key)
                                        return true;
                        }

                        return false;
                } */
        }
}
