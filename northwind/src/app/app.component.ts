import { Component, OnInit } from '@angular/core';
import { ThemeService } from './services/theme.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'northwind';
  dark:boolean;
  constructor(private themeService:ThemeService) { 
    this.themeService.setTheme(true);
  }
  ngOnInit():void{
    this.themeService.darkTheme$.subscribe(data=>this.dark = data)
  }
}
