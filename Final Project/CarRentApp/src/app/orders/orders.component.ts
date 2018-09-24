import { Component, OnInit } from '@angular/core';
import { Order } from '../shared/models/order.model';
import { OrderService } from '../shared/services/order.service';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.css']
})
export class OrdersComponent implements OnInit {

  msg:string;
  orders:Order;
  
  constructor(private orderService:OrderService) { }

  ngOnInit() {
    this.orderService.getOrders().subscribe(data=>this.orders=data);
  }

  deleteOrder(carNumber:string){
    this.orderService.deleteOrder(carNumber).subscribe(
      (res)=>{
        if(res){
          this.orderService.getOrders();
        }
        this.msg = (res)?"delet succes":"delete fail";
      }
    )
  }
}
