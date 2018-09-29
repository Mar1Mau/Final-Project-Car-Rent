import { Component, OnInit } from '@angular/core';
import { CarType } from '../shared/models/car-type.model';
import { CarTypeService } from '../shared/services/car-type.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-edit-car-type',
  templateUrl: './edit-car-type.component.html',
  styleUrls: ['./edit-car-type.component.css']
})
export class EditCarTypeComponent implements OnInit {

  actionMsg :string;
  localParam: string;

  localType:CarType = {
  "ManufactrName": undefined,
  "Model": undefined,
  "DailyCost":undefined,
  "OverdueCostDay":undefined,
  "ManufactYear": undefined,
  "IsManual": undefined
  } ;
  
  constructor(private myService: CarTypeService,private myActivatedRoute: ActivatedRoute) {
    this.localType;
   }

  ngOnInit() {
    this.myActivatedRoute.params.subscribe(params => {
      this.localParam = params.Model;

      if(params.Model){
        this.myService.getCarForEdit(params.Model,(carType:CarType)=>{this.localType=carType;})  
      }
    });
    }
  
  

  editCar(){

    let callback=(bool:boolean)=>{this.actionMsg = (bool) ? "Action success" : "Action fail";}
    this.myService.editCarType(this.localType,this.localParam,callback);
    
    setTimeout(() => {
      location.reload();
    }, 2000);
  }


}
