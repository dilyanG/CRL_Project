import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule }    from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {TableModule} from 'primeng/table';
import {DropdownModule} from 'primeng/dropdown';
import {ButtonModule} from 'primeng/button';
import {DialogModule} from 'primeng/dialog';
import {AutoCompleteModule} from 'primeng/autocomplete';
import {SpinnerModule} from 'primeng/spinner';
import {InputMaskModule} from 'primeng/inputmask';
import {CheckboxModule} from 'primeng/checkbox';

import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { CitiesComponent } from './components/cities/cities.component';
import { RoutesComponent } from './components/routes/routes.component';
import { MapComponent } from './components/map/map.component';
import { LogisticCenterComponent } from './components/logistic-center/logistic-center.component';

import { CityService } from './services/city.service';
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
    BrowserAnimationsModule,
    TableModule,
    DropdownModule,
    ButtonModule,
    DialogModule,
    SpinnerModule,
    InputMaskModule,
    AutoCompleteModule,
    CheckboxModule,
    HttpClientModule,
    AppRoutingModule,
  ],
  providers: [
    CityService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
