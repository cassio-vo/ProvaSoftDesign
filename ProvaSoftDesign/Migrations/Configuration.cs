namespace ProvaSoftDesign.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ProvaSoftDesign.Models.ProvaContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ProvaSoftDesign.Models.ProvaContext context)
        {
            context.Usuario.AddOrUpdate(
                new Models.Entity.Usuario
                {
                    Login = "admin",
                    Senha = "admin"
                },
                new Models.Entity.Usuario
                {
                    Login = "fulano",
                    Senha = "12345"
                }
            );

            context.Livros.AddOrUpdate(
                new Models.Entity.Livro
                {
                    NomeLivro = "Sitio do pica pau amarelo",
                    AutorLivro = "Monteiro Lobato",
                    Alugado = true,
                    DataLancamento = DateTime.Now,
                    Ativo = true,
                },
                new Models.Entity.Livro
                {
                    NomeLivro = "O Tempo e o Vento",
                    AutorLivro = "Erico Verissimo",
                    Alugado = false,
                    DataLancamento = DateTime.Now,
                    Ativo = true,
                },
                new Models.Entity.Livro
                {
                    NomeLivro = "O Tempo e o Vento",
                    AutorLivro = "Erico Verissimo",
                    Alugado = false,
                    DataLancamento = DateTime.Now,
                    Ativo = true,
                },
                new Models.Entity.Livro
                {
                    NomeLivro = "Memórias Póstumas de Bbrás Cubas",
                    AutorLivro = "Machado de Assis",
                    Alugado = false,
                    DataLancamento = DateTime.Now,
                    Ativo = true,
                }
            );
        }
    }
}
