import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import ValidateForm from '../../helpers/validationform';
import { AuthService } from '../../services/auth.service';
import { Router } from '@angular/router';
import { NgToastService } from 'ng-angular-popup';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent implements OnInit {
  
public loginForm!: FormGroup;
type: string = 'password';
  isText: boolean = false;
  eyeIcon: string = 'fa-eye-slash';

constructor(private fb : FormBuilder,private auth : AuthService,private router : Router,private toast : NgToastService){}

ngOnInit() {
  this.loginForm = this.fb.group({
    username: ['', Validators.required],
    password: ['', Validators.required],
  });
}
  
  hideShowPass() {
    this.isText = !this.isText;
    this.isText ? (this.eyeIcon = 'fa-eye') : (this.eyeIcon = 'fa-eye-slash');
    this.isText ? (this.type = 'text') : (this.type = 'password');
  }

  onSubmit() {
    if (this.loginForm.valid) {
      console.log(this.loginForm.value);
      this.auth.signIn(this.loginForm.value).subscribe({
        next: (res) => {
          console.log(res.message); 
          this.success();
          this.auth.storeToken(res.token);
          this.router.navigate(['dashboard']);    
        },
        error: (err) => {          
          this.error();
        },
      });
    } else {
      ValidateForm.validateAllFormFields(this.loginForm);
      alert("Form Invalid");
    }
  }
  error(){
    this.toast.danger("Error", "SUCCESS", 5000); // by default visible duration is 2000ms
  }

  success(){
    this.toast.success("Success", "SUCCESS", 5000) // message with title and 5000ms duration
  }

  info(){
    this.toast.info("Info", "INFO", 5000)
  }

  warning(){
    this.toast.warning("Warning", "WARNING", 5000)
  }


}
