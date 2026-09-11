import { useEffect, useState } from 'react'
import DashboardView from './DashboardView'
import EquipmentView from './EquipmentView'
import FaultsView from './FaultsView'
import MaintenanceView from './MaintenanceView'
import NotificationsView from './NotificationsView'
import ReportsView from './ReportsView'
import ShiftsView from './ShiftsView'
import TestsView from './TestsView'
import UserManagementView from './UserManagementView'
import { friendlyErrorMessage, requestJson } from './apiClient'
import { StatusMessage } from './UiState'

const API_BASE_URL = import.meta.env.VITE_API_BASE_URL ?? 'http://localhost:5162'

type ActiveView = 'dashboard' | 'faults' | 'maintenance' | 'tests' | 'shifts' | 'equipment' | 'reports' | 'notifications' | 'users'

type AuthUser = {
  fullName: string
  username: string
  email: string
  role: string
}

type LoginResponse = {
  accessToken: string
  expiresAt: string
  user: AuthUser
}

type NotificationUnreadCount = {
  unreadCount: number
}

const navigationItems: { label: string; shortLabel: string; icon: string; view: ActiveView; roles?: string[] }[] = [
  { label: 'Ana Kokpit', shortLabel: 'Kokpit', icon: 'space_dashboard', view: 'dashboard' },
  { label: 'Arızalar', shortLabel: 'Arıza', icon: 'report', view: 'faults' },
  { label: 'Vardiya', shortLabel: 'Vardiya', icon: 'swap_horiz', view: 'shifts' },
  { label: 'Bakım', shortLabel: 'Bakım', icon: 'construction', view: 'maintenance' },
  { label: 'Testler', shortLabel: 'Test', icon: 'science', view: 'tests' },
  { label: 'Ekipman', shortLabel: 'Ekipman', icon: 'inventory_2', view: 'equipment' },
  { label: 'Raporlar', shortLabel: 'Rapor', icon: 'query_stats', view: 'reports', roles: ['Admin', 'Yönetici', 'Teknik Personel', 'Rapor Kullanıcısı'] },
  { label: 'Bildirimler', shortLabel: 'Bildirim', icon: 'notifications', view: 'notifications' },
  { label: 'Kullanıcılar', shortLabel: 'Yönetim', icon: 'admin_panel_settings', view: 'users', roles: ['Admin'] },
]

const guidedFlow: ActiveView[] = ['dashboard', 'faults', 'shifts', 'equipment', 'reports', 'notifications', 'users']

const activeViewTitles: Record<ActiveView, string> = {
  dashboard: 'Operasyon Kokpiti',
  faults: 'Arıza Yönetimi',
  maintenance: 'Bakım Yönetimi',
  tests: 'Periyodik Testler',
  shifts: 'Vardiya Devir Teslim',
  equipment: 'Ekipman ve Varlıklar',
  reports: 'Yönetici Raporları',
  notifications: 'Bildirim ve Aktivite',
  users: 'Kullanıcı Yönetimi',
}

function App() {
  const [activeView, setActiveView] = useState<ActiveView>('dashboard')
  const [usernameOrEmail, setUsernameOrEmail] = useState('admin')
  const [password, setPassword] = useState('Demo123!')
  const [token, setToken] = useState('')
  const [user, setUser] = useState<AuthUser | null>(null)
  const [selectedFaultId, setSelectedFaultId] = useState<string | null>(null)
  const [selectedShiftHandoverNo, setSelectedShiftHandoverNo] = useState<string | null>(null)
  const [unreadNotificationCount, setUnreadNotificationCount] = useState(0)
  const [isLoading, setIsLoading] = useState(false)
  const [message, setMessage] = useState('Girişe hazır.')

  useEffect(() => {
    if (!token) {
      setUnreadNotificationCount(0)
      return
    }

    let ignore = false

    async function loadUnreadCount() {
      try {
        const data = await appAuthenticatedRequest<NotificationUnreadCount>(API_BASE_URL, token, '/api/notifications/unread-count')
        if (!ignore) {
          setUnreadNotificationCount(data.unreadCount)
        }
      } catch {
        if (!ignore) {
          setUnreadNotificationCount(0)
        }
      }
    }

    void loadUnreadCount()

    return () => {
      ignore = true
    }
  }, [token])

  async function handleLogin() {
    setIsLoading(true)
    setMessage('Kimlik doğrulanıyor...')

    try {
      const response = await requestJson<LoginResponse>(`${API_BASE_URL}/api/auth/login`, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ usernameOrEmail, password }),
      })

      setToken(response.accessToken)
      setUser(response.user)
      setActiveView('dashboard')
      setMessage(`${response.user.fullName} olarak giriş yapıldı.`)
    } catch (error) {
      setMessage(friendlyErrorMessage(error, 'Giriş sırasında hata oluştu.'))
    } finally {
      setIsLoading(false)
    }
  }

  function openFaultDetail(faultId: string) {
    setSelectedFaultId(faultId)
    setActiveView('faults')
  }

  function openShiftDetail(handoverNo: string) {
    setSelectedShiftHandoverNo(handoverNo)
    setActiveView('shifts')
  }

  function navigateTo(view: ActiveView) {
    setSelectedFaultId(null)
    setSelectedShiftHandoverNo(null)
    setActiveView(view)
  }

  function openNotifications() {
    navigateTo('notifications')
  }

  function handleNextStep() {
    const allowedFlow = guidedFlow.filter((view) => navigationItems.some((item) => item.view === view && (!item.roles || (user && item.roles.includes(user.role)))))
    const currentIndex = allowedFlow.indexOf(activeView)
    const nextView = allowedFlow[(currentIndex + 1) % allowedFlow.length] ?? 'dashboard'
    navigateTo(nextView)
  }

  function handleLogout() {
    setToken('')
    setUser(null)
    setSelectedFaultId(null)
    setSelectedShiftHandoverNo(null)
    setActiveView('dashboard')
    setMessage('Oturum kapatıldı. Yeniden giriş yapabilirsiniz.')
  }

  if (!token) {
    return (
      <main className="min-h-screen bg-[#EEF2F7] text-[#0F172A]">
        <div className="grid min-h-screen lg:grid-cols-[minmax(0,1fr)_480px]">
          <section className="module-font relative overflow-hidden bg-[#0B1220] px-6 py-8 text-white sm:px-10 lg:px-14">
            <div className="absolute inset-0 bg-[radial-gradient(circle_at_20%_10%,rgba(59,130,246,0.30),transparent_32%),radial-gradient(circle_at_80%_20%,rgba(14,165,233,0.16),transparent_28%)]" />
            <div className="relative flex min-h-full flex-col justify-between">
              <div>
                <div className="flex items-center gap-4">
                  <div className="flex h-12 w-12 items-center justify-center rounded-2xl bg-[#2563EB] shadow-[0_14px_36px_rgba(37,99,235,0.35)]">
                    <span className="material-symbols-outlined text-3xl">hub</span>
                  </div>
                  <div>
                    <p className="text-xl font-extrabold tracking-tight">TechOps O&amp;M</p>
                    <p className="text-sm text-[#C7D2FE]">Kurumsal Operasyon Merkezi</p>
                  </div>
                </div>

                <div className="mt-16 max-w-3xl">
                  <p className="text-[11px] font-bold uppercase tracking-[0.28em] text-[#93C5FD]">Operasyon kokpiti</p>
                  <h1 className="mt-4 text-4xl font-extrabold tracking-tight md:text-6xl">Vardiya, arıza, bakım ve raporlar tek sade ekranda.</h1>
                  <p className="mt-5 max-w-2xl text-base leading-8 text-[#D8E2F2]">Giriş yapan kullanıcı önce kritik işleri görür; açık arızalar, vardiyadan kalanlar, bakım ve test durumu öncelik sırasına göre aşağı doğru akar.</p>
                </div>
              </div>

              <div className="mt-12 grid gap-4 md:grid-cols-3">
                <LoginValueCard icon="priority_high" label="Öncelik Odaklı" text="Kritik arıza ve devreden iş en üstte görünür." />
                <LoginValueCard icon="groups" label="Herkese Uygun" text="Operatör, teknik ekip ve yönetici aynı akışı kullanır." />
                <LoginValueCard icon="summarize" label="Rapor Hazır" text="Her modül kendi Excel/PDF çıktısını üretir." />
              </div>
            </div>
          </section>

          <section className="flex items-center justify-center px-5 py-10 lg:px-10">
            <div className="w-full max-w-md rounded-[28px] border border-[#D7DEE8] bg-white p-7 shadow-[0_24px_70px_rgba(15,23,42,0.12)]">
              <div className="rounded-2xl border border-[#E2E8F0] bg-[#F8FAFC] p-4">
                <p className="text-[11px] font-bold uppercase tracking-[0.18em] text-[#64748B]">Güvenli giriş</p>
                <h2 className="mt-2 text-3xl font-extrabold tracking-tight text-[#0F172A]">Operasyon paneli</h2>
                <p className="mt-2 text-sm leading-6 text-[#475569]">Sadeleştirilmiş kokpite erişmek için yetkili kullanıcı bilgileriyle giriş yapın.</p>
              </div>

              <label className="mt-6 block text-[11px] font-bold uppercase tracking-wide text-[#334155]">
                Kullanıcı adı veya e-posta
                <input className="mt-2 h-12 w-full rounded-xl border border-[#CBD5E1] bg-white px-4 text-sm outline-none transition focus:border-[#2563EB] focus:ring-4 focus:ring-[#DBEAFE]" value={usernameOrEmail} onChange={(event) => setUsernameOrEmail(event.target.value)} />
              </label>
              <label className="mt-4 block text-[11px] font-bold uppercase tracking-wide text-[#334155]">
                Şifre
                <input className="mt-2 h-12 w-full rounded-xl border border-[#CBD5E1] bg-white px-4 text-sm outline-none transition focus:border-[#2563EB] focus:ring-4 focus:ring-[#DBEAFE]" type="password" value={password} onChange={(event) => setPassword(event.target.value)} />
              </label>

              <button className="mt-6 flex h-12 w-full items-center justify-center gap-2 rounded-xl bg-[#0F172A] px-4 text-sm font-bold text-white transition hover:bg-[#1E293B] disabled:cursor-not-allowed disabled:bg-[#94A3B8]" disabled={isLoading} type="button" onClick={handleLogin}>
                <span className="material-symbols-outlined text-lg">login</span>
                Panele Giriş Yap
              </button>

              <div className="mt-5"><StatusMessage busy={isLoading} message={message} /></div>

              <div className="mt-5 rounded-2xl border border-[#BFDBFE] bg-[#EFF6FF] p-4 text-sm leading-6 text-[#1E3A8A]">
                <p className="font-bold text-[#0F172A]">Hazır kurulum erişimi</p>
                <p className="mt-1">Form yetkili yönetici hesabıyla önceden dolduruludur.</p>
              </div>

              <div className="mt-5 grid grid-cols-3 gap-2 text-center text-[11px] font-bold uppercase tracking-wide text-[#64748B]">
                <span className="rounded-xl bg-[#F1F5F9] px-2 py-3">JWT</span>
                <span className="rounded-xl bg-[#F1F5F9] px-2 py-3">Rol Yetki</span>
                <span className="rounded-xl bg-[#F1F5F9] px-2 py-3">Docker</span>
              </div>
            </div>
          </section>
        </div>
      </main>
    )
  }

  const visibleNavigation = navigationItems.filter((item) => !item.roles || (user && item.roles.includes(user.role)))

  return (
    <main className="min-h-screen bg-[#F4F7FB] text-[#0F172A]">
      <header className="sticky top-0 z-50 border-b border-[#D7DEE8] bg-white/95 backdrop-blur-xl">
        <div className="mx-auto flex max-w-[1680px] items-center justify-between gap-4 px-4 py-3 lg:px-8">
          <div className="flex min-w-0 items-center gap-3">
            <div className="flex h-11 w-11 shrink-0 items-center justify-center rounded-2xl bg-[#0F172A] text-white">
              <span className="material-symbols-outlined text-[24px]">hub</span>
            </div>
            <div className="min-w-0">
              <p className="truncate text-base font-extrabold tracking-tight text-[#0F172A]">TechOps O&amp;M</p>
              <p className="truncate text-xs font-semibold text-[#64748B]">{activeViewTitles[activeView]}</p>
            </div>
          </div>

          <div className="flex items-center gap-2 sm:gap-3">
            <button className="hidden items-center gap-2 rounded-xl border border-[#CBD5E1] bg-white px-3 py-2 text-[13px] font-bold text-[#334155] transition hover:bg-[#F8FAFC] md:flex" type="button" onClick={handleNextStep}>
              <span className="material-symbols-outlined text-[18px]">route</span>
              Hızlı Gezin
            </button>
            <button className="relative flex h-10 items-center gap-2 rounded-xl border border-[#CBD5E1] bg-white px-3 text-[13px] font-bold text-[#334155] transition hover:bg-[#F8FAFC]" type="button" onClick={openNotifications}>
              <span className="material-symbols-outlined text-[18px]">notifications</span>
              <span className="hidden sm:inline">Bildirim</span>
              {unreadNotificationCount > 0 ? <span className="absolute -right-2 -top-2 min-w-5 rounded-full bg-[#DC2626] px-1.5 py-0.5 text-center font-mono text-[11px] font-bold text-white">{unreadNotificationCount > 99 ? '99+' : unreadNotificationCount}</span> : null}
            </button>
            <div className="hidden text-right text-xs md:block">
              <p className="font-extrabold text-[#0F172A]">{user?.fullName}</p>
              <p className="font-semibold text-[#64748B]">{user?.role}</p>
            </div>
            <button className="rounded-xl bg-[#0F172A] px-3 py-2 text-[13px] font-bold text-white transition hover:bg-[#1E293B]" type="button" onClick={handleLogout}>Çıkış</button>
          </div>
        </div>

        <nav className="mx-auto flex max-w-[1680px] gap-2 overflow-x-auto px-4 pb-3 lg:px-8" aria-label="Ana navigasyon">
          {visibleNavigation.map((item) => {
            const isActive = item.view === activeView

            return (
              <button className={`${isActive ? 'bg-[#0F172A] text-white shadow-[0_12px_30px_rgba(15,23,42,0.18)]' : 'bg-[#F1F5F9] text-[#475569] hover:bg-[#E2E8F0]'} flex shrink-0 items-center gap-2 rounded-2xl px-4 py-2.5 text-sm font-bold transition`} key={item.view} type="button" onClick={() => navigateTo(item.view)}>
                <span className="material-symbols-outlined text-[19px]">{item.icon}</span>
                <span className="hidden sm:inline">{item.label}</span>
                <span className="sm:hidden">{item.shortLabel}</span>
              </button>
            )
          })}
        </nav>
      </header>

      <div key={activeView} className="page-transition">
        {activeView === 'dashboard' ? <DashboardView apiBaseUrl={API_BASE_URL} token={token} user={user} onOpenFault={openFaultDetail} onOpenShift={openShiftDetail} /> : null}
        {activeView === 'faults' ? <FaultsView apiBaseUrl={API_BASE_URL} selectedFaultId={selectedFaultId} token={token} user={user} /> : null}
        {activeView === 'maintenance' ? <MaintenanceView apiBaseUrl={API_BASE_URL} token={token} /> : null}
        {activeView === 'tests' ? <TestsView apiBaseUrl={API_BASE_URL} token={token} /> : null}
        {activeView === 'shifts' ? <ShiftsView apiBaseUrl={API_BASE_URL} selectedHandoverNo={selectedShiftHandoverNo} token={token} user={user} /> : null}
        {activeView === 'equipment' ? <EquipmentView apiBaseUrl={API_BASE_URL} token={token} /> : null}
        {activeView === 'reports' ? <ReportsView apiBaseUrl={API_BASE_URL} token={token} /> : null}
        {activeView === 'notifications' ? <NotificationsView apiBaseUrl={API_BASE_URL} token={token} user={user} onUnreadCountChange={setUnreadNotificationCount} /> : null}
        {activeView === 'users' ? <UserManagementView apiBaseUrl={API_BASE_URL} token={token} /> : null}
      </div>
    </main>
  )
}

function LoginValueCard({ icon, label, text }: { icon: string; label: string; text: string }) {
  return (
    <div className="rounded-2xl border border-white/15 bg-white/10 p-4 shadow-[inset_0_1px_0_rgba(255,255,255,0.12)] backdrop-blur">
      <span className="material-symbols-outlined text-[#BFDBFE]">{icon}</span>
      <p className="mt-3 text-sm font-extrabold text-white">{label}</p>
      <p className="mt-1 text-xs leading-5 text-[#D8E2F2]">{text}</p>
    </div>
  )
}

async function appAuthenticatedRequest<T>(apiBaseUrl: string, token: string, path: string, options: RequestInit = {}): Promise<T> {
  const headers = new Headers(options.headers)
  headers.set('Authorization', `Bearer ${token}`)
  if (options.body && !headers.has('Content-Type')) {
    headers.set('Content-Type', 'application/json')
  }

  return requestJson<T>(`${apiBaseUrl}${path}`, { ...options, headers })
}

export default App
