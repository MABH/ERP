import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Employee } from 'src/app/models/Employee';
import { LoginService } from 'src/app/services/login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']  
})
export class LoginComponent implements OnInit{
  userLogued: Employee[];
  loading =false;
  user: string;
  password: string;
  isAdmin: string;

  constructor(private loginService: LoginService, private route: ActivatedRoute) {
    /*this.user = +this.route.snapshot.paramMap.get('user');
    this.password = +this.route.snapshot.paramMap.get('password');
    this.isAdmin = +this.route.snapshot.paramMap.get('isAdmin');*/

    this.user = this.route.snapshot.paramMap.get('user');
    this.password = this.route.snapshot.paramMap.get('password');
    this.isAdmin = this.route.snapshot.paramMap.get('isAdmin');
  }
  
  ngOnInit(): void {
      
  }

  login() {


    this.loading = true;
    this.loginService.getLogin(this.user, this.password).subscribe(data => {
      this.loading =false;
      this.userLogued=data;
      console.log('RES',this.userLogued);
    })   
    
  }

}
