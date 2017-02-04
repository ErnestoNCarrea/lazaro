using System.ComponentModel;

namespace Lui.Forms
{
        public interface IDataControl
        {
                [EditorBrowsable(EditorBrowsableState.Never),
                        Browsable(false),
                        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
                Lfx.Data.IConnection Connection
                {
                        get;
                }
        }
}
