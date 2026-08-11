# Teknik Otomasyon Operasyon ve Bakım Yönetim Sistemi

Teknik Otomasyon Operasyon ve Bakım Yönetim Sistemi; tesis ekipmanlarının, arıza kayıtlarının ve planlı bakım süreçlerinin merkezi olarak takip edilebilmesi için geliştirilmiş bir staj projesidir.

Proje; ASP.NET Core Web API backend, PostgreSQL veritabanı ve React TypeScript frontend yapısından oluşur. Arayüz tarafında operasyon, varlık yönetimi ve bakım yönetimi ekranları tek yönetim paneli içinde çalışır.

## Özellikler

| Modül | Kapsam |
|---|---|
| Kimlik doğrulama | JWT tabanlı login, rol bazlı yetkilendirme, demo kullanıcılar |
| Varlık yönetimi | Lokasyon, teknik sistem ve ekipman listeleme, ekipman detayı, lokasyon detayı |
| Arıza yönetimi | Arıza listesi, yeni arıza kaydı, detay, atama, not, durum güncelleme, çözme ve kapatma |
| Bakım yönetimi | Bakım planı oluşturma, plan listeleme, bakım başlatma, tamamlama ve bakım geçmişi |
| Kullanıcı deneyimi | Sidebar navigasyon, modern font yapısı, ekran geçiş animasyonları, responsive tablolar |

## Teknoloji Stack

| Katman | Teknoloji |
|---|---|
| Backend | ASP.NET Core Web API, .NET 9 |
| ORM | Entity Framework Core |
| Database | PostgreSQL |
| Auth | JWT Bearer Authentication |
| Frontend | React, TypeScript, Vite |
| Stil | Tailwind CSS, Material Symbols |
| Lint | oxlint |

## Proje Yapısı

```text
stajproject/
  back/
    TechOps.Api/
      Controllers/
      Data/
      Entities/
      Enums/
      Migrations/
      Models/
      Security/
      Services/
    TechOpsManagementSystem.sln
  front/
    src/
      App.tsx
      EquipmentView.tsx
      FaultsView.tsx
      MaintenanceView.tsx
      index.css
```

## Gereksinimler

| Araç | Sürüm |
|---|---|
| .NET SDK | 9.x |
| Node.js | 20.x veya üstü önerilir |
| PostgreSQL | 18 local kurulumda test edildi |
| npm | Node ile gelen sürüm yeterlidir |

## Backend Kurulumu

Backend dizinine geçin:

```powershell
cd stajproject/back/TechOps.Api
```

NuGet paketlerini yükleyin:

```powershell
dotnet restore
```

EF Core local tool manifestini yükleyin:

```powershell
cd ../
dotnet tool restore
cd TechOps.Api
```

PostgreSQL veritabanını migration ile hazırlayın:

```powershell
dotnet ef database update
```

API projesini çalıştırın:

```powershell
dotnet run --urls http://localhost:5088
```

Backend servisleri:

| Servis | URL |
|---|---|
| API | `http://localhost:5088` |
| Swagger | `http://localhost:5088/swagger/index.html` |
| Health | `http://localhost:5088/api/health` |

## Frontend Kurulumu

Frontend dizinine geçin:

```powershell
cd stajproject/front
```

Paketleri yükleyin:

```powershell
npm install
```

Frontend geliştirme sunucusunu başlatın:

```powershell
npm run dev
```

Frontend URL:

```text
http://localhost:5173
```

## Demo Giriş

| Alan | Değer |
|---|---|
| Kullanıcı adı | `admin` |
| Şifre | `Demo123!` |

Demo kullanıcılar seed data üzerinden oluşturulur. Geliştirme ortamındaki JWT secret ve bağlantı ayarları local kullanım içindir; production ortamında environment variable veya user-secrets kullanılmalıdır.

## Önemli API Endpointleri

### Auth

| Method | Endpoint | Açıklama |
|---|---|---|
| `POST` | `/api/auth/login` | Kullanıcı girişi yapar ve token döner |
| `GET` | `/api/auth/me` | Giriş yapan kullanıcı profilini döner |

### Varlık Yönetimi

| Method | Endpoint | Açıklama |
|---|---|---|
| `GET` | `/api/locations` | Lokasyonları listeler |
| `GET` | `/api/technical-systems` | Teknik sistemleri listeler |
| `GET` | `/api/equipment` | Ekipmanları listeler |
| `GET` | `/api/equipment/{id}` | Ekipman detayını getirir |
| `POST` | `/api/equipment` | Yeni ekipman oluşturur |
| `PUT` | `/api/equipment/{id}` | Ekipman bilgilerini günceller |

### Arıza Yönetimi

| Method | Endpoint | Açıklama |
|---|---|---|
| `GET` | `/api/faults` | Arızaları filtreli listeler |
| `GET` | `/api/faults/{id}` | Arıza detayını getirir |
| `POST` | `/api/faults` | Yeni arıza kaydı oluşturur |
| `POST` | `/api/faults/{id}/assign` | Teknik personel atar |
| `POST` | `/api/faults/{id}/actions` | İşlem notu ekler |
| `PATCH` | `/api/faults/{id}/status` | Arıza durumunu günceller |
| `POST` | `/api/faults/{id}/resolve` | Arızayı çözüldü durumuna alır |
| `POST` | `/api/faults/{id}/close` | Çözülen arızayı kapatır |

### Bakım Yönetimi

| Method | Endpoint | Açıklama |
|---|---|---|
| `GET` | `/api/maintenance/plans` | Bakım planlarını listeler |
| `GET` | `/api/maintenance/plans/{id}` | Bakım planı detayını getirir |
| `POST` | `/api/maintenance/plans` | Yeni bakım planı oluşturur |
| `PUT` | `/api/maintenance/plans/{id}` | Planlandı durumundaki bakım planını günceller |
| `POST` | `/api/maintenance/plans/{id}/start` | Bakımı başlatır |
| `POST` | `/api/maintenance/plans/{id}/complete` | Bakımı tamamlar ve geçmiş kaydı oluşturur |
| `GET` | `/api/maintenance/records` | Bakım geçmişini listeler |
| `GET` | `/api/maintenance/responsible-users` | Bakımdan sorumlu kullanıcıları listeler |

## Durum Akışları

Arıza yönetimi durumları:

```text
New -> Assigned -> InReview -> InProgress -> Waiting -> Resolved -> Closed
```

Bakım yönetimi durumları:

```text
Planned -> Started -> Completed
```

## Kontrol Komutları

Backend build:

```powershell
cd stajproject/back/TechOps.Api
dotnet build
```

Pending migration kontrolü:

```powershell
dotnet ef migrations has-pending-model-changes
```

Frontend build:

```powershell
cd stajproject/front
npm run build
```

Frontend lint:

```powershell
npm run lint
```

## Notlar

`Planlama/` klasörü sürüm kontrolüne dahil edilmemiştir. Bu repo yalnızca çalışan proje kodunu, migration dosyalarını ve gerekli yapılandırma dosyalarını içerir.

`node_modules`, `dist`, `bin` ve `obj` gibi dependency veya build çıktıları `.gitignore` ile hariç tutulmuştur.
