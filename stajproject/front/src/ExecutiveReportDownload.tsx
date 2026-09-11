import { useState } from 'react'
import { friendlyErrorMessage, requestBlob } from './apiClient'

type ExecutiveReportDownloadProps = {
  apiBaseUrl: string
  token: string
  label?: string
  fileBaseName: string
  path: string
  disabled?: boolean
  onMessage?: (message: string) => void
}

export default function ExecutiveReportDownload({ apiBaseUrl, token, label = 'Rapor İndir', fileBaseName, path, disabled = false, onMessage }: ExecutiveReportDownloadProps) {
  const [activeFormat, setActiveFormat] = useState<'xlsx' | 'pdf' | null>(null)

  async function download(format: 'xlsx' | 'pdf') {
    if (activeFormat || disabled) {
      return
    }

    setActiveFormat(format)
    try {
      onMessage?.(`${format === 'xlsx' ? 'Excel' : 'PDF'} raporu hazırlanıyor...`)
      const normalizedUrl = path.includes('?') ? `${apiBaseUrl}${path.replace('?', `/${format}?`)}` : `${apiBaseUrl}${path}/${format}`
      const blob = await requestBlob(normalizedUrl, {
        headers: { Authorization: `Bearer ${token}` },
      })
      const objectUrl = URL.createObjectURL(blob)
      const link = document.createElement('a')
      link.href = objectUrl
      link.download = `${safeFileBaseName(fileBaseName)}-${downloadStamp()}.${format}`
      document.body.appendChild(link)
      link.click()
      link.remove()
      URL.revokeObjectURL(objectUrl)
      onMessage?.(`${format === 'xlsx' ? 'Excel' : 'PDF'} raporu indirildi.`)
    } catch (error) {
      onMessage?.(friendlyErrorMessage(error, 'Rapor indirilemedi.'))
    } finally {
      setActiveFormat(null)
    }
  }

  const isBusy = activeFormat !== null

  return (
    <div className="flex flex-wrap gap-2">
      <button className="flex items-center gap-2 rounded-xl border border-[#BFDBFE] bg-[#EFF6FF] px-4 py-2 text-sm font-bold text-[#2563EB] transition hover:bg-[#DBEAFE] disabled:cursor-not-allowed disabled:opacity-50" disabled={disabled || isBusy} type="button" onClick={() => void download('xlsx')}>
        <span className="material-symbols-outlined text-[18px]">table_chart</span>
        {activeFormat === 'xlsx' ? 'Hazırlanıyor...' : `${label} Excel`}
      </button>
      <button className="flex items-center gap-2 rounded-xl border border-[#FECACA] bg-[#FFF7F7] px-4 py-2 text-sm font-bold text-[#DC2626] transition hover:bg-[#FEE2E2] disabled:cursor-not-allowed disabled:opacity-50" disabled={disabled || isBusy} type="button" onClick={() => void download('pdf')}>
        <span className="material-symbols-outlined text-[18px]">picture_as_pdf</span>
        {activeFormat === 'pdf' ? 'Hazırlanıyor...' : `${label} PDF`}
      </button>
    </div>
  )
}

function safeFileBaseName(value: string) {
  return value.trim().toLowerCase().replace(/[^a-z0-9-]+/g, '-').replace(/^-+|-+$/g, '') || 'yonetici-raporu'
}

function downloadStamp() {
  const now = new Date()
  const date = now.toISOString().slice(0, 10)
  const time = `${String(now.getHours()).padStart(2, '0')}${String(now.getMinutes()).padStart(2, '0')}`
  return `${date}-${time}`
}
