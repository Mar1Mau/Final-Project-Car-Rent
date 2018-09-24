import { Component, OnInit } from '@angular/core';
import { CarService } from '../shared/services/car.service';
import { ActivatedRoute } from '@angular/router';
import { Car } from '../shared/models/car.model';
import { BranchService } from '../shared/services/branch.service';
import { Branch } from '../shared/models/branch.model';
import { CarType } from '../shared/models/car-type.model';
import { CarTypeService } from '../shared/services/car-type.service';

@Component({
  selector: 'app-add-edit-car',
  templateUrl: './add-edit-car.component.html',
  styleUrls: ['./add-edit-car.component.css']
})
export class AddEditCarComponent implements OnInit {

  actionMsg :string;
  localParam: string;
  localBranch:Branch;
  branches:Branch;
  carTypes:CarType;
  localCarType:CarType;

  localCar: Car = {
    CarType:undefined,
    CurrentMileage:undefined,
    Img: undefined,
    IsProperForRent:undefined,
    CarNumber:undefined,
    Branch:undefined
  };
    
 
  
  constructor(private myService: CarService, private branchService:BranchService, private myActivatedRoute: ActivatedRoute, private carTypeService:CarTypeService) { }

  ngOnInit() {
    this.branchService.getAllBranches().subscribe(data=>this.branches = data);
    this.carTypeService.getAllCarTypes().subscribe(data=>this.carTypes = data);
    this.myActivatedRoute.params.subscribe(params => {
      this.localParam = params.CarNumber;

      if(params.CarNumber){
        this.myService.getCarForEdit(params.CarNumber,(car:Car)=>{this.localCar=car;})  
      }
    });
    }
  
  

  editCar(){

    let callback=(bool:boolean)=>{this.actionMsg = (bool) ? "action success" : "action fail";}
    this.myService.editCar(this.localCar,this.localParam,callback);
  }
    
  setSelectedBranch(branch:Branch){
    this.localBranch=branch;
    console.log(branch);
  }

  setSelectedCarType(carType:CarType){
    this.localCarType = carType;
    console.log(carType);
  }

 addCar(){
  let callback=(bool:boolean)=>{this.actionMsg = (bool) ? "action success" : "action fail";}
  
 this.myService.addCar(this.localCar,callback);
 console.log(this.localCar);
}
  
}
