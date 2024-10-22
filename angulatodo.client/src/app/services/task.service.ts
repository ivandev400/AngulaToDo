import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TaskService {

  private tasksBaseUrl = 'https://localhost:7031/api/tasks';

  constructor(private http: HttpClient) { }

  getAllTasks(userId: string): Observable<any[]> {
    return this.http.get<any[]>(`${this.tasksBaseUrl}/${userId}`);
  }
}
