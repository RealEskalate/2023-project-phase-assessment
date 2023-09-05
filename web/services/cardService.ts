"use client";
import axios from "axios";

const API_BASE_URL = "https://hakimhub-api-dev-wtupbmwpnq-uc.a.run.app/api/v1/";

export const fetchDoctors = async () => {
  const response =
    await axios.get(`${API_BASE_URL}/search?institutions=false&articles=False
  `);
  return response.data;
};

export const fetchDoctorDetail = async (cardId: string) => {
  const response = await axios.get(
    `${API_BASE_URL}/users/doctorProfile/${cardId}`
  );
  return response.data;
};
