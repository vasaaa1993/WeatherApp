import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { HttpModule } from "@angular/http";
import { AppRoutingModule } from './app-routing.module';
import { FormsModule } from '@angular/forms';

import { AppComponent } from "./components/app/app.component";
import { HistoryComponent } from './components/history/history.component';
import { CitiesComponent } from './components/cities/cities.component';
import { WeatherComponent } from './components/weather/weather.component';

import { CitiesService } from "./services/cities.service";
import { HistoryService } from "./services/history.service";
import { WeatherService } from "./services/weather.service";



@NgModule({
  declarations: [
    AppComponent,
    HistoryComponent,
    CitiesComponent,
    WeatherComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpModule,
    FormsModule
  ],
  providers: [
    CitiesService,
    HistoryService,
    WeatherService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
