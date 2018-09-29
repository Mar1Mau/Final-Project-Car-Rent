import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs/Observable";
import { CarType } from "../models/car-type.model";

@Injectable()
export class CarTypeService{
   
    myUIrl: string = 'http://localhost:12288/api/CarTypes';
 
    constructor(private myHttpClient: HttpClient) { }

    public getAllCarTypes():Observable<CarType> {
        return this.myHttpClient.get<CarType>(this.myUIrl);
    }

    public addCarType(carType: CarType, callback: (bool: boolean) => void): void {
        this.myHttpClient.post(this.myUIrl, JSON.stringify(carType), { headers: { "content-type": "application/json" } }).subscribe(() => { this.getAllCarTypes(); callback(true); },
            () => { callback(false) });

    }

   

    public editCarType(carType: CarType, model: string, callback: (bool: boolean) => void): void {
       this.myHttpClient.put<boolean>(`${this.myUIrl}?Model=${model}`, JSON.stringify(carType), { headers: { "content-type": "application/json" } })
         .subscribe(() => { this.getAllCarTypes(); callback(true); },
               () => { callback(false) });
    }

 
   

    getCarForEdit(model:string,callback:(carType:CarType)=>void): void {
       this.myHttpClient.get(`${this.myUIrl}?Model=${model}`)
       .subscribe((x:CarType) => { callback(x);});
    }


    public deleteCarType(type: string): Observable<CarType> {
        let apiUrl: string = `${this.myUIrl}?Model=${type}`;
       return this.myHttpClient.delete<CarType>(apiUrl);
    }
}
