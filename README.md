<div align="center">

# 🛒 ECOM
### ASP.NET Core MVC E-Ticaret Platformu

<br/>

![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white)
![ASP.NET](https://img.shields.io/badge/ASP.NET_Core-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![HTML5](https://img.shields.io/badge/HTML5-E34F26?style=for-the-badge&logo=html5&logoColor=white)
![CSS3](https://img.shields.io/badge/CSS3-1572B6?style=for-the-badge&logo=css3&logoColor=white)
![JavaScript](https://img.shields.io/badge/JavaScript-F7DF1E?style=for-the-badge&logo=javascript&logoColor=black)
![SQL Server](https://img.shields.io/badge/SQL_Server-CC2927?style=for-the-badge&logo=microsoftsqlserver&logoColor=white)

<br/>

![GitHub repo size](https://img.shields.io/github/repo-size/emrecuni/ECOM?style=flat-square&color=512BD4)
![GitHub last commit](https://img.shields.io/github/last-commit/emrecuni/ECOM?style=flat-square&color=239120)
![GitHub commit activity](https://img.shields.io/github/commit-activity/m/emrecuni/ECOM?style=flat-square&color=E34F26)
![GitHub top language](https://img.shields.io/github/languages/top/emrecuni/ECOM?style=flat-square&color=CC2927)

<br/>

> Kullanıcı dostu arayüzü ve güçlü altyapısıyla tam kapsamlı bir online alışveriş deneyimi sunan ASP.NET Core MVC tabanlı e-ticaret uygulaması.

</div>

---

## 📋 İçindekiler

- [✨ Özellikler](#-özellikler)
- [🛠️ Teknolojiler](#️-teknolojiler)
- [📁 Proje Yapısı](#-proje-yapısı)
- [⚙️ Kurulum](#️-kurulum)
- [🚀 Kullanım](#-kullanım)
- [👤 Geliştirici](#-geliştirici)

---

## ✨ Özellikler

<div align="center">

| 🛍️ Alışveriş | 👤 Kullanıcı | 
|:---:|:---:|
| Ürün Listeleme & Arama | Kayıt & Giriş |
| Ürün Detay Sayfası | Profil Yönetimi |
| Sepet Yönetimi | Sipariş Geçmişi |
| Güvenli Ödeme | Favori Ürünler |
| Kategori Filtreleme | Adres Yönetimi |

</div>

---

## 🛠️ Teknolojiler

```
Backend    → C# · ASP.NET Core MVC · Entity Framework Core
Frontend   → HTML5 · CSS3 · JavaScript · Bootstrap
Veritabanı → Microsoft SQL Server / LocalDB
Mimari     → MVC · Repository Pattern · Dependency Injection
Araçlar    → Visual Studio 2022 · Git
```

---

## 📁 Proje Yapısı

```
📦 ECOM
├── 📂 ECOM/
│   ├── 📂 Controllers/        # İstek yönetimi
│   │   ├── HomeController.cs
│   │   ├── ProductController.cs
│   │   ├── CartController.cs
│   │   └── AdminController.cs
│   ├── 📂 Models/             # Veri modelleri & ViewModels
│   │   ├── Product.cs
│   │   ├── Category.cs
│   │   ├── Order.cs
│   │   └── ApplicationUser.cs
│   ├── 📂 Views/              # Razor görünümleri
│   │   ├── Home/
│   │   ├── Product/
│   │   ├── Cart/
│   │   └── Shared/
│   ├── 📂 wwwroot/            # Statik dosyalar
│   │   ├── css/
│   │   ├── js/
│   │   └── images/
│   ├── 📂 Data/               # Veritabanı context & migration
│   └── 📄 Program.cs
├── 📄 ECOM.sln
└── 📄 .gitignore
```

---

## ⚙️ Kurulum

### Ön Gereksinimler

![.NET](https://img.shields.io/badge/.NET_6%2B-512BD4?style=flat-square&logo=dotnet&logoColor=white)
![Visual Studio](https://img.shields.io/badge/Visual_Studio_2022-5C2D91?style=flat-square&logo=visualstudio&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL_Server-CC2927?style=flat-square&logo=microsoftsqlserver&logoColor=white)

### 1️⃣ Repoyu Klonla

```bash
git clone https://github.com/emrecuni/ECOM.git
cd ECOM
```

### 2️⃣ Bağımlılıkları Yükle

```bash
dotnet restore
```

### 3️⃣ Veritabanı Ayarları

`appsettings.json` dosyasındaki bağlantı dizesini güncelle:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=ECOM;Trusted_Connection=True;"
  }
}
```

### 4️⃣ Migration Uygula

```bash
dotnet ef database update
```

### 5️⃣ Uygulamayı Çalıştır

```bash
dotnet run
```

> 🌐 Uygulama `https://localhost:5001` adresinde çalışmaya başlayacak.

---

## 🚀 Kullanım

<table>
  <tr>
    <th>👥 Kullanıcı Rolü</th>
    <th>🔑 Erişim</th>
    <th>📌 Açıklama</th>
  </tr>
  <tr>
    <td><strong>Misafir</strong></td>
    <td>Genel</td>
    <td>Ürünleri görüntüleyebilir, arama yapabilir</td>
  </tr>
  <tr>
    <td><strong>Kullanıcı</strong></td>
    <td>Kayıt Sonrası</td>
    <td>Sepet, sipariş ve profil yönetimi</td>
  </tr>
  <tr>
    <td><strong>Admin</strong></td>
    <td>/Admin</td>
    <td>Tüm yönetim paneline tam erişim</td>
  </tr>
</table>

---

## 🤝 Katkıda Bulunma

Katkılarınızı bekliyoruz! 🎉

```bash
# 1. Fork'la
# 2. Feature branch oluştur
git checkout -b feature/harika-ozellik

# 3. Değişikliklerini commit'le
git commit -m "✨ Harika özellik eklendi"

# 4. Branch'i push'la
git push origin feature/harika-ozellik

# 5. Pull Request aç
```

---

<div align="center">

## 👤 Geliştirici

**Emre Cuni**

[![GitHub](https://img.shields.io/badge/GitHub-181717?style=for-the-badge&logo=github&logoColor=white)](https://github.com/emrecuni)

---

![Wave](https://raw.githubusercontent.com/mayhemantt/mayhemantt/Update/svg/Bottom.svg)

</div>
