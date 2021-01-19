using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;

namespace Mercadeo
{
    class Control
    {
        DataBase Base = new DataBase();
         public DataSet DevolverSQL()
        {
            string sql = "select * from table";
            DataSet DS = new DataSet();
            DS = Base.FillDS(sql);
            return DS;
        }
    }
}
