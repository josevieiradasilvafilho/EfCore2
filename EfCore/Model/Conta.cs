using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EfCore.Model
{
    public class Conta
    {
        [Key,Required]
        public Guid Id  { get; set; }

        [Required,DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity),Column(TypeName = "varchar(300)")]
        public string Login { get; set; }

        [Required,Column(TypeName = "varchar(Max)")]
        public string Senha { get; set; }

        public Boolean IsBloqueado { get; set; }

        public Boolean AlterarSenha { get; set; }

        [Required]
        public Guid PessoaId { get; set; }
        public Pessoa Pessoas { get; set; }

        public ICollection<PermissaoConta> PermissaoConta { get; set; }

    }
}
