import { Component, OnInit } from '@angular/core';
import { User } from '../shared/models/user.model';
import { UserService } from '../shared/services/user.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-edit-user',
  templateUrl: './edit-user.component.html',
  styleUrls: ['./edit-user.component.css']
})
export class EditUserComponent implements OnInit {

  actionMsg :string;
  localParam: string;

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
  
  constructor(private myService: UserService,private myActivatedRoute: ActivatedRoute) {
    this.localUser;
   }

  ngOnInit() {
    
    this.myActivatedRoute.params.subscribe(params => {
      this.localParam = params.UserName;

      if(params.UserName){
        this.myService.getUserForEdit(params.UserName,(user:User)=>{this.localUser=user;})  
      }
    });
    }
  
  

  editUser(){

    let callback=(bool:boolean)=>{this.actionMsg = (bool) ? "action success" : "action fail";}
    this.myService.editUser(this.localUser,this.localParam,callback);
  }


}
