using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EfCore.Model
{
    public class Competencia
    {
        [Key]
        [Required]
        public Guid CompetenciaId { get; set; }

        [Required]
        public int Ano { get; set; }

        [Required]
        public int Mes { get; set; }

        /*
         * Relacionamentos
         */
        public ICollection<VendaProdutoCompetencia> VendaProdutoCompetencias { get; set; }
        public ICollection<Boleto> Boleto { get; set; }

    }
}
