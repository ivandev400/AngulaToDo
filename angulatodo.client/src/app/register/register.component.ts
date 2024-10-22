import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html'
})
export class RegisterComponent {
  username: string = '';
  email: string = '';
  password: string = '';
  confirmPassword: string = '';
  passwordMismatch: boolean = false;
  error: string = '';

  constructor(private authService: AuthService, private router: Router) { }

  onSubmit() {
    if (this.password !== this.confirmPassword) {
      this.passwordMismatch = true;
      return;
    }

    const credentials = { username: this.username, email: this.email, password: this.password, confirmPassword: this.confirmPassword };

    this.authService.register(credentials)
      .subscribe({
        next: () => {
          this.router.navigate(['/login']);
        },
        error: (error) => {
          this.error = error.message;
        }
      });
  }
}
