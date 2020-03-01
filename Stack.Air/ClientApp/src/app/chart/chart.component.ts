import { Component } from '@angular/core';

@Component({
  selector: 'app-chart-component',
  templateUrl: './chart.component.html'
})
export class ChartComponent {
  public currentCount = 0;

  public incrementCounter() {
    this.currentCount++;
  }
}
