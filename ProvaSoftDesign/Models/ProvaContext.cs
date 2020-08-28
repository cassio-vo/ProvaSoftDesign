using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProvaSoftDesign.Models
{
    public class ProvaContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public ProvaContext() : base("name=ProvaContext")
        {
        }

        public virtual System.Data.Entity.DbSet<ProvaSoftDesign.Models.Entity.Livro> Livros { get; set; }

        public virtual System.Data.Entity.DbSet<ProvaSoftDesign.Models.Entity.Usuario> Usuario { get; set; }
    }
}
