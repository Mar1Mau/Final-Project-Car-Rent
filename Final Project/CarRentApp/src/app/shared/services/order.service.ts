import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Order } from "../models/order.model";

@Injectable()
export class OrderService{
   
    myUIrl: string = 'http://localhost:12288/api/Orders';

   

    constructor(private myHttpClient: HttpClient) { }

    public getOrders():Observable<Order> {
        return this.myHttpClient.get<Order>(this.myUIrl);
    }

    public addOrder(order: Order, callback: (bool: boolean) => void): void {
        this.myHttpClient.post(this.myUIrl, JSON.stringify(order), { headers: { "content-type": "application/json" } }).subscribe(() => { this.getOrders(); callback(true); },
            () => { callback(false) });

    }

    getOrderForEdit(carNumber:string,callback:(order:Order)=>void): void {
        this.myHttpClient.get(`${this.myUIrl}/Cars?CarNumber=${carNumber}`)
            .subscribe((x:Order) => { callback(x);});
      }

    deleteOrder(carNumber:string):Observable<boolean>{
      let apiUrl:string=`${this.myUIrl}/Cars?CarNumber=${carNumber}`;
       return this.myHttpClient.delete<boolean>(apiUrl);
    }

   

    editOrder(order:Order,carNumber:string,callback:(bool:boolean)=>void): void {
        this.myHttpClient.put<boolean>(`${this.myUIrl}/Cars?CarNumber=${carNumber}`,JSON.stringify(order), { headers: {"content-type": "application/json" }}).subscribe(()=>{this.getOrders(); callback(true);},
        ()=>{callback(false)});
    }
}
