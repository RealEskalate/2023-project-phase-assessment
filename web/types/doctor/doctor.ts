import { institution } from "../institition/instition";
import { mainInstitution } from "../institition/mainInstition";
import { speciality } from "./speciality";

export interface doctor {
  _id: string;
  phoneNumbers: string[];
  emails: string[];
  photo: string;
  summary: string;
  speciality: speciality[];
  experience_years: number;
  institutionID_list: institution[];
  gender: string;
  languages: string[];
  birthday: string;
  otherDocuments: string[];
  experience: string[];
  fullName: string;
  mainInstitution: mainInstitution;
  education: string[];
  availablity: string[];
  __v: string;
  fullName_fuzzy: string[];
  source: string;
  score: number;
}
