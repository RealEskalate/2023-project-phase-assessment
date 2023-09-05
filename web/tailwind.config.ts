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
        primary: "#FF7272",
        subPrimary: "#7879F1",
        grayMedium: "#424242",
        background: "#FFFFFF",
        lightGray: "#DFDFE2",
        lightGray2: "#DCD0D0",
      },
    },
  },
  plugins: [],
};
export default config;
