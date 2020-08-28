using ProvaSoftDesign.Models.Entity;
using System.ComponentModel;

namespace ProvaSoftDesign.ViewModel
{
    public class LivroVM : BaseVM
    {
        public static LivroVM ConverteLivro(Livro livro)
        {
            var livroVM = new LivroVM();
            livroVM.Id = livro.Id;

            livroVM.NomeLivro = livro.NomeLivro;

            livroVM.AutorLivro = livro.AutorLivro;

            livroVM.DataLancamento = livro.DataLancamento.ToString("dd/MM/yyyy");

            livroVM.Alugado = livro.Alugado;

            livroVM.Ativo = livro.Ativo;

            return livroVM;
        }

        [DisplayName("Codigo")]
        public int Id { get; set; }

        [DisplayName("Nome")]
        public string NomeLivro { get; set; }

        [DisplayName("Autor")]
        public string AutorLivro { get; set; }

        [DisplayName("Data de Lançamento")]
        public string DataLancamento { get; set; }

        [DisplayName("Alugado")]
        public bool Alugado { get; set; }

        [DisplayName("Ativo")]
        public bool Ativo { get; set; }
    }
}