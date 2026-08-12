import { useEffect, useState } from 'react'

type DashboardViewProps = {
  apiBaseUrl: string
  token: string
  onOpenFault: (faultId: string) => void
  onOpenShift: (handoverNo: string) => void
}

type DashboardKpis = {
  openFaultCount: number
  criticalFaultCount: number
  todayMaintenanceCount: number
  pendingWorkCount: number
  monthlyCompletedTestCount: number
  maintenanceCompletionRate: number
  testSuccessRate: number
  faultedEquipmentCount: number
}

type ChartPoint = {
  label: string
  value: number
}

type TrendPeriod = 'week' | 'month' | 'year'

type TrendPoint = ChartPoint & {
  year: number
  month: number
}

type Rate = {
  completed: number
  total: number
  rate: number
}

type RecentFault = {
  id: string
  faultNo: string
  equipmentCode: string
  equipmentName: string
  locationName: string
  priority: string
  status: string
  createdAt: string
  updatedAt?: string | null
}

type OpenShiftItem = {
  id: string
  handoverNo: string
  shiftType: string
  shiftDate: string
  itemType: string
  title: string
  priority?: string | null
  equipmentCode?: string | null
  equipmentName?: string | null
  createdAt: string
}

type DashboardOverview = {
  kpis: DashboardKpis
  trendPeriod: TrendPeriod
  faultStatusDistribution: ChartPoint[]
  faultsByLocation: ChartPoint[]
  monthlyFaultTrend: TrendPoint[]
  maintenanceCompletion: Rate
  testSuccess: Rate
  criticalFaults: RecentFault[]
  recentFaults: RecentFault[]
  openShiftItems: OpenShiftItem[]
  generatedAt: string
}

type ActivityRow = {
  id: string
  targetType: 'fault' | 'shift'
  targetId: string
  time: string
  code: string
  activity: string
  status: string
  operator: string
  tone: 'default' | 'danger' | 'success' | 'warning'
}

const emptyOverview: DashboardOverview = {
  kpis: {
    openFaultCount: 0,
    criticalFaultCount: 0,
    todayMaintenanceCount: 0,
    pendingWorkCount: 0,
    monthlyCompletedTestCount: 0,
    maintenanceCompletionRate: 0,
    testSuccessRate: 0,
    faultedEquipmentCount: 0,
  },
  trendPeriod: 'month',
  faultStatusDistribution: [],
  faultsByLocation: [],
  monthlyFaultTrend: [],
  maintenanceCompletion: { completed: 0, total: 0, rate: 0 },
  testSuccess: { completed: 0, total: 0, rate: 0 },
  criticalFaults: [],
  recentFaults: [],
  openShiftItems: [],
  generatedAt: '',
}

const statusLabels: Record<string, string> = {
  New: 'Yeni',
  Assigned: 'Atandı',
  InReview: 'İnceleniyor',
  InProgress: 'Müdahale Ediliyor',
  Waiting: 'Beklemede',
  Resolved: 'Çözüldü',
  Closed: 'Kapatıldı',
}

const priorityLabels: Record<string, string> = {
  Low: 'Düşük',
  Medium: 'Orta',
  High: 'Yüksek',
  Critical: 'Kritik',
}

const shiftTypeLabels: Record<string, string> = {
  Morning: 'Sabah',
  Evening: 'Akşam',
  Night: 'Gece',
}

const shiftItemTypeLabels: Record<string, string> = {
  OpenFault: 'Açık Arıza',
  OngoingWork: 'Devam Eden İş',
  EquipmentToWatch: 'İzlenecek Ekipman',
  PendingMaintenance: 'Bekleyen Bakım',
  CriticalNote: 'Kritik Not',
}

const trendPeriods: { value: TrendPeriod; label: string }[] = [
  { value: 'week', label: 'Hafta' },
  { value: 'month', label: 'Ay' },
  { value: 'year', label: 'Yıl' },
]

const trendTitles: Record<TrendPeriod, string> = {
  week: 'Haftalık Arıza Trendi',
  month: 'Aylık Arıza Trendi',
  year: 'Yıllık Arıza Trendi',
}

const trendDescriptions: Record<TrendPeriod, string> = {
  week: 'Son 7 günlük kayıt yoğunluğu',
  month: 'Son 6 aylık kayıt yoğunluğu',
  year: 'Son 5 yıllık kayıt yoğunluğu',
}

const trendPeriodLabels: Record<TrendPeriod, string> = {
  week: 'Hafta',
  month: 'Ay',
  year: 'Yıl',
}

function DashboardView({ apiBaseUrl, token, onOpenFault, onOpenShift }: DashboardViewProps) {
  const [overview, setOverview] = useState<DashboardOverview>(emptyOverview)
  const [activePeriod, setActivePeriod] = useState<TrendPeriod>('month')
  const [isLoading, setIsLoading] = useState(false)
  const [message, setMessage] = useState('Dashboard verileri yükleniyor...')

  useEffect(() => {
    let ignore = false

    async function loadDashboard() {
      setIsLoading(true)
      try {
        const data = await dashboardRequest<DashboardOverview>(apiBaseUrl, token, dashboardPath(activePeriod))
        if (ignore) {
          return
        }

        setOverview(data)
        setMessage(`Son güncelleme: ${formatDateTime(data.generatedAt)}`)
      } catch (error) {
        if (!ignore) {
          setMessage(error instanceof Error ? error.message : 'Dashboard verileri alınamadı.')
        }
      } finally {
        if (!ignore) {
          setIsLoading(false)
        }
      }
    }

    void loadDashboard()

    return () => {
      ignore = true
    }
  }, [activePeriod, apiBaseUrl, token])

  async function handleRefresh() {
    setIsLoading(true)
    try {
      const data = await dashboardRequest<DashboardOverview>(apiBaseUrl, token, dashboardPath(activePeriod))
      setOverview(data)
      setMessage(`Son güncelleme: ${formatDateTime(data.generatedAt)}`)
    } catch (error) {
      setMessage(error instanceof Error ? error.message : 'Dashboard yenilenemedi.')
    } finally {
      setIsLoading(false)
    }
  }

  function handleDownloadReport() {
    if (!overview.generatedAt) {
      setMessage('Rapor oluşturmak için dashboard verilerinin yüklenmesi bekleniyor.')
      return
    }

    const csv = buildDashboardReportCsv(overview, activePeriod)
    const blob = new Blob(['\ufeff', csv], { type: 'text/csv;charset=utf-8;' })
    const url = URL.createObjectURL(blob)
    const link = document.createElement('a')
    link.href = url
    link.download = `operasyon-dashboard-${activePeriod}-${new Date().toISOString().slice(0, 10)}.csv`
    document.body.appendChild(link)
    link.click()
    link.remove()
    URL.revokeObjectURL(url)
    setMessage(`Rapor indirildi: ${formatDateTime(overview.generatedAt)}`)
  }

  const maxTrend = Math.max(1, ...overview.monthlyFaultTrend.map((item) => item.value))
  const trendChartHeightClass = activePeriod === 'year' ? 'min-h-[230px]' : 'min-h-[300px]'
  const trendBarMaxHeight = activePeriod === 'year' ? 130 : 190
  const maxLocationFault = Math.max(1, ...overview.faultsByLocation.map((item) => item.value))
  const totalFaultStatus = overview.faultStatusDistribution.reduce((sum, item) => sum + item.value, 0)
  const activityRows: ActivityRow[] = [
    ...overview.recentFaults.map((fault) => ({
      id: `fault-${fault.id}`,
      targetType: 'fault' as const,
      targetId: fault.id,
      time: fault.updatedAt ?? fault.createdAt,
      code: fault.faultNo,
      activity: `Arıza Kaydı: ${fault.equipmentName}`,
      status: labelFor(statusLabels, fault.status),
      operator: fault.locationName,
      tone: fault.priority === 'Critical' ? 'danger' as const : fault.priority === 'High' ? 'warning' as const : 'default' as const,
    })),
    ...overview.openShiftItems.map((item) => ({
      id: `shift-${item.id}`,
      targetType: 'shift' as const,
      targetId: item.handoverNo,
      time: item.createdAt,
      code: item.handoverNo,
      activity: `${labelFor(shiftItemTypeLabels, item.itemType)}: ${item.title}`,
      status: 'Devreden İş',
      operator: labelFor(shiftTypeLabels, item.shiftType),
      tone: item.priority === 'Critical' ? 'danger' as const : item.priority === 'High' ? 'warning' as const : 'default' as const,
    })),
  ].sort((first, second) => new Date(second.time).getTime() - new Date(first.time).getTime()).slice(0, 6)

  return (
    <section className="module-font mx-auto w-full max-w-[1600px] bg-[#FCF8FA] px-5 py-6 lg:px-6">
      <div className="mb-6 flex flex-col gap-4 md:flex-row md:items-end md:justify-between">
        <div>
          <h2 className="text-2xl font-semibold tracking-tight text-[#1B1B1D]">Operasyon Özeti</h2>
          <p className="mt-1 text-sm text-[#45464D]">{message}</p>
        </div>
        <div className="flex flex-wrap gap-3">
          <button className="border border-[#3755C3] px-4 py-2 text-sm font-semibold text-[#3755C3] transition-colors hover:bg-[#DDE1FF] disabled:cursor-not-allowed disabled:opacity-50" disabled={!overview.generatedAt || isLoading} type="button" onClick={handleDownloadReport}>Rapor İndir</button>
          <button className="border border-[#76777D] px-4 py-2 text-sm font-semibold text-[#1B1B1D] transition-colors hover:bg-[#F6F3F5]" disabled={isLoading} type="button" onClick={handleRefresh}>Yenile</button>
        </div>
      </div>

      <div className="mb-8 grid grid-cols-1 gap-4 md:grid-cols-3 xl:grid-cols-5">
        <KpiCard helper="Operasyon takibinde" icon="build_circle" label="Açık Arızalar" tone="blue" value={overview.kpis.openFaultCount} />
        <KpiCard helper="Toplam kritik kayıt" icon="warning" label="Kritik Arızalar" tone="danger" value={overview.kpis.criticalFaultCount} />
        <KpiCard helper="Planlanan operasyonlar" icon="event_note" label="Bugün Bakım" tone="amber" value={overview.kpis.todayMaintenanceCount} />
        <KpiCard helper="Atama veya takip bekliyor" icon="pending_actions" label="Bekleyen İşler" tone="neutral" value={overview.kpis.pendingWorkCount} />
        <KpiCard helper="Bu ay tamamlandı" icon="check_circle" label="Tamamlanan Testler" tone="navy" value={overview.kpis.monthlyCompletedTestCount} />
      </div>

      <div className="mb-8 grid grid-cols-1 gap-4 lg:grid-cols-12 lg:items-start">
        <div className="flex flex-col gap-4 lg:col-span-8">
        <section className="rounded-lg border border-[#C6C6CD] bg-white p-6 shadow-[0px_1px_3px_rgba(15,23,42,0.08)]">
          <div className="mb-4 flex flex-col gap-3 md:flex-row md:items-center md:justify-between">
            <div>
              <h3 className="text-lg font-semibold text-[#1B1B1D]">{trendTitles[activePeriod]}</h3>
              <p className="mt-1 text-[13px] text-[#45464D]">{trendDescriptions[activePeriod]}</p>
            </div>
            <div className="flex gap-2 text-[11px] font-bold uppercase tracking-wide">
              {trendPeriods.map((period) => (
                <button className={periodButtonClass(activePeriod === period.value)} disabled={isLoading} key={period.value} type="button" onClick={() => setActivePeriod(period.value)}>{period.label}</button>
              ))}
            </div>
          </div>
          <div className={`${trendChartHeightClass} flex items-end gap-3 rounded border border-dashed border-[#C6C6CD] bg-[#FCF8FA] px-4 pb-4 pt-8`}>
            {overview.monthlyFaultTrend.map((item, index) => (
              <div key={`${activePeriod}-${item.year}-${item.month}-${item.label}-${index}`} className="flex h-full flex-1 flex-col justify-end gap-2">
                <span className="text-center font-mono text-xs font-semibold text-[#45464D]">{item.value}</span>
                <div className="rounded-t bg-[#3755C3]" style={{ height: `${Math.max(10, (item.value / maxTrend) * trendBarMaxHeight)}px` }} />
                <span className="h-10 text-center text-[11px] leading-4 text-[#45464D]">{item.label}</span>
              </div>
            ))}
          </div>
        </section>

        <div className="grid grid-cols-1 gap-4 xl:grid-cols-12">
          <section className="rounded-lg border border-[#C6C6CD] bg-white p-4 shadow-[0px_1px_3px_rgba(15,23,42,0.08)] xl:col-span-4">
            <h3 className="mb-3 text-lg font-semibold text-[#1B1B1D]">Arıza Durum Dağılımı</h3>
            <div className="space-y-3">
              {overview.faultStatusDistribution.map((item) => (
                <div key={item.label} className="rounded border border-[#C6C6CD] bg-[#FCF8FA] p-3">
                  <div className="mb-2 flex items-center justify-between text-[13px]"><span className="font-semibold text-[#1B1B1D]">{labelFor(statusLabels, item.label)}</span><span className="font-mono font-bold text-[#1B1B1D]">{item.value}</span></div>
                  <div className="h-2 rounded bg-[#E4E2E4]"><div className="h-2 rounded bg-black" style={{ width: `${totalFaultStatus === 0 ? 0 : (item.value / totalFaultStatus) * 100}%` }} /></div>
                </div>
              ))}
              {overview.faultStatusDistribution.length === 0 ? <EmptyText text="Durum dağılımı bulunamadı." /> : null}
            </div>
          </section>

          <section className="rounded-lg border border-[#C6C6CD] bg-white shadow-[0px_1px_3px_rgba(15,23,42,0.08)] xl:col-span-8">
            <div className="flex items-center justify-between border-b border-[#C6C6CD] bg-white p-4">
              <h3 className="text-lg font-semibold text-[#1B1B1D]">Devreden ve Bekleyen İşler</h3>
              <span className="material-symbols-outlined text-[#45464D]">pending_actions</span>
            </div>
            <div className="divide-y divide-[#C6C6CD]">
              {overview.openShiftItems.slice(0, 4).map((item) => (
                <div key={item.id} className="grid gap-3 p-4 md:grid-cols-[120px_1fr_auto] md:items-center">
                  <span className="font-mono text-xs text-[#45464D]">{formatDate(item.shiftDate)}</span>
                  <div><p className="text-sm font-semibold text-[#1B1B1D]">{item.title}</p><p className="mt-1 text-xs text-[#45464D]">{item.handoverNo} • {labelFor(shiftItemTypeLabels, item.itemType)}{item.equipmentCode ? ` • ${item.equipmentCode}` : ''}</p></div>
                  <Badge label={item.priority ? labelFor(priorityLabels, item.priority) : labelFor(shiftTypeLabels, item.shiftType)} tone={item.priority === 'Critical' ? 'danger' : item.priority === 'High' ? 'warning' : 'default'} />
                </div>
              ))}
              {overview.openShiftItems.length === 0 ? <EmptyText text="Açık vardiya maddesi bulunamadı." /> : null}
            </div>
          </section>
        </div>
        </div>

        <aside className="flex flex-col gap-4 lg:col-span-4">
          <section className="rounded-lg border border-[#C6C6CD] bg-white p-4 shadow-[0px_1px_3px_rgba(15,23,42,0.08)]">
            <h3 className="mb-3 border-b border-[#C6C6CD] pb-2 text-lg font-semibold text-[#1B1B1D]">Kritik Açık Arızalar</h3>
            <div className="space-y-3">
              {overview.criticalFaults.map((fault) => (
                <div key={fault.id} className={`${fault.priority === 'Critical' ? 'border-[#FFDAD6] bg-[#FFDAD6]/30' : 'border-[#C6C6CD] bg-[#F6F3F5]'} rounded border p-3 transition-colors hover:bg-[#EAE7E9]`}>
                  <div className="mb-1 flex items-start justify-between gap-3">
                    <span className="font-mono text-[13px] font-bold text-[#BA1A1A]">{fault.faultNo}</span>
                    <Badge label={labelFor(priorityLabels, fault.priority)} tone={fault.priority === 'Critical' ? 'danger' : 'default'} />
                  </div>
                  <p className="mb-2 text-[13px] font-semibold text-[#1B1B1D]">{fault.equipmentName}</p>
                  <div className="flex items-center justify-between text-[11px] text-[#45464D]"><span>{formatDateTime(fault.updatedAt ?? fault.createdAt)}</span><span>{fault.locationName}</span></div>
                </div>
              ))}
              {overview.criticalFaults.length === 0 ? <EmptyText text="Açık kritik arıza kaydı bulunamadı." /> : null}
            </div>
          </section>

          <section className="rounded-lg border border-[#C6C6CD] bg-white p-4 shadow-[0px_1px_3px_rgba(15,23,42,0.08)]">
            <h3 className="mb-3 text-lg font-semibold text-[#1B1B1D]">Konuma Göre Dağılım</h3>
            <div className="space-y-3 rounded bg-[#FCF8FA] p-3">
              {overview.faultsByLocation.map((item) => <HorizontalBar key={item.label} label={item.label} max={maxLocationFault} value={item.value} />)}
              {overview.faultsByLocation.length === 0 ? <EmptyText text="Lokasyon dağılımı bulunamadı." /> : null}
            </div>
          </section>

          <section className="rounded-lg border border-[#C6C6CD] bg-white p-4 shadow-[0px_1px_3px_rgba(15,23,42,0.08)]">
            <h3 className="mb-3 text-lg font-semibold text-[#1B1B1D]">Operasyon Sağlığı</h3>
            <RateLine label="Bakım Tamamlama" rate={overview.maintenanceCompletion} tone="blue" />
            <RateLine label="Test Başarı" rate={overview.testSuccess} tone="green" />
            <RateLine label="Arızalı Ekipman" rate={{ completed: overview.kpis.faultedEquipmentCount, total: Math.max(overview.kpis.faultedEquipmentCount, 1), rate: overview.kpis.faultedEquipmentCount > 0 ? 100 : 0 }} tone="danger" />
          </section>
        </aside>
      </div>

      <section className="overflow-hidden rounded-lg border border-[#C6C6CD] bg-white shadow-[0px_1px_3px_rgba(15,23,42,0.08)]">
        <div className="flex items-center justify-between border-b border-[#C6C6CD] bg-white p-4">
          <h3 className="text-lg font-semibold text-[#1B1B1D]">Son Aktiviteler</h3>
          <span className="material-symbols-outlined text-[#45464D]">filter_list</span>
        </div>
        <div className="overflow-x-auto">
          <table className="w-full border-collapse text-left">
            <thead>
              <tr className="bg-[#F6F3F5] text-[11px] font-bold uppercase tracking-wide text-[#45464D]">
                <th className="p-3">Zaman</th>
                <th className="p-3">İşlem ID</th>
                <th className="p-3">Aktivite Türü</th>
                <th className="p-3">Durum</th>
                <th className="p-3">Operatör</th>
                <th className="p-3 text-right">Aksiyon</th>
              </tr>
            </thead>
            <tbody className="text-[13px] text-[#1B1B1D]">
              {activityRows.map((row, index) => (
                <tr key={row.id} className={`${index % 2 === 1 ? 'bg-[#F6F3F5]' : 'bg-white'} border-b border-[#C6C6CD] transition-colors hover:bg-[#FCF8FA]`}>
                  <td className="p-3 text-[#45464D]">{formatTime(row.time)}</td>
                  <td className="p-3 font-mono">{row.code}</td>
                  <td className="p-3">{row.activity}</td>
                  <td className="p-3"><Badge label={row.status} tone={row.tone} /></td>
                  <td className="p-3 text-[#45464D]">{row.operator}</td>
                  <td className="p-3 text-right"><button className="material-symbols-outlined text-[18px] text-[#45464D] hover:text-black" title="Detayı aç" type="button" onClick={() => row.targetType === 'fault' ? onOpenFault(row.targetId) : onOpenShift(row.targetId)}>open_in_new</button></td>
                </tr>
              ))}
              {activityRows.length === 0 ? <tr><td className="p-4 text-sm text-[#45464D]" colSpan={6}>Aktivite kaydı bulunamadı.</td></tr> : null}
            </tbody>
          </table>
        </div>
      </section>
    </section>
  )
}

async function dashboardRequest<T>(apiBaseUrl: string, token: string, path: string): Promise<T> {
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

function dashboardPath(period: TrendPeriod) {
  return `/api/dashboard/overview?period=${period}`
}

function periodButtonClass(isActive: boolean) {
  return isActive
    ? 'bg-black px-3 py-1 text-white disabled:cursor-not-allowed disabled:opacity-60'
    : 'bg-[#F6F3F5] px-3 py-1 text-[#45464D] transition-colors hover:bg-[#E4E2E4] disabled:cursor-not-allowed disabled:opacity-60'
}

function buildDashboardReportCsv(overview: DashboardOverview, period: TrendPeriod) {
  const rows: string[][] = [
    ['Operasyon Dashboard Raporu'],
    ['Olusturma Zamani', formatDateTime(overview.generatedAt)],
    ['Trend Periyodu', trendPeriodLabels[period]],
    [],
    ['KPI', 'Deger'],
    ['Acik Arizalar', overview.kpis.openFaultCount.toString()],
    ['Kritik Arizalar', overview.kpis.criticalFaultCount.toString()],
    ['Bugun Bakim', overview.kpis.todayMaintenanceCount.toString()],
    ['Bekleyen Isler', overview.kpis.pendingWorkCount.toString()],
    ['Tamamlanan Testler', overview.kpis.monthlyCompletedTestCount.toString()],
    ['Bakim Tamamlama Orani', `%${overview.kpis.maintenanceCompletionRate}`],
    ['Test Basari Orani', `%${overview.kpis.testSuccessRate}`],
    ['Arizali Ekipman', overview.kpis.faultedEquipmentCount.toString()],
    [],
    [`${trendTitles[period]}`, 'Kayit Sayisi'],
    ...overview.monthlyFaultTrend.map((item) => [item.label, item.value.toString()]),
    [],
    ['Ariza Durumu', 'Kayit Sayisi'],
    ...overview.faultStatusDistribution.map((item) => [labelFor(statusLabels, item.label), item.value.toString()]),
    [],
    ['Lokasyon', 'Ariza Sayisi'],
    ...overview.faultsByLocation.map((item) => [item.label, item.value.toString()]),
    [],
    ['Son Arizalar', 'Ekipman', 'Lokasyon', 'Oncelik', 'Durum', 'Tarih'],
    ...overview.recentFaults.map((fault) => [
      fault.faultNo,
      `${fault.equipmentCode} - ${fault.equipmentName}`,
      fault.locationName,
      labelFor(priorityLabels, fault.priority),
      labelFor(statusLabels, fault.status),
      formatDateTime(fault.updatedAt ?? fault.createdAt),
    ]),
    [],
    ['Devreden Isler', 'Tur', 'Vardiya', 'Ekipman', 'Oncelik', 'Tarih'],
    ...overview.openShiftItems.map((item) => [
      `${item.handoverNo} - ${item.title}`,
      labelFor(shiftItemTypeLabels, item.itemType),
      labelFor(shiftTypeLabels, item.shiftType),
      item.equipmentCode ? `${item.equipmentCode} - ${item.equipmentName ?? ''}` : '',
      item.priority ? labelFor(priorityLabels, item.priority) : '',
      formatDate(item.shiftDate),
    ]),
  ]

  return rows.map((row) => row.map(csvCell).join(';')).join('\n')
}

function csvCell(value: string) {
  return `"${value.replace(/"/g, '""')}"`
}

function KpiCard({ helper, icon, label, tone, value }: { helper: string; icon: string; label: string; tone: 'blue' | 'danger' | 'amber' | 'neutral' | 'navy'; value: number }) {
  const toneClass = tone === 'danger' ? 'text-[#BA1A1A]' : 'text-[#1B1B1D]'
  const labelClass = tone === 'danger' ? 'text-[#BA1A1A]' : tone === 'amber' ? 'text-[#574425]' : tone === 'navy' ? 'text-[#131B2E]' : tone === 'blue' ? 'text-[#3755C3]' : 'text-[#45464D]'
  const iconClass = tone === 'danger' ? 'bg-[#FFDAD6] text-[#BA1A1A]' : tone === 'amber' ? 'bg-[#FCDEB5] text-[#574425]' : tone === 'navy' ? 'bg-[#BEC6E0] text-[#131B2E]' : tone === 'blue' ? 'bg-[#DDE1FF] text-[#3755C3]' : 'bg-[#E4E2E4] text-[#45464D]'
  const borderClass = tone === 'danger' ? 'border-l-4 border-l-[#BA1A1A]' : ''

  return <section className={`${borderClass} flex flex-col gap-2 rounded-lg border border-[#C6C6CD] bg-white p-4 shadow-[0px_1px_3px_rgba(15,23,42,0.08)]`}><div className="flex items-center justify-between"><span className={`${labelClass} text-[11px] font-bold uppercase tracking-wide`}>{label}</span><span className={`${iconClass} flex h-8 w-8 items-center justify-center rounded-full`}><span className="material-symbols-outlined text-[18px]">{icon}</span></span></div><div className={`${toneClass} font-mono text-[32px] font-bold leading-10 tracking-tight`}>{value}</div><p className="text-[13px] text-[#45464D]">{helper}</p></section>
}

function HorizontalBar({ label, max, value }: { label: string; max: number; value: number }) {
  return <div><div className="mb-1 flex items-center justify-between gap-3 text-[13px]"><span className="font-semibold text-[#1B1B1D]">{label}</span><span className="font-mono text-[#45464D]">{value}</span></div><div className="h-2 rounded bg-[#E4E2E4]"><div className="h-2 rounded bg-[#3755C3]" style={{ width: `${Math.max(5, (value / max) * 100)}%` }} /></div></div>
}

function RateLine({ label, rate, tone }: { label: string; rate: Rate; tone: 'blue' | 'green' | 'danger' }) {
  const fillClass = tone === 'green' ? 'bg-[#16A34A]' : tone === 'danger' ? 'bg-[#BA1A1A]' : 'bg-[#3755C3]'

  return <div className="border-t border-[#C6C6CD] py-3 first:border-t-0"><div className="mb-2 flex items-center justify-between text-[13px]"><span className="font-semibold text-[#1B1B1D]">{label}</span><span className="font-mono text-[#45464D]">%{rate.rate}</span></div><div className="h-2 rounded bg-[#E4E2E4]"><div className={`${fillClass} h-2 rounded`} style={{ width: `${Math.min(100, rate.rate)}%` }} /></div><p className="mt-1 text-[11px] text-[#45464D]">{rate.completed}/{rate.total}</p></div>
}

function Badge({ label, tone = 'default' }: { label: string; tone?: 'default' | 'danger' | 'success' | 'warning' }) {
  const className = tone === 'danger' ? 'bg-[#BA1A1A] text-white' : tone === 'success' ? 'bg-[#DCFCE7] text-[#16A34A]' : tone === 'warning' ? 'bg-[#FCDEB5] text-[#574425]' : 'bg-[#E4E2E4] text-[#45464D]'

  return <span className={`${className} inline-flex rounded px-2 py-0.5 text-[10px] font-bold uppercase tracking-wide`}>{label}</span>
}

function EmptyText({ text }: { text: string }) {
  return <p className="p-3 text-sm text-[#45464D]">{text}</p>
}

function labelFor(labels: Record<string, string>, value: string) {
  return labels[value] ?? value
}

function formatDate(value: string) {
  return new Intl.DateTimeFormat('tr-TR', { day: '2-digit', month: 'short', year: 'numeric' }).format(new Date(value))
}

function formatTime(value: string) {
  return new Intl.DateTimeFormat('tr-TR', { hour: '2-digit', minute: '2-digit' }).format(new Date(value))
}

function formatDateTime(value: string) {
  return new Intl.DateTimeFormat('tr-TR', { day: '2-digit', month: 'short', year: 'numeric', hour: '2-digit', minute: '2-digit' }).format(new Date(value))
}

export default DashboardView
