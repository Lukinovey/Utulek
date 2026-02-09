using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtulekProZvirata
{
    internal class KonzoleUI
    {
        private Evidence _evidence;

        public KonzoleUI(Evidence evidence)
        {
            _evidence = evidence;
        }

        public void Spustit()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("===== ÚTULEK PRO ZVÍŘATA =====");
                Console.WriteLine("1) Přidat zvíře");
                Console.WriteLine("2) Vypsat všechna zvířata");
                Console.WriteLine("3) Vyhledat / filtrovat");
                Console.WriteLine("4) Označit adopci");
                Console.WriteLine("5) Statistiky");
                Console.WriteLine("0) Konec");
                Console.Write("Volba: ");

                string volba = Console.ReadLine();

                switch (volba)
                {
                    case "1":
                        PridatZvire();
                        break;
                    case "2":
                        Vypsat(_evidence.Vsechny());
                        break;
                    case "3":
                        Filtrovat();
                        break;
                    case "4":
                        Adopce();
                        break;
                    case "5":
                        Statistiky();
                        break;
                    case "0":
                        return;
                }

                Console.WriteLine("\nStiskni libovolnou klávesu...");
                Console.ReadKey();
            }
        }

        private void PridatZvire()
        {
            Zvire z = new Zvire();

            Console.Write("Jméno: ");
            z.Jmeno = Console.ReadLine();

            Console.Write("Druh: ");
            z.Druh = Console.ReadLine();

            Console.Write("Věk: ");
            int vek;
            while (!int.TryParse(Console.ReadLine(), out vek) || vek < 0)
            {
                Console.Write("Zadej platný věk: ");
            }
            z.Vek = vek;

            Console.Write("Pohlaví: ");
            z.Pohlavi = Console.ReadLine();

            Console.Write("Zdravotní stav (nepovinné): ");
            z.ZdravotniStav = Console.ReadLine();

            Console.Write("Poznámka (nepovinné): ");
            z.Poznamka = Console.ReadLine();

            _evidence.Pridat(z);
        }

        private void Vypsat(List<Zvire> seznam)
        {
            Console.WriteLine("ID | Jméno | Druh | Věk | Adoptováno");
            foreach (Zvire z in seznam)
            {
                Console.WriteLine(
                    z.ID + " | " +
                    z.Jmeno + " | " +
                    z.Druh + " | " +
                    z.Vek + " | " +
                    (z.Adoptovano ? "Ano" : "Ne")
                );
            }
        }

        private void Filtrovat()
        {
            Console.Write("Druh (Enter = vše): ");
            string druh = Console.ReadLine();

            Console.Write("Věk od (Enter = bez omezení): ");
            int? vekOd = null;
            int v1;
            if (int.TryParse(Console.ReadLine(), out v1))
                vekOd = v1;

            Console.Write("Věk do (Enter = bez omezení): ");
            int? vekDo = null;
            int v2;
            if (int.TryParse(Console.ReadLine(), out v2))
                vekDo = v2;

            Console.Write("Jméno (Enter = vše): ");
            string jmeno = Console.ReadLine();

            Vypsat(_evidence.Filtrovat(druh, vekOd, vekDo, jmeno));
        }

        private void Adopce()
        {
            Console.Write("Zadej ID zvířete: ");
            int id;
            if (int.TryParse(Console.ReadLine(), out id))
            {
                if (!_evidence.OznacitAdopci(id))
                    Console.WriteLine("Adopci nelze provést.");
            }
        }

        private void Statistiky()
        {
            Console.WriteLine("Počet zvířat: " + _evidence.Vsechny().Count);
            Console.WriteLine("Adoptováno: " + _evidence.PocetAdoptovanych());
            Console.WriteLine("Průměrný věk: " + _evidence.PrumernyVek());

            foreach (var item in _evidence.PocetPodleDruhu())
            {
                Console.WriteLine(item.Key + ": " + item.Value);
            }
        }
    }
}
