export interface Doctor {
  _id: string;
  emails: string[];
  photo: string; 
  summary: string;
  speciality: Speciality[];
  experience_years: number;
  institutionID_list: Institution[];
  gender: "Male" | "Female";
  languages: string[];
  birthday: string;
  otherDocuments: any[];
  experience: any[];
  fullName: string;
  mainInstitution: string;
  education: any[];
  availablity: any[];
  __v: number;
  fullName_fuzzy: string[];
}

export interface Speciality {
  _id: string;
  isSubspeciality: boolean;
  name_fuzzy: string[];
  name: string;
  created_at: string;
  updated_at: string;
  __v: number;
  lang: {
    [key: string]: {
      name: string;
      description: string; 
    }
  }
}

export interface Institution {
  _id: string;
  address: Address;
  availability: Availability;
  institutionType: "Hospital"; 
  establishedOn: string;
  institutionName: string;
  location: Location;
  lang: {
    [key: string]: {
      institutionName: string;
      summary: string;
    }
  }  
}

export interface Address {
  region: string;
  woreda: string; 
  zone: string;
  summary: string;
}

export interface Availability {
  twentyFourHours: boolean;
  startDay: string;
  endDay: string;
  opening: string;
  closing: string;  
}

export interface Location {
  type: string;
  coordinates: number[];
}