using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFAHamburgerci.Models
{
    public class Hamburger : Malzeme
    {
        public string Aciklama { get; set; }

        public override string ToString()
        {
            return $"{Adi} Menu";
        }
    }
}
