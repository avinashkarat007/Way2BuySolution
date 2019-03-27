import { Component } from "@angular/core"

@Component({
    selector: 'starting-app',
    templateUrl : 'app/app.component.html'
})
export class AppComponent {
    pageHeader: string = "Employee Details";
    image: string = "https://www.ust-global.com/sites/default/files/logo_2_0.png";

    onClick(): void {
        console.log("I am clicked");
    }
}