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
var http_1 = require("@angular/http");
var observable_1 = require("rxjs/observable");
require("rxjs/add/operator/map");
require("rxjs/add/operator/catch");
var EmployeeService = /** @class */ (function () {
    function EmployeeService(_http) {
        this._http = _http;
    }
    EmployeeService.prototype.getEmployees = function () {
        return this._http.get("http://localhost/EmployeeWebAPIService/api/employees/")
            .map(function (response) {
            return response.json();
        }).catch(this.handleError);
        //return [{ code: "emp1", name: "Tom", gender: "Male", annualSalary: 55000 },
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
    };
    EmployeeService.prototype.getEmployeesByCode = function (empCode) {
        return this._http.get("http://localhost/EmployeeWebAPIService/api/employees/" + empCode)
            .map(function (response) {
            return response.json();
        }).catch(this.handleError);
    };
    EmployeeService.prototype.handleError = function (error) {
        console.log(error);
        return observable_1.Observable.throw(error);
    };
    EmployeeService = __decorate([
        core_1.Injectable(),
        __metadata("design:paramtypes", [http_1.Http])
    ], EmployeeService);
    return EmployeeService;
}());
exports.EmployeeService = EmployeeService;
//# sourceMappingURL=employee.service.js.map