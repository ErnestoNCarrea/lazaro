using System;
using System.Collections.Generic;

namespace Lazaro.Pres.Forms
{
        public class Form
        {
                public Type ElementoTipo { get; set; }
                public string Label { get; set; }

                public SectionCollection Sections { get; set; }
        }
}
