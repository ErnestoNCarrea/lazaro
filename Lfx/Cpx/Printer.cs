using System;
using System.Collections.Generic;
using System.Text;

namespace Lfx.Cpx
{
        public enum PrinterModels
        {
                Unknown,
                DataCard150i
        }

        public enum PriterStatusCodes
        {
                Ready,                  // A (Ack)
                WaitingForOperator,     // c
                CardComplete,           // C
                CardError,              // X
                Busy,                   // NAK
                OtherError              // any other
        }

        public class Printer
        {
                private System.IO.Ports.SerialPort Impresora;
                private PrinterModels m_PrinterModel = PrinterModels.Unknown;

                public Printer(string portBame)
                {
                        Impresora = new System.IO.Ports.SerialPort(portBame);
                        Impresora.Encoding = System.Text.Encoding.Default;
                }

                public void SendCommands(CommandList commands)
                {
                        commands.Printer = this;
                        foreach (Command Cmd in commands) {
                                this.Send(Cmd.ToString());
                        }
                }

                public void SendCommand(Command command)
                {
                        command.Printer = this;
                        this.Send(command.ToString());
                }

                public void Open()
                {
                        Impresora.Open();
                        Impresora.DtrEnable = true;
                        Impresora.RtsEnable = true;
                        System.Threading.Thread.Sleep(100);
                }

                public void Close()
                {
                        Impresora.Close();
                }

                private void Send(string data)
                {
                        Impresora.Write(data);
                        System.Threading.Thread.Sleep(500);
                }

                public CommandResponse ReadResponse()
                {
                        System.Threading.Thread.Sleep(500);
                        DateTime Inicio = DateTime.Now;
                        while ((DateTime.Now - Inicio).TotalMilliseconds < 2000) {
                                string Res = Impresora.ReadExisting();
                                if (Res != null && Res.Length > 0)
                                        return new CommandResponse(Res);
                                System.Threading.Thread.Sleep(500);
                        }
                        return null;
                        
                        /* int ToRead = Impresora.BytesToRead;
                        DateTime Inicio = DateTime.Now;
                        while (ToRead == 0 && (DateTime.Now - Inicio).TotalMilliseconds < 5000) {
                                System.Threading.Thread.Sleep(100);
                        }
                        if (ToRead > 0) {
                                byte[] BytesRead = new byte[ToRead];
                                Impresora.Read(BytesRead, 0, ToRead);
                                CommandResponse Res = new CommandResponse(Impresora.Encoding.GetString(BytesRead));
                                return Res;
                        } else {
                                return null;
                        } */
                }

                public PrinterModels PrinterModel
                {
                        get
                        {
                                if (m_PrinterModel == PrinterModels.Unknown) {
                                        this.SendCommand(new CpxVersionCommand());
                                        CommandResponse Res = this.ReadResponse();
                                        if (Res != null && Res.PayLoad != null && Res.PayLoad.Length > 0) {
                                                switch (Res.PayLoad[0].Trim()) {
                                                        case "150i/CPX":
                                                        case "150i/CPX-DES":
                                                                m_PrinterModel = PrinterModels.DataCard150i;
                                                                break;
                                                }
                                        }
                                }
                                return m_PrinterModel;
                        }
                }

                public int ErrorStatus
                {
                        get
                        {
                                this.SendCommand(new ErrorStatusCommand());
                                CommandResponse Res = this.ReadResponse();
                                if (Res != null && Res.PayLoad != null && Res.PayLoad.Length > 0)
                                        return Lfx.Types.Parsing.ParseInt(Res.PayLoad[0]);
                                else
                                        return 0;
                        }
                }

                public PriterStatusCodes Status
                {
                        get
                        {
                                this.SendCommand(new EnquiryCommand());
                                CommandResponse Res = this.ReadResponse();
                                if (Res != null && Res.PayLoad != null && Res.PayLoad.Length > 0)
                                        switch (Res.PayLoad[0].Trim()) {
                                                case "A":
                                                        return PriterStatusCodes.Ready;
                                                case "C":
                                                        return PriterStatusCodes.CardComplete;
                                                case "X":
                                                        return PriterStatusCodes.CardError;
                                                case "NAK":
                                                case "\x15":
                                                        return PriterStatusCodes.Busy;
                                                case "b":
                                                        return PriterStatusCodes.WaitingForOperator;
                                                default:
                                                        return PriterStatusCodes.OtherError;
                                        }
                                else
                                        return PriterStatusCodes.OtherError;
                        }
                }
        }
}
