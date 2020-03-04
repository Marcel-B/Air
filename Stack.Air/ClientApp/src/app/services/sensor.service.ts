import {Inject, Injectable} from '@angular/core';
import {Observable} from 'rxjs';
import {Sensor} from '../models/sensor';
import {HttpClient} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class SensorService {
  readonly baseUrl: string;

  constructor(private httpClient: HttpClient,  @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }
  getSensorData(): Observable<Sensor[]> {
    console.log(this.baseUrl);
    return this.httpClient.get<Sensor[]>(this.baseUrl + `api/sensors`);
  }
}
