import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  constructor(private router: Router) { }

  isHomePage() {
    return this.router.url === '/';
  }

  isLoginPage() {
    return this.router.url === '/login';
  }

  navigateToLogin() {
    this.router.navigate(['/login']);
  }
}
