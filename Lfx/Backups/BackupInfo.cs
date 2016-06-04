using System;
using System.Collections.Generic;

namespace Lfx.Backups
{
        public class BackupInfo
        {
                public string Name { get; set; }
                public string CompanyName { get; set; }
                public string UserName { get; set; }
                public string ProgramVersion { get; set; }
                public DateTime BackupDate { get; set; }
        }
}
