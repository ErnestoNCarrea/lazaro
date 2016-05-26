using System;


namespace Lui.Forms
{
        public class Threads
        {
                public static void Sleep(int millisecondsTimeout, bool doingEvents)
                {
                        if (doingEvents) {
                                System.DateTime Meta = System.DateTime.Now.AddMilliseconds(millisecondsTimeout);

                                while (System.DateTime.Now < Meta) {
                                        System.Windows.Forms.Application.DoEvents();
                                        //Hago un thread.sleep para no atorar la CPU
                                        System.Threading.Thread.Sleep(10);
                                }
                        } else {
                                System.Threading.Thread.Sleep(millisecondsTimeout);
                        }
                }
        }
}
