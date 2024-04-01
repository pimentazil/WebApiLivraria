using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiLivraria.Application.Model
{
    public class LivroRequest
    {
        public string titulo { get; set; }
        public string autor { get; set; }
        public string genero { get; set; }
        public decimal preco { get; set; }
        public int quantidade { get; set; }
    }
}
