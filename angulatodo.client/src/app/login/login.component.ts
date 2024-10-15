import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
})
export class LoginComponent {
  email: string = '';
  password: string = '';

  constructor(private authService: AuthService, private router: Router) { }

  isLoginPage() {
    return this.router.url === '/login';
  }

  login() {
    const credentials = { email: this.email, password: this.password };

    this.authService.login(credentials)
      .subscribe((response: any) => {
        localStorage.setItem('token', response.token);
        this.router.navigate(['/tokens']);
      }, error => {
        console.error('Login failed', error);
      });
  }
}
