import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Employee } from '../models/Employee';

@Injectable()
export class LoginService {
  myAppUrl ='https://localhost:44395/';
  myApiUrl = 'api/erp/Login/';

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type' : 'application/json'
    })
  };
  
  constructor(private http: HttpClient) { }

  getLogin(user: string, password: string): Observable<any>{
    return this.http.get<any>(this.myAppUrl+this.myApiUrl+user+'/'+password);
  }
}
