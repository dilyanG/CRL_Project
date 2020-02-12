import { Component, OnInit, Input, OnChanges, SimpleChange, Output, EventEmitter } from '@angular/core';
import { MessageService } from 'primeng/api';

import { CityService } from 'src/app/services/city.service';
import { CityModel } from '../../models/city.model';

@Component({
  selector: 'app-cities',
  templateUrl: './cities.component.html',
  providers: [MessageService],
  styleUrls: ['./cities.component.css']
})
export class CitiesComponent implements OnInit, OnChanges {

  @Input() changes: boolean;
  @Output() canAddRoutes: EventEmitter<boolean> = new EventEmitter<boolean>();


  cities: CityModel[] = [];
  showDialog = false;
  cityForAdd: CityModel;
  cityForEdit: CityModel;
  logisticCenter: CityModel;

  constructor(private cityService: CityService,
    private messageService: MessageService) { }

  ngOnInit() {
    this.getAllCities();
  }
  ngOnChanges(changes: { [propKey: string]: SimpleChange }) {
    this.changes = changes.changes.currentValue;
  }

  showAddDialog() {
    this.showDialog = true;
    this.cityForAdd = new CityModel();
  }
  addCity() {
    this.cityService.addCity(this.cityForAdd).subscribe(
      res => {
        this.showDialog = false;
        this.cityForAdd = undefined;
        this.changes = true;
        this.getAllCities();
      }
    );
  }

  closeAddDialog() {
    this.showDialog = false;
    this.cityForAdd = undefined;
  }

  getAllCities() {
    this.cityService.getCities().subscribe(
      res => {
        this.cities = res as CityModel[];
        if (this.cities.length > 1)
          this.canAddRoutes.emit(true);
      }
    )
  }
  findLogisticCenter() {
    this.cityService.findLogisticCenter().subscribe(
      res => {
        this.logisticCenter = res;
        this.changes = false;
      }
    )
  }

  onRowEditInit(city: CityModel) {
    this.cityForEdit = city;
  }

  onRowEditSave(city: CityModel) {
    this.cityService.checkCityName(city.id, city.name).subscribe(
      res => {
        if (res) {
          this.messageService.add({ severity: 'success', summary: 'Success', detail: 'City is updated' });
          this.cityService.updateCity(city).subscribe(
            res => {
              this.changes = true;
              this.getAllCities();
            }
          )
        } else {
          this.messageService.add({ severity: 'error', summary: 'Error', detail: 'Name is not unique' });
          this.cities[this.cities.findIndex(c => c.id == this.cityForEdit.id)] = this.cityForEdit;
          this.cityForAdd = undefined;
        }
      }
    )
  }

  onRowEditCancel(city: CityModel, index: number) {
    this.cities[index] = this.cityForEdit;
    this.cityForAdd = undefined;
  }
}
