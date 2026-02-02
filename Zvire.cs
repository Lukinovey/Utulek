using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtulekProZvirata
{
    internal class Zvire
    {
        private static int _idCounter = 1;

        public int ID { get; private set; }
        public string Jmeno { get; set; }
        public string Druh { get; set; }
        public int Vek { get; set; }
        public string Pohlavi { get; set; }
        public DateTime DatumPrijmu { get; set; }
        public string ZdravotniStav { get; set; }
        public string Poznamka { get; set; }
        public bool Adoptovano { get; set; }
        public DateTime? DatumAdopce { get; set; }

        public Zvire()
        {
            ID = _idCounter++;
            DatumPrijmu = DateTime.Now;
            Adoptovano = false;
        }
    }
}
