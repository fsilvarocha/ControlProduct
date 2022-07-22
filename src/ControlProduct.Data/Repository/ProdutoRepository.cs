using ControlProduct.Business.Interfaces;
using ControlProduct.Business.Models;
using ControlProduct.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlProduct.Data.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(DataContext context) : base(context)
        {
        }

        public async Task<Produto> ObterProdutoFornecedor(Guid id)
        {
            return await _context.Produtos
                           .AsNoTracking()
                           .Include(f => f.Fornecedor)
                           .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Produto>> ObterprodutosFornecedores()
        {
            return await _context.Produtos
                           .AsNoTracking()
                           .Include(f => f.Fornecedor)
                           .OrderBy(p => p.Nome)
                           .ToListAsync();
        }

        public async Task<IEnumerable<Produto>> ObterProdutosPorFornecedor(Guid fornecedorId)
        {
            return await Buscar(p => p.FornecedorId == fornecedorId);
        }
    }
}
