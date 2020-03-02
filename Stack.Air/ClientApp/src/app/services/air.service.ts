import {Inject, Injectable} from '@angular/core';
import {Observable} from 'rxjs';
import {HttpClient} from '@angular/common/http';
import {Air} from '../models/air';
import {ChartData} from '../models/chartData';

@Injectable({
  providedIn: 'root'
})
export class AirService {
  baseUrl = '';

  constructor(private httpClient: HttpClient,  @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  getData(): Observable<Air[]> {
    return this.httpClient.get<Air[]>(this.baseUrl + 'api/airs');
  }

  getChartData(): Observable<ChartData[]> {
    return this.httpClient.get<ChartData[]>(this.baseUrl + 'api/values/3/48');
  }
}
