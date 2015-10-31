using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InMost.DAO
{
    class ConvidarDAO : Connection
    {
        public DataTable BuscarEmail(string email)
        {
            try
            {
                CriarConexao();
                Abrir();
                SqlDataAdapter Cmd = new SqlDataAdapter("BuscaMail", con);

                Cmd.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;

                Cmd.SelectCommand.Parameters.Add("@USUARIO", SqlDbType.VarChar).Value = email;

                DataTable data = new DataTable();

                Cmd.Fill(data);

                return data;

            }
            catch (Exception e)
            {

            }



            return null;
        }

        public void CadastrarLogin(string destinatario, string senha)
        {
            try
            {
                CriarConexao();
                Abrir();
                SqlCommand Cmd = new SqlCommand("InserirMail", con);

                Cmd.CommandType = System.Data.CommandType.StoredProcedure;

                Cmd.Parameters.Add("@USUARIO", SqlDbType.VarChar).Value = destinatario;
                Cmd.Parameters.Add("@SENHA", SqlDbType.VarChar).Value = senha;
                Cmd.ExecuteNonQuery();
                

            }
            catch (Exception e)
            {
                return;
            }
        }

    }
}
