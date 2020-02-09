import { Component, OnInit } from '@angular/core';
import { RouteService } from 'src/app/services/route.service';
import { RouteModel } from 'src/app/models/route.model';

@Component({
  selector: 'app-routes',
  templateUrl: './routes.component.html',
  styleUrls: ['./routes.component.css']
})
export class RoutesComponent implements OnInit {

  routes: RouteModel[]=[];

  constructor(private routeService: RouteService) { }

  ngOnInit() {
    this.routeService.getCities().subscribe(
      res=>{
        this.routes=res as RouteModel[];
      }
    )
  }

  addRoute(){
    
  }

}
