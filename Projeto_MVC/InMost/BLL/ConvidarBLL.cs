using InMost.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace InMost.BLL
{
    class ConvidarBLL
    {

        private readonly Random rnd = new Random();
        private const string caracteres = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        private string GerarSenha(int qtdCaracteres)
        {
            char[] aux = new char[qtdCaracteres];
            for(int i = 0; i < qtdCaracteres; i++)
            {
                aux[i] = caracteres[rnd.Next(caracteres.Length)];
            }
            return new string(aux);
        }

        /// <summary>
        /// Envia email
        /// </summary>
        /// <param name="destinatario">pessoa que recebera o email</param>
        /// <returns>validações no mail, string vazia = sucesso</returns>
        public int EnviarMail(string destinatario)
        {
            try
            {
                int validacao = ValidarDestinatario(destinatario);
                if (validacao != (int)Mensagens.Ok)
                    return validacao;
                
                ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate,X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
                MailMessage msgEmail = new MailMessage("xamarin5@lobu.com.br", destinatario, "Convite Beta InMost", CarregarCorpoEmail(destinatario));
                SmtpClient smtp = new SmtpClient("smtp.lobu.com.br", 587);
                NetworkCredential credencial = new NetworkCredential("xamarin5@lobu.com.br", "lobu2015");
                smtp.Credentials = credencial;
                smtp.Port = 587;
                smtp.Send(msgEmail);

                return validacao;
            }
            catch (Exception e)
            {
                
            }

            return (int)Mensagens.UsuarioExistente;
        }

        private string CarregarCorpoEmail(string destinatario)
        {
            //criar html de mail
            return "Bem vindo caro, vc foi convidado para rede social privada BAE Inmost \r\n seu login é " + destinatario + " sua senha é: " + GerarSenha(10);
        }

        private int ValidarDestinatario(string destinatario)
        {
            if (string.IsNullOrEmpty(destinatario))
                return  (int)Mensagens.CampoObrigatorio; //"O campo email é de preenchimento obrigatorio";

            if (destinatario.Contains("@") && destinatario.Contains("."))
            {
                ConvidarDAO  DAO = new ConvidarDAO();
                if (DAO.BuscarEmail(destinatario).Rows.Count > 0)
                    return (int)Mensagens.UsuarioExistente;
                else
                    return (int)Mensagens.Ok;
            }
            else
                return (int)Mensagens.CampoObrigatorio;
        }
    }
}


public enum Mensagens
{
    Ok,
    CampoObrigatorio,
    UsuarioExistente,
    EmailInvalido
}