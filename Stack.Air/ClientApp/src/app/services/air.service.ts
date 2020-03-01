import {Inject, Injectable} from '@angular/core';
import {Observable} from 'rxjs';
import {HttpClient} from '@angular/common/http';
import {Air} from '../models/air';

@Injectable({
  providedIn: 'root'
})
export class AirService {
  baseUrl = '';

  constructor(private httpClient: HttpClient,  @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  getData(): Observable<Air[]> {
    return this.httpClient.get<Air[]>(this.baseUrl + 'api/air');
  }
}
