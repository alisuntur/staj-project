import { useEffect, useState, type ReactNode } from 'react'
import ExecutiveReportDownload from './ExecutiveReportDownload'
import { requestJson } from './apiClient'
import { StatusMessage } from './UiState'

type ShiftsViewProps = {
  apiBaseUrl: string
  selectedHandoverNo?: string | null
  token: string
}

type ShiftScreen = 'list' | 'new' | 'detail' | 'openItems'
type ShiftType = 'Morning' | 'Evening' | 'Night'
type ShiftItemType = 'OpenFault' | 'OngoingWork' | 'EquipmentToWatch' | 'PendingMaintenance' | 'CriticalNote'
type FaultPriority = 'Low' | 'Medium' | 'High' | 'Critical'

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

type ShiftHandoverListItem = {
  id: string
  handoverNo: string
  shiftType: ShiftType
  shiftDate: string
  handoverFromUserId: string
  handoverFromUserName: string
  handoverToUserId: string
  handoverToUserName: string
  summary?: string | null
  criticalNotes?: string | null
  itemCount: number
  openItemCount: number
  criticalItemCount: number
  createdAt: string
  updatedAt?: string | null
}

type ShiftItem = {
  id: string
  shiftHandoverId: string
  handoverNo: string
  itemType: ShiftItemType
  title: string
  description?: string | null
  faultId?: string | null
  faultNo?: string | null
  faultStatus?: string | null
  equipmentId?: string | null
  equipmentCode?: string | null
  equipmentName?: string | null
  maintenancePlanId?: string | null
  maintenancePlanNo?: string | null
  priority?: FaultPriority | null
  isCompleted: boolean
  createdAt: string
  updatedAt?: string | null
}

type ShiftHandoverDetail = ShiftHandoverListItem & {
  handoverFromUserTitle?: string | null
  handoverToUserTitle?: string | null
  items: ShiftItem[]
}

type ShiftOpenFault = {
  id: string
  faultNo: string
  equipmentId: string
  equipmentCode: string
  equipmentName: string
  locationName: string
  technicalSystemName: string
  priority: FaultPriority
  status: string
  description: string
}

type ShiftPendingMaintenance = {
  id: string
  planNo: string
  equipmentId: string
  equipmentCode: string
  equipmentName: string
  maintenanceType: string
  plannedDate: string
  priority: FaultPriority
  status: string
  description?: string | null
}

type ShiftEquipmentOption = {
  id: string
  code: string
  name: string
  locationName: string
  technicalSystemName: string
  status: string
}

type ShiftOpenItems = {
  openFaults: ShiftOpenFault[]
  pendingMaintenancePlans: ShiftPendingMaintenance[]
  equipmentToWatch: ShiftEquipmentOption[]
  openShiftItems: ShiftItem[]
}

type ShiftFilters = {
  search: string
  shiftType: string
  shiftDate: string
  userId: string
  hasOpenItems: string
}

type ShiftFormState = {
  shiftType: ShiftType
  shiftDate: string
  handoverFromUserId: string
  handoverToUserId: string
  summary: string
  criticalNotes: string
}

type DraftShiftItem = {
  localId: string
  itemType: ShiftItemType
  title: string
  description: string
  faultId?: string | null
  equipmentId?: string | null
  maintenancePlanId?: string | null
  priority: FaultPriority
}

const shiftTypes: ShiftType[] = ['Morning', 'Evening', 'Night']
const priorities: FaultPriority[] = ['Low', 'Medium', 'High', 'Critical']

const shiftLabels: Record<ShiftType, string> = {
  Morning: 'Sabah',
  Evening: 'Akşam',
  Night: 'Gece',
}

const shiftBadgeClasses: Record<ShiftType, string> = {
  Morning: 'bg-[#DCFCE7] text-[#16A34A]',
  Evening: 'bg-[#FEF08A] text-[#854D0E]',
  Night: 'bg-[#E0E7FF] text-[#3755C3]',
}

const itemLabels: Record<ShiftItemType, string> = {
  OpenFault: 'Açık Arıza',
  OngoingWork: 'Devam Eden İş',
  EquipmentToWatch: 'Takip Edilecek Cihaz',
  PendingMaintenance: 'Bekleyen Bakım',
  CriticalNote: 'Kritik Not',
}

const itemBadgeClasses: Record<ShiftItemType, string> = {
  OpenFault: 'bg-[#FEE2E2] text-[#BA1A1A]',
  OngoingWork: 'bg-[#E4E2E4] text-[#45464D]',
  EquipmentToWatch: 'bg-[#DBEAFE] text-[#1D4ED8]',
  PendingMaintenance: 'bg-[#FEF08A] text-[#854D0E]',
  CriticalNote: 'bg-[#FFE4E6] text-[#BE123C]',
}

const priorityLabels: Record<FaultPriority, string> = {
  Low: 'Düşük',
  Medium: 'Orta',
  High: 'Yüksek',
  Critical: 'Kritik',
}

const priorityBadgeClasses: Record<FaultPriority, string> = {
  Low: 'bg-[#E4E2E4] text-[#45464D]',
  Medium: 'bg-[#DBEAFE] text-[#1D4ED8]',
  High: 'bg-[#FEF08A] text-[#854D0E]',
  Critical: 'bg-[#FEE2E2] text-[#BA1A1A]',
}

const defaultFilters: ShiftFilters = {
  search: '',
  shiftType: '',
  shiftDate: '',
  userId: '',
  hasOpenItems: '',
}

function ShiftsView({ apiBaseUrl, selectedHandoverNo, token }: ShiftsViewProps) {
  const [screen, setScreen] = useState<ShiftScreen>('list')
  const [handovers, setHandovers] = useState<ShiftHandoverListItem[]>([])
  const [users, setUsers] = useState<UserListItem[]>([])
  const [openItems, setOpenItems] = useState<ShiftOpenItems>(createEmptyOpenItems())
  const [selectedHandover, setSelectedHandover] = useState<ShiftHandoverDetail | null>(null)
  const [filters, setFilters] = useState<ShiftFilters>(defaultFilters)
  const [form, setForm] = useState<ShiftFormState>(createEmptyForm())
  const [draftItems, setDraftItems] = useState<DraftShiftItem[]>([])
  const [manualItem, setManualItem] = useState<DraftShiftItem>(createManualItem('OngoingWork'))
  const [isLoading, setIsLoading] = useState(false)
  const [message, setMessage] = useState('Vardiya devir teslim verileri yükleniyor...')

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

        const [handoverData, userData, openItemData] = await Promise.all([
          initialRequest<ShiftHandoverListItem[]>('/api/shifts/handovers'),
          initialRequest<UserListItem[]>('/api/shifts/users'),
          initialRequest<ShiftOpenItems>('/api/shifts/open-items'),
        ])

        if (ignore) {
          return
        }

        setHandovers(handoverData)
        setUsers(userData)
        setOpenItems(openItemData)
        setForm((current) => ({
          ...current,
          handoverFromUserId: current.handoverFromUserId || userData[0]?.id || '',
          handoverToUserId: current.handoverToUserId || userData[1]?.id || userData[0]?.id || '',
        }))
        if (selectedHandoverNo) {
          const selectedHandover = handoverData.find((item) => item.handoverNo === selectedHandoverNo)
          if (selectedHandover) {
            const detail = await initialRequest<ShiftHandoverDetail>(`/api/shifts/handovers/${selectedHandover.id}`)
            if (!ignore) {
              setSelectedHandover(detail)
              setScreen('detail')
            }
          }
        }
        setMessage(`${handoverData.length} vardiya devir teslim kaydı ve ${openItemData.openShiftItems.length} açık devir maddesi yüklendi.`)
      } catch (error) {
        if (!ignore) {
          setMessage(error instanceof Error ? error.message : 'Vardiya verileri yüklenemedi.')
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
  }, [apiBaseUrl, selectedHandoverNo, token])

  async function apiRequest<T>(path: string, options: RequestInit = {}): Promise<T> {
    const headers = new Headers(options.headers)
    headers.set('Authorization', `Bearer ${token}`)

    if (options.body && !headers.has('Content-Type')) {
      headers.set('Content-Type', 'application/json')
    }

    return requestJson<T>(`${apiBaseUrl}${path}`, { ...options, headers })
  }

  async function loadHandovers(currentFilters: ShiftFilters = filters) {
    const params = new URLSearchParams()
    if (currentFilters.search) {
      params.set('search', currentFilters.search)
    }
    if (currentFilters.shiftType) {
      params.set('shiftType', currentFilters.shiftType)
    }
    if (currentFilters.shiftDate) {
      params.set('shiftDate', currentFilters.shiftDate)
    }
    if (currentFilters.userId) {
      params.set('userId', currentFilters.userId)
    }
    if (currentFilters.hasOpenItems) {
      params.set('hasOpenItems', currentFilters.hasOpenItems)
    }

    const path = params.size ? `/api/shifts/handovers?${params.toString()}` : '/api/shifts/handovers'
    const data = await apiRequest<ShiftHandoverListItem[]>(path)
    setHandovers(data)
    return data
  }

  async function loadOpenItems() {
    const data = await apiRequest<ShiftOpenItems>('/api/shifts/open-items')
    setOpenItems(data)
    return data
  }

  async function handleApplyFilters() {
    setIsLoading(true)
    try {
      const data = await loadHandovers(filters)
      setMessage(`${data.length} vardiya devir teslim kaydı filtre sonucunda listelendi.`)
    } catch (error) {
      setMessage(error instanceof Error ? error.message : 'Vardiya listesi alınamadı.')
    } finally {
      setIsLoading(false)
    }
  }

  async function handleResetFilters() {
    setIsLoading(true)
    try {
      setFilters(defaultFilters)
      const data = await loadHandovers(defaultFilters)
      setMessage(`Filtreler temizlendi. ${data.length} devir teslim kaydı listelendi.`)
    } catch (error) {
      setMessage(error instanceof Error ? error.message : 'Filtreler temizlenemedi.')
    } finally {
      setIsLoading(false)
    }
  }

  async function startCreateHandover() {
    setForm(createEmptyFormWithUsers(users))
    setDraftItems([])
    setManualItem(createManualItem('OngoingWork'))
    setScreen('new')
    setIsLoading(true)
    try {
      const data = await loadOpenItems()
      setMessage(`Yeni devir teslim formu açıldı. ${data.openFaults.length} açık arıza ve ${data.pendingMaintenancePlans.length} bekleyen bakım seçilebilir.`)
    } catch (error) {
      setMessage(error instanceof Error ? error.message : 'Açık işler alınamadı.')
    } finally {
      setIsLoading(false)
    }
  }

  async function handleSelectHandover(id: string, showMessage = true) {
    setIsLoading(true)
    try {
      const detail = await apiRequest<ShiftHandoverDetail>(`/api/shifts/handovers/${id}`)
      setSelectedHandover(detail)
      setScreen('detail')
      if (showMessage) {
        setMessage(`${detail.handoverNo} vardiya detay ekranı açıldı.`)
      }
    } catch (error) {
      setMessage(error instanceof Error ? error.message : 'Vardiya detayı alınamadı.')
    } finally {
      setIsLoading(false)
    }
  }

  async function handleCreateHandover() {
    if (!form.shiftType || !form.shiftDate || !form.handoverFromUserId || !form.handoverToUserId) {
      setMessage('Vardiya türü, tarih, teslim eden ve teslim alan kullanıcı zorunludur.')
      return
    }

    if (form.handoverFromUserId === form.handoverToUserId) {
      setMessage('Teslim eden ve teslim alan kullanıcı aynı olamaz.')
      return
    }

    if (!form.summary.trim() && !form.criticalNotes.trim() && draftItems.length === 0) {
      setMessage('Devir teslim için özet, kritik not veya en az bir iş maddesi girilmelidir.')
      return
    }

    setIsLoading(true)
    try {
      const detail = await apiRequest<ShiftHandoverDetail>('/api/shifts/handovers', {
        method: 'POST',
        body: JSON.stringify({
          ...form,
          summary: form.summary.trim() || null,
          criticalNotes: form.criticalNotes.trim() || null,
          items: draftItems.map((item) => ({
            itemType: item.itemType,
            title: item.title.trim(),
            description: item.description.trim() || null,
            faultId: item.faultId || null,
            equipmentId: item.equipmentId || null,
            maintenancePlanId: item.maintenancePlanId || null,
            priority: item.priority,
          })),
        }),
      })
      await Promise.all([loadHandovers(filters), loadOpenItems()])
      setSelectedHandover(detail)
      setScreen('detail')
      setMessage(`${detail.handoverNo} vardiya devir teslim kaydı oluşturuldu.`)
    } catch (error) {
      setMessage(error instanceof Error ? error.message : 'Vardiya devir teslim kaydı oluşturulamadı.')
    } finally {
      setIsLoading(false)
    }
  }

  async function handleToggleItem(item: ShiftItem, nextValue: boolean) {
    setIsLoading(true)
    try {
      await apiRequest<ShiftItem>(`/api/shifts/items/${item.id}/complete`, {
        method: 'PATCH',
        body: JSON.stringify({ isCompleted: nextValue }),
      })
      if (selectedHandover) {
        await handleSelectHandover(selectedHandover.id, false)
      }
      await loadOpenItems()
      setMessage(`${item.title} maddesi ${nextValue ? 'tamamlandı' : 'açık'} olarak güncellendi.`)
    } catch (error) {
      setMessage(error instanceof Error ? error.message : 'Devir maddesi güncellenemedi.')
    } finally {
      setIsLoading(false)
    }
  }

  function addFaultItem(fault: ShiftOpenFault) {
    if (draftItems.some((item) => item.faultId === fault.id)) {
      setMessage(`${fault.faultNo} zaten forma eklendi.`)
      return
    }

    setDraftItems((current) => [...current, {
      localId: crypto.randomUUID(),
      itemType: 'OpenFault',
      title: `${fault.faultNo} - ${fault.equipmentName}`,
      description: fault.description,
      faultId: fault.id,
      equipmentId: fault.equipmentId,
      maintenancePlanId: null,
      priority: fault.priority,
    }])
  }

  function addMaintenanceItem(plan: ShiftPendingMaintenance) {
    if (draftItems.some((item) => item.maintenancePlanId === plan.id)) {
      setMessage(`${plan.planNo} zaten forma eklendi.`)
      return
    }

    setDraftItems((current) => [...current, {
      localId: crypto.randomUUID(),
      itemType: 'PendingMaintenance',
      title: `${plan.planNo} - ${plan.maintenanceType}`,
      description: plan.description ?? `${plan.equipmentName} için ${formatDate(plan.plannedDate)} tarihli bakım planı takip edilecek.`,
      faultId: null,
      equipmentId: plan.equipmentId,
      maintenancePlanId: plan.id,
      priority: plan.priority,
    }])
  }

  function addEquipmentItem(equipmentId: string) {
    const equipment = openItems.equipmentToWatch.find((item) => item.id === equipmentId)
    if (!equipment) {
      return
    }

    if (draftItems.some((item) => item.itemType === 'EquipmentToWatch' && item.equipmentId === equipment.id)) {
      setMessage(`${equipment.code} zaten takip listesine eklendi.`)
      return
    }

    setDraftItems((current) => [...current, {
      localId: crypto.randomUUID(),
      itemType: 'EquipmentToWatch',
      title: `${equipment.code} - ${equipment.name}`,
      description: `${equipment.locationName} lokasyonundaki ${equipment.technicalSystemName} ekipmanı vardiya boyunca izlenecek.`,
      faultId: null,
      equipmentId: equipment.id,
      maintenancePlanId: null,
      priority: equipment.status === 'Faulted' ? 'High' : equipment.status === 'Maintenance' ? 'Medium' : 'Low',
    }])
  }

  function addManualItem() {
    if (!manualItem.title.trim()) {
      setMessage('Manuel madde başlığı zorunludur.')
      return
    }

    setDraftItems((current) => [...current, { ...manualItem, localId: crypto.randomUUID(), title: manualItem.title.trim(), description: manualItem.description.trim() }])
    setManualItem(createManualItem(manualItem.itemType))
  }

  function removeDraftItem(localId: string) {
    setDraftItems((current) => current.filter((item) => item.localId !== localId))
  }

  async function openOpenItemsScreen() {
    setScreen('openItems')
    setIsLoading(true)
    try {
      const data = await loadOpenItems()
      setMessage(`${data.openShiftItems.length} tamamlanmamış devir maddesi listeleniyor.`)
    } catch (error) {
      setMessage(error instanceof Error ? error.message : 'Devreden işler alınamadı.')
    } finally {
      setIsLoading(false)
    }
  }

  return (
    <section className="module-font mx-auto w-full max-w-[1600px] px-5 py-6 lg:px-6">
      <div className="mb-6 flex flex-col gap-4 md:flex-row md:items-end md:justify-between">
        <div>
          <h2 className="text-3xl font-bold tracking-tight text-black">{screenTitle(screen)}</h2>
          <p className="mt-2 text-[15px] leading-5 text-[#45464D]">Açık işleri, kritik notları ve takip edilecek ekipmanları sonraki vardiyaya düzenli aktar.</p>
        </div>
        <div className="flex flex-wrap gap-2">
          <ExecutiveReportDownload apiBaseUrl={apiBaseUrl} disabled={isLoading} fileBaseName="vardiya-yonetici-raporu" label="Vardiya Raporu" path="/api/exports/shifts" token={token} onMessage={setMessage} />
          <ShiftScreenButton active={screen === 'list'} label="Devir Teslim Listesi" onClick={() => setScreen('list')} />
          <ShiftScreenButton active={screen === 'new'} label="Yeni Devir Teslim" onClick={() => void startCreateHandover()} />
          <ShiftScreenButton active={screen === 'detail'} disabled={!selectedHandover} label="Vardiya Detay" onClick={() => setScreen('detail')} />
          <ShiftScreenButton active={screen === 'openItems'} label="Devreden İşler" onClick={() => void openOpenItemsScreen()} />
        </div>
      </div>

      <div key={screen} className="screen-transition">
        {screen === 'list' ? renderListScreen() : null}
        {screen === 'new' ? renderNewScreen() : null}
        {screen === 'detail' ? renderDetailScreen() : null}
        {screen === 'openItems' ? renderOpenItemsScreen() : null}
      </div>

      <div className="mt-4"><StatusMessage busy={isLoading} message={message} /></div>
    </section>
  )

  function renderListScreen() {
    const openCount = handovers.reduce((total, handover) => total + handover.openItemCount, 0)
    const criticalCount = handovers.reduce((total, handover) => total + handover.criticalItemCount, 0)

    return (
      <>
        <div className="mb-6 grid gap-4 md:grid-cols-4">
          <ShiftMetricCard icon="sync_alt" label="Toplam Devir" value={String(handovers.length)} />
          <ShiftMetricCard icon="pending_actions" label="Açık İş" tone="danger" value={String(openCount)} />
          <ShiftMetricCard icon="priority_high" label="Kritik Madde" tone="danger" value={String(criticalCount)} />
          <ShiftMetricCard icon="schedule" label="Son Devir" value={handovers[0] ? formatDateTime(handovers[0].createdAt) : '-'} />
        </div>

        <div className="mb-6 flex justify-end">
          <button className="flex items-center gap-2 bg-black px-5 py-3 text-sm font-bold text-white shadow-sm disabled:bg-[#76777D]" disabled={isLoading} type="button" onClick={() => void startCreateHandover()}>
            <span className="material-symbols-outlined text-[18px]">add</span>
            Yeni Devir Teslim
          </button>
        </div>

        <div className="mb-6 border border-[#C6C6CD] bg-white p-4 shadow-[0px_1px_3px_rgba(15,23,42,0.08)]">
          <div className="grid gap-4 md:grid-cols-5">
            <ShiftFieldLabel label="Arama">
              <input className="asset-input" placeholder="Devir no, kullanıcı veya not ara..." value={filters.search} onChange={(event) => setFilters((current) => ({ ...current, search: event.target.value }))} />
            </ShiftFieldLabel>
            <ShiftFieldLabel label="Vardiya">
              <select className="asset-input" value={filters.shiftType} onChange={(event) => setFilters((current) => ({ ...current, shiftType: event.target.value }))}>
                <option value="">Tüm Vardiyalar</option>
                {shiftTypes.map((shiftType) => <option key={shiftType} value={shiftType}>{shiftLabels[shiftType]}</option>)}
              </select>
            </ShiftFieldLabel>
            <ShiftFieldLabel label="Tarih">
              <input className="asset-input" type="date" value={filters.shiftDate} onChange={(event) => setFilters((current) => ({ ...current, shiftDate: event.target.value }))} />
            </ShiftFieldLabel>
            <ShiftFieldLabel label="Kullanıcı">
              <select className="asset-input" value={filters.userId} onChange={(event) => setFilters((current) => ({ ...current, userId: event.target.value }))}>
                <option value="">Tüm Kullanıcılar</option>
                {users.map((user) => <option key={user.id} value={user.id}>{user.fullName}</option>)}
              </select>
            </ShiftFieldLabel>
            <ShiftFieldLabel label="Açık İş">
              <select className="asset-input" value={filters.hasOpenItems} onChange={(event) => setFilters((current) => ({ ...current, hasOpenItems: event.target.value }))}>
                <option value="">Tümü</option>
                <option value="true">Açık işi olanlar</option>
                <option value="false">Tamamlananlar</option>
              </select>
            </ShiftFieldLabel>
          </div>
          <div className="mt-3 flex flex-wrap justify-end gap-2">
            <button className="h-10 border border-[#76777D] bg-white px-4 text-[13px] font-semibold text-[#45464D]" disabled={isLoading} type="button" onClick={() => void handleResetFilters()}>Temizle</button>
            <button className="h-10 border border-[#3755C3] bg-[#3755C3] px-5 text-sm font-semibold text-white disabled:bg-[#76777D]" disabled={isLoading} type="button" onClick={() => void handleApplyFilters()}>Filtrele</button>
          </div>
        </div>

        <section className="overflow-hidden border border-[#C6C6CD] bg-white shadow-[0px_1px_3px_rgba(15,23,42,0.08)]">
          <div className="overflow-x-auto">
            <table className="w-full border-collapse text-left">
              <thead>
                <tr className="border-b border-[#C6C6CD] bg-[#FCF8FA]">
                  <ShiftTableHeader>Devir No</ShiftTableHeader>
                  <ShiftTableHeader>Vardiya</ShiftTableHeader>
                  <ShiftTableHeader>Tarih</ShiftTableHeader>
                  <ShiftTableHeader>Teslim Eden</ShiftTableHeader>
                  <ShiftTableHeader>Teslim Alan</ShiftTableHeader>
                  <ShiftTableHeader>Açık İş</ShiftTableHeader>
                  <ShiftTableHeader>Kritik</ShiftTableHeader>
                  <ShiftTableHeader>Oluşturulma</ShiftTableHeader>
                  <ShiftTableHeader alignRight>İşlem</ShiftTableHeader>
                </tr>
              </thead>
              <tbody className="text-[13px] text-[#1B1B1D]">
                {handovers.map((handover, index) => (
                  <tr key={handover.id} className={`border-b border-[#C6C6CD] transition-colors hover:bg-[#FCF8FA] ${index % 2 === 1 ? 'bg-[#FCF8FA]/50' : 'bg-white'}`}>
                    <td className="p-4"><button className="font-mono font-bold text-black hover:text-[#3755C3]" type="button" onClick={() => void handleSelectHandover(handover.id)}>{handover.handoverNo}</button></td>
                    <td className="p-4"><ShiftBadge shiftType={handover.shiftType} /></td>
                    <td className="p-4 font-mono text-xs text-[#45464D]">{formatDate(handover.shiftDate)}</td>
                    <td className="p-4"><UserAvatar name={handover.handoverFromUserName} /></td>
                    <td className="p-4"><UserAvatar name={handover.handoverToUserName} /></td>
                    <td className="p-4"><span className={handover.openItemCount > 0 ? 'font-bold text-[#BA1A1A]' : 'font-semibold text-[#16A34A]'}>{handover.openItemCount}</span> / {handover.itemCount}</td>
                    <td className="p-4"><span className="font-mono text-xs font-bold text-[#45464D]">{handover.criticalItemCount}</span></td>
                    <td className="p-4 font-mono text-xs text-[#45464D]">{formatDateTime(handover.createdAt)}</td>
                    <td className="p-4 text-right"><button className="p-1 text-[#45464D] transition-colors hover:text-black" type="button" onClick={() => void handleSelectHandover(handover.id)}><span className="material-symbols-outlined text-[18px]">more_vert</span></button></td>
                  </tr>
                ))}
              </tbody>
            </table>
          </div>
          {handovers.length === 0 ? <div className="p-8 text-center text-sm text-[#45464D]">{isLoading ? 'Vardiya devir teslim kayıtları yükleniyor...' : 'Filtreye uygun vardiya devir teslim kaydı bulunamadı.'}</div> : null}
          <div className="flex items-center justify-between border-t border-[#C6C6CD] bg-white p-3 text-[13px] text-[#45464D]"><span>Toplam {handovers.length} devir teslim kaydı gösteriliyor</span><span className="text-xs text-[#76777D]">Vardiya operasyon kayıtları</span></div>
        </section>
      </>
    )
  }

  function renderNewScreen() {
    return (
      <section className="grid gap-6 xl:grid-cols-[1fr_420px]">
        <div className="space-y-6">
          <section className="border border-[#C6C6CD] bg-white p-6 shadow-[0px_1px_3px_rgba(15,23,42,0.08)]">
            <h3 className="border-b border-[#C6C6CD] pb-3 text-xl font-bold text-black">Vardiya Bilgileri</h3>
            <div className="mt-5 grid gap-5 md:grid-cols-2">
              <ShiftFieldLabel label="Vardiya Türü">
                <select className="asset-input" value={form.shiftType} onChange={(event) => setForm((current) => ({ ...current, shiftType: event.target.value as ShiftType }))}>
                  {shiftTypes.map((shiftType) => <option key={shiftType} value={shiftType}>{shiftLabels[shiftType]}</option>)}
                </select>
              </ShiftFieldLabel>
              <ShiftFieldLabel label="Vardiya Tarihi">
                <input className="asset-input" type="date" value={form.shiftDate} onChange={(event) => setForm((current) => ({ ...current, shiftDate: event.target.value }))} />
              </ShiftFieldLabel>
              <ShiftFieldLabel label="Teslim Eden">
                <select className="asset-input" value={form.handoverFromUserId} onChange={(event) => setForm((current) => ({ ...current, handoverFromUserId: event.target.value }))}>
                  <option value="">Kullanıcı seçin...</option>
                  {users.map((user) => <option key={user.id} value={user.id}>{user.fullName} - {user.role}</option>)}
                </select>
              </ShiftFieldLabel>
              <ShiftFieldLabel label="Teslim Alan">
                <select className="asset-input" value={form.handoverToUserId} onChange={(event) => setForm((current) => ({ ...current, handoverToUserId: event.target.value }))}>
                  <option value="">Kullanıcı seçin...</option>
                  {users.map((user) => <option key={user.id} value={user.id}>{user.fullName} - {user.role}</option>)}
                </select>
              </ShiftFieldLabel>
            </div>
            <div className="mt-5 grid gap-5">
              <ShiftFieldLabel label="Vardiya Özeti">
                <textarea className="min-h-28 w-full border border-[#C6C6CD] bg-white p-3 text-sm outline-none focus:border-2 focus:border-[#3755C3]" placeholder="Vardiya boyunca yapılan işlemler, açık kalan işler ve genel operasyon durumunu yazın..." value={form.summary} onChange={(event) => setForm((current) => ({ ...current, summary: event.target.value }))} />
              </ShiftFieldLabel>
              <ShiftFieldLabel label="Kritik Notlar">
                <textarea className="min-h-24 w-full border border-[#C6C6CD] bg-white p-3 text-sm outline-none focus:border-2 focus:border-[#3755C3]" placeholder="Sonraki vardiyanın mutlaka bilmesi gereken kritik notları yazın..." value={form.criticalNotes} onChange={(event) => setForm((current) => ({ ...current, criticalNotes: event.target.value }))} />
              </ShiftFieldLabel>
            </div>
          </section>

          <section className="border border-[#C6C6CD] bg-white p-6 shadow-[0px_1px_3px_rgba(15,23,42,0.08)]">
            <h3 className="border-b border-[#C6C6CD] pb-3 text-xl font-bold text-black">Devredilecek Maddeler</h3>
            <div className="mt-5 grid gap-5 lg:grid-cols-2">
              <ShiftPickerPanel title="Açık Arızalar" emptyText="Açık arıza yok.">
                {openItems.openFaults.map((fault) => (
                  <button key={fault.id} className="block w-full border border-[#C6C6CD] bg-[#FCF8FA] p-3 text-left text-sm hover:border-[#3755C3]" type="button" onClick={() => addFaultItem(fault)}>
                    <span className="font-mono font-bold text-black">{fault.faultNo}</span>
                    <span className="ml-2 text-[#45464D]">{fault.equipmentName}</span>
                    <span className="mt-2 block"><PriorityBadge priority={fault.priority} /></span>
                  </button>
                ))}
              </ShiftPickerPanel>
              <ShiftPickerPanel title="Bekleyen Bakımlar" emptyText="Bekleyen bakım yok.">
                {openItems.pendingMaintenancePlans.map((plan) => (
                  <button key={plan.id} className="block w-full border border-[#C6C6CD] bg-[#FCF8FA] p-3 text-left text-sm hover:border-[#3755C3]" type="button" onClick={() => addMaintenanceItem(plan)}>
                    <span className="font-mono font-bold text-black">{plan.planNo}</span>
                    <span className="ml-2 text-[#45464D]">{plan.equipmentName}</span>
                    <span className="mt-2 block text-xs text-[#45464D]">{plan.maintenanceType} - {formatDate(plan.plannedDate)}</span>
                  </button>
                ))}
              </ShiftPickerPanel>
            </div>

            <div className="mt-5 grid gap-5 md:grid-cols-[1fr_auto]">
              <ShiftFieldLabel label="Takip Edilecek Ekipman">
                <select className="asset-input" defaultValue="" onChange={(event) => { addEquipmentItem(event.target.value); event.target.value = '' }}>
                  <option value="">Ekipman seçin...</option>
                  {openItems.equipmentToWatch.map((equipment) => <option key={equipment.id} value={equipment.id}>{equipment.code} - {equipment.name} - {equipment.locationName}</option>)}
                </select>
              </ShiftFieldLabel>
              <div className="flex items-end text-xs text-[#45464D]">Seçilen ekipman takip maddesi olarak eklenir.</div>
            </div>

            <div className="mt-5 border border-[#C6C6CD] bg-[#FCF8FA] p-4">
              <p className="text-[11px] font-bold uppercase tracking-wide text-[#45464D]">Manuel Madde Ekle</p>
              <div className="mt-3 grid gap-3 md:grid-cols-[180px_1fr_160px_auto]">
                <select className="asset-input" value={manualItem.itemType} onChange={(event) => setManualItem(createManualItem(event.target.value as ShiftItemType))}>
                  <option value="OngoingWork">Devam Eden İş</option>
                  <option value="CriticalNote">Kritik Not</option>
                </select>
                <input className="asset-input" placeholder="Madde başlığı" value={manualItem.title} onChange={(event) => setManualItem((current) => ({ ...current, title: event.target.value }))} />
                <select className="asset-input" value={manualItem.priority} onChange={(event) => setManualItem((current) => ({ ...current, priority: event.target.value as FaultPriority }))}>
                  {priorities.map((priority) => <option key={priority} value={priority}>{priorityLabels[priority]}</option>)}
                </select>
                <button className="h-10 bg-black px-4 text-sm font-bold text-white" type="button" onClick={addManualItem}>Ekle</button>
              </div>
              <textarea className="mt-3 min-h-20 w-full border border-[#C6C6CD] bg-white p-3 text-sm outline-none focus:border-2 focus:border-[#3755C3]" placeholder="Manuel madde açıklaması" value={manualItem.description} onChange={(event) => setManualItem((current) => ({ ...current, description: event.target.value }))} />
            </div>
          </section>
        </div>

        <aside className="space-y-5">
          <section className="border border-[#C6C6CD] bg-white p-5 shadow-[0px_1px_3px_rgba(15,23,42,0.08)]">
            <h3 className="border-b border-[#C6C6CD] pb-3 text-xl font-bold text-black">Form Özeti</h3>
            <div className="mt-4 grid gap-3">
              <ShiftSpecCell label="Vardiya" value={shiftLabels[form.shiftType]} />
              <ShiftSpecCell label="Tarih" value={formatDate(form.shiftDate)} />
              <ShiftSpecCell label="Madde Sayısı" value={String(draftItems.length)} />
            </div>
            <div className="mt-4 space-y-3">
              {draftItems.map((item) => (
                <div key={item.localId} className="border border-[#C6C6CD] bg-[#FCF8FA] p-3 text-sm">
                  <div className="flex items-start justify-between gap-3">
                    <div><ItemBadge itemType={item.itemType} /><p className="mt-2 font-semibold text-black">{item.title}</p><p className="mt-1 text-xs text-[#45464D]">{item.description || '-'}</p></div>
                    <button className="text-[#BA1A1A]" type="button" onClick={() => removeDraftItem(item.localId)}><span className="material-symbols-outlined text-[18px]">close</span></button>
                  </div>
                </div>
              ))}
              {draftItems.length === 0 ? <p className="text-sm text-[#45464D]">Henüz devredilecek madde eklenmedi.</p> : null}
            </div>
            <button className="mt-5 flex w-full items-center justify-center gap-2 bg-black px-4 py-2 text-sm font-semibold text-white disabled:bg-[#76777D]" disabled={isLoading} type="button" onClick={() => void handleCreateHandover()}><span className="material-symbols-outlined text-[18px]">save</span>Devir Kaydı Oluştur</button>
          </section>
        </aside>
      </section>
    )
  }

  function renderDetailScreen() {
    if (!selectedHandover) {
      return <ShiftEmptyPanel title="Vardiya Detay" text="Listeden bir vardiya devir teslim kaydı seçildiğinde detay ekranı burada açılır." />
    }

    return (
      <>
        <div className="mb-6 flex flex-col gap-4 md:flex-row md:items-start md:justify-between">
          <div>
            <p className="text-sm text-[#45464D]">Operasyonlar <span className="mx-2">›</span> Vardiya Devir Teslim <span className="mx-2">›</span> <strong className="text-black">{selectedHandover.handoverNo}</strong></p>
            <h3 className="mt-2 text-3xl font-bold tracking-tight text-black">{shiftLabels[selectedHandover.shiftType]} Vardiyası Devir Teslim</h3>
          </div>
          <div className="flex flex-wrap gap-2">
            <button className="border border-[#C6C6CD] bg-white px-5 py-2 font-semibold text-[#45464D]" type="button" onClick={() => setScreen('list')}>Listeye Dön</button>
            <button className="bg-black px-5 py-2 font-semibold text-white" type="button" onClick={() => void startCreateHandover()}>Yeni Devir</button>
          </div>
        </div>

        <div className="grid gap-6 xl:grid-cols-[1fr_420px]">
          <div className="space-y-6">
            <section className="border border-[#C6C6CD] bg-white p-5 shadow-[0px_1px_3px_rgba(15,23,42,0.08)]">
              <h4 className="mb-4 flex items-center gap-2 border-b border-[#C6C6CD] pb-3 text-xl font-bold text-black"><span className="material-symbols-outlined text-[#45464D]">badge</span>Vardiya Bilgileri</h4>
              <div className="grid gap-4 md:grid-cols-4">
                <ShiftSpecCell mono label="Devir No" value={selectedHandover.handoverNo} />
                <ShiftSpecCell label="Vardiya" value={shiftLabels[selectedHandover.shiftType]} />
                <ShiftSpecCell label="Tarih" value={formatDate(selectedHandover.shiftDate)} />
                <ShiftSpecCell label="Açık İş" value={`${selectedHandover.openItemCount} / ${selectedHandover.itemCount}`} />
              </div>
            </section>

            <section className="border border-[#C6C6CD] bg-white p-5 shadow-[0px_1px_3px_rgba(15,23,42,0.08)]">
              <h4 className="mb-4 flex items-center gap-2 border-b border-[#C6C6CD] pb-3 text-xl font-bold text-black"><span className="material-symbols-outlined text-[#45464D]">assignment</span>Devredilen İşler</h4>
              <div className="space-y-3">
                {selectedHandover.items.map((item) => <ShiftItemCard key={item.id} item={item} onToggle={(nextValue) => void handleToggleItem(item, nextValue)} />)}
                {selectedHandover.items.length === 0 ? <p className="text-sm text-[#45464D]">Bu devir teslim kaydında iş maddesi bulunmuyor.</p> : null}
              </div>
            </section>
          </div>

          <aside className="space-y-5">
            <section className="border border-[#C6C6CD] bg-white p-5 shadow-[0px_1px_3px_rgba(15,23,42,0.08)]">
              <h4 className="mb-4 flex items-center gap-2 border-b border-[#C6C6CD] pb-3 text-xl font-bold text-black"><span className="material-symbols-outlined text-[#45464D]">groups</span>Teslim Bilgisi</h4>
              <div className="space-y-4">
                <UserTransferBlock label="Teslim Eden" name={selectedHandover.handoverFromUserName} title={selectedHandover.handoverFromUserTitle} />
                <UserTransferBlock label="Teslim Alan" name={selectedHandover.handoverToUserName} title={selectedHandover.handoverToUserTitle} />
              </div>
            </section>
            <section className="border border-[#C6C6CD] bg-white p-5 shadow-[0px_1px_3px_rgba(15,23,42,0.08)]">
              <h4 className="mb-4 flex items-center gap-2 border-b border-[#C6C6CD] pb-3 text-xl font-bold text-black"><span className="material-symbols-outlined text-[#45464D]">notes</span>Özet ve Kritik Not</h4>
              <ShiftNotePanel title="Vardiya Özeti" text={selectedHandover.summary || 'Özet girilmedi.'} />
              <div className="mt-4"><ShiftNotePanel title="Kritik Notlar" text={selectedHandover.criticalNotes || 'Kritik not girilmedi.'} tone={selectedHandover.criticalNotes ? 'danger' : 'normal'} /></div>
            </section>
          </aside>
        </div>
      </>
    )
  }

  function renderOpenItemsScreen() {
    return (
      <section className="space-y-6">
        <div className="grid gap-4 md:grid-cols-4">
          <ShiftMetricCard icon="pending_actions" label="Açık Devir Maddesi" tone="danger" value={String(openItems.openShiftItems.length)} />
          <ShiftMetricCard icon="report" label="Açık Arıza" tone="danger" value={String(openItems.openFaults.length)} />
          <ShiftMetricCard icon="build" label="Bekleyen Bakım" value={String(openItems.pendingMaintenancePlans.length)} />
          <ShiftMetricCard icon="inventory_2" label="Takip Ekipmanı" value={String(openItems.equipmentToWatch.length)} />
        </div>

        <section className="overflow-hidden border border-[#C6C6CD] bg-white shadow-[0px_1px_3px_rgba(15,23,42,0.08)]">
          <div className="flex flex-col gap-2 border-b border-[#C6C6CD] p-5 md:flex-row md:items-center md:justify-between">
            <div><p className="text-[11px] font-bold uppercase tracking-wide text-[#45464D]">Devreden İşler</p><h3 className="mt-1 text-xl font-bold text-black">Tamamlanmamış vardiya maddeleri</h3></div>
            <button className="border border-[#C6C6CD] bg-white px-4 py-2 text-sm font-semibold text-[#45464D]" disabled={isLoading} type="button" onClick={() => void openOpenItemsScreen()}>Yenile</button>
          </div>
          <div className="overflow-x-auto">
            <table className="w-full border-collapse text-left">
              <thead><tr className="border-b border-[#C6C6CD] bg-[#FCF8FA]"><ShiftTableHeader>Tür</ShiftTableHeader><ShiftTableHeader>Başlık</ShiftTableHeader><ShiftTableHeader>Bağlı Kayıt</ShiftTableHeader><ShiftTableHeader>Öncelik</ShiftTableHeader><ShiftTableHeader>Devir No</ShiftTableHeader><ShiftTableHeader>Oluşturulma</ShiftTableHeader><ShiftTableHeader alignRight>Durum</ShiftTableHeader></tr></thead>
              <tbody className="text-[13px]">
                {openItems.openShiftItems.map((item, index) => (
                  <tr key={item.id} className={`border-b border-[#C6C6CD] hover:bg-[#FCF8FA] ${index % 2 === 1 ? 'bg-[#FCF8FA]/50' : 'bg-white'}`}>
                    <td className="p-4"><ItemBadge itemType={item.itemType} /></td>
                    <td className="max-w-[360px] p-4"><p className="font-semibold text-black">{item.title}</p><p className="mt-1 text-xs text-[#45464D]">{item.description || '-'}</p></td>
                    <td className="p-4 font-mono text-xs text-[#45464D]">{item.faultNo ?? item.maintenancePlanNo ?? item.equipmentCode ?? '-'}</td>
                    <td className="p-4">{item.priority ? <PriorityBadge priority={item.priority} /> : '-'}</td>
                    <td className="p-4 font-mono text-xs font-bold text-black">{item.handoverNo}</td>
                    <td className="p-4 font-mono text-xs text-[#45464D]">{formatDateTime(item.createdAt)}</td>
                    <td className="p-4 text-right"><button className="text-sm font-semibold text-[#3755C3]" type="button" onClick={() => void handleToggleItem(item, true)}>Tamamla</button></td>
                  </tr>
                ))}
              </tbody>
            </table>
          </div>
          {openItems.openShiftItems.length === 0 ? <div className="p-8 text-center text-sm text-[#45464D]">Tamamlanmamış devir maddesi bulunamadı.</div> : null}
        </section>
      </section>
    )
  }
}

function createEmptyOpenItems(): ShiftOpenItems {
  return { openFaults: [], pendingMaintenancePlans: [], equipmentToWatch: [], openShiftItems: [] }
}

function createEmptyForm(): ShiftFormState {
  return {
    shiftType: 'Morning',
    shiftDate: new Date().toISOString().slice(0, 10),
    handoverFromUserId: '',
    handoverToUserId: '',
    summary: '',
    criticalNotes: '',
  }
}

function createEmptyFormWithUsers(users: UserListItem[]): ShiftFormState {
  return {
    ...createEmptyForm(),
    handoverFromUserId: users[0]?.id || '',
    handoverToUserId: users[1]?.id || users[0]?.id || '',
  }
}

function createManualItem(itemType: ShiftItemType): DraftShiftItem {
  return {
    localId: crypto.randomUUID(),
    itemType,
    title: '',
    description: '',
    faultId: null,
    equipmentId: null,
    maintenancePlanId: null,
    priority: itemType === 'CriticalNote' ? 'High' : 'Medium',
  }
}

function screenTitle(screen: ShiftScreen) {
  const titles: Record<ShiftScreen, string> = {
    list: 'Vardiya Devir Teslim',
    new: 'Yeni Vardiya Devir Teslim',
    detail: 'Vardiya Devir Detay',
    openItems: 'Devreden İşler',
  }

  return titles[screen]
}

function ShiftScreenButton({ active, disabled = false, label, onClick }: { active: boolean; disabled?: boolean; label: string; onClick: () => void }) {
  return <button className={`${active ? 'bg-black text-white' : 'border border-[#C6C6CD] bg-white text-[#1B1B1D]'} px-4 py-2 text-sm font-semibold disabled:border-[#E4E2E4] disabled:text-[#76777D]`} disabled={disabled} type="button" onClick={onClick}>{label}</button>
}

function ShiftFieldLabel({ label, children }: { label: string; children: ReactNode }) {
  return <label className="block text-[11px] font-bold uppercase tracking-wide text-[#45464D]">{label}<div className="mt-1">{children}</div></label>
}

function ShiftTableHeader({ children, alignRight = false }: { children: ReactNode; alignRight?: boolean }) {
  return <th className={`p-4 text-[11px] font-bold uppercase tracking-wide text-[#45464D] ${alignRight ? 'text-right' : ''}`}>{children}</th>
}

function ShiftBadge({ shiftType }: { shiftType: ShiftType }) {
  return <span className={`inline-flex px-2 py-1 text-xs font-bold ${shiftBadgeClasses[shiftType]}`}>{shiftLabels[shiftType]}</span>
}

function ItemBadge({ itemType }: { itemType: ShiftItemType }) {
  return <span className={`inline-flex px-2 py-1 text-xs font-bold ${itemBadgeClasses[itemType]}`}>{itemLabels[itemType]}</span>
}

function PriorityBadge({ priority }: { priority: FaultPriority }) {
  return <span className={`inline-flex px-2 py-1 text-xs font-bold ${priorityBadgeClasses[priority]}`}>{priorityLabels[priority]}</span>
}

function ShiftMetricCard({ icon, label, tone = 'normal', value }: { icon: string; label: string; tone?: 'normal' | 'danger'; value: string }) {
  const toneClass = tone === 'danger' ? 'text-[#BA1A1A]' : 'text-[#3755C3]'
  return <section className="border border-[#C6C6CD] bg-white p-4 shadow-[0px_1px_3px_rgba(15,23,42,0.08)]"><div className="flex items-center justify-between"><p className="text-[11px] font-bold uppercase tracking-wide text-[#45464D]">{label}</p><span className={`material-symbols-outlined text-[22px] ${toneClass}`}>{icon}</span></div><p className="mt-3 text-2xl font-bold text-black">{value}</p></section>
}

function ShiftSpecCell({ label, mono = false, value }: { label: string; mono?: boolean; value: string }) {
  return <div><p className="text-[11px] font-bold uppercase tracking-wide text-[#45464D]">{label}</p><p className={`mt-2 inline-flex px-2 py-1 text-sm font-semibold ${mono ? 'font-mono' : ''} bg-[#F0EDEF] text-black`}>{value}</p></div>
}

function ShiftNotePanel({ text, title, tone = 'normal' }: { text: string; title: string; tone?: 'normal' | 'danger' }) {
  return <div className={`border p-4 ${tone === 'danger' ? 'border-[#F4C7C3] bg-[#FFF1F0]' : 'border-[#C6C6CD] bg-[#FCF8FA]'}`}><p className="text-[11px] font-bold uppercase tracking-wide text-[#45464D]">{title}</p><p className="mt-2 text-sm leading-6 text-[#1B1B1D]">{text}</p></div>
}

function ShiftPickerPanel({ children, emptyText, title }: { children: ReactNode; emptyText: string; title: string }) {
  const hasChildren = Array.isArray(children) ? children.length > 0 : Boolean(children)
  return <div className="border border-[#C6C6CD] bg-[#FCF8FA] p-4"><p className="text-[11px] font-bold uppercase tracking-wide text-[#45464D]">{title}</p><div className="mt-3 max-h-72 space-y-2 overflow-y-auto">{hasChildren ? children : <p className="text-sm text-[#45464D]">{emptyText}</p>}</div></div>
}

function ShiftItemCard({ item, onToggle }: { item: ShiftItem; onToggle: (nextValue: boolean) => void }) {
  return (
    <div className={`border p-4 ${item.isCompleted ? 'border-[#C6C6CD] bg-[#F6F3F5]' : 'border-[#C6C6CD] bg-white'}`}>
      <div className="flex flex-col gap-3 md:flex-row md:items-start md:justify-between">
        <div>
          <div className="flex flex-wrap items-center gap-2"><ItemBadge itemType={item.itemType} />{item.priority ? <PriorityBadge priority={item.priority} /> : null}{item.isCompleted ? <span className="bg-[#DCFCE7] px-2 py-1 text-xs font-bold text-[#16A34A]">Tamamlandı</span> : <span className="bg-[#FEE2E2] px-2 py-1 text-xs font-bold text-[#BA1A1A]">Açık</span>}</div>
          <p className="mt-3 font-semibold text-black">{item.title}</p>
          <p className="mt-1 text-sm leading-6 text-[#45464D]">{item.description || '-'}</p>
          <p className="mt-2 font-mono text-xs text-[#76777D]">{item.faultNo ?? item.maintenancePlanNo ?? item.equipmentCode ?? ''}</p>
        </div>
        <button className="border border-[#C6C6CD] bg-white px-3 py-2 text-sm font-semibold text-[#45464D]" type="button" onClick={() => onToggle(!item.isCompleted)}>{item.isCompleted ? 'Açık Yap' : 'Tamamla'}</button>
      </div>
    </div>
  )
}

function UserTransferBlock({ label, name, title }: { label: string; name: string; title?: string | null }) {
  return <div className="border border-[#C6C6CD] bg-[#FCF8FA] p-4"><p className="text-[11px] font-bold uppercase tracking-wide text-[#45464D]">{label}</p><div className="mt-3"><UserAvatar name={name} /><p className="mt-2 text-xs text-[#45464D]">{title || '-'}</p></div></div>
}

function UserAvatar({ name }: { name: string }) {
  return <div className="flex items-center gap-2"><span className="flex h-7 w-7 items-center justify-center rounded-full bg-[#E0E7FF] text-xs font-bold text-[#3755C3]">{getInitials(name)}</span><span>{name}</span></div>
}

function ShiftEmptyPanel({ text, title }: { text: string; title: string }) {
  return <section className="border border-[#C6C6CD] bg-white p-8 text-center text-[#45464D]"><h3 className="text-xl font-bold text-black">{title}</h3><p className="mt-2 text-sm">{text}</p></section>
}

function getInitials(name: string) {
  return name.split(' ').filter(Boolean).slice(0, 2).map((part) => part[0]?.toUpperCase()).join('') || 'VD'
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

export default ShiftsView
