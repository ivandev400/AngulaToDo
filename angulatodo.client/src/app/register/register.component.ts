import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
})
export class RegisterComponent {
  constructor(private router: Router) { }

  isLoginPage() {
    return this.router.url === '/register';
  }
}
