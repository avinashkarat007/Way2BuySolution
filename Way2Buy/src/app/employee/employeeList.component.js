"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var employee_service_1 = require("./employee.service");
var EmployeeListComponent = /** @class */ (function () {
    function EmployeeListComponent(empService) {
        this.empService = empService;
        this.selectedEmployeeCountRadioButton = "All";
        this.statusMessage = "Loading data, please wait....";
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
    EmployeeListComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.empService.getEmployees()
            .subscribe(function (empData) {
            _this.employees = empData;
        }, function (error) {
            _this.statusMessage = "Problem with service, please try again";
        });
    };
    EmployeeListComponent.prototype.ngOnDestroy = function () {
        console.log("Inside On Destroy");
    };
    EmployeeListComponent.prototype.getTotalEmployeesCount = function () {
        return this.employees.length;
    };
    EmployeeListComponent.prototype.getTotalMaleEmployeesCount = function () {
        return this.employees.filter(function (x) { return x.gender === "Male"; }).length;
    };
    EmployeeListComponent.prototype.getTotalFemaleEmployeesCount = function () {
        return this.employees.filter(function (x) { return x.gender === "Female"; }).length;
    };
    EmployeeListComponent.prototype.onEmployeeCountRadioButtonChange = function (selectedRadioButtonValue) {
        this.selectedEmployeeCountRadioButton = selectedRadioButtonValue;
    };
    EmployeeListComponent = __decorate([
        core_1.Component({
            selector: 'emp-list',
            templateUrl: 'app/employee/employeeList.component.html'
        }),
        __metadata("design:paramtypes", [employee_service_1.EmployeeService])
    ], EmployeeListComponent);
    return EmployeeListComponent;
}());
exports.EmployeeListComponent = EmployeeListComponent;
//# sourceMappingURL=employeeList.component.js.map