import { IProduct } from "./product";

export interface IInventory {
    id: number;
    productId: number;
    quantity?: number;
    product: IProduct;
}