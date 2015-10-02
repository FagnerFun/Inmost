using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InMost.DAO
{
    class Connection
    {

        private static string _connectionString = ConfigurationManager.AppSettings["conexao"].ToString();
        SqlConnection conn = null;
        SqlDataAdapter adapter = null;
        List<string> logValue = new List<string>();

        public void OpenConnection()
        {
            try
            {
                CloseConnection();

                conn = new SqlConnection(_connectionString);
                conn.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void CloseConnection()
        {
            if (conn != null)
            {
                conn.Close();
                conn = null;
            }
            if (adapter != null)
                adapter = null;
        }
        public void CreateDataAdapter(string procedureName)
        {
            try
            {
                adapter = new SqlDataAdapter(procedureName, conn);
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void InserParameter(string parameter, SqlDbType type, object value)
        {
            if (value != null)
                adapter.SelectCommand.Parameters.Add("@" + parameter, type).Value = value;
        }
        public DataTable GetResult(DataTable data)
        {
            adapter.Fill(data);
            CloseConnection();

            return data;
        }
        public DataSet GetResult(DataSet data)
        {
            adapter.Fill(data);
            CloseConnection();

            return data;
        }
        public DataSet GetResultAsDataSet(DataSet data)
        {
            adapter.Fill(data);
            CloseConnection();

            return data;
        }
    }

}

