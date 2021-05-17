import { Component, OnInit} from '@angular/core';
import {Router} from "@angular/router"

import {Categories} from '../../models/categories';
import {CategoriesService} from '../../services/categories.service'

import Swal from 'sweetalert2'

@Component({
  selector: 'app-categories',
  templateUrl: './categories.component.html',
  styleUrls: ['./categories.component.css']
})
export class CategoriesComponent implements OnInit {

  color = "warn";
  mode = "indeterminate"

  loading:boolean = true;

  categories!:Categories[];

  constructor(private categoriesService:CategoriesService,private router: Router) { 
    
  }

  ngOnInit(): void {
    this.setCategorySelected({CategoryID:0, CategoryName:'',Description:''})
    this.getCategories()
  }
  
  setFormAction(formAction:string, category:Categories){
    this.categoriesService.setFormAction(formAction);
    this.setCategorySelected(category);
    this.router.navigate(['/addOrEdit']);
  }
  setCategorySelected(category:Categories){
    this.categoriesService.setCategorySelected(category)
  }
  
  getCategories(){
    this.categoriesService.getCategories().subscribe(data=>{
      this.categories = data
      this.loading=false;
    });
  }
  deleteCategory(id:number){
    this.categoriesService.deleteCategory(id).subscribe(r=>
      this.getCategories()
    );
  }
  
}