import { Component, OnInit, OnDestroy } from "@angular/core"
import { EmployeeService } from "./employee.service"


@Component({
    selector: 'emp-list',
    templateUrl: 'app/employee/employeeList.component.html'    
})
export class EmployeeListComponent implements OnInit, OnDestroy {
    employees: any[];

    selectedEmployeeCountRadioButton: string = "All";

    statusMessage:string = "Loading data, please wait....";
 
    constructor(private empService: EmployeeService) {
        //this.employees = [{ code: "emp1", name: "Tom", gender: "Male", annualSalary: 55000 },
        //    { code: "emp2", name: "Mary", gender: "Female", annualSalary: 15000 },
        //    { code: "emp3", name: "Jerry", gender: "Male", annualSalary: 10000 },
        //    { code: "emp4", name: "Stephen", gender: "Male", annualSalary: 26000 },
        //    { code: "emp5", name: "Lisa", gender: "Female", annualSalary: 38000 },
        //    { code: "emp6", name: "Avinash", gender: "Male", annualSalary: 68000 },
        //    { code: "emp7", name: "Daisy", gender: "Female", annualSalary: 27000 },
        //    { code: "emp8", name: "Arjun", gender: "Male", annualSalary: 25000 },
        //    { code: "emp9", name: "Shinto", gender: "Male", annualSalary: 35000 },
        //    { code: "emp9", name: "Chris", gender: "Male", annualSalary: 40000 },
        //    { code: "emp9", name: "John", gender: "Male", annualSalary: 230000 }
        //];        
    }

    ngOnInit() {
        this.empService.getEmployees()
            .subscribe((empData) => {                                
                        this.employees = empData;                
                    },
                    (error) => {
                        this.statusMessage = "Problem with service, please try again";
                    });
    }

    ngOnDestroy() {
        console.log("Inside On Destroy");
    }

    getTotalEmployeesCount(): number {
        return this.employees.length;
    }

    getTotalMaleEmployeesCount(): number {
        return this.employees.filter(x => x.gender === "Male").length;
    }

    getTotalFemaleEmployeesCount(): number {
        return this.employees.filter(x => x.gender === "Female").length;
    }

    onEmployeeCountRadioButtonChange(selectedRadioButtonValue: string): void {
        this.selectedEmployeeCountRadioButton = selectedRadioButtonValue;
    }
}