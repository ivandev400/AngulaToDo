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
  error: string = '';

  constructor(private authService: AuthService, private router: Router) { }

  onSubmit() {
    const credentials = { username: this.username, email: this.email, password: this.password };

    this.authService.register(credentials)
      .subscribe({
        next: () => {
          this.router.navigate(['/tasks']);
        },
        error: (error) => {
          this.error = error.message;
        }
      });
  }
}
