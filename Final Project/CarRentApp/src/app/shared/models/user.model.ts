import { UserRole } from "./user-role.model";

export interface User{
     FullName:string,
     IdCard:string,
     UserName:string,
     DoB?: Date,
     IsMale: boolean,
     EmailAddress:string,
     Passwd: string,
     Role:UserRole,
     Img?:string
     
}