import {Inject, Injectable} from '@angular/core';
import {Observable} from 'rxjs';
import {HttpClient} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AirService {
  baseUrl = '';

  constructor(private httpClient: HttpClient,  @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  getData(): Observable<Air[]> {
    console.log('Air service here');
    return this.httpClient.get<Air[]>(this.baseUrl + 'api/air');
  }
}
