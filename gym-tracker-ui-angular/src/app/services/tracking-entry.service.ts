import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { TrackingEntry } from '../models/tracking-entry.model';  // Create this interface in the next step

@Injectable({
  providedIn: 'root'
})
export class TrackingEntryService {
  private apiUrl = 'https://localhost:44372/TrackingEntries';  // Base URL for the API

  constructor(private http: HttpClient) {}

  // GET: /trackingentries
  getTrackingEntries(): Observable<TrackingEntry[]> {
    return this.http.get<TrackingEntry[]>(this.apiUrl);
  }

  // GET: /trackingentries/{id}
  getTrackingEntryById(id: number): Observable<TrackingEntry> {
    const url = `${this.apiUrl}/${id}`;
    return this.http.get<TrackingEntry>(url);
  }

  // POST: /trackingentries
  createTrackingEntry(entry: TrackingEntry): Observable<TrackingEntry> {
    return this.http.post<TrackingEntry>(this.apiUrl, entry);
  }

  // PUT: /trackingentries/{id}
  updateTrackingEntry(id: number, entry: TrackingEntry): Observable<void> {
    const url = `${this.apiUrl}/${id}`;
    return this.http.put<void>(url, entry);
  }

  // DELETE: /trackingentries/{id}
  deleteTrackingEntry(id: number): Observable<void> {
    const url = `${this.apiUrl}/${id}`;
    return this.http.delete<void>(url);
  }
}
