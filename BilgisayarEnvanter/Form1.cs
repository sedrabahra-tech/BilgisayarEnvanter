using System;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace BilgisayarEnvanter
{
    public partial class Form1 : Form
    {
        // ARAYÜZ ELEMANLARI
        TextBox txtSeriNo, txtMarka, txtModel, txtIslemci, txtRAM, txtSSD, txtPersonelAdi, txtGarantiYili;
        DateTimePicker dtpTeslimTarihi;
        Button btnKaydet, btnGuncelle, btnSil, btnListele, btnAlimListesi, btnGarantiListesi;
        DataGridView dgvBilgisayarlar;

        // SQL Bağlantı Adresi
        string baglantiAdresi = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SirketEnvanterDB;Integrated Security=True;";

        public Form1()
        {
            TasarimiOlustur();
            Listele();
        }

        private void TasarimiOlustur()
        {
            this.Text = "Şirket Bilgisayar Takip Sistemi";
            this.Size = new Size(850, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.WhiteSmoke;

            // ETİKETLER
            string[] etiketler = { "Seri No:", "Marka:", "Model:", "İşlemci:", "RAM (GB):", "SSD (GB):", "Teslim Tarihi:", "Garanti Yılı:", "Personel Adı:" };
            int yEkseni = 20;

            for (int i = 0; i < etiketler.Length; i++)
            {
                Label lbl = new Label { Text = etiketler[i], Location = new Point(20, yEkseni), AutoSize = true };
                this.Controls.Add(lbl);
                yEkseni += 30;
            }

            // KUTULAR
            txtSeriNo = new TextBox { Location = new Point(120, 20), Width = 150 };
            txtMarka = new TextBox { Location = new Point(120, 50), Width = 150 };
            txtModel = new TextBox { Location = new Point(120, 80), Width = 150 };
            txtIslemci = new TextBox { Location = new Point(120, 110), Width = 150 };
            txtRAM = new TextBox { Location = new Point(120, 140), Width = 150 };
            txtSSD = new TextBox { Location = new Point(120, 170), Width = 150 };
            dtpTeslimTarihi = new DateTimePicker { Location = new Point(120, 200), Width = 150, Format = DateTimePickerFormat.Short };
            txtGarantiYili = new TextBox { Location = new Point(120, 230), Width = 150 };
            txtPersonelAdi = new TextBox { Location = new Point(120, 260), Width = 150 };

            this.Controls.AddRange(new Control[] { txtSeriNo, txtMarka, txtModel, txtIslemci, txtRAM, txtSSD, dtpTeslimTarihi, txtGarantiYili, txtPersonelAdi });

            // BUTONLAR
            btnKaydet = new Button { Text = "💾 Kaydet", Location = new Point(320, 20), Size = new Size(150, 40), BackColor = Color.LightGreen };
            btnGuncelle = new Button { Text = "🔄 Güncelle", Location = new Point(320, 70), Size = new Size(150, 40), BackColor = Color.LightBlue };
            btnSil = new Button { Text = "🗑️ Sil", Location = new Point(320, 120), Size = new Size(150, 40), BackColor = Color.Salmon };

            btnListele = new Button { Text = "📋 Tümünü Listele", Location = new Point(500, 20), Size = new Size(150, 40) };
            btnAlimListesi = new Button { Text = "⚠️ 5 Yılı Geçenler", Location = new Point(500, 70), Size = new Size(150, 40) };
            btnGarantiListesi = new Button { Text = "⏳ Garanti Sıralaması", Location = new Point(500, 120), Size = new Size(150, 40) };

            btnKaydet.Click += BtnKaydet_Click;
            btnGuncelle.Click += BtnGuncelle_Click;
            btnSil.Click += BtnSil_Click;
            btnListele.Click += BtnListele_Click;
            btnAlimListesi.Click += BtnAlimListesi_Click;
            btnGarantiListesi.Click += BtnGarantiListesi_Click;

            this.Controls.AddRange(new Control[] { btnKaydet, btnGuncelle, btnSil, btnListele, btnAlimListesi, btnGarantiListesi });

            // TABLO
            dgvBilgisayarlar = new DataGridView { Location = new Point(20, 310), Size = new Size(790, 230), ReadOnly = true, SelectionMode = DataGridViewSelectionMode.FullRowSelect };
            dgvBilgisayarlar.CellClick += DgvBilgisayarlar_CellClick;
            this.Controls.Add(dgvBilgisayarlar);
        }

        private void Listele()
        {
            try
            {
                using (SqlConnection baglanti = new SqlConnection(baglantiAdresi))
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Bilgisayarlar", baglanti);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvBilgisayarlar.DataSource = dt;
                }
            }
            catch (Exception ex) { MessageBox.Show("Veritabanı bağlanamadı: " + ex.Message); }
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection baglanti = new SqlConnection(baglantiAdresi))
                {
                    string sorgu = "INSERT INTO Bilgisayarlar (SeriNo, Marka, Model, Islemci, RAM, SSD, TeslimTarihi, GarantiYili, PersonelAdi) VALUES (@SeriNo, @Marka, @Model, @Islemci, @RAM, @SSD, @TeslimTarihi, @GarantiYili, @PersonelAdi)";
                    SqlCommand komut = new SqlCommand(sorgu, baglanti);

                    komut.Parameters.AddWithValue("@SeriNo", txtSeriNo.Text);
                    komut.Parameters.AddWithValue("@Marka", txtMarka.Text);
                    komut.Parameters.AddWithValue("@Model", txtModel.Text);
                    komut.Parameters.AddWithValue("@Islemci", txtIslemci.Text);
                    komut.Parameters.AddWithValue("@RAM", Convert.ToInt32(txtRAM.Text));
                    komut.Parameters.AddWithValue("@SSD", Convert.ToInt32(txtSSD.Text));
                    komut.Parameters.AddWithValue("@TeslimTarihi", dtpTeslimTarihi.Value.Date);
                    komut.Parameters.AddWithValue("@GarantiYili", Convert.ToInt32(txtGarantiYili.Text));
                    komut.Parameters.AddWithValue("@PersonelAdi", txtPersonelAdi.Text);

                    baglanti.Open();
                    komut.ExecuteNonQuery();
                    baglanti.Close();

                    MessageBox.Show("Başarıyla eklendi!");
                    Listele();
                }
            }
            catch { MessageBox.Show("Lütfen RAM, SSD ve Garanti Yılı alanlarına sadece SAYI girin."); }
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            if (dgvBilgisayarlar.CurrentRow != null)
            {
                try
                {
                    using (SqlConnection baglanti = new SqlConnection(baglantiAdresi))
                    {
                        string sorgu = "UPDATE Bilgisayarlar SET SeriNo=@SeriNo, Marka=@Marka, Model=@Model, Islemci=@Islemci, RAM=@RAM, SSD=@SSD, TeslimTarihi=@TeslimTarihi, GarantiYili=@GarantiYili, PersonelAdi=@PersonelAdi WHERE Id=@Id";
                        SqlCommand komut = new SqlCommand(sorgu, baglanti);

                        komut.Parameters.AddWithValue("@SeriNo", txtSeriNo.Text);
                        komut.Parameters.AddWithValue("@Marka", txtMarka.Text);
                        komut.Parameters.AddWithValue("@Model", txtModel.Text);
                        komut.Parameters.AddWithValue("@Islemci", txtIslemci.Text);
                        komut.Parameters.AddWithValue("@RAM", Convert.ToInt32(txtRAM.Text));
                        komut.Parameters.AddWithValue("@SSD", Convert.ToInt32(txtSSD.Text));
                        komut.Parameters.AddWithValue("@TeslimTarihi", dtpTeslimTarihi.Value.Date);
                        komut.Parameters.AddWithValue("@GarantiYili", Convert.ToInt32(txtGarantiYili.Text));
                        komut.Parameters.AddWithValue("@PersonelAdi", txtPersonelAdi.Text);
                        komut.Parameters.AddWithValue("@Id", Convert.ToInt32(dgvBilgisayarlar.CurrentRow.Cells["Id"].Value));

                        baglanti.Open();
                        komut.ExecuteNonQuery();
                        baglanti.Close();

                        MessageBox.Show("Başarıyla güncellendi!");
                        Listele();
                    }
                }
                catch { MessageBox.Show("Sayısal alanları doğru girdiğinizden emin olun."); }
            }
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            if (dgvBilgisayarlar.CurrentRow != null)
            {
                using (SqlConnection baglanti = new SqlConnection(baglantiAdresi))
                {
                    SqlCommand komut = new SqlCommand("DELETE FROM Bilgisayarlar WHERE Id=@Id", baglanti);
                    komut.Parameters.AddWithValue("@Id", Convert.ToInt32(dgvBilgisayarlar.CurrentRow.Cells["Id"].Value));

                    baglanti.Open();
                    komut.ExecuteNonQuery();
                    baglanti.Close();

                    MessageBox.Show("Kayıt silindi.");
                    Listele();
                }
            }
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void BtnAlimListesi_Click(object sender, EventArgs e)
        {
            using (SqlConnection baglanti = new SqlConnection(baglantiAdresi))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Bilgisayarlar WHERE DATEDIFF(YEAR, TeslimTarihi, GETDATE()) > 5", baglanti);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvBilgisayarlar.DataSource = dt;
            }
        }

        private void BtnGarantiListesi_Click(object sender, EventArgs e)
        {
            using (SqlConnection baglanti = new SqlConnection(baglantiAdresi))
            {
                string sorgu = "SELECT Id, SeriNo, Marka, Model, PersonelAdi, TeslimTarihi, GarantiYili, DATEADD(YEAR, GarantiYili, TeslimTarihi) AS GarantiBitisTarihi, DATEDIFF(DAY, GETDATE(), DATEADD(YEAR, GarantiYili, TeslimTarihi)) AS KalanGun FROM Bilgisayarlar ORDER BY KalanGun ASC";
                SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvBilgisayarlar.DataSource = dt;
            }
        }

        private void DgvBilgisayarlar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvBilgisayarlar.CurrentRow != null)
            {
                txtSeriNo.Text = dgvBilgisayarlar.CurrentRow.Cells["SeriNo"].Value.ToString();
                txtMarka.Text = dgvBilgisayarlar.CurrentRow.Cells["Marka"].Value.ToString();
                txtModel.Text = dgvBilgisayarlar.CurrentRow.Cells["Model"].Value.ToString();
                txtIslemci.Text = dgvBilgisayarlar.CurrentRow.Cells["Islemci"].Value.ToString();
                txtRAM.Text = dgvBilgisayarlar.CurrentRow.Cells["RAM"].Value.ToString();
                txtSSD.Text = dgvBilgisayarlar.CurrentRow.Cells["SSD"].Value.ToString();
                dtpTeslimTarihi.Value = Convert.ToDateTime(dgvBilgisayarlar.CurrentRow.Cells["TeslimTarihi"].Value);
                txtGarantiYili.Text = dgvBilgisayarlar.CurrentRow.Cells["GarantiYili"].Value.ToString();
                txtPersonelAdi.Text = dgvBilgisayarlar.CurrentRow.Cells["PersonelAdi"].Value.ToString();
            }
        }
    }
}