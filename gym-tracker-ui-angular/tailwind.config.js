/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    "./src/**/*.{html,ts}"
  ],
  theme: {
    extend: {
      colors: {
        SswRed: '#CC4141',
      },
    },
  },
  plugins: [
    require('@tailwindcss/typography'),
  ],
}

