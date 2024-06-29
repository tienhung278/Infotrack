import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {SearchEngine} from "../models/search-engine.model";
import {Observable} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class SearchEngineService {
  baseUrl: string ;

  constructor(private httpClient: HttpClient) {
    this.baseUrl = 'http://localhost:5051';
  }

  public getSearchEngines() {
    return this.httpClient.get<SearchEngine[]>(`${this.baseUrl}/searchengines`)
  }
}
