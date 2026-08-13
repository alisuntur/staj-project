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
  async function download(format: 'xlsx' | 'pdf') {
    try {
      onMessage?.(`${format === 'xlsx' ? 'Excel' : 'PDF'} raporu hazırlanıyor...`)
      const normalizedUrl = path.includes('?') ? `${apiBaseUrl}${path.replace('?', `/${format}?`)}` : `${apiBaseUrl}${path}/${format}`

      const response = await fetch(normalizedUrl, {
        headers: { Authorization: `Bearer ${token}` },
      })

      if (!response.ok) {
        const text = await response.text()
        let message = `Rapor indirilemedi: ${response.status}`
        if (text) {
          try {
            message = (JSON.parse(text) as { message?: string }).message ?? message
          } catch {
            message = text
          }
        }
        throw new Error(message)
      }

      const blob = await response.blob()
      const objectUrl = URL.createObjectURL(blob)
      const link = document.createElement('a')
      link.href = objectUrl
      link.download = `${fileBaseName}-${new Date().toISOString().slice(0, 10)}.${format}`
      document.body.appendChild(link)
      link.click()
      link.remove()
      URL.revokeObjectURL(objectUrl)
      onMessage?.(`${format === 'xlsx' ? 'Excel' : 'PDF'} raporu indirildi.`)
    } catch (error) {
      onMessage?.(error instanceof Error ? error.message : 'Rapor indirilemedi.')
    }
  }

  return (
    <div className="flex flex-wrap gap-2">
      <button className="flex items-center gap-2 border border-[#3755C3] bg-white px-4 py-2 text-sm font-semibold text-[#3755C3] transition-colors hover:bg-[#DDE1FF] disabled:cursor-not-allowed disabled:opacity-50" disabled={disabled} type="button" onClick={() => void download('xlsx')}>
        <span className="material-symbols-outlined text-[18px]">table_chart</span>
        {label} Excel
      </button>
      <button className="flex items-center gap-2 border border-[#BA1A1A] bg-white px-4 py-2 text-sm font-semibold text-[#BA1A1A] transition-colors hover:bg-[#FFDAD6] disabled:cursor-not-allowed disabled:opacity-50" disabled={disabled} type="button" onClick={() => void download('pdf')}>
        <span className="material-symbols-outlined text-[18px]">picture_as_pdf</span>
        PDF
      </button>
    </div>
  )
}
