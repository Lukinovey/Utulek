using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtulekProZvirata
{
    internal class Evidence
    {
        public List<Zvire> Zvirata { get; set; }

        public Evidence()
        {
            Zvirata = new List<Zvire>();

            Zvirata.Add(new Zvire
            {
                Jmeno = "Azor",
                Druh = "Pes",
                Vek = 3,
                Pohlavi = "Samec"
            });

            Zvirata.Add(new Zvire
            {
                Jmeno = "Micka",
                Druh = "Kočka",
                Vek = 2,
                Pohlavi = "Samice"
            });
        }

        public void Pridat(Zvire zvire)
        {
            Zvirata.Add(zvire);
        }

        public List<Zvire> Vsechny()
        {
            return Zvirata;
        }

        public Zvire NajdiPodleId(int id)
        {
            return Zvirata.FirstOrDefault(z => z.ID == id);
        }

        public List<Zvire> Filtrovat(string druh, int? vekOd, int? vekDo, string jmeno)
        {
            return Zvirata.Where(z =>
                (string.IsNullOrEmpty(druh) || z.Druh.ToLower() == druh.ToLower()) &&
                (!vekOd.HasValue || z.Vek >= vekOd.Value) &&
                (!vekDo.HasValue || z.Vek <= vekDo.Value) &&
                (string.IsNullOrEmpty(jmeno) || z.Jmeno.ToLower().Contains(jmeno.ToLower()))
            ).ToList();
        }

        public bool OznacitAdopci(int id)
        {
            Zvire zvire = NajdiPodleId(id);
            if (zvire == null || zvire.Adoptovano)
                return false;

            zvire.Adoptovano = true;
            zvire.DatumAdopce = DateTime.Now;
            return true;
        }

        public int PocetAdoptovanych()
        {
            return Zvirata.Count(z => z.Adoptovano);
        }

        public double PrumernyVek()
        {
            if (Zvirata.Count == 0)
                return 0;

            return Zvirata.Average(z => z.Vek);
        }

        public Dictionary<string, int> PocetPodleDruhu()
        {
            return Zvirata
                .GroupBy(z => z.Druh)
                .ToDictionary(g => g.Key, g => g.Count());
        }

    }
}
