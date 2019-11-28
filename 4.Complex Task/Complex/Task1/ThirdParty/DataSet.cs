using System.Collections.Generic;
using System.Linq;

namespace Complex.Task1.ThirdParty
{
    public class DataSet : IDataSet
    {
        private readonly ICollection<Data> data = new LinkedList<Data>();

        public void Put(string columnName, object value)
        {
            data.Add(new Data(columnName, value));
        }

        public IList<string> GetColumnNames()
        {
            return data.Select(d => d.ColumnName).ToList();
        }

        public IList<object> GetValues()
        {
            return data.Select(d => d.Value).ToList();
        }

        public override string ToString()
        {
            return $"DataStr\n{{\ncolumnNames: {GetColumnNames()}\nvalue: {GetValues()}\n}}";
        }

        private class Data
        {
            public Data(string columnName, object value)
            {
                ColumnName = columnName;
                Value = value;
            }

            public string ColumnName { get; }

            public object Value { get; }
        }
    }
}