import {Component, OnInit} from '@angular/core';
import {FormBuilder, FormGroup, ReactiveFormsModule, Validators} from "@angular/forms";
import {SearchEngineService} from "./services/search-engine.service";
import {Observable, tap} from "rxjs";
import {AsyncPipe, JsonPipe, NgForOf, NgIf} from "@angular/common";
import {MatCard, MatCardActions, MatCardContent, MatCardFooter, MatCardHeader} from "@angular/material/card";
import {MatFormField, MatLabel} from "@angular/material/form-field";
import {MatInput} from "@angular/material/input";
import {MatOption, MatSelect} from "@angular/material/select";
import {SearchResponse} from "./models/search-response";
import {MatButton} from "@angular/material/button";
import {RankingResponse} from "./models/ranking-response";
import {MatProgressSpinner} from "@angular/material/progress-spinner";

@Component({
  selector: 'app-search',
  standalone: true,
  imports: [
    ReactiveFormsModule,
    AsyncPipe,
    MatCard,
    MatCardContent,
    MatCardHeader,
    MatCardFooter,
    MatCardActions,
    MatFormField,
    MatInput,
    MatLabel,
    MatSelect,
    MatOption,
    NgForOf,
    JsonPipe,
    MatButton,
    NgIf,
    MatProgressSpinner
  ],
  templateUrl: './search.component.html',
  styleUrl: './search.component.scss'
})
export class SearchComponent implements OnInit {
  searchResponse$: Observable<SearchResponse>;
  rankingResponse$: Observable<RankingResponse>;
  myForm: FormGroup;
  isLoading: boolean;

  constructor(private fb: FormBuilder, private searchEngineService: SearchEngineService) {
    this.searchResponse$ = new Observable<SearchResponse>();
    this.rankingResponse$ = new Observable<RankingResponse>();
    this.isLoading = false;
    this.myForm = fb.group({
      numOfResults: [100, Validators.required],
      keyword: ['land registry search', Validators.required],
      websiteUrl: ['www.infotrack.co.uk', Validators.required],
      searchEngineId: ['', Validators.required]
    });
  }

  ngOnInit(): void {
    this.searchResponse$ = this.searchEngineService.getSearchEngines();
  }

  onSubmit(myForm: FormGroup) {
    this.isLoading = true;
    this.rankingResponse$ = this.searchEngineService.getRanking(myForm.value).pipe(
      tap(_ => this.isLoading = false),
    );
  }
}
