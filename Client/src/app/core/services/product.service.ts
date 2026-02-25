import { inject, Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { Product } from '../../shared/models/product';
import { pagination } from '../../shared/pagination';
@Injectable({
  providedIn: 'root',
})
export class ProductService {
  http = inject(HttpClient);
   apiUrl = environment.apiUrl;

  getProducts(): Observable<pagination<Product>> {
    return this.http.get<pagination<Product>>(`${this.apiUrl}/products`);
  }
}
