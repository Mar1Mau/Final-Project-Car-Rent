import { Component, OnInit } from '@angular/core';
import { CarType } from '../shared/models/car-type.model';
import { CarTypeService } from '../shared/services/car-type.service';

@Component({
  selector: 'app-add-car-type',
  templateUrl: './add-car-type.component.html',
  styleUrls: ['./add-car-type.component.css']
})
export class AddCarTypeComponent implements OnInit {

  actionMsg: string;
  carTypes: CarType;
  carType: CarType;

  localCarType: CarType = {
    ManufactrName: undefined,
    Model: undefined,
    DailyCost: undefined,
    OverdueCostDay: undefined,
    ManufactYear: undefined,
    IsManual: undefined
  };



  constructor(private carTypeService: CarTypeService) { }

  ngOnInit() {
    this.carTypeService.getAllCarTypes().subscribe(data => this.carTypes = data);
  }




  addCarType() {
    let callback = (bool: boolean) => { this.actionMsg = (bool) ? "Action success" : "Action fail"; }

    this.carTypeService.addCarType(this.localCarType, callback);
    console.log(this.localCarType);

    setTimeout(() => {
      location.reload();
    }, 2000);


  }

}
