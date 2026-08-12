import { useEffect, useState } from 'react'

type ReportsViewProps = {
  apiBaseUrl: string
  token: string
}

type FaultPriority = 'Low' | 'Medium' | 'High' | 'Critical'
type FaultStatus = 'New' | 'Assigned' | 'InReview' | 'InProgress' | 'Waiting' | 'Resolved' | 'Closed'
type MaintenanceStatus = 'Planned' | 'Started' | 'Completed' | 'Delayed' | 'Cancelled'
type TestResult = 'Success' | 'Failed' | 'ConditionalSuccess' | 'RetestRequired'
type EquipmentStatus = 'Active' | 'Passive' | 'Maintenance' | 'Faulted'

type LocationItem = {
  id: string
  code: string
  name: string
  type: string
  isActive: boolean
}

type TechnicalSystemItem = {
  id: string
  code: string
  name: string
  isActive: boolean
}

type EquipmentListItem = {
  id: string
  code: string
  name: string
  locationId: string
  locationName: string
  technicalSystemId: string
  technicalSystemName: string
  status: EquipmentStatus
  isActive: boolean
}

type ReportFilters = {
  from: string
  to: string
  locationId: string
  technicalSystemId: string
  equipmentId: string
  priority: string
  status: string
}

type ApiFilters = {
  from?: string | null
  to?: string | null
  locationId?: string | null
  technicalSystemId?: string | null
  equipmentId?: string | null
  priority?: string | null
  status?: string | null
}

type ReportSummary = {
  faultCount: number
  openFaultCount: number
  criticalFaultCount: number
  averageResolutionHours: number
  maintenanceCount: number
  maintenanceCompletionRate: number
  testCount: number
  testSuccessRate: number
  faultedEquipmentCount: number
}

type ReportChartPoint = {
  id: string
  label: string
  value: number
}

type RepeatedFault = {
  equipmentId: string
  equipmentCode: string
  equipmentName: string
  locationName: string
  technicalSystemName: string
  faultCount: number
  lastFaultAt?: string | null
}

type ReportFaultRow = {
  id: string
  faultNo: string
  equipmentCode: string
  equipmentName: string
  locationName: string
  technicalSystemName: string
  priority: FaultPriority
  status: FaultStatus
  createdAt: string
  resolvedAt?: string | null
  closedAt?: string | null
  resolutionHours?: number | null
}

type ReportMaintenanceRow = {
  id: string
  planNo: string
  equipmentCode: string
  equipmentName: string
  locationName: string
  technicalSystemName: string
  maintenanceType: string
  priority: FaultPriority
  status: MaintenanceStatus
  plannedDate: string
  completedAt?: string | null
}

type ReportTestRow = {
  id: string
  equipmentCode: string
  equipmentName: string
  locationName: string
  technicalSystemName: string
  testType: string
  result: TestResult
  testDate: string
  durationMinutes?: number | null
}

type OperationsReport = {
  filters: ApiFilters
  summary: ReportSummary
  faultsByEquipment: ReportChartPoint[]
  faultsByLocation: ReportChartPoint[]
  repeatedFaults: RepeatedFault[]
  faultRows: ReportFaultRow[]
  maintenanceRows: ReportMaintenanceRow[]
  testRows: ReportTestRow[]
  generatedAt: string
}

const faultPriorities: FaultPriority[] = ['Low', 'Medium', 'High', 'Critical']
const faultStatuses: FaultStatus[] = ['New', 'Assigned', 'InReview', 'InProgress', 'Waiting', 'Resolved', 'Closed']

const priorityLabels: Record<FaultPriority, string> = {
  Low: 'Düşük',
  Medium: 'Orta',
  High: 'Yüksek',
  Critical: 'Kritik',
}

const statusLabels: Record<FaultStatus, string> = {
  New: 'Yeni',
  Assigned: 'Atandı',
  InReview: 'İnceleniyor',
  InProgress: 'Müdahale Ediliyor',
  Waiting: 'Beklemede',
  Resolved: 'Çözüldü',
  Closed: 'Kapatıldı',
}

const maintenanceStatusLabels: Record<MaintenanceStatus, string> = {
  Planned: 'Planlandı',
  Started: 'Başladı',
  Completed: 'Tamamlandı',
  Delayed: 'Gecikti',
  Cancelled: 'İptal',
}

const testResultLabels: Record<TestResult, string> = {
  Success: 'Başarılı',
  Failed: 'Başarısız',
  ConditionalSuccess: 'Şartlı Başarılı',
  RetestRequired: 'Tekrar Test Gerekli',
}

const emptyReport: OperationsReport = {
  filters: {},
  summary: {
    faultCount: 0,
    openFaultCount: 0,
    criticalFaultCount: 0,
    averageResolutionHours: 0,
    maintenanceCount: 0,
    maintenanceCompletionRate: 0,
    testCount: 0,
    testSuccessRate: 0,
    faultedEquipmentCount: 0,
  },
  faultsByEquipment: [],
  faultsByLocation: [],
  repeatedFaults: [],
  faultRows: [],
  maintenanceRows: [],
  testRows: [],
  generatedAt: '',
}

const defaultFilters: ReportFilters = {
  from: '',
  to: '',
  locationId: '',
  technicalSystemId: '',
  equipmentId: '',
  priority: '',
  status: '',
}

function ReportsView({ apiBaseUrl, token }: ReportsViewProps) {
  const [locations, setLocations] = useState<LocationItem[]>([])
  const [technicalSystems, setTechnicalSystems] = useState<TechnicalSystemItem[]>([])
  const [equipment, setEquipment] = useState<EquipmentListItem[]>([])
  const [filters, setFilters] = useState<ReportFilters>(defaultFilters)
  const [report, setReport] = useState<OperationsReport>(emptyReport)
  const [isLoading, setIsLoading] = useState(false)
  const [message, setMessage] = useState('Raporlama verileri yükleniyor...')

  const filteredEquipment = equipment.filter((item) => (!filters.locationId || item.locationId === filters.locationId) && (!filters.technicalSystemId || item.technicalSystemId === filters.technicalSystemId))
  const maxEquipmentFault = Math.max(1, ...report.faultsByEquipment.map((item) => item.value))
  const maxLocationFault = Math.max(1, ...report.faultsByLocation.map((item) => item.value))
  const hasReportData = report.faultRows.length > 0 || report.maintenanceRows.length > 0 || report.testRows.length > 0

  useEffect(() => {
    let ignore = false

    async function loadInitialData() {
      setIsLoading(true)
      try {
        const [locationData, systemData, equipmentData, reportData] = await Promise.all([
          reportRequest<LocationItem[]>(apiBaseUrl, token, '/api/locations'),
          reportRequest<TechnicalSystemItem[]>(apiBaseUrl, token, '/api/technical-systems'),
          reportRequest<EquipmentListItem[]>(apiBaseUrl, token, '/api/equipment?isActive=true'),
          reportRequest<OperationsReport>(apiBaseUrl, token, buildReportPath(defaultFilters)),
        ])

        if (ignore) {
          return
        }

        setLocations(locationData.filter((item) => item.isActive))
        setTechnicalSystems(systemData.filter((item) => item.isActive))
        setEquipment(equipmentData.filter((item) => item.isActive))
        setReport(reportData)
        setMessage(`Rapor hazırlandı: ${formatDateTime(reportData.generatedAt)}`)
      } catch (error) {
        if (!ignore) {
          setMessage(error instanceof Error ? error.message : 'Raporlama verileri alınamadı.')
        }
      } finally {
        if (!ignore) {
          setIsLoading(false)
        }
      }
    }

    void loadInitialData()

    return () => {
      ignore = true
    }
  }, [apiBaseUrl, token])

  function updateFilter<K extends keyof ReportFilters>(key: K, value: ReportFilters[K]) {
    setFilters((current) => ({
      ...current,
      [key]: value,
      equipmentId: key === 'locationId' || key === 'technicalSystemId' ? '' : current.equipmentId,
    }))
  }

  async function loadReport(nextFilters = filters, successMessage = 'Rapor filtrelere göre güncellendi.') {
    setIsLoading(true)
    try {
      const data = await reportRequest<OperationsReport>(apiBaseUrl, token, buildReportPath(nextFilters))
      setReport(data)
      setMessage(`${successMessage} Son güncelleme: ${formatDateTime(data.generatedAt)}`)
    } catch (error) {
      setMessage(error instanceof Error ? error.message : 'Rapor yenilenemedi.')
    } finally {
      setIsLoading(false)
    }
  }

  async function handleApplyFilters() {
    if (filters.from && filters.to && filters.from > filters.to) {
      setMessage('Başlangıç tarihi bitiş tarihinden büyük olamaz.')
      return
    }

    await loadReport(filters)
  }

  async function handleResetFilters() {
    setFilters(defaultFilters)
    await loadReport(defaultFilters, 'Filtreler temizlendi.')
  }

  async function handleRefresh() {
    await loadReport(filters, 'Rapor yenilendi.')
  }

  function handleExportCsv() {
    if (!report.generatedAt) {
      setMessage('CSV oluşturmak için rapor verilerinin yüklenmesi bekleniyor.')
      return
    }

    const csv = buildReportCsv(report)
    const blob = new Blob(['\ufeff', csv], { type: 'text/csv;charset=utf-8;' })
    const url = URL.createObjectURL(blob)
    const link = document.createElement('a')
    link.href = url
    link.download = `operasyon-raporu-${new Date().toISOString().slice(0, 10)}.csv`
    document.body.appendChild(link)
    link.click()
    link.remove()
    URL.revokeObjectURL(url)
    setMessage(`CSV raporu indirildi: ${formatDateTime(report.generatedAt)}`)
  }

  return (
    <section className="module-font mx-auto w-full max-w-[1600px] bg-[#FCF8FA] px-5 py-6 lg:px-6">
      <div className="mb-6 flex flex-col gap-4 md:flex-row md:items-end md:justify-between">
        <div>
          <p className="text-[11px] font-bold uppercase tracking-[0.18em] text-[#45464D]">Analiz ekranları ve rapor filtreleri</p>
          <h2 className="mt-1 text-2xl font-semibold tracking-tight text-[#1B1B1D]">Raporlama ve Veri Analizi</h2>
          <p className="mt-1 text-sm text-[#45464D]">{message}</p>
        </div>
        <div className="flex flex-wrap gap-3">
          <button className="border border-[#3755C3] px-4 py-2 text-sm font-semibold text-[#3755C3] transition-colors hover:bg-[#DDE1FF] disabled:cursor-not-allowed disabled:opacity-50" disabled={!report.generatedAt || isLoading} type="button" onClick={handleExportCsv}>CSV İndir</button>
          <button className="border border-[#76777D] px-4 py-2 text-sm font-semibold text-[#1B1B1D] transition-colors hover:bg-[#F6F3F5] disabled:cursor-not-allowed disabled:opacity-50" disabled={isLoading} type="button" onClick={handleRefresh}>Yenile</button>
        </div>
      </div>

      <section className="mb-6 rounded-lg border border-[#C6C6CD] bg-white p-4 shadow-[0px_1px_3px_rgba(15,23,42,0.08)]">
        <div className="mb-4 flex items-center justify-between border-b border-[#C6C6CD] pb-3">
          <div>
            <h3 className="text-lg font-semibold text-[#1B1B1D]">Rapor Filtreleri</h3>
            <p className="mt-1 text-[13px] text-[#45464D]">Filtreler tüm KPI, analiz ve tablo verilerini aynı anda günceller.</p>
          </div>
          <span className="material-symbols-outlined text-[#45464D]">tune</span>
        </div>
        <div className="grid gap-4 md:grid-cols-2 xl:grid-cols-7">
          <ReportField label="Başlangıç">
            <input className="report-input" type="date" value={filters.from} onChange={(event) => updateFilter('from', event.target.value)} />
          </ReportField>
          <ReportField label="Bitiş">
            <input className="report-input" type="date" value={filters.to} onChange={(event) => updateFilter('to', event.target.value)} />
          </ReportField>
          <ReportField label="Lokasyon">
            <select className="report-input" value={filters.locationId} onChange={(event) => updateFilter('locationId', event.target.value)}>
              <option value="">Tümü</option>
              {locations.map((item) => <option key={item.id} value={item.id}>{item.name}</option>)}
            </select>
          </ReportField>
          <ReportField label="Sistem">
            <select className="report-input" value={filters.technicalSystemId} onChange={(event) => updateFilter('technicalSystemId', event.target.value)}>
              <option value="">Tümü</option>
              {technicalSystems.map((item) => <option key={item.id} value={item.id}>{item.name}</option>)}
            </select>
          </ReportField>
          <ReportField label="Ekipman">
            <select className="report-input" value={filters.equipmentId} onChange={(event) => updateFilter('equipmentId', event.target.value)}>
              <option value="">Tümü</option>
              {filteredEquipment.map((item) => <option key={item.id} value={item.id}>{item.code} - {item.name}</option>)}
            </select>
          </ReportField>
          <ReportField label="Öncelik">
            <select className="report-input" value={filters.priority} onChange={(event) => updateFilter('priority', event.target.value)}>
              <option value="">Tümü</option>
              {faultPriorities.map((item) => <option key={item} value={item}>{priorityLabels[item]}</option>)}
            </select>
          </ReportField>
          <ReportField label="Durum">
            <select className="report-input" value={filters.status} onChange={(event) => updateFilter('status', event.target.value)}>
              <option value="">Tümü</option>
              {faultStatuses.map((item) => <option key={item} value={item}>{statusLabels[item]}</option>)}
            </select>
          </ReportField>
        </div>
        <div className="mt-4 flex flex-wrap justify-end gap-3">
          <button className="border border-[#76777D] px-4 py-2 text-sm font-semibold text-[#45464D] transition-colors hover:bg-[#F6F3F5] disabled:cursor-not-allowed disabled:opacity-50" disabled={isLoading} type="button" onClick={() => void handleResetFilters()}>Filtreleri Temizle</button>
          <button className="bg-black px-5 py-2 text-sm font-semibold text-white transition-colors hover:bg-[#131B2E] disabled:cursor-not-allowed disabled:bg-[#76777D]" disabled={isLoading} type="button" onClick={() => void handleApplyFilters()}>Filtrele</button>
        </div>
      </section>

      <div className="mb-6 grid grid-cols-1 gap-4 md:grid-cols-2 xl:grid-cols-4">
        <ReportKpiCard helper="Filtreye uyan toplam kayıt" icon="report" label="Arıza Sayısı" tone="blue" value={report.summary.faultCount} />
        <ReportKpiCard helper="Çözülmemiş veya kapatılmamış" icon="pending_actions" label="Açık Arıza" tone="neutral" value={report.summary.openFaultCount} />
        <ReportKpiCard helper="Acil takip gerektirir" icon="warning" label="Kritik Arıza" tone="danger" value={report.summary.criticalFaultCount} />
        <ReportKpiCard helper="Çözülen/kapanan arızalar" icon="timer" label="Ort. Çözüm Saati" tone="navy" value={report.summary.averageResolutionHours} />
      </div>

      <div className="mb-6 grid grid-cols-1 gap-4 lg:grid-cols-12">
        <section className="rounded-lg border border-[#C6C6CD] bg-white p-4 shadow-[0px_1px_3px_rgba(15,23,42,0.08)] lg:col-span-4">
          <h3 className="mb-3 text-lg font-semibold text-[#1B1B1D]">Operasyon Oranları</h3>
          <RateLine label="Bakım Tamamlama" rate={report.summary.maintenanceCompletionRate} text={`${report.summary.maintenanceCount} bakım planı`} tone="blue" />
          <RateLine label="Test Başarı" rate={report.summary.testSuccessRate} text={`${report.summary.testCount} test kaydı`} tone="green" />
          <RateLine label="Arızalı Ekipman" rate={report.summary.faultedEquipmentCount > 0 ? 100 : 0} text={`${report.summary.faultedEquipmentCount} ekipman`} tone="danger" />
        </section>

        <section className="rounded-lg border border-[#C6C6CD] bg-white p-4 shadow-[0px_1px_3px_rgba(15,23,42,0.08)] lg:col-span-4">
          <h3 className="mb-3 text-lg font-semibold text-[#1B1B1D]">En Fazla Arıza Veren Ekipman</h3>
          <div className="space-y-3">
            {report.faultsByEquipment.map((item) => <HorizontalBar key={item.id} label={item.label} max={maxEquipmentFault} value={item.value} />)}
            {report.faultsByEquipment.length === 0 ? <EmptyText text="Filtreye uygun ekipman arıza dağılımı bulunamadı." /> : null}
          </div>
        </section>

        <section className="rounded-lg border border-[#C6C6CD] bg-white p-4 shadow-[0px_1px_3px_rgba(15,23,42,0.08)] lg:col-span-4">
          <h3 className="mb-3 text-lg font-semibold text-[#1B1B1D]">Lokasyon Bazlı Arıza</h3>
          <div className="space-y-3">
            {report.faultsByLocation.map((item) => <HorizontalBar key={item.id} label={item.label} max={maxLocationFault} value={item.value} />)}
            {report.faultsByLocation.length === 0 ? <EmptyText text="Filtreye uygun lokasyon dağılımı bulunamadı." /> : null}
          </div>
        </section>
      </div>

      <section className="mb-6 overflow-hidden rounded-lg border border-[#C6C6CD] bg-white shadow-[0px_1px_3px_rgba(15,23,42,0.08)]">
        <ReportSectionHeader icon="repeat" title="Tekrarlayan Arızalar" />
        <div className="overflow-x-auto">
          <table className="w-full border-collapse text-left">
            <thead><tr className="report-table-head"><th className="p-3">Ekipman</th><th className="p-3">Lokasyon</th><th className="p-3">Sistem</th><th className="p-3">Arıza Sayısı</th><th className="p-3">Son Arıza</th></tr></thead>
            <tbody className="text-[13px] text-[#1B1B1D]">
              {report.repeatedFaults.map((item, index) => (
                <tr key={item.equipmentId} className={tableRowClass(index)}><td className="p-3"><span className="block font-mono font-bold">{item.equipmentCode}</span><span className="text-[#45464D]">{item.equipmentName}</span></td><td className="p-3">{item.locationName}</td><td className="p-3">{item.technicalSystemName}</td><td className="p-3 font-mono font-bold text-[#BA1A1A]">{item.faultCount}</td><td className="p-3 text-[#45464D]">{item.lastFaultAt ? formatDateTime(item.lastFaultAt) : '-'}</td></tr>
              ))}
              {report.repeatedFaults.length === 0 ? <tr><td className="p-4 text-sm text-[#45464D]" colSpan={5}>Tekrarlayan arıza kaydı bulunamadı.</td></tr> : null}
            </tbody>
          </table>
        </div>
      </section>

      <div className="grid grid-cols-1 gap-6 xl:grid-cols-3">
        <ReportTable title="Arıza Raporu" icon="report_problem" emptyText="Filtreye uygun arıza kaydı yok.">
          <thead><tr className="report-table-head"><th className="p-3">Arıza</th><th className="p-3">Ekipman</th><th className="p-3">Durum</th><th className="p-3">Çözüm</th></tr></thead>
          <tbody className="text-[13px] text-[#1B1B1D]">
            {report.faultRows.map((row, index) => (
              <tr key={row.id} className={tableRowClass(index)}><td className="p-3"><span className="block font-mono font-bold">{row.faultNo}</span><Badge label={priorityLabels[row.priority]} tone={row.priority === 'Critical' ? 'danger' : row.priority === 'High' ? 'warning' : 'default'} /></td><td className="p-3"><span className="block font-semibold">{row.equipmentName}</span><span className="font-mono text-xs text-[#45464D]">{row.equipmentCode}</span></td><td className="p-3"><Badge label={statusLabels[row.status]} tone={row.status === 'Closed' || row.status === 'Resolved' ? 'success' : 'default'} /></td><td className="p-3 font-mono text-xs text-[#45464D]">{row.resolutionHours == null ? '-' : `${row.resolutionHours} sa`}</td></tr>
            ))}
            {report.faultRows.length === 0 ? <tr><td className="p-4 text-sm text-[#45464D]" colSpan={4}>Filtreye uygun arıza kaydı yok.</td></tr> : null}
          </tbody>
        </ReportTable>

        <ReportTable title="Bakım Raporu" icon="build" emptyText="Filtreye uygun bakım kaydı yok.">
          <thead><tr className="report-table-head"><th className="p-3">Plan</th><th className="p-3">Ekipman</th><th className="p-3">Durum</th><th className="p-3">Tarih</th></tr></thead>
          <tbody className="text-[13px] text-[#1B1B1D]">
            {report.maintenanceRows.map((row, index) => (
              <tr key={row.id} className={tableRowClass(index)}><td className="p-3"><span className="block font-mono font-bold">{row.planNo}</span><span className="text-xs text-[#45464D]">{row.maintenanceType}</span></td><td className="p-3"><span className="block font-semibold">{row.equipmentName}</span><span className="font-mono text-xs text-[#45464D]">{row.equipmentCode}</span></td><td className="p-3"><Badge label={maintenanceStatusLabels[row.status]} tone={row.status === 'Completed' ? 'success' : row.priority === 'Critical' ? 'danger' : 'default'} /></td><td className="p-3 font-mono text-xs text-[#45464D]">{formatDate(row.plannedDate)}</td></tr>
            ))}
            {report.maintenanceRows.length === 0 ? <tr><td className="p-4 text-sm text-[#45464D]" colSpan={4}>Filtreye uygun bakım kaydı yok.</td></tr> : null}
          </tbody>
        </ReportTable>

        <ReportTable title="Test Raporu" icon="biotech" emptyText="Filtreye uygun test kaydı yok.">
          <thead><tr className="report-table-head"><th className="p-3">Test</th><th className="p-3">Ekipman</th><th className="p-3">Sonuç</th><th className="p-3">Tarih</th></tr></thead>
          <tbody className="text-[13px] text-[#1B1B1D]">
            {report.testRows.map((row, index) => (
              <tr key={row.id} className={tableRowClass(index)}><td className="p-3"><span className="block font-semibold">{row.testType}</span><span className="font-mono text-xs text-[#45464D]">{row.durationMinutes ? `${row.durationMinutes} dk` : '-'}</span></td><td className="p-3"><span className="block font-semibold">{row.equipmentName}</span><span className="font-mono text-xs text-[#45464D]">{row.equipmentCode}</span></td><td className="p-3"><Badge label={testResultLabels[row.result]} tone={row.result === 'Success' || row.result === 'ConditionalSuccess' ? 'success' : 'danger'} /></td><td className="p-3 font-mono text-xs text-[#45464D]">{formatDateTime(row.testDate)}</td></tr>
            ))}
            {report.testRows.length === 0 ? <tr><td className="p-4 text-sm text-[#45464D]" colSpan={4}>Filtreye uygun test kaydı yok.</td></tr> : null}
          </tbody>
        </ReportTable>
      </div>

      {!hasReportData ? <div className="mt-6 rounded-lg border border-[#C6C6CD] bg-white p-5 text-sm text-[#45464D]">Seçili filtrelere uygun arıza, bakım veya test kaydı bulunamadı. Filtreleri temizleyerek tüm operasyon raporunu görüntüleyebilirsiniz.</div> : null}
    </section>
  )
}

async function reportRequest<T>(apiBaseUrl: string, token: string, path: string): Promise<T> {
  const response = await fetch(`${apiBaseUrl}${path}`, {
    headers: { Authorization: `Bearer ${token}` },
  })
  const text = await response.text()
  const payload = text ? JSON.parse(text) : null

  if (!response.ok) {
    throw new Error((payload as { message?: string } | null)?.message ?? `API isteği başarısız: ${response.status}`)
  }

  return payload as T
}

function buildReportPath(filters: ReportFilters) {
  const params = new URLSearchParams()
  Object.entries(filters).forEach(([key, value]) => {
    if (value) {
      params.set(key, value)
    }
  })

  return params.size ? `/api/reports/operations?${params.toString()}` : '/api/reports/operations'
}

function buildReportCsv(report: OperationsReport) {
  const rows: string[][] = [
    ['Operasyon Raporu'],
    ['Olusturma Zamani', formatDateTime(report.generatedAt)],
    [],
    ['Ozet', 'Deger'],
    ['Ariza Sayisi', report.summary.faultCount.toString()],
    ['Acik Ariza', report.summary.openFaultCount.toString()],
    ['Kritik Ariza', report.summary.criticalFaultCount.toString()],
    ['Ortalama Cozum Saati', report.summary.averageResolutionHours.toString()],
    ['Bakim Tamamlama Orani', `%${report.summary.maintenanceCompletionRate}`],
    ['Test Basari Orani', `%${report.summary.testSuccessRate}`],
    ['Arizali Ekipman', report.summary.faultedEquipmentCount.toString()],
    [],
    ['En Fazla Ariza Veren Ekipman', 'Ariza Sayisi'],
    ...report.faultsByEquipment.map((item) => [item.label, item.value.toString()]),
    [],
    ['Lokasyon', 'Ariza Sayisi'],
    ...report.faultsByLocation.map((item) => [item.label, item.value.toString()]),
    [],
    ['Tekrarlayan Arizalar', 'Lokasyon', 'Sistem', 'Ariza Sayisi', 'Son Ariza'],
    ...report.repeatedFaults.map((item) => [`${item.equipmentCode} - ${item.equipmentName}`, item.locationName, item.technicalSystemName, item.faultCount.toString(), item.lastFaultAt ? formatDateTime(item.lastFaultAt) : '']),
    [],
    ['Ariza No', 'Ekipman', 'Lokasyon', 'Sistem', 'Oncelik', 'Durum', 'Olusturma', 'Cozum Saati'],
    ...report.faultRows.map((item) => [item.faultNo, `${item.equipmentCode} - ${item.equipmentName}`, item.locationName, item.technicalSystemName, priorityLabels[item.priority], statusLabels[item.status], formatDateTime(item.createdAt), item.resolutionHours?.toString() ?? '']),
    [],
    ['Bakim No', 'Ekipman', 'Lokasyon', 'Sistem', 'Tur', 'Oncelik', 'Durum', 'Plan Tarihi'],
    ...report.maintenanceRows.map((item) => [item.planNo, `${item.equipmentCode} - ${item.equipmentName}`, item.locationName, item.technicalSystemName, item.maintenanceType, priorityLabels[item.priority], maintenanceStatusLabels[item.status], formatDate(item.plannedDate)]),
    [],
    ['Test', 'Ekipman', 'Lokasyon', 'Sistem', 'Sonuc', 'Tarih', 'Sure'],
    ...report.testRows.map((item) => [item.testType, `${item.equipmentCode} - ${item.equipmentName}`, item.locationName, item.technicalSystemName, testResultLabels[item.result], formatDateTime(item.testDate), item.durationMinutes?.toString() ?? '']),
  ]

  return rows.map((row) => row.map(csvCell).join(';')).join('\n')
}

function ReportField({ children, label }: { children: React.ReactNode; label: string }) {
  return <label className="block text-[11px] font-bold uppercase tracking-wide text-[#1B1B1D]">{label}<div className="mt-2">{children}</div></label>
}

function ReportKpiCard({ helper, icon, label, tone, value }: { helper: string; icon: string; label: string; tone: 'blue' | 'danger' | 'neutral' | 'navy'; value: number }) {
  const iconClass = tone === 'danger' ? 'bg-[#FFDAD6] text-[#BA1A1A]' : tone === 'navy' ? 'bg-[#BEC6E0] text-[#131B2E]' : tone === 'blue' ? 'bg-[#DDE1FF] text-[#3755C3]' : 'bg-[#E4E2E4] text-[#45464D]'
  const valueClass = tone === 'danger' ? 'text-[#BA1A1A]' : 'text-[#1B1B1D]'

  return <section className={`${tone === 'danger' ? 'border-l-4 border-l-[#BA1A1A]' : ''} rounded-lg border border-[#C6C6CD] bg-white p-4 shadow-[0px_1px_3px_rgba(15,23,42,0.08)]`}><div className="flex items-center justify-between"><span className="text-[11px] font-bold uppercase tracking-wide text-[#45464D]">{label}</span><span className={`${iconClass} flex h-8 w-8 items-center justify-center rounded-full`}><span className="material-symbols-outlined text-[18px]">{icon}</span></span></div><div className={`${valueClass} mt-2 font-mono text-[32px] font-bold leading-10 tracking-tight`}>{value}</div><p className="mt-1 text-[13px] text-[#45464D]">{helper}</p></section>
}

function RateLine({ label, rate, text, tone }: { label: string; rate: number; text: string; tone: 'blue' | 'green' | 'danger' }) {
  const fillClass = tone === 'green' ? 'bg-[#16A34A]' : tone === 'danger' ? 'bg-[#BA1A1A]' : 'bg-[#3755C3]'

  return <div className="border-t border-[#C6C6CD] py-3 first:border-t-0"><div className="mb-2 flex items-center justify-between text-[13px]"><span className="font-semibold text-[#1B1B1D]">{label}</span><span className="font-mono text-[#45464D]">%{rate}</span></div><div className="h-2 rounded bg-[#E4E2E4]"><div className={`${fillClass} h-2 rounded`} style={{ width: `${Math.min(100, rate)}%` }} /></div><p className="mt-1 text-[11px] text-[#45464D]">{text}</p></div>
}

function HorizontalBar({ label, max, value }: { label: string; max: number; value: number }) {
  return <div><div className="mb-1 flex items-center justify-between gap-3 text-[13px]"><span className="truncate font-semibold text-[#1B1B1D]" title={label}>{label}</span><span className="font-mono text-[#45464D]">{value}</span></div><div className="h-2 rounded bg-[#E4E2E4]"><div className="h-2 rounded bg-[#3755C3]" style={{ width: `${Math.max(5, (value / max) * 100)}%` }} /></div></div>
}

function ReportSectionHeader({ icon, title }: { icon: string; title: string }) {
  return <div className="flex items-center justify-between border-b border-[#C6C6CD] bg-white p-4"><h3 className="text-lg font-semibold text-[#1B1B1D]">{title}</h3><span className="material-symbols-outlined text-[#45464D]">{icon}</span></div>
}

function ReportTable({ children, emptyText, icon, title }: { children: React.ReactNode; emptyText: string; icon: string; title: string }) {
  return <section className="overflow-hidden rounded-lg border border-[#C6C6CD] bg-white shadow-[0px_1px_3px_rgba(15,23,42,0.08)]"><ReportSectionHeader icon={icon} title={title} /><div className="overflow-x-auto"><table className="w-full border-collapse text-left" aria-label={emptyText}>{children}</table></div></section>
}

function Badge({ label, tone = 'default' }: { label: string; tone?: 'default' | 'danger' | 'success' | 'warning' }) {
  const className = tone === 'danger' ? 'bg-[#BA1A1A] text-white' : tone === 'success' ? 'bg-[#DCFCE7] text-[#16A34A]' : tone === 'warning' ? 'bg-[#FCDEB5] text-[#574425]' : 'bg-[#E4E2E4] text-[#45464D]'

  return <span className={`${className} inline-flex rounded px-2 py-0.5 text-[10px] font-bold uppercase tracking-wide`}>{label}</span>
}

function EmptyText({ text }: { text: string }) {
  return <p className="p-3 text-sm text-[#45464D]">{text}</p>
}

function tableRowClass(index: number) {
  return `${index % 2 === 1 ? 'bg-[#F6F3F5]' : 'bg-white'} border-b border-[#C6C6CD] transition-colors hover:bg-[#FCF8FA]`
}

function csvCell(value: string) {
  return `"${value.replace(/"/g, '""')}"`
}

function formatDate(value: string) {
  return new Intl.DateTimeFormat('tr-TR', { day: '2-digit', month: 'short', year: 'numeric' }).format(new Date(value))
}

function formatDateTime(value: string) {
  return new Intl.DateTimeFormat('tr-TR', { day: '2-digit', month: 'short', year: 'numeric', hour: '2-digit', minute: '2-digit' }).format(new Date(value))
}

export default ReportsView
