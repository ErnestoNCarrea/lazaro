using System;

namespace Lazaro.Mensajeria
{

        /// <summary>
        /// La función Try se usa para decidir si cargar el componente o no.
        /// </summary>
        public class Try : Lfx.Components.TryFunction
        {
                public override object Run()
                {
                        Notify.FormChat = new Chat.Inicio();
                        // Accedo a la propiedad handle para forzar la creación del mismo
                        IntPtr Dummy = Notify.FormChat.Handle;
                        return new Lfx.Types.SuccessOperationResult();
                }
        }


        /// <summary>
        /// La función Notify se usa para recibir notificaciones locales o remotas.
        /// </summary>
        public class Notify : Lfx.Components.Function
        {
                public static Chat.Inicio FormChat = null;

                public override object Run()
                {
                        // Suscribo a esto via Runtime.Ipc (en Lfx)

                        /* Lbl.Notificaciones.INotificacion Notif = this.Arguments[0] as Lbl.Notificaciones.INotificacion;
                        if (Notif != null) {
                                if (FormChat != null)
                                        FormChat.MensajeRecibido(Notif);
                        } */

                        return new Lfx.Types.SuccessOperationResult();
                }
        }


        /// <summary>
        /// La función Notify se usa para recibir notificaciones locales o remotas.
        /// </summary>
        public class Show : Lfx.Components.Function
        {
                public override object Run()
                {
                        Notify.FormChat.Show();
                        return new Lfx.Types.SuccessOperationResult();
                }
        }
}