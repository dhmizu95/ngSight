import { Server } from './../../shared/server';
import { Component, OnInit } from '@angular/core';

const SAMPLE_SERVER = [
  { id: 1, name: 'dev-mail', isOnline: true },
  { id: 2, name: 'dev-web', isOnline: false },
  { id: 3, name: 'dev-angular', isOnline: true },
  { id: 4, name: 'dev-app', isOnline: true },
  { id: 5, name: 'dev-mobile', isOnline: false }
];

@Component({
  selector: 'app-section-health',
  templateUrl: './section-health.component.html',
  styleUrls: ['./section-health.component.css']
})
export class SectionHealthComponent implements OnInit {
  servers: Server[] = SAMPLE_SERVER;

  constructor() {}

  ngOnInit() {}
}
