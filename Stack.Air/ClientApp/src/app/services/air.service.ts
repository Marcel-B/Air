import {Inject, Injectable} from '@angular/core';
import {Observable} from 'rxjs';
import {HttpClient} from '@angular/common/http';
import {ChartData} from '../models/chartData';
import {Statistic} from '../models/statistic';

@Injectable({
  providedIn: 'root'
})
export class AirService {
  readonly baseUrl: string;

  constructor(private httpClient: HttpClient,  @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  getData(): Observable<Statistic[]> {
    return this.httpClient.get<Statistic[]>(this.baseUrl + 'api/stats/48');
  }

  getChartData(sensorId: Number): Observable<ChartData[]> {
    return this.httpClient.get<ChartData[]>(this.baseUrl + `api/values/${sensorId}/48`);
  }
}
