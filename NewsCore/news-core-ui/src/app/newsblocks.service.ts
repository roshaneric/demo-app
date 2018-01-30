import { Injectable } from '@angular/core';
import { NewsBlock } from './newsblock';

@Injectable()
export class NewsblocksService {

  constructor() { }

  getNewsblocks(): NewsBlock[] {
    return [
      {
        id: 1,
        title: 'title 1',
        content: 'content 1'
      }
    ];
  }
}
