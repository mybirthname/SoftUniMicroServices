import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NotificationService } from '../notification.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  
  constructor(private router: Router, private notificationsService: NotificationService ) { 
  }

  get isAuthenticated():boolean{
    return localStorage.getItem("token") != null;
  }

  ngOnInit() {
    this.notificationsService.subscribe();
  }

  logOut()
  {
    localStorage.removeItem("token");
    this.router.navigate(['/login']);
  }

}
