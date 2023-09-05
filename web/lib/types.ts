export interface Availability {
  twentyFourHours: boolean;
  startDay: string;
  endDay: string;
  opening: string;
  closing: string;
}

export interface Institution {
  _id: string;
  institutionName: string;
  lang: {
    am: {
      name: string;
      description: string;
    };
  };
}

export interface Service {
  _id: string;
  name: string;
  lang: {
    am: {
      name: string;
      description: string;
    };
  };
}

export interface Language {
  [index: number]: string;
  length: number;
}

export interface Speciality {
  isSubspeciality: boolean;
  lang: {
    am: {
      name: string;
      description: string;
    };
  };
  name: string;
  _id: string;
}

export interface ApiResponse {
  availability: Availability;
  birthday: string;
  education: any[];
  emails: any[];
  experience: any[];
  experience_years: number;
  fullName: string;
  fullName_fuzzy: string[];
  gender: string;
  institutionID_list: Institution[];
  languages: Language;
  mainInstitution: {
    availability: Availability;
    institutionName: string;
    lang: {
      am: {
        name: string;
        description: string;
      };
    };
    services: Service[];
    summary: string;
  };
  _id: string;
  otherDocuments: any[];
  phoneNumbers: any[];
  photo: string;
  score: number;
  source: string;
  speciality: Speciality[];
  summary: string;
  __v: number;
}
