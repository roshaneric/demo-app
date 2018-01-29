import { Component, OnInit } from '@angular/core';
import { NewsBlock } from '../newsblock';

@Component({
  selector: 'app-news',
  templateUrl: './news.component.html',
  styleUrls: ['./news.component.css']
})
export class NewsComponent implements OnInit {
  newsblocks: NewsBlock[] = [
      {
        id: 1,
        title: 'title 1',
        content: 'content 1'
      }
  ];

  constructor() { }

  ngOnInit() {
  }

}
