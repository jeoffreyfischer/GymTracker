import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'gym-tracker-ui-angular';

  constructor(private http: HttpClient) {}

  testApi() {
    const url = "https://localhost:44372/Exercises";
    this.http.get(url).subscribe(response =>
      console.log(response));
  }
}
