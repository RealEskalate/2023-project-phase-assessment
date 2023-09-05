import { language } from "./language";

export interface speciality {
  _id: string;
  isSubspeciality: boolean;
  name: string;
  lang: language;
}
