import { Component } from "@angular/core"

@Component({
    selector: 'my-employee',
    templateUrl: 'app/employee/employee.component.html'
})
export class EmployeeComponent {
    firstName: string = "James";
    lastName: string = "Bond";
    age: number = 30;
    gender: string = "Male";
    showDetails: boolean = false;

    name:string = "Tom";


    toggleDetails(): void {
        this.showDetails = !this.showDetails;
    }
}