using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFA_PersonelTakip
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            Personel yeniKayit = new Personel();//Personel classından instance alındı.
            #region Normal ekleme
            //yeniKayit.Ad = txtAd.Text;
            //yeniKayit.Soyad = txtSoyad.Text;
            //yeniKayit.TCKN = txtTcKimlikNo.Text;
            //yeniKayit.Telefon = txtTelefon.Text;
            //yeniKayit.Unvan = txtUnvan.Text;
            //yeniKayit.DogumTarihi = dtpDogumTarihi.Value;
            //yeniKayit.IseGiris = dtpIseGirisTarih.Value;
            //yeniKayit.Adres = txtAdres.Text; 
            #endregion
            yeniKayit = PersonelOlustur(yeniKayit);
            ListViewItem lvi = ListViewItemOlustur(yeniKayit);
            listView1.Items.Add(lvi);

        }

       

        //Bu metot listviewItem'e personel ekleyen bir metot olacak. 
        public ListViewItem ListViewItemOlustur(Personel p)
        {
            //ListviewItem'a parametreden almış olduğumuz Personel tipindeki p'yi ekleyeceğiz.
            string[] bilgiler = { p.TCKN, p.Ad, p.Soyad, p.DogumTarihi.ToString(), p.Telefon, p.Email, p.Adres,  p.Unvan, p.IseGiris.ToString() };


            ListViewItem lvi = new ListViewItem(bilgiler);
            //Tag taşıma çantası görevini üstlenir.
            //boxing (object haline dönüştürme)
            lvi.Tag = p;

            return lvi;

        }

        public Personel PersonelOlustur(Personel p)
        {
            p.Ad = txtAd.Text;
            p.Soyad = txtSoyad.Text;
            p.TCKN = txtTcKimlikNo.Text;
            p.Telefon = txtTelefon.Text;
            p.Unvan = txtUnvan.Text;
            p.DogumTarihi = dtpDogumTarihi.Value;
            p.IseGiris = dtpIseGirisTarih.Value;
            p.Adres = txtAdres.Text;

            return p;
        }
        Personel secili;//global alanda Personel tipinde boş bir değişken oluşturduk. Bu değişken ListViewItem Double Click olduğunda dolduruluyor.
      

        private void ListView1_DoubleClick(object sender, EventArgs e)
        {
            secili = (Personel)listView1.SelectedItems[0].Tag;//Tag içerisine object alan bir cep gibi düşünülebilir. Bağlı bulunan item ile beraber hareket eder. ListViewItemOlustur isimli metot içerisinde bu tag'i gönderdik.
            txtAd.Text = secili.Ad;
            txtSoyad.Text = secili.Soyad;
            txtTcKimlikNo.Text = secili.TCKN;
            txtAdres.Text = secili.Adres;
            txtEmail.Text = secili.Email;
            txtTelefon.Text = secili.Telefon;
            txtUnvan.Text = secili.Unvan;
            dtpDogumTarihi.Value = secili.DogumTarihi;
            dtpIseGirisTarih.Value = secili.IseGiris;
        }

        private void BtnGuncelle_Click_1(object sender, EventArgs e)
        {
            secili = PersonelOlustur(secili);

            int index = listView1.SelectedItems[0].Index;
            listView1.Items.RemoveAt(index);
            listView1.Items.Insert(index, ListViewItemOlustur(secili));


        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                DialogResult dr = MessageBox.Show("Silmek istediğinize emin misiniz?", "Bilgilendirme", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dr == DialogResult.Yes)
                {
                    listView1.SelectedItems[0].Remove();
                }
            }
            else
            {
                MessageBox.Show("Kardeşim ben neyi sileceğim?");
            }
        }

       

     
    }
}
