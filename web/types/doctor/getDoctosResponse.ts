import { doctor } from "./doctor";

export interface getDoctosResponse {
  success: true;
  message: "";
  totalCount: 59;
  data: doctor[];
}
