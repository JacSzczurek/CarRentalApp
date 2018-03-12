import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { Ng4LoadingSpinnerModule } from 'ng4-loading-spinner';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { VehicleListComponent } from './components/vehicleList/vehicleList.component';
import { CreateVehicleComponent } from "./components/createVehicle/createVehicle.component";
import { ViewVehicleCompontent } from "./components/viewVehicle/viewVehicle.component";
//import { HomeComponent } from './components/home/home.component';
//import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
//import { CounterComponent } from './components/counter/counter.component';
import { PaginationComponent } from './components/shared/pagination.component';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        VehicleListComponent,
        CreateVehicleComponent,
        //CounterComponent,
        //FetchDataComponent,
        //HomeComponent,
        PaginationComponent,
        ViewVehicleCompontent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        Ng4LoadingSpinnerModule.forRoot(),
        RouterModule.forRoot([
            { path: '', redirectTo: 'vehicles', pathMatch: 'full' },
            //{ path: 'home', component: HomeComponent },
            //{ path: 'counter', component: CounterComponent },
            //{ path: 'fetch-data', component: FetchDataComponent },
            { path: 'vehicles', component: VehicleListComponent },
            { path: 'vehicles/new', component: CreateVehicleComponent },
            { path: 'viewVehicle/:id', component: ViewVehicleCompontent },
            { path: '**', redirectTo: 'vehicles' }
        ])
    ]
})
export class AppModuleShared {
}
