using System;
using System.Collections.Generic;

namespace Lazaro.Pres.Forms
{
        public class FormActionCollection : List<FormAction>
        {
                public bool ContainsKey(string name)
                {
                        foreach (FormAction act in this) {
                                if (act.Name == name)
                                        return true;
                        }
                        return false;
                }

                public FormAction this[string name]
                {
                        get{
                                foreach (FormAction act in this) {
                                        if (act.Name == name)
                                                return act;
                                }
                                return null;
                        }
                        set
                        {
                                if (this.ContainsKey(name))
                                        this.Remove(this[name]);
                                this.Add(value);
                        }
                }

                public void AddAndUpdate(Lazaro.Pres.Forms.FormActionCollection actions)
                {
                        foreach (Lazaro.Pres.Forms.FormAction act in actions) {
                                if (this.ContainsKey(act.Name))
                                        this[act.Name] = act;
                                else
                                        this.Add(act);
                        }
                }

                /// <summary>
                /// Hace una copia superficial de la colección.
                /// Clona la colección, pero no clona cada uno de sus elementos, los cuales se pasan como referencias al original.
                /// </summary>
                /// <returns>Una copia superficial de la colección.</returns>
                public FormActionCollection ShallowClone()
                {
                        FormActionCollection Res = new FormActionCollection();

                        foreach (FormAction Act in this) {
                                Res.Add(Act);
                        }

                        return Res;
                }
        }
}
