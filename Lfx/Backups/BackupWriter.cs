using System;
using System.Collections.Generic;

namespace Lfx.Backups
{
        public class BackupWriter : IDisposable
        {
                public System.IO.Stream outputStream;

                public BackupWriter(string path)
                {
                        outputStream = new System.IO.FileStream(path, System.IO.FileMode.Create, System.IO.FileAccess.Write);
                }


                public void Dispose()
                {
                        outputStream.Dispose();
                }


                public void Close()
                {
                        outputStream.Close();
                }

                public void Write(string text)
                {
                        this.Write(System.Text.Encoding.UTF8.GetBytes(text));
                }

                public void Write(byte[] bytes)
                {
                        outputStream.Write(bytes, 0, bytes.Length);
                }
        }
}
