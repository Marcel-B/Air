import {Injectable} from '@angular/core';
import {ActivatedRouteSnapshot, Resolve, Router} from '@angular/router';
import {catchError} from 'rxjs/operators';
import {Observable, of} from 'rxjs';
import {SensorService} from '../services/sensor.service';
import {Sensor} from '../models/sensor';

@Injectable()
export class SensorResolver implements  Resolve<Sensor[]> {
  constructor(private sensorService: SensorService, private router: Router) {}

  resolve(route: ActivatedRouteSnapshot): Observable<Sensor[]>  {
    return this.sensorService.getSensorData().pipe(
      catchError(error => {
        this.router.navigate(['/']);
        return of(null);
      })
    );
  }
}
