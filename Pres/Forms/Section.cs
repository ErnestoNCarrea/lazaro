using System;
using System.Collections.Generic;

namespace Lazaro.Pres.Forms
{
        public class Section
        {
                public string Label { get; set; }

                public FieldCollection Fields { get; set; }

                public Section()
                {
                        this.Fields = new FieldCollection();
                }

                public Section(string label)
                        : this()
                {
                        this.Label = label;
                }

                public Section(string label, FieldCollection fields)
                        : this(label)
                {
                        this.Fields = fields;
                }
        }
}
