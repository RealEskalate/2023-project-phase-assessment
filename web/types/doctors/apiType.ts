import { DoctorProfile } from "./models";

export type ApiResponse = {
  data: DoctorProfile[];
  success: boolean;
  message: string;
  totalCount: number;
}