import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public air: Air[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Air[]>(baseUrl + 'api/air').subscribe(result => {
      this.air = result;
    }, error => console.error(error));
  }
}

interface Air {
  time: string;
  temperature: number;
  pressure: number;
  humidity: number;
  sdsP1: number;
  sdsP2: number;
}
