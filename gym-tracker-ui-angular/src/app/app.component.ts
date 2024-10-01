import { Component, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ExerciseService } from './services/exercise.service';
import { TrackingEntryService } from './services/tracking-entry.service';
import { Exercise } from './models/exercise.model';
import { TrackingEntry } from './models/tracking-entry.model';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  title = 'GYM TRACKER';
  exercises: Exercise[] = [];
  trackingEntries: TrackingEntry[] = [];

  constructor(private exerciseService: ExerciseService, private trackingEntryService: TrackingEntryService) {}

  ngOnInit() {
    this.getExercises();
    this.getTrackingEntries();
  }

  getExercises() {
    this.exerciseService.getExercises().subscribe(response => {
      this.exercises = response;
      console.log(this.exercises);
    });
  }

  getTrackingEntries() {
    this.trackingEntryService.getTrackingEntries().subscribe(response => {
      this.trackingEntries = response;
      console.log(this.trackingEntries);
    });
  }
}
