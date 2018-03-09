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
    getVehicle(id: any) {
        return this.http.get('api/vehicles/' + id)
            .map(res => res.json());
    }

    getVehicles(filter: any) {
        var queryString = this.toQueryString(filter,null);
        return this.http.get('api/vehicles' + '?' + queryString)
            .map(res => res.json());
    }

    toQueryString(obj : any, prefix : any): string {
            var str = [],
                p;
            for (p in obj) {
                if (obj.hasOwnProperty(p)) {
                    var k = prefix ? prefix + "[" + p + "]" : p,
                        v = obj[p];
                    str.push(((v !== null && typeof v === "object") ?
                        this.toQueryString(v, k) :
                        encodeURIComponent(k) + "=" + encodeURIComponent(v)) as any);
                }
            }
            return str.join("&");
    }
}