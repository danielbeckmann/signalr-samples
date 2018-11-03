import { Component, OnInit } from '@angular/core';
import { ChatService } from './chat.service';

@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.css']
})
export class ChatComponent implements OnInit {
  public message = '';
  public messages: string[] = [];

  constructor(private chatService: ChatService) { }

  ngOnInit() {
    this.chatService.init();

    this.chatService.messages$
      .subscribe(message => this.messages.push(message));
  }

  public sendMessage(): void {
    this.chatService.send(this.message);
    this.message = '';
  }
}
