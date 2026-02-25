import { Component } from '@angular/core';
import {MatBadgeModule} from '@angular/material/badge';
import  {MatButtonModule} from '@angular/material/button';
import {MatIconModule} from '@angular/material/icon';


@Component({
  selector: 'app-header',
  imports: [MatBadgeModule, MatIconModule,MatButtonModule],
  templateUrl: './header.html',
  styleUrl: './header.scss',
})
export class Header {

}
