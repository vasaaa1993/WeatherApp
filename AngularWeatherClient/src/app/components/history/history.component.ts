import { Component, OnInit } from '@angular/core';
import { Observable } from "rxjs/Observable";

import { HistoryItem } from "../../models/historyItem";

import { HistoryService } from "../../services/history.service";

@Component({
  selector: 'app-history',
  templateUrl: './history.component.html',
  styleUrls: ['./history.component.scss']
})
export class HistoryComponent implements OnInit {
  
  history: Observable<HistoryItem[]>;
  constructor(private historyService: HistoryService) { }

  ngOnInit() {
    this.history = this.historyService.getHistory();
  }

}
