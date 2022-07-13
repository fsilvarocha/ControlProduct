using ControlProduct.Business.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ControlProduct.Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //caso um campo varchar nao seja mapeado, é definido varchar(100) pra nao gerar nvarchar(max) no banco
            foreach (var property in modelBuilder.Model
                .GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                .Where(p => p.ClrType == typeof(string)))) property.SetColumnType("varchar(255)");

            //mapeia todas as entidades que estao declaradas no datacontext dbset<entidade
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);

            //desabilata o delete cascate e seta null
            foreach (var relationship in modelBuilder.Model
                .GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;


            base.OnModelCreating(modelBuilder);
        }
    }
}
