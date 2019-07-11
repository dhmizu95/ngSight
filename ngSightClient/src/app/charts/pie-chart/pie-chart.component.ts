import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-pie-chart',
  templateUrl: './pie-chart.component.html',
  styleUrls: ['./pie-chart.component.css']
})
export class PieChartComponent implements OnInit {
  public pieChartData: number[] = [345, 109, 578];
  public pieChartLabels: string[] = [
    'XYX Logistics',
    'Abul & Co.',
    'Chapter 14'
  ];
  public pieChartColors: any[] = [
    {
      backgroundColor: ['#26547c', '#ff6b6b', '#ffd166'],
      borderColor: '#111111'
    }
  ];
  public pieChartType = 'doughnut';

  constructor() {}

  ngOnInit() {}
}
