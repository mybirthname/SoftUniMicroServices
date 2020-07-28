import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-product-edit',
  templateUrl: './product-edit.component.html',
  styleUrls: ['./product-edit.component.css']
})
export class ProductEditComponent implements OnInit {

  productId;
  suppliers: Array<any>;
  form:FormGroup;
  constructor(private http:HttpClient, private fb:FormBuilder, private router: Router, private activatedRoute:ActivatedRoute) { 
    this.productId = this.activatedRoute.snapshot.params["id"];

      this.form = this.fb.group({
        nrIntern: [''],
        title: [''],
        pricePerPQ:[''],
        url: [''],
        description: [''],
        supplierID: [''],
        deliveryTime: ['']
      });


  
  }

  ngOnInit() {
    if(this.productId)
    {
      this.http.get<any>(environment.apiGetway + '/product/GetById', 
        {
          headers: {'Authorization': 'Bearer ' + localStorage.getItem('token')},
          params: {'id': this.productId}
        })
      .subscribe(x=>{
        this.form.get('nrIntern').setValue(x.nrIntern);
        this.form.get('title').setValue(x.title);
        this.form.get('description').setValue(x.description);
        this.form.get('pricePerPQ').setValue(x.pricePerPQ);
        this.form.get('url').setValue(x.url);
        this.form.get('deliveryTime').setValue(x.deliveryTime);
        this.form.get('supplierID').setValue(x.supplierID);

      });
    }

    this.http.get<Array<any>>(environment.apiGetway + "/product/GetSupplierList", {headers: {'Authorization': 'Bearer ' + localStorage.getItem('token')}}).subscribe(x=> {
      this.suppliers = x
    })

  }
  product: IProduct

  save(){
    this.product = this.form.value;
    console.log(JSON.stringify(this.product));
    let additionUrl = '';
    if(this.productId)
      additionUrl += '/' + this.productId; 

    this.http.post<IProduct>(environment.apiGetway + '/product/save' + additionUrl, this.product,        
    {
      headers: {'Authorization': 'Bearer ' + localStorage.getItem('token')},
    }).subscribe(x=>this.router.navigate(["/product"]));
  }

}

interface IProduct
{
   Title: String;
   NrIntern:String;
   PricePerPQ:Number;
   URL:String;
   Description: String;
   SupplierID:String;
   DeliveryTime:Date;
}
