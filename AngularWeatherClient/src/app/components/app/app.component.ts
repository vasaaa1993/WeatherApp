import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styles: ['./app.component.scss']
})
export class AppComponent implements OnInit{
  title = 'app';
  
  constructor() { }

   ngOnInit(): void {
  }
}
