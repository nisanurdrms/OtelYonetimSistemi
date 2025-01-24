# OtelYonetimSistemi
  Bu proje, otel rezervasyonlarını yönetmek, oda kullanılabilirliğini takip etmek ve misafirlerin giriş/çıkış işlemlerini kolaylaştırmak için tasarlanmış bir otel yönetim sistemidir. 
  
  Sistemin sunduğu bazı özellikler şunlardır: 
  
Oda Yönetimi: Oda bilgilerini ekleme, güncelleme ve silme işlemleri. 

Rezervasyon Sistemi: Kullanıcılar, oda rezervasyonu yapabilir, kullanılabilirlik durumunu kontrol edebilir ve geçmiş rezervasyonları görüntüleyebilir. 

Misafir Giriş/Çıkış: Misafirlerin giriş ve çıkış işlemlerinin takibi. 

Raporlar: Rezervasyonlar, doluluk oranları ve diğer önemli veriler hakkında raporlar oluşturma.


Bu proje,  C# dili ile, Windows Forms Apps (.NET Framework) kullanılarak ve phpMyAdmin veritabanı ile geliştirilmiştir ve otel yönetimini daha verimli hale getirmeyi amaçlamaktadır.


Projenin Youtube linki: https://youtu.be/1kdIbX-K6Bk?si=I1KYU5CRZ2kZQu0L





1- Use-Case Diyagramı
![Ekran görüntüsü 2025-01-24 224459](https://github.com/user-attachments/assets/c58875da-cdca-499a-9a04-d2b02ebb0433)















2- Class Diyagramı
![Ekran görüntüsü 2025-01-24 224514](https://github.com/user-attachments/assets/2b5b3f16-f844-4402-af07-e3220c86b245)
















3- ER Diyagramı
![Ekran görüntüsü 2025-01-24 224548](https://github.com/user-attachments/assets/70973366-0e75-4839-b6ab-d6458f903337)












![Ekran görüntüsü 2025-01-24 225021](https://github.com/user-attachments/assets/0e3ddfcb-e260-4bea-bf8a-ac04d6a6338b)
Login Formu 
 Admin bilgilerini veri tabanından alır. Bağlantı olmaması durumunda giriş yapılamaz.









![Ekran görüntüsü 2025-01-24 225112](https://github.com/user-attachments/assets/7354f6bb-7233-47cb-8624-d6110284b762)
MainForm
 MainForm genel bilgilerin görüldüğü yerdir. Diğer detay formlarına ve istenen belgelere buradan ulaşılır.













![Ekran görüntüsü 2025-01-24 225131](https://github.com/user-attachments/assets/ffc1b25b-7261-4cf8-9228-76949163bf12)
OdaForm
 Oda ekleme, silme, güncelleme, temizlik ve doluluk durumlarına müdahele buradan yapılabilir. Veri tabanıyla diğer formlara bağlıdır. Burada ekleyeceğiniz odalar rezervasyon ve müşteri formlarında da eklenir veya silinir.














![Ekran görüntüsü 2025-01-24 225140](https://github.com/user-attachments/assets/a23d9f05-61e4-4150-8464-b26fc9286de3)
MusteriForm
 Müşteri ekleme, silme, bilgilerini düzenleme buradan yapılır.













![Ekran görüntüsü 2025-01-24 225153](https://github.com/user-attachments/assets/dd1c27d2-867e-4220-9efd-c07cbddf02c6)
RezervasyonForm
 Rezervasyon işlemleri bu formda yapılır. Diğer formlarla entegredir.













![Ekran görüntüsü 2025-01-24 225208](https://github.com/user-attachments/assets/40cc6c30-146e-4dbc-9b7b-2f6dfa659bdb)
Uyarıcılar
 Birçok işlem yapılması ve özellikle yapılmaması durumunda kullanıcıya uyarı verecektir. Bu kullanıcıya hatırlatma konusunda yardımcı olmak için yapılmıştır.
