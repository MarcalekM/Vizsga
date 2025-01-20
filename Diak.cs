using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vizsga
{
    class Diak
    {
        public string Nev { get; set; }
        public float HalozatIrasbeli { get; set; }
        public float ProgramozasIrasbeli { get; set; }
        public float HalozatA {  get; set; }
        public float HalozatB { get; set; }
        public float HalozatC { get; set; }
        public float HalozatD { get; set; }
        public float AngolSzobeli { get; set; }
        public float ITSzobeli { get; set; }
        public float Eredmeny => (HalozatIrasbeli + ProgramozasIrasbeli + HalozatA + HalozatB + HalozatC + HalozatD + AngolSzobeli + ITSzobeli) / 8;

        public string Erdemjegy(float eredmeny)
        {
            if (eredmeny < 0.51) return "Elégtelen";
            else if (eredmeny < 0.61) return "Elégséges";
            else if (eredmeny < 0.71) return "Közepes";
            else if (eredmeny < 0.81) return "Jó";
            else return "Jeles";
        }

        public Diak(string sor)
        {
            string[] adatok = sor.Split(';');
            Nev = adatok[0];
            HalozatIrasbeli = float.Parse(adatok[1]);
            ProgramozasIrasbeli = float.Parse(adatok[2]);
            HalozatA = float.Parse(adatok[3]);
            HalozatB = float.Parse(adatok[4]);
            HalozatC = float.Parse(adatok[5]);
            HalozatD = float.Parse(adatok[6]);
            AngolSzobeli = float.Parse(adatok[7]);
            ITSzobeli = float.Parse(adatok[8]);
        }
    }
}
