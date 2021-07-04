using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FranzApp.Assistant
{
    class DatabaseAssistant
    {
        private OleDbConnection getOleDbConnection()
        {
            OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=U:\02_Privat\Programmieren\Acces Datenbanken\FranzAppDatabase.accdb");
            return conn;
        }


        protected String getSingleStringSelectCommand(String sql)
        {
            String output = "";

            OleDbConnection conn = getOleDbConnection();
            conn.Open();

            OleDbCommand comm = new OleDbCommand(sql, conn);
            OleDbDataReader reader = comm.ExecuteReader();

            while (reader.Read())
            {
                output = reader[0].ToString();
            }

            reader.Close();
            conn.Close();

            return output;
        }

        protected int getSingleIntSelectCommand(String sql)
        {
            int output = 0;

            OleDbConnection conn = getOleDbConnection();
            conn.Open();

            OleDbCommand comm = new OleDbCommand(sql, conn);
            OleDbDataReader reader = comm.ExecuteReader();

            while (reader.Read())
            {
                output = reader.GetInt32(0);
            }

            reader.Close();
            conn.Close();

            return output;
        }

        protected Boolean getSingleBooleanSelectCommand(String sql)
        {
            Boolean output = false;

            OleDbConnection conn = getOleDbConnection();
            conn.Open();

            OleDbCommand comm = new OleDbCommand(sql, conn);
            OleDbDataReader reader = comm.ExecuteReader();

            while (reader.Read())
            {
                output = reader.GetBoolean(0);
            }

            reader.Close();
            conn.Close();

            return output;
        }


        protected void setInsertIntoCommand(String sql)
        {
            OleDbConnection conn = getOleDbConnection();
            conn.Open();

            OleDbCommand comm = new OleDbCommand(sql, conn);
            comm.ExecuteNonQuery();

            conn.Close();
        }

        protected void setUpdateCommand(String sql)
        {
            OleDbConnection conn = getOleDbConnection();
            conn.Open();

            OleDbCommand comm = new OleDbCommand(sql, conn);
            comm.ExecuteNonQuery();

            conn.Close();
        }


        protected Library.User getUser(String sql)
        {
            Library.User user = new Library.User();

            OleDbConnection conn = getOleDbConnection();
            conn.Open();

            OleDbCommand comm = new OleDbCommand(sql, conn);
            OleDbDataReader reader = comm.ExecuteReader();

            while (reader.Read())
            {
                user.userID = reader.GetInt32(0);
                user.lastname = reader[1].ToString();
                user.firstname = reader[2].ToString();
                user.passcode = reader[3].ToString();
                user.eMail = reader[4].ToString();
                user.admin = reader.GetBoolean(5);
                user.teacher = reader.GetBoolean(6);
                user.teacher = reader.GetBoolean(7);
                user.student = reader.GetBoolean(8);
                user.guest = reader.GetBoolean(9);
                user.darkMode = reader.GetBoolean(10);
                user.group = reader[11].ToString();
            }

            reader.Close();
            conn.Close();

            return user;
        }
    }
}
