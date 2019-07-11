import { Component, OnInit } from '@angular/core';

const SAMPLE_BARCHART_DATA = [
  { data: [65, 59, 80, 81, 56, 55, 40], label: 'Series A' },
  { data: [28, 48, 40, 19, 86, 27, 90], label: 'Series B' }
];

const SAMPLE_BARCHART_LABLE = [
  '2006',
  '2007',
  '2008',
  '2009',
  '2010',
  '2011',
  '2012'
];

@Component({
  selector: 'app-bar-chart',
  templateUrl: './bar-chart.component.html',
  styleUrls: ['./bar-chart.component.css']
})
export class BarChartComponent implements OnInit {
  public barChartData: any[] = SAMPLE_BARCHART_DATA;
  public barChartLabels: string[] = SAMPLE_BARCHART_LABLE;
  public barChartType = 'bar';
  public barChartLegend = true;
  public barChartOptions: any = {
    salesShowVerticalLine: false,
    responsive: true
  };

  constructor() {}

  ngOnInit() {}
}
