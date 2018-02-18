import { Component, OnInit } from '@angular/core';
import { GlobalMessagingService } from './global-messaging.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  title: string = 'app';
  message: object;

  sendMessage(): void {
    GlobalMessagingService.GetInstance().broadcast({ title: 'Laptop', price: 1200, command: 'SepeteEkle', date: new Date() });
  }

  ngOnInit(): void {
    GlobalMessagingService.GetInstance().messaging$.subscribe((data) => {
      this.message = data;
    });
  }

}
