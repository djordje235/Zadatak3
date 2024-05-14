using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadatak3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Restoran restoran = new Restoran("Prvi restoran");

            restoran.Dodajstavku(new Jelo("Piletina sa povrćem", DateTime.Now.AddDays(5), false, 300, Kvalitet.Odlican));
            restoran.Dodajstavku(new Jelo("Pohovani škampi", DateTime.Now.AddDays(2), false, 500, Kvalitet.Dobar));
            restoran.Dodajstavku(new Jelo("Rižoto sa pečurkama", DateTime.Now.AddDays(4), true, 250, Kvalitet.Prihvatljiv));
            restoran.Dodajstavku(new Jelo("Pasta Carbonara", DateTime.Now.AddDays(1), false, 400, Kvalitet.Odlican));
            restoran.Dodajstavku(new Pice("Vino", DateTime.Now.AddMonths(6), true, 1, 800, Vrsta.domace));
            restoran.Dodajstavku(new Pice("Pivo", DateTime.Now.AddYears(-1), true, 3, 200, Vrsta.uvozno));
            restoran.Dodajstavku(new Pice("Sok od pomorandže", DateTime.Now.AddDays(10), true, 1, 100, Vrsta.domace));
            restoran.Dodajstavku(new Pice("Kafa", DateTime.Now.AddDays(30), true, 2, 1500, Vrsta.uvozno));

            restoran.upis("podaci.bin");
            
            Restoran novirestoran = new Restoran("Drugi restoran");
            novirestoran.citanje("podaci.bin");
            novirestoran.print();
            novirestoran.Izbaci();
            Console.WriteLine(" ");
            novirestoran.print();
            novirestoran.Sortirajpoceni();
            Console.WriteLine(" ");
            restoran.print();
            try
            {
                novirestoran.Proveriveganski();
                Console.WriteLine("Ima veganske stavke");
            }
            catch (VeganUnfriendly ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}
