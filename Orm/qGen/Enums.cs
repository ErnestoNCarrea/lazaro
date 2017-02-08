
namespace qGen
{
        public enum AndOr
        {
                And,
                Or,
        }

        public enum WhereHaving
        {
                Where,
                Having,
        }

        internal enum SqlFunctions
        {
                Now
        }

        public enum SqlModes
        {
                Ansi = 0,
                MySql,
                PostgreSql,
                SQLite,
                TransactSql,
                Oracle,
        }

        public enum ComparisonOperators
        {
                NullSafeEquals,
                Equals,
                NotEqual,
                LessThan,
                GreaterThan,
                LessOrEqual,
                GreaterOrEqual,
                SensitiveLike,
                InsensitiveLike,
                SensitiveNotLike,
                InsensitiveNotLike,
                SoundsLike,
                In,
                NotIn,
                Between
        }

        public enum JoinTypes
        {
                ImplicitJoin,
                InnerJoin,
                NaturalJoin,
                CrossJoin,
                LeftJoin,
                LeftOuterJoin,
                RightOuterJoin,
                FullOuterJoin
        }

        public enum InsertTypes
        {
                Insert,
                InsertOrReplace
        }
}
