import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { MessageService } from 'primeng/api';
import { Observable } from 'rxjs';
import { IInventory } from '../model/inventory';
import { IReferenceData } from '../model/reference-data';
import { BruService } from '../services/bru.service';

@Component({
  selector: 'app-edit-product',
  templateUrl: './edit-product.component.html',
  styleUrls: ['./edit-product.component.css']
})
export class EditProductComponent implements OnInit {

  @Input() showDialog: boolean;
  @Output() showDialogChange = new EventEmitter<boolean>();
  @Output() productUpdated = new EventEmitter();

  @Input() inventoryProduct: IInventory;

  productTypes$: Observable<IReferenceData[]>;
  bikeTypes$: Observable<IReferenceData[]>;
  brands$: Observable<IReferenceData[]>;

  constructor(private svc: BruService, private messageService: MessageService) { }

  ngOnInit(): void {
    this.productTypes$ = this.svc.getProductTypes();
    this.bikeTypes$ = this.svc.getBikeTypes();
    this.brands$ = this.svc.getBrands();

    if (!this.inventoryProduct) {
      this.inventoryProduct = {
        id: 0,
        productId: 0,
        product: {
          id: 0,
          name: '',
          description: '',
          rating: undefined,
          price: 0,
          productTypeId: 0,
          bikeTypeId: undefined,
          brandId: 0,
          imageId: undefined
        }
      };
    }
  }

  onShowDialogChange(val: boolean) {
    this.showDialogChange.emit(val);
  }

  onSave() {
    this.svc.putInventory(this.inventoryProduct).subscribe(success => {
      if (success) {
        this.messageService.add({ key: 'globalToast', life: 3000, severity: 'success', summary: 'Success', detail: 'The prduct record was updated.' });
        this.productUpdated.emit();
      }
    });
  }
}
