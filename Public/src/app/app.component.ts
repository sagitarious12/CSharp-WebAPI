import { Component, OnInit } from '@angular/core';
import { Company } from './models/companies';
import { ApiService } from './services/api.service';
import { FormGroup, FormBuilder } from '@angular/forms';
import { MatSnackBar } from '@angular/material';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  public companies: Array<Company>;
  public datasource: Array<CompanyTable>;
  public displayedColumns = ['id', 'name'];
  public currentView = 0;
  public addCompany: FormGroup;
  public selectedRow: Company;

  constructor(
    private _apiService: ApiService,
    private _fb: FormBuilder,
    private snackbar: MatSnackBar
  ) { }

  ngOnInit() {
    this.getCompanies();
    this.addCompany = this._fb.group({
      name: [""],
      id: [""]
    })
  }

  getCompanies() {
    this._apiService.getCompanies().subscribe((result: Array<Company>) => {
      this.companies = result;
      this.convertCompaniesToTable();
    });
  }

  convertCompaniesToTable() {
    this.datasource = this.companies.map(company => ({
      id: company.id,
      name: company.name
    }));
  }

  saveCompany() {
    if (this.addCompany.valid) {
      const company = new Company();
      company.name = this.addCompany.get('name').value;
      company.id = this.addCompany.get('id').value;
      if (company.name !== '') {
        this._apiService.saveCompany(company).subscribe((result: any) => {
          this.snackbar.open('Successfully Saved Company', '', {
            duration: 2000,
            verticalPosition: 'top',
            horizontalPosition: 'center'
          });
          this.getCompanies();
          this.currentView = 0;
        });
      } else {
        this.snackbar.open('Please add a name for the company.', '', {
          duration: 2000,
          verticalPosition: 'top',
          horizontalPosition: 'center'
        })
      }
    }
  }

  select(row) {
    this.currentView = 2;
    this.selectedRow = this.companies.find(company => company.name == row.name && company.id == row.id);
    this.addCompany.patchValue({
      name: row.name,
      id: row.id
    });
  }

  updateCompany() {
    this.selectedRow.id = this.addCompany.get('id').value;
    this.selectedRow.name = this.addCompany.get('name').value;
    this._apiService.updateCompany(this.selectedRow).subscribe((result: any) => {
      this.snackbar.open('Successfully Updated Company', '', {
        duration: 2000,
        horizontalPosition: 'center',
        verticalPosition: 'top'
      });
      this.addCompany.reset();
      this.getCompanies();
      this.currentView = 0;
    });
  }

  deleteCompany() {
    const company: Company = this.companies.find(company => company.name == this.addCompany.get('name').value && company.id == this.addCompany.get('id').value);
    this._apiService.deleteCompany(company).subscribe((result: any) => {
      this.snackbar.open('Successfully Deleted Company', '', {
        duration: 2000,
        horizontalPosition: 'center',
        verticalPosition: 'top'
      });
      this.getCompanies();
      this.currentView = 0;
    });
  }
}

interface CompanyTable {
  id: string;
  name: string;
}
