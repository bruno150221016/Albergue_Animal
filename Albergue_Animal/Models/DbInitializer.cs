using Albergue_Animal.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Albergue_Animal.Models
{
    public class DbInitializer
    {
        public static async Task Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();
            if (!context.Animal.Any())
            {
                // Adicionar Marcas para testes
                context.Animal.Add(new Animal { Nome = "Cao1", Raca="Raca1", Sexo="Masculino", Cor="Preto",DataEntrada= new DateTime(1998, 04, 30), DataVacina= new DateTime(1998, 04, 30),Fotografia ="pic1"  });
             //   context.Marca.Add(new Marca { Designacao = "Konnizegg aguera" });-
              //  context.Marca.Add(new Marca { Designacao = "Porche" });
              //  context.Marca.Add(new Marca { Designacao = "BMW" });

                context.SaveChanges();
            }
           
        }
    }
}
