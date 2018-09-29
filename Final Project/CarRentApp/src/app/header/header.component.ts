import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  userInLocalStorage:any;
 
  imgLink: string = "/assets/Images/logo-CarRental.png";
  constructor() { }

  ngOnInit() {

    this.userInLocalStorage = localStorage.getItem('UserName');
  }

  logout(){
    localStorage.clear();
    location.reload();
  }
}
 

