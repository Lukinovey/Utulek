using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtulekProZvirata
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var evidence = new Evidence();
            var ui = new KonzoleUI(evidence);
            ui.Spustit();
        }
    }
}
