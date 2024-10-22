import { Component, OnInit } from '@angular/core';
import { Router, NavigationEnd } from '@angular/router';
import { filter } from 'rxjs/operators';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent implements OnInit {

  showNavbar: boolean = true;

  constructor(private router: Router) { }

  ngOnInit(): void {
    this.router.events.pipe(
      filter(event => event instanceof NavigationEnd)
    ).subscribe(() => {
      this.updateNavbarVisibility();
    });
  }

  private updateNavbarVisibility(): void {
    this.showNavbar = !this.router.url.startsWith('/tasks');
  }

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
