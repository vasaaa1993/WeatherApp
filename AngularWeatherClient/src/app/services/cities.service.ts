import { Injectable } from '@angular/core';
import { Http } from '@angular/http';

import 'rxjs/add/operator/map';

import { BaceService } from "./base.service";
import { City } from "../models/city";

import { Observable } from "rxjs/Observable";

@Injectable()
export class CitiesService extends BaceService{
  cities: City[];

  constructor(http: Http) {
    super(http);
    this.parUrl = 'cities';
  }

  getCities(): Observable<City[]>{
   return this.getData(this.generateUrl());
  }

  deleteCity(id: number){
    debugger
    return this.deleteData(this.generateUrl() + '/' + id);
  }

  addCity(name: string){
    return this.http.post(this.generateUrl(), {'Name': name});
  }

}
