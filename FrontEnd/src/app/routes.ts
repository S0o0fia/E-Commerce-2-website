import { Routes } from '@angular/router'
import { HomePageComponent } from './Components/home-page/home-page.component';
import { OthersComponent } from './Components/others/others.component';
import { KidsComponent } from './Components/kids/kids.component';
import { WomenProductComponent } from './Components/women-product/women-product.component';
import { MenComponent } from './Components/men/men.component';
import { CartComponent } from './Components/cart/cart.component';
import { LoginCustomerComponent } from './Components/login-customer/login-customer.component';
import { ProductDetailsComponent } from './Components/product-details/product-details.component';
import { ProfileComponent } from './Components/profile/profile.component';
import { OrdersComponent } from './Components/orders/orders.component';
import { RegisterCutomerComponent } from './Components/register-cutomer/register-cutomer.component';




export const appRoute: Routes = [
    {
       path :'home' , 
       component:HomePageComponent   
    }
    ,
    {
        path: 'others',
        component: OthersComponent,
    }
    ,
    {
        path: 'kids',
        component: KidsComponent

    }
    ,
    {
        path: 'women',
        component: WomenProductComponent
    }


    ,
    {
        path: 'men',
        component: MenComponent
    }
    ,
    {
        path:'register',
        component:RegisterCutomerComponent
    }
    ,
    {
        path : "cart",
        component : CartComponent

    }
    ,
    {
        path : 'login' ,
        component : LoginCustomerComponent
    }
    ,
    {
        path : 'productdeatils/:type/:id',
        component : ProductDetailsComponent
    }
    ,
    {
        path :'profile' ,
        component : ProfileComponent
    }
    ,
    {
        path : 'orders' , 
        component : OrdersComponent
    }
    ,
    {
        path: '', redirectTo: '/home', pathMatch: 'full'
    }

];