import { Address } from "./Address";
import { Availability } from "./Availability";
import { Rating } from "./Rating";

export interface Doctor {
  availability: Availability[]; // You may want to define a proper type for 'availability'
  birthday: string;
  education: any[]; // You may want to define a proper type for 'education'
  emails: any[]; // You may want to define a proper type for 'emails'
  experience: any[]; // You may want to define a proper type for 'experience'
  experience_years: number;
  fullName: string;
  fullName_fuzzy: string[];
  gender: string;
  institutionID_list: any[]; // You may want to define a proper type for 'institutionID_list'
  languages: string[];
  mainInstitution: {
    _id: string;
    availability: any; // You may want to define a proper type for 'availability'
    services: any[]; // You may want to define a proper type for 'services'
    institutionName: string;
    summary: string;
    // Add other properties from 'mainInstitution' as needed
  };
  otherDocuments: any[]; // You may want to define a proper type for 'otherDocuments'
  phoneNumbers: any[]; // You may want to define a proper type for 'phoneNumbers'
  photo: string;
  score: number;
  source: string;
  speciality: any[]; // You may want to define a proper type for 'speciality'
  summary: string;
  __v: number;
  _id: string;
}
