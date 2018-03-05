import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';
import { Vehicle, SaveVehicle } from "../models/vehicle";

@Injectable()
export class VehicleService {

    constructor(private http: Http) { }

    getMakes() {
        return this.http.get('api/makes')
            .map(res => res.json());
    }

    getFeatures() {
        return this.http.get('api/features')
            .map(res => res.json());
    }

    createVehicle(vehicle: any) {
        return this.http.post('api/vehicles', vehicle)
            .map(res => res.json());
    }

    updateVehicle(vehicle: SaveVehicle) {
        return this.http.put('api/vehicles/' + vehicle.id, vehicle)
            .map(res => res.json());
    }

    getVehicles(filter: any) {
        return this.http.get('api/vehicles' + '?' + this.toQueryString(filter))
            .map(res => res.json());
    }


    toQueryString(obj: any) {
        var parts = [];
        for (var property in obj) {
            var value = obj[property];
            if (value != null && value != undefined) {
                parts.push((encodeURIComponent(property) + '=' + encodeURIComponent(value)) as any);
            }
        }

        return parts.join('&');
    }
}