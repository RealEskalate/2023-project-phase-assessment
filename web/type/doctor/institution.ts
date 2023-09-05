import {Language} from "@/type/doctor/language";
import {Address} from "@/type/doctor/address";

export interface Institution {
    _id: string;
    institutionName: string;
    summary: string;
    lang: Language;
    address: Address;
    institutionName_fuzzy: string[];
}