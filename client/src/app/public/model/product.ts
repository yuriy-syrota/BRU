import { IReferenceData } from "./reference-data";

export interface IProduct {
    id: number;
    name: string;
    description: string;
    rating?: number;
    price: number;
    productTypeId: number;
    bikeTypeId?: number;
    brandId: number;
    imageId?: number;
    bikeType?: IReferenceData;
    brand?: IReferenceData;
    productType?: IReferenceData;
}