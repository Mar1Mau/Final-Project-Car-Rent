import { Car } from "../models/car.model";
import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs/Observable";

@Injectable()
export class CarService {


  carInfo: Car;

  myUIrl: string = 'http://localhost:12288/api/Cars';


  constructor(private myHttpClient: HttpClient) { }

  public getAllCars(): Observable<Car> {
    return this.myHttpClient.get<Car>(this.myUIrl);
  }


  getCarByCarNumber(number: string): void {
    const url = `http://localhost:12288/api/Cars?CarNumber=${number}`;
    this.myHttpClient.get(url).subscribe((x: Car) => { this.carInfo = x });

    console.log("////");
  }

  getCarForEdit(number: string, callback: (car: Car) => void): void {
    const url = `http://localhost:12288/api/Cars?CarNumber=${number}`;
    this.myHttpClient.get(url)
      .subscribe((x: Car) => { callback(x); });
  }

  public editCar(car: Car, number: string, callback: (bool: boolean) => void): void {
    this.myHttpClient.put<boolean>(`${this.myUIrl}?CarNumber=${number}`, JSON.stringify(car), { headers: { "content-type": "application/json" } })
      .subscribe(() => { this.getAllCars(); callback(true); },
        () => { callback(false) });
  }

  public addCar(car: Car, callback: (bool: boolean) => void): void {
    this.myHttpClient.post(this.myUIrl, JSON.stringify(car), { headers: { "content-type": "application/json" } }).subscribe(() => { this.getAllCars(); callback(true); },
      () => { callback(false) });

  }

  public deleteCar(car: string): Observable<boolean> {
    const url = `http://localhost:12288/api/Cars?CarNumber=${car}`;

    return this.myHttpClient.delete<boolean>(url);
  }

}

