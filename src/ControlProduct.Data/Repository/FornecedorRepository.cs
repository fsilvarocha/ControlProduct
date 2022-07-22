using ControlProduct.Business.Interfaces;
using ControlProduct.Business.Models;
using ControlProduct.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace ControlProduct.Data.Repository
{
    public class FornecedorRepository : Repository<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(DataContext context) : base(context)
        {
        }

        public async Task<Fornecedor> ObterFornecedorEndereco(Guid id)
        {
            return await _context.Fornecedores
                .AsNoTracking()
                .Include(e => e.Endereco)
                .FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<Fornecedor> ObterFornecedorProdutosEndereco(Guid id)
        {
            return await _context.Fornecedores
                .AsNoTracking()
                .Include(e => e.Endereco)
                .Include(p => p.Produtos)
                .FirstOrDefaultAsync(f => f.Id == id);
        }
    }
}
