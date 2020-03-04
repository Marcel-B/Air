import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { SensorsComponent } from './sensors/sensors.component';
import { TableComponent } from './table/table.component';
import { ChartComponent } from './chart/chart.component';
import { AirResolver} from './resolvers/air.resolver';
import {ChartDataResolver} from './resolvers/chartData.resolver';
import {SensorResolver} from './resolvers/sensor.resolver';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    SensorsComponent,
    TableComponent,
    ChartComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'sensors', component: SensorsComponent, resolve: {sensor: SensorResolver} },
      { path: 'table', component: TableComponent, resolve: {air: AirResolver} },
      { path: 'chart', component: ChartComponent, resolve: {chartData: ChartDataResolver} },
    ])
  ],
  providers: [
    AirResolver,
    ChartDataResolver,
    SensorResolver
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
