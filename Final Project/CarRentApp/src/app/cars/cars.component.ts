import { Component, OnInit } from '@angular/core';
import { Car } from '../shared/models/car.model';
import { CarService } from '../shared/services/car.service';

@Component({
  selector: 'app-cars',
  templateUrl: './cars.component.html',
  styleUrls: ['./cars.component.css']
})
export class CarsComponent implements OnInit {

  public cars: Car;
  public userInLocalStorage:any;

  constructor(private myService:CarService) { }

  ngOnInit() {
    this.myService.getAllCars().subscribe(data => {this.cars = data});
    this.userInLocalStorage = localStorage.getItem('RoleName');
  }

 

}
