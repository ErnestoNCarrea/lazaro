using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl.Charts
{
        public class Serie
        {
                public Element[] Elements = null;
                public string Name = null;
                public System.Drawing.Color Color = System.Drawing.Color.Black;

                public Serie(string name, Element[] elements)
                {
                        this.Name = name;
                        this.Elements = elements;
                        System.Random r = new System.Random();
                        this.Color = System.Drawing.Color.FromArgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255));
                }

                public Serie(string name, Element[] elements, System.Drawing.Color color)
                {
                        this.Name = name;
                        this.Elements = elements;
                        this.Color = color;
                }

                public Serie(string name)
                {
                        this.Name = name;
                        System.Random r = new System.Random();
                        this.Color = System.Drawing.Color.FromArgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255));
                }

                public decimal GetSum()
                {
                        decimal Sum = 0;
                        foreach (Element El in this.Elements) {
                                if (El != null)
                                        Sum += El.Value;
                        }
                        return Sum;
                }
        }

        public class Element
        {
                public decimal Value = 0;
                public string Label = null;

                public Element()
                {
                }

                public Element(decimal value, string label)
                {
                        this.Value = value;
                        this.Label = label;
                }
        }
}
