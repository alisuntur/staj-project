import { useEffect, useState } from 'react'
import type { ReactNode } from 'react'
import ExecutiveReportDownload from './ExecutiveReportDownload'
import { friendlyErrorMessage, requestJson } from './apiClient'
import { EmptyState, LoadingPanel, StatusMessage } from './UiState'

type DashboardViewProps = {
  apiBaseUrl: string
  token: string
  user: { fullName: string; role: string } | null
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
  title: string
  meta: string
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

function DashboardView({ apiBaseUrl, token, user, onOpenFault, onOpenShift }: DashboardViewProps) {
  const [overview, setOverview] = useState<DashboardOverview>(emptyOverview)
  const [activePeriod, setActivePeriod] = useState<TrendPeriod>('week')
  const [isLoading, setIsLoading] = useState(false)
  const [message, setMessage] = useState('Operasyon kokpiti hazırlanıyor...')

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
          setMessage(friendlyErrorMessage(error, 'Operasyon kokpiti verileri alınamadı.'))
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
      setMessage(friendlyErrorMessage(error, 'Operasyon kokpiti yenilenemedi.'))
    } finally {
      setIsLoading(false)
    }
  }

  const currentShift = currentShiftLabel()
  const maxTrend = Math.max(1, ...overview.monthlyFaultTrend.map((item) => item.value))
  const maxLocationFault = Math.max(1, ...overview.faultsByLocation.map((item) => item.value))
  const totalFaultStatus = overview.faultStatusDistribution.reduce((sum, item) => sum + item.value, 0)
  const activityRows = buildActivityRows(overview)
  const firstCriticalFault = overview.criticalFaults[0]
  const firstShiftItem = overview.openShiftItems[0]

  return (
    <section className="module-font mx-auto w-full max-w-[1680px] px-4 py-6 lg:px-8 lg:py-8">
      <section className="overflow-hidden rounded-[32px] border border-[#D7DEE8] bg-[#0B1220] text-white shadow-[0_24px_80px_rgba(15,23,42,0.18)]">
        <div className="grid gap-0 xl:grid-cols-[1fr_420px]">
          <div className="p-6 sm:p-8 lg:p-10">
            <p className="text-[11px] font-bold uppercase tracking-[0.26em] text-[#93C5FD]">Giriş sonrası ana ekran</p>
            <h2 className="mt-3 max-w-4xl text-3xl font-extrabold tracking-tight sm:text-5xl">{greeting()}, {user?.fullName ?? 'Operasyon Ekibi'}</h2>
            <p className="mt-4 max-w-3xl text-base leading-8 text-[#D8E2F2]">Önce vardiyanın görmesi gereken işler: açık arızalar, devreden vardiya maddeleri, kritik riskler ve bugünkü bakım planları.</p>

            <div className="mt-7 grid gap-3 sm:grid-cols-2 xl:grid-cols-4">
              <HeroMetric icon="schedule" label="Aktif Vardiya" value={currentShift} />
              <HeroMetric icon="report" label="Açık Arıza" value={overview.kpis.openFaultCount} />
              <HeroMetric icon="swap_horiz" label="Devreden İş" value={overview.openShiftItems.length} />
              <HeroMetric icon="engineering" label="Kullanıcı Rolü" value={user?.role ?? '-'} />
            </div>
          </div>

          <aside className="border-t border-white/10 bg-white/8 p-6 backdrop-blur xl:border-l xl:border-t-0 lg:p-8">
            <p className="text-[11px] font-bold uppercase tracking-[0.2em] text-[#BFDBFE]">Hızlı aksiyon</p>
            <div className="mt-5 flex flex-wrap gap-2">
              <ExecutiveReportDownload apiBaseUrl={apiBaseUrl} disabled={!overview.generatedAt || isLoading} fileBaseName={`operasyon-dashboard-${activePeriod}`} label="Kokpit Raporu" path={`/api/exports/dashboard?period=${activePeriod}`} token={token} onMessage={setMessage} />
              <button className="rounded-xl border border-white/20 bg-white px-4 py-2 text-sm font-bold text-[#0F172A] transition hover:bg-[#DBEAFE] disabled:cursor-not-allowed disabled:opacity-60" disabled={isLoading} type="button" onClick={handleRefresh}>Yenile</button>
            </div>
            <div className="mt-5"><StatusMessage busy={isLoading} message={message} /></div>
          </aside>
        </div>
      </section>

      {isLoading && !overview.generatedAt ? <div className="mt-6"><LoadingPanel title="Operasyon verileri hazırlanıyor" text="KPI, arıza, vardiya ve rapor verileri API'den alınıyor." /></div> : null}

      <section className="mt-6 grid gap-4 md:grid-cols-2 xl:grid-cols-4">
        <PriorityCard helper="Vardiyanın ilk kontrol edeceği kayıtlar" icon="report" label="Açık Arızalar" tone="blue" value={overview.kpis.openFaultCount} />
        <PriorityCard helper="Öncelikli saha müdahalesi gerekir" icon="priority_high" label="Kritik Arızalar" tone="danger" value={overview.kpis.criticalFaultCount} />
        <PriorityCard helper="Önceki vardiyadan taşınan maddeler" icon="swap_horiz" label="Vardiyadan Kalanlar" tone="warning" value={overview.openShiftItems.length} />
        <PriorityCard helper="Bugün planlanan bakım işi" icon="event_note" label="Bugünkü Bakım" tone="success" value={overview.kpis.todayMaintenanceCount} />
      </section>

      <section className="mt-6 grid gap-6 xl:grid-cols-[1.15fr_0.85fr]">
        <Panel eyebrow="Birinci öncelik" title="Müdahale bekleyen açık arızalar" action={firstCriticalFault ? <button className="text-sm font-bold text-[#2563EB]" type="button" onClick={() => onOpenFault(firstCriticalFault.id)}>İlk kritiği aç</button> : null}>
          <div className="grid gap-3">
            {overview.criticalFaults.slice(0, 5).map((fault) => (
              <button className="group grid gap-3 rounded-2xl border border-[#FECACA] bg-[#FFF7F7] p-4 text-left transition hover:-translate-y-0.5 hover:border-[#DC2626] hover:shadow-[0_16px_40px_rgba(220,38,38,0.12)] md:grid-cols-[130px_1fr_auto] md:items-center" key={fault.id} type="button" onClick={() => onOpenFault(fault.id)}>
                <div>
                  <p className="font-mono text-sm font-extrabold text-[#DC2626]">{fault.faultNo}</p>
                  <p className="mt-1 text-xs font-semibold text-[#64748B]">{formatDateTime(fault.updatedAt ?? fault.createdAt)}</p>
                </div>
                <div>
                  <p className="font-extrabold text-[#0F172A]">{fault.equipmentName}</p>
                  <p className="mt-1 text-sm text-[#475569]">{fault.equipmentCode} • {fault.locationName} • {labelFor(statusLabels, fault.status)}</p>
                </div>
                <Badge label={labelFor(priorityLabels, fault.priority)} tone="danger" />
              </button>
            ))}
            {overview.criticalFaults.length === 0 ? <EmptyState icon="verified" title="Kritik açık arıza yok" text="Vardiya başlangıcı için kritik risk bulunmuyor." /> : null}
          </div>
        </Panel>

        <Panel eyebrow="Vardiya devri" title="Devreden işler" action={firstShiftItem ? <button className="text-sm font-bold text-[#2563EB]" type="button" onClick={() => onOpenShift(firstShiftItem.handoverNo)}>Devir kaydını aç</button> : null}>
          <div className="grid gap-3">
            {overview.openShiftItems.slice(0, 6).map((item) => (
              <button className="rounded-2xl border border-[#D7DEE8] bg-white p-4 text-left transition hover:-translate-y-0.5 hover:border-[#2563EB] hover:shadow-[0_16px_40px_rgba(15,23,42,0.08)]" key={item.id} type="button" onClick={() => onOpenShift(item.handoverNo)}>
                <div className="flex items-start justify-between gap-3">
                  <div>
                    <p className="font-extrabold text-[#0F172A]">{item.title}</p>
                    <p className="mt-1 text-sm text-[#64748B]">{item.handoverNo} • {labelFor(shiftTypeLabels, item.shiftType)} vardiyası</p>
                  </div>
                  <Badge label={item.priority ? labelFor(priorityLabels, item.priority) : labelFor(shiftItemTypeLabels, item.itemType)} tone={item.priority === 'Critical' ? 'danger' : item.priority === 'High' ? 'warning' : 'default'} />
                </div>
                <p className="mt-3 text-xs font-semibold text-[#475569]">{labelFor(shiftItemTypeLabels, item.itemType)}{item.equipmentCode ? ` • ${item.equipmentCode}` : ''}</p>
              </button>
            ))}
            {overview.openShiftItems.length === 0 ? <EmptyState icon="task_alt" title="Devreden iş yok" text="Önceki vardiyadan taşınan açık madde bulunmuyor." /> : null}
          </div>
        </Panel>
      </section>

      <section className="mt-6 grid gap-6 xl:grid-cols-[0.8fr_1.2fr]">
        <Panel eyebrow="İkinci öncelik" title="Operasyon sağlığı">
          <div className="grid gap-4 sm:grid-cols-3 xl:grid-cols-1">
            <HealthCard label="Bakım Tamamlama" rate={overview.maintenanceCompletion} tone="blue" />
            <HealthCard label="Test Başarı" rate={overview.testSuccess} tone="green" />
            <HealthCard label="Arızalı Ekipman" rate={{ completed: overview.kpis.faultedEquipmentCount, total: Math.max(overview.kpis.faultedEquipmentCount, 1), rate: overview.kpis.faultedEquipmentCount > 0 ? 100 : 0 }} tone="danger" />
          </div>
        </Panel>

        <Panel eyebrow="Trend" title="Arıza yoğunluğu">
          <div className="mb-4 flex flex-wrap gap-2">
            {trendPeriods.map((period) => (
              <button className={periodButtonClass(activePeriod === period.value)} disabled={isLoading} key={period.value} type="button" onClick={() => setActivePeriod(period.value)}>{period.label}</button>
            ))}
          </div>
          <div className="flex min-h-[260px] items-end gap-3 rounded-3xl border border-dashed border-[#CBD5E1] bg-[#F8FAFC] px-4 pb-4 pt-8">
            {overview.monthlyFaultTrend.map((item, index) => (
              <div className="flex h-full flex-1 flex-col justify-end gap-2" key={`${activePeriod}-${item.year}-${item.month}-${item.label}-${index}`}>
                <span className="text-center font-mono text-xs font-bold text-[#475569]">{item.value}</span>
                <div className="rounded-t-2xl bg-[#2563EB]" style={{ height: `${Math.max(12, (item.value / maxTrend) * 190)}px` }} />
                <span className="h-10 text-center text-[11px] leading-4 text-[#64748B]">{item.label}</span>
              </div>
            ))}
          </div>
        </Panel>
      </section>

      <section className="mt-6 grid gap-6 xl:grid-cols-2">
        <Panel eyebrow="Üçüncü öncelik" title="Durum dağılımı">
          <div className="grid gap-3">
            {overview.faultStatusDistribution.map((item) => (
              <DistributionRow key={item.label} label={labelFor(statusLabels, item.label)} value={item.value} max={Math.max(1, totalFaultStatus)} />
            ))}
            {overview.faultStatusDistribution.length === 0 ? <EmptyState icon="donut_large" title="Durum dağılımı yok" text="Seçili dönem için arıza durum dağılımı bulunamadı." /> : null}
          </div>
        </Panel>

        <Panel eyebrow="Lokasyon" title="Arızaların bölgesel dağılımı">
          <div className="grid gap-3">
            {overview.faultsByLocation.map((item) => <DistributionRow key={item.label} label={item.label} max={maxLocationFault} value={item.value} />)}
            {overview.faultsByLocation.length === 0 ? <EmptyState icon="location_on" title="Lokasyon dağılımı yok" text="Seçili dönem için lokasyon bazlı kayıt bulunamadı." /> : null}
          </div>
        </Panel>
      </section>

      <Panel className="mt-6" eyebrow="Operasyon akışı" title="Son aktiviteler">
        <div className="overflow-x-auto">
          <table className="w-full border-collapse text-left">
            <thead>
              <tr className="text-[11px] font-bold uppercase tracking-wide text-[#64748B]">
                <th className="border-b border-[#E2E8F0] p-3">Zaman</th>
                <th className="border-b border-[#E2E8F0] p-3">Kayıt</th>
                <th className="border-b border-[#E2E8F0] p-3">Açıklama</th>
                <th className="border-b border-[#E2E8F0] p-3">Öncelik</th>
                <th className="border-b border-[#E2E8F0] p-3 text-right">Aksiyon</th>
              </tr>
            </thead>
            <tbody className="text-sm text-[#0F172A]">
              {activityRows.map((row) => (
                <tr className="border-b border-[#E2E8F0] transition hover:bg-[#F8FAFC]" key={row.id}>
                  <td className="p-3 text-[#64748B]">{formatTime(row.time)}</td>
                  <td className="p-3 font-mono font-bold">{row.code}</td>
                  <td className="p-3"><p className="font-bold">{row.title}</p><p className="mt-1 text-xs text-[#64748B]">{row.meta}</p></td>
                  <td className="p-3"><Badge label={row.tone === 'danger' ? 'Kritik' : row.tone === 'warning' ? 'Yüksek' : 'Normal'} tone={row.tone} /></td>
                  <td className="p-3 text-right"><button className="rounded-xl border border-[#CBD5E1] px-3 py-1.5 text-xs font-bold text-[#334155] transition hover:bg-[#F1F5F9]" type="button" onClick={() => row.targetType === 'fault' ? onOpenFault(row.targetId) : onOpenShift(row.targetId)}>Detay</button></td>
                </tr>
              ))}
              {activityRows.length === 0 ? <tr><td colSpan={5}><EmptyState icon="timeline" title="Aktivite bulunamadı" text="Son arıza ve vardiya hareketleri burada listelenir." /></td></tr> : null}
            </tbody>
          </table>
        </div>
      </Panel>
    </section>
  )
}

async function dashboardRequest<T>(apiBaseUrl: string, token: string, path: string): Promise<T> {
  return requestJson<T>(`${apiBaseUrl}${path}`, {
    headers: { Authorization: `Bearer ${token}` },
  })
}

function dashboardPath(period: TrendPeriod) {
  return `/api/dashboard/overview?period=${period}`
}

function buildActivityRows(overview: DashboardOverview): ActivityRow[] {
  return [
    ...overview.recentFaults.map((fault) => ({
      id: `fault-${fault.id}`,
      targetType: 'fault' as const,
      targetId: fault.id,
      time: fault.updatedAt ?? fault.createdAt,
      code: fault.faultNo,
      title: fault.equipmentName,
      meta: `${fault.equipmentCode} • ${fault.locationName} • ${labelFor(statusLabels, fault.status)}`,
      tone: fault.priority === 'Critical' ? 'danger' as const : fault.priority === 'High' ? 'warning' as const : 'default' as const,
    })),
    ...overview.openShiftItems.map((item) => ({
      id: `shift-${item.id}`,
      targetType: 'shift' as const,
      targetId: item.handoverNo,
      time: item.createdAt,
      code: item.handoverNo,
      title: item.title,
      meta: `${labelFor(shiftItemTypeLabels, item.itemType)} • ${labelFor(shiftTypeLabels, item.shiftType)} vardiyası${item.equipmentCode ? ` • ${item.equipmentCode}` : ''}`,
      tone: item.priority === 'Critical' ? 'danger' as const : item.priority === 'High' ? 'warning' as const : 'default' as const,
    })),
  ].sort((first, second) => new Date(second.time).getTime() - new Date(first.time).getTime()).slice(0, 8)
}

function HeroMetric({ icon, label, value }: { icon: string; label: string; value: number | string }) {
  return (
    <div className="rounded-2xl border border-white/10 bg-white/10 p-4 backdrop-blur">
      <span className="material-symbols-outlined text-[#BFDBFE]">{icon}</span>
      <p className="mt-3 text-[11px] font-bold uppercase tracking-wide text-[#C7D2FE]">{label}</p>
      <p className="mt-1 font-mono text-2xl font-extrabold text-white">{value}</p>
    </div>
  )
}

function PriorityCard({ helper, icon, label, tone, value }: { helper: string; icon: string; label: string; tone: 'blue' | 'danger' | 'warning' | 'success'; value: number }) {
  const toneClass = tone === 'danger'
    ? 'border-[#FECACA] bg-[#FFF7F7] text-[#DC2626]'
    : tone === 'warning'
      ? 'border-[#FED7AA] bg-[#FFF7ED] text-[#C2410C]'
      : tone === 'success'
        ? 'border-[#BBF7D0] bg-[#F0FDF4] text-[#15803D]'
        : 'border-[#BFDBFE] bg-[#EFF6FF] text-[#2563EB]'

  return (
    <section className={`${toneClass} rounded-[28px] border p-5 shadow-[0_14px_40px_rgba(15,23,42,0.07)]`}>
      <div className="flex items-start justify-between gap-4">
        <div>
          <p className="text-[11px] font-extrabold uppercase tracking-wide">{label}</p>
          <p className="mt-3 font-mono text-4xl font-extrabold leading-none">{value}</p>
        </div>
        <span className="material-symbols-outlined rounded-2xl bg-white/70 p-2 text-[24px]">{icon}</span>
      </div>
      <p className="mt-4 text-sm font-semibold text-[#475569]">{helper}</p>
    </section>
  )
}

function Panel({ action, children, className = '', eyebrow, title }: { action?: ReactNode; children: ReactNode; className?: string; eyebrow: string; title: string }) {
  return (
    <section className={`${className} rounded-[28px] border border-[#D7DEE8] bg-white p-5 shadow-[0_16px_50px_rgba(15,23,42,0.06)] lg:p-6`}>
      <div className="mb-5 flex items-start justify-between gap-4">
        <div>
          <p className="text-[11px] font-extrabold uppercase tracking-[0.18em] text-[#2563EB]">{eyebrow}</p>
          <h3 className="mt-1 text-xl font-extrabold tracking-tight text-[#0F172A]">{title}</h3>
        </div>
        {action}
      </div>
      {children}
    </section>
  )
}

function HealthCard({ label, rate, tone }: { label: string; rate: Rate; tone: 'blue' | 'green' | 'danger' }) {
  const fillClass = tone === 'green' ? 'bg-[#16A34A]' : tone === 'danger' ? 'bg-[#DC2626]' : 'bg-[#2563EB]'

  return (
    <div className="rounded-2xl border border-[#E2E8F0] bg-[#F8FAFC] p-4">
      <div className="flex items-center justify-between gap-3">
        <p className="font-bold text-[#0F172A]">{label}</p>
        <p className="font-mono text-xl font-extrabold text-[#0F172A]">%{rate.rate}</p>
      </div>
      <div className="mt-3 h-3 rounded-full bg-[#E2E8F0]"><div className={`${fillClass} h-3 rounded-full`} style={{ width: `${Math.min(100, rate.rate)}%` }} /></div>
      <p className="mt-2 text-xs font-semibold text-[#64748B]">{rate.completed}/{rate.total}</p>
    </div>
  )
}

function DistributionRow({ label, max, value }: { label: string; max: number; value: number }) {
  return (
    <div>
      <div className="mb-1 flex items-center justify-between gap-3 text-sm">
        <span className="font-bold text-[#0F172A]">{label}</span>
        <span className="font-mono font-bold text-[#64748B]">{value}</span>
      </div>
      <div className="h-3 rounded-full bg-[#E2E8F0]"><div className="h-3 rounded-full bg-[#2563EB]" style={{ width: `${Math.max(6, (value / max) * 100)}%` }} /></div>
    </div>
  )
}

function periodButtonClass(isActive: boolean) {
  return isActive
    ? 'rounded-xl bg-[#0F172A] px-4 py-2 text-sm font-bold text-white disabled:cursor-not-allowed disabled:opacity-60'
    : 'rounded-xl bg-[#F1F5F9] px-4 py-2 text-sm font-bold text-[#475569] transition hover:bg-[#E2E8F0] disabled:cursor-not-allowed disabled:opacity-60'
}

function Badge({ label, tone = 'default' }: { label: string; tone?: 'default' | 'danger' | 'success' | 'warning' }) {
  const className = tone === 'danger' ? 'bg-[#DC2626] text-white' : tone === 'success' ? 'bg-[#DCFCE7] text-[#15803D]' : tone === 'warning' ? 'bg-[#FFEDD5] text-[#C2410C]' : 'bg-[#E2E8F0] text-[#475569]'

  return <span className={`${className} inline-flex rounded-full px-3 py-1 text-[10px] font-extrabold uppercase tracking-wide`}>{label}</span>
}

function labelFor(labels: Record<string, string>, value: string) {
  return labels[value] ?? value
}

function greeting() {
  const hour = new Date().getHours()
  if (hour < 12) return 'Günaydın'
  if (hour < 18) return 'İyi günler'
  return 'İyi akşamlar'
}

function currentShiftLabel() {
  const hour = new Date().getHours()
  if (hour >= 7 && hour < 15) return 'Sabah'
  if (hour >= 15 && hour < 23) return 'Akşam'
  return 'Gece'
}

function formatTime(value: string) {
  return new Intl.DateTimeFormat('tr-TR', { hour: '2-digit', minute: '2-digit' }).format(new Date(value))
}

function formatDateTime(value: string) {
  return new Intl.DateTimeFormat('tr-TR', { day: '2-digit', month: 'short', year: 'numeric', hour: '2-digit', minute: '2-digit' }).format(new Date(value))
}

export default DashboardView
