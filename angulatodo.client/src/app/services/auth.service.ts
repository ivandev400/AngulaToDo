import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'any'
})
export class AuthService {
  private baseApiUrl: string = 'http://angulatodoserverside.runasp.net/api/accounts';

  constructor(private http: HttpClient) { }

  register(data: any): Observable<any> {
    return this.http.post(`${this.baseApiUrl}/register`, data);
  }

  login(data: any): Observable<any> {
    return this.http.post(`${this.baseApiUrl}/login`, data);
  }
}
