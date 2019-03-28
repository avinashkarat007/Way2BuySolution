import { Injectable } from "@angular/core";
import { Http, Response } from '@angular/http'
import { Observable } from 'rxjs/observable';
import 'rxjs/add/operator/map';

@Injectable()
export class EmployeeService {

    constructor(private _http: Http) {
        
    }

    getEmployees(): Observable<any> {

        return this._http.get("http://localhost/EmployeeWebAPIService/api/employees/")
                    .map((response: Response) => { return response.json() as any; });

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
    }
}