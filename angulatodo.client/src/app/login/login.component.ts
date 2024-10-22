import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
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
        if (response && response.userId) {
          localStorage.setItem('userId', response.userId);

          this.router.navigate([`/tasks/${response.userId}`]);
        }

      }, error => {
        console.error('Login failed', error);
      });
  }
}
