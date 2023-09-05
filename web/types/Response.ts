import { Doctor } from "./Doctor";

export interface Response {
    success: boolean;
    message: string;
    totalCount?: Number;
    data: Doctor | Doctor[]
}
