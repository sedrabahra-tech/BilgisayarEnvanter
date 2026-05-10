-- 1. ADIM: Önce veritabanımızı oluşturuyoruz.
CREATE DATABASE SirketEnvanterDB;
GO

-- 2. ADIM: Yeni oluşturduğumuz veritabanını kullanacağımızı sisteme söylüyoruz.
USE SirketEnvanterDB;
GO

-- 3. ADIM: Tablomuzu ve kolonlarımızı (alanları) oluşturuyoruz.
CREATE TABLE Bilgisayarlar (
    -- Id: Her bilgisayara özel otomatik artan eşsiz numaradır (1,2,3 diye artar). Birincil anahtardır (Primary Key).
    Id INT PRIMARY KEY IDENTITY(1,1),
    SeriNo NVARCHAR(50) NOT NULL,       -- Harf ve rakam içerebileceği için NVARCHAR
    Marka NVARCHAR(50) NOT NULL,
    Model NVARCHAR(50) NOT NULL,
    Islemci NVARCHAR(50) NOT NULL,
    RAM INT NOT NULL,                   -- Matematiksel bir değer olduğu için INT (Sayı)
    SSD INT NOT NULL,                   -- Matematiksel bir değer olduğu için INT
    TeslimTarihi DATE NOT NULL,         -- Sadece tarih tutacağı için DATE
    GarantiYili INT NOT NULL,           -- Örneğin sadece '2' yazılacağı için INT
    PersonelAdi NVARCHAR(100) NOT NULL
);
GO