import { Component, OnInit } from '@angular/core';
import { VehicleService } from "../../services/vehicles.service";
import { Vehicle, SaveVehicle, KeyValueResource, Make } from "../../models/vehicle";

@Component({
    selector: 'vehicle-list',
    templateUrl: './vehicleList.component.html',
    styleUrls: ['./vehicleList.component.css'],
    providers: [
        { provide: VehicleService, useClass: VehicleService}]
})
export class VehicleListComponent implements OnInit {

    vehicles: Vehicle[];
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
        console.log(this.makes);
    }

    onMakeChange() {
        var selectedMake = this.makes.find(m => m.id == this.filter.makeId);
        this.models = selectedMake ? selectedMake.models : [];
        delete this.filter.modelId; 
    }

    onFilterChange() {
        this.vehicleService.getVehicles(this.filter).subscribe(x => {
            this.vehicles = x.items;
            this.totalItems = x.itemsCount;
        });
    }

    onFeaturesChange(id: number) {
        console.log("click");
        this.selectedFeatures.push(id);
    }
}
