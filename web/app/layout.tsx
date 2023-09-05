"use client";
import "./globals.css";
import Navbar from "../component/Navbar";
import Footer from "../component/Footer";
import { Provider } from "react-redux";
import store from "../Reducer/store";

export default function RootLayout({
  children,
}: {
  children: React.ReactNode;
}) {
  return (
    <Provider store={store}>
      <Navbar />
      {children}
      <Footer />
    </Provider>
  );
}
