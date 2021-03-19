using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EfCore.Model
{
    public class VendaProdutoCompetencia
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        public DateTime DataVenda { get; set; }

        [Required]
        public int QuantidadeVendida { get; set; }

        /*
        * Relacionamento 1 para muitos
        * */
        [Required]
        public Guid VendaId { get; set; }
        public Venda Vendas { get; set; }

        [Required]
        public Guid ProdutoId { get; set; }
        public Produto Produtos { get; set; }

        [Required]
        public Guid CompetenciaId { get; set; }
        public Competencia Competencias { get; set; }
    }
}
