import { Component, OnInit } from '@angular/core';
import { VehicleService } from "../../services/vehicles.service";
import { Vehicle, SaveVehicle, KeyValueResource } from "../../models/vehicle";

@Component({
    selector: 'vehicle-list',
    templateUrl: './vehicleList.component.html',
    styleUrls: ['./vehicleList.component.css'],
    providers: [
        { provide: VehicleService, useClass: VehicleService}]
})
export class VehicleListComponent implements OnInit {

    vehicles: Vehicle[];
    makes: any[];
    models: KeyValueResource[];
    filter: any = {};

    constructor(
        private vehicleService: VehicleService) {

    }

    ngOnInit() {
        this.vehicleService.getMakes().subscribe(m => this.makes = m);
        console.log(this.makes);
    }

    onMakeChange() {
        var selectedMake = this.makes.find(m => m.id == this.filter.makeId);
        this.models = selectedMake ? selectedMake.models : [];
        delete this.filter.modelId; 
    }

    onFilterChange() {

     }
}
