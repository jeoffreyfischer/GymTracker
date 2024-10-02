import { Component, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ExerciseService } from './services/exercise.service';
import { TrackingEntryService } from './services/tracking-entry.service';
import { Exercise } from './models/exercise.model';
import { TrackingEntry } from './models/tracking-entry.model';
import { FormsModule } from '@angular/forms';
import { DatePipe } from '@angular/common';
import { MatDialogModule } from '@angular/material/dialog';


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
  filteredTrackingEntries: TrackingEntry[] = [];
  selectedExerciseId: number | null = null;
  selectedExerciseName: string = '';

  constructor(private exerciseService: ExerciseService, private trackingEntryService: TrackingEntryService) {}

  ngOnInit() {
    this.getExercises();
    this.getTrackingEntries();
  }

  getExercises() {
    this.exerciseService.getExercises().subscribe(response => {
      this.exercises = response;
      if (response.length > 0) {
        this.selectedExerciseId = response[0].id;
        this.selectedExerciseName = response[0].name;
      }
      this.filterTrackingEntries();
    });
  }

  getTrackingEntries() {
    this.trackingEntryService.getTrackingEntries().subscribe(response => {
      this.trackingEntries = response;
      this.filterTrackingEntries();
    });
  }
}
