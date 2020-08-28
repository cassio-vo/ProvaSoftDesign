using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProvaSoftDesign.Models;
using ProvaSoftDesign.Models.Entity;
using ProvaSoftDesign.Negocio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteTdd
{
    [TestClass]
    public class LivroTeste
    {
        [TestMethod]
        public void AlugaLivroNok()
        {
            IQueryable<Livro> livrosLista = new List<Livro> { new Livro() { Id = 1, Alugado = true, Ativo = true, AutorLivro = "Eu", DataLancamento = DateTime.Now, NomeLivro = "Livro do lobo" } }.AsQueryable<Livro>();

            var mockSet = new Mock<DbSet<Livro>>();
            mockSet.As<IQueryable<Livro>>().Setup(s => s.Provider).Returns(livrosLista.Provider);
            mockSet.As<IQueryable<Livro>>().Setup(s => s.Expression).Returns(livrosLista.Expression);
            mockSet.As<IQueryable<Livro>>().Setup(s => s.ElementType).Returns(livrosLista.ElementType);
            mockSet.As<IQueryable<Livro>>().Setup(s => s.GetEnumerator()).Returns(livrosLista.GetEnumerator());


            var mockContexto = new Mock<ProvaContext>();
            mockContexto.Setup(s => s.Livros).Returns(mockSet.Object);

            LivroNegocio livroNegocio = new LivroNegocio(mockContexto.Object);

            bool alugou = livroNegocio.AlugaLivro(1);

            Assert.IsFalse(alugou);
        }        
    }
}
