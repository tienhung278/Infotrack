import {Component} from "@angular/core";
import {SearchComponent} from "./components/search/search.component";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    SearchComponent,
  ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {

}
