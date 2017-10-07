using Modelo.Cadastros;
using Modelo.Tabelas;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Contexts
{
    public class EFContext : DbContext
    {
        public EFContext() : base("DefaultConnection")
        {

        }
        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<Fabricante> Fabricante { get; set; }

        public DbSet<Produto> Produto { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "id")
                .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            base.OnModelCreating(modelBuilder);
        }
    }
}
