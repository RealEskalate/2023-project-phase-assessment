import type { Config } from 'tailwindcss'

const config: Config = {
  content: [
    './pages/**/*.{js,ts,jsx,tsx,mdx}',
    './components/**/*.{js,ts,jsx,tsx,mdx}',
    './app/**/*.{js,ts,jsx,tsx,mdx}',
  ],
  theme: {
    extend: {
      backgroundColor:{
        primary: "#7879F1"
      },
      fontFamily:{
        poppins: ['Poppins', "sans-serif"]
      }
    },
  },
  plugins: [],
}
export default config
