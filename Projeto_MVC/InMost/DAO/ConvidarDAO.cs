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
        private object sqlDbType;

        public object SqlAdapter { get; private set; }

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

    }
}
