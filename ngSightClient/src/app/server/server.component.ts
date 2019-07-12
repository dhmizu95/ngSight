import { Server } from './../shared/server';
import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-server',
  templateUrl: './server.component.html',
  styleUrls: ['./server.component.css']
})
export class ServerComponent implements OnInit {
  @Input() serverInput: Server;
  color: string;
  buttonText: string;

  constructor() {}

  ngOnInit() {
    this.getServerAction(this.serverInput.isOnline);
  }

  getServerAction(isOnline: boolean) {
    if (isOnline) {
      this.serverInput.isOnline = true;
      this.color = '#66bb6a';
      this.buttonText = 'Shut Down';
    } else {
      this.serverInput.isOnline = false;
      this.color = '#ff6b6b';
      this.buttonText = 'Start';
    }
  }

  toggleStatus(onlineStatus: boolean) {
    console.log('toggled!');
    this.getServerAction(!onlineStatus);
  }
}
