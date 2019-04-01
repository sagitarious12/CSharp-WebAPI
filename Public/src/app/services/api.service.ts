import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment as env } from './../../environments/environment';
import { Company } from '../models/companies';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(
    private http: HttpClient
  ) { }

  getCompanies(): Observable<any> {
    return this.http.get(`${env.api}/companies`);
  }

  saveCompany(company: Company): Observable<any> {
    return this.http.post(`${env.api}/companies`, company);
  }

  updateCompany(company: Company): Observable<any> {
    return this.http.put(`${env.api}/companies/${company._id}`, company);
  }

  deleteCompany(company: Company): Observable<any> {
    return this.http.delete(`${env.api}/companies/${company._id}`);
  }
}
