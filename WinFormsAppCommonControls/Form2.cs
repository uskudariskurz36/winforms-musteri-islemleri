using MFramework.Services.FakeData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsAppCommonControls
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            string name = txtAd.Text;
            string surname = txtSoyad.Text;
            string phone = txtTelefon.Text;
            string company = txtFirma.Text;

            string info = $"{name} {surname} ({company}) - {phone}";

            lstMusteriler.Items.Add(info);
            lblAdet.Text = lstMusteriler.Items.Count.ToString() + " adet kişi vardır.";
            lblCount.Text = lstMusteriler.Items.Count.ToString() + " adet kişi vardır.";
            lblLastProcess.Text = $"Kişi eklendi.({DateTime.Now})";

            notifyIcon1.ShowBalloonTip(5000, "Bilgilendirme", "Kişi eklendi.", ToolTipIcon.Info);
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int index = lstMusteriler.SelectedIndex;

            //if (index < 0)
            //{
            //    MessageBox.Show("Lütfen silmek için bir kişi seçiniz.");
            //}
            //else
            //{
            //    lstMusteriler.Items.RemoveAt(index);
            //}

            if (index < 0)
            {
                MessageBox.Show("Lütfen silmek için bir kişi seçiniz.");
                return;
            }

            DialogResult result = MessageBox.Show("İlgili kaydı silmek istediğinize emin misiniz?", "Silme Onay", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3);

            if (result == DialogResult.Yes)
            {
                lstMusteriler.Items.RemoveAt(index);
                lblAdet.Text = lstMusteriler.Items.Count.ToString() + " adet kişi vardır.";
                lblCount.Text = lstMusteriler.Items.Count.ToString() + " adet kişi vardır.";
                lblLastProcess.Text = $"Kişi silindi.({DateTime.Now})";
            }
        }

        private void lstMusteriler_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstMusteriler.SelectedIndex < 0)
                return;
            
            //string info = lstMusteriler.SelectedItem.ToString();
            string info = lstMusteriler.Items[lstMusteriler.SelectedIndex].ToString();

            // Julia Mohamed (Bradshaw Ccc) - 01761-296755

            string[] split1 = info.Split(" - ");
            
            string nameSurnameCompany = split1[0];  // Julia Mohamed (Bradshaw Ccc)
            string phone = split1[1];               // 01761-296755

            string[] split2 = nameSurnameCompany.Split(" (");
            string nameSurname = split2[0];         // Julia Mohamed
            string company = split2[1];             // Bradshaw Ccc)

            //company = company.Substring(0, company.Length - 1);   // Bradshaw Ccc
            company = company.TrimEnd(')');                         // Bradshaw Ccc

            string[] split3 = nameSurname.Split(" ");
            string name = split3[0];
            string surname = split3[1];

            txtAd.Text = name;
            txtSoyad.Text = surname;
            txtFirma.Text = company;
            txtTelefon.Text = phone;

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                string name = NameData.GetFirstName();
                string surname = NameData.GetSurname();
                string phone = PhoneNumberData.GetPhoneNumber();
                string company = NameData.GetCompanyName();

                string info = $"{name} {surname} ({company}) - {phone}";

                lstMusteriler.Items.Add(info);
            }

            lblAdet.Text = lstMusteriler.Items.Count.ToString() + " adet kişi vardır.";
            lblCount.Text = lstMusteriler.Items.Count.ToString() + " adet kişi vardır.";
            lblLastProcess.Text = $"Veriler yüklendi.({DateTime.Now})";
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (lstMusteriler.SelectedIndex < 0)
            {
                MessageBox.Show("Lütfen kaydetmek için bir kişi seçiniz.", "Kişi Seçili Değil!", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);

                return;
            }

            string name = txtAd.Text;
            string surname = txtSoyad.Text;
            string phone = txtTelefon.Text;
            string company = txtFirma.Text;

            string info = $"{name} {surname} ({company}) - {phone}";

            lstMusteriler.Items[lstMusteriler.SelectedIndex] = info;
            lblLastProcess.Text = $"Kişi güncellendi.({DateTime.Now})";

            MessageBox.Show("Kişi kaydedildi", "Güncellendi", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }
    }
}
