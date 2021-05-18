import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class ThemeService {

  private darkTheme =new BehaviorSubject<boolean>(false);
  darkTheme$= this.darkTheme.asObservable();

  constructor() { }

  setTheme(dark:boolean){
    this.darkTheme.next(dark);
  }
}
