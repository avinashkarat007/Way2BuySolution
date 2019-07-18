import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms'
import { HttpModule } from '@angular/http';
import { RouterModule,Routes } from "@angular/router";

import { AppComponent } from './app.component';
import { EmployeeComponent } from "./employee/employee.component";
import { EmployeeListComponent } from "./employee/employeeList.component";
import { EmployeeTitlePipe } from "./employee/employeeTitle.pipe";
import { EmployeeCountComponent } from "./employee/employeeCount.component";
import { ProductComponent } from "./Products/product.component";
import { HomeComponent } from "./Home/home.component";
import { EmployeeService } from "./employee/employee.service"

const appRoutes: Routes = [
    {
        path: 'home', component: ProductComponent
    },
    {
        path: 'employees', component: EmployeeListComponent
    },
    {
        path: 'employees/:code', component: EmployeeComponent
    },
    {
        path: '', redirectTo : '/home', pathMatch : 'full'
    },
    {
        path: '**', component: HomeComponent
    }
];


@NgModule({
    imports: [BrowserModule, FormsModule, HttpModule, RouterModule.forRoot(appRoutes)],
    declarations: [AppComponent, EmployeeComponent, EmployeeListComponent, EmployeeTitlePipe, EmployeeCountComponent, ProductComponent, HomeComponent],
    bootstrap: [AppComponent],
    providers: [EmployeeService]
})
export class AppModule { }
