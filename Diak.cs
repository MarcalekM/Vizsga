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
        public float Vegeredmeny => (HalozatIrasbeli + ProgramozasIrasbeli + HalozatA + HalozatB + HalozatC + HalozatD + AngolSzobeli + ITSzobeli) / 8;

        public string Erdemjegy()
        {
            if (HalozatIrasbeli <= 0.5 || ProgramozasIrasbeli <= 0.5 || HalozatA <= 0.5 || HalozatB <= 0.5 || HalozatC <= 0.5 || HalozatD <= 0.5 || AngolSzobeli <= 0.5 || ITSzobeli <= 0.5) return "Elégtelen";
            else if (Vegeredmeny < 0.61 && Vegeredmeny >= 0.51) return "Elégséges";
            else if (Vegeredmeny < 0.71 && Vegeredmeny >= 0.61) return "Közepes";
            else if (Vegeredmeny < 0.81 && Vegeredmeny >= 0.71) return "Jó";
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
