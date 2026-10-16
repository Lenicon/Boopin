// Only used by the optional production CSS build (see README.md).
// The theme itself lives in wwwroot/js/tailwind-theme.js and is shared with the CDN setup.
const boopinTheme = require('./wwwroot/js/tailwind-theme.js');

/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ['./**/*.razor', './**/*.cs', './wwwroot/index.html'],
  theme: { extend: boopinTheme },
  plugins: []
};
