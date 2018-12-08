using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Albergue_Animal.Models
{
    public class Animal
    {
        [Display(Name = "ID")]
        public int AnimalId { get; set; }

        public String Nome { get; set; }

        [Display(Name = "Raça")]
        public String Raca { get; set; }

        [Display(Name = "Género")]
        public String Sexo { get; set; }

        public String Cor { get; set; }

        [Display(Name = "Data Entrada")]
        public DateTime DataEntrada { get; set; }

        [Display(Name = "Data Vacina")]
        public DateTime DataVacina { get; set; }

        [StringLength(255)]
        [Display(Name = "Fotografia")]
        public string Fotografia { get; set; }

    }
}
