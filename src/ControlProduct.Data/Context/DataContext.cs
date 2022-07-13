using ControlProduct.Business.Models;
using Microsoft.EntityFrameworkCore;

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

    }
}
