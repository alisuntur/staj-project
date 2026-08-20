# TechOps Frontend

React, TypeScript, Vite ve Tailwind CSS ile geliştirilen TechOps O&M yönetim paneli arayüzüdür.

## Komutlar

```powershell
npm install
$env:VITE_API_BASE_URL="http://localhost:5162"
npm run dev -- --host 127.0.0.1 --port 5173
npm run build
npm run lint
```

## Ana Ekranlar

| Ekran | Kapsam |
|---|---|
| Dashboard | KPI, trend, kritik arıza, operasyon sağlığı |
| Operasyonlar | Arıza listesi, kayıt, atama, durum akışı |
| Varlık Yönetimi | Ekipman, lokasyon, operasyon geçmişi |
| Bakım | Plan, başlatma, tamamlama, geçmiş |
| Testler | Planlı/plansız test kayıtları ve ekipman test geçmişi |
| Vardiya | Devir teslim ve açık iş aktarımı |
| Raporlama | Filtreli analiz ve Excel/PDF export |
| Bildirimler | Bildirim ve aktivite merkezi |
| Yönetim | Admin kullanıcı yönetimi |

## Not

Frontend varsayılan API adresi `http://localhost:5162` olarak ayarlanmıştır. Farklı port için `VITE_API_BASE_URL` kullanın.
