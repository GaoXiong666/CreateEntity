using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateEntity
{
    public interface IDB
    {
        List<Table> GetTableAll(DbConnection conn);

        List<TableColumn> GetTableColumn(DbConnection conn, Table table);
    }
}
