import { Component, OnInit } from '@angular/core';
import { Order } from '../shared/models/order.model';
import { UserService } from '../shared/services/user.service';
import { User } from '../shared/models/user.model';
import { OrderService } from '../shared/services/order.service';
import { Car } from '../shared/models/car.model';
import { CarService } from '../shared/services/car.service';

@Component({
  selector: 'app-add-order',
  templateUrl: './add-order.component.html',
  styleUrls: ['./add-order.component.css']
})
export class AddOrderComponent implements OnInit {

  cars:Car;
  users:User;
  actionMsg:string;
  localUser:User;
  localCar:Car;
  difDays:any;
  localStartDate:Date = new Date();
  localEndDate:Date = new Date();
  price:number;

  localOrder:Order = {
    "StartDate":undefined,
    "ReturnDate":undefined,
    "ActualReturnDate":undefined,
    "User":undefined,
    "Car":undefined
  };
  
  constructor(private carService:CarService, private userService:UserService,private orderService:OrderService) {}
 
  ngOnInit() {
    this.carService.getAllCars().subscribe(data => this.cars = data);
    this.userService.getAllUsers().subscribe(data => this.users = data);
    
  }

 
  
  addOrder(){
    let callback=(bool:boolean)=>{this.actionMsg = (bool) ? "action success" : "action fail";}
    
   this.orderService.addOrder(this.localOrder,callback);
   console.log(this.localOrder);
  }

  setSelectedUser(user:User){
    this.localUser=user;
    console.log(user);
  }

  setSelectedCar(car:Car){
    this.localCar=car;
    console.log(car);
  }

}
