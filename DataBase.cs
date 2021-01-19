using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;

namespace Mercadeo
{
    class DataBase
    {
        public OleDbConnection DB = new OleDbConnection();
        public OleDbDataReader dr;

        public void ConectDB()
        {
            string stringconexion;
            stringconexion = "Provider=SQLOLEDB.1;Password=#;Persist Security Info=True;User ID=;Initial Catalog=#;Data Source=#";
            DB.ConnectionString = stringconexion;
                DB.Open();
        }
        public void DisconectDB()
        {
            DB.Close();
        }
        public void ExecuteSQL(string sql)
        {
            ConectDB();
            OleDbCommand Comand = new OleDbCommand(sql, DB);
            Comand.ExecuteNonQuery();
            DisconectDB();
        }


        public DataSet FillDS(string sql)
        {
            ConectDB();
            DataSet DS = new DataSet();
            OleDbDataAdapter Adaptador = new OleDbDataAdapter(sql, DB);
            Adaptador.Fill(DS);
            DisconectDB();
            return DS;
        }

    }
}
