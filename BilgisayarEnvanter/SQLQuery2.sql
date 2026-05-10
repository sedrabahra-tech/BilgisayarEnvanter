USE SirketEnvanterDB;
GO

-- Eğer önceden yarım yamalak veri eklendiyse tabloyu tertemiz yapar:
TRUNCATE TABLE Bilgisayarlar;
GO

-- Sadece test verilerini ekliyoruz:
INSERT INTO Bilgisayarlar (SeriNo, Marka, Model, Islemci, RAM, SSD, TeslimTarihi, GarantiYili, PersonelAdi)
VALUES 
('SN-1001', 'Lenovo', 'ThinkPad T480', 'i5', 8, 256, '2018-05-15', 2, 'Oğuzhan Taş'),
('SN-1002', 'HP', 'ProBook', 'i7', 16, 512, '2024-06-01', 2, 'Ayşe Yılmaz'),
('SN-1003', 'Dell', 'XPS 15', 'i9', 32, 1000, '2025-11-20', 3, 'Mehmet Demir'),
('SN-1004', 'Asus', 'ZenBook', 'i5', 8, 512, '2019-01-10', 2, 'Fatma Kaya'),
('SN-1005', 'Apple', 'MacBook Air', 'M1', 8, 256, '2022-09-14', 2, 'Ali Veli');
GO