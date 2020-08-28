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
    public class UsuarioTeste
    {
        [TestMethod]
        public void LoginNok()
        {
            IQueryable<Usuario> UsuariosLista = new List<Usuario> { new Usuario() { Id = 1, Login = "admin", Senha = "admin" } }.AsQueryable<Usuario>();

            var mockSet = new Mock<DbSet<Usuario>>();
            mockSet.As<IQueryable<Usuario>>().Setup(s => s.Provider).Returns(UsuariosLista.Provider);
            mockSet.As<IQueryable<Usuario>>().Setup(s => s.Expression).Returns(UsuariosLista.Expression);
            mockSet.As<IQueryable<Usuario>>().Setup(s => s.ElementType).Returns(UsuariosLista.ElementType);
            mockSet.As<IQueryable<Usuario>>().Setup(s => s.GetEnumerator()).Returns(UsuariosLista.GetEnumerator());


            var mockContexto = new Mock<ProvaContext>();
            mockContexto.Setup(s => s.Usuario).Returns(mockSet.Object);

            UsuarioNegocio usuarioNegocio = new UsuarioNegocio(mockContexto.Object);

            bool valido = usuarioNegocio.ValidaUsuarioSenha("admin","teste");

            Assert.IsFalse(valido);
        }        
    }
}
