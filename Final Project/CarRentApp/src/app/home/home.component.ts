import { Component, OnInit} from '@angular/core';
import { Order } from '../shared/models/order.model';
import { CarTypeService } from '../shared/services/car-type.service';
import { CarType } from '../shared/models/car-type.model';
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit{

  imgLink: string = "assets/Images/background1.jpg";
 
  carTypes:CarType;

  localOrder:Order = {
    "StartDate":undefined,
    "ReturnDate":undefined,
    "ActualReturnDate":undefined,
    "User":undefined,
    "Car":undefined
  };

  constructor(private myService:CarTypeService) {}
 
  ngOnInit() {
    this.myService.getAllCarTypes().subscribe(data => this.carTypes = data);
  }
}
