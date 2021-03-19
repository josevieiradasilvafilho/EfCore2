    using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EfCore.Model
{
    public class Cedente
    {
        [Key,Required]
        public Guid Id { get; set; }

        [Required,Column(TypeName = "varchar(30)")]
        public string Carteira { get; set; }

        [Required,Column(TypeName = "varchar(20)")]
        public string Contrato { get; set; }

        [Required,Column(TypeName = "varchar(200)")]
        public string NomeConta { get; set; }

        [Required,Column(TypeName = "varchar(20)")]
        public string Agencia { get; set; }

        [Required,Column(TypeName = "char(1)")]
        public char DigitoVerificador { get; set; }

        [Column(TypeName = "varchar(200)")]
        public string Instituicao { get; set; }

        /*
         * Relacionamentos
         */
        public ICollection<Boleto> Boleto { get; set; }
    }
}
