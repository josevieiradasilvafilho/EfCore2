using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EfCore.Model
{
    public class PermissaoConta
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        
        [Required]
        public Guid ContaId { get; set; }

        [Required]
        public Boolean Read { get; set; }

        [Required]
        public Boolean Write { get; set; }

        [Required]
        public Boolean Execute { get; set; }

        /*
         * relacionamento
         */
        [Required]
        public Guid PermissaoId { get; set; }
        public Permissao Permissao { get; set; }
    }
}
