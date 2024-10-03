import { Component, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ExerciseService } from './services/exercise.service';
import { TrackingEntryService } from './services/tracking-entry.service';
import { Exercise } from './models/exercise.model';
import { TrackingEntry } from './models/tracking-entry.model';
import { FormsModule } from '@angular/forms';
import { DatePipe } from '@angular/common';
import { MatDialog } from '@angular/material/dialog';
import { MatDialogModule } from '@angular/material/dialog';
import { NewTrackingEntryDialogComponent } from './components/new-tracking-entry-dialog/new-tracking-entry-dialog.component';


@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, FormsModule, DatePipe, MatDialogModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  title = 'GYM\'O TRACK\'A';
  exercises: Exercise[] = [];
  trackingEntries: TrackingEntry[] = [];
  filteredTrackingEntries: TrackingEntry[] = [];
  selectedExerciseId: number | null = null;
  selectedExerciseName: string = '';

  constructor(
    private exerciseService: ExerciseService,
    private trackingEntryService: TrackingEntryService,
    private dialog: MatDialog
  ) { }

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

  onExerciseChange(event: Event) {
    const selectedExerciseId = Number((event.target as HTMLSelectElement).value);
    this.selectedExerciseId = selectedExerciseId;

    const selectedExercise = this.exercises.find(ex => ex.id === selectedExerciseId);
    this.selectedExerciseName = selectedExercise ? selectedExercise.name : '';

    this.filterTrackingEntries();
  }

  filterTrackingEntries() {
    if (this.selectedExerciseId !== null) {
      this.filteredTrackingEntries = this.trackingEntries.filter(
        entry => entry.exerciseId === this.selectedExerciseId
      );
    } else {
      this.filteredTrackingEntries = [];
    }
  }

  openNewEntryDialog() {
    const dialogRef = this.dialog.open(NewTrackingEntryDialogComponent, {
      data: {
        selectedExerciseName: this.selectedExerciseName,
        exerciseId: this.selectedExerciseId
      }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.addNewTrackingEntry(result);
      }
    });
  }

  addNewTrackingEntry(entry: { date: string, loadInKg: number, reps: number, sets: number }) {
    const newEntry: TrackingEntry = {
      id: this.trackingEntries.length + 1,
      exerciseId: this.selectedExerciseId!,
      date: entry.date,
      loadInKg: entry.loadInKg,
      reps: entry.reps,
      sets: entry.sets
    };

    this.trackingEntries.push(newEntry);
    this.filterTrackingEntries();
  }
}
