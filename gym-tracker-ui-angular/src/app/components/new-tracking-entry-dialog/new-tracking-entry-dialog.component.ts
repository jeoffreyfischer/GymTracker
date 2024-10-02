import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-new-tracking-entry-dialog',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './new-tracking-entry-dialog.component.html',
  styleUrls: ['./new-tracking-entry-dialog.component.css']
})
export class NewTrackingEntryDialogComponent {
  date: string;
  load: number;
  reps: number;
  sets: number;

  constructor(
    private dialogRef: MatDialogRef<NewTrackingEntryDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: { selectedExerciseName: string }
  ) {
    const today = new Date();
    this.date = today.toISOString().substring(0, 10); // Default to today
    this.load = 0;
    this.reps = 0;
    this.sets = 0;
  }

  save() {
    this.dialogRef.close({
      date: this.date,
      load: this.load,
      reps: this.reps,
      sets: this.sets
    });
  }

  close() {
    this.dialogRef.close();
  }
}
