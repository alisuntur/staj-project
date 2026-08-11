import { useEffect, useState, type ReactNode } from 'react'

type EquipmentViewProps = {
  apiBaseUrl: string
  token: string
}

type LocationItem = {
  id: string
  parentLocationId?: string | null
  code: string
  name: string
  type: string
  description?: string | null
  isActive: boolean
}

type TechnicalSystemItem = {
  id: string
  code: string
  name: string
  description?: string | null
  isActive: boolean
}

type EquipmentStatus = 'Active' | 'Passive' | 'Maintenance' | 'Faulted'

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

type EquipmentDetail = EquipmentListItem & {
  commissionedAt?: string | null
  description?: string | null
  location: LocationItem
  technicalSystem: TechnicalSystemItem
}

type EquipmentFormState = {
  locationId: string
  technicalSystemId: string
  code: string
  name: string
  brand: string
  model: string
  serialNo: string
  status: EquipmentStatus
  commissionedAt: string
  description: string
  isActive: boolean
}

type EquipmentFilters = {
  search: string
  locationId: string
  technicalSystemId: string
  status: string
  isActive: string
}

type EquipmentScreen = 'list' | 'new' | 'detail' | 'locations' | 'locationDetail'

const equipmentStatuses: EquipmentStatus[] = ['Active', 'Passive', 'Maintenance', 'Faulted']

const statusLabels: Record<EquipmentStatus, string> = {
  Active: 'Aktif',
  Passive: 'Pasif',
  Maintenance: 'Bakımda',
  Faulted: 'Arızalı',
}

const statusBadgeClasses: Record<EquipmentStatus, string> = {
  Active: 'bg-[#DCFCE7] text-[#16A34A]',
  Passive: 'bg-[#E4E2E4] text-[#45464D]',
  Maintenance: 'bg-[#FEF08A] text-[#854D0E]',
  Faulted: 'bg-[#FEE2E2] text-[#BA1A1A]',
}

const defaultFilters: EquipmentFilters = {
  search: '',
  locationId: '',
  technicalSystemId: '',
  status: '',
  isActive: '',
}

const emptyForm: EquipmentFormState = {
  locationId: '',
  technicalSystemId: '',
  code: '',
  name: '',
  brand: '',
  model: '',
  serialNo: '',
  status: 'Active',
  commissionedAt: '',
  description: '',
  isActive: true,
}

function EquipmentView({ apiBaseUrl, token }: EquipmentViewProps) {
  const [screen, setScreen] = useState<EquipmentScreen>('list')
  const [locations, setLocations] = useState<LocationItem[]>([])
  const [technicalSystems, setTechnicalSystems] = useState<TechnicalSystemItem[]>([])
  const [equipment, setEquipment] = useState<EquipmentListItem[]>([])
  const [selectedEquipment, setSelectedEquipment] = useState<EquipmentDetail | null>(null)
  const [selectedLocationId, setSelectedLocationId] = useState('')
  const [filters, setFilters] = useState<EquipmentFilters>(defaultFilters)
  const [form, setForm] = useState<EquipmentFormState>(emptyForm)
  const [editingId, setEditingId] = useState('')
  const [isLoading, setIsLoading] = useState(false)
  const [message, setMessage] = useState('Varlık yönetimi verileri yükleniyor...')

  useEffect(() => {
    let ignore = false

    async function loadInitialData() {
      setIsLoading(true)
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

        const [locationData, systemData] = await Promise.all([
          initialRequest<LocationItem[]>('/api/locations'),
          initialRequest<TechnicalSystemItem[]>('/api/technical-systems'),
        ])

        if (ignore) {
          return
        }

        setLocations(locationData)
        setTechnicalSystems(systemData)
        setSelectedLocationId((current) => (current && locationData.some((location) => location.id === current) ? current : locationData[0]?.id || ''))
        setForm((current) => ({
          ...current,
          locationId: current.locationId || locationData[0]?.id || '',
          technicalSystemId: current.technicalSystemId || systemData[0]?.id || '',
        }))

        const equipmentData = await initialRequest<EquipmentListItem[]>('/api/equipment')
        if (ignore) {
          return
        }

        setEquipment(equipmentData)
        if (!ignore) {
          setMessage(`${equipmentData.length} ekipman kaydı yüklendi.`)
        }
      } catch (error) {
        if (!ignore) {
          setMessage(error instanceof Error ? error.message : 'Ekipman verileri yüklenemedi.')
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

    const response = await fetch(`${apiBaseUrl}${path}`, { ...options, headers })
    const text = await response.text()
    const payload = text ? JSON.parse(text) : null

    if (!response.ok) {
      throw new Error((payload as { message?: string } | null)?.message ?? `API isteği başarısız: ${response.status}`)
    }

    return payload as T
  }

  async function loadEquipment(currentFilters: EquipmentFilters = filters, selectFirst = false) {
    const params = new URLSearchParams()
    Object.entries(currentFilters).forEach(([key, value]) => {
      if (value) {
        params.set(key, value)
      }
    })

    const path = params.size ? `/api/equipment?${params.toString()}` : '/api/equipment'
    const data = await apiRequest<EquipmentListItem[]>(path)
    setEquipment(data)

    if (selectFirst && data.length > 0 && (!selectedEquipment || !data.some((item) => item.id === selectedEquipment.id))) {
      await handleSelectEquipment(data[0].id, false)
    }

    if (data.length === 0) {
      setSelectedEquipment(null)
    }

    return data
  }

  async function handleApplyFilters() {
    setIsLoading(true)
    try {
      const data = await loadEquipment(filters)
      setMessage(`${data.length} ekipman filtre sonucunda listelendi.`)
    } catch (error) {
      setMessage(error instanceof Error ? error.message : 'Ekipman listesi alınamadı.')
    } finally {
      setIsLoading(false)
    }
  }

  async function handleResetFilters() {
    setIsLoading(true)
    try {
      setFilters(defaultFilters)
      const data = await loadEquipment(defaultFilters)
      setMessage(`Filtreler temizlendi. ${data.length} ekipman listelendi.`)
    } catch (error) {
      setMessage(error instanceof Error ? error.message : 'Filtreler temizlenemedi.')
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
        loadEquipment(filters),
      ])
      setLocations(locationData)
      setTechnicalSystems(systemData)
      setSelectedLocationId((current) => (current && locationData.some((location) => location.id === current) ? current : locationData[0]?.id || ''))
      setMessage(`Veriler yenilendi. ${equipmentData.length} ekipman listelendi.`)
    } catch (error) {
      setMessage(error instanceof Error ? error.message : 'Veriler yenilenemedi.')
    } finally {
      setIsLoading(false)
    }
  }

  async function handleSelectEquipment(id: string, showMessage = true) {
    setIsLoading(true)
    try {
      const detail = await apiRequest<EquipmentDetail>(`/api/equipment/${id}`)
      setSelectedEquipment(detail)
      setEditingId(detail.id)
      setForm({
        locationId: detail.locationId,
        technicalSystemId: detail.technicalSystemId,
        code: detail.code,
        name: detail.name,
        brand: detail.brand ?? '',
        model: detail.model ?? '',
        serialNo: detail.serialNo ?? '',
        status: detail.status,
        commissionedAt: detail.commissionedAt ?? '',
        description: detail.description ?? '',
        isActive: detail.isActive,
      })
      setScreen('detail')

      if (showMessage) {
        setMessage(`${detail.code} ekipman detayı açıldı.`)
      }
    } catch (error) {
      setMessage(error instanceof Error ? error.message : 'Ekipman detayı alınamadı.')
    } finally {
      setIsLoading(false)
    }
  }

  function startCreateEquipment() {
    setEditingId('')
    setForm({
      ...emptyForm,
      locationId: locations[0]?.id || '',
      technicalSystemId: technicalSystems[0]?.id || '',
    })
    setScreen('new')
    setMessage('Yeni ekipman formu açıldı.')
  }

  function handleSelectLocation(locationId: string) {
    const location = locations.find((item) => item.id === locationId)
    setSelectedLocationId(locationId)
    setScreen('locationDetail')
    setMessage(`${location?.name ?? 'Lokasyon'} detayı açıldı.`)
  }

  async function showLocationEquipment(locationId: string) {
    const location = locations.find((item) => item.id === locationId)
    const nextFilters = { ...defaultFilters, locationId }

    setFilters(nextFilters)
    setScreen('list')
    setIsLoading(true)

    try {
      const data = await loadEquipment(nextFilters, false)
      setMessage(`${location?.name ?? 'Lokasyon'} için ${data.length} ekipman listelendi.`)
    } catch (error) {
      setMessage(error instanceof Error ? error.message : 'Lokasyon ekipmanları listelenemedi.')
    } finally {
      setIsLoading(false)
    }
  }

  async function handleSubmitEquipment() {
    if (!form.locationId || !form.technicalSystemId || !form.code.trim() || !form.name.trim()) {
      setMessage('Ekipman kodu, adı, lokasyon ve sistem seçimi zorunludur.')
      return
    }

    setIsLoading(true)
    try {
      const body = JSON.stringify({ ...form, commissionedAt: form.commissionedAt || null })
      const path = editingId ? `/api/equipment/${editingId}` : '/api/equipment'
      const method = editingId ? 'PUT' : 'POST'
      const detail = await apiRequest<EquipmentDetail>(path, { method, body })
      await loadEquipment(filters, false)
      setSelectedEquipment(detail)
      setEditingId(detail.id)
      setScreen('detail')
      setMessage(`${detail.code} ekipman kaydı ${method === 'POST' ? 'oluşturuldu' : 'güncellendi'}.`)
    } catch (error) {
      setMessage(error instanceof Error ? error.message : 'Ekipman kaydedilemedi.')
    } finally {
      setIsLoading(false)
    }
  }

  function exportEquipmentCsv() {
    if (equipment.length === 0) {
      setMessage('Dışa aktarılacak ekipman yok.')
      return
    }

    const headers = ['Ekipman Kodu', 'Ad', 'Lokasyon', 'Sistem Türü', 'Durum', 'Aktif']
    const rows = equipment.map((item) => [item.code, item.name, item.locationName, item.technicalSystemName, statusLabels[item.status], item.isActive ? 'Aktif' : 'Pasif'])
    const csv = [headers, ...rows].map((row) => row.map((cell) => `"${cell.replaceAll('"', '""')}"`).join(',')).join('\n')
    const blob = new Blob([`\uFEFF${csv}`], { type: 'text/csv;charset=utf-8;' })
    const url = URL.createObjectURL(blob)
    const link = document.createElement('a')
    link.href = url
    link.download = `ekipman-envanteri-${new Date().toISOString().slice(0, 10)}.csv`
    link.click()
    URL.revokeObjectURL(url)
    setMessage(`${equipment.length} ekipman CSV olarak dışa aktarıldı.`)
  }

  return (
    <section className="module-font mx-auto w-full max-w-[1600px] px-5 py-6 lg:px-6">
      <div className="mb-6 flex flex-col gap-4 md:flex-row md:items-end md:justify-between">
        <div>
          <h2 className="text-3xl font-bold tracking-tight text-black">{screenTitle(screen)}</h2>
          <p className="mt-1 text-[13px] leading-5 text-[#45464D]">Varlık yönetimi akışı: liste, yeni kayıt, detay ve lokasyon ekranları.</p>
        </div>
        <div className="flex flex-wrap gap-2">
          <AssetScreenButton active={screen === 'list'} label="Ekipman Listesi" onClick={() => setScreen('list')} />
          <AssetScreenButton active={screen === 'new'} label="Yeni Ekipman" onClick={startCreateEquipment} />
          <AssetScreenButton active={screen === 'detail'} disabled={!selectedEquipment} label="Ekipman Detay" onClick={() => setScreen('detail')} />
          <AssetScreenButton active={screen === 'locations' || screen === 'locationDetail'} label="Lokasyonlar" onClick={() => setScreen('locations')} />
        </div>
      </div>

      <div key={screen} className="screen-transition">
      {screen === 'list' ? renderListScreen() : null}
      {screen === 'new' ? renderNewEquipmentScreen() : null}
      {screen === 'detail' ? renderDetailScreen() : null}
      {screen === 'locations' ? renderLocationsScreen() : null}
      {screen === 'locationDetail' ? renderLocationDetailScreen() : null}
      </div>

      <div className="mt-4 border border-[#C6C6CD] bg-[#F6F3F5] p-3 text-[13px] text-[#45464D]">{message}</div>
    </section>
  )

  function renderListScreen() {
    return (
      <>
        <div className="mb-6 flex justify-end gap-2">
          <button className="flex items-center gap-2 border border-[#C6C6CD] bg-white px-4 py-2 text-[13px] text-[#1B1B1D] shadow-sm" disabled={isLoading} type="button" onClick={handleRefresh}>
            <span className="material-symbols-outlined text-[18px]">refresh</span>
            Yenile
          </button>
          <button className="flex items-center gap-2 border border-[#C6C6CD] bg-white px-4 py-2 text-[13px] text-[#1B1B1D] shadow-sm" type="button" onClick={exportEquipmentCsv}>
            <span className="material-symbols-outlined text-[18px]">download</span>
            Dışa Aktar
          </button>
          <button className="flex items-center gap-2 bg-black px-4 py-2 text-[13px] font-semibold text-white shadow-sm" type="button" onClick={startCreateEquipment}>
            <span className="material-symbols-outlined text-[18px]">add</span>
            Yeni Ekipman Ekle
          </button>
        </div>

        <div className="mb-6 border border-[#C6C6CD] bg-white p-4 shadow-[0px_1px_3px_rgba(15,23,42,0.08)]">
          <div className="grid gap-4 md:grid-cols-5">
            <AssetFieldLabel label="Sistem Türü">
              <select className="asset-input" value={filters.technicalSystemId} onChange={(event) => setFilters((current) => ({ ...current, technicalSystemId: event.target.value }))}>
                <option value="">Tümü</option>
                {technicalSystems.map((system) => <option key={system.id} value={system.id}>{system.name}</option>)}
              </select>
            </AssetFieldLabel>
            <AssetFieldLabel label="Lokasyon">
              <select className="asset-input" value={filters.locationId} onChange={(event) => setFilters((current) => ({ ...current, locationId: event.target.value }))}>
                <option value="">Tüm Lokasyonlar</option>
                {locations.map((location) => <option key={location.id} value={location.id}>{location.name}</option>)}
              </select>
            </AssetFieldLabel>
            <AssetFieldLabel label="Durum">
              <select className="asset-input" value={filters.status} onChange={(event) => setFilters((current) => ({ ...current, status: event.target.value }))}>
                <option value="">Tümü</option>
                {equipmentStatuses.map((status) => <option key={status} value={status}>{statusLabels[status]}</option>)}
              </select>
            </AssetFieldLabel>
            <AssetFieldLabel label="Aktiflik">
              <select className="asset-input" value={filters.isActive} onChange={(event) => setFilters((current) => ({ ...current, isActive: event.target.value }))}>
                <option value="">Tümü</option>
                <option value="true">Aktif</option>
                <option value="false">Pasif</option>
              </select>
            </AssetFieldLabel>
            <div className="flex items-end gap-2">
              <button className="h-10 flex-1 border border-[#C6C6CD] text-sm font-semibold text-[#45464D]" disabled={isLoading} type="button" onClick={handleResetFilters}>Temizle</button>
              <button className="h-10 flex-1 bg-[#3755C3] text-sm font-semibold text-white disabled:bg-[#76777D]" disabled={isLoading} type="button" onClick={handleApplyFilters}>Filtrele</button>
            </div>
          </div>
        </div>

        <section className="overflow-hidden border border-[#C6C6CD] bg-white shadow-[0px_1px_3px_rgba(15,23,42,0.08)]">
          <div className="overflow-x-auto">
            <table className="w-full border-collapse text-left">
              <thead>
                <tr className="border-b border-[#C6C6CD] bg-[#FCF8FA]">
                  <AssetTableHeader>Ekipman Kodu</AssetTableHeader>
                  <AssetTableHeader>Ad</AssetTableHeader>
                  <AssetTableHeader>Lokasyon</AssetTableHeader>
                  <AssetTableHeader>Sistem Türü</AssetTableHeader>
                  <AssetTableHeader>Uptime (%)</AssetTableHeader>
                  <AssetTableHeader>Durum</AssetTableHeader>
                  <AssetTableHeader alignRight>İşlemler</AssetTableHeader>
                </tr>
              </thead>
              <tbody className="text-[13px] text-[#1B1B1D]">
                {equipment.map((item, index) => (
                  <tr key={item.id} className={`border-b border-[#C6C6CD] transition-colors hover:bg-[#FCF8FA] ${index % 2 === 1 ? 'bg-[#FCF8FA]/50' : 'bg-white'}`}>
                    <td className={`p-3 font-mono font-medium ${item.isActive ? 'text-black' : 'text-[#76777D] line-through'}`}>{item.code}</td>
                    <td className="p-3 font-medium">{item.name}</td>
                    <td className="p-3 text-[#45464D]">{item.locationName}</td>
                    <td className="p-3">{item.technicalSystemName}</td>
                    <td className="p-3 font-mono">{item.status === 'Passive' ? '-' : item.status === 'Maintenance' ? '98.45' : '99.99'}</td>
                    <td className="p-3"><AssetStatusBadge status={item.status} /></td>
                    <td className="p-3 text-right">
                      <button className="p-1 text-[#45464D] transition-colors hover:text-black" type="button" onClick={() => handleSelectEquipment(item.id)}>
                        <span className="material-symbols-outlined text-[18px]">more_vert</span>
                      </button>
                    </td>
                  </tr>
                ))}
              </tbody>
            </table>
          </div>
          <div className="flex items-center justify-between border-t border-[#C6C6CD] bg-white p-3">
            <span className="text-[13px] text-[#45464D]">Toplam {equipment.length} kayıttan 1-{Math.min(5, equipment.length)} arası gösteriliyor</span>
            <div className="flex gap-1">
              <button className="flex h-8 w-8 items-center justify-center border border-[#C6C6CD] text-[#76777D]" disabled type="button"><span className="material-symbols-outlined text-[18px]">chevron_left</span></button>
              <button className="flex h-8 w-8 items-center justify-center bg-black text-sm text-white" type="button">1</button>
              <button className="flex h-8 w-8 items-center justify-center border border-[#C6C6CD] text-[#45464D]" type="button">2</button>
              <button className="flex h-8 w-8 items-center justify-center border border-[#C6C6CD] text-[#45464D]" type="button"><span className="material-symbols-outlined text-[18px]">chevron_right</span></button>
            </div>
          </div>
        </section>
      </>
    )
  }

  function renderNewEquipmentScreen() {
    return (
      <div className="grid gap-6 xl:grid-cols-[1fr_360px]">
        <section className="border border-[#C6C6CD] bg-white p-7 shadow-[0px_1px_3px_rgba(15,23,42,0.08)]">
          <div className="grid gap-6 md:grid-cols-2">
            <AssetFieldLabel label="Ekipman Kodu">
              <input className="asset-input" placeholder="Örn: EQP-2023-001" value={form.code} onChange={(event) => setForm((current) => ({ ...current, code: event.target.value }))} />
            </AssetFieldLabel>
            <AssetFieldLabel label="Ekipman Adı *">
              <input className="asset-input" placeholder="Örn: Ana Dağıtım Panosu" value={form.name} onChange={(event) => setForm((current) => ({ ...current, name: event.target.value }))} />
            </AssetFieldLabel>
            <AssetFieldLabel label="Sistem Türü">
              <select className="asset-input" value={form.technicalSystemId} onChange={(event) => setForm((current) => ({ ...current, technicalSystemId: event.target.value }))}>
                <option value="">Sistem Seçin...</option>
                {technicalSystems.map((system) => <option key={system.id} value={system.id}>{system.name}</option>)}
              </select>
            </AssetFieldLabel>
            <AssetFieldLabel label="Lokasyon">
              <select className="asset-input" value={form.locationId} onChange={(event) => setForm((current) => ({ ...current, locationId: event.target.value }))}>
                <option value="">Bölge/Kat Seçin...</option>
                {locations.map((location) => <option key={location.id} value={location.id}>{location.name}</option>)}
              </select>
            </AssetFieldLabel>
            <AssetFieldLabel label="Marka / Model">
              <input className="asset-input" placeholder="Örn: Siemens S7-1500" value={form.brand} onChange={(event) => setForm((current) => ({ ...current, brand: event.target.value }))} />
            </AssetFieldLabel>
            <AssetFieldLabel label="Seri Numarası">
              <input className="asset-input uppercase" placeholder="Örn: SN-9876543210" value={form.serialNo} onChange={(event) => setForm((current) => ({ ...current, serialNo: event.target.value }))} />
            </AssetFieldLabel>
            <AssetFieldLabel label="Durum">
              <select className="asset-input" value={form.status} onChange={(event) => setForm((current) => ({ ...current, status: event.target.value as EquipmentStatus }))}>
                {equipmentStatuses.map((status) => <option key={status} value={status}>{statusLabels[status]}</option>)}
              </select>
            </AssetFieldLabel>
            <AssetFieldLabel label="Devreye Alma Tarihi">
              <input className="asset-input" type="date" value={form.commissionedAt} onChange={(event) => setForm((current) => ({ ...current, commissionedAt: event.target.value }))} />
            </AssetFieldLabel>
          </div>
          <AssetFieldLabel label="Teknik Özellikler / Notlar">
            <textarea className="mt-1 min-h-32 w-full border border-[#C6C6CD] bg-white p-3 text-sm outline-none focus:border-2 focus:border-[#3755C3]" value={form.description} onChange={(event) => setForm((current) => ({ ...current, description: event.target.value }))} />
          </AssetFieldLabel>
          <div className="mt-8 flex flex-wrap justify-end gap-3 border-t border-[#C6C6CD] pt-5">
            <button className="px-5 py-2 text-sm font-semibold text-[#45464D] hover:bg-[#E4E2E4]" type="button" onClick={() => setScreen('list')}>İptal</button>
            <button className="border border-[#3755C3] px-6 py-2 text-sm font-semibold text-[#3755C3]" type="button" onClick={() => setMessage('Taslak demo kapsamında saklanmadı.')}>Taslak Olarak Kaydet</button>
            <button className="bg-black px-6 py-2 text-sm font-semibold text-white disabled:bg-[#76777D]" disabled={isLoading} type="button" onClick={handleSubmitEquipment}>Sisteme Ekle</button>
          </div>
        </section>
        <aside className="space-y-5">
          <InfoCard title="Kodlama Standardı" icon="info">
            Ekipman kodları manuel girilebilir. Önerilen format: <span className="font-mono">EQ-[SISTEM]-[SIRA]</span>.
          </InfoCard>
          <InfoCard title="Son Eklenenler" icon="fiber_manual_record">
            <div className="space-y-3">
              {equipment.slice(0, 2).map((item) => (
                <div key={item.id} className="border-l-4 border-[#3755C3] pl-3">
                  <p className="font-semibold text-black">{item.name}</p>
                  <p className="font-mono text-xs text-[#45464D]">{item.code} • {item.locationName}</p>
                </div>
              ))}
            </div>
          </InfoCard>
        </aside>
      </div>
    )
  }

  function renderDetailScreen() {
    if (!selectedEquipment) {
      return <EmptyPanel title="Ekipman Detay" text="Listeden bir ekipman seçildiğinde detay ekranı burada açılır." />
    }

    return (
      <>
        <section className="mb-6 border border-[#C6C6CD] bg-[#E4E2E4] p-7 shadow-[0px_1px_3px_rgba(15,23,42,0.08)]">
          <div className="flex flex-col gap-5 md:flex-row md:items-center md:justify-between">
            <div className="flex items-center gap-5">
              <div className="flex h-20 w-20 items-center justify-center border border-[#C6C6CD] bg-[#F0EDEF] text-[#45464D]"><span className="material-symbols-outlined text-[40px]">bolt</span></div>
              <div>
                <div className="mb-2 flex flex-wrap gap-2"><span className="bg-[#F0EDEF] px-2 py-1 font-mono text-[13px] text-black">{selectedEquipment.code}</span><AssetStatusBadge status={selectedEquipment.status} /></div>
                <h3 className="text-4xl font-bold tracking-tight text-black">{selectedEquipment.name}</h3>
                <div className="mt-3 flex flex-wrap gap-4 text-[13px] text-[#45464D]"><span>{selectedEquipment.location.name}</span><span>Sistem: {selectedEquipment.technicalSystem.name}</span><span>Son Bakım: 12 Eki 2023</span></div>
              </div>
            </div>
            <div className="flex gap-2"><button className="border border-[#76777D] bg-white px-5 py-2 font-semibold" type="button" onClick={() => setScreen('new')}>Düzenle</button><button className="bg-black px-5 py-2 font-semibold text-white" type="button">İş Emri Oluştur</button></div>
          </div>
        </section>
        <div className="mb-6 flex flex-wrap gap-6 border-b border-[#C6C6CD] text-lg font-medium text-[#45464D]"><span className="border-b-2 border-black pb-3 font-bold text-black">Genel Bilgiler</span><span>Arıza Geçmişi</span><span>Bakım Geçmişi</span><span>Test Geçmişi</span></div>
        <div className="grid gap-6 xl:grid-cols-[360px_1fr]">
          <section className="border border-[#C6C6CD] bg-white p-5"><AssetSectionTitle title="Teknik Özellikler" /><AssetSpecRow label="Marka/Model" value={`${selectedEquipment.brand ?? '-'} / ${selectedEquipment.model ?? '-'}`} /><AssetSpecRow label="Kapasite" value="750 kVA" /><AssetSpecRow label="Kurulum Tarihi" value={selectedEquipment.commissionedAt ?? '-'} /><AssetSpecRow label="Seri No" value={selectedEquipment.serialNo ?? '-'} /></section>
          <section className="space-y-5"><div className="border border-[#C6C6CD] bg-white"><AssetSectionTitle padded title="Son Bakım Kayıtları" /><table className="w-full text-left text-sm"><tbody><AssetMiniRow cols={['12 Eki 2023', 'WO-8892', 'Periyodik (6 Aylık)', 'TAMAMLANDI']} /><AssetMiniRow cols={['14 Nis 2023', 'WO-7104', 'Arıza Müdahale', 'TAMAMLANDI']} /></tbody></table></div><div className="border border-[#C6C6CD] bg-white p-5"><AssetSectionTitle title="Son Arıza Logları" /><p className="text-lg font-bold text-black">Düşük Yağ Basıncı Uyarısı</p><p className="mt-1 text-sm text-[#45464D]">Sensör düşük basınç algıladı. Sistem otomatik olarak güvenli moda alındı.</p></div></section>
        </div>
      </>
    )
  }

  function renderLocationsScreen() {
    const criticalLocation = locations[2]
    const selectedLocation = locations.find((location) => location.id === selectedLocationId) ?? locations[0]

    return (
      <div className="grid gap-6 xl:grid-cols-[380px_1fr]">
        <section className="min-h-[680px] border border-[#C6C6CD] bg-white p-5">
          <div className="mb-5 flex items-center justify-between">
            <h3 className="text-xl font-bold text-black">Tesis Hiyerarşisi</h3>
            <span className="material-symbols-outlined text-[#45464D]">account_tree</span>
          </div>
          <div className="space-y-3 text-sm">
            <LocationTreeRow active={!selectedLocation} name="Merkez Kampüs" icon="domain" />
            <div className="ml-6 space-y-3 border-l border-[#C6C6CD] pl-5">
              {locations.slice(0, 4).map((location) => (
                <LocationTreeRow key={location.id} active={location.id === selectedLocation?.id} critical={location.id === criticalLocation?.id} name={location.name} icon="apartment" onClick={() => handleSelectLocation(location.id)} />
              ))}
            </div>
            <LocationTreeRow name="Kuzey Tesisleri" icon="domain" />
          </div>
        </section>

        <section className="min-h-[680px] overflow-hidden border border-[#C6C6CD] bg-white">
          <div className="flex flex-col gap-2 border-b border-[#C6C6CD] p-5 md:flex-row md:items-center md:justify-between">
            <div>
              <h3 className="text-xl font-bold text-black">Alt Lokasyon Detayları: Merkez Kampüs</h3>
              <p className="mt-1 text-sm text-[#45464D]">Detay butonuyla lokasyon kartına geçebilirsin.</p>
            </div>
            <span className="text-sm text-[#45464D]">Toplam {locations.length} Kayıt</span>
          </div>
          <div className="overflow-x-auto">
            <table className="w-full border-collapse text-left">
              <thead>
                <tr className="border-b border-[#C6C6CD] bg-[#FCF8FA]">
                  <AssetTableHeader>Lokasyon Adı</AssetTableHeader>
                  <AssetTableHeader>Tipi</AssetTableHeader>
                  <AssetTableHeader>Bağlı Ekipman</AssetTableHeader>
                  <AssetTableHeader>Aktif Arıza</AssetTableHeader>
                  <AssetTableHeader>Durum</AssetTableHeader>
                  <AssetTableHeader alignRight>İşlem</AssetTableHeader>
                </tr>
              </thead>
              <tbody>
                {locations.map((location, index) => {
                  const isCritical = location.id === criticalLocation?.id
                  const activeFaultCount = isCritical ? 2 : 0

                  return (
                    <tr key={location.id} className={`border-b border-[#C6C6CD] transition-colors hover:bg-[#FCF8FA] ${isCritical ? 'bg-[#FFF7F7]' : ''}`}>
                      <td className="p-4">
                        <button className="text-left font-semibold text-black hover:text-[#3755C3]" type="button" onClick={() => handleSelectLocation(location.id)}>{location.name}</button>
                        <p className="mt-1 font-mono text-xs text-[#76777D]">{location.code}</p>
                      </td>
                      <td className="p-4 text-[#45464D]">{location.type}</td>
                      <td className="p-4 font-mono">{equipment.filter((item) => item.locationId === location.id).length}</td>
                      <td className="p-4">{activeFaultCount > 0 ? <span className="inline-flex h-7 w-7 items-center justify-center rounded-full bg-[#BA1A1A] text-sm font-bold text-white">{activeFaultCount}</span> : '-'}</td>
                      <td className="p-4"><span className={`px-2 py-1 text-xs font-bold ${isCritical ? 'bg-[#FEE2E2] text-[#BA1A1A]' : 'bg-[#DCFCE7] text-[#16A34A]'}`}>{isCritical ? 'Kritik' : index % 2 === 0 ? 'Aktif' : 'Normal'}</span></td>
                      <td className="p-4 text-right">
                        <button className="inline-flex items-center gap-1 border border-[#3755C3] px-3 py-1.5 text-sm font-semibold text-[#3755C3] transition-colors hover:bg-[#E0E7FF]" type="button" onClick={() => handleSelectLocation(location.id)}>
                          Detay
                          <span className="material-symbols-outlined text-[16px]">arrow_forward</span>
                        </button>
                      </td>
                    </tr>
                  )
                })}
              </tbody>
            </table>
          </div>
        </section>
      </div>
    )
  }

  function renderLocationDetailScreen() {
    const location = locations.find((item) => item.id === selectedLocationId) ?? locations[0]

    if (!location) {
      return <EmptyPanel title="Lokasyon Detay" text="Detayını gösterecek lokasyon kaydı bulunamadı." />
    }

    const criticalLocation = locations[2]
    const relatedEquipment = equipment.filter((item) => item.locationId === location.id)
    const childLocations = locations.filter((item) => item.parentLocationId === location.id)
    const parentLocation = location.parentLocationId ? locations.find((item) => item.id === location.parentLocationId)?.name ?? '-' : 'Merkez Kampüs'
    const activeFaultCount = location.id === criticalLocation?.id ? 2 : 0
    const activeEquipmentCount = relatedEquipment.filter((item) => item.isActive).length

    return (
      <div className="grid gap-6 xl:grid-cols-[1fr_380px]">
        <section className="border border-[#C6C6CD] bg-white p-7 shadow-[0px_1px_3px_rgba(15,23,42,0.08)]">
          <button className="mb-5 flex items-center gap-2 text-sm font-semibold text-[#45464D] transition-colors hover:text-black" type="button" onClick={() => setScreen('locations')}>
            <span className="material-symbols-outlined text-[18px]">arrow_back</span>
            Lokasyonlara Dön
          </button>
          <div className="flex flex-col gap-5 border-b border-[#C6C6CD] pb-6 md:flex-row md:items-start md:justify-between">
            <div className="flex items-start gap-5">
              <div className={`flex h-20 w-20 items-center justify-center border ${activeFaultCount > 0 ? 'border-[#BA1A1A] bg-[#FEE2E2] text-[#BA1A1A]' : 'border-[#C6C6CD] bg-[#F0EDEF] text-[#45464D]'}`}>
                <span className="material-symbols-outlined text-[40px]">apartment</span>
              </div>
              <div>
                <div className="mb-2 flex flex-wrap gap-2">
                  <span className="bg-[#F0EDEF] px-2 py-1 font-mono text-[13px] text-black">{location.code}</span>
                  <span className={`px-2 py-1 text-xs font-bold ${activeFaultCount > 0 ? 'bg-[#FEE2E2] text-[#BA1A1A]' : location.isActive ? 'bg-[#DCFCE7] text-[#16A34A]' : 'bg-[#E4E2E4] text-[#45464D]'}`}>{activeFaultCount > 0 ? 'Kritik' : location.isActive ? 'Aktif' : 'Pasif'}</span>
                </div>
                <h3 className="text-4xl font-bold tracking-tight text-black">{location.name}</h3>
                <p className="mt-3 text-sm leading-6 text-[#45464D]">{location.description || 'Bu lokasyon için açıklama girilmemiş.'}</p>
              </div>
            </div>
            <button className="h-10 border border-[#3755C3] px-4 text-sm font-semibold text-[#3755C3]" type="button" onClick={() => void showLocationEquipment(location.id)}>Ekipmanları Listele</button>
          </div>

          <div className="mt-6 grid gap-4 md:grid-cols-4">
            <div className="border border-[#C6C6CD] bg-[#FCF8FA] p-4"><p className="text-[11px] font-bold uppercase tracking-wide text-[#45464D]">Lokasyon Tipi</p><p className="mt-2 text-lg font-bold text-black">{location.type}</p></div>
            <div className="border border-[#C6C6CD] bg-[#FCF8FA] p-4"><p className="text-[11px] font-bold uppercase tracking-wide text-[#45464D]">Bağlı Ekipman</p><p className="mt-2 font-mono text-2xl font-bold text-black">{relatedEquipment.length}</p></div>
            <div className="border border-[#C6C6CD] bg-[#FCF8FA] p-4"><p className="text-[11px] font-bold uppercase tracking-wide text-[#45464D]">Aktif Ekipman</p><p className="mt-2 font-mono text-2xl font-bold text-black">{activeEquipmentCount}</p></div>
            <div className="border border-[#C6C6CD] bg-[#FCF8FA] p-4"><p className="text-[11px] font-bold uppercase tracking-wide text-[#45464D]">Aktif Arıza</p><p className={`mt-2 font-mono text-2xl font-bold ${activeFaultCount > 0 ? 'text-[#BA1A1A]' : 'text-black'}`}>{activeFaultCount}</p></div>
          </div>

          <div className="mt-6 overflow-hidden border border-[#C6C6CD]">
            <div className="border-b border-[#C6C6CD] bg-[#FCF8FA] p-4"><h4 className="text-lg font-bold text-black">Bu Lokasyondaki Ekipmanlar</h4></div>
            <table className="w-full border-collapse text-left">
              <thead>
                <tr className="border-b border-[#C6C6CD]">
                  <AssetTableHeader>Ekipman</AssetTableHeader>
                  <AssetTableHeader>Sistem</AssetTableHeader>
                  <AssetTableHeader>Durum</AssetTableHeader>
                  <AssetTableHeader alignRight>İşlem</AssetTableHeader>
                </tr>
              </thead>
              <tbody className="text-sm">
                {relatedEquipment.map((item) => (
                  <tr key={item.id} className="border-b border-[#C6C6CD] hover:bg-[#FCF8FA]">
                    <td className="p-4"><p className="font-semibold text-black">{item.name}</p><p className="font-mono text-xs text-[#76777D]">{item.code}</p></td>
                    <td className="p-4 text-[#45464D]">{item.technicalSystemName}</td>
                    <td className="p-4"><AssetStatusBadge status={item.status} /></td>
                    <td className="p-4 text-right"><button className="text-sm font-semibold text-[#3755C3]" type="button" onClick={() => handleSelectEquipment(item.id)}>Ekipman Detayı</button></td>
                  </tr>
                ))}
                {relatedEquipment.length === 0 ? <tr><td className="p-6 text-center text-sm text-[#45464D]" colSpan={4}>Bu lokasyona bağlı ekipman bulunamadı.</td></tr> : null}
              </tbody>
            </table>
          </div>
        </section>

        <aside className="space-y-4">
          <section className="border border-[#C6C6CD] bg-[#F0EDEF] p-5 shadow-[0px_1px_3px_rgba(15,23,42,0.08)]">
            <AssetSectionTitle title="Lokasyon Kimliği" />
            <AssetSpecRow label="Kod" value={location.code} />
            <AssetSpecRow label="Üst Lokasyon" value={parentLocation} />
            <AssetSpecRow label="Aktiflik" value={location.isActive ? 'Aktif' : 'Pasif'} />
          </section>
          <section className="border border-[#C6C6CD] bg-white p-5 shadow-[0px_1px_3px_rgba(15,23,42,0.08)]">
            <AssetSectionTitle title="Alt Lokasyonlar" />
            <div className="space-y-2 text-sm text-[#45464D]">
              {childLocations.map((child) => <button key={child.id} className="flex w-full items-center justify-between border border-[#C6C6CD] bg-[#FCF8FA] px-3 py-2 text-left hover:border-[#3755C3]" type="button" onClick={() => handleSelectLocation(child.id)}><span>{child.name}</span><span className="material-symbols-outlined text-[16px]">arrow_forward</span></button>)}
              {childLocations.length === 0 ? <p>Alt lokasyon kaydı yok.</p> : null}
            </div>
          </section>
          <section className="border border-[#C6C6CD] bg-white p-5 shadow-[0px_1px_3px_rgba(15,23,42,0.08)]">
            <AssetSectionTitle title="Hızlı İşlemler" />
            <button className="flex w-full items-center justify-center gap-2 bg-black px-4 py-2 text-sm font-semibold text-white disabled:bg-[#76777D]" disabled={isLoading} type="button" onClick={() => void showLocationEquipment(location.id)}>
              <span className="material-symbols-outlined text-[18px]">inventory_2</span>
              Ekipmanları Listele
            </button>
          </section>
        </aside>
      </div>
    )
  }
}

function screenTitle(screen: EquipmentScreen) {
  const titles: Record<EquipmentScreen, string> = {
    list: 'Teknik Ekipman Envanteri',
    new: 'Yeni Ekipman Kaydı',
    detail: 'Ekipman Detay',
    locations: 'Lokasyon Yönetimi',
    locationDetail: 'Lokasyon Detay',
  }

  return titles[screen]
}

function AssetScreenButton({ active, disabled = false, label, onClick }: { active: boolean; disabled?: boolean; label: string; onClick: () => void }) {
  return <button className={`${active ? 'bg-black text-white' : 'border border-[#C6C6CD] bg-white text-[#1B1B1D]'} px-4 py-2 text-sm font-semibold disabled:border-[#E4E2E4] disabled:text-[#76777D]`} disabled={disabled} type="button" onClick={onClick}>{label}</button>
}

function AssetFieldLabel({ label, children }: { label: string; children: ReactNode }) {
  return <label className="block text-[11px] font-bold uppercase tracking-wide text-[#45464D]">{label}<div className="mt-1">{children}</div></label>
}

function AssetTableHeader({ children, alignRight = false }: { children: ReactNode; alignRight?: boolean }) {
  return <th className={`p-3 text-[11px] font-bold uppercase tracking-wide text-[#45464D] ${alignRight ? 'text-right' : ''}`}>{children}</th>
}

function AssetStatusBadge({ status }: { status: EquipmentStatus }) {
  return <span className={`inline-flex rounded px-2 py-0.5 text-[11px] font-bold ${statusBadgeClasses[status]}`}>{statusLabels[status]}</span>
}

function InfoCard({ children, icon, title }: { children: ReactNode; icon: string; title: string }) {
  return <section className="border border-[#C6C6CD] bg-white p-5 shadow-[0px_1px_3px_rgba(15,23,42,0.08)]"><div className="mb-3 flex items-center gap-2"><span className="material-symbols-outlined text-[#3755C3]">{icon}</span><h3 className="text-xl font-bold text-black">{title}</h3></div><div className="text-[13px] leading-5 text-[#45464D]">{children}</div></section>
}

function EmptyPanel({ text, title }: { text: string; title: string }) {
  return <section className="border border-[#C6C6CD] bg-white p-8 text-center text-[#45464D]"><h3 className="text-xl font-bold text-black">{title}</h3><p className="mt-2 text-sm">{text}</p></section>
}

function AssetSectionTitle({ padded = false, title }: { padded?: boolean; title: string }) {
  return <h4 className={`${padded ? 'border-b border-[#C6C6CD] p-4' : 'mb-4'} text-[12px] font-bold uppercase tracking-wide text-[#45464D]`}>{title}</h4>
}

function AssetSpecRow({ label, value }: { label: string; value: string }) {
  return <div className="flex justify-between border-b border-[#C6C6CD] py-2 text-sm"><span className="text-[#45464D]">{label}</span><span className="font-medium text-black">{value}</span></div>
}

function AssetMiniRow({ cols }: { cols: string[] }) {
  return <tr className="border-t border-[#C6C6CD]">{cols.map((col) => <td key={col} className="p-3 text-sm text-[#45464D]">{col}</td>)}</tr>
}

function LocationTreeRow({ active = false, critical = false, icon, name, onClick }: { active?: boolean; critical?: boolean; icon: string; name: string; onClick?: () => void }) {
  const className = `flex w-full items-center justify-between gap-2 px-3 py-2 text-left transition-colors ${active ? 'bg-[#F6F3F5] text-black' : critical ? 'text-[#BA1A1A]' : 'text-[#45464D]'} ${onClick ? 'hover:bg-[#FCF8FA] hover:text-black' : ''}`
  const content = <><span className="flex items-center gap-2"><span className="material-symbols-outlined text-[17px]">{icon}</span>{name}</span>{critical ? <span className="bg-[#FEE2E2] px-2 py-1 text-xs text-[#BA1A1A]">2 Arıza</span> : null}</>

  if (onClick) {
    return <button className={className} type="button" onClick={onClick}>{content}</button>
  }

  return <div className={className}>{content}</div>
}

export default EquipmentView
