export interface DoctorData {
    success: boolean;
    message: string;
    totalCount: number;
    data: Doctor[];
  }
  
  export interface Doctor {
    _id: string;
    phoneNumbers: string[];
    emails: string[];
    photo: string;
    summary: string;
    speciality: Speciality[];
    experience_years: number;
    institutionID_list: Institution[];
    gender: string;
    languages: string[];
    birthday: string;
    otherDocuments: any[]; // Replace with a specific type if available
    experience: any[]; // Replace with a specific type if available
    fullName: string;
    mainInstitution: Institution;
    education: Education[]; // Replace with a specific type if available
    availability: Availability[]; // Replace with a specific type if available
    __v: number;
    fullName_fuzzy: string[];
    source: string;
    score: number;
  }
  
  export interface Speciality {
    _id: string;
    isSubspeciality: boolean;
    name: string;
    lang: {
      am: {
        name: string;
        description: string;
      };
    };
  }
  
  export interface Institution {
    _id: string;
    institutionName: string;
    lang: {
      am: {
        institutionName: string;
        summary: string;
        address: {
          region: string;
          summary: string;
          woreda: string;
          zone: string;
        };
        institutionName_fuzzy: string[];
      };
    };
  }
  
  export interface Education {
    // Define the education fields based on the actual data
  }
  
  export interface Availability {
    // Define the availability fields based on the actual data
  }
  