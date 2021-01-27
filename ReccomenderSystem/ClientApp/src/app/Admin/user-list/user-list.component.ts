import { Component, OnInit } from '@angular/core';
import { AdminService } from '../../_services/admin.service';

@Component({
    selector: 'app-user-list',
    templateUrl: './user-list.component.html',
    styleUrls: ['./user-list.component.css']
})
/** user-list component*/
export class UserListComponent implements OnInit {
  users: any;
    /** user-list ctor */
  constructor(
    private adminService: AdminService
  ) {

    }
  ngOnInit(): void {
    this.adminService.GetStudents().subscribe(res => {
      this.users = res;
      console.log(this.users);
    }, error => {
      console.log(error);
    });
  }
}
