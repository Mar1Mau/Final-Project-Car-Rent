import { Component, OnInit } from '@angular/core';
import { User } from '../shared/models/user.model';
import { UserService } from '../shared/services/user.service';

@Component({
  selector: 'app-log-in',
  templateUrl: './log-in.component.html',
  styleUrls: ['./log-in.component.css']
})
export class LogInComponent implements OnInit {

 

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

  constructor(private userService:UserService) { }

  ngOnInit() {
    
  }

  login(){
    this.userService.getUserByUserNameAndPsswd(this.localUser.UserName,this.localUser.Passwd)
    .subscribe(
      (res)=> {
        
        localStorage.setItem('RoleName', JSON.stringify(res.Role.RoleName));
        localStorage.setItem('UserName', JSON.stringify(res.UserName));
        
         }
      );
      setTimeout(() => {
        location.reload();
      }, 2000);
  }

}
