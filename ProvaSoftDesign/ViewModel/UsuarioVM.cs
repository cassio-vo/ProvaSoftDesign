using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProvaSoftDesign.ViewModel
{
    public class UsuarioVM : BaseVM
    {
        public int Id { get; set; }

        [DisplayName("Login")]
        [Required(ErrorMessage = "Precisa do login.")]
        public string Login { get; set; }

        [DisplayName("Senha")]
        [Required(ErrorMessage = "Precisa da senha.")]
        public string Senha { get; set; }
    }
}