using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

/*
 * 
 * */

namespace EfCore.Model
{
    public class Boleto
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        //[UniqueKey(groupId: "1", order: 0)]
        [Column(TypeName = "bigint")]
        public int Numero { get; set; }

        [Required]
        public DateTime DataVencimento { get; set; }
        
        [Required]
        [Column(TypeName = "decimal(35, 2)")]
        public decimal Valor { get; set; }

        [Required]
        public DateTime DataEmissao { get; set; }

        [Required]
        [Column(TypeName = "varchar(10)")]
        public int Sequencial { get; set; }

        /*
         *Relacionamentos 
         */
        [Required]
        public Guid CedenteId { get; set; }
        public Cedente Cedente { get; set; }

        [Required]
        public Guid ClientId { get; set; }
        public Pessoa Pessoa { get; set; }

        [Required]
        public Guid CompetenciaId { get; set; }
        public Competencia Competencia { get; set; }

    }
}
