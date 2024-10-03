import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { FormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { TrackingEntryService } from '../../services/tracking-entry.service';
import { TrackingEntry } from '../../models/tracking-entry.model';

@Component({
  selector: 'app-new-tracking-entry-dialog',
  standalone: true,
  imports: [FormsModule, MatFormFieldModule, MatInputModule],
  templateUrl: './new-tracking-entry-dialog.component.html',
  styleUrls: ['./new-tracking-entry-dialog.component.css']
})
export class NewTrackingEntryDialogComponent {
  date: string;
  loadInKg: number;
  reps: number;
  sets: number;
  exerciseId: number;

  constructor(
    private dialogRef: MatDialogRef<NewTrackingEntryDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: { selectedExerciseName: string; exerciseId: number },
    private trackingEntryService: TrackingEntryService // Inject the service here
  ) {
    const today = new Date();
    this.date = today.toISOString().substring(0, 10);
    this.loadInKg = 0;
    this.reps = 0;
    this.sets = 0;
    this.exerciseId = data.exerciseId;
  }

  save() {
    if (this.loadInKg < 0 || this.reps < 0 || this.sets < 0) {
      console.error("Load, Reps, and Sets must be 0 or more.");
      return;
    }

    const entry: TrackingEntry = {
      date: this.date,
      loadInKg: this.loadInKg,
      reps: this.reps,
      sets: this.sets,
      exerciseId: this.exerciseId
    };

    this.trackingEntryService.createTrackingEntry(entry).subscribe({
      next: (result) => {
        console.log('Entry saved:', result);
        this.dialogRef.close(result);
      },
      error: (err) => {
        console.error('Error saving entry:', err);
      }
    });
  }

  close() {
    this.dialogRef.close();
  }
}
