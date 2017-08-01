import { Injectable } from '@angular/core';
import { Http } from '@angular/http';

import 'rxjs/add/operator/map';

import { BaceService } from "./base.service";
import { City } from "../models/city";

@Injectable()
export class CitiesService extends BaceService{
  cities: City[];

  constructor(http: Http) {
    super(http);
    this.parUrl = 'cities';
  }

  getDataObservable(url:string){
   return this.http.get(url)
        .map(res => res.json());
  }

  deleteDataObservable(id: number){
    return this.http.delete(this.baseUrl + this.parUrl + '/' + id);
  }

}
