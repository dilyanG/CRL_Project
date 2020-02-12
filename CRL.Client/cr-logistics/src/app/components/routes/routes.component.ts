import { Component, OnInit, EventEmitter, Output, SimpleChange, OnChanges } from '@angular/core';
import { MessageService } from 'primeng/api';

import { CityModel } from '../../models/city.model';
import { CityService } from '../../services/city.service';
import { RouteModel } from '../../models/route.model';
import { RouteService } from 'src/app/services/route.service';

@Component({
  selector: 'app-routes',
  templateUrl: './routes.component.html',
  providers: [MessageService],
  styleUrls: ['./routes.component.css']
})
export class RoutesComponent implements OnInit, OnChanges {

  @Output() changesEmitter = new EventEmitter<boolean>();

  routes: RouteModel[] = [];
  showDialog: boolean = false;
  canAdd: boolean = true;
  routeForAdd: RouteModel;
  routeForEdit: RouteModel;

  filteredCitiesSingle: CityModel[] = [];

  constructor(private routeService: RouteService,
    private cityService: CityService,
    private messageService: MessageService) { }

  ngOnInit() {
    this.getAllRoutes();
  }
  ngOnChanges(changes: { [propKey: string]: SimpleChange }) {
    this.canAdd = changes.canAdd.currentValue;
  }

  showAddDialog() {
    this.showDialog = true;
    this.routeForAdd = new RouteModel();
  }
  addRoute() {
    this.routeService.addRoute(this.routeForAdd).subscribe(
      res => {
        this.showDialog = false;
        this.routeForAdd = undefined;
        this.changesEmitter.emit(true);
        this.getAllRoutes();
      }
    );
  }

  closeAddDialog() {
    this.showDialog = false;
    this.routeForAdd = undefined;
  }

  getAllRoutes() {
    this.routeService.getRoutes().subscribe(
      res => {
        this.routes = res as RouteModel[];
      }
    )
  }

  filterCitySingle(event) {
    let query = event.query;
    this.cityService.getCitiesByName(query).subscribe(
      res => {
        this.filteredCitiesSingle = res;
      }
    );
  }

  onRowEditInit(route: RouteModel) {
    this.routeForEdit = route;
  }

  onRowEditSave(route: RouteModel) {
    if (route.distance > 0 || route.end.id != route.start.id) {
      this.messageService.add({ severity: 'success', summary: 'Success', detail: 'Route is updated' });
      this.routeService.updateRoute(route).subscribe(
        res => {
          this.changesEmitter.emit(true);
          this.getAllRoutes();
        }
      )
    } else {
      this.messageService.add({ severity: 'error', summary: 'Error', detail: 'Year is required' });
    }


  }

  onRowEditCancel(city: CityModel, index: number) {
    this.routes[index] = this.routeForEdit;
    this.routeForEdit = undefined;
  }
}
