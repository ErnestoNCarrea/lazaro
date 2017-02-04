using System;

namespace Lfx.Data
{
        public class Table
        {
                public string Name;
                public bool AlwaysCache = false, Cacheable = true;
                public IConnection Connection;

                private string m_PrimaryKey = null;
		protected RowCollection m_Rows = null;

                public Table(IConnection connection, string name)
                {
			this.Connection = connection;
                        this.Name = name;
                }

		public RowCollection FastRows
                {
			get
			{
				if(m_Rows == null) {
		                        m_Rows = new RowCollection(this);
				}
				return m_Rows;
			}
		}

                public string PrimaryKey
                {
                        get
                        {
                                if (m_PrimaryKey == null && Lfx.Workspace.Master.Structure.Tables.ContainsKey(this.Name) && Lfx.Workspace.Master.Structure.Tables[this.Name].PrimaryKey != null)
                                        m_PrimaryKey = Lfx.Workspace.Master.Structure.Tables[this.Name].PrimaryKey.Name;

                                return m_PrimaryKey;
                        }
                }


                public void PreLoad()
                {
                        this.FastRows.LoadAll();
                }


                public Lfx.Data.TagCollection Tags
                {
			get
			{
                                if (Lfx.Workspace.Master.Structure.TagList.ContainsKey(this.Name) == false)
                                        Lfx.Workspace.Master.Structure.TagList.Add(this.Name, new Lfx.Data.TagCollection());

                                return Lfx.Workspace.Master.Structure.TagList[this.Name];
			}
                }

                public override string ToString()
                {
                        return this.Name;
                }
        }
}
