import { Component, OnInit } from '@angular/core';
import { RouteService } from 'src/app/services/route.service';
import { RouteModel } from 'src/app/models/route.model';
import { CityModel } from '../../models/city.model';
import { CityService } from '../../services/city.service';

@Component({
  selector: 'app-routes',
  templateUrl: './routes.component.html',
  styleUrls: ['./routes.component.css']
})
export class RoutesComponent implements OnInit {

  routes: RouteModel[] = [];
  showDialog = false;
  routeForAdd: RouteModel;
  filteredCitiesSingle: CityModel[] = [];

  constructor(private routeService: RouteService,
              private cityService: CityService) { }

  ngOnInit() {
    this.getAllRoutes();
  }

  showAddDialog() {
    this.showDialog = true;
    this.routeForAdd = new RouteModel();
  }
  addRoute() {
    this.routeForAdd
    this.routeService.addRoute(this.routeForAdd).subscribe(
      res => {
        this.showDialog = false;
        this.routeForAdd = undefined;
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
      res=>{
        this.filteredCitiesSingle=res;
      }
    );

  }
}
