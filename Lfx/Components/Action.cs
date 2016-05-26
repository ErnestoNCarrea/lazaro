using System;
using System.Collections.Generic;

namespace Lfx.Components
{
        public class Action
        {
                public string Verb { get; set; }
                public Type Handler { get; set; }

                public Action(string verb, Type verbHandler) 
                {
                        this.Verb = verb;
                        this.Handler = verbHandler;
                }
        }
}
