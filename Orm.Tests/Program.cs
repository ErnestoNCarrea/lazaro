using System;

namespace Lazaro.Orm.Tests
{
        public class Program
        {
                public static int Main(string[] args)
                {
                        var Tst = new qGen.SqlFormatterTests();

                        Tst.InsertTest();
                        return 0;
                }
        }
}
