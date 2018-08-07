import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NewsBlock, NewsContent } from '../newsblock';
import { NewsblocksService } from '../newsblocks.service';

@Component({
  selector: 'app-news-editor',
  templateUrl: './news-editor.component.html',
  styleUrls: ['./news-editor.component.css']
})
export class NewsEditorComponent implements OnInit {

  newsblock: NewsBlock;
  newsForm: FormGroup;

  constructor(private fb: FormBuilder,
    private newsblocksService: NewsblocksService) { }

  ngOnInit() {
    this.createForm();
    // this.setContents([new NewsContent()]);
  }

  setContents(contents: NewsContent[]) {
    const contentFGs = contents.map(content => this.fb.group(content));
    const contentFormArray = this.fb.array(contentFGs);
    this.newsForm.setControl('contents', contentFormArray);
  }

  trackByIndex(index: number, value: number) {
    return index;
  }

  createForm() {
    this.newsForm = this.fb.group({
      title: ['', Validators.required],
      contents: this.fb.array([])
    });
    this.addContent();
  }

  save(): void {
    this.newsblock = this.prepareSaveNewsBlock();
    this.newsblocksService.addNewsblock(this.newsblock);
  }

  get contents(): FormArray {
    return this.newsForm.get('contents') as FormArray;
  }

  addContent() {
    this.contents.push(this.fb.group(new NewsContent()));
  }

  prepareSaveNewsBlock(): NewsBlock {
    const formModel = this.newsForm.value;

    const contentsDeepCopy: NewsContent[] = formModel.contents.map(
      (content: NewsContent) => Object.assign({}, content)
    );

    const saveNewsblock: NewsBlock = {
      id: formModel.id,
      title: formModel.title as string,
      contents: contentsDeepCopy
    };

    return saveNewsblock;
  }
}
