import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { LoginComponent } from './login/login.component';
import { OrderComponent } from './order/order.component';
import { ProductComponent } from './product/product.component';
import { SupplierComponent } from './supplier/supplier.component';
import { ShopcartComponent } from './shopcart/shopcart.component';
import { ReactiveFormsModule } from '@angular/forms';
import { SupplierEditComponent } from './supplier-edit/supplier-edit.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    LoginComponent,
    OrderComponent,
    ProductComponent,
    SupplierComponent,
    ShopcartComponent,
    SupplierEditComponent
    
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    ToastrModule.forRoot()
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
