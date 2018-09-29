import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-contact-us',
  templateUrl: './contact-us.component.html',
  styleUrls: ['./contact-us.component.css']
})
export class ContactUsComponent implements OnInit {

  actionMsg: string;

  constructor() { }

  ngOnInit() {
  }
  Send() {
    this.actionMsg = "Thank you for your message. One of our team members will be in touch within three business days";

    setTimeout(() => {
      location.reload();
    }, 4000);
    
  }

}
