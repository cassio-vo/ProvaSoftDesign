using ProvaSoftDesign.Models;
using ProvaSoftDesign.Models.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using ProvaSoftDesign.ViewModel;

namespace ProvaSoftDesign.Negocio
{
    public class LivroNegocio
    {
        private ProvaContext contexto;

        public LivroNegocio()
        {
            contexto = new ProvaContext();
        }

        public LivroNegocio(ProvaContext context)
        {
            contexto = context;
        }

        public List<LivroVM> RetornaListaLivros()
        {
            return contexto.Livros.Select(x=>x).ToList().Select(x=> LivroVM.ConverteLivro(x)).ToList();
        }

        public List<LivroVM> RetornaListaLivrosPeloNome(string titulo)
        {
            //Utiliação sem where para melhorar a performance do sql no banco de dados.
            if (string.IsNullOrEmpty(titulo))
                return RetornaListaLivros();
            else
                return contexto.Livros.Where(x => x.NomeLivro.Contains(titulo)).ToList().Select(x => LivroVM.ConverteLivro(x)).ToList();
        }

        public LivroVM RetornaLivro(int id)
        {
            var livro = contexto.Livros.FirstOrDefault(x => x.Id == id);

            if (livro == null)
                return null;
            else
                return LivroVM.ConverteLivro(livro);
        }

        public bool AlugaLivro(int id)
        {
            var livro = contexto.Livros.FirstOrDefault(x => x.Id == id);

            if (livro == null)
                return false;

            if (livro.Alugado)
                return false;

            livro.Alugado = true;

            contexto.Entry(livro).State = EntityState.Modified;
            contexto.SaveChanges();

            return true;
        }
    }
}