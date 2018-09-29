import { CarType } from "./car-type.model";
import { Branch } from "./branch.model";

export interface Car{
    CarType: CarType,
    CurrentMileage:number,
    Img: string,
    IsProperForRent:boolean,
    CarNumber:string,
    Branch: Branch
}