import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { User } from '../../_models/user';
import { AuthenticationService } from '../../_services/authentication.service';
import { StudentService } from '../../_services/student.service';

@Component({
    selector: 'app-student-home',
    templateUrl: './student-home.component.html',
    styleUrls: ['./student-home.component.css']
})
/** StudentHome component*/
export class StudentHomeComponent implements OnInit {
/** StudentHome ctor */
  currentUser: User;
  materials: any;
  searchForm: FormGroup;
  searchedMaterials: any;
  searched: boolean = false;
  constructor(
    private studentService: StudentService,
    private authenticationService: AuthenticationService,
    private formBuilder: FormBuilder
  ) {
    this.authenticationService.currentUser.subscribe(x => this.currentUser = x);
  }

  searchMaterials() {
    //console.log(this.searchForm.get('search').value);
    this.searched = true;
    this.studentService.searchMaterial(this.searchForm.get('search').value).subscribe(res => {
      this.searchedMaterials = res;
      this.materials = this.searchedMaterials;
      console.log(this.materials);
    }, error => {
      console.log(error);
    });
  }

  clearSearch() {
    this.searched = false;
    this.searchForm.get('search').setValue("");
    this.studentService.getMaterialsForUser(this.currentUser.id).subscribe(result => {
      this.materials = result;
      console.log(this.materials);
    }, error => {
      console.log(error);
    });
  }

  ngOnInit(): void {
    this.searchForm = this.formBuilder.group({
      search: ['']
    });
    this.studentService.getMaterialsForUser(this.currentUser.id).subscribe(result => {
      this.materials = result;
      console.log(this.materials);
    }, error => {
      console.log(error);
    });
  }
}
