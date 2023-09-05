type ObjectId = string;

export type LangData = {
    name: string;
    description?: string;
};

export interface Language<T> {
    am: T;
}

export interface Service {
    _id: ObjectId;
    title: string;
    description: string;
    lang: Language<{
        title: string;
        description: string;
    }>;
}

export interface Availability {
    twentyFourHours: boolean;
    startDay: string;
    endDay: string;
    opening: string;
    closing: string;
}

export interface MainInstitution {
    _id: ObjectId;
    availability: Availability;
    services: Service[];
    institutionName: string;
    summary: string;
    lang: Language<{
        institutionName: string;
        summary: string;
    }>;
}

export interface Location {
    lat: number;
    long: number;
}

export interface Hospital {
    _id: ObjectId;
    name: string;
    location: Location;
    mainInstitution: MainInstitution;
    lang: Language<{
        name: string;
    }>;
}

export type Speciality = {
    _id: string;
    isSubspeciality: boolean;
    name: string;
    lang: {
        am: LangData;
    };
};

export type Address = {
    region: string;
    summary: string;
    woreda: string;
    zone: string;
};

export type InstitutionID = {
    _id: string;
    institutionName: string;
    lang: {
        am: {
            institutionName: string;
            summary: string;
            address: Address;
            institutionName_fuzzy: string[];
        };
    };
};

export type DoctorProfile = {
    _id: string;
    phoneNumbers: string[];
    emails: string[];
    photo: string;
    summary: string;
    speciality: Speciality[];
    experience_years: number;
    institutionID_list: InstitutionID[];
    mainInstitution: MainInstitution;
    gender: 'Male' | 'Female';  // You can expand this union type if there are other gender values.
    languages: string[];
    birthday: string;
    otherDocuments: any[];  // Replace 'any' with the specific type if available.
    experience: any[];  // Replace 'any' with the specific type if available.
    fullName: string;
    education: any[];  // Replace 'any' with the specific type if available.
};

interface Data {
    hospitals: Hospital[];
}
