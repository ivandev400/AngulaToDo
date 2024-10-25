import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Category } from '../models/category';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {
  private categoryBaseUrl = 'http://angulatodoserverside.runasp.net/api/categories';

  constructor(private http: HttpClient) { }

  getAllCategories(userId: string): Observable<Category[]> {
    return this.http.get<Category[]>(`${this.categoryBaseUrl}/${userId}`);
  }

  getCategoryByName(userId: string, name: string): Observable<Category | null> {
    return this.http.get<Category | null>(`${this.categoryBaseUrl}/${userId}/${name}`);
  }

  createCategory(userId: string, category: Category): Observable<Category> {
    return this.http.post<Category>(`${this.categoryBaseUrl}/${userId}`, category);
  }

  deleteCategory(userId: string, categoryId?: number): Observable<any> {
    return this.http.delete<any>(`${this.categoryBaseUrl}/${userId}/${categoryId}`);
  }
}
