export interface KeyValueResource {
    id: number;
    name: string;
}

export interface Vehicle {
    id: number;
    make: KeyValueResource;
    model: KeyValueResource;
    features: KeyValueResource[];

}

export interface SaveVehicle {
    id: number;
    makeId: number;
    modelId: number;
    features: number[];
}