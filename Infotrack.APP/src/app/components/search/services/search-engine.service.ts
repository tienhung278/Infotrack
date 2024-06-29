import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {SearchResponse} from "../models/search-response";
import {RankingResponse} from "../models/ranking-response";
import {RankingRequest} from "../models/ranking-request";

@Injectable({
  providedIn: 'root'
})
export class SearchEngineService {
  baseUrl: string;

  constructor(private httpClient: HttpClient) {
    this.baseUrl = 'http://localhost:5051';
  }

  public getSearchEngines() {
    return this.httpClient.get<SearchResponse>(`${this.baseUrl}/searchengines`);
  }

  public getRanking(payload: RankingRequest): Observable<RankingResponse> {
    return this.httpClient.post<RankingResponse>(`${this.baseUrl}/ranking`, payload);
  }
}
