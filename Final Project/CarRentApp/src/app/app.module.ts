import { BrowserModule } from '@angular/platform-browser';
import { NgModule} from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { AgmCoreModule } from '@agm/core';


import { AppComponent } from './app.component';
import { MainComponent } from './main/main.component';
import { HomeComponent } from './home/home.component';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { LogInComponent } from './log-in/log-in.component';
import { Page404Component } from './page404/page404.component';
import { CarsComponent } from './cars/cars.component';
import { ContactUsComponent } from './contact-us/contact-us.component';
import { BranchesComponent } from './branches/branches.component';
import { SignUpComponent } from './sign-up/sign-up.component';
import { BranchService } from './shared/services/branch.service';
import { CarService } from './shared/services/car.service';
import { CarDetailsComponent } from './car-details/car-details.component';
import { CarTypeService } from './shared/services/car-type.service';
import { UsersComponent } from './users/users.component';
import { UserService } from './shared/services/user.service';
import { EditUserComponent } from './edit-user/edit-user.component';
import { AddEditCarComponent } from './add-edit-car/add-edit-car.component';
import { OrderService } from './shared/services/order.service';
import { OrdersComponent } from './orders/orders.component';
import { AddOrderComponent } from './add-order/add-order.component';
import { EditOrderComponent } from './edit-order/edit-order.component';
import { AddCarTypeComponent } from './add-car-type/add-car-type.component';
import { CarTypesComponent } from './car-types/car-types.component';
import { EditCarTypeComponent } from './edit-car-type/edit-car-type.component';


const appRoutes: Routes = [
 
  { path: 'home', component: HomeComponent },
  { path: 'cars', component: CarsComponent },
  { path: 'cars/addCar', component: AddEditCarComponent },
  { path: 'cars/add-car-type', component: AddCarTypeComponent },
  { path: 'cars/:CarNumber', component: CarDetailsComponent },
  { path: 'cars/edit/:CarNumber', component: AddEditCarComponent },
  { path: 'car-types', component: CarTypesComponent },
  { path: 'car-types/:Model', component: EditCarTypeComponent },
  { path: 'add-order', component: AddOrderComponent },
  { path: 'orders', component: OrdersComponent },
  { path: 'orders/:CarNumber', component: EditOrderComponent },
  { path: 'contact', component: ContactUsComponent },
  { path: 'branches', component: BranchesComponent },
  { path: 'users', component: UsersComponent },
  { path: 'users/:UserName', component: EditUserComponent },
  { path: 'add-user', component: SignUpComponent },
  { path: 'login', component: LogInComponent },

  { path: '',
    redirectTo: '/home',
    pathMatch: 'full'
  },
 
 { path: '**', component: Page404Component }
  
];


@NgModule({
  declarations: [
    AppComponent,
    MainComponent,
    HomeComponent,
    HeaderComponent,
    FooterComponent,
    LogInComponent,
    Page404Component,
    CarsComponent,
    ContactUsComponent,
    BranchesComponent,
    SignUpComponent,
    CarDetailsComponent,
    AddOrderComponent,
    UsersComponent,
    EditUserComponent,
    AddEditCarComponent,
    OrdersComponent,
    EditOrderComponent,
    AddCarTypeComponent,
    CarTypesComponent,
    EditCarTypeComponent
  ],
  imports: [
    BrowserModule,
    //NgbModule,
    HttpClientModule,
    RouterModule.forRoot(appRoutes),
    FormsModule,
    AgmCoreModule.forRoot({
      apiKey: 'AIzaSyDdCphDNz1W8_5bARYdpVEPoFq-wuIuSmI'
    })
  ],
  
  providers: [BranchService,CarService,CarTypeService,UserService,OrderService],
  bootstrap: [AppComponent]
})
export class AppModule { }
