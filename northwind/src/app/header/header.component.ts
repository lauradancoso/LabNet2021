import { Component, OnInit } from '@angular/core';
import {Router} from "@angular/router"


import {Categories} from '../models/categories';
import {CategoriesService} from '../services/categories.service'

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  constructor(private categoriesService:CategoriesService,private router: Router){ }

  ngOnInit(): void {
  }
  setFormAction(formAction:string, category:Categories){
    this.categoriesService.setFormAction(formAction);
    this.setCategorySelected(category);
  }
  setCategorySelected(category:Categories){
    this.categoriesService.setCategorySelected(category)
  }

}

