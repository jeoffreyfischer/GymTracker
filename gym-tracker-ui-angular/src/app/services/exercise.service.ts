import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Exercise } from '../models/exercise.model';

@Injectable({
  providedIn: 'root'
})
export class ExerciseService {
  private apiUrl = 'https://localhost:44372/Exercises';

  constructor(private http: HttpClient) {}

  // GET: /exercises
  getExercises(): Observable<Exercise[]> {
    return this.http.get<Exercise[]>(this.apiUrl);
  }

  // GET: /exercises/{id}
  getExerciseById(id: number): Observable<Exercise> {
    const url = `${this.apiUrl}/${id}`;
    return this.http.get<Exercise>(url);
  }

  // POST: /exercises
  createExercise(exercise: Exercise): Observable<Exercise> {
    return this.http.post<Exercise>(this.apiUrl, exercise);
  }

  // PUT: /exercises/{id}
  updateExercise(id: number, exercise: Exercise): Observable<void> {
    const url = `${this.apiUrl}/${id}`;
    return this.http.put<void>(url, exercise);
  }

  // DELETE: /exercises/{id}
  deleteExercise(id: number): Observable<void> {
    const url = `${this.apiUrl}/${id}`;
    return this.http.delete<void>(url);
  }
}
