import type { Config } from "tailwindcss";

const config: Config = {
  content: [
    "./pages/**/*.{js,ts,jsx,tsx,mdx}",
    "./components/**/*.{js,ts,jsx,tsx,mdx}",
    "./app/**/*.{js,ts,jsx,tsx,mdx}",
  ],
  theme: {
    extend: {
      colors: {
        primary: "#7879F1",
        secondary: "#686868",
      },
      fontFamily: {
        custom: ["Poppins", "sans"],
      },
    },
  },
  plugins: [],
};
export default config;
