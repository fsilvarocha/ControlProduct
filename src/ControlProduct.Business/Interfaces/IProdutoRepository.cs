using ControlProduct.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControlProduct.Business.Interfaces
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Task<IEnumerable<Produto>> ObterProdutosPorFornecedor(Guid fornecedorId);
        Task<IEnumerable<Produto>> ObterprodutosFornecedores();
        Task<Produto> ObterProdutoFornecedor(Guid id);
    }
}
