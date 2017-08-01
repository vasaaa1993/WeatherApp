import { Component, OnInit } from '@angular/core';

import { Observable } from "rxjs/Observable";

import { CitiesService } from "../../services/cities.service";
import { City } from "../../models/city";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styles: ['./app.component.scss']
})
export class AppComponent implements OnInit{
  title = 'app';
  data:Observable<City[]>;
  
  constructor(private citiesService: CitiesService) { }

   ngOnInit(): void {
    this.data = this.citiesService.getDataObservable('http://localhost:50185/api/Cities');
    this.data.subscribe(info => console.log(info));
  }
}
