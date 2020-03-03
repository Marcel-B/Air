import { Component, OnInit, ViewChild, ElementRef, AfterViewInit, HostListener } from '@angular/core';
import * as  d3 from 'd3';
import {ActivatedRoute} from '@angular/router';
import {ChartData} from '../models/chartData';

@Component({
  selector: 'app-chart-component',
  templateUrl: './chart.component.html',
  styleUrls: ['./chart.component.css']
})

export class ChartComponent implements AfterViewInit, OnInit {
  private innerWidth: number;
  private innerHeight: number;
  private values: ChartData[];

  @ViewChild('myDiv') here: ElementRef;
  constructor(private route: ActivatedRoute) { }

  onResize(event) {
    this.innerWidth = this.here.nativeElement.offsetWidth;
    this.innerHeight = window.innerHeight - 100;
    this.chartIt();
  }

  ngOnInit(): void {
    this.route.data.subscribe(data => {
      this.values = data.chartData;
      console.log(`Inc ${this.values.length} values`);
    });
    this.innerWidth = window.innerWidth;
    this.innerHeight = window.innerHeight - 100;
  }

  chartIt(): void {
    // 2. Use the margin convention practice
    const margin = { top: 50, right: 50, bottom: 50, left: 50 }
      , width = this.innerWidth - margin.left - margin.right // Use the window's width
      , height = this.innerHeight - margin.top - margin.bottom; // Use the window's height

    const parseTime = d3.timeParse('%Y-%m-%dT%H:%M:%S.%L');
    //2020-03-02T07:41:02.862168
    // The number of datapoints
    const dataSet = this.values
        .filter(a => a.measureValue !== undefined && a.timestamp !== undefined && parseTime(a.timestamp))
        .map(function(value) { return {'v': value.measureValue, 't': parseTime(value.timestamp) }; } );

    console.log(`Use ${dataSet.length} values`);
    const extent = d3.extent(dataSet, function(d) { return d.v; } );
    const tex = d3.extent(dataSet, function(d) { return d.t; });

    // 5. X scale will use the index of our data
    const xScale = d3.scaleTime()
      .domain(tex)
      .range([0, width]); // output

    extent[0] -=  (extent[0] * .1);
    extent[1] +=  (extent[1] * .1);

    // 6. Y scale will use the randomly generate number
    const yScale = d3.scaleLinear()
      .domain(extent) // input
      .range([height, 0]); // output


    // 7. d3's line generator
    const line = d3.line()
      .x(function (d) { return xScale(d.t); }) // set the x values for the line generator
      .y(function (d) { return yScale(d.v); }) // set the y values for the line generator
      .curve(d3.curveMonotoneX); // apply smoothing to the line

    // 1. Add the SVG to the page and employ #2

    d3.select('svg').remove();
    const svg = d3.select('#graph')
      .append('svg')
      .attr('width', width + margin.left + margin.right)
      .attr('height', height + margin.top + margin.bottom)
      .append('g')
      .attr('transform', 'translate(' + margin.left + ',' + margin.top + ')');

    // 3. Call the x axis in a group tag
    svg.append('g')
      .attr('class', 'x axis')
      .attr('transform', 'translate(0,' + height + ')')
      .call(d3.axisBottom(xScale)
        .tickFormat(d3.timeFormat('%H:%M')));
   // .call(d3.axisBottom(xScale)); // Create an axis component with d3.axisBottom

    // 4. Call the y axis in a group tag
    svg.append('g')
      .attr('class', 'y axis')
      .call(d3.axisLeft(yScale)); // Create an axis component with d3.axisLeft

    // 9. Append the path, bind the data, and call the line generator
    svg.append('path')
      .datum(dataSet) // 10. Binds data to the line
      .attr('class', 'line') // Assign a class for styling
      .attr('d', line); // 11. Calls the line generator

    // 12. Appends a circle for each datapoint
    svg.selectAll('.dot')
      .data(dataSet)
      .enter()
      .append('circle') // Uses the enter().append() method
      .attr('class', 'dot') // Assign a class for styling
      .attr('cx', function (d) { return xScale(d.t); })
      .attr('cy', function (d) { return yScale(d.v); })
      .attr('r', 3);
      //.on('mouseover', function (a, b, c) {
        //console.log(a);
       // this.attr('class', 'focus');
      //})
     // .on('mouseout', function () { });
  }

  ngAfterViewInit(): void {
    this.innerWidth = this.here.nativeElement.offsetWidth;
    this.innerHeight = window.innerHeight - 100;
    this.chartIt();
  }
}
