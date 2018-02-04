import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms'
import { NewsBlock } from '../newsblock';
import { NewsblocksService } from '../newsblocks.service';

@Component({
  selector: 'app-news-editor',
  templateUrl: './news-editor.component.html',
  styleUrls: ['./news-editor.component.css']
})
export class NewsEditorComponent implements OnInit {

  constructor(private newsblocksService: NewsblocksService) { }

  ngOnInit() {
  }

}
