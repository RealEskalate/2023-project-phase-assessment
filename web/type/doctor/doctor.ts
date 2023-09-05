import {Institution} from "@/type/doctor/institution";
import {Availability} from "@/type/doctor/availablity";

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
    otherDocuments: any[]; // You can replace 'any' with the actual type
    experience: any[]; // You can replace 'any' with the actual type
    fullName: string;
    mainInstitution: Institution;
    education: any[]; // You can replace 'any' with the actual type
    availablity: Availability[]; // Correct the typo in 'availability'
    __v: number;
    fullName_fuzzy: string[];
    source: string;
    score: number;
}
