import { Component, OnInit } from '@angular/core';
import { Observable } from "rxjs/Observable";
import { DatePipe } from '@angular/common';

import { HistoryItem } from "../../models/historyItem";

import { HistoryService } from "../../services/history.service";

import 'rxjs/add/operator/toPromise';

@Component({
  selector: 'app-history',
  templateUrl: './history.component.html',
  styleUrls: ['./history.component.scss']
})
export class HistoryComponent implements OnInit {
  
  history: Observable<HistoryItem[]>;
  constructor(private historyService: HistoryService) { }

  ngOnInit(): void {
    this.getHistory();
  }

  getHistory():void{
    this.history = this.historyService.getHistory();
  }

  clearHistory():void {
      this.historyService.clearHistory()
      .toPromise()
      .then(()=>this.history = this.historyService.getHistory());
  }
}
