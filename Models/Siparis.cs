using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFAHamburgerci.Models
{
    public class Siparis
    {
        public Siparis()
        {
            ExtraMalzemeleri = new List<ExtraMalzeme>();
        }

        public Hamburger SeciliHamburger { get; set; }
        public Boyut SeciliBoyut { get; set; }
        public List<ExtraMalzeme> ExtraMalzemeleri { get; set; }
        public int Adet { get; set; }
        public decimal ToplamTutar { get; set; }

        public void TutarHesapla()
        {
            ToplamTutar = 0;

            ToplamTutar += SeciliHamburger.Fiyati;

            switch (SeciliBoyut)
            {
                case Boyut.Kucuk:
                    break;
                case Boyut.Orta:
                    ToplamTutar += 1.05m;
                    break;
                case Boyut.Buyuk:
                    ToplamTutar *= 1.10m;
                    break;
            }

            foreach (ExtraMalzeme item in ExtraMalzemeleri)
            {
                ToplamTutar += item.Fiyati;
            }

            ToplamTutar *= Adet;
        }

        public override string ToString()
        {
            //Steakhouse Menu, Orta Boy, (......., ...., ....), x2 Adet, Tutar:25TL
            if (ExtraMalzemeleri.Count < 1)
            {
                return $"{SeciliHamburger.Adi} Menu, {SeciliBoyut} Boyut, x{Adet} Adet, Tutar : {ToplamTutar.ToString("C2")}";
            }
            else
            {
                string exMalzemeler = null;
                foreach (ExtraMalzeme item in ExtraMalzemeleri)
                {
                    exMalzemeler += item.Adi + ",";
                }
                exMalzemeler = exMalzemeler.TrimEnd(',');

                return $"{SeciliHamburger.Adi} Menu, {SeciliBoyut} Boyut, ({exMalzemeler}), x{Adet} Adet, Tutar : {ToplamTutar.ToString("C2")}";
            }
        }
    }
}
