using System;
using NUnit.Framework;
using System.Collections.Generic;
using qGen;

namespace Lazaro.Orm.Tests.qGen
{
        public class SqlFormatterTests
        {
                [Test]
                public void ValueFormatTest()
                {
                        var Fmt = this.GetSqlFormatter();

                        Assert.AreEqual("1.23", Fmt.FormatDecimal(1.2345m, 2));
                        Assert.AreEqual("1.24", Fmt.FormatDecimal(1.2399m, 2));
                        Assert.AreEqual("1.2345", Fmt.FormatDecimal(1.2345m, 4));

                        Assert.AreEqual("'abc'", Fmt.FormatValue("abc"));
                        Assert.AreEqual("1.23450000", Fmt.FormatValue(1.2345m));
                        Assert.AreEqual("678", Fmt.FormatValue(678));

                        Assert.AreEqual("'1976-03-19 01:02:03'", Fmt.FormatValue(new DateTime(1976, 03, 19, 1, 2, 3)));

                        Assert.AreEqual("NULL", Fmt.FormatValue(null));
                        Assert.AreEqual("NULL", Fmt.FormatValue(DBNull.Value));

                        Assert.AreEqual("1,2,3", Fmt.FormatValue(new int[] { 1, 2, 3 }));
                        Assert.AreEqual("11,22,33", Fmt.FormatValue(new List<int>() { 11, 22, 33 }));

                        Assert.AreEqual("'rojo','azul','verde'", Fmt.FormatValue(new string[] { "rojo", "azul", "verde" }));
                        Assert.AreEqual("'rojo','azul','verde'", Fmt.FormatValue(new List<string>() { "rojo", "azul", "verde" }));
                }


                [Test]
                public void SelectTest()
                {
                        var Fmt = this.GetSqlFormatter();

                        var Select = new Select("sampletable");
                        Assert.AreEqual("SELECT * FROM \"sampletable\"", Fmt.SqlText(Select));

                        Select.Columns = new SqlIdentifierCollection() { "cola", "colb", "colc" };
                        Assert.AreEqual("SELECT \"cola\", \"colb\", \"colc\" FROM \"sampletable\"", Fmt.SqlText(Select));

                        Select.Joins = new JoinCollection()
                        {
                                new Join("secondtable", "sampletable.idcol=secondtable.idcol")
                        };
                        Select.WhereClause = new Where("colc", "valcolc");
                        Select.Order = "colb DESC";
                        Select.Window = new Window(50, 10);
                        Assert.AreEqual("SELECT \"cola\", \"colb\", \"colc\" FROM \"sampletable\" LEFT JOIN \"secondtable\" ON sampletable.idcol=secondtable.idcol WHERE (colc='valcolc') ORDER BY colb DESC LIMIT 10 OFFSET 50", Fmt.SqlText(Select));
                }


                [Test]
                public void DeleteTest()
                {
                        var Fmt = this.GetSqlFormatter();

                        var Delete = new Delete("sampletable");
                        Delete.WhereClause = new Where(AndOr.Or);
                        Delete.WhereClause.AddWithValue("col1", "val1");
                        Delete.WhereClause.AddWithValue("col2", 123.45);
                        Assert.AreEqual("DELETE FROM \"sampletable\" WHERE (col1='val1' OR col2=123.45000000)", Fmt.SqlText(Delete));
                }

                [Test]
                public void InsertTest()
                {
                        var Fmt = this.GetSqlFormatter();

                        var Insert = new Insert("instable");
                        Insert.ColumnValues.AddWithValue("col1", 123);
                        Insert.ColumnValues.AddWithValue("col2", 45.678);
                        Insert.ColumnValues.AddWithValue("col3", "Ushuaia");
                        Insert.ColumnValues.AddWithValue("col4", new DateTime(2017, 5, 6, 1, 2, 3));
                        Assert.AreEqual("INSERT INTO \"instable\" (\"col1\", \"col2\", \"col3\", \"col4\") VALUES (123, 45.67800000, 'Ushuaia', '2017-05-06 01:02:03')", Fmt.SqlText(Insert));
                }


                [Test]
                public void WhereTest()
                {
                        var Fmt = this.GetSqlFormatter();

                        var Where = new Where();
                        Where.Add(new ComparisonCondition("col1", ComparisonOperators.GreaterOrEqual, 32));
                        Where.Add(new ComparisonCondition("col2", ComparisonOperators.InsensitiveLike, "%part%"));
                        Where.Add(new SqlCondition("col3 IS NOT NULL"));
                        Assert.AreEqual("(col1>=32 AND col2 LIKE '%part%' AND col3 IS NOT NULL)", Fmt.SqlText(Where));
                }


                [Test]
                public void BulkInsertTest()
                {
                        var Fmt = this.GetSqlFormatter();

                        var Bi = new BuilkInsert();
                        Assert.AreEqual(string.Empty, Fmt.SqlText(Bi));

                        var Insert1 = new Insert("bitable");
                        Insert1.ColumnValues.AddWithValue("col1", 1);
                        Insert1.ColumnValues.AddWithValue("col2", "abc");

                        var Insert2 = new Insert("bitable");
                        Insert2.ColumnValues.AddWithValue("col1", 2);
                        Insert2.ColumnValues.AddWithValue("col2", "def");

                        var Insert3 = new Insert("bitable");
                        Insert3.ColumnValues.AddWithValue("col1", 3);
                        Insert3.ColumnValues.AddWithValue("col2", "ghi");

                        Bi.Add(Insert1);
                        Bi.Add(Insert2);
                        Bi.Add(Insert3);

                        Assert.AreEqual("INSERT INTO \"bitable\" (\"col1\", \"col2\") VALUES (1, 'abc')\r\n, (2, 'def')\r\n, (3, 'ghi')\r\n", Fmt.SqlText(Bi));
                }


                protected SqlFormatter GetSqlFormatter()
                {
                        return new SqlFormatter();
                }
        }
}
