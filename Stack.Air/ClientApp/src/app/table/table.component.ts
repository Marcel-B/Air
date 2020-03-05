import {Component, OnInit} from '@angular/core';
import {ActivatedRoute} from '@angular/router';
import {Statistic} from '../models/statistic';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './table.component.html'
})

export class TableComponent implements OnInit {
  public stats: Statistic[];

  constructor(private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.data.subscribe(data => {
      this.stats = data.statistics;
    });
  }
}
