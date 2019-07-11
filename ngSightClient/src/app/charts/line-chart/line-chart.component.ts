import { LINECHART_COLOR } from '../../shared/chart.colors';
import { Component, OnInit } from '@angular/core';

const SAMPLE_LINECHART_DATA = [
  { data: [45, 57, 50, 41, 56, 55], label: 'Sentiment Analysis' },
  { data: [28, 48, 40, 19, 46, 27], label: 'Image Recognition' },
  { data: [28, 54, 40, 55, 45, 54], label: 'Forcasting' }
];

const SAMPLE_LINECHART_LABLE = ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun'];

@Component({
  selector: 'app-line-chart',
  templateUrl: './line-chart.component.html',
  styleUrls: ['./line-chart.component.css']
})
export class LineChartComponent implements OnInit {
  public lineChartData: any[] = SAMPLE_LINECHART_DATA;
  public lineChartLabels: string[] = SAMPLE_LINECHART_LABLE;
  public lineChartOptions: any = {
    responsive: true
  };
  public lineChartLegend = true;
  public lineChartType = 'line';
  public lineChartColors = LINECHART_COLOR;

  constructor() {}

  ngOnInit() {}
}
