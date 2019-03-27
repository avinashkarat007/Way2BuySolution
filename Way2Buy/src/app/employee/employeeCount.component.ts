import { Component,Input, Output,EventEmitter } from "@angular/core"

@Component({
    selector: 'emp-count',
    templateUrl: 'app/employee/employeeCount.component.html'
})
export class EmployeeCountComponent {

    selectedRadioButtonValue: string = "All";

    @Output()
    countRadioButtonSelectionChanged: EventEmitter<string> = new EventEmitter <string>();


    @Input()
    all: number;

    @Input()
    male: number;

    @Input()
    female: number;


    onRadioButtonSelectionChange() {        
        this.countRadioButtonSelectionChanged.emit(this.selectedRadioButtonValue);
        console.log(this.selectedRadioButtonValue);
    }
}