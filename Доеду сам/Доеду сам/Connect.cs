using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Win32;

namespace Доеду_сам
{
    class Connect
    {
        static string connect = "Server=Vc-stud-mssql1,1433;Initial Catalog=user97_db;User id=user97_db;Password=user97;MultipleActiveResultSets=True; App = EntityFrameword; Connection Timeout=2;";
        public static SqlConnection MyConnection = new SqlConnection(@connect);
        public static int On(int x)
        {
            try { MyConnection.Open(); }
            catch (System.Data.SqlClient.SqlException) { return x = 1; }
            return x = 0;
        }
        public static void Off()
        {
            MyConnection.Close();
        }
    }
}
