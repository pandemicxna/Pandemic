using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace Pandemic
{
    class _mySQLBase
    {
        protected MySqlConnectionStringBuilder mysqlSB = new MySqlConnectionStringBuilder();
        protected MySqlCommand com = new MySqlCommand();
        protected MySqlConnection con = new MySqlConnection();
        protected MySqlDataReader dr;

        public _mySQLBase() { }
        public _mySQLBase(string Server, string Database, string UserID, string Password)
        {
            mysqlSB.Server = Server;
            mysqlSB.Database = Database;
            mysqlSB.UserID = UserID;
            mysqlSB.Password = Password;
        }

        public virtual DataTable Display(String queryString)
        {
            DataTable dt = new DataTable();
            return dt;
        }
    }
}
