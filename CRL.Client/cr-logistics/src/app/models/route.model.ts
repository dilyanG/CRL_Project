import { CityModel } from './city.model';

export class RouteModel {
    id: number;
    name: string;
    distance: number;
    start: CityModel;
    end: CityModel;
    twoway: boolean = true;
    createdOn = Date.now;
}