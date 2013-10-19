using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Pandemic
{
    class _mySQLMethods:_mySQLBase
    {
        DataTable dt = new DataTable();
        public _mySQLMethods(string Server, string Database, string UserID, string Password) 
            : base(Server, Database, UserID, Password) { }

        public override DataTable Display(String queryString)
        {
            con.ConnectionString = mysqlSB.ConnectionString;
            com = new MySqlCommand(queryString, con);
            try
            {
                con.Open();
                dr = com.ExecuteReader();
                if (dr.HasRows) dt.Load(dr);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dt;
        }
        public void Query(String queryString)
        {
            con.ConnectionString = mysqlSB.ConnectionString;
            com = new MySqlCommand(queryString, con);
            try
            {
                con.Open();
                MySqlDataReader dr = com.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }

        }
    }
}
