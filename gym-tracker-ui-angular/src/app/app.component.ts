import { Component, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ExerciseService } from './services/exercise.service';
import { TrackingEntryService } from './services/tracking-entry.service';
import { Exercise } from './models/exercise.model';
import { TrackingEntry } from './models/tracking-entry.model';
import { FormsModule } from '@angular/forms';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, FormsModule, DatePipe],
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
    });
  }

  getTrackingEntries() {
    this.trackingEntryService.getTrackingEntries().subscribe(response => {
      this.trackingEntries = response;
    });
  }

  onExerciseChange(event: Event) {
    const selectedExerciseId = Number((event.target as HTMLSelectElement).value);
    this.selectedExerciseId = selectedExerciseId;

    const selectedExercise = this.exercises.find(ex => ex.id === selectedExerciseId);
    this.selectedExerciseName = selectedExercise ? selectedExercise.name : '';

    this.filteredTrackingEntries = this.trackingEntries.filter(
      entry => entry.exerciseId === this.selectedExerciseId
    );
  }
}
