using System.Collections.Generic;

namespace Complex.Task1.ThirdParty
{
    public interface IDatabaseManager
    {
        IList<IDataSet> GetTableData(string tableName);
    }
}