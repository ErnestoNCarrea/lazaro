using System;
using System.Collections.Generic;
using System.Text;

namespace Lfx.Cpx
{
        public class CommandList : List<Command>
        {
                private Printer m_Printer = null;

                public Printer Printer
                {
                        get
                        {
                                return m_Printer;
                        }
                        set
                        {
                                m_Printer = value;
                                foreach (Command Cmd in this) {
                                        Cmd.Printer = value;
                                }
                        }
                }

                public CommandList(Printer printer)
                {
                        this.Printer = printer;
                }

                new public void Add(Command command)
                {
                        command.Printer = this.Printer;
                        base.Add(command);
                }

                public override string ToString()
                {
                        StringBuilder Res = new StringBuilder();

                        foreach (Command Cmd in this) {
                                Res.Append(Cmd.ToString());
                        }

                        return Res.ToString();
                }
        }
}
