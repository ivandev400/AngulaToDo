import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Task } from '../models/task';

@Injectable({
  providedIn: 'root'
})
export class FilterService {

  private filterBaseUrl = 'https://localhost:7031/api/filter';

  constructor(private http: HttpClient) { }

  getDailyTasks(userId: string): Observable<Task[]> {
    return this.http.get<Task[]>(`${this.filterBaseUrl}/${userId}/daily`)
  }

  getImportantTasks(userId: string): Observable<Task[]> {
    return this.http.get<Task[]>(`${this.filterBaseUrl}/${userId}/important`)
  }

  getPlannedTasks(userId: string): Observable<Task[]> {
    return this.http.get<Task[]>(`${this.filterBaseUrl}/${userId}/planned`)
  }

  getCompletedTasks(userId: string): Observable<Task[]> {
    return this.http.get<Task[]>(`${this.filterBaseUrl}/${userId}/completed`)
  }
}
