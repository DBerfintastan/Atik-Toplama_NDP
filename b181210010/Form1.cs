/****************************************************************************
**					SAKARYA ÜNİVERSİTESİ
**				BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ
**				    BİLGİSAYAR MÜHENDİSLİĞİ BÖLÜMÜ
**				   NESNEYE DAYALI PROGRAMLAMA DERSİ
**					2019-2020 BAHAR DÖNEMİ
**	
**				ÖDEV NUMARASI..........: 3
**				ÖĞRENCİ ADI............: Deniz Berfin Taştan
**				ÖĞRENCİ NUMARASI.......: B181210010
**              DERSİN ALINDIĞI GRUP...: 1-D
****************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace B181210010
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Buzdolabi buzdolabi = new Buzdolabi("Buzdolabi", "Vestel", "No Frost", "Çift Kapılı", 3500, Convert.ToInt32(BuzdolabiAdet.Value), 500, "A");
            Laptop laptop = new Laptop("Laptop", "Lenovo", "Ideapad", "i7", 6000, Convert.ToInt32(LaptopAdet.Value), 17, "HD", 256, 16, 100000);
            LedTv televizyon = new LedTv("Televizyon", "Samsung", "Ultra HD", "Plazma", 4000, Convert.ToInt32(TvAdet.Value), 25, "HD");
            CepTel telefon = new CepTel("Telefon", "Huawei", "P30", "Dokunmatik", 2500, Convert.ToInt32(TelefonAdet.Value), 64, 8, 3000);
            Sepet s1 = new Sepet();
            s1.StokAta(televizyon, buzdolabi, laptop, telefon);
            lblTvStok.Text = Convert.ToString(s1.Stoklar[0]);
            lblLaptopStok.Text = Convert.ToString(s1.Stoklar[2]);
            lblBuzdolabiStok.Text = Convert.ToString(s1.Stoklar[1]);
            lblTelStok.Text = Convert.ToString(s1.Stoklar[3]);

        }
        private void sepeteEkle_Click(object sender, EventArgs e)
        {
            listAdet.Items.Clear();
            listUrun.Items.Clear();
            listFiyat.Items.Clear();
            Sepet s1 = new Sepet();
            Buzdolabi buzdolabi = new Buzdolabi("Buzdolabi", "Vestel", "No Frost", "Çift Kapılı", 3500, Convert.ToInt32(BuzdolabiAdet.Value), 500, "A");
            Laptop laptop = new Laptop("Laptop", "Lenovo", "Ideapad", "i7", 6000, Convert.ToInt32(LaptopAdet.Value), 17, "HD", 256, 16, 100000);
            LedTv televizyon = new LedTv("Televizyon", "Samsung", "Ultra HD", "Plazma", 4000, Convert.ToInt32(TvAdet.Value), 25, "HD");
            CepTel telefon = new CepTel("Telefon", "Huawei", "P30", "Dokunmatik", 2500, Convert.ToInt32(TelefonAdet.Value), 64, 8, 3000); // Sınıflardan nesneler oluşturduk.
            s1.SepeteUrunEkle(buzdolabi, laptop, televizyon, telefon); //sepet sınıfından çektiğimiz parametreli ürün ekleme fonksiyonunu çağırdık.
            if (TvAdet.Value > 0)
            {
                listAdet.Items.Add(TvAdet.Value);
                listUrun.Items.Add("Televizyon");
            }
            if (BuzdolabiAdet.Value > 0)
            {
                listAdet.Items.Add(BuzdolabiAdet.Value);
                listUrun.Items.Add("Buzdolabı");
            }
            if (LaptopAdet.Value > 0)
            {
                listAdet.Items.Add(LaptopAdet.Value);
                listUrun.Items.Add("Laptop");
            }
            if (TelefonAdet.Value > 0)
            {
                listAdet.Items.Add(TelefonAdet.Value);
                listUrun.Items.Add("Telefon");
            } // eğer seçilen adetler 1den büyük ise seçilen ürünleri ve adetlerini yandaki listboxa yazdır.
            for (int i = 0; i < 4; i++)
            {
                if (s1.KdvliFiyat[i] > 0)
                    listFiyat.Items.Add(s1.KdvliFiyat[i]);
            } // oluşturduğumuz kdvli fiyat dizisinden ürünlerin kdvli fiyatları kdcli fiyat listbox'ına yaz.
            lblKdvFiyat.Text = Convert.ToString(s1.KdvliFiyat[0] + s1.KdvliFiyat[1] + s1.KdvliFiyat[2] + s1.KdvliFiyat[3]); // tüm ürünlerin toplam kdvli fiyatını hesapla

            lblTvStok.Text = Convert.ToString(Convert.ToInt32(lblTvStok.Text) - Convert.ToInt32(TvAdet.Value)); 
            lblBuzdolabiStok.Text = Convert.ToString(Convert.ToInt32(lblBuzdolabiStok.Text) - Convert.ToInt32(BuzdolabiAdet.Value));
            lblLaptopStok.Text = Convert.ToString(Convert.ToInt32(lblLaptopStok.Text) - Convert.ToInt32(LaptopAdet.Value));
            lblTelStok.Text = Convert.ToString(Convert.ToInt32(lblTelStok.Text) - Convert.ToInt32(TelefonAdet.Value)); // seçilen adetleri stok adedinden çıkar tekrar stok adedine yaz.
           

        }

        private void sepetTemizle_Click(object sender, EventArgs e)
        {
            listAdet.Items.Clear();
            listUrun.Items.Clear();
            listFiyat.Items.Clear();
            lblKdvFiyat.Text = " "; //Sepet temizlenince listeleri sil
            lblTvStok.Text = Convert.ToString(Convert.ToInt32(lblTvStok.Text) + Convert.ToInt32(TvAdet.Value));
            lblBuzdolabiStok.Text = Convert.ToString(Convert.ToInt32(lblBuzdolabiStok.Text) + Convert.ToInt32(BuzdolabiAdet.Value));
            lblLaptopStok.Text = Convert.ToString(Convert.ToInt32(lblLaptopStok.Text) + Convert.ToInt32(LaptopAdet.Value));
            lblTelStok.Text = Convert.ToString(Convert.ToInt32(lblTelStok.Text) + Convert.ToInt32(TelefonAdet.Value)); //Stoklara seçilen adetleri tekrar ekle.
        }

     }
    public class Sepet
    {
        public double[] KdvliFiyat = new double[4];
        public void SepeteUrunEkle(Buzdolabi b1, Laptop l1, LedTv t1, CepTel c1)
        {
            KdvliFiyat[0] = t1.KdvUygula();
            KdvliFiyat[1] = b1.KdvUygula();
            KdvliFiyat[2] = l1.KdvUygula();
            KdvliFiyat[3] = c1.KdvUygula(); //her ürün için ayrı ayrı kdvli fiyat hesapla ve bunu dizideki bir elemana aktar. (Yukarıda çağırmak için ihtiyacımız olacak.)
        }
        public int[] Stoklar = new int[4];
        public void StokAta(LedTv t, Buzdolabi b, Laptop l, CepTel c)
        {
            Random random = new Random();
            Stoklar[0] = random.Next(1, 100);
            Stoklar[1] = random.Next(1, 100);
            Stoklar[2] = random.Next(1, 100);
            Stoklar[3] = random.Next(1, 100); // her ürün için random bir değer ata ve bunu dizideki bir elemana aktar. (Yukarıda çağırmak için ihtiyacımız olacak.)
        }
    }
    public partial class Urun
    {
        public int StokAdedi, HamFiyat, SecilenAdet;
        public string Ad, Marka, Model, Ozellik;
    }
    public class Buzdolabi : Urun
    {
        int IcHacim;
        string EnerjiSınıfı;
        public Buzdolabi(string b_ad, string b_marka, string b_model, string b_ozellik, int b_hamFiyat, int b_secilenAdet, int icHacim, string enerjiSinifi)
        {

            Ad = b_ad;
            Marka = b_marka;
            Model = b_model;
            Ozellik = b_ozellik;
            HamFiyat = b_hamFiyat;
            SecilenAdet = b_secilenAdet;
            IcHacim = icHacim;
            EnerjiSınıfı = enerjiSinifi;
        }
        public double KdvUygula()
        {
            double KdvFiyat;
            KdvFiyat = HamFiyat * 1.05 * SecilenAdet;
            return KdvFiyat;
        }
    }
    public class LedTv : Urun
    {
        int EkranBoyutu;
        string EkranCozunurlugu;
        public LedTv(string t_ad, string t_marka, string t_model, string t_ozellik, int t_hamFiyat, int t_secilenAdet, int ekranBoyutu, string ekranCozunurlugu)
        {

            Ad = t_ad;
            Marka = t_marka;
            Model = t_model;
            Ozellik = t_ozellik;
            HamFiyat = t_hamFiyat;
            SecilenAdet = t_secilenAdet;
            EkranBoyutu = ekranBoyutu;
            EkranCozunurlugu = ekranCozunurlugu;
        }
        public double KdvUygula()
        {
            double KdvFiyat;
            KdvFiyat = HamFiyat * 1.18 * SecilenAdet;
            return KdvFiyat;
        }
    }
    public class CepTel : Urun
    {
        int DahiliHafiza;
        int RamKapasitesi;
        int PilGucu;

        public CepTel(string c_ad, string c_marka, string c_model, string c_ozellik, int c_hamFiyat, int c_secilenAdet, int dahiliHafiza, int ramKapasitesi, int pilGucu)
        {
            Ad = c_ad;
            Marka = c_marka;
            Model = c_model;
            Ozellik = c_ozellik;
            HamFiyat = c_hamFiyat;
            SecilenAdet = c_secilenAdet;
            DahiliHafiza = dahiliHafiza;
            RamKapasitesi = ramKapasitesi;
            PilGucu = pilGucu;
        }

        public double KdvUygula()
        {
            double KdvFiyat;
            KdvFiyat = HamFiyat * 1.20 * SecilenAdet;
            return KdvFiyat;
        }
    }
    public class Laptop : Urun
    {
        int EkranBoyutu;
        string EkranCozunurluk;
        int DahiliHafiza;
        int RamKapasitesi;
        int PilGucu;
        public Laptop(string l_ad, string l_marka, string l_model, string l_ozellik, int l_hamFiyat, int l_secilenAdet, int ekranBoyutu, string ekranCozunurluk, int dahiliHafiza, int ramKapasitesi, int pilGucu)
        {
            Ad = l_ad;
            Marka = l_marka;
            Model = l_model;
            Ozellik = l_ozellik;
            HamFiyat = l_hamFiyat;
            SecilenAdet = l_secilenAdet;
            EkranBoyutu = ekranBoyutu;
            EkranCozunurluk = ekranCozunurluk;
            DahiliHafiza = dahiliHafiza;
            RamKapasitesi = ramKapasitesi;
            PilGucu = pilGucu;

        }

        public double KdvUygula()
        {
            double KdvFiyat;
            KdvFiyat = HamFiyat * 1.15 * SecilenAdet;
            return KdvFiyat;
        }
    }
}