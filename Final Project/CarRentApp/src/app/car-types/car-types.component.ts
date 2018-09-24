import { Component, OnInit } from '@angular/core';
import { CarType } from '../shared/models/car-type.model';
import { CarTypeService } from '../shared/services/car-type.service';

@Component({
  selector: 'app-car-types',
  templateUrl: './car-types.component.html',
  styleUrls: ['./car-types.component.css']
})
export class CarTypesComponent implements OnInit {

  carTypes:CarType;
  constructor(private carTypeService:CarTypeService) { }

  ngOnInit() {
    this.carTypeService.getAllCarTypes().subscribe(data=>this.carTypes = data);
  }

  deleteCarType(type:string){
    this.carTypeService.deleteCarType(type).subscribe(
      (res) =>{this.carTypes = res; console.log(res, type);}
      
      );
    }

}
