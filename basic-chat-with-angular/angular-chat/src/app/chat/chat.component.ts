import { Component, OnInit } from '@angular/core';
import { HubConnection } from '@aspnet/signalr-client';

@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.css']
})
export class ChatComponent implements OnInit {
  private hubConnection: HubConnection;
  messages: string[];

  constructor() { }

  ngOnInit() {
    this.hubConnection = new HubConnection('/chat');

    this.hubConnection.on('broadcast', (message: string) => {
      this.messages.push(message);
    });

    this.hubConnection.start();
  }

  sendMessage(message: string): void {
    this.hubConnection.invoke('send', message);
  }
}
