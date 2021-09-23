using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleLinqTeste
{
    public class LinqTeste
    {
        public void Testar_SelectMany()
        {
            Console.WriteLine("LINQ SelectMany.......");

            List<Pessoa> listaPessoas = new List<Pessoa>() 
            { 
                new Pessoa { Codigo = 1, Nome = "Ryan", Frutas = new List<string> {"Maça", "Pera", "Morango" } },
                new Pessoa { Codigo = 2, Nome = "Cesar", Frutas = new List<string> {"Pessego", "Morango", "Pera" } }
            };

            var listaTodasFrutas = listaPessoas.SelectMany(x => x.Frutas);

            var listaFrutasComNome = listaPessoas
                .SelectMany(x => x.Frutas, (pessoa, fruta) => {
                    return new { pessoa.Nome, fruta };
                });

            Console.WriteLine("Lista frutas juntas.......");
            Console.WriteLine("----------------------------------------");
            foreach (var fruta in listaTodasFrutas)
            {
                Console.WriteLine(fruta);
            }

            Console.WriteLine("Lista frutas com nomes.......");
            Console.WriteLine("----------------------------------------");
            foreach (var fruta in listaFrutasComNome)
            {
                Console.WriteLine($"{fruta.Nome} - {fruta.fruta}");
            }

            Console.WriteLine("\nPress any key.......");
            Console.ReadKey();

        }
    }

    public class Pessoa
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public List<string> Frutas { get; set; }
    }

}
