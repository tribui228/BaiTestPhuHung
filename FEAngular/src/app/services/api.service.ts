import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  private apiUrl = 'https://localhost:44385/api/'; // URL của API
  constructor(private http: HttpClient) { }

  getallproduct(){
    return this.http.get<any>(this.apiUrl+'Products');
  }
  AddProducts(ProductsObj: any) {
    return this.http.post<any>(`${this.apiUrl}Products`, ProductsObj)
  }
  deleteProduct(productId: number): Observable<any> {
    return this.http.delete<any>(`${this.apiUrl}Products/${productId}`);
  }

  updateProduct(productObj: any): Observable<any> {
    return this.http.put<any>(`${this.apiUrl}Products/${productObj.id}`, productObj);
  }
}
