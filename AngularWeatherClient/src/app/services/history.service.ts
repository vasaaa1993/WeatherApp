import { Injectable } from '@angular/core';

import { BaceService } from "./base.service";
import { Http } from "@angular/http";
import { HistoryItem } from "../models/historyItem";

import { Observable } from "rxjs/Observable";

@Injectable()
export class HistoryService  extends BaceService {

  constructor(http: Http) {
    super(http);

    this.parUrl = 'history';
  }

  getHistory(): Observable<HistoryItem[]>
  {
    return this.getDataObservable(this.baseUrl + this.parUrl);
  }

}
