import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Router } from '@angular/router';

@Component({
  selector: 'app-supplier',
  templateUrl: './supplier.component.html',
  styleUrls: ['./supplier.component.css']
})
export class SupplierComponent implements OnInit {

  supplier: Array<any>
  constructor(private http:HttpClient, private router: Router) { }

  ngOnInit() {
    let headers = new HttpHeaders();

    this.http.get<Array<any>>(environment.apiGetway + "/supplier/getlist", {headers: {'Authorization': 'Bearer ' + localStorage.getItem('token')}}).subscribe(x=> {
      this.supplier = x
    })
  }

  newSupplier(){
    
    this.router.navigate(['/supplier-edit']);

  }

  editSupplier(id)
  {
    this.router.navigate(['/supplier-edit/' + id]);
  }

}
