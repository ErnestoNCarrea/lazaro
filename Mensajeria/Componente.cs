using Lfx;
using Lfx.Components;
using Lfx.Types;
using System;

namespace Lazaro.Mensajeria
{

        public class Component : IComponent
        {
                public static Chat.Inicio FormChat = null;
                public Workspace Workspace { get; set; }

                public RegisteredTypeCollection GetRegisteredTypes()
                {
                        return null;
                }

                public OperationResult Register()
                {
                        return new SuccessOperationResult();
                }

                public OperationResult Run()
                {
                        FormChat = new Chat.Inicio();
                        // Accedo a la propiedad handle para forzar la creación del mismo
                        IntPtr Dummy = FormChat.Handle;
                        return new Lfx.Types.SuccessOperationResult();
                }

                public OperationResult Try()
                {
                        if (Lbl.Sys.Config.Empresa.ClaveTributaria != null && Lbl.Sys.Config.Empresa.ClaveTributaria.Valor == "30-70917198-0")
                                return new Lfx.Types.SuccessOperationResult();
                        else
                                return new Lfx.Types.CancelOperationResult();
                }

                public object Do(string actionName, object[] argv)
                {
                        switch(actionName) {
                                case "Show":
                                        FormChat.Show();
                                        return new Lfx.Types.SuccessOperationResult();
                                case "Notify":
                                        // Suscribo a esto via Runtime.Ipc (en Lfx)

                                        /* Lbl.Notificaciones.INotificacion Notif = this.Arguments[0] as Lbl.Notificaciones.INotificacion;
                                        if (Notif != null) {
                                                if (FormChat != null)
                                                        FormChat.MensajeRecibido(Notif);
                                        } */

                                        return new Lfx.Types.SuccessOperationResult();
                                default:
                                        return new FailureOperationResult("No existe la función " + actionName);
                        }
                        
                }
        }
        
}