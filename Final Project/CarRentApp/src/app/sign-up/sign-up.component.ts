import { Component, OnInit } from '@angular/core';
import { UserService } from '../shared/services/user.service';
import { User } from '../shared/models/user.model';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})
export class SignUpComponent implements OnInit {

 
  actionMsg :string;

  localUser: User = {
    "FullName": undefined,
    "IdCard": undefined,
    "UserName": undefined,
    "DoB": undefined,
    "IsMale": undefined,
    "EmailAddress": undefined,
    "Passwd": undefined,
    "Role":{
         "RoleName":undefined
       },
    "Img": undefined

  } ;

  constructor(private myService: UserService) { }

  ngOnInit() {
  }

  addUser(){
    let callback=(bool:boolean)=>{this.actionMsg = (bool) ? "action success" : "action fail";}
    
   this.myService.addUser(this.localUser,callback);
   console.log(this.localUser);
  }
}

