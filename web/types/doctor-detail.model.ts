export interface doctorDetail {
  _id: string;
  fullName: string;
  emails: string[];
  photo: string;
  summary?: string;
  speciality?: [name: string];
  institutionID_list?: [institutionName: string];
  education?: string[];
}
