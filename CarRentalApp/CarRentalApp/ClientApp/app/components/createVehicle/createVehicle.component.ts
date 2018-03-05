//import * as _ from "underscore";
import { Component, OnInit } from '@angular/core';
import { VehicleService } from "../../services/vehicles.service";
import { Vehicle, SaveVehicle, KeyValueResource, Make } from "../../models/vehicle";
import { ActivatedRoute, Router } from "@angular/router";
import { Observable } from "rxjs/Observable";
import "rxjs/add/Observable/forkJoin";

@Component({
    selector: 'create-vehicle',
    templateUrl: './createVehicle.component.html',
    styleUrls: ['./createVehicle.component.css'],
    providers: [
        { provide: VehicleService, useClass: VehicleService}]
})
export class CreateVehicleComponent implements OnInit {

    vehicle: SaveVehicle = {
        id: 0,
        makeId: 0,
        modelId: 0,
        features: []
        };
    makes: Make[];
    models: KeyValueResource[];
    features: KeyValueResource[];
    selectedFeatures: any = [];
    totalItems: number;
    filter: any = {
        pagesize: 5
    };

    constructor(
        private vehicleService: VehicleService) {

    }

    ngOnInit() {
        this.vehicleService.getMakes().subscribe(m => this.makes = m);
        this.vehicleService.getFeatures().subscribe(f => this.features = f);
    }

    onMakeChange() {
        var selectedMake = this.makes.find(m => m.id == this.vehicle.makeId);
        this.models = selectedMake ? selectedMake.models : [];
        delete this.filter.modelId; 
    }

    onFilterChange() {

    }

    onFeatureToggle(id: any, $event: any) {
        if ($event.target.checked)
            this.vehicle.features.push(id);
        else {
            var index = this.vehicle.features.indexOf(id);
            this.vehicle.features.splice(index);
        }
    }

    submit() {
        this.vehicleService.createVehicle(this.vehicle)
            .subscribe(
            x => console.log(x)
        );
        }
}
