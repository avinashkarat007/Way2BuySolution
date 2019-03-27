"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var EmployeeListComponent = /** @class */ (function () {
    function EmployeeListComponent() {
        this.employees = [{ code: "emp1", name: "Tom", gender: "Male", annualSalary: 55000 },
            { code: "emp2", name: "Mary", gender: "Female", annualSalary: 15000 },
            { code: "emp3", name: "Jerry", gender: "Male", annualSalary: 10000 },
            { code: "emp4", name: "Stephen", gender: "Male", annualSalary: 26000 },
            { code: "emp5", name: "Lisa", gender: "Female", annualSalary: 38000 }
        ];
    }
    EmployeeListComponent = __decorate([
        core_1.Component({
            selector: 'emp-list',
            templateUrl: 'app/employee/employeeList.component.html'
        })
    ], EmployeeListComponent);
    return EmployeeListComponent;
}());
exports.EmployeeListComponent = EmployeeListComponent;
//# sourceMappingURL=employeeList.js.map