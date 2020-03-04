import {Component, OnInit} from '@angular/core';
import {Sensor} from '../models/sensor';
import {ActivatedRoute} from '@angular/router';

@Component({
  selector: 'app-counter-component',
  templateUrl: './sensors.component.html'
})
export class SensorsComponent implements OnInit {
  public sensors: Sensor[];
  public currentCount = 0;

  constructor(private route: ActivatedRoute) {
  }

  public incrementCounter() {
    this.currentCount++;
  }

  ngOnInit(): void {
    this.route.data.subscribe(data => {
      this.sensors = data.sensor;
    });
  }
}
