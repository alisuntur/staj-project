import { useState } from 'react'
import EquipmentView from './EquipmentView'
import FaultsView from './FaultsView'
import MaintenanceView from './MaintenanceView'
import ShiftsView from './ShiftsView'
import TestsView from './TestsView'

const API_BASE_URL = import.meta.env.VITE_API_BASE_URL ?? 'http://localhost:5088'

type ActiveView = 'faults' | 'maintenance' | 'tests' | 'shifts' | 'equipment'

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

const navigationItems: { label: string; icon: string; view?: ActiveView }[] = [
  { label: 'Panel', icon: 'dashboard' },
  { label: 'Operasyonlar', icon: 'settings_suggest', view: 'faults' },
  { label: 'Vardiya Devir Teslim', icon: 'sync_alt', view: 'shifts' },
  { label: 'Bakım', icon: 'build', view: 'maintenance' },
  { label: 'Testler', icon: 'biotech', view: 'tests' },
  { label: 'Varlık Yönetimi', icon: 'inventory_2', view: 'equipment' },
  { label: 'Raporlama', icon: 'assessment' },
  { label: 'Yönetim', icon: 'admin_panel_settings' },
]

function App() {
  const [activeView, setActiveView] = useState<ActiveView>('faults')
  const [usernameOrEmail, setUsernameOrEmail] = useState('admin')
  const [password, setPassword] = useState('Demo123!')
  const [token, setToken] = useState('')
  const [user, setUser] = useState<AuthUser | null>(null)
  const [isLoading, setIsLoading] = useState(false)
  const [message, setMessage] = useState('Hazır. Demo admin bilgileriyle giriş yapın.')

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
      setActiveView('faults')
      setMessage(`${response.user.fullName} olarak giriş yapıldı.`)
    } catch (error) {
      setMessage(error instanceof Error ? error.message : 'Giriş sırasında hata oluştu.')
    } finally {
      setIsLoading(false)
    }
  }

  async function apiRequest<T>(path: string, options: RequestInit = {}): Promise<T> {
    const headers = new Headers(options.headers)
    if (options.body && !headers.has('Content-Type')) {
      headers.set('Content-Type', 'application/json')
    }

    const response = await fetch(`${API_BASE_URL}${path}`, { ...options, headers })
    const text = await response.text()
    const payload = text ? JSON.parse(text) : null

    if (!response.ok) {
      throw new Error((payload as { message?: string } | null)?.message ?? `API isteği başarısız: ${response.status}`)
    }

    return payload as T
  }

  if (!token) {
    return (
      <main className="min-h-screen bg-[#FCF8FA] text-[#1B1B1D]">
        <div className="flex min-h-screen items-center justify-center px-5 py-10">
          <section className="page-transition w-full">
            <div className="mx-auto w-full max-w-md border border-[#C6C6CD] bg-white p-8 shadow-[0px_1px_3px_rgba(15,23,42,0.08)]">
              <p className="text-[11px] font-bold uppercase tracking-[0.18em] text-[#45464D]">O&amp;M Otomasyon</p>
              <h1 className="mt-2 text-3xl font-bold tracking-tight text-black">Yönetim paneline giriş</h1>
              <p className="mt-3 text-sm leading-6 text-[#45464D]">Arıza ve varlık yönetimi ekranlarını görüntülemek için demo kullanıcıyla giriş yap.</p>

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
              <div className="mt-5 border border-[#C6C6CD] bg-[#F6F3F5] p-3 text-sm text-[#45464D]">{message}</div>
              <div className="mt-5 bg-[#F0EDEF] p-3 text-xs leading-5 text-[#45464D]"><strong className="text-black">Demo bilgi:</strong> kullanıcı adı <span className="font-mono">admin</span>, şifre <span className="font-mono">Demo123!</span></div>
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
          {navigationItems.map((item) => {
            const isActive = item.view === activeView

            return (
              <button
                key={item.label}
                className={`flex w-full items-center gap-3 px-5 py-3 text-left text-sm transition-colors ${
                  isActive
                    ? 'border-l-4 border-[#3755C3] bg-[#3F465C] text-white'
                    : item.view
                      ? 'text-[#7C839B] hover:bg-[#3F465C]/50 hover:text-white'
                      : 'cursor-not-allowed text-[#3F465C]'
                }`}
                disabled={!item.view}
                type="button"
                onClick={() => {
                  if (item.view) {
                    setActiveView(item.view)
                  }
                }}
              >
                <span className="material-symbols-outlined text-[22px]">{item.icon}</span>
                <span>{item.label}</span>
              </button>
            )
          })}
        </nav>
        <div className="border-t border-[#3F465C] p-4 text-xs text-[#7C839B]"><p className="font-mono">API: {API_BASE_URL}</p></div>
      </aside>

      <div className="lg:ml-[260px]">
        <header className="sticky top-0 z-40 flex items-center justify-between border-b border-[#C6C6CD] bg-[#FCF8FA] px-5 py-3 lg:px-6">
          <div className="flex items-center gap-4">
            <span className="text-lg font-bold text-black">O&amp;M Yönetimi</span>
            <div className="relative hidden md:block">
              <span className="material-symbols-outlined absolute left-3 top-1/2 -translate-y-1/2 text-[#76777D]">search</span>
              <input className="h-9 w-72 border border-[#C6C6CD] bg-white pl-9 pr-3 text-[13px] outline-none focus:border-[#3755C3]" placeholder={activeView === 'faults' ? 'Arıza ara...' : activeView === 'maintenance' ? 'Bakım planı ara...' : activeView === 'tests' ? 'Test kaydı ara...' : activeView === 'shifts' ? 'Vardiya devri ara...' : 'Ekipman ara...'} readOnly />
            </div>
          </div>
          <div className="flex items-center gap-3">
            <span className="material-symbols-outlined text-[#45464D]">notifications</span>
            <span className="material-symbols-outlined text-[#45464D]">history</span>
            <span className="material-symbols-outlined text-[#45464D]">help</span>
            <div className="hidden text-right text-xs md:block"><p className="font-semibold text-black">{user?.fullName}</p><p className="text-[#45464D]">{user?.role}</p></div>
            <div className="flex h-9 w-9 items-center justify-center rounded-full bg-[#131B2E] text-white"><span className="material-symbols-outlined text-[18px]">person</span></div>
          </div>
        </header>

        <div key={activeView} className="page-transition">
          {activeView === 'faults' ? <FaultsView apiBaseUrl={API_BASE_URL} token={token} user={user} /> : null}
          {activeView === 'maintenance' ? <MaintenanceView apiBaseUrl={API_BASE_URL} token={token} /> : null}
          {activeView === 'tests' ? <TestsView apiBaseUrl={API_BASE_URL} token={token} /> : null}
          {activeView === 'shifts' ? <ShiftsView apiBaseUrl={API_BASE_URL} token={token} /> : null}
          {activeView === 'equipment' ? <EquipmentView apiBaseUrl={API_BASE_URL} token={token} /> : null}
        </div>
      </div>
    </main>
  )
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

export default App
