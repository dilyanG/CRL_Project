import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule }    from '@angular/common/http';
import {TableModule} from 'primeng/table';
import {DropdownModule} from 'primeng/dropdown';
import {ButtonModule} from 'primeng/button';

import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { CitiesComponent } from './components/cities/cities.component';
import { RoutesComponent } from './components/routes/routes.component';
import { MapComponent } from './components/map/map.component';
import { LogisticCenterComponent } from './components/logistic-center/logistic-center.component';

import { CityService } from './services/city.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    CitiesComponent,
    RoutesComponent,
    MapComponent,
    LogisticCenterComponent
  ],
  imports: [
    FormsModule,
    BrowserModule,
    TableModule,
    DropdownModule,
    ButtonModule,
    HttpClientModule,
    AppRoutingModule,
  ],
  providers: [
    CityService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
