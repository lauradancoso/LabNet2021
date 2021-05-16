import { Component, OnInit,OnDestroy} from '@angular/core';
import {Router} from "@angular/router"
import { FormBuilder,FormGroup,FormControl, Validators, MinLengthValidator } from '@angular/forms';
import { Categories } from 'src/app/models/categories';
import { CategoriesService } from 'src/app/services/categories.service';

import Swal from 'sweetalert2'
@Component({
  selector: 'app-category-form',
  templateUrl: './category-form.component.html',
  styleUrls: ['./category-form.component.css']
})
export class CategoryFormComponent implements OnInit {

  actionForm!:string;
  form!:FormGroup;
  isInvalid:boolean =false;
  categorySelected!: Categories;
  
  constructor(private readonly fb:FormBuilder, private categoriesService:CategoriesService,private router: Router) {
    this.getFormAction();
    this.getCategorySelected();
    
  }

  getFormAction(){
    this.categoriesService.formAction$.subscribe(formAction=>this.actionForm=formAction)
  }
  getCategorySelected(){
    this.categoriesService.categorySelected$.subscribe(category =>this.categorySelected=category)
  }

  ngOnInit(): void {
    this.configForm();
  }
  configForm(){
    this.form = this.fb.group({
      CategoryName: new FormControl(this.categorySelected.CategoryName,[Validators.required,Validators.maxLength(15)])!,
      Description : new FormControl(this.categorySelected.Description)
    });
  }
  get categoryName() { return this.form.get('CategoryName'); }
  
  onSubmit():void{
    if(this.form.invalid){
      this.isInvalid = true;
      Swal.fire({
        icon: 'error',
        title: 'Invalid inputs'
      })
    }else{
      this.addEditCategory(this.form.value);
    }
  }
  canReset():boolean{
    return (this.form.value.CategoryName != null || this.form.value.Description != null) && (this.form.value.CategoryName != '' || this.form.value.Description != '')
  }
  reset():void{
    if(this.canReset())
    Swal.fire({
      title: "Are you sure?",
      text: "The form will be reset",
      icon: "warning",
      showCancelButton: true,
      confirmButtonColor: "#3085d6",
      cancelButtonColor: "#d33",
      confirmButtonText: "Yes!",
    }).then((result) => {
      if (result.isConfirmed) {
        this.form.reset()
      }
    });
    
  }
  addEditCategory(category:Categories){
    if(this.actionForm == "Add"){
      console.log("add",category)
      this.categoriesService.postCategory(category).subscribe(r=>this.router.navigate(['/categories']));

    }
    if(this.actionForm == "Edit"){
      console.log("edit",category)
      this.categoriesService.editCategory({CategoryID:this.categorySelected.CategoryID, CategoryName: category.CategoryName, Description: category.Description}).subscribe(
        r=>this.router.navigate(['/categories'])
      );
    }
  }

}
