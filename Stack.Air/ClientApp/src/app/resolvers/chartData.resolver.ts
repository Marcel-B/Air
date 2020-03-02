import {Injectable} from '@angular/core';
import {ActivatedRouteSnapshot, Resolve, Router} from '@angular/router';
import {AirService} from '../services/air.service';
import {catchError} from 'rxjs/operators';
import {Observable, of} from 'rxjs';
import {ChartData} from '../models/chartData';

@Injectable()
export class ChartDataResolver implements  Resolve<ChartData[]> {
  constructor(private airService: AirService, private router: Router) {}

  resolve(route: ActivatedRouteSnapshot): Observable<ChartData[]>  {
    return this.airService.getChartData().pipe(
      catchError(error => {
        this.router.navigate(['/']);
        return of(null);
      })
    );
  }
}
