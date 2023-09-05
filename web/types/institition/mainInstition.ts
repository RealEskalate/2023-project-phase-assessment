import { availability } from "./availability";
import { service } from "./service";

export interface mainInstitution {
  _id: string;
  availability: availability;
  services: service[];
  institutionName: string;
  summary: string;
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
