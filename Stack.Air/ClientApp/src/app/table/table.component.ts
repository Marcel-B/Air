import {Component, OnInit} from '@angular/core';
import {ActivatedRoute} from '@angular/router';
import {Air} from '../models/air';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './table.component.html'
})

export class TableComponent implements OnInit {
  public air: Air[];

  constructor(private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.data.subscribe(data => {
      this.air = data.air;
    });
  }
}
