import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { RouteModel } from '../models/route.model';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class RouteService {

  constructor(private http: HttpClient) { }
  
  getCities(): Observable<RouteModel[]> {
    return this.http.get<RouteModel[]>(environment.webApi + "route/all");
  }
}
