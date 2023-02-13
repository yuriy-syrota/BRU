import { Component, OnInit } from '@angular/core';
import { BruService } from '../services/bru.service';
import { IInventory } from '../model/inventory';
import { Observable } from 'rxjs';
import { IReferenceData } from '../model/reference-data';
import { ConfirmationService } from 'primeng/api';

@Component({
  selector: 'app-inventory',
  templateUrl: './inventory.component.html',
  styleUrls: ['./inventory.component.css']
})
export class InventoryComponent implements OnInit {

  formData: IInventory[] = [];
  productToEdit: IInventory;
  showEditDialog = false;

  productTypes$: Observable<IReferenceData[]>;
  bikeTypes$: Observable<IReferenceData[]>;
  brands$: Observable<IReferenceData[]>;
  productTypeFilter: number;
  bikeTypesFilter: number;
  brandFilter: number;

  constructor(private svc: BruService, private confirmationService: ConfirmationService) { }

  async ngOnInit(): Promise<void> {
    this.productTypes$ = this.svc.getProductTypes(true);
    this.bikeTypes$ = this.svc.getBikeTypes(true);
    this.brands$ = this.svc.getBrands(true);

    await this.refresh();
  }

  async refresh(showHint: boolean = true) {
    this.svc.getInventory().subscribe(data => {
      this.formData = data;
    });
  }

  delete(inventoryId: string, rowIndex: number) {
    this.confirmationService.confirm({
      message: 'Are you sure you want to delete this product?',
      accept: () => {
        this.svc.deleteInventory(inventoryId).subscribe(result => {
          if (result) {
            this.formData.splice(rowIndex, 1);
          }
        });
      }
    });
  }

  edit(rowIndex: number) {
    this.showEditDialog = true;
    this.productToEdit = this.formData[rowIndex];
  }

  showAddProduct() {
    this.productToEdit = undefined;
    this.showEditDialog = true;
  }
}
