// Single source of truth for the Boopin Tailwind theme.
// - In the browser (Tailwind Play CDN) it is read as the global `boopinTheme`.
// - In Node (optional production build) tailwind.config.js require()s it.
const boopinTheme = {
  colors: {
    plum: { 600: '#4d3175', 700: '#3a2459', 800: '#2a1a42', 900: '#1e1230', 950: '#150d1f' },
    lavender: { 100: '#f1eaff', 200: '#e0d2ff', 300: '#c9b3ff', 400: '#b095f5', 500: '#957ae0' },
    blush: { 200: '#ffd3e6', 300: '#ffb3d4', 400: '#ff8fbf', 500: '#ff6aa8' },
    mint: { 200: '#ccf5e6', 300: '#a8ecd2', 400: '#7fdcb9' }
  },
  fontFamily: {
    display: ['Fredoka', 'ui-rounded', 'system-ui', 'sans-serif'],
    sans: ['Nunito', 'ui-sans-serif', 'system-ui', 'sans-serif']
  },
  boxShadow: {
    glow: '0 0 32px rgba(255, 143, 191, 0.35)',
    soft: '0 12px 40px rgba(10, 4, 20, 0.45)'
  },
  keyframes: {
    float: {
      '0%, 100%': { transform: 'translateY(0) rotate(var(--tw-rotate, 0deg))' },
      '50%': { transform: 'translateY(-12px) rotate(var(--tw-rotate, 0deg))' }
    },
    pop: {
      '0%': { opacity: '0', transform: 'translateY(16px) scale(0.97)' },
      '100%': { opacity: '1', transform: 'translateY(0) scale(1)' }
    },
    toast: {
      '0%': { opacity: '0', transform: 'translateY(12px) scale(0.96)' },
      '100%': { opacity: '1', transform: 'translateY(0) scale(1)' }
    }
  },
  animation: {
    float: 'float 6s ease-in-out infinite',
    pop: 'pop 0.25s ease-out both',
    toast: 'toast 0.3s ease-out both'
  }
};

if (typeof module !== 'undefined' && module.exports) {
  module.exports = boopinTheme;
}
