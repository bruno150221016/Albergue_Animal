using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Albergue_Animal.Models
{
    public class Animal
    {

        public int AnimalId { get; set; }

        public String Nome { get; set; }

        public String Raca { get; set; }

        public String Sexo { get; set; }

        public String Cor { get; set; }

        public DateTime DataEntrada { get; set; }

        public DateTime DataVacina { get; set; }

        [StringLength(255)]
        [Display(Name = "Fotografia")]
        public string Fotografia { get; set; }

    }
}
