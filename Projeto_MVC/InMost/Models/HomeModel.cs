using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InMost.Models
{
    public class HomeModel
    {
        public string Email  { get; set; }
        public string Nome { get; set; }
        public string Apelido { get; set; }
        public string Url_foto { get; set; }

        public List<Membros> membros { get; set; }

    }
}
