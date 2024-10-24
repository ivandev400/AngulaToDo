import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Task } from '../models/task';

@Injectable({
  providedIn: 'root'
})
export class TaskService {

  private tasksBaseUrl = 'https://localhost:7031/api/tasks';

  constructor(private http: HttpClient) { }

  getAllTasks(userId: string): Observable<Task[]> {
    return this.http.get<Task[]>(`${this.tasksBaseUrl}/${userId}`);
  }
  getTaskById(userId: string, taskId: number): Observable<Task> {
    return this.http.get<Task>(`${this.tasksBaseUrl}/${userId}/${taskId}`);
  }
  createTask(userId: string, taskDto: Task): Observable<Task> {
    return this.http.post<Task>(`${this.tasksBaseUrl}/${userId}`, taskDto);
  }
  updateTask(userId: string, taskId?: number, task?: Task): Observable<void> {
    return this.http.put<void>(`${this.tasksBaseUrl}/${userId}/${taskId}`, task);
  }
  deleteTask(userId: string, taskId?: number): Observable<void> {
    return this.http.delete<void>(`${this.tasksBaseUrl}/${userId}/${taskId}`);
  }
}
