import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule, Validators, FormBuilder} from '@angular/forms'
import { RouterModule }  from '@angular/router'
import { HttpClientModule } from '@angular/common/http'
import {MatPaginatorModule} from '@angular/material/paginator'
import {MatTableModule} from '@angular/material/table';
// import {PopupModule} from 'ng2-opd-popup';
import {MatDialogModule } from '@angular/material/dialog';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RegisterCutomerComponent } from './Components/register-cutomer/register-cutomer.component';
import { HeaderComponent } from './Components/header/header.component';
import { FooterComponent } from './Components/footer/footer.component';
import { ProductDetailsComponent } from './Components/product-details/product-details.component';
import { WomenProductComponent } from './Components/women-product/women-product.component';
import { MenComponent } from './Components/men/men.component';
import { KidsComponent } from './Components/kids/kids.component';
import { OthersComponent } from './Components/others/others.component';
import { HomePageComponent } from './Components/home-page/home-page.component';
import { LoginCustomerComponent } from './Components/login-customer/login-customer.component';
import { CartComponent } from './Components/cart/cart.component';
import { ProfileComponent } from './Components/profile/profile.component';
import { OrdersComponent } from './Components/orders/orders.component';
import { appRoute } from './routes';






@NgModule({
  declarations: [
    AppComponent,
    RegisterCutomerComponent,
    HeaderComponent,
    FooterComponent,
    ProductDetailsComponent,
    WomenProductComponent,
    MenComponent,
    KidsComponent,
    OthersComponent,
    HomePageComponent,
    LoginCustomerComponent,
    CartComponent,
    ProfileComponent,
    OrdersComponent,

    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule ,
    FormsModule , 
    RouterModule.forRoot(appRoute) ,
    HttpClientModule ,
    ReactiveFormsModule , 
    MatPaginatorModule ,
    MatTableModule,
    MatDialogModule,
    BrowserAnimationsModule
  ],
  providers: [],
  bootstrap: [AppComponent] ,
  entryComponents : [ProductDetailsComponent]
})
export class AppModule { }
