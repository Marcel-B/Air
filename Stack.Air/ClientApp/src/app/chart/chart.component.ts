import { Component, OnInit, ViewChild, ElementRef, AfterViewInit, HostListener } from '@angular/core';
import * as  d3 from 'd3';

@Component({
  selector: 'app-chart-component',
  templateUrl: './chart.component.html',
  styleUrls: ['./chart.component.css']
})

export class ChartComponent implements AfterViewInit, OnInit {
  @ViewChild('myDiv') here: ElementRef;
  @HostListener('window:resize', ['$event'])
  onResize(event) {
    this.innerWidth = this.here.nativeElement.offsetWidth;
    this.innerHeight = window.innerHeight - 100;
    this.chartIt();
  }

  private innerWidth: number;
  private innerHeight: number;

  ngOnInit(): void {
    this.innerWidth = this.innerWidth;
    this.innerHeight = this.innerHeight - 100;
  }

  chartIt(): void {
    // 2. Use the margin convention practice 
    var margin = { top: 50, right: 50, bottom: 50, left: 50 }
      , width = this.innerWidth - margin.left - margin.right // Use the window's width 
      , height = this.innerHeight - margin.top - margin.bottom; // Use the window's height

    // The number of datapoints
    var n = 21;

    // 5. X scale will use the index of our data
    var xScale = d3.scaleLinear()
      .domain([0, n - 1]) // input
      .range([0, width]); // output

    // 6. Y scale will use the randomly generate number 
    var yScale = d3.scaleLinear()
      .domain([0, 1]) // input 
      .range([height, 0]); // output 

    // 7. d3's line generator
    var line = d3.line()
      .x(function (d, i) { return xScale(i); }) // set the x values for the line generator
      .y(function (d) { return yScale(d.y); }) // set the y values for the line generator 
      .curve(d3.curveMonotoneX) // apply smoothing to the line

    // 8. An array of objects of length N. Each object has key -> value pair, the key being "y" and the value is a random number
    var dataset = d3.range(n).map(function (d) { return { "y": d3.randomUniform(1)() } })

    // 1. Add the SVG to the page and employ #2

    d3.select("svg").remove();
    var svg = d3.select("#graph")
      .append("svg")
      .attr("width", width + margin.left + margin.right)
      .attr("height", height + margin.top + margin.bottom)
      .append("g")
      .attr("transform", "translate(" + margin.left + "," + margin.top + ")");

    // 3. Call the x axis in a group tag
    svg.append("g")
      .attr("class", "x axis")
      .attr("transform", "translate(0," + height + ")")
      .call(d3.axisBottom(xScale)); // Create an axis component with d3.axisBottom

    // 4. Call the y axis in a group tag
    svg.append("g")
      .attr("class", "y axis")
      .call(d3.axisLeft(yScale)); // Create an axis component with d3.axisLeft

    // 9. Append the path, bind the data, and call the line generator 
    svg.append("path")
      .datum(dataset) // 10. Binds data to the line 
      .attr("class", "line") // Assign a class for styling 
      .attr("d", line); // 11. Calls the line generator 

    // 12. Appends a circle for each datapoint 
    svg.selectAll(".dot")
      .data(dataset)
      .enter().append("circle") // Uses the enter().append() method
      .attr("class", "dot") // Assign a class for styling
      .attr("cx", function (d, i) { return xScale(i) })
      .attr("cy", function (d) { return yScale(d.y) })
      .attr("r", 5)
      .on("mouseover", function (a, b, c) {
        console.log(a)
        this.attr('class', 'focus')
      })
      .on("mouseout", function () { })
  }

  ngAfterViewInit(): void {
    this.innerWidth = this.here.nativeElement.offsetWidth;
    this.innerHeight = window.innerHeight - 100;
    this.chartIt();
  }
}
