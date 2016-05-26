using System.Windows.Forms;

namespace Lazaro.WinMain.Principal
{
        public class MenuItemInfo
        {
                public MenuItem Item;
                public string Text;
                public string Funcion;
                public string ParentText;

                public string FullPath
                {
                        get
                        {
                                return this.ParentText + @"\" + this.Text;
                        }
                }

                public override string ToString()
                {
                        return this.FullPath;
                }
        }
}
