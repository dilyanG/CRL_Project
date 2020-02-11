import { Component, OnInit } from '@angular/core';
import { CityModel } from 'src/app/models/city.model';
import { CityService } from 'src/app/services/city.service';

@Component({
  selector: 'app-cities',
  templateUrl: './cities.component.html',
  styleUrls: ['./cities.component.css']
})
export class CitiesComponent implements OnInit {

  cities: CityModel[]=[];
  showDialog = false;
  cityForAdd: CityModel;
  logisticCenter: CityModel;
  
  constructor(private cityService: CityService) { }

  ngOnInit() {
    this.getAllCities();
  }
  showAddDialog(){
    this.showDialog = true;
    this.cityForAdd = new CityModel();
  }
  addCity(){
    this.cityService.addCity(this.cityForAdd).subscribe(
      res=>{
        this.showDialog=false;
        this.cityForAdd=undefined;
        this.getAllCities();
      }
    );
  }

  closeAddDialog() {
    this.showDialog = false;
    this.cityForAdd = undefined;
  }

  getAllCities(){
    this.cityService.getCities().subscribe(
      res=>{
        this.cities=res as CityModel[];
      }
    )
  }
  findLogisticCenter(){
    this.cityService.findLogisticCenter().subscribe(
      res=>{
        this.logisticCenter = res;
      }
    )
  }
}
