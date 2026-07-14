# 📦 Araç Yönetimi Projesi - Kullanılan Paketler ve Sürümleri

Bu doküman, projede kullanılan 3. parti kütüphanelerin (NuGet paketlerinin) güncel sürümlerini kayıt altında tutmak ve olası sürüm yükseltmelerinde yaşanabilecek köklü değişiklikleri (Breaking Changes) öngörebilmek amacıyla oluşturulmuştur.

## 🛠️ Çekirdek ve Veri Katmanı Paketleri

| Paket Adı | Sürüm | Kullanıldığı Katman | Kullanım Amacı ve Notlar |
| :--- | :--- | :--- | :--- |
| **AutoMapper** | `16.2.0` | Application, Api | Entity'leri DTO'lara dönüştürmek için. **Dikkat:** 13.0 sürümünden sonra sisteme kayıt mantığı değişti. `typeof` yerine `cfg => cfg.AddProfile<T>()` Action bloğu kullanılmalı. |
| **Npgsql.EntityFrameworkCore.PostgreSQL** | `9.0.4` | Infrastructure, Api | PostgreSQL veritabanı bağlantısı ve EF Core entegrasyonu sağlamak için. |
| **Microsoft.EntityFrameworkCore** | `9.0.1` | Infrastructure | ORM (Object-Relational Mapping) işlemleri ve veritabanı sorguları için ana kütüphane. |
| **Microsoft.EntityFrameworkCore.Design** | `9.0.4` & `9.0.1` | Api, Infrastructure | Code-First migration işlemlerini CLI üzerinden yürütebilmek için. *(Not: Katmanlar arası minor sürüm farkı var, ileride 9.0.4'te eşitlenebilir).* |
| **Swashbuckle.AspNetCore** | `10.2.3` | Api | Geliştirme ortamında (Development) Swagger UI / OpenAPI arayüzü sağlamak için. |

---

## 🧪 Test Katmanı Paketleri (UnitTests)

Birim testleri katmanında (.NET 9.0 altyapısı ile birlikte) kullanılan doğrulama ve test araçları:

| Paket Adı | Sürüm | Kullanım Amacı |
| :--- | :--- | :--- |
| **xunit** | `2.9.2` | Testleri yazmak için kullanılan ana test framework'ü. |
| **xunit.runner.visualstudio** | `2.8.2` | Testlerin Visual Studio / VS Code Test Explorer üzerinden çalıştırılabilmesi için. |
| **Microsoft.NET.Test.Sdk** | `17.12.0` | Projenin bir test projesi olarak derlenmesini sağlayan ana SDK. |
| **coverlet.collector** | `6.0.2` | Yazılan testlerin "Kod Kapsamını" (Code Coverage - yüzde kaçının test edildiğini) ölçmek için. |

---

## ⚠️ Sürüm Güncelleme (Upgrade) Rehberi

Bir paketin sürümünü yükseltmeden önce:
1. **Majör Güncellemeler (Örn: 9.x.x -> 10.x.x):** Büyük ihtimalle Breaking Change içerir. Migration Guide okunmalıdır.
2. **Minör Güncellemeler:** Yeni özellikler eklenir, test edilerek geçilmelidir.

**Sürümleri Kontrol Etme Komutu:**
```bash
dotnet list package