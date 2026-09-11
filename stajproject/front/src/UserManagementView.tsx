import { useEffect, useState, type ReactNode } from 'react'
import ExecutiveReportDownload from './ExecutiveReportDownload'
import { requestJson } from './apiClient'
import { StatusMessage } from './UiState'

type UserManagementViewProps = {
  apiBaseUrl: string
  token: string
}

type RoleItem = {
  id: string
  name: string
  description?: string | null
  isSystemRole: boolean
}

type UserItem = {
  id: string
  roleId: string
  fullName: string
  username: string
  email: string
  role: string
  title?: string | null
  department?: string | null
  isActive: boolean
  lastLoginAt?: string | null
}

type UserFormState = {
  roleId: string
  fullName: string
  username: string
  email: string
  password: string
  title: string
  department: string
}

type UserSubView = 'list' | 'tasks'

type WorkloadSummary = {
  openFaultCount: number
  openMaintenanceCount: number
  openTestCount: number
  shiftHandoverCount: number
  faultActionCount: number
  completedWorkCount: number
}

type FaultTask = {
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

type MaintenanceTask = {
  id: string
  planNo: string
  equipmentCode: string
  equipmentName: string
  maintenanceType: string
  priority: string
  status: string
  plannedDate: string
}

type TestTask = {
  id: string
  equipmentCode: string
  equipmentName: string
  testType: string
  status: string
  plannedDate: string
}

type ShiftTask = {
  id: string
  handoverNo: string
  shiftType: string
  shiftDate: string
  direction: string
  summary?: string | null
  createdAt: string
}

type FaultAction = {
  id: string
  faultNo: string
  actionType: string
  oldStatus?: string | null
  newStatus?: string | null
  note?: string | null
  createdAt: string
}

type CompletedWork = {
  id: string
  workType: string
  referenceNo: string
  title: string
  result?: string | null
  completedAt: string
}

type UserWorkload = {
  user: UserItem
  summary: WorkloadSummary
  openFaults: FaultTask[]
  openMaintenancePlans: MaintenanceTask[]
  openTestPlans: TestTask[]
  shiftHandovers: ShiftTask[]
  faultActions: FaultAction[]
  completedWorks: CompletedWork[]
  generatedAt: string
}

const emptyForm: UserFormState = {
  roleId: '',
  fullName: '',
  username: '',
  email: '',
  password: 'Demo123!',
  title: '',
  department: '',
}

const statusLabels: Record<string, string> = {
  New: 'Yeni',
  Assigned: 'Atandı',
  InReview: 'İnceleniyor',
  InProgress: 'Müdahale Ediliyor',
  Waiting: 'Beklemede',
  Resolved: 'Çözüldü',
  Closed: 'Kapatıldı',
  Planned: 'Planlandı',
  Started: 'Başladı',
  Completed: 'Tamamlandı',
  Delayed: 'Gecikti',
  Cancelled: 'İptal',
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

function UserManagementView({ apiBaseUrl, token }: UserManagementViewProps) {
  const [users, setUsers] = useState<UserItem[]>([])
  const [roles, setRoles] = useState<RoleItem[]>([])
  const [selectedUserId, setSelectedUserId] = useState('')
  const [workload, setWorkload] = useState<UserWorkload | null>(null)
  const [form, setForm] = useState<UserFormState>(emptyForm)
  const [activeSubView, setActiveSubView] = useState<UserSubView>('list')
  const [roleFilter, setRoleFilter] = useState('')
  const [statusFilter, setStatusFilter] = useState('active')
  const [isLoading, setIsLoading] = useState(false)
  const [message, setMessage] = useState('Kullanıcı yönetimi verileri yükleniyor...')

  const filteredUsers = users.filter((user) => (!roleFilter || user.role === roleFilter) && (statusFilter === 'all' || (statusFilter === 'active' ? user.isActive : !user.isActive)))
  const selectedUser = users.find((user) => user.id === selectedUserId) ?? null
  const selectedTaskCount = workload
    ? workload.summary.openFaultCount + workload.summary.openMaintenanceCount + workload.summary.openTestCount + workload.summary.shiftHandoverCount
    : 0

  useEffect(() => {
    let ignore = false

    async function loadInitial() {
      setIsLoading(true)
      try {
        const [userData, roleData] = await Promise.all([
          adminRequest<UserItem[]>(apiBaseUrl, token, '/api/admin/users'),
          adminRequest<RoleItem[]>(apiBaseUrl, token, '/api/admin/roles'),
        ])

        if (ignore) {
          return
        }

        setUsers(userData)
        setRoles(roleData)
        setForm((current) => ({ ...current, roleId: current.roleId || roleData[0]?.id || '' }))

        const firstUserId = userData[0]?.id || ''
        setSelectedUserId(firstUserId)
        if (firstUserId) {
          const detail = await adminRequest<UserWorkload>(apiBaseUrl, token, `/api/admin/users/${firstUserId}/workload`)
          if (!ignore) {
            setWorkload(detail)
          }
        }

        if (!ignore) {
          setMessage(`${userData.length} kullanıcı listelendi.`)
        }
      } catch (error) {
        if (!ignore) {
          setMessage(error instanceof Error ? error.message : 'Kullanıcı yönetimi verileri alınamadı.')
        }
      } finally {
        if (!ignore) {
          setIsLoading(false)
        }
      }
    }

    void loadInitial()

    return () => {
      ignore = true
    }
  }, [apiBaseUrl, token])

  async function loadUsers(keepSelectedId = selectedUserId) {
    const userData = await adminRequest<UserItem[]>(apiBaseUrl, token, '/api/admin/users')
    setUsers(userData)
    const nextSelectedId = keepSelectedId && userData.some((user) => user.id === keepSelectedId) ? keepSelectedId : userData[0]?.id || ''
    setSelectedUserId(nextSelectedId)
    if (nextSelectedId) {
      await loadWorkload(nextSelectedId)
    } else {
      setWorkload(null)
    }
    return userData
  }

  async function loadWorkload(userId: string) {
    const detail = await adminRequest<UserWorkload>(apiBaseUrl, token, `/api/admin/users/${userId}/workload`)
    setWorkload(detail)
    return detail
  }

  async function handleSelectUser(userId: string, showTasks = false) {
    setSelectedUserId(userId)
    if (showTasks) {
      setActiveSubView('tasks')
    }
    setIsLoading(true)
    try {
      const detail = await loadWorkload(userId)
      setMessage(`${detail.user.fullName} kullanıcı görev detayları yüklendi.`)
    } catch (error) {
      setMessage(error instanceof Error ? error.message : 'Kullanıcı detayları alınamadı.')
    } finally {
      setIsLoading(false)
    }
  }

  async function handleCreateUser() {
    if (!form.roleId || !form.fullName.trim() || !form.username.trim() || !form.email.trim() || !form.password.trim()) {
      setMessage('Rol, ad soyad, kullanıcı adı, e-posta ve şifre zorunludur.')
      return
    }

    setIsLoading(true)
    try {
      const created = await adminRequest<UserItem>(apiBaseUrl, token, '/api/admin/users', {
        method: 'POST',
        body: JSON.stringify({
          roleId: form.roleId,
          fullName: form.fullName.trim(),
          username: form.username.trim(),
          email: form.email.trim(),
          password: form.password,
          title: form.title.trim() || null,
          department: form.department.trim() || null,
        }),
      })

      setForm({ ...emptyForm, roleId: form.roleId })
      await loadUsers(created.id)
      setMessage(`${created.fullName} kullanıcısı oluşturuldu.`)
    } catch (error) {
      setMessage(error instanceof Error ? error.message : 'Kullanıcı oluşturulamadı.')
    } finally {
      setIsLoading(false)
    }
  }

  async function handleToggleStatus(user: UserItem) {
    setIsLoading(true)
    try {
      const updated = await adminRequest<UserItem>(apiBaseUrl, token, `/api/admin/users/${user.id}/status`, {
        method: 'PATCH',
        body: JSON.stringify({ isActive: !user.isActive }),
      })
      await loadUsers(updated.id)
      setMessage(`${updated.fullName} durumu ${updated.isActive ? 'aktif' : 'pasif'} yapıldı.`)
    } catch (error) {
      setMessage(error instanceof Error ? error.message : 'Kullanıcı durumu güncellenemedi.')
    } finally {
      setIsLoading(false)
    }
  }

  async function handleRefresh() {
    setIsLoading(true)
    try {
      const data = await loadUsers()
      setMessage(`Veriler yenilendi. ${data.length} kullanıcı listelendi.`)
    } catch (error) {
      setMessage(error instanceof Error ? error.message : 'Kullanıcı listesi yenilenemedi.')
    } finally {
      setIsLoading(false)
    }
  }

  return (
    <section className="module-font mx-auto w-full max-w-[1600px] bg-[#FCF8FA] px-5 py-6 lg:px-6">
      <div className="mb-6 flex flex-col gap-4 md:flex-row md:items-end md:justify-between">
        <div>
          <p className="text-[11px] font-bold uppercase tracking-[0.18em] text-[#45464D]">Admin Yönetimi</p>
          <h2 className="mt-1 text-3xl font-bold tracking-tight text-black">Kullanıcı Yönetimi</h2>
          <div className="mt-3"><StatusMessage busy={isLoading} message={message} /></div>
        </div>
        <div className="flex flex-wrap gap-2">
          <ExecutiveReportDownload apiBaseUrl={apiBaseUrl} disabled={isLoading} fileBaseName="kullanici-yonetici-raporu" label="Kullanıcı Raporu" path="/api/exports/users" token={token} onMessage={setMessage} />
          <button className="border border-[#3755C3] px-4 py-2 text-sm font-semibold text-[#3755C3] transition-colors hover:bg-[#DDE1FF] disabled:opacity-60" disabled={isLoading} type="button" onClick={handleRefresh}>Yenile</button>
        </div>
      </div>

      <div className="mb-5 flex flex-wrap gap-2 rounded-lg border border-[#C6C6CD] bg-white p-1 shadow-[0px_1px_3px_rgba(15,23,42,0.08)]">
        <SubViewTab active={activeSubView === 'list'} label="Liste" meta={`${filteredUsers.length} kullanıcı`} onClick={() => setActiveSubView('list')} />
        <SubViewTab active={activeSubView === 'tasks'} label="Görevlerim" meta={selectedUser ? `${selectedTaskCount} açık iş` : 'Kullanıcı seçin'} onClick={() => setActiveSubView('tasks')} />
      </div>

      <div className="grid gap-6 xl:grid-cols-[minmax(0,1fr)_420px]">
        <div className="space-y-6">
          {activeSubView === 'list' ? (
            <section className="rounded-lg border border-[#C6C6CD] bg-white p-4 shadow-[0px_1px_3px_rgba(15,23,42,0.08)]">
              <div className="mb-4 flex flex-col gap-3 md:flex-row md:items-center md:justify-between">
                <div>
                  <h3 className="text-xl font-bold text-black">Kullanıcı Listesi</h3>
                  <p className="mt-1 text-sm text-[#45464D]">Rol ve aktiflik durumuna göre sistem kullanıcıları.</p>
                </div>
                <div className="flex flex-wrap gap-2">
                  <select className="report-input w-auto min-w-44" value={roleFilter} onChange={(event) => setRoleFilter(event.target.value)}>
                    <option value="">Tüm Roller</option>
                    {roles.map((role) => <option key={role.id} value={role.name}>{role.name}</option>)}
                  </select>
                  <select className="report-input w-auto min-w-36" value={statusFilter} onChange={(event) => setStatusFilter(event.target.value)}>
                    <option value="all">Tümü</option>
                    <option value="active">Aktif</option>
                    <option value="passive">Pasif</option>
                  </select>
                </div>
              </div>
              <div className="overflow-x-auto">
                <table className="w-full border-collapse text-left text-sm">
                  <thead className="report-table-head">
                    <tr>
                      <th className="p-3">Kullanıcı</th>
                      <th className="p-3">Rol</th>
                      <th className="p-3">Departman</th>
                      <th className="p-3">Durum</th>
                      <th className="p-3">Son Giriş</th>
                      <th className="p-3 text-right">İşlem</th>
                    </tr>
                  </thead>
                  <tbody>
                    {filteredUsers.map((user) => (
                      <tr className={`${selectedUserId === user.id ? 'bg-[#DDE1FF]/40' : 'bg-white'} border-b border-[#C6C6CD]`} key={user.id}>
                        <td className="p-3"><button className="text-left" type="button" onClick={() => handleSelectUser(user.id)}><span className="block font-bold text-black">{user.fullName}</span><span className="font-mono text-xs text-[#76777D]">{user.username} • {user.email}</span></button></td>
                        <td className="p-3 text-[#45464D]">{user.role}</td>
                        <td className="p-3 text-[#45464D]">{user.department ?? '-'}</td>
                        <td className="p-3"><StatusBadge active={user.isActive} /></td>
                        <td className="p-3 font-mono text-xs text-[#45464D]">{formatDateTime(user.lastLoginAt)}</td>
                        <td className="p-3 text-right"><div className="flex justify-end gap-2"><button className="border border-[#C6C6CD] px-3 py-1.5 text-xs font-semibold text-[#1B1B1D] hover:bg-[#F6F3F5]" type="button" onClick={() => handleSelectUser(user.id, true)}>Detay</button><button className="border border-[#C6C6CD] px-3 py-1.5 text-xs font-semibold text-[#45464D] hover:bg-[#F6F3F5]" disabled={isLoading} type="button" onClick={() => handleToggleStatus(user)}>{user.isActive ? 'Pasifleştir' : 'Aktifleştir'}</button></div></td>
                      </tr>
                    ))}
                  </tbody>
                </table>
              </div>
              {filteredUsers.length === 0 ? <EmptyPanel text={isLoading ? 'Kullanıcılar yükleniyor...' : 'Bu filtrelerle kullanıcı bulunamadı.'} /> : null}
            </section>
          ) : workload ? <UserDetailPanel workload={workload} /> : <EmptyPanel text="Kullanıcı detayını görmek için listeden kullanıcı seçin." />}
        </div>

        <aside className="space-y-6">
          {selectedUser ? (
            <section className="rounded-lg border border-[#C6C6CD] bg-[#F0EDEF] p-5">
              <h3 className="text-lg font-bold text-black">Seçili Kullanıcı</h3>
              <p className="mt-3 text-xl font-bold text-black">{selectedUser.fullName}</p>
              <p className="font-mono text-xs text-[#45464D]">{selectedUser.username}</p>
              <div className="mt-4 grid gap-2 text-sm text-[#45464D]"><p><strong className="text-black">Rol:</strong> {selectedUser.role}</p><p><strong className="text-black">E-posta:</strong> {selectedUser.email}</p><p><strong className="text-black">Unvan:</strong> {selectedUser.title ?? '-'}</p><p><strong className="text-black">Departman:</strong> {selectedUser.department ?? '-'}</p></div>
            </section>
          ) : null}

          <section className="rounded-lg border border-[#C6C6CD] bg-white p-5 shadow-[0px_1px_3px_rgba(15,23,42,0.08)]">
            <h3 className="text-xl font-bold text-black">Yeni Kullanıcı Oluştur</h3>
            <p className="mt-1 text-sm text-[#45464D]">Bu form yalnızca Admin rolüne açıktır.</p>
            <div className="mt-5 grid gap-4">
              <Field label="Rol"><select className="report-input" value={form.roleId} onChange={(event) => setForm((current) => ({ ...current, roleId: event.target.value }))}><option value="">Rol Seçiniz</option>{roles.map((role) => <option key={role.id} value={role.id}>{role.name}</option>)}</select></Field>
              <Field label="Ad Soyad"><input className="report-input" value={form.fullName} onChange={(event) => setForm((current) => ({ ...current, fullName: event.target.value }))} /></Field>
              <Field label="Kullanıcı Adı"><input className="report-input" value={form.username} onChange={(event) => setForm((current) => ({ ...current, username: event.target.value }))} /></Field>
              <Field label="E-posta"><input className="report-input" type="email" value={form.email} onChange={(event) => setForm((current) => ({ ...current, email: event.target.value }))} /></Field>
              <Field label="Şifre"><input className="report-input" type="password" value={form.password} onChange={(event) => setForm((current) => ({ ...current, password: event.target.value }))} /></Field>
              <Field label="Unvan"><input className="report-input" value={form.title} onChange={(event) => setForm((current) => ({ ...current, title: event.target.value }))} /></Field>
              <Field label="Departman"><input className="report-input" value={form.department} onChange={(event) => setForm((current) => ({ ...current, department: event.target.value }))} /></Field>
            </div>
            <button className="mt-5 w-full bg-black px-4 py-2 text-sm font-semibold text-white disabled:bg-[#76777D]" disabled={isLoading} type="button" onClick={handleCreateUser}>Kullanıcı Oluştur</button>
          </section>
        </aside>
      </div>
    </section>
  )
}

function SubViewTab({ active, label, meta, onClick }: { active: boolean; label: string; meta: string; onClick: () => void }) {
  return <button className={`${active ? 'bg-black text-white' : 'bg-[#FCF8FA] text-[#45464D] hover:bg-[#F0EDEF]'} flex min-w-48 flex-1 items-center justify-between gap-3 rounded-md px-4 py-3 text-left transition-colors md:flex-none`} type="button" onClick={onClick}><span className="font-bold">{label}</span><span className={`${active ? 'text-[#DDE1FF]' : 'text-[#76777D]'} text-xs font-semibold`}>{meta}</span></button>
}

function UserDetailPanel({ workload }: { workload: UserWorkload }) {
  return (
    <section className="rounded-lg border border-[#C6C6CD] bg-white p-5 shadow-[0px_1px_3px_rgba(15,23,42,0.08)]">
      <div className="mb-5 flex flex-col gap-3 md:flex-row md:items-start md:justify-between">
        <div>
          <h3 className="text-2xl font-bold text-black">{workload.user.fullName} Görev Detayı</h3>
          <p className="mt-1 text-sm text-[#45464D]">Açık görevler, yaptığı işlemler ve tamamladığı işler.</p>
        </div>
        <span className="font-mono text-xs text-[#76777D]">{formatDateTime(workload.generatedAt)}</span>
      </div>
      <div className="mb-6 grid gap-3 md:grid-cols-3 xl:grid-cols-6">
        <Metric label="Açık Arıza" value={workload.summary.openFaultCount} />
        <Metric label="Açık Bakım" value={workload.summary.openMaintenanceCount} />
        <Metric label="Açık Test" value={workload.summary.openTestCount} />
        <Metric label="Vardiya" value={workload.summary.shiftHandoverCount} />
        <Metric label="İşlem" value={workload.summary.faultActionCount} />
        <Metric label="Tamamlanan" value={workload.summary.completedWorkCount} />
      </div>
      <div className="grid gap-5 xl:grid-cols-2">
        <TaskSection title="Atanmış Açık Arızalar" items={workload.openFaults} render={(item) => <TaskRow key={item.id} title={`${item.faultNo} • ${item.equipmentCode}`} subtitle={`${item.equipmentName} • ${item.locationName}`} meta={`${labelFor(priorityLabels, item.priority)} / ${labelFor(statusLabels, item.status)}`} />} />
        <TaskSection title="Açık Bakım Planları" items={workload.openMaintenancePlans} render={(item) => <TaskRow key={item.id} title={`${item.planNo} • ${item.maintenanceType}`} subtitle={`${item.equipmentCode} • ${item.equipmentName}`} meta={`${formatDate(item.plannedDate)} / ${labelFor(statusLabels, item.status)}`} />} />
        <TaskSection title="Açık Test Planları" items={workload.openTestPlans} render={(item) => <TaskRow key={item.id} title={item.testType} subtitle={`${item.equipmentCode} • ${item.equipmentName}`} meta={`${formatDate(item.plannedDate)} / ${labelFor(statusLabels, item.status)}`} />} />
        <TaskSection title="Vardiya Görevleri" items={workload.shiftHandovers} render={(item) => <TaskRow key={item.id} title={`${item.handoverNo} • ${item.direction}`} subtitle={item.summary ?? 'Özet girilmedi'} meta={`${formatDate(item.shiftDate)} / ${labelFor(shiftTypeLabels, item.shiftType)}`} />} />
        <TaskSection title="Yaptığı Arıza İşlemleri" items={workload.faultActions} render={(item) => <TaskRow key={item.id} title={`${item.faultNo} • ${item.actionType}`} subtitle={item.note ?? 'İşlem notu yok'} meta={formatDateTime(item.createdAt)} />} />
        <TaskSection title="Tamamladığı İşler" items={workload.completedWorks} render={(item) => <TaskRow key={item.id} title={`${item.workType} • ${item.referenceNo}`} subtitle={item.title} meta={`${item.result ?? '-'} / ${formatDateTime(item.completedAt)}`} />} />
      </div>
    </section>
  )
}

function TaskSection<T>({ items, render, title }: { items: T[]; render: (item: T) => ReactNode; title: string }) {
  return <div className="rounded border border-[#C6C6CD] bg-[#FCF8FA]"><h4 className="border-b border-[#C6C6CD] p-3 text-sm font-bold text-black">{title}</h4><div className="divide-y divide-[#C6C6CD]">{items.map(render)}{items.length === 0 ? <EmptyPanel text="Kayıt yok." /> : null}</div></div>
}

function TaskRow({ meta, subtitle, title }: { meta: string; subtitle: string; title: string }) {
  return <div className="p-3"><p className="text-sm font-bold text-black">{title}</p><p className="mt-1 text-xs text-[#45464D]">{subtitle}</p><p className="mt-2 font-mono text-[11px] text-[#76777D]">{meta}</p></div>
}

function Metric({ label, value }: { label: string; value: number }) {
  return <div className="border border-[#C6C6CD] bg-[#FCF8FA] p-3"><p className="text-[11px] font-bold uppercase tracking-wide text-[#45464D]">{label}</p><p className="mt-1 font-mono text-2xl font-bold text-black">{value}</p></div>
}

function Field({ children, label }: { children: ReactNode; label: string }) {
  return <label className="block text-[11px] font-bold uppercase tracking-wide text-[#1B1B1D]"><span className="mb-2 block">{label}</span>{children}</label>
}

function StatusBadge({ active }: { active: boolean }) {
  return <span className={`${active ? 'bg-[#DCFCE7] text-[#166534]' : 'bg-[#E4E2E4] text-[#45464D]'} px-2 py-1 text-xs font-bold`}>{active ? 'Aktif' : 'Pasif'}</span>
}

function EmptyPanel({ text }: { text: string }) {
  return <div className="p-5 text-center text-sm text-[#45464D]">{text}</div>
}

function labelFor(labels: Record<string, string>, value: string) {
  return labels[value] ?? value
}

function formatDate(value?: string | null) {
  if (!value) {
    return '-'
  }

  return new Intl.DateTimeFormat('tr-TR', { dateStyle: 'short' }).format(new Date(value))
}

function formatDateTime(value?: string | null) {
  if (!value) {
    return '-'
  }

  return new Intl.DateTimeFormat('tr-TR', { dateStyle: 'short', timeStyle: 'short' }).format(new Date(value))
}

async function adminRequest<T>(apiBaseUrl: string, token: string, path: string, options: RequestInit = {}): Promise<T> {
  const headers = new Headers(options.headers)
  headers.set('Authorization', `Bearer ${token}`)
  if (options.body && !headers.has('Content-Type')) {
    headers.set('Content-Type', 'application/json')
  }

  return requestJson<T>(`${apiBaseUrl}${path}`, { ...options, headers })
}

export default UserManagementView
