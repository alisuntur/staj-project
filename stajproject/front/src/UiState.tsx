import type { ReactNode } from 'react'

type StatusMessageProps = {
  busy?: boolean
  message: string
}

type EmptyStateProps = {
  action?: ReactNode
  icon?: string
  text: string
  title: string
}

type LoadingPanelProps = {
  text?: string
  title: string
}

export function StatusMessage({ busy = false, message }: StatusMessageProps) {
  const tone = statusTone(message)
  const className = tone === 'danger'
    ? 'border-[#FFDAD6] bg-[#FFF1F0] text-[#7F1D1D]'
    : tone === 'success'
      ? 'border-[#BBF7D0] bg-[#F0FDF4] text-[#166534]'
      : 'border-[#C6C6CD] bg-[#F6F3F5] text-[#45464D]'

  return (
    <div className={`${className} flex items-start gap-3 border p-3 text-[13px] leading-5`} role="status">
      {busy ? <Spinner /> : <span className="material-symbols-outlined mt-0.5 text-[18px]">{tone === 'danger' ? 'error' : tone === 'success' ? 'check_circle' : 'info'}</span>}
      <span>{message}</span>
    </div>
  )
}

export function EmptyState({ action, icon = 'inbox', text, title }: EmptyStateProps) {
  return (
    <div className="p-8 text-center text-sm text-[#45464D]">
      <span className="material-symbols-outlined mx-auto mb-3 flex h-11 w-11 items-center justify-center rounded-full bg-[#F6F3F5] text-[24px] text-[#76777D]">{icon}</span>
      <p className="text-base font-bold text-[#1B1B1D]">{title}</p>
      <p className="mx-auto mt-1 max-w-md leading-6">{text}</p>
      {action ? <div className="mt-4 flex justify-center">{action}</div> : null}
    </div>
  )
}

export function LoadingPanel({ text = 'Veriler hazırlanıyor, lütfen bekleyin.', title }: LoadingPanelProps) {
  return (
    <div className="rounded-lg border border-[#C6C6CD] bg-white p-6 shadow-[0px_1px_3px_rgba(15,23,42,0.08)]">
      <div className="flex items-center gap-4">
        <Spinner size="lg" />
        <div>
          <p className="text-base font-bold text-[#1B1B1D]">{title}</p>
          <p className="mt-1 text-sm text-[#45464D]">{text}</p>
        </div>
      </div>
    </div>
  )
}

export function TableState({ colSpan, isLoading, loadingText, text, title }: { colSpan: number; isLoading: boolean; loadingText: string; text: string; title: string }) {
  return (
    <tr>
      <td colSpan={colSpan}>
        {isLoading ? <LoadingPanel title={loadingText} /> : <EmptyState text={text} title={title} />}
      </td>
    </tr>
  )
}

function Spinner({ size = 'sm' }: { size?: 'sm' | 'lg' }) {
  return <span className={`${size === 'lg' ? 'h-8 w-8' : 'h-4 w-4'} inline-flex shrink-0 animate-spin rounded-full border-2 border-[#C6C6CD] border-t-[#3755C3]`} aria-hidden />
}

function statusTone(message: string) {
  const normalized = message.toLowerCase()
  if (normalized.includes('hata') || normalized.includes('ulaşılamıyor') || normalized.includes('başarısız') || normalized.includes('yetkiniz yok') || normalized.includes('doğrulanamadı')) {
    return 'danger'
  }

  if (normalized.includes('oluşturuldu') || normalized.includes('güncellendi') || normalized.includes('indirildi') || normalized.includes('yüklendi') || normalized.includes('hazırlandı') || normalized.includes('yenilendi')) {
    return 'success'
  }

  return 'default'
}
