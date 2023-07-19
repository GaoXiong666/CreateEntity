using System.Collections.Generic;
using System.Data.Common;

namespace CreateEntity
{
    public interface IDB
    {
        List<Table> GetTableAll(DbConnection conn);

        List<TableColumn> GetTableColumn(DbConnection conn, Table table);
    }
}
