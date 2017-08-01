import { Injectable } from '@angular/core';
import { Http } from "@angular/http";
import { Observable } from "rxjs/Observable";

import { BaceService } from "./base.service";
import { Weather } from "../models/weather";

@Injectable()
export class WeatherService extends BaceService{

  constructor(http: Http) {
    super(http);
    this.parUrl = 'weather';
  }

  getWeather(city: string, period: string): Observable<Weather>{
   return this.getData(this.generateUrl() + '/' + city + '/' + period);
  }
}
