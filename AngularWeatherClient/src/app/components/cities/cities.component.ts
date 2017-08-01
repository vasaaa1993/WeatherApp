import { Component, OnInit } from '@angular/core';

import { City } from "../../models/city";
import { CitiesService } from "../../services/cities.service";
import { Observable } from "rxjs/Observable";

@Component({
  selector: 'app-cities',
  templateUrl: './cities.component.html',
  styleUrls: ['./cities.component.scss']
})
export class CitiesComponent implements OnInit {

  cities: Observable<City[]>;
  constructor(private citiesService: CitiesService) { }

  ngOnInit(): void {
    this.getCities();
  }

  getCities(): void{
    this.cities = this.citiesService.getCities();
  }

  deleteCity(id: number){
    this.citiesService.deleteCity(id)
    .toPromise()
    .then(() => this.getCities());
  }

  addCity(name: string){
    this.citiesService.addCity(name)
    .toPromise()
    .then(() => this.getCities());
  }
}
