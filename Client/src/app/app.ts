
import { Component, inject, OnInit, Signal, signal } from '@angular/core';
import {MatMenuModule} from '@angular/material/menu';
import {MatButtonModule} from '@angular/material/button';
import { Header } from "./layout/header/header";
import { ProductService } from './core/services/product.service';
import { Product } from './shared/models/product';
@Component({
  selector: 'app-root',
  imports: [MatButtonModule, MatMenuModule, Header],
  templateUrl: './app.html',
  styleUrl: './app.scss'
})
export class App implements OnInit {
  ngOnInit(): void {
    this.getProducts();}
  prodServices = inject(ProductService);
  protected readonly title = signal('shop');
  products = signal<Product[]>([]);

  getProducts() {
    this.prodServices.getProducts().subscribe({
      next: (res) => {
        this.products.set(res.data!);
        console.log(res);
      },
      error: (err) => {
        console.log(err);
      }
    })
  }
}
