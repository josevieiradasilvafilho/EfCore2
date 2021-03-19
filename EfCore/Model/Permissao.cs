using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EfCore.Model
{
    public class Permissao
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required, DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity), Column(TypeName = "varchar(300)")]
        public string Nome { get; set; }

        public ICollection<PermissaoConta> PermissaoConta { get; set; }
    }
}
