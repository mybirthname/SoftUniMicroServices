import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {  FormGroup, FormBuilder } from '@angular/forms';
import { environment } from 'src/environments/environment';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  form:FormGroup;
  constructor(private http:HttpClient, private fb:FormBuilder, private router: Router  ) { 
    this.form = this.fb.group({
      email:[''],
      password:['']
    })
  }

  ngOnInit() {

  }

  login()
  {
    this.http.post<any>(environment.userSerivce + "/login", this.form.value).subscribe(x=>{
      localStorage.setItem("token", x.token);
      this.router.navigate(['/shopcart']);
    })
  }
}
