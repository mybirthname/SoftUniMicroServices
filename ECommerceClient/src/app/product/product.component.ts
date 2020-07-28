import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {

  product: Array<any>
  constructor(private http:HttpClient, private router: Router) { }

  ngOnInit() {
    let headers = new HttpHeaders();

    this.http.get<Array<any>>(environment.apiGetway + "/product/getlist", {headers: {'Authorization': 'Bearer ' + localStorage.getItem('token')}}).subscribe(x=> {
      this.product = x
    })

  }

  newProduct(){
    
    this.router.navigate(['/product-edit']);

  }

  editProduct(id)
  {
    this.router.navigate(['/product-edit/' + id]);
  }
}


