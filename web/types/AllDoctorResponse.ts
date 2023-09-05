import { Doctor } from "./Doctor";

export type AllDoctorResponse = {
  data: Doctor[];
  success: boolean;
  message: string;
  totalCount: number;
}