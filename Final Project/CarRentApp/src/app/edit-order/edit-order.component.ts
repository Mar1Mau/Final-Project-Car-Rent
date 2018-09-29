import { Component, OnInit } from '@angular/core';
import { User } from '../shared/models/user.model';
import { Car } from '../shared/models/car.model';
import { CarService } from '../shared/services/car.service';
import { UserService } from '../shared/services/user.service';
import { OrderService } from '../shared/services/order.service';
import { Order } from '../shared/models/order.model';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-edit-order',
  templateUrl: './edit-order.component.html',
  styleUrls: ['./edit-order.component.css']
})
export class EditOrderComponent implements OnInit {


  actionMsg: string;

  localParam: string;

  localOrder: Order = {
    "StartDate": undefined,
    "ReturnDate": undefined,
    "ActualReturnDate": undefined,
    "User": {
      "FullName": undefined,
      "IdCard": undefined,
      "UserName": undefined,
      "DoB": undefined,
      "IsMale": undefined,
      "EmailAddress": undefined,
      "Passwd": undefined,
      "Role": undefined,
      "Img": undefined,
    },
    "Car": {
      "CarType": {
        "ManufactrName": undefined,
        "Model": undefined,
        "DailyCost": undefined,
        "OverdueCostDay": undefined,
        "ManufactYear": undefined,
        "IsManual": undefined,
      },
      "CurrentMileage": undefined,
      "Img": undefined,
      "IsProperForRent": undefined,
      "CarNumber": undefined,
      "Branch": {
        "FullAddress": undefined,
        "Latitude": undefined,
        "Longitude": undefined,
        "BranchName": undefined,
      }
    },
  };

  constructor(private orderService: OrderService, private myActivatedRoute: ActivatedRoute) { }

  ngOnInit() {

    this.myActivatedRoute.params.subscribe(params => {
      this.localParam = params.CarNumber;

      if (params.CarNumber) {
        this.orderService.getOrderForEdit(params.CarNumber, (order: Order) => { this.localOrder = order })
      }
    });
  }



  editOrder() {
    let callback = (bool: boolean) => { this.actionMsg = (bool) ? "Action success" : "Action fail"; }

    this.orderService.editOrder(this.localOrder, this.localParam, callback);

    setTimeout(() => {
      location.reload();
    }, 2000);

  }
}
