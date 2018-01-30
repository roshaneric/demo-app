import { Component, OnInit } from '@angular/core';
import { NewsBlock } from '../newsblock';
import { NewsblocksService }  from '../newsblocks.service';

@Component({
  selector: 'app-news',
  templateUrl: './news.component.html',
  styleUrls: ['./news.component.css']
})
export class NewsComponent implements OnInit {
  newsblocks: NewsBlock[];

  constructor(private newsblocksService : NewsblocksService) { }

  ngOnInit() {
    this.newsblocks = this.newsblocksService.getNewsblocks();
  }
}
