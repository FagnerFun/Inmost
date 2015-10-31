using InMost.Entity;
using InMost.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InMost.DAO
{
    class LoginDAO : Connection
    {
        public object SqlAdapter { get; private set; }

        public DataTable EfetuaLogin(LoginEntity entity)
        {
            try
            {
                CriarConexao();
                Abrir();
                SqlDataAdapter Cmd = new SqlDataAdapter("BuscaLogin",con);

                Cmd.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;

                Cmd.SelectCommand.Parameters.Add("@USUARIO", SqlDbType.VarChar).Value = entity.Email;
                Cmd.SelectCommand.Parameters.Add("@SENHA", SqlDbType.VarChar).Value = entity.Senha;

                DataTable data = new DataTable();

                Cmd.Fill(data);

                return data;

            }
            catch(Exception e)
            {

            }



            return null;
        }

    }
}
