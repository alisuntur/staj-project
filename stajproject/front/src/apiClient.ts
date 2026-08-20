const connectionErrorMessage = 'API sunucusuna ulaşılamıyor. Backend penceresinin açık olduğundan ve API adresinin doğru olduğundan emin olun.'

export async function requestJson<T>(url: string, options: RequestInit = {}): Promise<T> {
  const response = await safeFetch(url, options)
  const payload = await readPayload(response)

  if (!response.ok) {
    throw new Error(apiStatusMessage(response.status, extractServerMessage(payload)))
  }

  return payload as T
}

export async function requestBlob(url: string, options: RequestInit = {}): Promise<Blob> {
  const response = await safeFetch(url, options)

  if (!response.ok) {
    const payload = await readPayload(response)
    throw new Error(apiStatusMessage(response.status, extractServerMessage(payload)))
  }

  return response.blob()
}

export function friendlyErrorMessage(error: unknown, fallback = 'İşlem tamamlanamadı. Lütfen tekrar deneyin.') {
  if (!(error instanceof Error)) {
    return fallback
  }

  const message = error.message.trim()
  if (!message) {
    return fallback
  }

  if (isNetworkError(message)) {
    return connectionErrorMessage
  }

  return message
}

async function safeFetch(url: string, options: RequestInit) {
  try {
    return await fetch(url, options)
  } catch {
    throw new Error(connectionErrorMessage)
  }
}

async function readPayload(response: Response) {
  const text = await response.text()
  if (!text) {
    return null
  }

  try {
    return JSON.parse(text) as unknown
  } catch {
    return text
  }
}

function extractServerMessage(payload: unknown) {
  if (payload && typeof payload === 'object' && 'message' in payload) {
    const message = (payload as { message?: unknown }).message
    return typeof message === 'string' ? message.trim() : ''
  }

  return typeof payload === 'string' ? payload.trim() : ''
}

function apiStatusMessage(status: number, serverMessage: string) {
  if (status === 400) {
    return serverMessage || 'Girilen bilgileri kontrol edip tekrar deneyin.'
  }

  if (status === 401) {
    return 'Oturum doğrulanamadı. Lütfen yeniden giriş yapın.'
  }

  if (status === 403) {
    return 'Bu işlem için yetkiniz yok.'
  }

  if (status === 404) {
    return 'İstenen kayıt bulunamadı veya artık erişilebilir değil.'
  }

  if (status === 409) {
    return serverMessage || 'Bu işlem mevcut kayıtlarla çakışıyor. Listeyi yenileyip tekrar deneyin.'
  }

  if (status >= 500) {
    return 'Sunucu tarafında beklenmeyen bir hata oluştu. API penceresindeki logları kontrol edin.'
  }

  return serverMessage || `İşlem tamamlanamadı. HTTP ${status}`
}

function isNetworkError(message: string) {
  const normalized = message.toLowerCase()
  return normalized.includes('failed to fetch') || normalized.includes('networkerror') || normalized.includes('load failed') || normalized.includes('ulaşılamıyor')
}
