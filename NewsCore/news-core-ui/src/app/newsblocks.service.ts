import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { environment } from '../environments/environment';
import { Observable } from 'rxjs/Observable';

import { NewsBlock } from './newsblock';

@Injectable()
export class NewsblocksService {
  private newsApiUrl = environment.apiBaseUrl + 'news-blocks';

  constructor(private http: HttpClient) { }

  getNewsblocks(): Observable<NewsBlock[]> {
    return this.http.get<NewsBlock[]>(this.newsApiUrl);
  }
}
