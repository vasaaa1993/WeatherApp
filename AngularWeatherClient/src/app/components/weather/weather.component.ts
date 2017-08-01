import { Component, OnInit, Input } from '@angular/core';
import { Observable } from "rxjs/Observable";
import { Router } from '@angular/router';

import { Weather } from "../../models/weather";
import { City } from "../../models/city";

import { WeatherService } from "../../services/weather.service";
import { CitiesService } from "../../services/cities.service";

@Component({
  selector: 'app-weather',
  templateUrl: './weather.component.html',
  styleUrls: ['./weather.component.scss']
})
export class WeatherComponent implements OnInit {

  @Input()
  cityName: string;
  @Input()
  period: string;
  weather: Observable<Weather>;
  cities: Observable<City[]>;

  constructor(private weatherService: WeatherService, private citiesService: CitiesService, private router: Router) { }

  ngOnInit(): void {
    this.cityName = '';
    this.period = '1';
    this.weather;
    this.cities = this.citiesService.getCities();
  }

  onGetWeather(city?: string):void{
    if(city != null)
      this.cityName = city;
    if(this.cityName == '')
      return;
    this.weather = this.weatherService.getWeather(this.cityName, this.period);
    this.weather.subscribe(item => console.log(item));
  }

  onGoToCities(): void{
    this.router.navigate(['/cities']);
  }

}
