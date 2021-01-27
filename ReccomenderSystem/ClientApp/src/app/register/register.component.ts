import { Component, Injectable, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from '../_services/user.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})

@Injectable({
  providedIn: 'root'
})
/** register component*/
export class RegisterComponent implements OnInit {
  /** register ctor */

  registerForm: FormGroup;
  submitted = false;
  topics: any;
  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private userService: UserService,
  ) {
  }

  ngOnInit() {
    this.registerForm = this.formBuilder.group({
      firstName: ['', [Validators.required, Validators.pattern(/^[A-Za-z,.'-]+[A-Za-z .,'-]+$/)]],
      lastName: ['', [Validators.required, Validators.pattern(/^[A-Za-z ,.'-]+$/)]],
      password: ['', [Validators.required, Validators.pattern(/^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.{8,})/)]],
      //confirmPassword: ['', [Validators.required, Validators.pattern(/^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.{8,})/)]],
      email: ['', [Validators.required, Validators.pattern("^[A-Za-z0-9._+-]+@[a-z]+\.[a-z]{2,4}$")]],
      interest: ['']
    },
      //{
      //  validator: MustMatch('password', 'confirmPassword')
      //}
    );

    this.userService.GetTopics().subscribe(result => {
      this.topics = result;
      console.log(this.topics);
    }, error => {
      console.log(error);
    });
  }



  onSubmit() {
    this.submitted = true;
    // stop here if form is invalid
    if (this.registerForm.invalid) {
      return;
    }


    try {
      var interesti = Number(this.interest.value);
      console.log(interesti);
      this.userService.register(this.name, this.LastName, this.Email, interesti, this.password).subscribe(result => {
        if (result) {
          this.router.navigate([`/login`]);
          this.submitted = false;
        }
      }, error => {
        console.log(error);
      });
    }
    catch (e) {
      console.log(e);
    }
  }

  get name() { return this.registerForm.get('firstName').value; };
  get LastName() { return this.registerForm.get('lastName').value; };
  get Email() { return this.registerForm.get('email').value };
  get password() { return this.registerForm.get('password').value };
  get interest() { return this.registerForm.get('interest') };
  //get confirmPassword() { return this.registerForm.get('confirmPassword').value };
}



export function MustMatch(controlName: string, matchingControlName: string) {
  return (formGroup: FormGroup) => {
    const control = formGroup.controls[controlName];
    const matchingControl = formGroup.controls[matchingControlName];

    if (matchingControl.errors && !matchingControl.errors.mustMatch) {
      // return if another validator has already found an error on the matchingControl
      return;
    }

    // set error on matchingControl if validation fails
    if (control.value !== matchingControl.value) {
      matchingControl.setErrors({ mustMatch: true });
    } else {
      matchingControl.setErrors(null);
    }
  }
}
