import { Component, OnInit } from '@angular/core';
import { CarService } from '../shared/services/car.service';
import { Car } from '../shared/models/car.model';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-car-details',
  templateUrl: './car-details.component.html',
  styleUrls: ['./car-details.component.css']
})
export class CarDetailsComponent implements OnInit {
  
  actionMsg :string;
  localParam: string;
  userInLocalStorage:any;
 

  localCar: Car = {
    CarType:{
      "ManufactrName": undefined,
      "Model": undefined,
      "DailyCost":undefined,
      "OverdueCostDay":undefined,
      "ManufactYear": undefined,
      "IsManual": undefined
    },
    CurrentMileage:undefined,
    Img: undefined,
    IsProperForRent:undefined,
    CarNumber:undefined,
    Branch:{
      "FullAddress":undefined,
     "Latitude": undefined,
      "Longitude": undefined,
      "BranchName":undefined
  }
    
  };
    
 
  
  constructor(private myService: CarService,private myActivatedRoute: ActivatedRoute) { }

  ngOnInit() {
    this.userInLocalStorage = localStorage.getItem('RoleName');
    this.myActivatedRoute.params.subscribe(params => {
      this.localParam = params.CarNumber;

      if(params.CarNumber){
        this.myService.getCarForEdit(params.CarNumber,(car:Car)=>{this.localCar=car;})  
      }
    });
    }
  
  
    deleteCar(car:string){
      this.myService.deleteCar(car).subscribe(
        (res) =>{
          if(res){
            this.myService.getAllCars();
          }
          this.actionMsg = (res) ? "delete success" : "delete fail";
          console.log("res"+ this.actionMsg);
        });
        
        setTimeout(() => {
          location.reload();
        }, 2000);
    }
  
}
