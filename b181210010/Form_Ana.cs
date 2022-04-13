/****************************************************************************
**				 	     SAKARYA ÜNİVERSİTESİ
**				BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ
**				    BİLGİSAYAR MÜHENDİSLİĞİ BÖLÜMÜ
**				   NESNEYE DAYALI PROGRAMLAMA DERSİ
**					     2019-2020 BAHAR DÖNEMİ
**                             PROJE ÖDEVi
**	
**				ÖDEV NUMARASI..........: PROJE ÖDEVİ
**				ÖĞRENCİ ADI............: Deniz Berfin Taştan
**				ÖĞRENCİ NUMARASI.......: B181210010
**              DERSİN ALINDIĞI GRUP...: 1-D
******************************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace B181210010
{
    public partial class Form_Ana : Form
    {
        public Form_Ana()
        {
            InitializeComponent();
        }
        List<Atik> atiklar = new List<Atik>();
        Atik atik = new Atik();
        OrganikKutu organikKutu = new OrganikKutu();
        KagitKutu kagitKutu = new KagitKutu();
        CamKutu camKutu = new CamKutu();
        MetalKutu metalKutu = new MetalKutu();
        int sure, puan;
        public int atikBul(string tur)
        {
            for (int i = 0; i < atiklar.Count; i++)
            {
                if (atiklar[i].Tur == tur && atiklar[i].Ad == atik.Ad)
                {
                    yeniAtik();
                    return i;
                }

            }
            return -1;
        }//Listedeki atıkları türüne ve adına göre tarar.
        public void yeniAtik()
        {
            int sec = new Random().Next(0, atiklar.Count);
            atik = atiklar[sec];
            pbAtik.Image = atik.Image;
        }//Rastgele atık ve atık resmi ataması yapılır.
        public void butonAktif()
        {
            btnOrganikAtik.Enabled = true;
            btnBosaltOrganik.Enabled = true;
            btnKagit.Enabled = true;
            btnBosaltKagit.Enabled = true;
            btnCam.Enabled = true;
            btnBosaltCam.Enabled = true;
            btnMetal.Enabled = true;
            btnBosaltMetal.Enabled = true;
        }//Ekleme ve boşaltma butonları aktifleşir.
        public void butonKapat()
        {
            btnOrganikAtik.Enabled = false;
            btnBosaltOrganik.Enabled = false;
            btnKagit.Enabled = false;
            btnBosaltKagit.Enabled = false;
            btnCam.Enabled = false;
            btnBosaltCam.Enabled = false;
            btnMetal.Enabled = false;
            btnBosaltMetal.Enabled =false;
        }//Ekleme ve boşaltma butonları kapatır.
        public void yeniOyun()
        {
            btnYeniOyun.Enabled = false;
            pbAtik.Image = null;
            sure = 60;
            puan = 0;
            temizle();
            butonAktif();
            tmSayac.Enabled = true; 
            yeniAtik();
        }
        public void temizle()
        {
            lstOrganik.Items.Clear();
            lstMetal.Items.Clear();
            lstKagit.Items.Clear();
            lstCam.Items.Clear();
            pgOrganik.Value = 0;
            pgMetal.Value = 0;
            pgKagit.Value = 0;
            pgCam.Value = 0;
            
        }//Listeler ve progress barlar sıfırlanır.
        private void Form_Ana_Load(object sender, EventArgs e)
        {
            atiklar.Add(new Atik("cam", "Cam Şişe", 600));
            atiklar.Add(new Atik("cam", "Bardak", 250));
            atiklar.Add(new Atik("kagit", "Gazete", 250));
            atiklar.Add(new Atik("kagit", "Dergi", 200));
            atiklar.Add(new Atik("organik", "Domates", 150));
            atiklar.Add(new Atik("organik", "Salatalık", 120));
            atiklar.Add(new Atik("metal", "Kola Kutusu", 350));
            atiklar.Add(new Atik("metal", "Salça Kutusu", 550));
        } //Yukarıda oluşturduğumuz listeye tür, isim ve hacim atamaları yaptık. Bu liste aşağıda iflerde bize yardımcı olacak.
        public void oyunBitir()
        {
            tmSayac.Enabled = false;
            btnYeniOyun.Enabled = true;
            pbAtik.Image = null;
            butonKapat();
            temizle();
        }// Sayaç sıfırlanır. Yeni oyun butonu aktif hale gelir.Resim boş hale gelir ve listeler temizlenir.
        private void tmSayac_Tick(object sender, EventArgs e)
        {
            if (sure <= 0)
            {
                oyunBitir();
                return;
            }
            sure--;
            lbSure.Text = sure.ToString();
            lbPuan.Text = puan.ToString();
        }
        private void btnYeniOyun_Click(object sender, EventArgs e)
        {
            yeniOyun();
        }
        private void btnOrganikAtik_Click(object sender, EventArgs e)
        { 
            if(organikKutu.DolulukOrani<75)
            {   
                int index = atikBul("organik"); 
                if (index > -1)
                {
                    if (organikKutu.Ekle(atiklar[index]))
                    {
                        pgOrganik.Value = organikKutu.DolulukOrani;
                        lstOrganik.Items.Add(atiklar[index].Ad + " (" + atiklar[index].Hacim.ToString() + ")");
                        puan += atiklar[index].Hacim;
                        yeniAtik();
                    }
                }
            } 

        }//Eğer organik atık kutusunun doluluk oranı %75'ten küçükse yukarıda tür adı "organik" olarak atanan liste elemanları çağırılır ve gelen elemana göre progressbar'a hacim, listbox'a isim, puan label'ine de puan ataması yapılır ve yeni atık oluşturulur.
        private void btnKagit_Click(object sender, EventArgs e)
        {
            if(kagitKutu.DolulukOrani<75)
            { 
                int index = atikBul("kagit");
                if (index > -1)
                {
                    if (kagitKutu.Ekle(atiklar[index]))
                    {
                        pgKagit.Value = kagitKutu.DolulukOrani;
                        lstKagit.Items.Add(atiklar[index].Ad + " (" + atiklar[index].Hacim.ToString() + ")");
                        puan += atiklar[index].Hacim;
                        yeniAtik();
                    }
                }
            }
        }//OrganikAtik butonundaki tüm işlemler burada da gerçekleşir.
        private void btnCam_Click(object sender, EventArgs e)
        {
            if(camKutu.DolulukOrani<75)
            { 
                int index = atikBul("cam");
                if (index > -1)
                {
                    if (camKutu.Ekle(atiklar[index]))
                    {
                        pgCam.Value = camKutu.DolulukOrani;
                        lstCam.Items.Add(atiklar[index].Ad + " (" + atiklar[index].Hacim.ToString() + ")");
                        puan += atiklar[index].Hacim;
                        yeniAtik();
                    }
                }
            }
        }//OrganikAtik butonundaki tüm işlemler burada da gerçekleşir.
        private void btnMetal_Click(object sender, EventArgs e)
        {
            if(metalKutu.DolulukOrani<75)
            { 
                int index = atikBul("metal");
                if (index > -1)
                {
                    if (metalKutu.Ekle(atiklar[index]))
                    {
                        pgMetal.Value = metalKutu.DolulukOrani;
                        lstMetal.Items.Add(atiklar[index].Ad + " (" + atiklar[index].Hacim.ToString() + ")");
                        puan += atiklar[index].Hacim;
                        yeniAtik();
                    }
                }
            }
        }//OrganikAtik butonundaki tüm işlemler burada da gerçekleşir.
        private void btnBosaltOrganik_Click(object sender, EventArgs e)
        {
            if(organikKutu.DolulukOrani>75)
            { 
                
                if (organikKutu.Bosalt())
                {
                    lstOrganik.Items.Clear();
                    pgOrganik.Value = 0;
                    puan += organikKutu.BosaltmaPuani;
                    sure += 3;
                }
            } 

        }//Eğer Organik kutusunun doluluk oranı %75'ten fazlaysa progressbar sıfırlanır. Puana boşaltma puanı ve süreye 3 saniye eklenir.
        private void btnBosaltCam_Click(object sender, EventArgs e)
        {
            if (camKutu.DolulukOrani > 75)
            { 
                if (camKutu.Bosalt())
                {
                    lstCam.Items.Clear();
                    pgCam.Value = 0;
                    puan += camKutu.BosaltmaPuani;
                    sure += 3;
                }
            }
        }//Organik kutusunun boşaltma işlemleri ile aynı işlevi görür.
        private void btnBosaltMetal_Click(object sender, EventArgs e)
        {   
            if(metalKutu.DolulukOrani>75)
            { 
               
                if (metalKutu.Bosalt())
                {
                    lstMetal.Items.Clear();
                    pgMetal.Value = 0;
                    puan += metalKutu.BosaltmaPuani;
                    sure += 3;
                }
            }
        }//Organik kutusunun boşaltma işlemleri ile aynı işlevi görür.
        private void btnBosaltKagit_Click(object sender, EventArgs e)
        {   
            if(kagitKutu.DolulukOrani>75)
            { 
                int doluHacim = kagitKutu.DoluHacim;
                if (kagitKutu.Bosalt())
                {
                    lstKagit.Items.Clear();
                    pgKagit.Value = 0;
                    puan += doluHacim + kagitKutu.BosaltmaPuani;
                    sure += 3;
                }
            }
        }//Organik kutusunun boşaltma işlemleri ile aynı işlevi görür.
        private void btnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }//Uygulamadan çıkar.

    }
    public interface IAtik
    {
        string Ad { get; set; }
        string Tur { get; set; }
        int Hacim { get; set; }
        System.Drawing.Image Image { get; set; }
    }
    public interface IAtikKutusu : IDolabilen
    {
        int BosaltmaPuani { get; }
        bool Ekle(Atik atik);
        bool Bosalt();
    }
    public interface IDolabilen
    {
        int Kapasite { get; }
        int DoluHacim { get; set; }
        int DolulukOrani { get; }
    }
    public class Atik : IAtik
    {
        public Atik() //Fonksiyon kullanırken nesne çağırmak için parametresiz bir sınıf oluşturdum.
        {
        }
        public Atik(string tur, string ad, int hacim)
        {
            Tur = tur;
            Ad = ad;
            Hacim = hacim;
            Image = Image.FromFile(ad + ".jpg");
        }//Her bir ürün için isim,tür,hacim ve resim ataması için kullanılır.

        public string Ad
        { get; set; }

        public int Hacim
        { get; set; }

        public Image Image
        { get; set; }

        public string Tur
        { get; set; }
    }
    public class OrganikKutu : IAtikKutusu
    {
        public int BosaltmaPuani
        {
            get
            {
                return 0;
            }
        }

        public int DoluHacim
        {
            get; set;
        }

        public int DolulukOrani
        {
            get
            {
                return (DoluHacim / (Kapasite / 100));
            }
        }

        public int Kapasite
        {
            get
            {
                return 700;
            }
        }

        public bool Bosalt()
        {
            if (DolulukOrani > 75)
            {
                DoluHacim = 0;
                return true;
            }
            return false;
        }

        public bool Ekle(Atik atik)
        {
            if (DolulukOrani < 75)
            {
                if (Kapasite - DoluHacim >= atik.Hacim)
                {

                    DoluHacim = DoluHacim + atik.Hacim;
                }
                return true;
            }
            return false;
        }
    } 
    public class KagitKutu : IAtikKutusu
    {
        public int BosaltmaPuani
        {
            get
            {
                return 1000;
            }
        }

        public int DoluHacim
        {
            get; set;
        }

        public int DolulukOrani
        {
            get
            {
                return (DoluHacim / (Kapasite / 100));
            }
        }

        public int Kapasite
        {
            get
            {
                return 2300;
            }
        }

        public bool Bosalt()
        {
            if (DolulukOrani > 75)
            {
                DoluHacim = 0;
                return true;
            }
            return false;
        }

        public bool Ekle(Atik atik)
        {
            if (DolulukOrani < 75)
            {
                if (Kapasite - DoluHacim >= atik.Hacim)
                {

                    DoluHacim = DoluHacim + atik.Hacim;
                }
                return true;
            }
            return false;
        }
    }
    public class CamKutu : IAtikKutusu
    {
        public int BosaltmaPuani
        {
            get
            {
                return 600;
            }
        }

        public int DoluHacim
        {
            get; set;
        }

        public int DolulukOrani
        {
            get
            {
                return (DoluHacim / (Kapasite / 100));
            }
        }

        public int Kapasite
        {
            get
            {
                return 2200;
            }
        }

        public bool Bosalt()
        {
            if (DolulukOrani > 75)
            {
                DoluHacim = 0;
                return true;
            }
            return false;
        }

        public bool Ekle(Atik atik)
        {
            if (DolulukOrani < 75)
            {
                if (Kapasite - DoluHacim >= atik.Hacim)
                {

                    DoluHacim = DoluHacim + atik.Hacim;
                }
                return true;
            }
            return false;
        }
    }
    public class MetalKutu : IAtikKutusu
    {
        public int BosaltmaPuani
        {
            get
            {
                return 800;
            }
        }

        public int DoluHacim
        {
            get; set;
        }

        public int DolulukOrani
        {
            get
            {
                return (DoluHacim / (Kapasite / 100));
            }
        }

        public int Kapasite
        {
            get
            {
                return 2300;
            }
        }

        public bool Bosalt()
        {
            if (DolulukOrani > 75)
            {
                DoluHacim = 0;
                return true;
            }
            return false;
        }

        public bool Ekle(Atik atik)
        {
            if (DolulukOrani < 75)
            {
                if (Kapasite - DoluHacim >= atik.Hacim)
                {

                    DoluHacim = DoluHacim + atik.Hacim;
                }
                return true;
            }
            return false;
        }
    }
    
}
