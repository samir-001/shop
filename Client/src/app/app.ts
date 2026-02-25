import { Component, signal } from '@angular/core';
import {MatMenuModule} from '@angular/material/menu';
import {MatButtonModule} from '@angular/material/button';
import { Header } from "./layout/header/header";

@Component({
  selector: 'app-root',
  imports: [MatButtonModule, MatMenuModule, Header],
  templateUrl: './app.html',
  styleUrl: './app.scss'
})
export class App {
  protected readonly title = signal('shop');
}
