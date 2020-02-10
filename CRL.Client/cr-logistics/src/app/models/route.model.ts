import { CityModel } from './city.model';

export class RouteModel {
    id: number;
    name: string;
    start: CityModel;
    end: CityModel;
    twoway: boolean = true;
    createdOn = Date.now;
}