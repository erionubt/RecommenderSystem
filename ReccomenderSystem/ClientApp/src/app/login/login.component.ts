import { Component, OnInit, NgModule, Host } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators, FormControl, ReactiveFormsModule } from '@angular/forms';
import { first } from 'rxjs/operators';
import { User } from '../_models/user';
import { AuthenticationService } from '../_services/authentication.service';
import { Role } from '../_models/role';

@Component({
  selector: 'app-home-page',
  templateUrl: 'login.component.html',
  styleUrls: ['./login.component.css']
})


export class LoginComponent implements OnInit {
  //public readonly sitekey = "6LfYlcYZAAAAAKKxdCzqIYyCPBe4rvcDkB2UG5uQ";
  //public readonly sitekey2 = "6LfYlcYZAAAAABmLjdI1MXXRyQ_9zRi7qzaWYX5w";

  //Site key: 6LfYlcYZAAAAAKKxdCzqIYyCPBe4rvcDkB2UG5uQ
  //Secret key: 6LfYlcYZAAAAABmLjdI1MXXRyQ_9zRi7qzaWYX5w

  siteKey: string;
  theme: string;
  useGlobalDomain: boolean;
  loginForm: FormGroup;
  loading = false;
  submitted = false;
  returnUrl: string;
  error = '';
  currentUser: User;
  recaptcha: any[];
  tt: number = 0;
  alert: any;
  //captchaEnabled: boolean;



  public reactiveForm: FormGroup = new FormGroup({
    recaptchaReactive: new FormControl(null, Validators.required)
  });
  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private authenticationService: AuthenticationService,

  ) {

    this.siteKey = "6LfYlcYZAAAAAKKxdCzqIYyCPBe4rvcDkB2UG5uQ";
    this.theme = "Normal";
    this.authenticationService.currentUser.subscribe(x => this.currentUser = x);
    if (this.currentUser) {
      this.router.navigate(['/']);
    }

    //this.captchaEnabled = this.hostSettings.captchaEnabled;
  }


  ngOnInit() {

    this.loginForm = this.formBuilder.group({
      recaptchaFromRegister: [''],
      username: ['', Validators.required],
      password: ['', Validators.required],
      remember: [false],

    });
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
    //var x = document.getElementById('logoja');
    //x.removeAttribute('tabindex');

    // get return url from route parameters or default to '/'
    // this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/garage';
  }

  // convenience getter for easy access to form fields
  get f() { return this.loginForm.controls; }
  get RecaptchaFromRegister() { return this.loginForm.get('recaptchaFromRegister'); }
  get emailValue() { return this.loginForm.get('username').value; }
  get passwordValue() { return this.loginForm.get('password').value; }
  //register() : void {
  //  this.router.navigateByUrl('register');
  //}

  onSubmit() {

    this.submitted = true;

    // stop here if form is invalid
    if (this.loginForm.invalid) {
      return;
    }

    this.loading = true;
    this.authenticationService.login(this.f.username.value, this.f.password.value)
      .pipe(first())
      .subscribe(
        data => {

          this.alert = '';
          if (this.currentUser && this.currentUser.role === Role.Admin)
          {
            
            this.router.navigate([this.route.snapshot.queryParams['returnUrl'] || '/']);
          }
          else if (this.currentUser && this.currentUser.role == Role.Student) {
            this.router.navigate([]).then(result => { window.open(`student/home`, '_self'); });
          }

          

          //else {
          //  this.router.navigate([`home`]);
          //}
          //this.spinner.hide();
        },
        error => {
          console.log(this.emailValue);
          if (this.emailValue == 'admin@appdec.com') {
            console.log('test');
            this.alert = 'Please check your email and password. If you still can not login.';
          } else {
            console.log('test2');
            this.alert = 'Please check your email and password. If you still can not login, contact your Appdec administrator.';
          }


          console.log('error logs');
          this.error = error;
          this.loading = false;
        });
  }

  getActualYearFooter() {
    var d = new Date().getFullYear().toString();
    document.getElementById("demo").innerHTML = d;
  }

}
