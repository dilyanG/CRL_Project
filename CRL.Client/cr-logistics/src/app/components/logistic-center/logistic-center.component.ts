import { Component, OnInit } from '@angular/core';
import { CityService } from '../../services/city.service';

@Component({
  selector: 'app-logistic-center',
  templateUrl: './logistic-center.component.html',
  styleUrls: ['./logistic-center.component.css']
})
export class LogisticCenterComponent implements OnInit {

  areThereAnyChanges: boolean = false;

  constructor(private cityService: CityService) { }

  ngOnInit() {
    this.checkForLogisticCenter();
  }
  updateChangesForLC(){
    this.areThereAnyChanges = true;
  }
  checkForLogisticCenter(){
    this.cityService.checkForLogisticCenter().subscribe(
      res=>{
        this.areThereAnyChanges=res;
      }
    )
  }
}
