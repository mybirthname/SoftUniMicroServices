import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { stringify } from 'querystring';


@Component({
  selector: 'app-supplier-edit',
  templateUrl: './supplier-edit.component.html',
  styleUrls: ['./supplier-edit.component.css']
})
export class SupplierEditComponent implements OnInit {

  supplierId;
  form:FormGroup;
  constructor(private http:HttpClient, private fb:FormBuilder, private router: Router, private activatedRoute:ActivatedRoute) { 
    this.supplierId = this.activatedRoute.snapshot.params["id"];

      this.form = this.fb.group({
        nrIntern: [''],
        name: [''],
        email:[''],
        address: [''],
        bank: [''],
        iban: [''],
      });
  }

  ngOnInit() {
    if(this.supplierId)
    {
      this.http.get<any>(environment.apiGetway + '/supplier/GetById', 
        {
          headers: {'Authorization': 'Bearer ' + localStorage.getItem('token')},
          params: {'id': this.supplierId}
        })
      .subscribe(x=>{
        this.form.get('nrIntern').setValue(x.nrIntern);
        this.form.get('name').setValue(x.name);
        this.form.get('email').setValue(x.email);
        this.form.get('address').setValue(x.address);
        this.form.get('bank').setValue(x.bank);
        this.form.get('iban').setValue(x.iban);


      });
    }
  }
  supplier: ISupplier

  save(){
    this.supplier = this.form.value;
    let additionUrl = '';
    if(this.supplierId)
      additionUrl += '/' + this.supplierId; 

    this.http.post<any>(environment.apiGetway + '/supplier/save' + additionUrl, this.supplier,        
    {
      headers: {'Authorization': 'Bearer ' + localStorage.getItem('token')},
    }).subscribe(x=>this.router.navigate(["/supplier"]));
  }



}

interface ISupplier
{
   NrIntern: String;
   Name:String;
   Email:String;
   Bank:String;
   IBAN: String;
   Address:String;
}
