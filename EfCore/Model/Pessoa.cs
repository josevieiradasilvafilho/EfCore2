using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfCore.Model
{
    public class Pessoa
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(300)")]
        public string Nome { get; set; }

        [Required,DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity), Column(TypeName = "varchar(22)")]
        public string Documento { get; set; }

        [Required,DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity), Column(TypeName = "varchar(300)")]
        public string Email { get; set; }

        [Column(TypeName = "varchar(15)")]
        public string Telefone { get; set; }

        /*
         * Relacionamento
         */
        public ICollection<Conta> Contas { get; set; }
        public ICollection<Boleto> Boleto { get; set; }
    }
}
