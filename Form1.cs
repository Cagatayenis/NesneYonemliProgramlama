using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFAHamburgerci.Models;

namespace WFAHamburgerci
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<Hamburger> menuler = new List<Hamburger>() {
            new Hamburger() { Adi = "Steakhouse", Fiyati = 21 },
            new Hamburger() { Adi = "Texas Smokehouse", Fiyati = 23 },
            new Hamburger() { Adi = "Big King", Fiyati = 18 },
            new Hamburger() { Adi = "Whooper", Fiyati = 14 },
            new Hamburger() { Adi = "King Chicken", Fiyati = 11 },
            new Hamburger() { Adi = "Mc Fish", Fiyati = 11.25m }
        };

        private void Form1_Load(object sender, EventArgs e)
        {
            //cbMenuler.Items.AddRange(menuler.ToArray());

            foreach (Hamburger item in menuler)
            {
                cbMenuler.Items.Add(item);
            }

            cbMenuler.SelectedIndex = 0;
        }

        private void btnSiparisEkle_Click(object sender, EventArgs e)
        {
            Siparis s = new Siparis();
            s.SeciliHamburger = (Hamburger)cbMenuler.SelectedItem;

            #region Boyut Seçimi
            if (rbKucuk.Checked) s.SeciliBoyut = Boyut.Kucuk;
            else if (rbOrta.Checked) s.SeciliBoyut = Boyut.Orta;
            else if (rbBuyuk.Checked) s.SeciliBoyut = Boyut.Buyuk;
            else
            {
                MessageBox.Show("Lütfen boyut seçimi yapın.");
                return;
            }
            #endregion
            
            foreach (CheckBox item in grpExtraMalzemeler.Controls)
            {
                if (item.Checked)
                {
                    ExtraMalzeme ex = new ExtraMalzeme();
                    ex.Adi = item.Text;
                    ex.Fiyati = Convert.ToDecimal(item.Tag);

                    s.ExtraMalzemeleri.Add(ex);
                }
            }

            s.Adet = Convert.ToInt32(nmrAdet.Value);

            s.TutarHesapla();
            lstSiparisler.Items.Add(s);
        }

        private void btnTutarHesapla_Click(object sender, EventArgs e)
        {
            decimal toplamTutar = 0;
            foreach (Siparis item in lstSiparisler.Items)
            {
                toplamTutar += item.ToplamTutar;
            }

            MessageBox.Show($"Siparişiniz başarıyla tamamlanmıştır. Toplam tutarınız : {toplamTutar.ToString("C2")}");

            lstSiparisler.Items.Clear();
        }
    }
}
