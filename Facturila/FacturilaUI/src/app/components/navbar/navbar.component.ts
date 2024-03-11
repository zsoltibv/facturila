import { Component, ViewChild } from '@angular/core';
import { Router } from "@angular/router";
import { AuthService } from "src/app/services/auth.service";
import { SidebarService } from "src/app/services/sidebar.service";

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent {
  constructor(
    private authService: AuthService,
    private router: Router,
    private sidebarService: SidebarService
  ) { }

  ngOnInit(): void {
  }

  isLoggedIn(): boolean {
    return this.authService.isLoggedIn();
  }

  logout(): void {
    this.authService.logout();
    localStorage.removeItem('authToken');
    this.router.navigateByUrl('/login');
  }

  toggleSidebar(): void {
    this.sidebarService.toggleSidebar();
  }

  get nameInitials(): string {
    return this.authService.nameInitials;
  }
}
