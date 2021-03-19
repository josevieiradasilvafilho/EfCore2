using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EfCore.Model
{
    public class Venda
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        [Column(TypeName = "decimal(37, 2)")]
        public decimal Valor { get; set; }

        public ICollection<VendaProdutoCompetencia> VendaProdutoCompetencias { get; set; }
    }

}
