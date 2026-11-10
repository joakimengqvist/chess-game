// Backend base URL. Set VITE_API_URL at build time (e.g. https://<backend-domain>).
export const API_URL: string = (
  import.meta.env.VITE_API_URL ?? 'http://localhost:5069'
).replace(/\/+$/, '');
