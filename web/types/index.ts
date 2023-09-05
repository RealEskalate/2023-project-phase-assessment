export interface Doctor{
    _id: string;
    phoneNumbers: string[];
    emails: string[];
    photo: string;
    summary: string;
    speciality: {
      _id: string;
      isSubspeciality: boolean;
      name: string;
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
      institutionName: string;
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
    experience: string[];
    fullName: string;
    mainInstitution: {
      _id: string;
      availability: {
        twentyFourHours: boolean;
        startDay: string;
        endDay: string;
        opening: string;
        closing: string;
      };
      services: {
        _id: string;
        title: string;
        description: string;
        lang: {
          am: {
            title: string;
            description: string;
          };
        };
      }[];
      institutionName: string;
      summary: string;
      lang: {
        am: {
          institutionName: string;
          summary: string;
        };
      };
    };
    education: string[];
    availability: string[];
    __v: number;
    fullName_fuzzy: string[];
    source: string;
    score: number;
  }
export interface SearchDoctorsResponse {
    doctors: Doctor[];
    totalItems: number;
}