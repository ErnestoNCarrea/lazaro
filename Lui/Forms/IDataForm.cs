using System.ComponentModel;

namespace Lui.Forms
{
        public interface IDataForm
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
