using ControlProduct.Business.Interfaces;
using ControlProduct.Business.Models;
using ControlProduct.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace ControlProduct.Data.Repository
{
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(DataContext context) : base(context)
        {
        }

        public async Task<Endereco> ObterEnderecoPorFornecedor(Guid fornecedorId)
        {
            return await _context.Enderecos
                     .AsNoTracking()
                     .FirstOrDefaultAsync(f => f.FornecedorId == fornecedorId);
        }
    }
}
