using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ControlProduct.Business.Models
{
    public class Fornecedor : Entity
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O Campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(14, ErrorMessage = "O Campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 11)]
        public string Documento { get; set; }

        public TipoFornecedor TipoFornecedor { get; set; }
        public Endereco Endereco { get; set; }

        public bool Ativo { get; set; } = true;
        public IEnumerable<Produto> Produtos { get; set; }
    }
}
