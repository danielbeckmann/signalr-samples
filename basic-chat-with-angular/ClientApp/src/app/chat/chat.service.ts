import { Injectable } from '@angular/core';
import * as signalR from '@aspnet/signalr';
import { Observable, Subject } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class ChatService {
  public messages$: Observable<string>;

  private hubConnection: signalR.HubConnection;
  private messagesSubject: Subject<string> = new Subject();

  constructor() {
    this.messages$ = this.messagesSubject.asObservable();

    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl('/chat')
      .build();

    this.hubConnection.on('broadcast', (message: string) => {
      this.messagesSubject.next(message);
    });
  }

  public init() {
    this.hubConnection.start();
  }

  public send(message: string): void {
    this.hubConnection.invoke('send', message);
  }
}
