import { User } from "./user.model";
import { Car } from "./car.model";

export interface Order{
    StartDate:Date,
    ReturnDate:Date,
    ActualReturnDate:Date,
    User: User,
    Car:Car
}