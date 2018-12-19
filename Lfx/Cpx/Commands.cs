using System;
using System.Collections.Generic;
using System.Text;

namespace Lfx.Cpx
{
        public class Command
        {
                public Printer Printer = null;

                public override string ToString()
                {
                        throw new NotImplementedException();
                }
        }

        public class EmbossCommand : Command
        {

        }

        public class EncodeCommand : Command
        {

        }

        public class MessageCommand : Command
        {

        }

        public class ChangeFontCommand : Command
        {

        }

        public class RejectCardCommand : Command
        {

        }

        public class LineLocationDatacommand : Command
        {
                
        }

        /// <summary>
        /// Matches the data on the magnetic stripe before writing.
        /// </summary>
        public class DataMatchCompareCommand : Command
        {
                public string MatchData;

                public DataMatchCompareCommand(string matchData)
                {
                        this.MatchData = matchData;
                }

                public override string ToString()
                {
                        return "#CMP#" + this.MatchData;
                }
        }

        public class ReadMagneticsStripeCommand : Command
        {
                public override string ToString()
                {
                        return "#DCC##TRK##END#@@@@@@";
                }
        }

        public class CpxVersionCommand : Command
        {
                public override string ToString()
                {
                        return "#DCC##VER##END#@";
                }
        }

        public class ErrorStatusCommand : Command
        {
                public override string ToString()
                {
                        return "#DCC##ERR##END#@";
                }
        }

        public class EnquiryCommand : Command
        {
                public override string ToString()
                {
                        return ((char)(0x05)).ToString();
                }
        }

        /// <summary>
        /// 150i CPX Protocol/Setup Manual, 2-14 en adelante
        /// </summary>
        public class EmbossAndEncodeCommand1 : Command
        {
                public EmbossAndEncodeCommand1()
                {
                }

                public override string ToString()
                {
                        //                        string LineLocationsBlock = @"#DCL##GTW#0""
                        //0004,0002,0401,0843,0000,0000,0000,0000,0000,""
                        //0004,0001,0600,0489,0000,0000,0000,0000,0000,""
                        //0004,0001,0250,0332,0000,0000,0000,0000,0000,""
                        //0004,0003,2353,1250,0000,0000,0000,0000,0000,""
                        //#END#@@@@@@";
                        string LineLocationsBlock = @"#DCL##GTW#0""
0004,0002,0401,0843,0000,0000,0000,0000,0000,""
0004,0001,0600,0489,0000,0000,0000,0000,0000,""
0004,0001,0250,0332,0000,0000,0000,0000,0000,""
0004,0001,0250,0170,0000,0000,0000,0000,0000,""
0004,0003,1547,1168,0000,0000,0000,0000,0000,""
#END#@@@@@@";
                        //0005,0002,0000,0000,0000,0000,0000,0000,0000,""
                        return LineLocationsBlock;
                }
        }

        /// <summary>
        /// 150i CPX Protocol/Setup Manual, 2-14 en adelante
        /// </summary>
        public class EmbossAndEncodeCommand2 : Command
        {
                public string CardNumber, ExpDate, CardOwner, Track2;
                public int Cvc {get;set;}
                public string BackText { get; set; }

                public EmbossAndEncodeCommand2(string cardNumber, string expDate, string cardOwner, int cvc, string track2)
                {
                        this.CardNumber = cardNumber;
                        this.ExpDate = expDate;
                        this.CardOwner = cardOwner;
                        this.Track2 = track2;
                        this.Cvc = cvc;
                }

                public override string ToString()
                {
                        if (this.CardOwner.Length > 23)
                                this.CardOwner = this.CardOwner.Substring(0, 23);

                        if (string.IsNullOrEmpty(this.BackText))
                                this.BackText = CardNumber.Substring(CardNumber.Length - 4, 4) + " " + Cvc.ToString();

                        string DataBlock = @"#DCC#";
                        if (string.IsNullOrEmpty(Track2) == false)
                                DataBlock += @"#CMP#;" + Track2 + @"?";

                        DataBlock += @"#GRD#0""
" + CardNumber + @"""
" + ExpDate + @"""
" + CardOwner + @"""
" + Cvc + @"""
" + BackText + @"""
#END#@@@@@";

                        if (string.IsNullOrEmpty(Track2) == false)
                                DataBlock += "@";
                        return DataBlock;
                }
        }
}
