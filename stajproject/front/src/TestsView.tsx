import { useEffect, useState, type ReactNode } from 'react'

type TestsViewProps = {
  apiBaseUrl: string
  token: string
}

type TestScreen = 'history' | 'new' | 'detail' | 'equipmentHistory'
type TestResult = 'Success' | 'Failed' | 'ConditionalSuccess' | 'RetestRequired'
type TestPlanStatus = 'Planned' | 'Completed' | 'Delayed' | 'Cancelled'
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

type TestPlanListItem = {
  id: string
  equipmentId: string
  equipmentCode: string
  equipmentName: string
  locationId: string
  locationName: string
  technicalSystemId: string
  technicalSystemName: string
  responsibleUserId: string
  responsibleUserName: string
  testType: string
  plannedDate: string
  frequency?: string | null
  status: Exclude<TestPlanStatus, 'Delayed'>
  displayStatus: TestPlanStatus
  description?: string | null
  createdAt: string
  updatedAt?: string | null
}

type TestRecordListItem = {
  id: string
  testPlanId?: string | null
  equipmentId: string
  equipmentCode: string
  equipmentName: string
  locationId: string
  locationName: string
  technicalSystemId: string
  technicalSystemName: string
  testedByUserId: string
  testedByUserName: string
  testedByUserTitle?: string | null
  testType: string
  testDate: string
  durationMinutes?: number | null
  result: TestResult
  abnormalCondition?: string | null
  description?: string | null
  createdAt: string
  updatedAt?: string | null
}

type TestRecordDetail = TestRecordListItem & {
  testedByUserDepartment?: string | null
  equipmentRecentRecords: TestRecordListItem[]
}

type TestFilters = {
  search: string
  locationId: string
  equipmentId: string
  result: string
  testDate: string
}

type TestFormState = {
  testPlanId: string
  equipmentId: string
  testedByUserId: string
  testDate: string
  testType: string
  durationMinutes: string
  result: TestResult
  abnormalCondition: string
  description: string
}

const testResults: TestResult[] = ['Success', 'Failed', 'ConditionalSuccess', 'RetestRequired']
const testTypeOptions = ['Haftalık Jeneratör Testi', 'UPS Yük Transfer Testi', 'HVAC Çalışma Testi', 'PLC I/O Testi', 'Acil Durum Senaryo Testi', 'Tek Seferlik Fonksiyon Testi']

const resultLabels: Record<TestResult, string> = {
  Success: 'Başarılı',
  Failed: 'Başarısız',
  ConditionalSuccess: 'Şartlı Başarılı',
  RetestRequired: 'Tekrar Test Gerekli',
}

const resultBadgeClasses: Record<TestResult, string> = {
  Success: 'bg-[#DCFCE7] text-[#16A34A]',
  Failed: 'bg-[#FEE2E2] text-[#BA1A1A]',
  ConditionalSuccess: 'bg-[#FEF08A] text-[#854D0E]',
  RetestRequired: 'bg-[#E0E7FF] text-[#3755C3]',
}

const defaultFilters: TestFilters = {
  search: '',
  locationId: '',
  equipmentId: '',
  result: '',
  testDate: '',
}

function TestsView({ apiBaseUrl, token }: TestsViewProps) {
  const [screen, setScreen] = useState<TestScreen>('history')
  const [locations, setLocations] = useState<LocationItem[]>([])
  const [equipment, setEquipment] = useState<EquipmentListItem[]>([])
  const [responsibleUsers, setResponsibleUsers] = useState<UserListItem[]>([])
  const [plans, setPlans] = useState<TestPlanListItem[]>([])
  const [records, setRecords] = useState<TestRecordListItem[]>([])
  const [selectedRecord, setSelectedRecord] = useState<TestRecordDetail | null>(null)
  const [equipmentHistoryId, setEquipmentHistoryId] = useState('')
  const [equipmentRecords, setEquipmentRecords] = useState<TestRecordListItem[]>([])
  const [filters, setFilters] = useState<TestFilters>(defaultFilters)
  const [form, setForm] = useState<TestFormState>(createEmptyForm())
  const [isLoading, setIsLoading] = useState(false)
  const [message, setMessage] = useState('Test yönetimi verileri yükleniyor...')

  const selectedEquipment = equipment.find((item) => item.id === form.equipmentId) ?? null
  const selectedPlan = plans.find((item) => item.id === form.testPlanId) ?? null
  const plannedTestOptions = plans.filter((plan) => plan.status === 'Planned')

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

        const [locationData, equipmentData, userData, planData, recordData] = await Promise.all([
          initialRequest<LocationItem[]>('/api/locations'),
          initialRequest<EquipmentListItem[]>('/api/equipment?isActive=true'),
          initialRequest<UserListItem[]>('/api/tests/responsible-users'),
          initialRequest<TestPlanListItem[]>('/api/tests/plans'),
          initialRequest<TestRecordListItem[]>('/api/tests/records'),
        ])

        if (ignore) {
          return
        }

        const firstPlannedTest = planData.find((plan) => plan.status === 'Planned')
        setLocations(locationData)
        setEquipment(equipmentData)
        setResponsibleUsers(userData)
        setPlans(planData)
        setRecords(recordData)
        setEquipmentHistoryId(equipmentData[0]?.id || '')
        setForm((current) => ({
          ...current,
          testPlanId: current.testPlanId || firstPlannedTest?.id || '',
          equipmentId: current.equipmentId || firstPlannedTest?.equipmentId || equipmentData[0]?.id || '',
          testedByUserId: current.testedByUserId || firstPlannedTest?.responsibleUserId || userData[0]?.id || '',
          testType: current.testType || firstPlannedTest?.testType || testTypeOptions[0],
        }))
        setMessage(`${recordData.length} test kaydı ve ${planData.length} test planı yüklendi.`)
      } catch (error) {
        if (!ignore) {
          setMessage(error instanceof Error ? error.message : 'Test yönetimi verileri yüklenemedi.')
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

  async function loadRecords(currentFilters: TestFilters = filters) {
    const params = new URLSearchParams()
    if (currentFilters.search) {
      params.set('search', currentFilters.search)
    }
    if (currentFilters.locationId) {
      params.set('locationId', currentFilters.locationId)
    }
    if (currentFilters.equipmentId) {
      params.set('equipmentId', currentFilters.equipmentId)
    }
    if (currentFilters.result) {
      params.set('result', currentFilters.result)
    }
    if (currentFilters.testDate) {
      params.set('testDate', currentFilters.testDate)
    }

    const path = params.size ? `/api/tests/records?${params.toString()}` : '/api/tests/records'
    const data = await apiRequest<TestRecordListItem[]>(path)
    setRecords(data)
    return data
  }

  async function loadPlans() {
    const data = await apiRequest<TestPlanListItem[]>('/api/tests/plans')
    setPlans(data)
    return data
  }

  async function handleApplyFilters() {
    setIsLoading(true)
    try {
      const data = await loadRecords(filters)
      setMessage(`${data.length} test kaydı filtre sonucunda listelendi.`)
    } catch (error) {
      setMessage(error instanceof Error ? error.message : 'Test kayıtları alınamadı.')
    } finally {
      setIsLoading(false)
    }
  }

  async function handleResetFilters() {
    setIsLoading(true)
    try {
      setFilters(defaultFilters)
      const data = await loadRecords(defaultFilters)
      setMessage(`Filtreler temizlendi. ${data.length} test kaydı listelendi.`)
    } catch (error) {
      setMessage(error instanceof Error ? error.message : 'Filtreler temizlenemedi.')
    } finally {
      setIsLoading(false)
    }
  }

  function startCreateRecord() {
    const firstPlannedTest = plans.find((plan) => plan.status === 'Planned')
    setForm({
      ...createEmptyForm(),
      testPlanId: firstPlannedTest?.id || '',
      equipmentId: firstPlannedTest?.equipmentId || equipment[0]?.id || '',
      testedByUserId: firstPlannedTest?.responsibleUserId || responsibleUsers[0]?.id || '',
      testType: firstPlannedTest?.testType || testTypeOptions[0],
    })
    setScreen('new')
    setMessage('Yeni test kaydı formu açıldı.')
  }

  function handlePlanSelection(planId: string) {
    const plan = plans.find((item) => item.id === planId)
    setForm((current) => ({
      ...current,
      testPlanId: planId,
      equipmentId: plan?.equipmentId || current.equipmentId,
      testedByUserId: plan?.responsibleUserId || current.testedByUserId,
      testType: plan?.testType || current.testType,
    }))
  }

  async function handleCreateRecord() {
    if (!form.equipmentId || !form.testedByUserId || !form.testDate || !form.testType) {
      setMessage('Ekipman, test tipi, test tarihi ve test eden kullanıcı zorunludur.')
      return
    }

    if ((form.result === 'Failed' || form.result === 'RetestRequired') && !form.abnormalCondition.trim() && !form.description.trim()) {
      setMessage('Başarısız veya tekrar test gerekli sonucunda anormal durum ya da açıklama zorunludur.')
      return
    }

    const durationMinutes = form.durationMinutes.trim() ? Number(form.durationMinutes) : null
    if (durationMinutes !== null && (!Number.isFinite(durationMinutes) || durationMinutes <= 0)) {
      setMessage('Test süresi 0 değerinden büyük olmalıdır.')
      return
    }

    setIsLoading(true)
    try {
      const detail = await apiRequest<TestRecordDetail>('/api/tests/records', {
        method: 'POST',
        body: JSON.stringify({
          testPlanId: form.testPlanId || null,
          equipmentId: form.equipmentId,
          testedByUserId: form.testedByUserId,
          testDate: new Date(form.testDate).toISOString(),
          testType: form.testType.trim(),
          durationMinutes,
          result: form.result,
          abnormalCondition: form.abnormalCondition.trim() || null,
          description: form.description.trim() || null,
        }),
      })
      await Promise.all([loadRecords(filters), loadPlans()])
      setSelectedRecord(detail)
      setScreen('detail')
      setMessage(`${detail.equipmentName} için ${resultLabels[detail.result]} test kaydı oluşturuldu.`)
    } catch (error) {
      setMessage(error instanceof Error ? error.message : 'Test kaydı oluşturulamadı.')
    } finally {
      setIsLoading(false)
    }
  }

  async function handleSelectRecord(id: string, showMessage = true) {
    setIsLoading(true)
    try {
      const detail = await apiRequest<TestRecordDetail>(`/api/tests/records/${id}`)
      setSelectedRecord(detail)
      setScreen('detail')
      if (showMessage) {
        setMessage(`${detail.equipmentName} test detayı açıldı.`)
      }
    } catch (error) {
      setMessage(error instanceof Error ? error.message : 'Test detayı alınamadı.')
    } finally {
      setIsLoading(false)
    }
  }

  async function openHistoryScreen() {
    setScreen('history')
    setIsLoading(true)
    try {
      const data = await loadRecords(filters)
      setMessage(`${data.length} test kaydı listeleniyor.`)
    } catch (error) {
      setMessage(error instanceof Error ? error.message : 'Test geçmişi alınamadı.')
    } finally {
      setIsLoading(false)
    }
  }

  async function openEquipmentHistory(equipmentId: string) {
    if (!equipmentId) {
      setMessage('Ekipman bazlı geçmiş için ekipman seçilmelidir.')
      return
    }

    setIsLoading(true)
    try {
      const data = await apiRequest<TestRecordListItem[]>(`/api/tests/equipment/${equipmentId}/records`)
      setEquipmentHistoryId(equipmentId)
      setEquipmentRecords(data)
      setScreen('equipmentHistory')
      setMessage(`${data.length} ekipman bazlı test kaydı listeleniyor.`)
    } catch (error) {
      setMessage(error instanceof Error ? error.message : 'Ekipman test geçmişi alınamadı.')
    } finally {
      setIsLoading(false)
    }
  }

  return (
    <section className="module-font mx-auto w-full max-w-[1600px] px-5 py-6 lg:px-6">
      <div className="mb-6 flex flex-col gap-4 md:flex-row md:items-end md:justify-between">
        <div>
          <h2 className="text-3xl font-bold tracking-tight text-black">{screenTitle(screen)}</h2>
          <p className="mt-2 text-[15px] leading-5 text-[#45464D]">Periyodik testleri kaydet, sonuçlarını izle ve ekipman bazlı test geçmişini takip et.</p>
        </div>
        <div className="flex flex-wrap gap-2">
          <TestScreenButton active={screen === 'history'} label="Test Geçmişi" onClick={() => void openHistoryScreen()} />
          <TestScreenButton active={screen === 'new'} label="Yeni Test Kaydı" onClick={startCreateRecord} />
          <TestScreenButton active={screen === 'detail'} disabled={!selectedRecord} label="Test Detay" onClick={() => setScreen('detail')} />
          <TestScreenButton active={screen === 'equipmentHistory'} label="Ekipman Geçmişi" onClick={() => void openEquipmentHistory(selectedRecord?.equipmentId || equipmentHistoryId || equipment[0]?.id || '')} />
        </div>
      </div>

      <div key={screen} className="screen-transition">
        {screen === 'history' ? renderHistoryScreen() : null}
        {screen === 'new' ? renderNewRecordScreen() : null}
        {screen === 'detail' ? renderDetailScreen() : null}
        {screen === 'equipmentHistory' ? renderEquipmentHistoryScreen() : null}
      </div>

      <div className="mt-4 border border-[#C6C6CD] bg-[#F6F3F5] p-3 text-[13px] text-[#45464D]">{message}</div>
    </section>
  )

  function renderHistoryScreen() {
    const successCount = records.filter((record) => record.result === 'Success').length
    const attentionCount = records.filter((record) => record.result === 'Failed' || record.result === 'RetestRequired').length
    const latestRecord = records[0]

    return (
      <>
        <div className="mb-6 grid gap-4 md:grid-cols-4">
          <TestMetricCard icon="fact_check" label="Toplam Test" value={String(records.length)} />
          <TestMetricCard icon="check_circle" label="Başarılı" tone="success" value={String(successCount)} />
          <TestMetricCard icon="warning" label="Dikkat Gereken" tone="danger" value={String(attentionCount)} />
          <TestMetricCard icon="event_available" label="Son Test" value={latestRecord ? formatDate(latestRecord.testDate) : '-'} />
        </div>

        <div className="mb-6 flex justify-end">
          <button className="flex items-center gap-2 bg-black px-5 py-3 text-sm font-bold text-white shadow-sm disabled:bg-[#76777D]" disabled={isLoading} type="button" onClick={startCreateRecord}>
            <span className="material-symbols-outlined text-[18px]">add</span>
            Yeni Test Kaydı
          </button>
        </div>

        <div className="mb-6 border border-[#C6C6CD] bg-white p-4 shadow-[0px_1px_3px_rgba(15,23,42,0.08)]">
          <div className="grid gap-4 md:grid-cols-5">
            <TestFieldLabel label="Arama">
              <input className="asset-input" placeholder="Ekipman, test tipi veya not ara..." value={filters.search} onChange={(event) => setFilters((current) => ({ ...current, search: event.target.value }))} />
            </TestFieldLabel>
            <TestFieldLabel label="Lokasyon">
              <select className="asset-input" value={filters.locationId} onChange={(event) => setFilters((current) => ({ ...current, locationId: event.target.value }))}>
                <option value="">Tüm Lokasyonlar</option>
                {locations.map((location) => <option key={location.id} value={location.id}>{location.name}</option>)}
              </select>
            </TestFieldLabel>
            <TestFieldLabel label="Ekipman">
              <select className="asset-input" value={filters.equipmentId} onChange={(event) => setFilters((current) => ({ ...current, equipmentId: event.target.value }))}>
                <option value="">Tüm Ekipmanlar</option>
                {equipment.map((item) => <option key={item.id} value={item.id}>{item.code} - {item.name}</option>)}
              </select>
            </TestFieldLabel>
            <TestFieldLabel label="Sonuç">
              <select className="asset-input" value={filters.result} onChange={(event) => setFilters((current) => ({ ...current, result: event.target.value }))}>
                <option value="">Tüm Sonuçlar</option>
                {testResults.map((result) => <option key={result} value={result}>{resultLabels[result]}</option>)}
              </select>
            </TestFieldLabel>
            <TestFieldLabel label="Test Tarihi">
              <input className="asset-input" type="date" value={filters.testDate} onChange={(event) => setFilters((current) => ({ ...current, testDate: event.target.value }))} />
            </TestFieldLabel>
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
                  <TestTableHeader>Test Tarihi</TestTableHeader>
                  <TestTableHeader>Ekipman</TestTableHeader>
                  <TestTableHeader>Lokasyon</TestTableHeader>
                  <TestTableHeader>Test Tipi</TestTableHeader>
                  <TestTableHeader>Süre</TestTableHeader>
                  <TestTableHeader>Test Eden</TestTableHeader>
                  <TestTableHeader>Sonuç</TestTableHeader>
                  <TestTableHeader alignRight>İşlem</TestTableHeader>
                </tr>
              </thead>
              <tbody className="text-[13px] text-[#1B1B1D]">
                {records.map((record, index) => (
                  <tr key={record.id} className={`border-b border-[#C6C6CD] transition-colors hover:bg-[#FCF8FA] ${index % 2 === 1 ? 'bg-[#FCF8FA]/50' : 'bg-white'}`}>
                    <td className="p-4"><button className="font-mono text-xs font-bold text-black hover:text-[#3755C3]" type="button" onClick={() => void handleSelectRecord(record.id)}>{formatDateTime(record.testDate)}</button></td>
                    <td className="p-4"><p className="font-semibold text-black">{record.equipmentName}</p><p className="font-mono text-xs text-[#76777D]">{record.equipmentCode}</p></td>
                    <td className="p-4 text-[#45464D]">{record.locationName}</td>
                    <td className="p-4"><span className="bg-[#E4E2E4] px-2 py-1 text-xs font-medium text-[#45464D]">{record.testType}</span></td>
                    <td className="p-4 font-mono text-xs text-[#45464D]">{formatDuration(record.durationMinutes)}</td>
                    <td className="p-4"><UserAvatar name={record.testedByUserName} /></td>
                    <td className="p-4"><TestResultBadge result={record.result} /></td>
                    <td className="p-4 text-right"><button className="p-1 text-[#45464D] transition-colors hover:text-black" type="button" onClick={() => void handleSelectRecord(record.id)}><span className="material-symbols-outlined text-[18px]">more_vert</span></button></td>
                  </tr>
                ))}
              </tbody>
            </table>
          </div>
          {records.length === 0 ? <div className="p-8 text-center text-sm text-[#45464D]">Filtreye uygun test kaydı bulunamadı.</div> : null}
          <div className="flex items-center justify-between border-t border-[#C6C6CD] bg-white p-3 text-[13px] text-[#45464D]"><span>Toplam {records.length} test kaydı gösteriliyor</span><span className="font-mono text-xs text-[#76777D]">API: /api/tests/records</span></div>
        </section>
      </>
    )
  }

  function renderNewRecordScreen() {
    const featuredEquipment = equipment.slice(0, 2)
    const needsAttentionNote = form.result !== 'Success'

    return (
      <section className="mx-auto max-w-[1180px] border border-[#C6C6CD] bg-white p-7 shadow-[0px_1px_3px_rgba(15,23,42,0.08)]">
        <div className="border-b border-[#C6C6CD] pb-8">
          <div className="flex flex-col gap-3 md:flex-row md:items-start md:justify-between">
            <div>
              <h3 className="text-xl font-bold text-black">Hedef Ekipman</h3>
              <p className="mt-2 text-sm text-[#45464D]">Testin uygulanacağı varlığı veya planlı testi seçin.</p>
            </div>
            <span className="inline-flex w-fit items-center gap-2 bg-[#F0EDEF] px-3 py-2 text-xs font-bold uppercase tracking-wide text-[#45464D]"><span className="material-symbols-outlined text-[16px]">verified</span>Kayıtlar geçmiş olarak saklanır</span>
          </div>

          <TestFieldLabel label="Planlı Test Seçimi">
            <select className="asset-input mt-4" value={form.testPlanId} onChange={(event) => handlePlanSelection(event.target.value)}>
              <option value="">Plansız / tek seferlik test</option>
              {plannedTestOptions.map((plan) => <option key={plan.id} value={plan.id}>{plan.testType} - {plan.equipmentName} - {formatDate(plan.plannedDate)}</option>)}
            </select>
          </TestFieldLabel>

          <div className="mt-5 grid gap-4 md:grid-cols-2">
            {featuredEquipment.map((item) => (
              <button key={item.id} className={`flex items-center gap-4 border p-5 text-left transition-colors ${form.equipmentId === item.id ? 'border-[#3755C3] bg-[#F0EDEF]' : 'border-[#C6C6CD] bg-white hover:border-[#3755C3]'}`} type="button" onClick={() => setForm((current) => ({ ...current, testPlanId: '', equipmentId: item.id }))}>
                <span className="material-symbols-outlined text-[#3755C3]">precision_manufacturing</span>
                <span><span className="block text-lg font-bold text-black">{item.name}</span><span className="mt-1 block font-mono text-sm text-[#45464D]">{item.code}</span></span>
              </button>
            ))}
          </div>
          <TestFieldLabel label="Diğer ekipmanları ara">
            <select className="asset-input mt-4" value={form.equipmentId} onChange={(event) => setForm((current) => ({ ...current, testPlanId: '', equipmentId: event.target.value }))}>
              <option value="">Ekipman seçin...</option>
              {equipment.map((item) => <option key={item.id} value={item.id}>{item.code} - {item.name}</option>)}
            </select>
          </TestFieldLabel>
        </div>

        <div className="grid gap-8 border-b border-[#C6C6CD] py-8 md:grid-cols-2">
          <TestFieldLabel label="Test Tipi">
            <select className="asset-input" value={form.testType} onChange={(event) => setForm((current) => ({ ...current, testType: event.target.value }))}>
              {testTypeOptions.map((type) => <option key={type} value={type}>{type}</option>)}
            </select>
          </TestFieldLabel>
          <TestFieldLabel label="Test Tarihi ve Saati">
            <input className="asset-input" type="datetime-local" value={form.testDate} onChange={(event) => setForm((current) => ({ ...current, testDate: event.target.value }))} />
          </TestFieldLabel>
          <TestFieldLabel label="Çalışma/Test Süresi (Dakika)">
            <input className="asset-input" min="1" type="number" value={form.durationMinutes} onChange={(event) => setForm((current) => ({ ...current, durationMinutes: event.target.value }))} />
          </TestFieldLabel>
          <TestFieldLabel label="Test Sonucu">
            <select className="asset-input" value={form.result} onChange={(event) => setForm((current) => ({ ...current, result: event.target.value as TestResult }))}>
              {testResults.map((result) => <option key={result} value={result}>{resultLabels[result]}</option>)}
            </select>
          </TestFieldLabel>
          <TestFieldLabel label="Test Eden Kullanıcı">
            <select className="asset-input" value={form.testedByUserId} onChange={(event) => setForm((current) => ({ ...current, testedByUserId: event.target.value }))}>
              <option value="">Kullanıcı seçin...</option>
              {responsibleUsers.map((user) => <option key={user.id} value={user.id}>{user.fullName} - {user.role}</option>)}
            </select>
          </TestFieldLabel>
          <div className="border border-[#C6C6CD] bg-[#FCF8FA] p-4 text-sm text-[#45464D]">
            <p className="text-[11px] font-bold uppercase tracking-wide text-[#1B1B1D]">Plan Özeti</p>
            <p className="mt-2">{selectedPlan ? `${selectedPlan.testType} testi ${formatDate(selectedPlan.plannedDate)} tarihinde planlandı.` : 'Plansız test kaydı oluşturulacak.'}</p>
            {selectedPlan ? <p className="mt-1 font-semibold text-black">Sorumlu: {selectedPlan.responsibleUserName}</p> : null}
          </div>
        </div>

        <div className="grid gap-6 py-8">
          {needsAttentionNote ? <div className="border border-[#F4C7C3] bg-[#FFF1F0] p-4 text-sm text-[#7F1D1D]">Başarısız, şartlı başarılı veya tekrar test gerekli sonuçlarda anormal durum ve açıklama alanlarını detaylı doldurun.</div> : null}
          <TestFieldLabel label="Anormal Durum">
            <textarea className={`min-h-24 w-full border bg-white p-3 text-sm outline-none focus:border-2 focus:border-[#3755C3] ${needsAttentionNote ? 'border-[#BA1A1A]' : 'border-[#C6C6CD]'}`} placeholder="Varsa gözlenen anormal durumları yazın..." value={form.abnormalCondition} onChange={(event) => setForm((current) => ({ ...current, abnormalCondition: event.target.value }))} />
          </TestFieldLabel>
          <TestFieldLabel label="Açıklama ve Notlar">
            <textarea className="min-h-32 w-full border border-[#C6C6CD] bg-white p-3 text-sm outline-none focus:border-2 focus:border-[#3755C3]" placeholder="Test gözlemleri, ölçülen değerler ve takip aksiyonlarını girin..." value={form.description} onChange={(event) => setForm((current) => ({ ...current, description: event.target.value }))} />
          </TestFieldLabel>
          {selectedEquipment ? (
            <div className="grid gap-4 border border-[#C6C6CD] bg-[#FCF8FA] p-4 md:grid-cols-3">
              <TestSpecCell label="Seçilen Ekipman" value={selectedEquipment.name} />
              <TestSpecCell label="Lokasyon" value={selectedEquipment.locationName} />
              <TestSpecCell label="Sistem" value={selectedEquipment.technicalSystemName} />
            </div>
          ) : null}
        </div>

        <div className="flex flex-wrap justify-end gap-4 border-t border-[#C6C6CD] pt-5">
          <button className="px-5 py-2 text-sm font-semibold text-[#45464D] hover:bg-[#E4E2E4]" type="button" onClick={() => setScreen('history')}>İptal</button>
          <button className="bg-black px-7 py-2 text-sm font-bold text-white disabled:bg-[#76777D]" disabled={isLoading} type="button" onClick={() => void handleCreateRecord()}>Test Kaydı Oluştur</button>
        </div>
      </section>
    )
  }

  function renderDetailScreen() {
    if (!selectedRecord) {
      return <TestEmptyPanel title="Test Detay" text="Listeden bir test kaydı seçildiğinde detay ekranı burada açılır." />
    }

    return (
      <>
        <div className="mb-6 flex flex-col gap-4 md:flex-row md:items-start md:justify-between">
          <div>
            <p className="text-sm text-[#45464D]">Testler <span className="mx-2">›</span> Test Geçmişi <span className="mx-2">›</span> <strong className="text-black">{selectedRecord.equipmentCode}</strong></p>
            <h3 className="mt-2 text-3xl font-bold tracking-tight text-black">{selectedRecord.testType}</h3>
          </div>
          <div className="flex flex-wrap gap-2">
            <button className="border border-[#C6C6CD] bg-white px-5 py-2 font-semibold text-[#45464D]" type="button" onClick={() => setScreen('history')}>Geri Dön</button>
            <button className="bg-black px-5 py-2 font-semibold text-white" type="button" onClick={startCreateRecord}>Yeni Test Kaydı</button>
          </div>
        </div>

        <div className="grid gap-6 xl:grid-cols-[1fr_420px]">
          <div className="space-y-6">
            <section className="border border-[#C6C6CD] bg-white p-5 shadow-[0px_1px_3px_rgba(15,23,42,0.08)]">
              <h4 className="mb-4 flex items-center gap-2 border-b border-[#C6C6CD] pb-3 text-xl font-bold text-black"><span className="material-symbols-outlined text-[#45464D]">inventory_2</span>Ekipman Bilgileri</h4>
              <div className="grid gap-4 md:grid-cols-4">
                <TestSpecCell mono label="Ekipman Kodu" value={selectedRecord.equipmentCode} />
                <TestSpecCell label="Ekipman" value={selectedRecord.equipmentName} />
                <TestSpecCell label="Sistem" value={selectedRecord.technicalSystemName} />
                <TestSpecCell label="Lokasyon" value={selectedRecord.locationName} />
              </div>
            </section>

            <section className="border border-[#C6C6CD] bg-white p-5 shadow-[0px_1px_3px_rgba(15,23,42,0.08)]">
              <h4 className="mb-4 flex items-center gap-2 border-b border-[#C6C6CD] pb-3 text-xl font-bold text-black"><span className="material-symbols-outlined text-[#45464D]">science</span>Test Bilgileri</h4>
              <div className="grid gap-4 md:grid-cols-4">
                <TestSpecCell label="Test Tarihi" value={formatDateTime(selectedRecord.testDate)} />
                <TestSpecCell label="Test Süresi" value={formatDuration(selectedRecord.durationMinutes)} />
                <TestSpecCell label="Test Eden" value={selectedRecord.testedByUserName} />
                <div><p className="text-[11px] font-bold uppercase tracking-wide text-[#45464D]">Sonuç</p><div className="mt-2"><TestResultBadge result={selectedRecord.result} /></div></div>
              </div>
              <div className="mt-6 grid gap-4 md:grid-cols-2">
                <TestNotePanel title="Anormal Durum" text={selectedRecord.abnormalCondition || 'Anormal durum kaydedilmedi.'} tone={selectedRecord.abnormalCondition ? 'danger' : 'normal'} />
                <TestNotePanel title="Açıklama" text={selectedRecord.description || 'Açıklama kaydedilmedi.'} />
              </div>
            </section>
          </div>

          <aside className="space-y-5">
            <section className="border border-[#C6C6CD] bg-white p-5 shadow-[0px_1px_3px_rgba(15,23,42,0.08)]">
              <h4 className="mb-4 flex items-center gap-2 border-b border-[#C6C6CD] pb-3 text-xl font-bold text-black"><span className="material-symbols-outlined text-[#45464D]">verified</span>Sonuç Durumu</h4>
              <div className="flex items-center justify-between border border-[#C6C6CD] bg-[#FCF8FA] p-4">
                <div><p className="text-[11px] font-bold uppercase tracking-wide text-[#45464D]">Değerlendirme</p><p className="mt-2 text-lg font-bold text-black">{resultLabels[selectedRecord.result]}</p></div>
                <span className="material-symbols-outlined text-3xl text-[#3755C3]">biotech</span>
              </div>
              <button className="mt-4 flex w-full items-center justify-center gap-2 bg-black px-4 py-2 text-sm font-semibold text-white" type="button" onClick={() => void openEquipmentHistory(selectedRecord.equipmentId)}><span className="material-symbols-outlined text-[18px]">history</span>Ekipman Test Geçmişi</button>
            </section>

            <section className="border border-[#C6C6CD] bg-white p-5 shadow-[0px_1px_3px_rgba(15,23,42,0.08)]">
              <h4 className="mb-4 flex items-center gap-2 border-b border-[#C6C6CD] pb-3 text-xl font-bold text-black"><span className="material-symbols-outlined text-[#45464D]">history</span>Aynı Ekipmanın Son Testleri</h4>
              <div className="space-y-3">
                {selectedRecord.equipmentRecentRecords.map((record) => (
                  <button key={record.id} className="block w-full border border-[#C6C6CD] bg-[#FCF8FA] p-3 text-left text-sm hover:border-[#3755C3]" type="button" onClick={() => void handleSelectRecord(record.id, false)}>
                    <span className="block font-semibold text-black">{record.testType}</span>
                    <span className="mt-1 block font-mono text-xs text-[#45464D]">{formatDateTime(record.testDate)} - {resultLabels[record.result]}</span>
                  </button>
                ))}
                {selectedRecord.equipmentRecentRecords.length === 0 ? <p className="text-sm text-[#45464D]">Bu ekipman için başka test kaydı bulunmuyor.</p> : null}
              </div>
            </section>
          </aside>
        </div>
      </>
    )
  }

  function renderEquipmentHistoryScreen() {
    const historyEquipment = equipmentRecords[0] ?? records.find((record) => record.equipmentId === equipmentHistoryId)
    const successCount = equipmentRecords.filter((record) => record.result === 'Success').length
    const attentionCount = equipmentRecords.filter((record) => record.result === 'Failed' || record.result === 'RetestRequired').length
    const lastRecord = equipmentRecords[0]

    return (
      <section className="space-y-6">
        <div className="flex flex-col gap-4 border border-[#C6C6CD] bg-white p-5 shadow-[0px_1px_3px_rgba(15,23,42,0.08)] md:flex-row md:items-end md:justify-between">
          <div>
            <p className="text-[11px] font-bold uppercase tracking-wide text-[#45464D]">Ekipman Bazlı Test Geçmişi</p>
            <h3 className="mt-1 text-2xl font-bold text-black">{historyEquipment?.equipmentName ?? 'Ekipman seçilmedi'}</h3>
            <p className="mt-2 font-mono text-sm text-[#45464D]">{historyEquipment?.equipmentCode ?? '-'}</p>
          </div>
          <TestFieldLabel label="Ekipman Seç">
            <select className="asset-input min-w-72" value={equipmentHistoryId} onChange={(event) => void openEquipmentHistory(event.target.value)}>
              <option value="">Ekipman seçin...</option>
              {equipment.map((item) => <option key={item.id} value={item.id}>{item.code} - {item.name}</option>)}
            </select>
          </TestFieldLabel>
        </div>

        <div className="grid gap-4 md:grid-cols-4">
          <TestMetricCard icon="event_available" label="Son Test" value={lastRecord ? formatDate(lastRecord.testDate) : '-'} />
          <TestMetricCard icon="check_circle" label="Başarılı" tone="success" value={String(successCount)} />
          <TestMetricCard icon="warning" label="Başarısız / Tekrar" tone="danger" value={String(attentionCount)} />
          <TestMetricCard icon="biotech" label="Toplam Kayıt" value={String(equipmentRecords.length)} />
        </div>

        <section className="overflow-hidden border border-[#C6C6CD] bg-white shadow-[0px_1px_3px_rgba(15,23,42,0.08)]">
          <div className="overflow-x-auto">
            <table className="w-full border-collapse text-left">
              <thead><tr className="border-b border-[#C6C6CD] bg-[#FCF8FA]"><TestTableHeader>Test Tarihi</TestTableHeader><TestTableHeader>Test Tipi</TestTableHeader><TestTableHeader>Süre</TestTableHeader><TestTableHeader>Test Eden</TestTableHeader><TestTableHeader>Sonuç</TestTableHeader><TestTableHeader>Anormal Durum</TestTableHeader><TestTableHeader alignRight>İşlem</TestTableHeader></tr></thead>
              <tbody className="text-[13px]">
                {equipmentRecords.map((record, index) => (
                  <tr key={record.id} className={`border-b border-[#C6C6CD] hover:bg-[#FCF8FA] ${index % 2 === 1 ? 'bg-[#FCF8FA]/50' : 'bg-white'}`}>
                    <td className="p-4 font-mono text-xs font-bold text-black">{formatDateTime(record.testDate)}</td>
                    <td className="p-4">{record.testType}</td>
                    <td className="p-4 font-mono text-xs text-[#45464D]">{formatDuration(record.durationMinutes)}</td>
                    <td className="p-4">{record.testedByUserName}</td>
                    <td className="p-4"><TestResultBadge result={record.result} /></td>
                    <td className="max-w-[280px] p-4 text-[#45464D]">{record.abnormalCondition || '-'}</td>
                    <td className="p-4 text-right"><button className="text-sm font-semibold text-[#3755C3]" type="button" onClick={() => void handleSelectRecord(record.id)}>Detay</button></td>
                  </tr>
                ))}
              </tbody>
            </table>
          </div>
          {equipmentRecords.length === 0 ? <div className="p-8 text-center text-sm text-[#45464D]">Bu ekipman için test kaydı bulunamadı.</div> : null}
        </section>
      </section>
    )
  }
}

function createEmptyForm(): TestFormState {
  return {
    testPlanId: '',
    equipmentId: '',
    testedByUserId: '',
    testDate: toDateTimeLocalInput(new Date().toISOString()),
    testType: testTypeOptions[0],
    durationMinutes: '30',
    result: 'Success',
    abnormalCondition: '',
    description: '',
  }
}

function screenTitle(screen: TestScreen) {
  const titles: Record<TestScreen, string> = {
    history: 'Test Geçmişi',
    new: 'Yeni Test Kaydı',
    detail: 'Test Detay',
    equipmentHistory: 'Ekipman Test Geçmişi',
  }

  return titles[screen]
}

function TestScreenButton({ active, disabled = false, label, onClick }: { active: boolean; disabled?: boolean; label: string; onClick: () => void }) {
  return <button className={`${active ? 'bg-black text-white' : 'border border-[#C6C6CD] bg-white text-[#1B1B1D]'} px-4 py-2 text-sm font-semibold disabled:border-[#E4E2E4] disabled:text-[#76777D]`} disabled={disabled} type="button" onClick={onClick}>{label}</button>
}

function TestFieldLabel({ label, children }: { label: string; children: ReactNode }) {
  return <label className="block text-[11px] font-bold uppercase tracking-wide text-[#45464D]">{label}<div className="mt-1">{children}</div></label>
}

function TestTableHeader({ children, alignRight = false }: { children: ReactNode; alignRight?: boolean }) {
  return <th className={`p-4 text-[11px] font-bold uppercase tracking-wide text-[#45464D] ${alignRight ? 'text-right' : ''}`}>{children}</th>
}

function TestResultBadge({ result }: { result: TestResult }) {
  return <span className={`inline-flex px-2 py-1 text-xs font-bold ${resultBadgeClasses[result]}`}>{resultLabels[result]}</span>
}

function TestSpecCell({ label, mono = false, value }: { label: string; mono?: boolean; value: string }) {
  return <div><p className="text-[11px] font-bold uppercase tracking-wide text-[#45464D]">{label}</p><p className={`mt-2 inline-flex px-2 py-1 text-sm font-semibold ${mono ? 'font-mono' : ''} bg-[#F0EDEF] text-black`}>{value}</p></div>
}

function TestMetricCard({ icon, label, tone = 'normal', value }: { icon: string; label: string; tone?: 'normal' | 'success' | 'danger'; value: string }) {
  const toneClass = tone === 'success' ? 'text-[#16A34A]' : tone === 'danger' ? 'text-[#BA1A1A]' : 'text-[#3755C3]'
  return <section className="border border-[#C6C6CD] bg-white p-4 shadow-[0px_1px_3px_rgba(15,23,42,0.08)]"><div className="flex items-center justify-between"><p className="text-[11px] font-bold uppercase tracking-wide text-[#45464D]">{label}</p><span className={`material-symbols-outlined text-[22px] ${toneClass}`}>{icon}</span></div><p className="mt-3 text-2xl font-bold text-black">{value}</p></section>
}

function TestNotePanel({ text, title, tone = 'normal' }: { text: string; title: string; tone?: 'normal' | 'danger' }) {
  return <div className={`border p-4 ${tone === 'danger' ? 'border-[#F4C7C3] bg-[#FFF1F0]' : 'border-[#C6C6CD] bg-[#FCF8FA]'}`}><p className="text-[11px] font-bold uppercase tracking-wide text-[#45464D]">{title}</p><p className="mt-2 text-sm leading-6 text-[#1B1B1D]">{text}</p></div>
}

function TestEmptyPanel({ text, title }: { text: string; title: string }) {
  return <section className="border border-[#C6C6CD] bg-white p-8 text-center text-[#45464D]"><h3 className="text-xl font-bold text-black">{title}</h3><p className="mt-2 text-sm">{text}</p></section>
}

function UserAvatar({ name }: { name: string }) {
  return <div className="flex items-center gap-2"><span className="flex h-7 w-7 items-center justify-center rounded-full bg-[#E0E7FF] text-xs font-bold text-[#3755C3]">{getInitials(name)}</span><span>{name}</span></div>
}

function getInitials(name: string) {
  return name.split(' ').filter(Boolean).slice(0, 2).map((part) => part[0]?.toUpperCase()).join('') || 'TS'
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

function formatDuration(value?: number | null) {
  return value ? `${value} dk` : '-'
}

export default TestsView
