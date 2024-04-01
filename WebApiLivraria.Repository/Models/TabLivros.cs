using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiLivraria.Repository.Models
{
    public class TabLivros
    {

        public int id { get; set; }
        public string titulo { get; set; }
        public string autor { get; set; }
        public string genero { get; set; }
        public decimal preco { get; set; }
        public int quantidade { get; set; }

    }
}
