import { useEffect, useState, type ReactNode } from 'react'
import ExecutiveReportDownload from './ExecutiveReportDownload'

type AuthUser = {
  fullName: string
  role: string
}

type FaultsViewProps = {
  apiBaseUrl: string
  selectedFaultId?: string | null
  token: string
  user: AuthUser | null
}

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

type EquipmentStatus = 'Active' | 'Passive' | 'Maintenance' | 'Faulted'

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

type UserListItem = {
  id: string
  fullName: string
  username: string
  role: string
  isActive: boolean
}

type FaultStatus = 'New' | 'Assigned' | 'InReview' | 'InProgress' | 'Waiting' | 'Resolved' | 'Closed'
type FaultPriority = 'Low' | 'Medium' | 'High' | 'Critical'
type FaultSource = 'ScadaObservation' | 'HoneywellEbiObservation' | 'FieldObservation' | 'OperatorReport' | 'MaintenanceFinding'

type FaultListItem = {
  id: string
  faultNo: string
  equipmentId: string
  equipmentCode: string
  equipmentName: string
  locationId: string
  locationName: string
  technicalSystemId: string
  technicalSystemName: string
  source: FaultSource
  priority: FaultPriority
  status: FaultStatus
  createdByUserId: string
  createdByUserName: string
  assignedToUserId?: string | null
  assignedToUserName?: string | null
  createdAt: string
  updatedAt?: string | null
}

type FaultAction = {
  id: string
  actionType: string
  userId: string
  userName: string
  oldStatus?: FaultStatus | null
  newStatus?: FaultStatus | null
  note?: string | null
  createdAt: string
}

type FaultDetail = FaultListItem & {
  description: string
  resolutionDescription?: string | null
  waitingReason?: string | null
  resolvedByUserId?: string | null
  resolvedByUserName?: string | null
  closedByUserId?: string | null
  closedByUserName?: string | null
  assignedAt?: string | null
  resolvedAt?: string | null
  closedAt?: string | null
  actions: FaultAction[]
}

type FaultFilters = {
  search: string
  status: string
  priority: string
  source: string
  locationId: string
  technicalSystemId: string
  equipmentId: string
}

type FaultFormState = {
  equipmentId: string
  source: FaultSource
  priority: FaultPriority
  description: string
}

type AssignFaultFormState = {
  assignedToUserId: string
  note: string
}

type UpdateFaultStatusFormState = {
  status: FaultStatus
  note: string
  waitingReason: string
}

type FaultScreen = 'list' | 'create' | 'detail'

const faultStatuses: FaultStatus[] = ['New', 'Assigned', 'InReview', 'InProgress', 'Waiting', 'Resolved', 'Closed']
const faultStatusUpdateOptions: FaultStatus[] = ['InReview', 'InProgress', 'Waiting']
const faultPriorities: FaultPriority[] = ['Low', 'Medium', 'High', 'Critical']
const faultSources: FaultSource[] = ['ScadaObservation', 'HoneywellEbiObservation', 'FieldObservation', 'OperatorReport', 'MaintenanceFinding']

const faultStatusLabels: Record<FaultStatus, string> = {
  New: 'Yeni',
  Assigned: 'Atandı',
  InReview: 'İnceleniyor',
  InProgress: 'Müdahale Ediliyor',
  Waiting: 'Beklemede',
  Resolved: 'Çözüldü',
  Closed: 'Kapatıldı',
}

const faultStatusBadgeClasses: Record<FaultStatus, string> = {
  New: 'bg-[#DBEAFE] text-[#1D4ED8]',
  Assigned: 'bg-[#E0E7FF] text-[#3730A3]',
  InReview: 'bg-[#F3E8FF] text-[#7E22CE]',
  InProgress: 'bg-[#FFEDD5] text-[#C2410C]',
  Waiting: 'bg-[#FEF08A] text-[#854D0E]',
  Resolved: 'bg-[#DCFCE7] text-[#16A34A]',
  Closed: 'bg-[#E4E2E4] text-[#45464D]',
}

const faultPriorityLabels: Record<FaultPriority, string> = {
  Low: 'Düşük',
  Medium: 'Orta',
  High: 'Yüksek',
  Critical: 'Kritik',
}

const faultPriorityBadgeClasses: Record<FaultPriority, string> = {
  Low: 'bg-[#E4E2E4] text-[#45464D]',
  Medium: 'bg-[#DBEAFE] text-[#1D4ED8]',
  High: 'bg-[#FFEDD5] text-[#C2410C]',
  Critical: 'bg-[#FEE2E2] text-[#BA1A1A] ring-1 ring-[#BA1A1A]',
}

const faultSourceLabels: Record<FaultSource, string> = {
  ScadaObservation: 'SCADA Gözlemi',
  HoneywellEbiObservation: 'Honeywell EBI',
  FieldObservation: 'Saha Gözlemi',
  OperatorReport: 'Operatör Bildirimi',
  MaintenanceFinding: 'Bakım Bulgusu',
}

const defaultFaultFilters: FaultFilters = {
  search: '',
  status: '',
  priority: '',
  source: '',
  locationId: '',
  technicalSystemId: '',
  equipmentId: '',
}

const emptyFaultForm: FaultFormState = {
  equipmentId: '',
  source: 'OperatorReport',
  priority: 'High',
  description: '',
}

const defaultAssignForm: AssignFaultFormState = {
  assignedToUserId: '',
  note: '',
}

const defaultStatusForm: UpdateFaultStatusFormState = {
  status: 'InReview',
  note: '',
  waitingReason: '',
}

function FaultsView({ apiBaseUrl, selectedFaultId, token, user }: FaultsViewProps) {
  const [faultScreen, setFaultScreen] = useState<FaultScreen>('list')
  const [locations, setLocations] = useState<LocationItem[]>([])
  const [technicalSystems, setTechnicalSystems] = useState<TechnicalSystemItem[]>([])
  const [equipment, setEquipment] = useState<EquipmentListItem[]>([])
  const [users, setUsers] = useState<UserListItem[]>([])
  const [faults, setFaults] = useState<FaultListItem[]>([])
  const [selectedFault, setSelectedFault] = useState<FaultDetail | null>(null)
  const [filters, setFilters] = useState<FaultFilters>(defaultFaultFilters)
  const [faultForm, setFaultForm] = useState<FaultFormState>(emptyFaultForm)
  const [assignForm, setAssignForm] = useState<AssignFaultFormState>(defaultAssignForm)
  const [actionNote, setActionNote] = useState('')
  const [statusForm, setStatusForm] = useState<UpdateFaultStatusFormState>(defaultStatusForm)
  const [resolutionDescription, setResolutionDescription] = useState('')
  const [closeNote, setCloseNote] = useState('')
  const [isLoading, setIsLoading] = useState(false)
  const [message, setMessage] = useState('Arıza yönetimi verileri yükleniyor...')

  const activeEquipment = equipment.filter((item) => item.isActive && item.status === 'Active')
  const technicians = users.filter((item) => item.isActive && item.role === 'Teknik Personel')
  const canAssignFaults = user?.role === 'Admin' || user?.role === 'Yönetici'
  const canOperateFaults = canAssignFaults || user?.role === 'Teknik Personel'
  const canCreateFaults = canOperateFaults || user?.role === 'Operatör'
  const canCloseFaults = canAssignFaults

  useEffect(() => {
    if (!token) {
      return
    }

    let ignore = false

    async function loadInitialData() {
      setIsLoading(true)
      setMessage('Arıza yönetimi referans verileri yükleniyor...')

      try {
        async function initialRequest<T>(path: string): Promise<T> {
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

        const [locationData, systemData, equipmentData] = await Promise.all([
          initialRequest<LocationItem[]>('/api/locations'),
          initialRequest<TechnicalSystemItem[]>('/api/technical-systems'),
          initialRequest<EquipmentListItem[]>('/api/equipment?isActive=true'),
        ])

        if (ignore) {
          return
        }

        setLocations(locationData)
        setTechnicalSystems(systemData)
        setEquipment(equipmentData)

        const firstActiveEquipment = equipmentData.find((item) => item.isActive && item.status === 'Active')
        setFaultForm((current) => ({
          ...current,
          equipmentId: current.equipmentId || firstActiveEquipment?.id || '',
        }))

        if (user?.role === 'Admin') {
          const userData = await initialRequest<UserListItem[]>('/api/admin/users')
          if (!ignore) {
            setUsers(userData)
            const firstTechnician = userData.find((item) => item.isActive && item.role === 'Teknik Personel')
            setAssignForm((current) => ({
              ...current,
              assignedToUserId: current.assignedToUserId || firstTechnician?.id || '',
            }))
          }
        } else {
          setUsers([])
        }

        const faultData = await initialRequest<FaultListItem[]>('/api/faults')
        if (ignore) {
          return
        }

        setFaults(faultData)

        if (selectedFaultId) {
          const detail = await initialRequest<FaultDetail>(`/api/faults/${selectedFaultId}`)
          if (!ignore) {
            setSelectedFault(detail)
            setFaultScreen('detail')
            setStatusForm({ ...defaultStatusForm, status: getDefaultNextStatus(detail.status) })
          }
        } else {
          setSelectedFault(null)
        }

        if (!ignore) {
          setMessage(`${faultData.length} arıza kaydı yüklendi.`)
        }
      } catch (error) {
        if (!ignore) {
          setMessage(error instanceof Error ? error.message : 'Arıza yönetimi verileri yüklenemedi.')
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
  }, [apiBaseUrl, selectedFaultId, token, user?.role])

  async function apiRequest<T>(path: string, options: RequestInit = {}): Promise<T> {
    const headers = new Headers(options.headers)
    headers.set('Authorization', `Bearer ${token}`)

    if (options.body && !headers.has('Content-Type')) {
      headers.set('Content-Type', 'application/json')
    }

    const response = await fetch(`${apiBaseUrl}${path}`, { ...options, headers })
    const text = await response.text()
    const payload = text ? JSON.parse(text) : null

    if (!response.ok) {
      throw new Error((payload as { message?: string } | null)?.message ?? `API isteği başarısız: ${response.status}`)
    }

    return payload as T
  }

  async function loadFaults(currentFilters: FaultFilters = filters) {
    const params = new URLSearchParams()
    Object.entries(currentFilters).forEach(([key, value]) => {
      if (value) {
        params.set(key, value)
      }
    })

    const path = params.size ? `/api/faults?${params.toString()}` : '/api/faults'
    const data = await apiRequest<FaultListItem[]>(path)
    setFaults(data)

    if (data.length === 0) {
      setSelectedFault(null)
      return data
    }

    if (selectedFault && !data.some((item) => item.id === selectedFault.id)) {
      setSelectedFault(null)
      setFaultScreen('list')
    }

    return data
  }

  async function handleApplyFilters() {
    setIsLoading(true)
    try {
      const data = await loadFaults(filters)
      setMessage(`${data.length} arıza filtre sonucunda listelendi.`)
    } catch (error) {
      setMessage(error instanceof Error ? error.message : 'Arıza listesi alınamadı.')
    } finally {
      setIsLoading(false)
    }
  }

  async function handleRefresh() {
    setIsLoading(true)
    try {
      const [locationData, systemData, equipmentData] = await Promise.all([
        apiRequest<LocationItem[]>('/api/locations'),
        apiRequest<TechnicalSystemItem[]>('/api/technical-systems'),
        apiRequest<EquipmentListItem[]>('/api/equipment?isActive=true'),
      ])
      setLocations(locationData)
      setTechnicalSystems(systemData)
      setEquipment(equipmentData)

      if (user?.role === 'Admin') {
        const userData = await apiRequest<UserListItem[]>('/api/admin/users')
        setUsers(userData)
      }

      const data = await loadFaults(filters)
      setMessage(`Veriler yenilendi. ${data.length} arıza listelendi.`)
    } catch (error) {
      setMessage(error instanceof Error ? error.message : 'Veriler yenilenemedi.')
    } finally {
      setIsLoading(false)
    }
  }

  async function handleSelectFault(id: string, showMessage = true, openDetail = true) {
    setIsLoading(true)
    try {
      const detail = await apiRequest<FaultDetail>(`/api/faults/${id}`)
      setSelectedFault(detail)
      if (openDetail) {
        setFaultScreen('detail')
      }
      setStatusForm({ ...defaultStatusForm, status: getDefaultNextStatus(detail.status) })
      setAssignForm((current) => ({ ...current, note: '', assignedToUserId: detail.assignedToUserId ?? current.assignedToUserId }))
      setActionNote('')
      setResolutionDescription('')
      setCloseNote('')

      if (showMessage) {
        setMessage(`${detail.faultNo} arıza detayı yüklendi.`)
      }
    } catch (error) {
      setMessage(error instanceof Error ? error.message : 'Arıza detayı alınamadı.')
    } finally {
      setIsLoading(false)
    }
  }

  function startCreateFault() {
    const firstActiveEquipment = activeEquipment[0]
    setFaultForm({ ...emptyFaultForm, equipmentId: firstActiveEquipment?.id || '' })
    setFaultScreen('create')
    setMessage('Yeni arıza formu hazırlandı.')
  }

  async function handleCreateFault() {
    if (!canCreateFaults) {
      setMessage('Bu kullanıcı arıza oluşturamaz.')
      return
    }

    if (!faultForm.equipmentId || !faultForm.description.trim()) {
      setMessage('Ekipman ve arıza açıklaması zorunludur.')
      return
    }

    setIsLoading(true)
    try {
      const detail = await apiRequest<FaultDetail>('/api/faults', {
        method: 'POST',
        body: JSON.stringify({
          equipmentId: faultForm.equipmentId,
          source: faultForm.source,
          priority: faultForm.priority,
          description: faultForm.description.trim(),
        }),
      })

      await loadFaults(filters)
      setSelectedFault(detail)
      setFaultScreen('detail')
      setFaultForm((current) => ({ ...current, description: '' }))
      setMessage(`${detail.faultNo} arıza kaydı oluşturuldu.`)
    } catch (error) {
      setMessage(error instanceof Error ? error.message : 'Arıza oluşturulamadı.')
    } finally {
      setIsLoading(false)
    }
  }

  async function handleAssignFault() {
    if (!selectedFault || !canAssignFaults) {
      return
    }

    if (!assignForm.assignedToUserId) {
      setMessage('Atanacak teknik personel seçilmelidir.')
      return
    }

    setIsLoading(true)
    try {
      const detail = await apiRequest<FaultDetail>(`/api/faults/${selectedFault.id}/assign`, {
        method: 'POST',
        body: JSON.stringify({
          assignedToUserId: assignForm.assignedToUserId,
          note: assignForm.note || null,
        }),
      })

      await loadFaults(filters)
      setSelectedFault(detail)
      setAssignForm((current) => ({ ...current, note: '' }))
      setMessage(`${detail.faultNo} arızası ${detail.assignedToUserName ?? 'teknik personele'} atandı.`)
    } catch (error) {
      setMessage(error instanceof Error ? error.message : 'Atama işlemi yapılamadı.')
    } finally {
      setIsLoading(false)
    }
  }

  async function handleAddFaultNote() {
    if (!selectedFault || !canOperateFaults) {
      return
    }

    if (!actionNote.trim()) {
      setMessage('İşlem notu boş olamaz.')
      return
    }

    setIsLoading(true)
    try {
      const detail = await apiRequest<FaultDetail>(`/api/faults/${selectedFault.id}/actions`, {
        method: 'POST',
        body: JSON.stringify({ note: actionNote.trim() }),
      })

      setSelectedFault(detail)
      setActionNote('')
      setMessage(`${detail.faultNo} işlem notu eklendi.`)
    } catch (error) {
      setMessage(error instanceof Error ? error.message : 'İşlem notu eklenemedi.')
    } finally {
      setIsLoading(false)
    }
  }

  async function handleUpdateFaultStatus() {
    if (!selectedFault || !canOperateFaults) {
      return
    }

    if (statusForm.status === 'Waiting' && !statusForm.waitingReason.trim()) {
      setMessage('Bekleme durumuna geçerken bekleme nedeni zorunludur.')
      return
    }

    setIsLoading(true)
    try {
      const detail = await apiRequest<FaultDetail>(`/api/faults/${selectedFault.id}/status`, {
        method: 'PATCH',
        body: JSON.stringify({
          status: statusForm.status,
          note: statusForm.note || null,
          waitingReason: statusForm.status === 'Waiting' ? statusForm.waitingReason.trim() : null,
        }),
      })

      await loadFaults(filters)
      setSelectedFault(detail)
      setStatusForm({ ...defaultStatusForm, status: getDefaultNextStatus(detail.status) })
      setMessage(`${detail.faultNo} durumu ${faultStatusLabels[detail.status]} olarak güncellendi.`)
    } catch (error) {
      setMessage(error instanceof Error ? error.message : 'Durum güncellenemedi.')
    } finally {
      setIsLoading(false)
    }
  }

  async function handleResolveFault() {
    if (!selectedFault || !canOperateFaults) {
      return
    }

    if (!resolutionDescription.trim()) {
      setMessage('Çözüm açıklaması zorunludur.')
      return
    }

    setIsLoading(true)
    try {
      const detail = await apiRequest<FaultDetail>(`/api/faults/${selectedFault.id}/resolve`, {
        method: 'POST',
        body: JSON.stringify({ resolutionDescription: resolutionDescription.trim() }),
      })

      await loadFaults(filters)
      setSelectedFault(detail)
      setResolutionDescription('')
      setMessage(`${detail.faultNo} arızası çözüldü.`)
    } catch (error) {
      setMessage(error instanceof Error ? error.message : 'Arıza çözüldü durumuna alınamadı.')
    } finally {
      setIsLoading(false)
    }
  }

  async function handleCloseFault() {
    if (!selectedFault || !canCloseFaults) {
      return
    }

    setIsLoading(true)
    try {
      const detail = await apiRequest<FaultDetail>(`/api/faults/${selectedFault.id}/close`, {
        method: 'POST',
        body: JSON.stringify({ note: closeNote || null }),
      })

      await loadFaults(filters)
      setSelectedFault(detail)
      setCloseNote('')
      setMessage(`${detail.faultNo} arızası kapatıldı.`)
    } catch (error) {
      setMessage(error instanceof Error ? error.message : 'Arıza kapatılamadı.')
    } finally {
      setIsLoading(false)
    }
  }

  function renderFaultDetailScreen() {
    if (!selectedFault) {
      return (
        <section className="border border-[#C6C6CD] bg-white p-8 text-center text-[#45464D]">
          <h3 className="text-xl font-bold text-black">Arıza Detay Ekranı</h3>
          <p className="mt-2 text-sm">Listeden bir arıza seçildiğinde detay ve işlem geçmişi burada açılır.</p>
        </section>
      )
    }

    const faultAge = formatFaultAge(selectedFault.createdAt, selectedFault.resolvedAt ?? selectedFault.closedAt)
    const faultAgeTone = selectedFault.status === 'Resolved' || selectedFault.status === 'Closed' ? 'bg-[#DCFCE7] text-[#166534]' : selectedFault.priority === 'Critical' ? 'bg-[#FEE2E2] text-[#BA1A1A]' : 'bg-[#FFEDD5] text-[#C2410C]'

    return (
      <div className="grid gap-6 xl:grid-cols-[1fr_400px]">
        <div className="space-y-6">
          <section className="border border-[#C6C6CD] bg-white p-7 shadow-[0px_1px_3px_rgba(15,23,42,0.08)]">
            <div className="mb-5 flex flex-col gap-4 md:flex-row md:items-start md:justify-between">
              <div>
                <h3 className="text-3xl font-bold tracking-tight text-black">Arıza Detay: {selectedFault.faultNo}</h3>
                <p className="mt-2 font-mono text-sm text-[#45464D]"># {selectedFault.faultNo}</p>
              </div>
              <div className="flex flex-wrap items-center gap-2">
                <FaultPriorityBadge priority={selectedFault.priority} />
                <FaultStatusBadge status={selectedFault.status} />
              </div>
            </div>
            <div className="border-t border-[#C6C6CD] pt-5">
              <h4 className="mb-3 flex items-center gap-2 text-xl font-bold text-black"><span className="material-symbols-outlined text-[#3755C3]">info</span>Arıza Özeti</h4>
              <p className="max-w-4xl text-[15px] leading-7 text-[#45464D]">{selectedFault.description}</p>
              <div className="mt-6 grid gap-4 border-t border-[#C6C6CD] pt-5 md:grid-cols-4">
                <FaultSummaryCell label="Ekipman" value={selectedFault.equipmentName} />
                <FaultSummaryCell label="Lokasyon" value={selectedFault.locationName} />
                <FaultSummaryCell label="Kaynak" value={faultSourceLabels[selectedFault.source]} />
                <FaultSummaryCell label="Oluşma Zamanı" value={formatDateTime(selectedFault.createdAt)} />
              </div>
            </div>
          </section>

          <div className="grid gap-6 md:grid-cols-2">
            <section className="border border-[#C6C6CD] bg-white p-6 shadow-[0px_1px_3px_rgba(15,23,42,0.08)]">
              <h4 className="mb-4 flex items-center gap-2 text-xl font-bold text-black"><span className="material-symbols-outlined text-[#3755C3]">assignment_ind</span>Atama Bilgileri</h4>
              <p className="text-lg font-bold text-black">{selectedFault.assignedToUserName ?? 'Atama yapılmadı'}</p>
              <p className="mt-1 text-sm text-[#45464D]">{selectedFault.assignedAt ? formatDateTime(selectedFault.assignedAt) : 'Teknik personel bekleniyor'}</p>
            </section>
            <section className="flex min-h-40 items-center justify-center border border-[#C6C6CD] bg-white p-6 text-center shadow-[0px_1px_3px_rgba(15,23,42,0.08)]">
              <div>
                <p className="text-[12px] font-bold uppercase tracking-wide text-[#45464D]">Arıza Yaşı</p>
                <p className="mt-3 font-mono text-5xl font-bold text-black">{faultAge.value}</p>
                <p className={`mt-3 inline-flex px-3 py-1 text-sm ${faultAgeTone}`}>{faultAge.label}</p>
              </div>
            </section>
          </div>

          <section className="border border-[#C6C6CD] bg-white p-6 shadow-[0px_1px_3px_rgba(15,23,42,0.08)]">
            <h4 className="mb-4 flex items-center gap-2 text-xl font-bold text-black"><span className="material-symbols-outlined text-[#3755C3]">edit_note</span>Çözüm / Not Girişi</h4>
            <textarea className="min-h-28 w-full border border-[#C6C6CD] bg-white p-3 text-sm outline-none focus:border-2 focus:border-[#3755C3]" placeholder="Yapılan işlemleri, değiştirilen parçaları veya ek notları buraya giriniz..." value={actionNote} onChange={(event) => setActionNote(event.target.value)} />
            <div className="mt-4 flex justify-end gap-3"><button className="px-5 py-2 text-sm font-semibold text-[#45464D]" type="button" onClick={() => setActionNote('')}>İptal</button><button className="bg-black px-6 py-2 text-sm font-semibold text-white disabled:bg-[#76777D]" disabled={!actionNote.trim()} type="button" onClick={handleAddFaultNote}>Kaydet</button></div>
          </section>
        </div>

        <aside className="space-y-4">
          <section className="border border-[#C6C6CD] bg-[#F0EDEF] p-5 shadow-[0px_1px_3px_rgba(15,23,42,0.08)]">
            <FaultPanelTitle eyebrow="Arıza Detay Ekranı" title="Kayıt Özeti" />
            <div className="grid gap-3 text-[13px]">
              <FaultSpecRow label="Kaynak" value={faultSourceLabels[selectedFault.source]} />
              <FaultSpecRow label="Oluşturan" value={selectedFault.createdByUserName} />
              <FaultSpecRow label="Atanan" value={selectedFault.assignedToUserName ?? '-'} />
              <FaultSpecRow label="Oluşturma" value={formatDateTime(selectedFault.createdAt)} mono />
              {selectedFault.resolvedAt ? <FaultSpecRow label="Çözüm" value={formatDateTime(selectedFault.resolvedAt)} mono /> : null}
              {selectedFault.closedAt ? <FaultSpecRow label="Kapanış" value={formatDateTime(selectedFault.closedAt)} mono /> : null}
            </div>
          </section>

          <section className="border border-[#C6C6CD] bg-white shadow-[0px_1px_3px_rgba(15,23,42,0.08)]">
            <div className="border-b border-[#C6C6CD] p-5"><h4 className="flex items-center gap-2 text-xl font-bold text-black"><span className="material-symbols-outlined text-[#3755C3]">timeline</span>İşlem Geçmişi</h4></div>
            <div className="max-h-96 space-y-5 overflow-y-auto p-5">
              {selectedFault.actions.map((action) => (
                <div key={action.id} className="border-l-2 border-[#E4E2E4] pl-5">
                  <p className="text-sm font-bold uppercase tracking-wide text-[#3755C3]">{formatActionType(action.actionType)}</p>
                  <p className="mt-1 text-sm text-[#1B1B1D]">{action.note ?? `${action.userName} tarafından işlem yapıldı.`}</p>
                  <p className="mt-1 font-mono text-xs text-[#76777D]">{formatDateTime(action.createdAt)}</p>
                </div>
              ))}
            </div>
          </section>

          {canAssignFaults && selectedFault.status !== 'Closed' && selectedFault.status !== 'Resolved' ? (
            <section className="border border-[#C6C6CD] bg-white p-5 shadow-[0px_1px_3px_rgba(15,23,42,0.08)]">
              <FaultPanelTitle eyebrow="Yetkili İşlem" title="Personel Ata" />
              {technicians.length > 0 ? (
                <div className="grid gap-3">
                  <FaultFieldLabel label="Teknik Personel">
                    <select className="asset-input" value={assignForm.assignedToUserId} onChange={(event) => setAssignForm((current) => ({ ...current, assignedToUserId: event.target.value }))}>
                      <option value="">Personel seçin</option>
                      {technicians.map((technician) => <option key={technician.id} value={technician.id}>{technician.fullName}</option>)}
                    </select>
                  </FaultFieldLabel>
                  <FaultFieldLabel label="Atama Notu">
                    <input className="asset-input" value={assignForm.note} onChange={(event) => setAssignForm((current) => ({ ...current, note: event.target.value }))} />
                  </FaultFieldLabel>
                  <FaultActionButton disabled={isLoading || !assignForm.assignedToUserId} icon="assignment_ind" label="Personele Ata" onClick={handleAssignFault} />
                </div>
              ) : (
                <p className="text-[13px] leading-5 text-[#45464D]">Teknik personel listesi yalnızca Admin demo kullanıcısı ile yüklenir.</p>
              )}
            </section>
          ) : null}

          {canOperateFaults && selectedFault.status !== 'Closed' && selectedFault.status !== 'Resolved' ? (
            <section className="border border-[#C6C6CD] bg-white p-5 shadow-[0px_1px_3px_rgba(15,23,42,0.08)]">
              <FaultPanelTitle eyebrow="Teknik İşlem" title="Durum Güncelle" />
              <div className="grid gap-3">
                <FaultFieldLabel label="Yeni Durum">
                  <select className="asset-input" value={statusForm.status} onChange={(event) => setStatusForm((current) => ({ ...current, status: event.target.value as FaultStatus }))}>
                    {faultStatusUpdateOptions.map((status) => <option key={status} value={status}>{faultStatusLabels[status]}</option>)}
                  </select>
                </FaultFieldLabel>
                {statusForm.status === 'Waiting' ? (
                  <FaultFieldLabel label="Bekleme Nedeni">
                    <input className="asset-input" value={statusForm.waitingReason} onChange={(event) => setStatusForm((current) => ({ ...current, waitingReason: event.target.value }))} />
                  </FaultFieldLabel>
                ) : null}
                <FaultFieldLabel label="Durum Notu">
                  <input className="asset-input" value={statusForm.note} onChange={(event) => setStatusForm((current) => ({ ...current, note: event.target.value }))} />
                </FaultFieldLabel>
                <FaultActionButton disabled={isLoading} icon="sync_alt" label="Durumu Güncelle" onClick={handleUpdateFaultStatus} />
              </div>
            </section>
          ) : null}

          {canOperateFaults && selectedFault.status !== 'Closed' && selectedFault.status !== 'Resolved' ? (
            <section className="border border-[#C6C6CD] bg-white p-5 shadow-[0px_1px_3px_rgba(15,23,42,0.08)]">
              <FaultPanelTitle eyebrow="Çözüm" title="Arızayı Çöz" />
              <FaultFieldLabel label="Çözüm Açıklaması">
                <textarea className="min-h-20 w-full border border-[#C6C6CD] bg-white p-2 text-sm outline-none focus:border-2 focus:border-[#3755C3]" value={resolutionDescription} onChange={(event) => setResolutionDescription(event.target.value)} />
              </FaultFieldLabel>
              <FaultActionButton disabled={isLoading || !resolutionDescription.trim()} icon="task_alt" label="Çözüldü Yap" onClick={handleResolveFault} />
            </section>
          ) : null}

          {canCloseFaults && selectedFault.status === 'Resolved' ? (
            <section className="border border-[#C6C6CD] bg-white p-5 shadow-[0px_1px_3px_rgba(15,23,42,0.08)]">
              <FaultPanelTitle eyebrow="Kapanış" title="Arızayı Kapat" />
              <FaultFieldLabel label="Kapanış Notu">
                <input className="asset-input" value={closeNote} onChange={(event) => setCloseNote(event.target.value)} />
              </FaultFieldLabel>
              <button className="mt-3 flex w-full items-center justify-center gap-2 bg-black px-4 py-2 text-sm font-semibold text-white disabled:bg-[#76777D]" disabled={isLoading} type="button" onClick={handleCloseFault}>
                <span className="material-symbols-outlined text-[18px]">lock</span>
                Arızayı Kapat
              </button>
            </section>
          ) : null}

          <div className="border border-[#C6C6CD] bg-[#F6F3F5] p-3 text-[13px] text-[#45464D]">{message}</div>
        </aside>
      </div>
    )
  }

  return (
    <section className="module-font mx-auto w-full max-w-[1600px] px-5 py-6 lg:px-6" id="faults">
      <div className="mb-6 flex flex-col gap-4 md:flex-row md:items-end md:justify-between">
        <div>
          {faultScreen === 'create' ? <p className="mb-3 text-sm text-[#45464D]">Bakım <span className="mx-2">›</span> Arıza Kayıtları <span className="mx-2">›</span> <strong className="text-black">Yeni Kayıt</strong></p> : null}
          <h2 className="text-3xl font-bold tracking-tight text-black">{faultScreenTitle(faultScreen, selectedFault?.faultNo)}</h2>
          <p className="mt-2 text-[15px] leading-5 text-[#45464D]">{faultScreenDescription(faultScreen)}</p>
        </div>
        <div className="flex flex-wrap gap-2">
          <button className={`${faultScreen === 'list' ? 'bg-black text-white' : 'border border-[#C6C6CD] bg-white text-[#1B1B1D]'} px-4 py-2 text-[13px] font-semibold shadow-sm`} type="button" onClick={() => setFaultScreen('list')}>Arıza Listesi</button>
          <button className={`${faultScreen === 'create' ? 'bg-black text-white' : 'border border-[#C6C6CD] bg-white text-[#1B1B1D]'} px-4 py-2 text-[13px] font-semibold shadow-sm`} type="button" onClick={startCreateFault}>Yeni Arıza</button>
          <button className={`${faultScreen === 'detail' ? 'bg-black text-white' : 'border border-[#C6C6CD] bg-white text-[#1B1B1D]'} px-4 py-2 text-[13px] font-semibold shadow-sm disabled:text-[#76777D]`} disabled={!selectedFault} type="button" onClick={() => setFaultScreen('detail')}>Arıza Detay</button>
          <button className="hidden items-center gap-2 border border-[#C6C6CD] bg-white px-4 py-2 text-[13px] text-[#1B1B1D] shadow-sm md:flex" disabled={isLoading} type="button" onClick={handleRefresh}>
            <span className="material-symbols-outlined text-[18px]">refresh</span>
            Yenile
          </button>
          {faultScreen === 'list' ? <ExecutiveReportDownload apiBaseUrl={apiBaseUrl} disabled={isLoading} fileBaseName="ariza-yonetici-raporu" label="Rapor" path="/api/exports/faults" token={token} onMessage={setMessage} /> : null}
          {faultScreen === 'list' ? <button className="flex items-center gap-2 bg-black px-4 py-2 text-[13px] font-semibold text-white shadow-sm disabled:bg-[#76777D]" disabled={isLoading || !canCreateFaults} type="button" onClick={startCreateFault}>
            <span className="material-symbols-outlined text-[18px]">report</span>
            Yeni Arıza Kaydı
          </button> : null}
        </div>
      </div>

      <div key={faultScreen} className="screen-transition">
      {faultScreen === 'list' ? (
      <div className="mb-6 border border-[#C6C6CD] bg-white p-4 shadow-[0px_1px_3px_rgba(15,23,42,0.08)]">
        <div className="grid grid-cols-1 gap-4 md:grid-cols-[1.25fr_1fr_1fr_1fr_1fr_84px]">
          <FaultFieldLabel label="Tarih Aralığı">
            <div className="flex h-10 items-center gap-2 border border-[#C6C6CD] bg-white px-3 text-sm text-[#1B1B1D]"><span className="material-symbols-outlined text-[18px]">calendar_today</span>Son 30 Gün</div>
          </FaultFieldLabel>
          <FaultFieldLabel label="Lokasyon">
            <select className="asset-input" value={filters.locationId} onChange={(event) => setFilters((current) => ({ ...current, locationId: event.target.value }))}>
              <option value="">Tümü</option>
              {locations.map((location) => <option key={location.id} value={location.id}>{location.name}</option>)}
            </select>
          </FaultFieldLabel>
          <FaultFieldLabel label="Sistem">
            <select className="asset-input" value={filters.technicalSystemId} onChange={(event) => setFilters((current) => ({ ...current, technicalSystemId: event.target.value }))}>
              <option value="">Tümü</option>
              {technicalSystems.map((system) => <option key={system.id} value={system.id}>{system.name}</option>)}
            </select>
          </FaultFieldLabel>
          <FaultFieldLabel label="Öncelik">
            <select className="asset-input" value={filters.priority} onChange={(event) => setFilters((current) => ({ ...current, priority: event.target.value }))}>
              <option value="">Tümü</option>
              {faultPriorities.map((priority) => <option key={priority} value={priority}>{faultPriorityLabels[priority]}</option>)}
            </select>
          </FaultFieldLabel>
          <FaultFieldLabel label="Durum">
            <select className="asset-input" value={filters.status} onChange={(event) => setFilters((current) => ({ ...current, status: event.target.value }))}>
              <option value="">Açık</option>
              {faultStatuses.map((status) => <option key={status} value={status}>{faultStatusLabels[status]}</option>)}
            </select>
          </FaultFieldLabel>
          <div className="flex items-end">
            <button className="h-10 w-full border border-[#C6C6CD] bg-[#E4E2E4] px-3 text-[13px] font-semibold text-[#45464D]" disabled={isLoading} type="button" onClick={handleApplyFilters}>Filtrele</button>
          </div>
        </div>
      </div>
      ) : null}

      {faultScreen === 'create' ? (
      <section className="rounded border border-[#C6C6CD] bg-white p-7 shadow-[0px_1px_3px_rgba(15,23,42,0.08)]" id="new-fault-form">
        <div className="grid gap-8 xl:grid-cols-[1fr_360px]">
          <div>
            <h3 className="mb-4 flex items-center gap-2 border-b border-[#C6C6CD] pb-4 text-xl font-bold text-black"><span className="material-symbols-outlined text-[#3755C3]">info</span>Temel Bilgiler</h3>
            <div className="grid gap-5 md:grid-cols-2">
              <FaultFieldLabel label="Lokasyon">
                <select className="asset-input" value={filters.locationId} onChange={(event) => setFilters((current) => ({ ...current, locationId: event.target.value }))}>
                  <option value="">Lokasyon Seçiniz</option>
                  {locations.map((location) => <option key={location.id} value={location.id}>{location.name}</option>)}
                </select>
              </FaultFieldLabel>
              <FaultFieldLabel label="Sistem">
                <select className="asset-input" value={filters.technicalSystemId} onChange={(event) => setFilters((current) => ({ ...current, technicalSystemId: event.target.value }))}>
                  <option value="">Sistem Seçiniz</option>
                  {technicalSystems.map((system) => <option key={system.id} value={system.id}>{system.name}</option>)}
                </select>
              </FaultFieldLabel>
            </div>
            <div className="mt-5">
              <FaultFieldLabel label="Ekipman Kodu / Seri No">
                <select className="asset-input" value={faultForm.equipmentId} onChange={(event) => setFaultForm((current) => ({ ...current, equipmentId: event.target.value }))}>
                  <option value="">Örn: SVR-RACK04-N02</option>
                  {activeEquipment.map((item) => <option key={item.id} value={item.id}>{item.code} - {item.name}</option>)}
                </select>
              </FaultFieldLabel>
            </div>
            <div className="mt-5 max-w-sm">
              <FaultFieldLabel label="Bildirim Kaynağı">
                <select className="asset-input" value={faultForm.source} onChange={(event) => setFaultForm((current) => ({ ...current, source: event.target.value as FaultSource }))}>
                  {faultSources.map((source) => <option key={source} value={source}>{faultSourceLabels[source]}</option>)}
                </select>
              </FaultFieldLabel>
            </div>
            <div className="mt-10">
              <FaultFieldLabel label="Arıza Açıklaması ve Belirtiler">
                <textarea className="min-h-32 w-full border border-[#C6C6CD] bg-white p-3 text-sm outline-none focus:border-2 focus:border-[#3755C3]" placeholder="Gözlemlenen hataları, log kayıtlarından özetleri ve ilk müdahale bulgularını giriniz..." value={faultForm.description} onChange={(event) => setFaultForm((current) => ({ ...current, description: event.target.value }))} />
              </FaultFieldLabel>
            </div>
          </div>
          <aside className="h-fit border border-[#C6C6CD] bg-[#F6F3F5] p-5">
            <h3 className="mb-4 flex items-center gap-2 border-b border-[#C6C6CD] pb-4 text-xl font-bold text-black"><span className="material-symbols-outlined text-[#BA1A1A]">warning</span>Teşhis ve Öncelik</h3>
            <p className="mb-3 text-[11px] font-bold uppercase tracking-wide text-[#45464D]">Öncelik Seviyesi</p>
            <div className="grid grid-cols-2 gap-2">
              {faultPriorities.map((priority) => (
                <button key={priority} className={`flex h-11 items-center gap-2 border px-3 text-sm ${faultForm.priority === priority ? 'border-[#3755C3] bg-[#E0E7FF] font-semibold text-[#3755C3]' : 'border-[#C6C6CD] bg-white text-[#45464D]'}`} type="button" onClick={() => setFaultForm((current) => ({ ...current, priority }))}>
                  <span className={`h-3 w-3 rounded-full ${priority === 'Critical' ? 'bg-[#BA1A1A]' : priority === 'High' ? 'bg-[#F97316]' : priority === 'Medium' ? 'bg-[#3755C3]' : 'bg-[#C6C6CD]'}`} />
                  {faultPriorityLabels[priority]}
                </button>
              ))}
            </div>
            <div className="mt-6 border-t border-[#C6C6CD] pt-5">
              <FaultFieldLabel label="Atanacak Personel / Ekip">
                <select className="asset-input" value={assignForm.assignedToUserId} onChange={(event) => setAssignForm((current) => ({ ...current, assignedToUserId: event.target.value }))}>
                  <option value="">Otomatik Ata (Yüke Göre)</option>
                  {technicians.map((technician) => <option key={technician.id} value={technician.id}>{technician.fullName}</option>)}
                </select>
              </FaultFieldLabel>
            </div>
          </aside>
        </div>
        <div className="mt-8 flex justify-end gap-4 border-t border-[#C6C6CD] pt-5">
          <button className="px-5 py-2 text-sm font-semibold text-[#45464D] hover:bg-[#E4E2E4]" type="button" onClick={() => setFaultScreen('list')}>Vazgeç</button>
          <button className="flex items-center gap-2 bg-black px-6 py-2 text-sm font-semibold text-white disabled:bg-[#76777D]" disabled={isLoading || !canCreateFaults} type="button" onClick={handleCreateFault}>
            <span className="material-symbols-outlined text-[18px]">save</span>
            Kaydet ve Oluştur
          </button>
        </div>
      </section>
      ) : null}

      {faultScreen === 'detail' ? renderFaultDetailScreen() : null}

      {faultScreen === 'list' ? (
      <div>
        <section className="overflow-hidden border border-[#C6C6CD] bg-white shadow-[0px_1px_3px_rgba(15,23,42,0.08)]">
          <div className="flex flex-col gap-2 border-b border-[#C6C6CD] bg-white p-4 md:flex-row md:items-center md:justify-between">
            <div>
              <p className="text-[11px] font-bold uppercase tracking-wide text-[#45464D]">Arıza Listesi Ekranı</p>
              <h3 className="mt-1 text-lg font-semibold text-black">Canlı arıza kayıtları</h3>
            </div>
            <div className="flex flex-wrap items-center gap-2 text-[11px] font-bold uppercase tracking-wide">
              <span className="inline-flex items-center gap-1 bg-[#FEE2E2] px-2 py-1 text-[#BA1A1A]"><span className="h-3 w-1 bg-[#BA1A1A]" />Kritik kırmızı şerit</span>
              <span className="bg-[#FFEDD5] px-2 py-1 text-[#C2410C]">Yüksek öncelik turuncu</span>
            </div>
          </div>
          <div className="overflow-x-auto">
            <table className="w-full border-collapse text-left">
              <thead>
                <tr className="border-b border-[#C6C6CD] bg-[#FCF8FA]">
                  <FaultTableHeader>Arıza</FaultTableHeader>
                  <FaultTableHeader>Ekipman</FaultTableHeader>
                  <FaultTableHeader>Lokasyon / Sistem</FaultTableHeader>
                  <FaultTableHeader>Durum</FaultTableHeader>
                  <FaultTableHeader>Atanan</FaultTableHeader>
                  <FaultTableHeader>Oluşturma</FaultTableHeader>
                  <FaultTableHeader alignRight>İşlem</FaultTableHeader>
                </tr>
              </thead>
              <tbody className="text-[13px] text-[#1B1B1D]">
                {faults.map((fault, index) => (
                  <tr
                    key={fault.id}
                    className={`border-b border-[#C6C6CD] transition-colors hover:bg-[#FCF8FA] ${index % 2 === 1 ? 'bg-[#FCF8FA]/50' : 'bg-white'} ${fault.priority === 'Critical' ? 'border-l-4 border-l-[#BA1A1A]' : ''}`}
                  >
                    <td className="p-3">
                      <button className="text-left" type="button" onClick={() => handleSelectFault(fault.id)}>
                        <span className="block font-mono text-[13px] font-bold text-black">{fault.faultNo}</span>
                        <span className="mt-1 inline-flex"><FaultPriorityBadge priority={fault.priority} /></span>
                      </button>
                    </td>
                    <td className="p-3">
                      <span className="block font-semibold text-black">{fault.equipmentName}</span>
                      <span className="font-mono text-xs text-[#76777D]">{fault.equipmentCode}</span>
                    </td>
                    <td className="p-3 text-[#45464D]">
                      <span className="block">{fault.locationName}</span>
                      <span className="text-xs">{fault.technicalSystemName}</span>
                    </td>
                    <td className="p-3"><FaultStatusBadge status={fault.status} /></td>
                    <td className="p-3 text-[#45464D]">{fault.assignedToUserName ?? '-'}</td>
                    <td className="p-3 font-mono text-xs text-[#45464D]">{formatDateTime(fault.createdAt)}</td>
                    <td className="p-3 text-right">
                      <button className="p-1 text-[#45464D] transition-colors hover:text-black" type="button" onClick={() => handleSelectFault(fault.id)}>
                        <span className="material-symbols-outlined text-[18px]">open_in_new</span>
                      </button>
                    </td>
                  </tr>
                ))}
              </tbody>
            </table>
          </div>
          {faults.length === 0 ? (
            <div className="p-8 text-center text-sm text-[#45464D]">Filtreye uygun arıza kaydı bulunamadı.</div>
          ) : null}
          <div className="flex items-center justify-between border-t border-[#C6C6CD] bg-white p-3">
            <span className="text-[13px] text-[#45464D]">Toplam {faults.length} arıza gösteriliyor</span>
            <span className="font-mono text-xs text-[#76777D]">API: /api/faults</span>
          </div>
        </section>

      </div>
      ) : null}
      </div>
    </section>
  )
}

function getDefaultNextStatus(status: FaultStatus): FaultStatus {
  if (status === 'New') {
    return 'InReview'
  }

  if (status === 'Assigned') {
    return 'InProgress'
  }

  if (status === 'Waiting') {
    return 'InProgress'
  }

  return 'Waiting'
}

function formatDateTime(value?: string | null) {
  if (!value) {
    return '-'
  }

  return new Intl.DateTimeFormat('tr-TR', {
    dateStyle: 'short',
    timeStyle: 'short',
  }).format(new Date(value))
}

function formatFaultAge(createdAt: string, endedAt?: string | null) {
  const start = new Date(createdAt).getTime()
  const end = endedAt ? new Date(endedAt).getTime() : Date.now()
  const diffHours = Math.max(0, (end - start) / 36e5)

  if (diffHours < 1) {
    return { value: `${Math.max(1, Math.round(diffHours * 60))}`, label: endedAt ? 'Dakikada çözüldü' : 'Dakikadır açık' }
  }

  if (diffHours < 24) {
    return { value: diffHours.toFixed(1), label: endedAt ? 'Saatte çözüldü' : 'Saattir açık' }
  }

  return { value: (diffHours / 24).toFixed(1), label: endedAt ? 'Günde çözüldü' : 'Gündür açık' }
}

function formatActionType(actionType: string) {
  const labels: Record<string, string> = {
    Created: 'Oluşturuldu',
    Assigned: 'Atandı',
    StatusChanged: 'Durum Güncellendi',
    NoteAdded: 'İşlem Notu',
    Resolved: 'Çözüldü',
    Closed: 'Kapatıldı',
  }

  return labels[actionType] ?? actionType
}

function faultScreenTitle(screen: FaultScreen, faultNo?: string) {
  if (screen === 'create') {
    return 'Yeni Arıza Kaydı'
  }

  if (screen === 'detail') {
    return faultNo ? `Arıza Detay: ${faultNo}` : 'Arıza Detay'
  }

  return 'Arıza Listesi'
}

function faultScreenDescription(screen: FaultScreen) {
  if (screen === 'create') {
    return 'Sistem üzerindeki yeni bir donanım veya yazılım arızasını sisteme işleyin.'
  }

  if (screen === 'detail') {
    return 'Arızanın özet bilgileri, atama bilgisi, çözüm notu ve işlem geçmişi.'
  }

  return 'Sistem hataları ve operasyonel arızaların listesi.'
}

function FaultSummaryCell({ label, value }: { label: string; value: string }) {
  return (
    <div>
      <p className="text-[11px] font-bold uppercase tracking-wide text-[#45464D]">{label}</p>
      <p className="mt-2 text-sm font-semibold text-black">{value}</p>
    </div>
  )
}

function FaultFieldLabel({ label, children }: { label: string; children: ReactNode }) {
  return (
    <label className="block text-[11px] font-bold uppercase tracking-wide text-[#45464D]">
      {label}
      <div className="mt-1">{children}</div>
    </label>
  )
}

function FaultPanelTitle({ eyebrow, title }: { eyebrow: string; title: string }) {
  return (
    <div className="mb-4">
      <p className="text-[11px] font-bold uppercase tracking-wide text-[#45464D]">{eyebrow}</p>
      <h3 className="mt-1 text-lg font-semibold text-black">{title}</h3>
    </div>
  )
}

function FaultStatusBadge({ status }: { status: FaultStatus }) {
  return <span className={`inline-flex rounded px-2 py-0.5 text-[11px] font-bold ${faultStatusBadgeClasses[status]}`}>{faultStatusLabels[status]}</span>
}

function FaultPriorityBadge({ priority }: { priority: FaultPriority }) {
  return <span className={`inline-flex rounded px-2 py-0.5 text-[11px] font-bold ${faultPriorityBadgeClasses[priority]}`}>{faultPriorityLabels[priority]}</span>
}

function FaultActionButton({ disabled, icon, label, onClick }: { disabled: boolean; icon: string; label: string; onClick: () => void }) {
  return (
    <button className="mt-3 flex w-full items-center justify-center gap-2 bg-[#3755C3] px-4 py-2 text-sm font-semibold text-white disabled:bg-[#76777D]" disabled={disabled} type="button" onClick={onClick}>
      <span className="material-symbols-outlined text-[18px]">{icon}</span>
      {label}
    </button>
  )
}

function FaultTableHeader({ children, alignRight = false }: { children: ReactNode; alignRight?: boolean }) {
  return <th className={`p-3 text-[11px] font-bold uppercase tracking-wide text-[#45464D] ${alignRight ? 'text-right' : ''}`}>{children}</th>
}

function FaultSpecRow({ label, value, mono = false }: { label: string; value: string; mono?: boolean }) {
  return (
    <div className="flex justify-between gap-3 border-b border-[#C6C6CD] pb-2">
      <dt className="text-[#45464D]">{label}</dt>
      <dd className={`${mono ? 'font-mono text-xs' : 'font-medium'} text-right text-[#1B1B1D]`}>{value}</dd>
    </div>
  )
}

export default FaultsView
