import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-page404',
  template: '<img [src]="imgLink"/>',
    styles: [`
    img{
        width:50%;
        margin:60px;
        margin-left:25%;
        display:inline-block;
    }`]
})
export class Page404Component implements OnInit {

  imgLink: string = "/assets/Images/404-error.jpg";

  constructor() { }

  ngOnInit() {
  }

}
