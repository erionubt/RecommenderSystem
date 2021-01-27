import { Route } from '@angular/compiler/src/core';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { User } from '../_models/user';
import { AuthenticationService } from '../_services/authentication.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit {
  isExpanded = false;
  isLoggedIn: boolean = false;
  currentUser: User;

  constructor(
    private authenticationService: AuthenticationService,
    private router: Router
  ) {
    this.authenticationService.currentUser.subscribe(x => this.currentUser = x);
  }
    ngOnInit(): void {
      if(this.currentUser) {
        this.isLoggedIn = true;
      }
    }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  logOut() {
    this.authenticationService.logout();
    this.router.navigate([]).then(result => { window.open(`/`, '_self'); });
  }
}
