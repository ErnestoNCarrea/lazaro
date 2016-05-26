using System.ComponentModel;

namespace Lui.Forms
{
        public interface IEditableControl
        {
                string FieldName { get; set; }
                bool ReadOnly { get; set; }
                bool TemporaryReadOnly { get; set; }

                [EditorBrowsable(EditorBrowsableState.Never),
                        Browsable(false),
                        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
                bool Changed
                {
                        get;
                        set;
                }

                bool ShowChanged
                {
                        set;
                }
        }
}
