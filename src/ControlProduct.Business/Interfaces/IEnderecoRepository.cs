using ControlProduct.Business.Models;
using System;
using System.Threading.Tasks;

namespace ControlProduct.Business.Interfaces
{
    public interface IEnderecoRepository : IRepository<Endereco>
    {
        Task<Endereco> ObterEnderecoPorFornecedor(Guid fornecedorId);
    }
}
