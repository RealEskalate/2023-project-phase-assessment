interface DoctorInfo {
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
    otherDocuments: any[]; // You might want to provide a more specific type here
    experience: any[]; // You might want to provide a more specific type here
    fullName: string;
    mainInstitution: Institution;
    education: any[]; // You might want to provide a more specific type here
    availablity: any[]; // You might want to provide a more specific type here
    __v: number;
    fullName_fuzzy: string[];
    source: string;
    score: number;
  }
  
  interface Speciality {
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
  
  interface Institution {
    _id: string;
    institutionName: string;
    lang: {
      am: {
        institutionName: string;
        summary: string;
      };
    };
    availability?: {
      twentyFourHours: boolean;
      startDay: string;
      endDay: string;
      opening: string;
      closing: string;
    };
    services?: Service[];
    address?: {
      region: string;
      summary: string;
      woreda: string;
      zone: string;
    };
    institutionName_fuzzy?: string[];
  }
  
  interface Service {
    _id: string;
    title: string;
    description: string;
    lang: {
      am: {
        title: string;
        description: string;
      };
    };
  }
  
  export interface single_Doctor {
    success: boolean;
    message: string;
    totalCount: number;
    data: DoctorInfo[];
  }
  