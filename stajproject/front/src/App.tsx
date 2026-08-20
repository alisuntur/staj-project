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

const navigationItems: { label: string; icon: string; view: ActiveView; roles?: string[] }[] = [
  { label: 'Panel', icon: 'dashboard', view: 'dashboard' },
  { label: 'Operasyonlar', icon: 'settings_suggest', view: 'faults' },
  { label: 'Vardiya Devir Teslim', icon: 'sync_alt', view: 'shifts' },
  { label: 'Bakım', icon: 'build', view: 'maintenance' },
  { label: 'Testler', icon: 'biotech', view: 'tests' },
  { label: 'Varlık Yönetimi', icon: 'inventory_2', view: 'equipment' },
  { label: 'Raporlama', icon: 'assessment', view: 'reports', roles: ['Admin', 'Yönetici', 'Teknik Personel', 'Rapor Kullanıcısı'] },
  { label: 'Bildirimler', icon: 'notifications', view: 'notifications' },
  { label: 'Yönetim', icon: 'admin_panel_settings', view: 'users', roles: ['Admin'] },
]

const demoFlow: ActiveView[] = ['dashboard', 'faults', 'equipment', 'shifts', 'reports', 'notifications', 'users']

const activeViewTitles: Record<ActiveView, string> = {
  dashboard: 'Operasyon Özeti',
  faults: 'Arıza Yönetimi',
  maintenance: 'Bakım Yönetimi',
  tests: 'Periyodik Testler',
  shifts: 'Vardiya Devir Teslim',
  equipment: 'Varlık Yönetimi',
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
  const [message, setMessage] = useState('Hazır. Admin bilgileriyle giriş yapın.')

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
      const response = await apiRequest<LoginResponse>('/api/auth/login', {
        method: 'POST',
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

  async function apiRequest<T>(path: string, options: RequestInit = {}): Promise<T> {
    const headers = new Headers(options.headers)
    if (options.body && !headers.has('Content-Type')) {
      headers.set('Content-Type', 'application/json')
    }

    return requestJson<T>(`${API_BASE_URL}${path}`, { ...options, headers })
  }

  function openFaultDetail(faultId: string) {
    setSelectedFaultId(faultId)
    setActiveView('faults')
  }

  function openShiftDetail(handoverNo: string) {
    setSelectedShiftHandoverNo(handoverNo)
    setActiveView('shifts')
  }

  function openNotifications() {
    setSelectedFaultId(null)
    setSelectedShiftHandoverNo(null)
    setActiveView('notifications')
  }

  function navigateTo(view: ActiveView) {
    setSelectedFaultId(null)
    setSelectedShiftHandoverNo(null)
    setActiveView(view)
  }

  function handleNextDemoStep() {
    const allowedFlow = demoFlow.filter((view) => navigationItems.some((item) => item.view === view && (!item.roles || (user && item.roles.includes(user.role)))))
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
    setMessage('Oturum kapatıldı. Yetkili hesapla yeniden giriş yapabilirsiniz.')
  }

  if (!token) {
    return (
      <main className="min-h-screen bg-[#F3F5F8] text-[#1B1B1D]">
        <div className="grid min-h-screen lg:grid-cols-[minmax(0,1.1fr)_520px]">
          <section className="module-font flex min-h-[520px] flex-col justify-between bg-[#111827] p-8 text-white lg:p-12">
            <div>
              <div className="flex items-center gap-4">
                <div className="flex h-12 w-12 items-center justify-center rounded bg-[#3755C3]"><span className="material-symbols-outlined text-3xl">hub</span></div>
                <div><p className="text-xl font-bold leading-tight">TechOps O&amp;M</p><p className="text-sm text-[#BEC6E0]">Operasyon ve Bakım Yönetim Sistemi</p></div>
              </div>
              <div className="mt-16 max-w-3xl">
                <p className="text-[11px] font-bold uppercase tracking-[0.22em] text-[#93A4D4]">Kurumsal Operasyon Paneli</p>
                <h1 className="mt-4 text-4xl font-bold tracking-tight md:text-6xl">Teknik operasyon, varlık ve raporlama süreçleri tek merkezde.</h1>
                <p className="mt-5 max-w-2xl text-base leading-8 text-[#D1D5DB]">Arıza kayıtları, bakım planları, periyodik testler, vardiya devri, ekipman geçmişi ve yönetici raporları rol bazlı bir yönetim panelinde birleşir.</p>
              </div>
            </div>
            <div className="mt-12 grid gap-4 md:grid-cols-3">
              <LoginValueCard icon="monitoring" label="Canlı KPI" text="Dashboard, kritik risk ve operasyon sağlığı" />
              <LoginValueCard icon="assignment" label="Saha Akışı" text="Arıza, bakım, test ve vardiya kayıtları" />
              <LoginValueCard icon="picture_as_pdf" label="Yönetici Çıktısı" text="Excel/PDF imzaya hazır raporlar" />
            </div>
          </section>

          <section className="flex items-center justify-center px-5 py-10 lg:px-10">
            <div className="page-transition w-full max-w-md border border-[#C6C6CD] bg-white p-8 shadow-[0px_20px_45px_rgba(15,23,42,0.10)]">
              <p className="text-[11px] font-bold uppercase tracking-[0.18em] text-[#45464D]">Güvenli erişim</p>
              <h2 className="mt-2 text-3xl font-bold tracking-tight text-black">Yönetim paneline giriş</h2>
              <p className="mt-3 text-sm leading-6 text-[#45464D]">Hazır admin hesabı üzerinden tüm operasyon yönetimi akışını görüntüleyin.</p>

              <label className="mt-7 block text-[11px] font-bold uppercase tracking-wide text-[#1B1B1D]">
                Kullanıcı adı veya e-posta
                <input className="mt-2 h-10 w-full border border-[#C6C6CD] bg-white px-3 text-sm outline-none focus:border-2 focus:border-[#3755C3]" value={usernameOrEmail} onChange={(event) => setUsernameOrEmail(event.target.value)} />
              </label>
              <label className="mt-4 block text-[11px] font-bold uppercase tracking-wide text-[#1B1B1D]">
                Şifre
                <input className="mt-2 h-10 w-full border border-[#C6C6CD] bg-white px-3 text-sm outline-none focus:border-2 focus:border-[#3755C3]" type="password" value={password} onChange={(event) => setPassword(event.target.value)} />
              </label>
              <button className="mt-6 flex h-11 w-full items-center justify-center gap-2 bg-black px-4 text-sm font-semibold text-white transition-colors hover:bg-[#131B2E] disabled:bg-[#76777D]" disabled={isLoading} type="button" onClick={handleLogin}>
                <span className="material-symbols-outlined text-lg">login</span>
                Giriş Yap
              </button>
              <div className="mt-5"><StatusMessage busy={isLoading} message={message} /></div>
              <div className="mt-5 border border-[#DDE1FF] bg-[#F8FAFF] p-3 text-xs leading-5 text-[#45464D]"><strong className="text-black">Erişim bilgisi:</strong> <span className="font-mono">admin</span> / <span className="font-mono">Demo123!</span></div>
            </div>
          </section>
        </div>
      </main>
    )
  }

  return (
    <main className="min-h-screen bg-[#FCF8FA] text-[#1B1B1D]">
      <aside className="fixed left-0 top-0 z-50 hidden h-full w-[260px] flex-col bg-black text-white shadow-sm lg:flex">
        <BrandBlock />
        <nav className="flex-1 overflow-y-auto py-4">
          {navigationItems.filter((item) => !item.roles || (user && item.roles.includes(user.role))).map((item) => {
            const isActive = item.view === activeView

            return (
              <button
                key={item.label}
                className={`flex w-full items-center gap-3 px-5 py-3 text-left text-sm transition-colors ${
                  isActive
                    ? 'border-l-4 border-[#3755C3] bg-[#3F465C] text-white'
                    : 'text-[#7C839B] hover:bg-[#3F465C]/50 hover:text-white'
                }`}
                type="button"
                onClick={() => {
                  setSelectedFaultId(null)
                  setSelectedShiftHandoverNo(null)
                  setActiveView(item.view)
                }}
              >
                <span className="material-symbols-outlined text-[22px]">{item.icon}</span>
                <span>{item.label}</span>
              </button>
            )
          })}
        </nav>
        <div className="border-t border-[#3F465C] p-4 text-xs text-[#7C839B]"><p>TechOps O&amp;M • Kurumsal Operasyon</p></div>
      </aside>

      <div className="pb-24 lg:ml-[260px] lg:pb-0">
        <header className="sticky top-0 z-40 flex items-center justify-between border-b border-[#C6C6CD] bg-[#FCF8FA] px-5 py-3 lg:px-6">
          <div className="flex items-center gap-4">
            <span className="text-lg font-bold text-black">O&amp;M Yönetimi</span>
            <div className="hidden border-l border-[#C6C6CD] pl-4 text-sm text-[#45464D] md:block"><span className="font-semibold text-black">{activeViewTitles[activeView]}</span><span className="mx-2">/</span><span>Operasyon verisi aktif</span></div>
          </div>
          <div className="flex items-center gap-3">
            <button className="hidden items-center gap-2 bg-black px-3 py-2 text-[13px] font-semibold text-white transition-colors hover:bg-[#131B2E] md:flex" type="button" onClick={handleNextDemoStep}>
              <span className="material-symbols-outlined text-[18px]">slideshow</span>
              Sonraki Akış Adımı
            </button>
            <button className={`${activeView === 'notifications' ? 'border-[#3755C3] bg-[#DDE1FF] text-[#3755C3]' : 'border-[#C6C6CD] bg-white text-[#45464D] hover:bg-[#F6F3F5]'} relative flex h-9 items-center gap-2 border px-3 text-[13px] font-semibold transition-colors`} type="button" onClick={openNotifications}>
              <span className="material-symbols-outlined text-[18px]">notifications</span>
              <span className="hidden md:inline">Bildirimler</span>
              {unreadNotificationCount > 0 ? <span className="absolute -right-2 -top-2 min-w-5 rounded-full bg-[#BA1A1A] px-1.5 py-0.5 text-center font-mono text-[11px] font-bold text-white">{unreadNotificationCount > 99 ? '99+' : unreadNotificationCount}</span> : null}
            </button>
            <div className="hidden text-right text-xs md:block"><p className="font-semibold text-black">{user?.fullName}</p><p className="text-[#45464D]">{user?.role}</p></div>
            <div className="flex h-9 w-9 items-center justify-center rounded-full bg-[#131B2E] text-white"><span className="material-symbols-outlined text-[18px]">person</span></div>
            <button className="hidden border border-[#C6C6CD] bg-white px-3 py-2 text-[13px] font-semibold text-[#45464D] transition-colors hover:bg-[#F6F3F5] sm:block" type="button" onClick={handleLogout}>Çıkış</button>
          </div>
        </header>

        <div key={activeView} className="page-transition">
          {activeView === 'dashboard' ? <DashboardView apiBaseUrl={API_BASE_URL} token={token} onOpenFault={openFaultDetail} onOpenShift={openShiftDetail} /> : null}
          {activeView === 'faults' ? <FaultsView apiBaseUrl={API_BASE_URL} selectedFaultId={selectedFaultId} token={token} user={user} /> : null}
          {activeView === 'maintenance' ? <MaintenanceView apiBaseUrl={API_BASE_URL} token={token} /> : null}
          {activeView === 'tests' ? <TestsView apiBaseUrl={API_BASE_URL} token={token} /> : null}
          {activeView === 'shifts' ? <ShiftsView apiBaseUrl={API_BASE_URL} selectedHandoverNo={selectedShiftHandoverNo} token={token} /> : null}
          {activeView === 'equipment' ? <EquipmentView apiBaseUrl={API_BASE_URL} token={token} /> : null}
          {activeView === 'reports' ? <ReportsView apiBaseUrl={API_BASE_URL} token={token} /> : null}
          {activeView === 'notifications' ? <NotificationsView apiBaseUrl={API_BASE_URL} token={token} user={user} onUnreadCountChange={setUnreadNotificationCount} /> : null}
          {activeView === 'users' ? <UserManagementView apiBaseUrl={API_BASE_URL} token={token} /> : null}
        </div>
      </div>
      <MobileNavigation activeView={activeView} user={user} onNavigate={(view) => {
        navigateTo(view)
      }} />
    </main>
  )
}

function LoginValueCard({ icon, label, text }: { icon: string; label: string; text: string }) {
  return <div className="border border-white/15 bg-white/5 p-4"><span className="material-symbols-outlined text-[#DBEAFE]">{icon}</span><p className="mt-3 text-sm font-bold text-white">{label}</p><p className="mt-1 text-xs leading-5 text-[#D1D5DB]">{text}</p></div>
}

function BrandBlock() {
  return (
    <div className="border-b border-[#1F2937] p-6">
      <div className="flex items-center gap-4">
        <div className="flex h-12 w-12 items-center justify-center rounded bg-[#3755C3] text-white"><span className="material-symbols-outlined text-3xl">hub</span></div>
        <div><h1 className="text-2xl font-bold leading-tight tracking-tight">O&amp;M<br />Otomasyon</h1><p className="mt-1 text-sm text-[#7C839B]">Yönetim Paneli</p></div>
      </div>
    </div>
  )
}

function MobileNavigation({ activeView, onNavigate, user }: { activeView: ActiveView; onNavigate: (view: ActiveView) => void; user: AuthUser | null }) {
  const visibleItems = navigationItems.filter((item) => !item.roles || (user && item.roles.includes(user.role)))

  return (
    <nav className="fixed bottom-0 left-0 right-0 z-50 border-t border-[#C6C6CD] bg-white/95 px-2 py-2 shadow-[0_-8px_24px_rgba(15,23,42,0.08)] backdrop-blur lg:hidden" aria-label="Mobil menü">
      <div className="flex gap-2 overflow-x-auto pb-1">
        {visibleItems.map((item) => {
          const isActive = item.view === activeView

          return (
            <button className={`${isActive ? 'bg-black text-white' : 'bg-[#F6F3F5] text-[#45464D]'} flex min-w-[84px] flex-col items-center justify-center gap-1 rounded px-3 py-2 text-[11px] font-semibold`} key={item.view} type="button" onClick={() => onNavigate(item.view)}>
              <span className="material-symbols-outlined text-[20px]">{item.icon}</span>
              <span className="whitespace-nowrap">{item.label}</span>
            </button>
          )
        })}
      </div>
    </nav>
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
