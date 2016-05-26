using System;

namespace qGen
{
        [Serializable]
        public class Window
        {
                public int Offset = 0;
                public int Limit = 0;

                public Window(int limit)
                        : this(0, limit)
                {
                }

                public Window(int offset, int limit)
                {
                        this.Offset = offset;
                        this.Limit = limit;
                }

                public override string ToString()
                {
                        return "LIMIT " + this.Limit.ToString() + " OFFSET " + this.Offset.ToString();
                }
        }
}
