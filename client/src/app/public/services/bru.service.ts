import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { IInventory } from '../model/inventory';
import { IReferenceData } from '../model/reference-data';

@Injectable({
  providedIn: 'root'
})
export class BruService {

  constructor(private httpClient: HttpClient) { }

  getInventory(): Observable<IInventory[]> {
    return this.httpClient.get<IInventory[]>(`${environment.apiUrlBase}/inventory`).pipe(catchError(this.handleError));
  }

  getProductTypes(addAny = false): Observable<IReferenceData[]> {
    return this.httpClient.get<IReferenceData[]>(`${environment.apiUrlBase}/reference/ProductTypes`).pipe(
      tap((data: IReferenceData[]) => {
        if (addAny) {
          data.unshift({ id: undefined, name: 'Any' });
        }
        return data;
      }),
      catchError(this.handleError)
    );
  }

  getBikeTypes(addAny = false): Observable<IReferenceData[]> {
    return this.httpClient.get<IReferenceData[]>(`${environment.apiUrlBase}/reference/BikeTypes`).pipe(
      tap((data: IReferenceData[]) => {
        if (addAny) {
          data.unshift({ id: undefined, name: 'Any' });
        }
        return data;
      }),
      catchError(this.handleError));
  }

  getBrands(addAny = false): Observable<IReferenceData[]> {
    return this.httpClient.get<IReferenceData[]>(`${environment.apiUrlBase}/reference/Brands`).pipe(
      tap((data: IReferenceData[]) => {
        if (addAny) {
          data.unshift({ id: undefined, name: 'Any' });
        }
        return data;
      }),
      catchError(this.handleError));
  }

  putInventory(data: IInventory): Observable<boolean> {
    return this.httpClient.put<boolean>(`${environment.apiUrlBase}/inventory`, data).pipe(catchError(this.handleError));
  }

  deleteInventory(id: string): Observable<boolean> 
  {
    return this.httpClient.delete<boolean>(`${environment.apiUrlBase}/inventory/${id}`).pipe(catchError(this.handleError));
  }

  private handleError(err: HttpErrorResponse) {
    if (!environment.production)
      console.log(err);

    return throwError(err);
  }
}
