import { Component, OnInit } from '@angular/core';
import { CityService } from '../../services/city.service';

@Component({
  selector: 'app-logistic-center',
  templateUrl: './logistic-center.component.html',
  styleUrls: ['./logistic-center.component.css']
})
export class LogisticCenterComponent implements OnInit {

  areThereAnyChanges: boolean = false;
  canAddRoutes: boolean = true;

  constructor(private cityService: CityService) { }

  ngOnInit() {
    this.checkForLogisticCenter();
  }
  updateChangesForLC(event){
    this.areThereAnyChanges = event;
  }
  checkForLogisticCenter(){
    this.cityService.checkForLogisticCenter().subscribe(
      res=>{
        this.areThereAnyChanges=res;
      }
    )
  }
  updateCanAddRoutes(event){
    this.canAddRoutes = event;
  }
}
