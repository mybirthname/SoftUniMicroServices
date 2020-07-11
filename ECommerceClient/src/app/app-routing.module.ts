import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { OrderComponent } from './order/order.component';
import { ShopcartComponent } from './shopcart/shopcart.component';
import { SupplierComponent } from './supplier/supplier.component';
import { ProductComponent } from './product/product.component';


const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'order', component: OrderComponent },
  { path: 'shopcart', component: ShopcartComponent },
  { path: 'supplier', component: SupplierComponent },
  { path: 'product', component: ProductComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
