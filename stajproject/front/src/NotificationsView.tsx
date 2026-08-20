import { useEffect, useState } from 'react'
import ExecutiveReportDownload from './ExecutiveReportDownload'
import { requestJson } from './apiClient'
import { StatusMessage } from './UiState'

type AuthUser = {
  fullName: string
  role: string
}

type NotificationsViewProps = {
  apiBaseUrl: string
  token: string
  user: AuthUser | null
  onUnreadCountChange: (count: number) => void
}

type NotificationType = 'Info' | 'Warning' | 'Critical'
type ReadFilter = 'all' | 'unread' | 'read'

type NotificationItem = {
  id: string
  title: string
  message: string
  type: NotificationType
  relatedEntityName?: string | null
  relatedEntityId?: string | null
  isRead: boolean
  createdAt: string
  updatedAt?: string | null
}

type NotificationResponse = {
  totalCount: number
  unreadCount: number
  items: NotificationItem[]
  generatedAt: string
}

type NotificationReadResult = {
  id: string
  isRead: boolean
  updatedAt?: string | null
  unreadCount: number
}

type NotificationReadAllResult = {
  updatedCount: number
  unreadCount: number
  updatedAt: string
}

type ActivityLogItem = {
  id: string
  userId?: string | null
  userName?: string | null
  userRole?: string | null
  entityName: string
  entityId?: string | null
  action: string
  oldValues?: string | null
  newValues?: string | null
  ipAddress?: string | null
  userAgent?: string | null
  createdAt: string
}

type ActivityResponse = {
  totalCount: number
  items: ActivityLogItem[]
  generatedAt: string
}

type ActivityFilters = {
  entityName: string
  action: string
  from: string
  to: string
}

const emptyNotifications: NotificationResponse = {
  totalCount: 0,
  unreadCount: 0,
  items: [],
  generatedAt: '',
}

const emptyActivity: ActivityResponse = {
  totalCount: 0,
  items: [],
  generatedAt: '',
}

const defaultActivityFilters: ActivityFilters = {
  entityName: '',
  action: '',
  from: '',
  to: '',
}

const notificationTypes: NotificationType[] = ['Info', 'Warning', 'Critical']
const readFilters: { value: ReadFilter; label: string }[] = [
  { value: 'all', label: 'Tümü' },
  { value: 'unread', label: 'Okunmamış' },
  { value: 'read', label: 'Okundu' },
]

const entityOptions = ['Fault', 'MaintenancePlan', 'TestRecord', 'ShiftHandover', 'Equipment']
const actionOptions = ['Create', 'Update', 'StatusChange', 'Export', 'View']
const activityRoles = ['Admin', 'Yönetici', 'Rapor Kullanıcısı']

const notificationTypeLabels: Record<NotificationType, string> = {
  Info: 'Bilgi',
  Warning: 'Uyarı',
  Critical: 'Kritik',
}

const notificationTypeClasses: Record<NotificationType, string> = {
  Info: 'border-[#DDE1FF] bg-[#EEF2FF] text-[#3755C3]',
  Warning: 'border-[#FFEDD5] bg-[#FFF7ED] text-[#C2410C]',
  Critical: 'border-[#FFDAD6] bg-[#FEE2E2] text-[#BA1A1A]',
}

const actionLabels: Record<string, string> = {
  Create: 'Oluşturma',
  Update: 'Güncelleme',
  StatusChange: 'Durum Değişimi',
  Export: 'Dışa Aktarma',
  View: 'Görüntüleme',
}

function NotificationsView({ apiBaseUrl, token, user, onUnreadCountChange }: NotificationsViewProps) {
  const [notifications, setNotifications] = useState<NotificationResponse>(emptyNotifications)
  const [activity, setActivity] = useState<ActivityResponse>(emptyActivity)
  const [readFilter, setReadFilter] = useState<ReadFilter>('all')
  const [typeFilter, setTypeFilter] = useState('')
  const [activityFilters, setActivityFilters] = useState<ActivityFilters>(defaultActivityFilters)
  const [isNotificationsLoading, setIsNotificationsLoading] = useState(false)
  const [isActivityLoading, setIsActivityLoading] = useState(false)
  const [message, setMessage] = useState('Bildirim ve aktivite verileri yükleniyor...')

  const canViewActivity = Boolean(user && activityRoles.includes(user.role))
  const listedCriticalCount = notifications.items.filter((item) => item.type === 'Critical').length
  const listedUnreadCount = notifications.items.filter((item) => !item.isRead).length

  useEffect(() => {
    let ignore = false

    async function loadInitial() {
      setIsNotificationsLoading(true)
      try {
        const notificationData = await notificationRequest<NotificationResponse>(apiBaseUrl, token, '/api/notifications?take=50')
        if (!ignore) {
          setNotifications(notificationData)
          onUnreadCountChange(notificationData.unreadCount)
          setMessage(`${notificationData.totalCount} bildirim listelendi.`)
        }
      } catch (error) {
        if (!ignore) {
          setMessage(error instanceof Error ? error.message : 'Bildirimler alınamadı.')
        }
      } finally {
        if (!ignore) {
          setIsNotificationsLoading(false)
        }
      }

      if (!ignore && canViewActivity) {
        setIsActivityLoading(true)
        try {
          const activityData = await notificationRequest<ActivityResponse>(apiBaseUrl, token, '/api/activity/logs?take=50')
          if (!ignore) {
            setActivity(activityData)
          }
        } catch (error) {
          if (!ignore) {
            setMessage(error instanceof Error ? error.message : 'Aktivite geçmişi alınamadı.')
          }
        } finally {
          if (!ignore) {
            setIsActivityLoading(false)
          }
        }
      }
    }

    void loadInitial()

    return () => {
      ignore = true
    }
  }, [apiBaseUrl, token, canViewActivity, onUnreadCountChange])

  async function loadNotifications(nextReadFilter = readFilter, nextTypeFilter = typeFilter) {
    setIsNotificationsLoading(true)
    try {
      const params = new URLSearchParams({ take: '50' })
      if (nextReadFilter === 'unread') {
        params.set('isRead', 'false')
      }
      if (nextReadFilter === 'read') {
        params.set('isRead', 'true')
      }
      if (nextTypeFilter) {
        params.set('type', nextTypeFilter)
      }

      const data = await notificationRequest<NotificationResponse>(apiBaseUrl, token, `/api/notifications?${params.toString()}`)
      setNotifications(data)
      onUnreadCountChange(data.unreadCount)
      return data
    } catch (error) {
      setMessage(error instanceof Error ? error.message : 'Bildirimler alınamadı.')
      return null
    } finally {
      setIsNotificationsLoading(false)
    }
  }

  async function loadActivity(nextFilters = activityFilters) {
    if (!canViewActivity) {
      return null
    }

    setIsActivityLoading(true)
    try {
      const params = new URLSearchParams({ take: '50' })
      Object.entries(nextFilters).forEach(([key, value]) => {
        if (value) {
          params.set(key, value)
        }
      })

      const data = await notificationRequest<ActivityResponse>(apiBaseUrl, token, `/api/activity/logs?${params.toString()}`)
      setActivity(data)
      return data
    } catch (error) {
      setMessage(error instanceof Error ? error.message : 'Aktivite geçmişi alınamadı.')
      return null
    } finally {
      setIsActivityLoading(false)
    }
  }

  async function handleReadFilterChange(nextFilter: ReadFilter) {
    setReadFilter(nextFilter)
    const data = await loadNotifications(nextFilter, typeFilter)
    if (data) {
      setMessage(`${readFilters.find((item) => item.value === nextFilter)?.label ?? 'Bildirim'} filtresi uygulandı.`)
    }
  }

  async function handleTypeFilterChange(nextType: string) {
    setTypeFilter(nextType)
    const data = await loadNotifications(readFilter, nextType)
    if (data) {
      setMessage(nextType ? `${notificationTypeLabels[nextType as NotificationType]} bildirimleri listelendi.` : 'Bildirim tipi filtresi temizlendi.')
    }
  }

  async function handleMarkAsRead(notification: NotificationItem) {
    if (notification.isRead) {
      return
    }

    setIsNotificationsLoading(true)
    try {
      const result = await notificationRequest<NotificationReadResult>(apiBaseUrl, token, `/api/notifications/${notification.id}/read`, { method: 'PATCH' })
      onUnreadCountChange(result.unreadCount)
      await loadNotifications(readFilter, typeFilter)
      setMessage(`${notification.title} bildirimi okundu olarak işaretlendi.`)
    } catch (error) {
      setMessage(error instanceof Error ? error.message : 'Bildirim okundu yapılamadı.')
    } finally {
      setIsNotificationsLoading(false)
    }
  }

  async function handleMarkAllAsRead() {
    setIsNotificationsLoading(true)
    try {
      const result = await notificationRequest<NotificationReadAllResult>(apiBaseUrl, token, '/api/notifications/read-all', { method: 'PATCH' })
      onUnreadCountChange(result.unreadCount)
      await loadNotifications(readFilter, typeFilter)
      setMessage(`${result.updatedCount} bildirim okundu olarak işaretlendi.`)
    } catch (error) {
      setMessage(error instanceof Error ? error.message : 'Bildirimler okundu yapılamadı.')
    } finally {
      setIsNotificationsLoading(false)
    }
  }

  async function handleApplyActivityFilters() {
    const data = await loadActivity(activityFilters)
    if (data) {
      setMessage(`${data.totalCount} aktivite kaydı filtre sonucunda bulundu.`)
    }
  }

  async function handleClearActivityFilters() {
    setActivityFilters(defaultActivityFilters)
    const data = await loadActivity(defaultActivityFilters)
    if (data) {
      setMessage('Aktivite filtreleri temizlendi.')
    }
  }

  async function handleRefresh() {
    const [notificationData, activityData] = await Promise.all([
      loadNotifications(readFilter, typeFilter),
      canViewActivity ? loadActivity(activityFilters) : Promise.resolve(null),
    ])

    if (notificationData || activityData) {
      setMessage(`Veriler yenilendi: ${formatDateTime(new Date().toISOString())}`)
    }
  }

  return (
    <section className="module-font mx-auto w-full max-w-[1600px] bg-[#FCF8FA] px-5 py-6 lg:px-6">
      <div className="mb-6 flex flex-col gap-4 md:flex-row md:items-end md:justify-between">
        <div>
          <p className="text-[11px] font-bold uppercase tracking-[0.18em] text-[#45464D]">İzlenebilirlik</p>
          <h2 className="mt-1 text-3xl font-bold tracking-tight text-black">Bildirim ve Aktivite Merkezi</h2>
          <div className="mt-3"><StatusMessage busy={isNotificationsLoading || isActivityLoading} message={message} /></div>
        </div>
        <div className="flex flex-wrap gap-2">
          {canViewActivity ? <ExecutiveReportDownload apiBaseUrl={apiBaseUrl} disabled={isNotificationsLoading || isActivityLoading} fileBaseName="aktivite-denetim-raporu" label="Aktivite Raporu" path="/api/exports/activity" token={token} onMessage={setMessage} /> : null}
          <button className="flex items-center gap-2 border border-[#3755C3] px-4 py-2 text-sm font-semibold text-[#3755C3] transition-colors hover:bg-[#DDE1FF] disabled:cursor-wait disabled:opacity-60" disabled={isNotificationsLoading || isActivityLoading} type="button" onClick={handleRefresh}>
            <span className="material-symbols-outlined text-[18px]">refresh</span>
            Yenile
          </button>
        </div>
      </div>

      <div className="mb-6 grid gap-4 md:grid-cols-4">
        <SummaryCard icon="notifications_unread" label="Okunmamış" tone="danger" value={notifications.unreadCount} />
        <SummaryCard icon="notifications" label="Toplam Bildirim" tone="blue" value={notifications.totalCount} />
        <SummaryCard icon="priority_high" label="Listelenen Kritik" tone="amber" value={listedCriticalCount} />
        <SummaryCard icon="mark_email_unread" label="Listelenen Okunmamış" tone="neutral" value={listedUnreadCount} />
      </div>

      <div className="grid gap-6 xl:grid-cols-[minmax(0,1fr)_520px]">
        <section className="rounded-lg border border-[#C6C6CD] bg-white shadow-[0px_1px_3px_rgba(15,23,42,0.08)]">
          <div className="border-b border-[#C6C6CD] p-4">
            <div className="flex flex-col gap-3 lg:flex-row lg:items-center lg:justify-between">
              <div>
                <h3 className="text-xl font-bold text-black">Bildirimler</h3>
                <p className="mt-1 text-sm text-[#45464D]">Kullanıcıya ait operasyon bildirimleri ve okundu durumu.</p>
              </div>
              <div className="flex flex-wrap gap-2">
                {readFilters.map((filter) => (
                  <button className={filterButtonClass(readFilter === filter.value)} disabled={isNotificationsLoading} key={filter.value} type="button" onClick={() => handleReadFilterChange(filter.value)}>{filter.label}</button>
                ))}
                <select className="h-9 border border-[#C6C6CD] bg-white px-3 text-[13px] font-semibold text-[#1B1B1D] outline-none focus:border-2 focus:border-[#3755C3]" disabled={isNotificationsLoading} value={typeFilter} onChange={(event) => handleTypeFilterChange(event.target.value)}>
                  <option value="">Tüm Tipler</option>
                  {notificationTypes.map((type) => <option key={type} value={type}>{notificationTypeLabels[type]}</option>)}
                </select>
                {notifications.unreadCount > 0 ? <button className="h-9 bg-black px-3 text-[13px] font-semibold text-white disabled:bg-[#76777D]" disabled={isNotificationsLoading} type="button" onClick={handleMarkAllAsRead}>Tümünü Okundu Yap</button> : null}
              </div>
            </div>
          </div>
          <div className="divide-y divide-[#C6C6CD]">
            {notifications.items.map((notification) => (
              <article className={`${notification.isRead ? 'bg-white' : 'bg-[#FCF8FA]'} p-4`} key={notification.id}>
                <div className="flex flex-col gap-3 md:flex-row md:items-start md:justify-between">
                  <div className="min-w-0">
                    <div className="mb-2 flex flex-wrap items-center gap-2">
                      <span className={`border px-2 py-1 text-[11px] font-bold uppercase tracking-wide ${notificationTypeClasses[notification.type]}`}>{notificationTypeLabels[notification.type]}</span>
                      <span className={`px-2 py-1 text-[11px] font-bold uppercase tracking-wide ${notification.isRead ? 'bg-[#E4E2E4] text-[#45464D]' : 'bg-black text-white'}`}>{notification.isRead ? 'Okundu' : 'Okunmamış'}</span>
                      {notification.relatedEntityName ? <span className="font-mono text-[11px] text-[#76777D]">{notification.relatedEntityName}</span> : null}
                    </div>
                    <h4 className="text-base font-bold text-black">{notification.title}</h4>
                    <p className="mt-1 text-sm leading-6 text-[#45464D]">{notification.message}</p>
                    <p className="mt-2 font-mono text-xs text-[#76777D]">{formatDateTime(notification.createdAt)}</p>
                  </div>
                  {!notification.isRead ? <button className="shrink-0 border border-[#C6C6CD] px-3 py-2 text-[13px] font-semibold text-[#1B1B1D] transition-colors hover:bg-[#F6F3F5] disabled:opacity-60" disabled={isNotificationsLoading} type="button" onClick={() => handleMarkAsRead(notification)}>Okundu Yap</button> : null}
                </div>
              </article>
            ))}
            {notifications.items.length === 0 ? <EmptyState text={isNotificationsLoading ? 'Bildirimler yükleniyor...' : 'Bu filtrelerle bildirim bulunamadı.'} /> : null}
          </div>
        </section>

        <aside className="space-y-4">
          <section className="rounded-lg border border-[#C6C6CD] bg-white p-4 shadow-[0px_1px_3px_rgba(15,23,42,0.08)]">
            <h3 className="text-lg font-bold text-black">Aktivite Yetkisi</h3>
            <p className="mt-2 text-sm leading-6 text-[#45464D]">{canViewActivity ? 'Bu kullanıcı sistem aktivite geçmişini görüntüleyebilir.' : 'Bu rol için sistem aktivite geçmişi gizlenir; bildirim ekranı kullanılabilir.'}</p>
            <div className="mt-4 grid grid-cols-3 gap-2 text-center text-xs">
              {activityRoles.map((role) => <span className="border border-[#C6C6CD] bg-[#F6F3F5] px-2 py-2 font-semibold text-[#45464D]" key={role}>{role}</span>)}
            </div>
          </section>

          {canViewActivity ? (
            <section className="rounded-lg border border-[#C6C6CD] bg-white shadow-[0px_1px_3px_rgba(15,23,42,0.08)]">
              <div className="border-b border-[#C6C6CD] p-4">
                <h3 className="text-xl font-bold text-black">Aktivite Geçmişi</h3>
                <p className="mt-1 text-sm text-[#45464D]">Audit log kayıtları ve sistem işlem izleri.</p>
                <div className="mt-4 grid gap-3 sm:grid-cols-2">
                  <select className="report-input" value={activityFilters.entityName} onChange={(event) => setActivityFilters((current) => ({ ...current, entityName: event.target.value }))}>
                    <option value="">Tüm Entityler</option>
                    {entityOptions.map((entity) => <option key={entity} value={entity}>{entity}</option>)}
                  </select>
                  <select className="report-input" value={activityFilters.action} onChange={(event) => setActivityFilters((current) => ({ ...current, action: event.target.value }))}>
                    <option value="">Tüm İşlemler</option>
                    {actionOptions.map((action) => <option key={action} value={action}>{actionLabels[action] ?? action}</option>)}
                  </select>
                  <input className="report-input" type="date" value={activityFilters.from} onChange={(event) => setActivityFilters((current) => ({ ...current, from: event.target.value }))} />
                  <input className="report-input" type="date" value={activityFilters.to} onChange={(event) => setActivityFilters((current) => ({ ...current, to: event.target.value }))} />
                </div>
                <div className="mt-3 flex flex-wrap gap-2">
                  <button className="bg-black px-4 py-2 text-[13px] font-semibold text-white disabled:bg-[#76777D]" disabled={isActivityLoading} type="button" onClick={handleApplyActivityFilters}>Filtrele</button>
                  <button className="border border-[#C6C6CD] px-4 py-2 text-[13px] font-semibold text-[#45464D] transition-colors hover:bg-[#F6F3F5]" disabled={isActivityLoading} type="button" onClick={handleClearActivityFilters}>Temizle</button>
                </div>
              </div>
              <div className="max-h-[760px] divide-y divide-[#C6C6CD] overflow-y-auto">
                {activity.items.map((item) => (
                  <article className="p-4" key={item.id}>
                    <div className="mb-2 flex flex-wrap items-center gap-2">
                      <span className="bg-[#DDE1FF] px-2 py-1 text-[11px] font-bold uppercase tracking-wide text-[#3755C3]">{item.entityName}</span>
                      <span className="bg-[#F6F3F5] px-2 py-1 text-[11px] font-bold uppercase tracking-wide text-[#45464D]">{actionLabels[item.action] ?? item.action}</span>
                    </div>
                    <p className="text-sm font-bold text-black">{item.userName ?? 'Sistem'} <span className="font-normal text-[#45464D]">{item.userRole ? `- ${item.userRole}` : ''}</span></p>
                    <p className="mt-1 font-mono text-xs text-[#76777D]">{formatDateTime(item.createdAt)}{item.ipAddress ? ` • ${item.ipAddress}` : ''}</p>
                  </article>
                ))}
                {activity.items.length === 0 ? <EmptyState text={isActivityLoading ? 'Aktivite kayıtları yükleniyor...' : 'Bu filtrelerle aktivite kaydı bulunamadı.'} /> : null}
              </div>
            </section>
          ) : null}
        </aside>
      </div>
    </section>
  )
}

function SummaryCard({ icon, label, tone, value }: { icon: string; label: string; tone: 'blue' | 'danger' | 'amber' | 'neutral'; value: number }) {
  const toneClass = tone === 'danger' ? 'bg-[#FEE2E2] text-[#BA1A1A]' : tone === 'amber' ? 'bg-[#FFEDD5] text-[#C2410C]' : tone === 'blue' ? 'bg-[#DDE1FF] text-[#3755C3]' : 'bg-[#F6F3F5] text-[#45464D]'

  return (
    <div className="rounded-lg border border-[#C6C6CD] bg-white p-4 shadow-[0px_1px_3px_rgba(15,23,42,0.08)]">
      <div className="flex items-start justify-between gap-3">
        <div>
          <p className="text-[11px] font-bold uppercase tracking-wide text-[#45464D]">{label}</p>
          <p className="mt-2 font-mono text-3xl font-bold text-black">{value}</p>
        </div>
        <span className={`${toneClass} material-symbols-outlined rounded-full p-2 text-[22px]`}>{icon}</span>
      </div>
    </div>
  )
}

function EmptyState({ text }: { text: string }) {
  return <div className="p-8 text-center text-sm text-[#45464D]">{text}</div>
}

function filterButtonClass(active: boolean) {
  return `${active ? 'bg-black text-white' : 'border border-[#C6C6CD] bg-white text-[#1B1B1D] hover:bg-[#F6F3F5]'} h-9 px-3 text-[13px] font-semibold transition-colors disabled:opacity-60`
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

async function notificationRequest<T>(apiBaseUrl: string, token: string, path: string, options: RequestInit = {}): Promise<T> {
  const headers = new Headers(options.headers)
  headers.set('Authorization', `Bearer ${token}`)
  if (options.body && !headers.has('Content-Type')) {
    headers.set('Content-Type', 'application/json')
  }

  return requestJson<T>(`${apiBaseUrl}${path}`, { ...options, headers })
}

export default NotificationsView
