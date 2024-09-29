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
  title = 'GYM TRACKER';
  exercises: any[] = [];

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.testApi();
  }

  testApi() {
    const url = "https://localhost:44372/Exercises";
    this.http.get<any[]>(url).subscribe(response => {
      this.exercises = response;
      console.log(this.exercises);
    });
  }
}
