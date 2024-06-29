import {Component, OnInit} from '@angular/core';
import {RouterOutlet} from '@angular/router';
import {FormBuilder, FormGroup, ReactiveFormsModule} from "@angular/forms";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent implements OnInit {
  searchEngines:[];
  results;
  myForm: FormGroup;

  constructor(private fb: FormBuilder) {
    this.searchEngines = [];
    this.results = '';
    this.myForm = fb.group({
      numOfResults: 100,
      keyword: 'land registry search',
      websiteUrl: 'www.infotrack.co.uk',
      searchEngineId: ''
    });
  }

  ngOnInit(): void {
    throw new Error('Method not implemented.');
  }

  onSubmit(myForm: FormGroup) {

  }
}
