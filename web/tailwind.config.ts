import type { Config } from 'tailwindcss'

const config: Config = {
  content: [
    './pages/**/*.{js,ts,jsx,tsx,mdx}',
    './components/**/*.{js,ts,jsx,tsx,mdx}',
    './app/**/*.{js,ts,jsx,tsx,mdx}',
  ],
  theme: {
    extend: {
      colors: {
        primaryColor: {
          100: "#7879F1",
          200: "#6C63FF",
        },
        secondaryColor: "#FF7272",
        textBlack: {
          100: "#686868",
          200: "#FF7272",
          300: "#3F3F3F",
          400: "#424242",
        },
        textWhite: "#FFF",
      }
    },
  },
  plugins: [],
}
export default config
