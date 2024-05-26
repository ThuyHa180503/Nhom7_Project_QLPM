using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Nhom7_Project_QLPM.Class
{
    internal class functions
    {
        public static SqlConnection conn;
        public static string connString;
        public static void connect()
        {
            connString = "Data Source=DESKTOP-KQJ3SRA\\SQLEXPRESS;Initial Catalog=QLPM;Integrated Security=True;Encrypt=False";
            conn = new SqlConnection();
            conn.ConnectionString = connString;
            conn.Open();
            //MessageBox.Show("kntc");

        }
        public static void fillcombo(string sql, ComboBox cbo, string ma, string ten)
        {
            SqlDataAdapter mydata = new SqlDataAdapter(sql, Class.functions.conn);
            DataTable tb = new DataTable();
            mydata.Fill(tb);
            cbo.DataSource = tb;
            cbo.ValueMember = ma;
            cbo.DisplayMember = ten;
        }
        public static DataTable getdatatotable(string sql)
        {
            SqlDataAdapter Mydata = new SqlDataAdapter(sql, Class.functions.conn);
            DataTable table = new DataTable();
            Mydata.Fill(table);
            return table;
        }
        public static void runsql(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, Class.functions.conn);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (System.Exception loi)
            {
                MessageBox.Show(loi.ToString());
            }
            cmd.Dispose();
            cmd = null;
        }
        public static string CreateMastt()
        {
            int maxMastt = 0;
            string sql = "SELECT ISNULL(MAX(CAST(mastt AS INT)), 0) FROM tbllichthuchanh"; 

            using (SqlConnection connection = new SqlConnection(connString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                connection.Open();
                object result = command.ExecuteScalar();
                maxMastt = Convert.ToInt32(result);

                maxMastt += 1;

                if (maxMastt < 10)
                    return "00" + maxMastt;
                else if (maxMastt < 100)
                    return "0" + maxMastt;
                else
                    return maxMastt.ToString();
            }
        }


        public static bool isdate(string d)
        {
            string[] parts = d.Split('/');
            if ((Convert.ToInt32(parts[0]) >= 1) && (Convert.ToInt32(parts[0]) <= 31) && (Convert.ToInt32(parts[1]) >= 1) && (Convert.ToInt32(parts[1]) <= 12) && (Convert.ToInt32(parts[2]) >= 1900))
                return true;
            else
                return false;
        }
        public static string convertdatetime(string d)
        {
            string[] parts = d.Split('/');
            string dt = String.Format("{0}/{1}/{2}", parts[1], parts[0], parts[2]);
            return dt;
        }
        public static bool checkkey(string sql)
        {
            SqlDataAdapter mydata = new SqlDataAdapter(sql, Class.functions.conn);
            DataTable table = new DataTable();
            mydata.Fill(table);
            if (table.Rows.Count > 0)
                return true;
            else return false;
        }
        public static string getfieldvalues(string sql)
        {
            string ma = "";
            SqlCommand cmd = new SqlCommand(sql, Class.functions.conn);
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            while (reader.Read())
                ma = reader.GetString(0).ToString();
            reader.Close();
            return ma;
        }
        public static string getfieldvaluesint (string sql)
        {
            string value = null;
            SqlCommand cmd = new SqlCommand(sql, Class.functions.conn);
            SqlDataReader reader;

            reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                if (!reader.IsDBNull(0))
                {
                    int intValue;
                    if (int.TryParse(reader[0].ToString(), out intValue))
                    {
                        value = intValue.ToString();
                    }
                }
            }
            reader.Close();
            return value;
        }

    }
}
