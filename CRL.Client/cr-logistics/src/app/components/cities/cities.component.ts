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

  constructor(private cityService: CityService) { }

  ngOnInit() {
    this.cityService.getCities().subscribe(
      res=>{
        this.cities=res as CityModel[];
      }
    )
  }
  addCity(){
    this.cities= [ new CityModel(), ...this.cities ]
  }
}
