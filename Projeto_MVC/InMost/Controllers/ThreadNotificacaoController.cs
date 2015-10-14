using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace InMost.Controllers
{
    public class ThreadNotificacaoController : Controller
    {

        public static Thread threadNotificacao { get; set; }

        public void IniciarThread()
        {
            ThreadNotificacaoController.threadNotificacao = new Thread(new ThreadStart(AtualizarNotificacoes));
            ThreadNotificacaoController.threadNotificacao.Start();
        }

        private void AtualizarNotificacoes()
        {

        }
    }
}