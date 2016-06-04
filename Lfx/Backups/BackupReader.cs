using System;
using System.Collections.Generic;

namespace Lfx.Backups
{
        public class BackupReader : IDisposable
        {
                private System.IO.Stream inputStream;

                public BackupReader(string path)
                {
                        System.IO.FileStream fs = new System.IO.FileStream(path, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                        fs.ReadByte();
                        inputStream = fs;
                        inputStream.Seek(0, System.IO.SeekOrigin.Begin);
                }


                public void Dispose()
                {
                        inputStream.Dispose();
                }


                public string ReadString(int length)
                {
                        byte[] Res = new byte[length];
                        inputStream.Read(Res, 0, length);
                        return System.Text.Encoding.UTF8.GetString(Res);
                }

                public string ReadPrefixedString4()
                {
                        int Len = int.Parse(this.ReadString(4));
                        return this.ReadString(Len);
                }

                public object ReadField()
                {
                        string Type = this.ReadString(1);
                        string StrLen = this.ReadString(8);
                        int Len = int.Parse(StrLen);
                        switch (Type) {
                                case "I":
                                        return int.Parse(this.ReadString(Len));
                                case "N":
                                        return Lfx.Types.Parsing.ParseDecimal(this.ReadString(Len));
                                case "D":
                                        string FldVal = this.ReadString(Len);
                                        return DateTime.ParseExact(FldVal, Lfx.Types.Formatting.DateTime.SqlDateTimeFormat, null);
                                case "B":
                                        byte[] Res = new byte[Len];
                                        inputStream.Read(Res, 0, Len);
                                        return Res;
                                case "U":
                                        return null;
                                default:
                                        return this.ReadString(Len);

                        }
                }

                public void Close()
                {
                        inputStream.Close();
                }

                public long Length
                {
                        get
                        {
                                return inputStream.Length;
                        }
                }

                public long Position
                {
                        get
                        {
                                return inputStream.Position;
                        }
                }
        }
}
