import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class UserService {
  //private baseUrl: string = 'https://localhost:44306/';
  constructor(private http: HttpClient, @Inject('BASE_API_URL') private baseUrl: string) { }

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };

  register(firstName: any, lastName: any, email: any, interest: number, password: any): Observable<any> {
    return this.http.post<any>(this.baseUrl + 'User/Register/' + firstName + '/' + lastName + '/' + email + '/' + interest + '/' + password, this.httpOptions);
  }

  GetTopics(): Observable<any> {
    return this.http.get<any>(this.baseUrl + 'Topics/GetTopics', this.httpOptions)
  }

  SaveTopic(emri: any): Observable<any> {
    return this.http.post<any>(this.baseUrl + 'Topics/SaveTopic/' + emri, this.httpOptions)
  }
}
