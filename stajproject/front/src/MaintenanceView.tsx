import { useEffect, useState, type ReactNode } from 'react'
import ExecutiveReportDownload from './ExecutiveReportDownload'
import { requestJson } from './apiClient'
import { StatusMessage } from './UiState'

type MaintenanceViewProps = {
  apiBaseUrl: string
  token: string
}

type MaintenanceScreen = 'plans' | 'new' | 'detail' | 'history'
type MaintenanceStatus = 'Planned' | 'Started' | 'Completed' | 'Delayed'
type MaintenancePriority = 'Low' | 'Medium' | 'High' | 'Critical'
type MaintenanceResultStatus = 'Completed' | 'PartiallyCompleted' | 'Failed'
type EquipmentStatus = 'Active' | 'Passive' | 'Maintenance' | 'Faulted'

type LocationItem = {
  id: string
  code: string
  name: string
  type: string
  isActive: boolean
}

type EquipmentListItem = {
  id: string
  code: string
  name: string
  brand?: string | null
  model?: string | null
  serialNo?: string | null
  locationId: string
  locationName: string
  technicalSystemId: string
  technicalSystemName: string
  status: EquipmentStatus
  isActive: boolean
}

type UserListItem = {
  id: string
  fullName: string
  username: string
  email: string
  role: string
  title?: string | null
  department?: string | null
  isActive: boolean
}

type MaintenancePlanListItem = {
  id: string
  planNo: string
  equipmentId: string
  equipmentCode: string
  equipmentName: string
  locationId: string
  locationName: string
  technicalSystemId: string
  technicalSystemName: string
  responsibleUserId: string
  responsibleUserName: string
  maintenanceType: string
  plannedDate: string
  frequency?: string | null
  priority: MaintenancePriority
  status: Exclude<MaintenanceStatus, 'Delayed'>
  displayStatus: MaintenanceStatus
  description?: string | null
  startedAt?: string | null
  completedAt?: string | null
  createdAt: string
  updatedAt?: string | null
}

type MaintenanceChecklistItem = {
  text: string
  isChecked: boolean
}

type MaintenanceRecord = {
  id: string
  maintenancePlanId?: string | null
  planNo?: string | null
  equipmentId: string
  equipmentCode: string
  equipmentName: string
  locationId: string
  locationName: string
  technicalSystemId: string
  technicalSystemName: string
  performedByUserId: string
  performedByUserName: string
  maintenanceType: string
  startedAt?: string | null
  completedAt: string
  resultStatus: MaintenanceResultStatus
  description: string
  usedMaterials?: string | null
  checklistItems: MaintenanceChecklistItem[]
  createdAt: string
}

type MaintenancePlanDetail = MaintenancePlanListItem & {
  createdByUserId: string
  createdByUserName: string
  responsibleUserTitle?: string | null
  responsibleUserDepartment?: string | null
  records: MaintenanceRecord[]
}

type MaintenanceFilters = {
  locationId: string
  status: string
  plannedDate: string
}

type MaintenanceFormState = {
  equipmentId: string
  responsibleUserId: string
  maintenanceType: string
  plannedDate: string
  frequency: string
  priority: MaintenancePriority
  description: string
}

type CompleteFormState = {
  completedAt: string
  resultStatus: MaintenanceResultStatus
  description: string
  usedMaterials: string
}

const maintenanceStatuses: MaintenanceStatus[] = ['Planned', 'Started', 'Completed', 'Delayed']
const maintenancePriorities: MaintenancePriority[] = ['Low', 'Medium', 'High', 'Critical']
const maintenanceTypes = ['Haftalık Periyodik', 'Aylık', '3 Aylık', '6 Aylık', 'Yıllık', 'Tek Seferlik']
const maintenanceFrequencies = ['Haftalık', 'Aylık', '3 Aylık', '6 Aylık', 'Yıllık', 'Tek Seferlik']

const statusLabels: Record<MaintenanceStatus, string> = {
  Planned: 'Planlandı',
  Started: 'Başladı',
  Completed: 'Tamamlandı',
  Delayed: 'Gecikti',
}

const statusBadgeClasses: Record<MaintenanceStatus, string> = {
  Planned: 'bg-[#DCFCE7] text-[#16A34A]',
  Started: 'bg-[#FEF08A] text-[#854D0E]',
  Completed: 'bg-[#DBEAFE] text-[#1D4ED8]',
  Delayed: 'bg-[#FEE2E2] text-[#BA1A1A]',
}

const priorityLabels: Record<MaintenancePriority, string> = {
  Low: 'Düşük',
  Medium: 'Orta',
  High: 'Yüksek',
  Critical: 'Kritik',
}

const resultLabels: Record<MaintenanceResultStatus, string> = {
  Completed: 'Tamamlandı',
  PartiallyCompleted: 'Kısmi Tamamlandı',
  Failed: 'Başarısız',
}

const defaultFilters: MaintenanceFilters = {
  locationId: '',
  status: '',
  plannedDate: '',
}

const defaultChecklistItems: MaintenanceChecklistItem[] = [
  { text: 'Fiziksel hasar kontrolü yapıldı.', isChecked: false },
  { text: 'Bağlantı, conta ve sızdırmazlık kontrolleri yapıldı.', isChecked: false },
  { text: 'Kalibrasyon ve çalışma testi gerçekleştirildi.', isChecked: false },
]

function MaintenanceView({ apiBaseUrl, token }: MaintenanceViewProps) {
  const [screen, setScreen] = useState<MaintenanceScreen>('plans')
  const [locations, setLocations] = useState<LocationItem[]>([])
  const [equipment, setEquipment] = useState<EquipmentListItem[]>([])
  const [responsibleUsers, setResponsibleUsers] = useState<UserListItem[]>([])
  const [plans, setPlans] = useState<MaintenancePlanListItem[]>([])
  const [records, setRecords] = useState<MaintenanceRecord[]>([])
  const [selectedPlan, setSelectedPlan] = useState<MaintenancePlanDetail | null>(null)
  const [filters, setFilters] = useState<MaintenanceFilters>(defaultFilters)
  const [form, setForm] = useState<MaintenanceFormState>(createEmptyForm())
  const [completeForm, setCompleteForm] = useState<CompleteFormState>(createEmptyCompleteForm())
  const [checklistItems, setChecklistItems] = useState<MaintenanceChecklistItem[]>(defaultChecklistItems)
  const [detailDescription, setDetailDescription] = useState('')
  const [isLoading, setIsLoading] = useState(false)
  const [message, setMessage] = useState('Bakım yönetimi verileri yükleniyor...')

  const selectedEquipment = equipment.find((item) => item.id === form.equipmentId) ?? equipment[0]

  useEffect(() => {
    let ignore = false

    async function loadInitialData() {
      setIsLoading(true)
      try {
        async function initialRequest<T>(path: string): Promise<T> {
          return requestJson<T>(`${apiBaseUrl}${path}`, {
            headers: { Authorization: `Bearer ${token}` },
          })
        }

        const [locationData, equipmentData, userData, planData, recordData] = await Promise.all([
          initialRequest<LocationItem[]>('/api/locations'),
          initialRequest<EquipmentListItem[]>('/api/equipment?isActive=true'),
          initialRequest<UserListItem[]>('/api/maintenance/responsible-users'),
          initialRequest<MaintenancePlanListItem[]>('/api/maintenance/plans'),
          initialRequest<MaintenanceRecord[]>('/api/maintenance/records'),
        ])

        if (ignore) {
          return
        }

        setLocations(locationData)
        setEquipment(equipmentData)
        setResponsibleUsers(userData)
        setPlans(planData)
        setRecords(recordData)
        setForm((current) => ({
          ...current,
          equipmentId: current.equipmentId || equipmentData[0]?.id || '',
          responsibleUserId: current.responsibleUserId || userData[0]?.id || '',
        }))
        setMessage(`${planData.length} bakım planı ve ${recordData.length} bakım geçmişi kaydı yüklendi.`)
      } catch (error) {
        if (!ignore) {
          setMessage(error instanceof Error ? error.message : 'Bakım yönetimi verileri yüklenemedi.')
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

  async function apiRequest<T>(path: string, options: RequestInit = {}): Promise<T> {
    const headers = new Headers(options.headers)
    headers.set('Authorization', `Bearer ${token}`)

    if (options.body && !headers.has('Content-Type')) {
      headers.set('Content-Type', 'application/json')
    }

    return requestJson<T>(`${apiBaseUrl}${path}`, { ...options, headers })
  }

  async function loadPlans(currentFilters: MaintenanceFilters = filters) {
    const params = new URLSearchParams()
    if (currentFilters.locationId) {
      params.set('locationId', currentFilters.locationId)
    }
    if (currentFilters.status) {
      params.set('status', currentFilters.status)
    }
    if (currentFilters.plannedDate) {
      params.set('plannedFrom', currentFilters.plannedDate)
      params.set('plannedTo', currentFilters.plannedDate)
    }

    const path = params.size ? `/api/maintenance/plans?${params.toString()}` : '/api/maintenance/plans'
    const data = await apiRequest<MaintenancePlanListItem[]>(path)
    setPlans(data)
    return data
  }

  async function loadRecords() {
    const data = await apiRequest<MaintenanceRecord[]>('/api/maintenance/records')
    setRecords(data)
    return data
  }

  async function handleApplyFilters() {
    setIsLoading(true)
    try {
      const data = await loadPlans(filters)
      setMessage(`${data.length} bakım planı filtre sonucunda listelendi.`)
    } catch (error) {
      setMessage(error instanceof Error ? error.message : 'Bakım planları alınamadı.')
    } finally {
      setIsLoading(false)
    }
  }

  async function handleResetFilters() {
    setIsLoading(true)
    try {
      setFilters(defaultFilters)
      const data = await loadPlans(defaultFilters)
      setMessage(`Filtreler temizlendi. ${data.length} bakım planı listelendi.`)
    } catch (error) {
      setMessage(error instanceof Error ? error.message : 'Filtreler temizlenemedi.')
    } finally {
      setIsLoading(false)
    }
  }

  function startCreatePlan() {
    setForm({ ...createEmptyForm(), equipmentId: equipment[0]?.id || '', responsibleUserId: responsibleUsers[0]?.id || '' })
    setScreen('new')
    setMessage('Yeni bakım planı formu açıldı.')
  }

  async function handleCreatePlan() {
    if (!form.equipmentId || !form.responsibleUserId || !form.maintenanceType || !form.plannedDate) {
      setMessage('Ekipman, bakım türü, planlanan tarih ve sorumlu kişi zorunludur.')
      return
    }

    setIsLoading(true)
    try {
      const detail = await apiRequest<MaintenancePlanDetail>('/api/maintenance/plans', {
        method: 'POST',
        body: JSON.stringify(form),
      })
      await loadPlans(filters)
      setSelectedPlan(detail)
      setDetailDescription(detail.description ?? '')
      setScreen('detail')
      setMessage(`${detail.planNo} bakım planı oluşturuldu.`)
    } catch (error) {
      setMessage(error instanceof Error ? error.message : 'Bakım planı oluşturulamadı.')
    } finally {
      setIsLoading(false)
    }
  }

  async function handleSelectPlan(id: string, showMessage = true) {
    setIsLoading(true)
    try {
      const detail = await apiRequest<MaintenancePlanDetail>(`/api/maintenance/plans/${id}`)
      setSelectedPlan(detail)
      setDetailDescription(detail.description ?? '')
      prepareCompletionState(detail)
      setScreen('detail')
      if (showMessage) {
        setMessage(`${detail.planNo} bakım detayı açıldı.`)
      }
    } catch (error) {
      setMessage(error instanceof Error ? error.message : 'Bakım detayı alınamadı.')
    } finally {
      setIsLoading(false)
    }
  }

  async function handleSavePlanDetails() {
    if (!selectedPlan) {
      return
    }

    if (selectedPlan.status !== 'Planned') {
      setMessage('Yalnızca planlandı durumundaki bakım planı güncellenebilir.')
      return
    }

    setIsLoading(true)
    try {
      const detail = await apiRequest<MaintenancePlanDetail>(`/api/maintenance/plans/${selectedPlan.id}`, {
        method: 'PUT',
        body: JSON.stringify({
          equipmentId: selectedPlan.equipmentId,
          responsibleUserId: selectedPlan.responsibleUserId,
          maintenanceType: selectedPlan.maintenanceType,
          plannedDate: selectedPlan.plannedDate,
          frequency: selectedPlan.frequency,
          priority: selectedPlan.priority,
          description: detailDescription,
        }),
      })
      await loadPlans(filters)
      setSelectedPlan(detail)
      setMessage(`${detail.planNo} bakım açıklaması güncellendi.`)
    } catch (error) {
      setMessage(error instanceof Error ? error.message : 'Bakım planı güncellenemedi.')
    } finally {
      setIsLoading(false)
    }
  }

  async function handleStartPlan() {
    if (!selectedPlan) {
      return
    }

    setIsLoading(true)
    try {
      const detail = await apiRequest<MaintenancePlanDetail>(`/api/maintenance/plans/${selectedPlan.id}/start`, {
        method: 'POST',
        body: JSON.stringify({ note: 'Bakım detay ekranından başlatıldı.' }),
      })
      await loadPlans(filters)
      setSelectedPlan(detail)
      prepareCompletionState(detail)
      setMessage(`${detail.planNo} bakım planı başlatıldı.`)
    } catch (error) {
      setMessage(error instanceof Error ? error.message : 'Bakım başlatılamadı.')
    } finally {
      setIsLoading(false)
    }
  }

  async function handleCompletePlan() {
    if (!selectedPlan) {
      return
    }

    if (!completeForm.description.trim()) {
      setMessage('Bakımı tamamlamak için yapılan işlemler açıklaması zorunludur.')
      return
    }

    setIsLoading(true)
    try {
      const detail = await apiRequest<MaintenancePlanDetail>(`/api/maintenance/plans/${selectedPlan.id}/complete`, {
        method: 'POST',
        body: JSON.stringify({
          completedAt: completeForm.completedAt ? new Date(completeForm.completedAt).toISOString() : null,
          resultStatus: completeForm.resultStatus,
          description: completeForm.description.trim(),
          usedMaterials: completeForm.usedMaterials || null,
          checklistItems,
        }),
      })
      await Promise.all([loadPlans(filters), loadRecords()])
      setSelectedPlan(detail)
      prepareCompletionState(detail)
      setMessage(`${detail.planNo} bakım planı tamamlandı ve bakım geçmişine işlendi.`)
    } catch (error) {
      setMessage(error instanceof Error ? error.message : 'Bakım tamamlanamadı.')
    } finally {
      setIsLoading(false)
    }
  }

  async function openHistoryScreen() {
    setScreen('history')
    setIsLoading(true)
    try {
      const data = await loadRecords()
      setMessage(`${data.length} tamamlanmış bakım kaydı listeleniyor.`)
    } catch (error) {
      setMessage(error instanceof Error ? error.message : 'Bakım geçmişi alınamadı.')
    } finally {
      setIsLoading(false)
    }
  }

  function prepareCompletionState(detail: MaintenancePlanDetail) {
    const lastRecord = detail.records.length > 0 ? detail.records[detail.records.length - 1] : null
    setCompleteForm({
      completedAt: toDateTimeLocalInput(detail.completedAt ?? lastRecord?.completedAt ?? new Date().toISOString()),
      resultStatus: lastRecord?.resultStatus ?? 'Completed',
      description: lastRecord?.description ?? '',
      usedMaterials: lastRecord?.usedMaterials ?? '',
    })
    setChecklistItems(lastRecord?.checklistItems.length ? lastRecord.checklistItems : defaultChecklistItems.map((item) => ({ ...item })))
  }

  return (
    <section className="module-font mx-auto w-full max-w-[1600px] px-5 py-6 lg:px-6">
      <div className="mb-6 flex flex-col gap-4 md:flex-row md:items-end md:justify-between">
        <div>
          <h2 className="text-3xl font-bold tracking-tight text-black">{screenTitle(screen)}</h2>
          <p className="mt-2 text-[15px] leading-5 text-[#45464D]">Planlı bakım faaliyetlerini oluştur, durumunu ilerlet ve tamamlanan işleri geçmişe işle.</p>
        </div>
        <div className="flex flex-wrap gap-2">
          <ExecutiveReportDownload apiBaseUrl={apiBaseUrl} disabled={isLoading} fileBaseName="bakim-yonetici-raporu" label="Bakım Raporu" path="/api/exports/maintenance" token={token} onMessage={setMessage} />
          <MaintenanceScreenButton active={screen === 'plans'} label="Bakım Planları" onClick={() => setScreen('plans')} />
          <MaintenanceScreenButton active={screen === 'new'} label="Yeni Bakım Planı" onClick={startCreatePlan} />
          <MaintenanceScreenButton active={screen === 'detail'} disabled={!selectedPlan} label="Bakım Detay" onClick={() => setScreen('detail')} />
          <MaintenanceScreenButton active={screen === 'history'} label="Bakım Geçmişi" onClick={() => void openHistoryScreen()} />
        </div>
      </div>

      <div key={screen} className="screen-transition">
        {screen === 'plans' ? renderPlansScreen() : null}
        {screen === 'new' ? renderNewPlanScreen() : null}
        {screen === 'detail' ? renderDetailScreen() : null}
        {screen === 'history' ? renderHistoryScreen() : null}
      </div>

      <div className="mt-4"><StatusMessage busy={isLoading} message={message} /></div>
    </section>
  )

  function renderPlansScreen() {
    return (
      <>
        <div className="mb-6 flex justify-end">
          <button className="flex items-center gap-2 bg-black px-5 py-3 text-sm font-bold text-white shadow-sm" disabled={isLoading} type="button" onClick={startCreatePlan}>
            <span className="material-symbols-outlined text-[18px]">add</span>
            Yeni Bakım Planı
          </button>
        </div>

        <div className="mb-6 border border-[#C6C6CD] bg-white p-4 shadow-[0px_1px_3px_rgba(15,23,42,0.08)]">
          <div className="grid gap-4 md:grid-cols-[1fr_1fr_1fr_88px]">
            <MaintenanceFieldLabel label="Lokasyon">
              <select className="asset-input" value={filters.locationId} onChange={(event) => setFilters((current) => ({ ...current, locationId: event.target.value }))}>
                <option value="">Tüm Lokasyonlar</option>
                {locations.map((location) => <option key={location.id} value={location.id}>{location.name}</option>)}
              </select>
            </MaintenanceFieldLabel>
            <MaintenanceFieldLabel label="Durum">
              <select className="asset-input" value={filters.status} onChange={(event) => setFilters((current) => ({ ...current, status: event.target.value }))}>
                <option value="">Tüm Durumlar</option>
                {maintenanceStatuses.map((status) => <option key={status} value={status}>{statusLabels[status]}</option>)}
              </select>
            </MaintenanceFieldLabel>
            <MaintenanceFieldLabel label="Planlanan Tarih">
              <input className="asset-input" type="date" value={filters.plannedDate} onChange={(event) => setFilters((current) => ({ ...current, plannedDate: event.target.value }))} />
            </MaintenanceFieldLabel>
            <div className="flex items-end gap-2 md:block">
              <button className="h-10 w-full border border-[#76777D] bg-white px-3 text-[13px] font-semibold text-[#45464D]" disabled={isLoading} type="button" onClick={() => void handleResetFilters()}>Temizle</button>
            </div>
          </div>
          <div className="mt-3 flex justify-end">
            <button className="h-10 border border-[#3755C3] bg-[#3755C3] px-5 text-sm font-semibold text-white disabled:bg-[#76777D]" disabled={isLoading} type="button" onClick={() => void handleApplyFilters()}>Filtrele</button>
          </div>
        </div>

        <section className="overflow-hidden border border-[#C6C6CD] bg-white shadow-[0px_1px_3px_rgba(15,23,42,0.08)]">
          <div className="overflow-x-auto">
            <table className="w-full border-collapse text-left">
              <thead>
                <tr className="border-b border-[#C6C6CD] bg-[#FCF8FA]">
                  <MaintenanceTableHeader>Bakım No</MaintenanceTableHeader>
                  <MaintenanceTableHeader>Ekipman</MaintenanceTableHeader>
                  <MaintenanceTableHeader>Lokasyon</MaintenanceTableHeader>
                  <MaintenanceTableHeader>Bakım Türü</MaintenanceTableHeader>
                  <MaintenanceTableHeader>Planlanan Tarih</MaintenanceTableHeader>
                  <MaintenanceTableHeader>Sorumlu</MaintenanceTableHeader>
                  <MaintenanceTableHeader>Durum</MaintenanceTableHeader>
                  <MaintenanceTableHeader alignRight>İşlem</MaintenanceTableHeader>
                </tr>
              </thead>
              <tbody className="text-[13px] text-[#1B1B1D]">
                {plans.map((plan, index) => (
                  <tr key={plan.id} className={`border-b border-[#C6C6CD] transition-colors hover:bg-[#FCF8FA] ${index % 2 === 1 ? 'bg-[#FCF8FA]/50' : 'bg-white'}`}>
                    <td className="p-4"><button className="font-mono font-bold text-black hover:text-[#3755C3]" type="button" onClick={() => void handleSelectPlan(plan.id)}>{plan.planNo}</button></td>
                    <td className="p-4"><p className="font-semibold text-black">{plan.equipmentName}</p><p className="font-mono text-xs text-[#76777D]">{plan.equipmentCode}</p></td>
                    <td className="p-4 text-[#45464D]">{plan.locationName}</td>
                    <td className="p-4"><span className="bg-[#E4E2E4] px-2 py-1 text-xs font-medium text-[#45464D]">{plan.maintenanceType}</span></td>
                    <td className={`p-4 font-mono ${plan.displayStatus === 'Delayed' ? 'font-bold text-[#BA1A1A]' : 'text-[#1B1B1D]'}`}>{formatDate(plan.plannedDate)}</td>
                    <td className="p-4"><UserAvatar name={plan.responsibleUserName} /></td>
                    <td className="p-4"><MaintenanceStatusBadge status={plan.displayStatus} /></td>
                    <td className="p-4 text-right"><button className="p-1 text-[#45464D] transition-colors hover:text-black" type="button" onClick={() => void handleSelectPlan(plan.id)}><span className="material-symbols-outlined text-[18px]">more_vert</span></button></td>
                  </tr>
                ))}
              </tbody>
            </table>
          </div>
          {plans.length === 0 ? <div className="p-8 text-center text-sm text-[#45464D]">{isLoading ? 'Bakım planları yükleniyor...' : 'Filtreye uygun bakım planı bulunamadı.'}</div> : null}
          <div className="flex items-center justify-between border-t border-[#C6C6CD] bg-white p-3 text-[13px] text-[#45464D]"><span>Toplam {plans.length} bakım planı gösteriliyor</span><span className="text-xs text-[#76777D]">Planlı bakım takibi</span></div>
        </section>
      </>
    )
  }

  function renderNewPlanScreen() {
    const featuredEquipment = equipment.slice(0, 2)

    return (
      <section className="mx-auto max-w-[1180px] border border-[#C6C6CD] bg-white p-7 shadow-[0px_1px_3px_rgba(15,23,42,0.08)]">
        <div className="border-b border-[#C6C6CD] pb-8">
          <h3 className="text-xl font-bold text-black">Hedef Ekipman</h3>
          <p className="mt-2 text-sm text-[#45464D]">Bakımın uygulanacağı varlığı seçin.</p>
          <div className="mt-5 grid gap-4 md:grid-cols-2">
            {featuredEquipment.map((item) => (
              <button key={item.id} className={`flex items-center gap-4 border p-5 text-left transition-colors ${form.equipmentId === item.id ? 'border-[#3755C3] bg-[#F0EDEF]' : 'border-[#C6C6CD] bg-white hover:border-[#3755C3]'}`} type="button" onClick={() => setForm((current) => ({ ...current, equipmentId: item.id }))}>
                <span className="material-symbols-outlined text-[#3755C3]">precision_manufacturing</span>
                <span><span className="block text-lg font-bold text-black">{item.name}</span><span className="mt-1 block font-mono text-sm text-[#45464D]">{item.code}</span></span>
              </button>
            ))}
          </div>
          <MaintenanceFieldLabel label="Diğer ekipmanları ara">
            <select className="asset-input mt-4" value={form.equipmentId} onChange={(event) => setForm((current) => ({ ...current, equipmentId: event.target.value }))}>
              <option value="">Ekipman seçin...</option>
              {equipment.map((item) => <option key={item.id} value={item.id}>{item.code} - {item.name}</option>)}
            </select>
          </MaintenanceFieldLabel>
        </div>

        <div className="grid gap-8 border-b border-[#C6C6CD] py-8 md:grid-cols-2">
          <MaintenanceFieldLabel label="Bakım Türü">
            <select className="asset-input" value={form.maintenanceType} onChange={(event) => setForm((current) => ({ ...current, maintenanceType: event.target.value }))}>
              {maintenanceTypes.map((type) => <option key={type} value={type}>{type}</option>)}
            </select>
          </MaintenanceFieldLabel>
          <MaintenanceFieldLabel label="Planlanan Başlangıç Tarihi">
            <input className="asset-input" type="date" value={form.plannedDate} onChange={(event) => setForm((current) => ({ ...current, plannedDate: event.target.value }))} />
          </MaintenanceFieldLabel>
          <MaintenanceFieldLabel label="Periyot">
            <select className="asset-input" value={form.frequency} onChange={(event) => setForm((current) => ({ ...current, frequency: event.target.value }))}>
              {maintenanceFrequencies.map((frequency) => <option key={frequency} value={frequency}>{frequency}</option>)}
            </select>
          </MaintenanceFieldLabel>
          <MaintenanceFieldLabel label="Kritiklik">
            <select className="asset-input" value={form.priority} onChange={(event) => setForm((current) => ({ ...current, priority: event.target.value as MaintenancePriority }))}>
              {maintenancePriorities.map((priority) => <option key={priority} value={priority}>{priorityLabels[priority]}</option>)}
            </select>
          </MaintenanceFieldLabel>
        </div>

        <div className="grid gap-6 py-8">
          <MaintenanceFieldLabel label="Sorumlu Mühendis / Teknisyen">
            <select className="asset-input" value={form.responsibleUserId} onChange={(event) => setForm((current) => ({ ...current, responsibleUserId: event.target.value }))}>
              <option value="">Kullanıcı veya ekip ara...</option>
              {responsibleUsers.map((user) => <option key={user.id} value={user.id}>{user.fullName} - {user.role}</option>)}
            </select>
          </MaintenanceFieldLabel>
          <MaintenanceFieldLabel label="İşlem Açıklaması ve Notlar">
            <textarea className="min-h-32 w-full border border-[#C6C6CD] bg-white p-3 text-sm outline-none focus:border-2 focus:border-[#3755C3]" placeholder="Yapılacak işlemleri, gerekli yedek parçaları ve özel güvenlik talimatlarını buraya girin..." value={form.description} onChange={(event) => setForm((current) => ({ ...current, description: event.target.value }))} />
          </MaintenanceFieldLabel>
          {selectedEquipment ? (
            <div className="grid gap-4 border border-[#C6C6CD] bg-[#FCF8FA] p-4 md:grid-cols-3">
              <MaintenanceSpecCell label="Seçilen Ekipman" value={selectedEquipment.name} />
              <MaintenanceSpecCell label="Lokasyon" value={selectedEquipment.locationName} />
              <MaintenanceSpecCell label="Sistem" value={selectedEquipment.technicalSystemName} />
            </div>
          ) : null}
        </div>

        <div className="flex flex-wrap justify-end gap-4 border-t border-[#C6C6CD] pt-5">
          <button className="px-5 py-2 text-sm font-semibold text-[#45464D] hover:bg-[#E4E2E4]" type="button" onClick={() => setScreen('plans')}>İptal</button>
          <button className="bg-black px-7 py-2 text-sm font-bold text-white disabled:bg-[#76777D]" disabled={isLoading} type="button" onClick={() => void handleCreatePlan()}>Plan Oluştur</button>
        </div>
      </section>
    )
  }

  function renderDetailScreen() {
    if (!selectedPlan) {
      return <MaintenanceEmptyPanel title="Bakım Detay" text="Listeden bir bakım planı seçildiğinde detay ekranı burada açılır." />
    }

    const canStart = selectedPlan.status === 'Planned'
    const canComplete = selectedPlan.status === 'Started'
    const isCompleted = selectedPlan.status === 'Completed'

    return (
      <>
        <div className="mb-6 flex flex-col gap-4 md:flex-row md:items-start md:justify-between">
          <div>
            <p className="text-sm text-[#45464D]">Bakım <span className="mx-2">›</span> Görev Listesi <span className="mx-2">›</span> <strong className="text-black">{selectedPlan.planNo} Detay</strong></p>
            <h3 className="mt-2 text-3xl font-bold tracking-tight text-black">Planlı Bakım: {selectedPlan.maintenanceType}</h3>
          </div>
          <div className="flex gap-2"><button className="border border-[#C6C6CD] bg-white px-5 py-2 font-semibold text-[#45464D]" type="button" onClick={() => setScreen('plans')}>İptal</button><button className="bg-black px-5 py-2 font-semibold text-white disabled:bg-[#76777D]" disabled={isLoading || isCompleted} type="button" onClick={() => void handleSavePlanDetails()}>Kaydet</button></div>
        </div>

        <div className="grid gap-6 xl:grid-cols-[1fr_420px]">
          <div className="space-y-6">
            <section className="border border-[#C6C6CD] bg-white p-5 shadow-[0px_1px_3px_rgba(15,23,42,0.08)]">
              <h4 className="mb-4 flex items-center gap-2 border-b border-[#C6C6CD] pb-3 text-xl font-bold text-black"><span className="material-symbols-outlined text-[#45464D]">inventory_2</span>Ekipman Bilgileri</h4>
              <div className="grid gap-4 md:grid-cols-4">
                <MaintenanceSpecCell mono label="Ekipman Kodu" value={selectedPlan.equipmentCode} />
                <MaintenanceSpecCell label="Sistem" value={selectedPlan.technicalSystemName} />
                <MaintenanceSpecCell label="Lokasyon" value={selectedPlan.locationName} />
                <MaintenanceSpecCell label="Kritiklik" value={priorityLabels[selectedPlan.priority]} tone={selectedPlan.priority === 'High' || selectedPlan.priority === 'Critical' ? 'danger' : 'normal'} />
              </div>
            </section>

            <section className="border border-[#C6C6CD] bg-white p-5 shadow-[0px_1px_3px_rgba(15,23,42,0.08)]">
              <h4 className="mb-4 flex items-center gap-2 border-b border-[#C6C6CD] pb-3 text-xl font-bold text-black"><span className="material-symbols-outlined text-[#45464D]">list_alt</span>Bakım İşlemleri & Açıklama</h4>
              <MaintenanceFieldLabel label={canComplete ? 'Yapılan İşlemler (Detaylı Açıklama)' : 'Plan Açıklaması'}>
                <textarea className="min-h-36 w-full border border-[#C6C6CD] bg-white p-3 text-sm outline-none focus:border-2 focus:border-[#3755C3] disabled:bg-[#F6F3F5]" disabled={isCompleted} placeholder="Bakım sırasında gerçekleştirilen tüm işlemleri, değiştirilen parçaları ve gözlemleri buraya giriniz..." value={canComplete ? completeForm.description : detailDescription} onChange={(event) => canComplete ? setCompleteForm((current) => ({ ...current, description: event.target.value })) : setDetailDescription(event.target.value)} />
              </MaintenanceFieldLabel>
              <MaintenanceFieldLabel label="Kontrol Listesi (Checklist)">
                <div className="mt-2 space-y-3 border border-[#C6C6CD] bg-[#F6F3F5] p-4">
                  {checklistItems.map((item, index) => (
                    <label key={item.text} className="flex items-center gap-3 text-sm text-[#45464D]">
                      <input className="h-4 w-4" disabled={!canComplete} type="checkbox" checked={item.isChecked} onChange={(event) => setChecklistItems((current) => current.map((entry, entryIndex) => entryIndex === index ? { ...entry, isChecked: event.target.checked } : entry))} />
                      {item.text}
                    </label>
                  ))}
                </div>
              </MaintenanceFieldLabel>
            </section>
          </div>

          <aside className="space-y-5">
            <section className="border border-[#C6C6CD] bg-white p-5 shadow-[0px_1px_3px_rgba(15,23,42,0.08)]">
              <h4 className="mb-4 flex items-center gap-2 border-b border-[#C6C6CD] pb-3 text-xl font-bold text-black"><span className="material-symbols-outlined text-[#45464D]">update</span>Durum Güncelleme</h4>
              <MaintenanceFieldLabel label="Mevcut Durum">
                <select className="asset-input" disabled value={selectedPlan.status}><option>{statusLabels[selectedPlan.status]}</option></select>
              </MaintenanceFieldLabel>
              <MaintenanceFieldLabel label="Tamamlanma Tarihi & Saati">
                <input className="asset-input" disabled={!canComplete} type="datetime-local" value={completeForm.completedAt} onChange={(event) => setCompleteForm((current) => ({ ...current, completedAt: event.target.value }))} />
              </MaintenanceFieldLabel>
              <MaintenanceFieldLabel label="Sorumlu Teknisyen">
                <input className="asset-input" readOnly value={selectedPlan.responsibleUserName} />
              </MaintenanceFieldLabel>
              {canComplete ? (
                <MaintenanceFieldLabel label="Sonuç">
                  <select className="asset-input" value={completeForm.resultStatus} onChange={(event) => setCompleteForm((current) => ({ ...current, resultStatus: event.target.value as MaintenanceResultStatus }))}>
                    {Object.entries(resultLabels).map(([value, label]) => <option key={value} value={value}>{label}</option>)}
                  </select>
                </MaintenanceFieldLabel>
              ) : null}
              {canComplete ? (
                <MaintenanceFieldLabel label="Kullanılan Malzemeler">
                  <input className="asset-input" value={completeForm.usedMaterials} onChange={(event) => setCompleteForm((current) => ({ ...current, usedMaterials: event.target.value }))} />
                </MaintenanceFieldLabel>
              ) : null}
              {canStart ? <MaintenanceActionButton disabled={isLoading} icon="play_arrow" label="Bakımı Başlat" onClick={() => void handleStartPlan()} /> : null}
              {canComplete ? <MaintenanceActionButton disabled={isLoading || !completeForm.description.trim()} icon="task_alt" label="Bakımı Tamamla" onClick={() => void handleCompletePlan()} /> : null}
              {isCompleted ? <div className="mt-4 border border-[#C6C6CD] bg-[#F6F3F5] p-3 text-sm text-[#45464D]">Bu bakım tamamlandı ve geçmiş kayıtlarına işlendi.</div> : null}
            </section>

            <section className="border border-[#C6C6CD] bg-white p-5 shadow-[0px_1px_3px_rgba(15,23,42,0.08)]">
              <h4 className="mb-4 flex items-center gap-2 border-b border-[#C6C6CD] pb-3 text-xl font-bold text-black"><span className="material-symbols-outlined text-[#45464D]">history</span>İşlem Geçmişi</h4>
              <div className="space-y-4">
                <TimelineItem active title="İş Emri Oluşturuldu" subtitle={`${formatDateTime(selectedPlan.createdAt)} - ${selectedPlan.createdByUserName}`} />
                {selectedPlan.startedAt ? <TimelineItem active={selectedPlan.status === 'Started' || selectedPlan.status === 'Completed'} title="Bakım Başlatıldı" subtitle={`${formatDateTime(selectedPlan.startedAt)} - ${selectedPlan.responsibleUserName}`} /> : null}
                {selectedPlan.completedAt ? <TimelineItem active title="Bakım Tamamlandı" subtitle={`${formatDateTime(selectedPlan.completedAt)} - ${selectedPlan.records[0]?.performedByUserName ?? selectedPlan.responsibleUserName}`} /> : null}
              </div>
            </section>
          </aside>
        </div>
      </>
    )
  }

  function renderHistoryScreen() {
    return (
      <section className="overflow-hidden border border-[#C6C6CD] bg-white shadow-[0px_1px_3px_rgba(15,23,42,0.08)]">
        <div className="flex flex-col gap-2 border-b border-[#C6C6CD] p-5 md:flex-row md:items-center md:justify-between">
          <div><p className="text-[11px] font-bold uppercase tracking-wide text-[#45464D]">Bakım Geçmişi</p><h3 className="mt-1 text-xl font-bold text-black">Tamamlanan bakım kayıtları</h3></div>
          <button className="border border-[#C6C6CD] bg-white px-4 py-2 text-sm font-semibold text-[#45464D]" disabled={isLoading} type="button" onClick={() => void openHistoryScreen()}>Yenile</button>
        </div>
        <div className="overflow-x-auto">
          <table className="w-full border-collapse text-left">
            <thead><tr className="border-b border-[#C6C6CD] bg-[#FCF8FA]"><MaintenanceTableHeader>Bakım No</MaintenanceTableHeader><MaintenanceTableHeader>Ekipman</MaintenanceTableHeader><MaintenanceTableHeader>Bakım Türü</MaintenanceTableHeader><MaintenanceTableHeader>Başlangıç</MaintenanceTableHeader><MaintenanceTableHeader>Tamamlanma</MaintenanceTableHeader><MaintenanceTableHeader>Sorumlu</MaintenanceTableHeader><MaintenanceTableHeader>Sonuç</MaintenanceTableHeader><MaintenanceTableHeader alignRight>İşlem</MaintenanceTableHeader></tr></thead>
            <tbody className="text-[13px]">
              {records.map((record, index) => (
                <tr key={record.id} className={`border-b border-[#C6C6CD] hover:bg-[#FCF8FA] ${index % 2 === 1 ? 'bg-[#FCF8FA]/50' : 'bg-white'}`}>
                  <td className="p-4 font-mono font-bold text-black">{record.planNo ?? '-'}</td>
                  <td className="p-4"><p className="font-semibold text-black">{record.equipmentName}</p><p className="font-mono text-xs text-[#76777D]">{record.equipmentCode}</p></td>
                  <td className="p-4">{record.maintenanceType}</td>
                  <td className="p-4 font-mono text-xs text-[#45464D]">{formatDateTime(record.startedAt)}</td>
                  <td className="p-4 font-mono text-xs text-[#45464D]">{formatDateTime(record.completedAt)}</td>
                  <td className="p-4">{record.performedByUserName}</td>
                  <td className="p-4"><span className="bg-[#DBEAFE] px-2 py-1 text-xs font-bold text-[#1D4ED8]">{resultLabels[record.resultStatus]}</span></td>
                  <td className="p-4 text-right">{record.maintenancePlanId ? <button className="text-sm font-semibold text-[#3755C3]" type="button" onClick={() => void handleSelectPlan(record.maintenancePlanId!)}>Detay</button> : '-'}</td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
        {records.length === 0 ? <div className="p-8 text-center text-sm text-[#45464D]">Tamamlanmış bakım kaydı bulunamadı.</div> : null}
      </section>
    )
  }
}

function createEmptyForm(): MaintenanceFormState {
  return {
    equipmentId: '',
    responsibleUserId: '',
    maintenanceType: 'Haftalık Periyodik',
    plannedDate: getDateInputDaysFromNow(7),
    frequency: 'Haftalık',
    priority: 'Medium',
    description: '',
  }
}

function createEmptyCompleteForm(): CompleteFormState {
  return {
    completedAt: toDateTimeLocalInput(new Date().toISOString()),
    resultStatus: 'Completed',
    description: '',
    usedMaterials: '',
  }
}

function screenTitle(screen: MaintenanceScreen) {
  const titles: Record<MaintenanceScreen, string> = {
    plans: 'Bakım Planları',
    new: 'Yeni Bakım Planı Oluştur',
    detail: 'Bakım Detay',
    history: 'Bakım Geçmişi',
  }

  return titles[screen]
}

function MaintenanceScreenButton({ active, disabled = false, label, onClick }: { active: boolean; disabled?: boolean; label: string; onClick: () => void }) {
  return <button className={`${active ? 'bg-black text-white' : 'border border-[#C6C6CD] bg-white text-[#1B1B1D]'} px-4 py-2 text-sm font-semibold disabled:border-[#E4E2E4] disabled:text-[#76777D]`} disabled={disabled} type="button" onClick={onClick}>{label}</button>
}

function MaintenanceFieldLabel({ label, children }: { label: string; children: ReactNode }) {
  return <label className="block text-[11px] font-bold uppercase tracking-wide text-[#45464D]">{label}<div className="mt-1">{children}</div></label>
}

function MaintenanceTableHeader({ children, alignRight = false }: { children: ReactNode; alignRight?: boolean }) {
  return <th className={`p-4 text-[11px] font-bold uppercase tracking-wide text-[#45464D] ${alignRight ? 'text-right' : ''}`}>{children}</th>
}

function MaintenanceStatusBadge({ status }: { status: MaintenanceStatus }) {
  return <span className={`inline-flex px-2 py-1 text-xs font-bold ${statusBadgeClasses[status]}`}>{statusLabels[status]}</span>
}

function MaintenanceSpecCell({ label, mono = false, tone = 'normal', value }: { label: string; mono?: boolean; tone?: 'normal' | 'danger'; value: string }) {
  return <div><p className="text-[11px] font-bold uppercase tracking-wide text-[#45464D]">{label}</p><p className={`mt-2 inline-flex px-2 py-1 text-sm font-semibold ${mono ? 'font-mono' : ''} ${tone === 'danger' ? 'bg-[#FEE2E2] text-[#BA1A1A]' : 'bg-[#F0EDEF] text-black'}`}>{value}</p></div>
}

function MaintenanceActionButton({ disabled, icon, label, onClick }: { disabled: boolean; icon: string; label: string; onClick: () => void }) {
  return <button className="mt-4 flex w-full items-center justify-center gap-2 bg-black px-4 py-2 text-sm font-semibold text-white disabled:bg-[#76777D]" disabled={disabled} type="button" onClick={onClick}><span className="material-symbols-outlined text-[18px]">{icon}</span>{label}</button>
}

function TimelineItem({ active = false, subtitle, title }: { active?: boolean; subtitle: string; title: string }) {
  return <div className="flex gap-3"><div className={`mt-1 h-3 w-3 rounded-full ${active ? 'bg-[#3755C3]' : 'bg-[#C6C6CD]'}`} /><div><p className="text-sm font-semibold text-black">{title}</p><p className="mt-1 text-xs font-medium text-[#45464D]">{subtitle}</p></div></div>
}

function UserAvatar({ name }: { name: string }) {
  return <div className="flex items-center gap-2"><span className="flex h-7 w-7 items-center justify-center rounded-full bg-[#E0E7FF] text-xs font-bold text-[#3755C3]">{getInitials(name)}</span><span>{name}</span></div>
}

function MaintenanceEmptyPanel({ text, title }: { text: string; title: string }) {
  return <section className="border border-[#C6C6CD] bg-white p-8 text-center text-[#45464D]"><h3 className="text-xl font-bold text-black">{title}</h3><p className="mt-2 text-sm">{text}</p></section>
}

function getInitials(name: string) {
  return name.split(' ').filter(Boolean).slice(0, 2).map((part) => part[0]?.toUpperCase()).join('') || 'BK'
}

function getDateInputDaysFromNow(days: number) {
  const date = new Date()
  date.setDate(date.getDate() + days)
  return date.toISOString().slice(0, 10)
}

function toDateTimeLocalInput(value?: string | null) {
  if (!value) {
    return ''
  }

  return new Date(value).toISOString().slice(0, 16)
}

function formatDate(value?: string | null) {
  if (!value) {
    return '-'
  }

  const date = value.includes('T') ? new Date(value) : new Date(`${value}T00:00:00`)
  return new Intl.DateTimeFormat('tr-TR', { dateStyle: 'medium' }).format(date)
}

function formatDateTime(value?: string | null) {
  if (!value) {
    return '-'
  }

  return new Intl.DateTimeFormat('tr-TR', { dateStyle: 'short', timeStyle: 'short' }).format(new Date(value))
}

export default MaintenanceView
