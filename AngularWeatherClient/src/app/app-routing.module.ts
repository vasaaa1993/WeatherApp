import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { WeatherComponent } from "./components/weather/weather.component";
import { HistoryComponent } from "./components/history/history.component";
import { CitiesComponent } from "./components/cities/cities.component";

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    redirectTo: '/weather'
  },
  {
    path: 'weather',
    component: WeatherComponent
  },
  {
    path: 'history',
    component: HistoryComponent
  },
  {
    path: 'cities',
    component: CitiesComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
