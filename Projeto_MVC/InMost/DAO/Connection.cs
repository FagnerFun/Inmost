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
    public class Connection
    {
        public SqlConnection con = null;
        private string _conexao = System.Configuration.ConfigurationManager.AppSettings["conexao"];

        public void CriarConexao()
        {
            con = new SqlConnection(_conexao);
        }

        public void Abrir()
        {

            if (con != null)
            {
                con.Close();
                con.Open();
            }
            else
                con.Open();
        }

        public void Fechar()
        {
            con.Close();
        }
    }

}

