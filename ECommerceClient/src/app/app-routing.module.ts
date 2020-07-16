import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { OrderComponent } from './order/order.component';
import { ShopcartComponent } from './shopcart/shopcart.component';
import { SupplierComponent } from './supplier/supplier.component';
import { ProductComponent } from './product/product.component';
import { SupplierEditComponent } from './supplier-edit/supplier-edit.component';


const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'order', component: OrderComponent },
  { path: 'shopcart', component: ShopcartComponent },
  { path: 'supplier', component: SupplierComponent },
  { path: 'product', component: ProductComponent },
  { path: 'supplier-edit/:id', component:SupplierEditComponent},
  { path: 'supplier-edit', component:SupplierEditComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
