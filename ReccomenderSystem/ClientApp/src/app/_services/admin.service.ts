import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class AdminService {
  constructor(private http: HttpClient, @Inject('BASE_API_URL') private baseUrl: string) { }

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };

  GetStudents(): Observable<any> {
    return this.http.get<any>(this.baseUrl + 'Admin/GetStudents', this.httpOptions);
  }

  GetTopics(): Observable<any> {
    return this.http.get<any>(this.baseUrl + 'Topics/GetTopics', this.httpOptions)
  }

  SaveTopic(emri: any): Observable<any> {
    return this.http.post<any>(this.baseUrl + 'Topics/SaveTopic/' + emri, this.httpOptions)
  }
}
