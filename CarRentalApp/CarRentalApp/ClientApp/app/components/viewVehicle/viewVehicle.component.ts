//import * as _ from "underscore";
import { Component, OnInit, ElementRef, ViewChild } from '@angular/core';
import { VehicleService } from "../../services/vehicles.service";
import { Vehicle, SaveVehicle, KeyValueResource, Make } from "../../models/vehicle";
import { ActivatedRoute, Router } from "@angular/router";
import { Observable } from "rxjs/Observable";
import "rxjs/add/Observable/forkJoin";

@Component({
    selector: 'view-vehicle',
    templateUrl: './viewVehicle.component.html',
    styleUrls: ['./viewVehicle.component.css'],
    providers: [
        { provide: VehicleService, useClass: VehicleService}]
})
export class ViewVehicleCompontent implements OnInit {
    @ViewChild("fileInput") fileInput: ElementRef;
    vehicle: {};
    vehicleId: number;

    constructor(
        private vehicleService: VehicleService,
        private router: Router,
        private route: ActivatedRoute) {
        route.params.subscribe(p => {
            this.vehicleId = +p["id"];
            if (isNaN(this.vehicleId) || this.vehicleId <= 0) {
                this.router.navigate(['/vehicles']);
                return;
            }
        });
    }

    ngOnInit() {
        var sources = [this.vehicleService.getVehicle(this.vehicleId)];

        this.vehicleService.getVehicle(this.vehicleId)
            .subscribe(v => this.vehicle = v);

        //Observable.forkJoin(sources).subscribe(data => {
        //    this.vehicle = data[0];
        //});
    }
}
