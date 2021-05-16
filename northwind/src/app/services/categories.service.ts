import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse,HttpHeaders } from '@angular/common/http';
import { BehaviorSubject, Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Categories } from '../models/categories';
import { environment } from 'src/environments/environment';
import { FormGroup } from '@angular/forms';

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
    if (error.status === 0) {
      // A client-side or network error occurred. Handle it accordingly.
      console.error('An error occurred:', error.error);
    } else {
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong.
      console.error(
        `Backend returned code ${error.status}, ` +
        `body was: ${error.error}`);
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
