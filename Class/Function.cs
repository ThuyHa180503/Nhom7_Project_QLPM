using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nhom7_Project_QLPM.Class
{
    internal class Function
    {
        public static SqlConnection Conn;
        public static string connString;
        public static void Connect()
        {
            connString = "Data Source=RYNNA\\THUYHA;Initial Catalog=QLPM;Integrated Security=True;Encrypt=False";
            Conn = new SqlConnection();
            Conn.ConnectionString = connString;
            Conn.Open();
            //MessageBox.Show("kntc");
        }
        public static void Disconnect()
        {
            if (Conn.State == ConnectionState.Open)
            {
                Conn.Close();
                Conn.Dispose();
                Conn = null;
            }
        }

        public static void FillCombo(string sql, ComboBox cbo, string ma, string ten)
        {
            SqlDataAdapter Mydata = new SqlDataAdapter(sql, Class.Function.Conn); ;
            DataTable table = new DataTable();
            Mydata.Fill(table);
            cbo.DataSource = table;
            cbo.ValueMember = ma;
            cbo.DisplayMember = ten;
        }
        public static void RunSql(string sql)
        {
            SqlCommand cmd;		               
            cmd = new SqlCommand();	         
            cmd.Connection = Function.Conn;	  
            cmd.CommandText = sql;			  
            try
            {
                cmd.ExecuteNonQuery();		  
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            cmd.Dispose();
            cmd = null;
        }
        public static DataTable GetDataToTable(string sql)
        {
            SqlDataAdapter Mydata = new SqlDataAdapter(sql, Function.Conn);
            DataTable table = new DataTable();
            Mydata.Fill(table);
            return table;
        }
        public static string GetFieldValues(string sql)
        {
            string ma = "";
            SqlCommand cmd = new SqlCommand(sql, Function.Conn);
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ma = reader.GetValue(0).ToString();
            }
            reader.Close();
            return ma;
        }
        public static void RunSqlDel(string sql)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Function.Conn;
            cmd.CommandText = sql;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (System.Exception)
            {
                MessageBox.Show("Dữ liệu đang được dùng, không thể xóa...", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            cmd.Dispose();
            cmd = null;
        }
        //Trang trần
        public static bool CheckKey(string sql)
        {
            SqlDataAdapter Mydata = new SqlDataAdapter(sql, Function.Conn);
            DataTable table = new DataTable();
            Mydata.Fill(table);
            if (table.Rows.Count > 0)
                return true;
            else
                return false;
        }


        //Phượng

        public static string createmastt()
        {
            int maxMastt = 0;
            string sql = "SELECT ISNULL(MAX(CAST(mastt AS INT)), 0) FROM tbllichthuchanh";
            SqlCommand command = new SqlCommand(sql, Class.Function.Conn);
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

        public static string getfieldvaluesint(string sql)
        {
            string value = null;
            SqlCommand cmd = new SqlCommand(sql, Class.Function.Conn);
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
        public static DataTable getdatatotables(string sql, SqlParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(connString))
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    return table;
                }
            }
        }


        //Phương anh



        //Giang



    }
}
