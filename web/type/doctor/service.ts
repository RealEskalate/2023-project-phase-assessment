import {Language} from "@/type/doctor/language";
export interface Service {
    _id: string;
    title: string;
    description: string;
    lang: Language;
}