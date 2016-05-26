namespace Lazaro.Pres.Filters
{
        public interface IFilter
        {
                string Label { get; set; }
                string ColumnName { get; set; }

                object Value { get; set; }
                object Value2 { get; set; }

                object Control { get; set; }

                bool IsEmpty();
        }
}
