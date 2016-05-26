using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Lui.Forms
{
	public class ProgressBar : System.Windows.Forms.ProgressBar, IControl, IDisplayStyleControl
	{
                [EditorBrowsable(EditorBrowsableState.Never),
                        System.ComponentModel.Browsable(false),
                        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
                public virtual Lazaro.Pres.DisplayStyles.IDisplayStyle DisplayStyle
                {
                        get
                        {
                                return null;
                        }
                        set
                        {
                        }
                }
	}
}
