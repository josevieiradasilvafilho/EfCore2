using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EfCore.Model
{
    public class Produto
    {

        [Key]
        public Guid Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(300)")]
        public string Nome { get; set; }

        [Column(TypeName = "varchar(Max)")]
        public string Descricao { get; set; }

        [Required]
        public int Quantidade { get; set; }
        public ICollection<VendaProdutoCompetencia> VendaProdutoCompetencias { get; set; }

    }
}
