using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lazaro.Base.Controller
{
        public class BaseController
        {
                public System.Data.IDbTransaction Transaction { get; set; }

                public BaseController() { }

                public BaseController(System.Data.IDbTransaction trans)
                {
                        this.Transaction = trans;
                }
        }
}
