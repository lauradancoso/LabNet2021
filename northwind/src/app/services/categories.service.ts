import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse,HttpHeaders } from '@angular/common/http';
import { BehaviorSubject, Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Categories } from '../models/categories';
import { environment } from 'src/environments/environment';

import Swal from 'sweetalert2'

@Injectable({
  providedIn: 'root'  
})
export class CategoriesService {
  
  private formAction =new BehaviorSubject<string>('');
  formAction$= this.formAction.asObservable();

  private categorySelected =new BehaviorSubject<Categories>({CategoryID:0, CategoryName:'',Description:''});
  categorySelected$= this.categorySelected.asObservable();

  constructor(private http: HttpClient) {
    this.setFormAction("Add")
   }

  //TODO: revisar esto
  private handleError(error: HttpErrorResponse) {
    if (error) {
      Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'Something went wrong!'
      })
    }
    // Return an observable with a user-facing error message.
    return throwError(
      'Something bad happened; please try again later.');
  }

  setFormAction(formAction:string){
    this.formAction.next(formAction);
  }
  setCategorySelected(category:Categories){
    this.categorySelected.next(category);
  }

  getCategories():Observable<Categories[]>{
    return this.http.get<Categories[]>(environment.categories + '/categories').pipe(
      catchError(this.handleError)
    );
  }
  deleteCategory(id: number): Observable<{}> {
    return this.http.delete(environment.categories + '/categories/' + id, {headers: new HttpHeaders({
      'Content-Type':  'application/json'})})
      .pipe(
        catchError(this.handleError)
      );
  }
  postCategory(request:Categories){
    return this.http.post(environment.categories + '/categories', request).pipe(catchError(this.handleError));
  }
  editCategory(request:Categories){
    return this.http.patch(environment.categories + '/categories', request).pipe(catchError(this.handleError));
  }
}
