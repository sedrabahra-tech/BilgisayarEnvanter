# 💻 Şirket Bilgisayar Takip Sistemi (BilgisayarEnvanter)

Bu proje, bir şirket veya kurum içindeki bilgisayarların donanım özelliklerini, kime zimmetli olduklarını ve garanti sürelerini kolayca takip etmek amacıyla geliştirilmiş bir **C# Windows Forms** uygulamasıdır.

## 🌟 Projenin Özellikleri

* **Temel İşlemler (CRUD):** Yeni bilgisayar kaydı ekleme, var olan kayıtları güncelleme ve silme.
* **Donanım Takibi:** Her cihazın Seri No, Marka, Model, İşlemci, RAM ve SSD bilgilerini kayıt altında tutma.
* **Zimmet Takibi:** Cihazın hangi personele, hangi tarihte teslim edildiğini görme.
* **Akıllı Filtreleme:**
  * ⚠️ **5 Yılı Geçenler:** Şirkette kullanım ömrü 5 yılı doldurmuş, yenilenmesi gerekebilecek eski cihazları tek tuşla listeleme.
  * ⏳ **Garanti Sıralaması:** Cihazların teslim tarihi ve garanti yılına bakarak, garantisinin bitmesine kaç gün kaldığını hesaplama ve süresi en az kalandan en çoka doğru sıralama.

## 🛠️ Kullanılan Teknolojiler

* **C#** (Nesne Yönelimli Programlama)
* **Windows Forms** (Kullanıcı Arayüzü)
* **Microsoft SQL Server / LocalDB** (Veritabanı Yönetimi)
* **ADO.NET** (Veritabanı Bağlantısı)

## 🚀 Kurulum ve Çalıştırma Rehberi

Projeyi kendi bilgisayarınızda sorunsuz bir şekilde çalıştırmak için aşağıdaki adımları sırasıyla izleyin. Hiçbir karmaşık ayara gerek yoktur!

### Adım 1: Veritabanını Hazırlama
Projenin verileri kaydedebilmesi için önce SQL veritabanını oluşturmalıyız.
1. SQL Server Management Studio (SSMS) programını açın.
2. Proje dosyalarının içindeki **`SQLQuery1.sql`** dosyasını açın ve çalıştırın (`Execute`). Bu işlem `SirketEnvanterDB` adında boş bir veritabanı ve tablomuzu oluşturacaktır.
3. Ardından **`SQLQuery2.sql`** dosyasını açın ve çalıştırın. Bu işlem, sistemi test edebilmeniz için tabloya birkaç örnek personel ve bilgisayar verisi ekleyecektir.

### Adım 2: Projeyi Çalıştırma
1. Visual Studio programını açın.
2. `BilgisayarEnvanter.sln` veya `BilgisayarEnvanter.csproj` dosyasını seçerek projeyi yükleyin.
3. Üstteki yeşil **Start (Başlat)** butonuna basarak programı çalıştırın.

*(Not: Proje içerisindeki bağlantı cümlesi `(localdb)\MSSQLLocalDB` olarak ayarlanmıştır. Eğer farklı bir SQL Server isminiz varsa, `Form1.cs` içindeki `baglantiAdresi` değişkenini kendi sunucu adınıza göre güncelleyebilirsiniz.)*
