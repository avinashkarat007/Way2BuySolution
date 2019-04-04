import { Component, OnInit } from "@angular/core"
import { ActivatedRoute } from "@angular/router"
import { EmployeeService } from "./employee.service"

@Component({
    selector: 'my-employee',
    templateUrl: 'app/employee/employee.component.html'
})
export class EmployeeComponent implements OnInit {
    employee: any;
    statusMessage:string ="";

    constructor(private _empService: EmployeeService, private _activatedRoute: ActivatedRoute ) {
        
    }

    ngOnInit() {
        var empCode: string = this._activatedRoute.snapshot.params["code"];

        this._empService.getEmployeesByCode(empCode).subscribe((empData) => {
            this.employee = empData;
        }, (error) => {
            this.statusMessage = "Problem with service";
            console.log(error);
        });
    }


}