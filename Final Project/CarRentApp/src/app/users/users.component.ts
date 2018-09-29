import { Component, OnInit } from '@angular/core';
import { UserService } from '../shared/services/user.service';
import { User } from '../shared/models/user.model';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {

  imgLink: string = "/assets/Images/anonym.png";

  users:User;
  actionMsg: string;
  constructor(private myService:UserService) { }

  ngOnInit() {
   
    this.myService.getAllUsers().subscribe(data => {this.users = data});
    
  }



  deleteUser(userName:string){
    this.myService.deleteUser(userName).subscribe(
      (res) =>{this.users = res; console.log(res, userName);}
      
      );
      setTimeout(() => {
        location.reload();
      }, 2000);
  }
}
