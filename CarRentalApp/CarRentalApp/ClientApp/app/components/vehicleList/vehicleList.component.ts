import { Component, OnInit } from '@angular/core';
import { VehicleService } from "../../services/vehicles.service";
import { Vehicle, SaveVehicle, KeyValueResource, Make } from "../../models/vehicle";
import { LoadingModule } from 'ngx-loading';

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
    loading: true;
    models: KeyValueResource[];
    features: KeyValueResource[];
    selectedFeatures: any = [];
    totalItems: number;
    filter: any = {
        pageSize: 5,
        features: []
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
        this.onFilterChange();
    }

    onFilterChange() {
        this.vehicleService.getVehicles(this.filter).subscribe(x => {
            this.vehicles = x.items;
            this.totalItems = x.itemsCount;
        });
    }

    onFeatureToggle(id: any, $event: any) {
        if ($event.target.checked)
            this.filter.features.push(id);
        else {
            var index = this.filter.features.indexOf(id);
            this.filter.features.splice(index);
        }
        this.onFilterChange();
    }

    joinObject(a:any, attr: string) {
        var out = [];
        for (var i = 0; i < a.length; i++) {
            out.push(a[i][attr]);
        }
        return out.join(", ");
    }

        onPageChange(page: any) {
        this.filter.page = page;
        this.onFilterChange();
    }
}
