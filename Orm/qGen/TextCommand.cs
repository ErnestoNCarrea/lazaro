using Lazaro.Orm.Data;
using System;

namespace qGen
{
        public class LiteralStatement : Statement
        {
                public string Text { get; set; }

                public LiteralStatement()
                        : base() { }

                public LiteralStatement(string stmntText)
                        : this()
                {
                        this.Text = stmntText;
                }

                public override string ToString()
                {
                        return this.Text;
                }
        }
}
