using InMost.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InMost.DAO
{
    class HomeDAO : Connection
    {

        public DataTable CarregaPerfil(HomeEntity entity)
        {
            try
            {
                CriarConexao();
                Abrir();

                SqlDataAdapter Cmd = new SqlDataAdapter("CarregaPerfil", con);
                Cmd.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                Cmd.SelectCommand.Parameters.Add("@USUARIO", SqlDbType.VarChar).Value = entity.Email;
                DataTable data = new DataTable();
                Cmd.Fill(data);
          

                Fechar();

                return data;

            }
            catch (Exception e)
            {
            }
            finally
            {
                Fechar();
            }
            return null;
        }

        public DataTable CarregaLista(HomeEntity entity)
        {
            try
            {
                CriarConexao();
                Abrir();

                SqlDataAdapter Cmd = new SqlDataAdapter("BuscaListaCurtir", con);
                Cmd.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                Cmd.SelectCommand.Parameters.Add("@EMAIL", SqlDbType.VarChar).Value = entity.Email;
                DataTable lista = new DataTable();
                Cmd.Fill(lista);

                Fechar();

                return lista;

            }
            catch (Exception e)
            {
            }
            finally
            {
                Fechar();
            }
            return null;
        }




    }
}
