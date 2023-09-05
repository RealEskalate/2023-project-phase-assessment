export interface Doctor {
  _id: string;
  emails: string[];
  photo: string;
  summary: string;
  speciality: {
    _id: string;
    isSubspeciality: boolean;
    name_fuzzy: string[];
    name: string;
    created_at: string;
    updated_at: string;
    __v: number;
    lang: {
      am: {
        name: string;
        description: string;
      };
    };
  }[];
  experience_years: number;
  institutionID_list: {
    _id: string;
    address: {
      region: string;
      summary: string;
      woreda: string;
      zone: string;
    };
    availability: {
      twentyFourHours: boolean;
      startDay: string;
      endDay: string;
      opening: string;
      closing: string;
    };
    institutionType: string;
    establishedOn: string;
    institutionName: string;
    location: {
      type: string;
      coordinates: [number, number];
    };
    lang: {
      am: {
        institutionName: string;
        summary: string;
      };
    };
  }[];
  gender: string;
  languages: string[];
  birthday: string;
  otherDocuments: string[];
  experience: any[]; // You might want to create a type for this if you have more information.
  fullName: string;
  mainInstitution: string;
  education: any[]; // You might want to create a type for this if you have more information.
  availablity: any[]; // You might want to create a type for this if you have more information.
  __v: number;
  fullName_fuzzy: string[];
}

