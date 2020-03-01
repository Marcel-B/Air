import {Component, OnInit} from '@angular/core';
import {ActivatedRoute} from '@angular/router';
import {Air} from '../models/air';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})

export class FetchDataComponent implements OnInit {
  public air: Air[];

  constructor(private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.data.subscribe(data => {
      this.air = data.air;
    });
  }
}
