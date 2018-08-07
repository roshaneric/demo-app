import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { environment } from '../environments/environment';
import { Observable } from 'rxjs/Observable';

import { NewsBlock } from './newsblock';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable()
export class NewsblocksService {
  private newsApiUrl = environment.apiBaseUrl + 'news-blocks';

  constructor(private http: HttpClient) { }

  getNewsblocks(): Observable<NewsBlock[]> {
    return this.http.get<NewsBlock[]>(this.newsApiUrl);
  }

  addNewsblock(newsblock: NewsBlock): void {
    this.http.post<NewsBlock>(this.newsApiUrl, newsblock, httpOptions).subscribe(res => console.log(res));
  }
}
