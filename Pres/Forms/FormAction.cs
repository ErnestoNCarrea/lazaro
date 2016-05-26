using System;
using System.Collections.Generic;

namespace Lazaro.Pres.Forms
{
        public enum FormActionVisibility
        {
                Hidden,
                Main,
                Secondary,
                Tertiary
        }

        public class FormAction
        {
                public string Text { get; set; }
                public string SubText { get; set; }
                public string Name { get; set; }
                public bool Enabled { get; set; }
                public string Extra { get; set; }
                public int TabIndex { get; set; }
                public FormActionVisibility Visibility { get; set; }

                public FormAction(string text, string subtext, string name, int tabstop)
                        : this(text, subtext, name, tabstop, FormActionVisibility.Main)
                {
                }

                public FormAction(string text, string subtext, string name, int tabstop, FormActionVisibility visibility)
                {
                        this.Enabled = true;
                        this.Text = text;
                        this.SubText = subtext;
                        if (string.IsNullOrEmpty(name))
                                this.Name = this.Text;
                        else
                                this.Name = name;
                        this.TabIndex = tabstop;
                        this.Visibility = visibility;
                }

                public override string ToString()
                {
                        return this.Text;
                }
        }
}
