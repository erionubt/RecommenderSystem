import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class StudentService {
  constructor(private http: HttpClient, @Inject('BASE_API_URL') private baseUrl: string) { }

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };

  searchMaterial(material: any): Observable<any> {
    return this.http.get<any>(this.baseUrl + 'Material/GetSearchedMaterials/' + material, this.httpOptions);
  }

  getMaterialsForUser(id: any): Observable<any> {
    return this.http.get<any>(this.baseUrl + 'Student/GetMaterialsForUser/' + id, this.httpOptions);
  }
}
