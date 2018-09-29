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
  userInLocalStorage:any;

  constructor(private carTypeService:CarTypeService) { }

  ngOnInit() {
    this.userInLocalStorage = localStorage.getItem('RoleName');
    this.carTypeService.getAllCarTypes().subscribe(data=>this.carTypes = data);
  }

  deleteCarType(type:string){
    this.carTypeService.deleteCarType(type).subscribe(
      (res) =>{this.carTypes = res; console.log(res, type);}
      
      );
      setTimeout(() => {
        location.reload();
      }, 2000);
    }

}
