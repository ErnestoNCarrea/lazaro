using System;
using System.Collections.Generic;
using System.Text;

namespace Lfx.FileFormats.Compression
{
        public enum ArchiveTypes
        {
                Unknown = 0,
                Zip,
                SevenZip,
                BZip2
        }

	public class Archive
	{
                private static System.Reflection.Assembly m_SharpZipLib = null;
		//public string ArchiveFileName = null;
                public System.IO.Stream InputStream = null;
		public ArchiveTypes ArchiveType = ArchiveTypes.Unknown;

                public Archive(System.IO.Stream inputStream, ArchiveTypes archiveType)
		{
                        this.InputStream = inputStream;
			this.ArchiveType = archiveType;
		}

                public Archive(string archiveFileName)
		{
                        this.InputStream = System.IO.File.OpenRead(archiveFileName);
			switch(System.IO.Path.GetExtension(archiveFileName).ToUpperInvariant())
			{
                                case ".BZ2":
                                case ".BZIP2":
                                        this.ArchiveType = ArchiveTypes.BZip2;
                                        break;
				case ".7Z":
					this.ArchiveType = ArchiveTypes.SevenZip;
					break;
				case ".ZIP":
					this.ArchiveType = ArchiveTypes.Zip;
					break;
			}
		}

                private System.Reflection.Assembly SharpZipLib
                {
                        get
                        {
                                if (m_SharpZipLib == null)
                                        m_SharpZipLib = System.Reflection.Assembly.LoadFrom(Lfx.Environment.Folders.ApplicationFolder + "ICSharpCode.SharpZipLib.dll");
                                return m_SharpZipLib;
                        }
                }

		/* public bool ExtractAll(string outputFolder)
		{
			return this.Extract("*.*", outputFolder);
		} */

		public bool Extract(System.IO.Stream outputStream)
		{
			switch(this.ArchiveType)
			{
                                case ArchiveTypes.BZip2:
                                        object[] Args = new object[] { InputStream, outputStream, true };
                                        System.Reflection.MethodInfo DecompMethod = this.SharpZipLib.GetType("ICSharpCode.SharpZipLib.BZip2.BZip2").GetMethod("Decompress");
                                        DecompMethod.Invoke(null, Args);
                                        break;
                                default:
                                        throw new NotImplementedException("Tipo de archivo no reconocido");
			}
			return true;
		}

		public bool Add(string fileName)
		{
                        throw new NotImplementedException("No implementado");
		}
	}
}
