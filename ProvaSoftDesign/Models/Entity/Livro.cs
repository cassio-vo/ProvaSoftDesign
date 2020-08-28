using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProvaSoftDesign.Models.Entity
{
    [Table("Livro")]
    public class Livro
    {
        public int Id { get; set; }

        public string NomeLivro { get; set; }

        public string AutorLivro { get; set; }

        public DateTime DataLancamento { get; set; }

        public bool Alugado { get; set; }

        public bool Ativo { get; set; }
    }
}