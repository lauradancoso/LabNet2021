import { Component, OnInit } from '@angular/core';
import {Router} from "@angular/router"


import {Categories} from '../models/categories';
import {CategoriesService} from '../services/categories.service';
import { ThemeService } from 'src/app/services/theme.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  dark:boolean;

  constructor(private categoriesService:CategoriesService,private router: Router,private themeService:ThemeService){ }

  ngOnInit(): void {
    this.themeService.darkTheme$.subscribe(data=>this.dark = data)
  }
  setFormAction(formAction:string, category:Categories){
    this.categoriesService.setFormAction(formAction);
    this.setCategorySelected(category);
  }
  setCategorySelected(category:Categories){
    this.categoriesService.setCategorySelected(category)
  }
  changeTheme(){
    this.themeService.setTheme(!this.dark);
  }

}

