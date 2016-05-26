using System;
using System.Collections.Generic;
using System.Text;

namespace Lfx.Cpx
{
        public class CommandResponse
        {
                public string OriginalCommand = "";
                public string[] PayLoad;

                public CommandResponse(string rawResponse)
                {
                        this.FromString(rawResponse);
                }

                public void FromString(string text)
                {
                        bool Escape = false;
                        string RawPayLoad = "";

                        for (int i = 0; i < text.Length; i++) {
                                if (text[i] == '#') {
                                        Escape = !Escape;
                                        if (Escape && OriginalCommand.Length > 0)
                                                OriginalCommand += ",";
                                } else if (text[i] == '@') {
                                        break;
                                } else if (Escape) {
                                        OriginalCommand += text[i];
                                } else {
                                        RawPayLoad += text[i];
                                }
                        }

                        if (RawPayLoad.Length > 0)
                                PayLoad = RawPayLoad.Split(new char[] { '\"' });
                }
        }
}
