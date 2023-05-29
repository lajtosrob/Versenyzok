using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Versenyzok.DATAS
{
    internal class Pilotak
    {
        string nev;
        DateTime szuletesiDatum;
        string nemzetiseg;
        string rajtszam;

        public Pilotak(string nev, DateTime szuletesiDatum, string nemzetiseg, string rajtszam)
        {
            this.nev = nev;
            this.szuletesiDatum = szuletesiDatum;
            this.nemzetiseg = nemzetiseg;
            this.rajtszam = rajtszam;
        }

        public string Nev { get => nev; }
        public DateTime SzuletesiDatum { get => szuletesiDatum; }
        public string Nemzetiseg { get => nemzetiseg; }
        public string Rajtszam { get => rajtszam; }
    }
}
