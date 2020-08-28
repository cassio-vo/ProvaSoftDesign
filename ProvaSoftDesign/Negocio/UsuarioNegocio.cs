using ProvaSoftDesign.Models;
using System.Linq;

namespace ProvaSoftDesign.Negocio
{
    public class UsuarioNegocio
    {
        private ProvaContext contexto;

        public UsuarioNegocio()
        {
            contexto = new ProvaContext();
        }

        public UsuarioNegocio(ProvaContext context)
        {
            contexto = context;
        }

        public bool ValidaUsuarioSenha(string usuario, string senha)
        {
            return contexto.Usuario.Any(x => x.Login.Equals(usuario) &&
                                             x.Senha.Equals(senha));
        }
    }
}