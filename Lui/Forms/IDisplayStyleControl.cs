using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Text;

namespace Lui.Forms
{
        public interface IDisplayStyleControl
        {
                Lazaro.Pres.DisplayStyles.IDisplayStyle DisplayStyle { get; }
        }
}
