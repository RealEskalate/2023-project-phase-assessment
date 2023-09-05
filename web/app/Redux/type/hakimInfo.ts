interface Availability {
    twentyFourHours: boolean;
    startDay: string;
    endDay: string;
    opening: string;
    closing: string; 
  }
  

export interface HakimInfo {
    address: string[];
    availability: Availability;
    coverPhoto: string;
    doctors: Doctor[];
    emails: string[];
    establishedOn: string; 
    institutionName: string;
    institutionName_fuzzy: string[];
    institutionType: string;
    lang: {
      am: object; 
    };
    location: Location;
    phoneNumbers: string[];
    photo: string;
    pictures: string[];
    rating: Rating;
    score: number;
    services: Service[];
    source: string;
    speciality: string[];
    status: string;
    summary: string;
    website: string;
    __v: number;
    _id: string;
  }