using System;
using System.Collections.Generic;
using System.Text;

namespace Lfx.Components
{
        public class FunctionInfo
        {
                public IComponent ComponentInfo;
                public string Nombre;
                public bool AutoRun = false;
                public Lfx.Components.Function Instancia = null;
                public bool Ready = false;

                public FunctionInfo(IComponent compInfo)
                {
                        this.ComponentInfo = compInfo;
                }

                public void Load()
                {
                        if (this.Instancia == null)
                                this.Instancia = (Lfx.Components.Function)this.ComponentInfo.Assembly.CreateInstance(this.ComponentInfo.EspacioNombres + "." + this.Nombre);

                        if (Instancia != null) {
                                this.Instancia.Workspace = Lfx.Workspace.Master;
                                Lfx.Types.OperationResult Res = this.Instancia.Try();
                                if (Res.Success) {
                                        this.Ready = true;
                                } else {
                                        this.Ready = false;
                                }
                        } else {
                                this.Ready = false;
                        }
                }

                public object Run()
                {
                        if (this.Instancia == null)
                                this.Load();

                        if (this.Instancia == null)
                                return null;
                        else
                                return this.Instancia.Run();
                }

                public override string ToString()
                {
                        if (this.Instancia == null)
                                return this.Nombre;
                        else
                                return Instancia.ToString();
                }
        }
}
