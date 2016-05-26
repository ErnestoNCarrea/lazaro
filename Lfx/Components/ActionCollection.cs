using System;
using System.Collections.Generic;

namespace Lfx.Components
{
        public class ActionCollection : List<Action>
        {
                public Action this[string verb]
                {
                        get
                        {
                                foreach (Action act in this) {
                                        if (act.Verb == verb)
                                                return act;
                                }
                                throw new IndexOutOfRangeException();
                        }
                }

                public bool ContainsKey(string verb)
                {
                        foreach (Action act in this) {
                                if (act.Verb == verb)
                                        return true;
                        }
                        return false;
                }


                public void Remove(string verb)
                {
                        foreach (Action act in this) {
                                if (act.Verb == verb) {
                                        this.Remove(act);
                                        return;
                                }
                        }
                        throw new IndexOutOfRangeException();
                }

                new public void AddRange(IEnumerable<Action> acciones)
                {
                        foreach (Action acc in acciones) {
                                this.Add(acc);
                        }
                }

                new public void Add(Action act)
                {
                        if (this.ContainsKey(act.Verb))
                                this.Remove(act.Verb);

                        base.Add(act);
                }
        }
}
