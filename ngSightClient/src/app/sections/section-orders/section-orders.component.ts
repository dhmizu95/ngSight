import { Component, OnInit } from '@angular/core';
import { Order } from 'src/app/shared/order';

@Component({
  selector: 'app-section-orders',
  templateUrl: './section-orders.component.html',
  styleUrls: ['./section-orders.component.css']
})
export class SectionOrdersComponent implements OnInit {
  orders: Order[] = [
    {
      id: 1,
      customer: {
        id: 1,
        name: 'Main St Bakery',
        email: 'some@thing.com',
        state: 'Co'
      },
      total: 230,
      placed: new Date(2019, 3, 3),
      fulfilled: new Date(2019, 4, 4)
    },
    {
      id: 2,
      customer: {
        id: 1,
        name: 'Main St Bakery',
        email: 'some@thing.com',
        state: 'Co'
      },
      total: 230,
      placed: new Date(2019, 3, 3),
      fulfilled: new Date(2019, 4, 4)
    },
    {
      id: 3,
      customer: {
        id: 1,
        name: 'Main St Bakery',
        email: 'some@thing.com',
        state: 'Co'
      },
      total: 230,
      placed: new Date(2019, 3, 3),
      fulfilled: new Date(2019, 4, 4)
    },
    {
      id: 4,
      customer: {
        id: 1,
        name: 'Main St Bakery',
        email: 'some@thing.com',
        state: 'Co'
      },
      total: 230,
      placed: new Date(2019, 3, 3),
      fulfilled: new Date(2019, 4, 4)
    },
    {
      id: 5,
      customer: {
        id: 1,
        name: 'Main St Bakery',
        email: 'some@thing.com',
        state: 'Co'
      },
      total: 230,
      placed: new Date(2019, 3, 3),
      fulfilled: new Date(2019, 4, 4)
    }
  ];

  constructor() {}

  ngOnInit() {}
}
