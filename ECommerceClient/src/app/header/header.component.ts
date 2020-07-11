import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  
  constructor(private router: Router ) { 
  }

  get isAuthenticated():boolean{
    return localStorage.getItem("token") != null;
  }

  ngOnInit() {
  }

  logOut()
  {
    console.log('test');
    localStorage.removeItem("token");
    this.router.navigate(['/login']);
  }

}
