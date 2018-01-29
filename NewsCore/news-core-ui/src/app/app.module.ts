import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';

import { MatCardModule, MatButtonModule } from '@angular/material';

import { AppComponent } from './app.component';
import { NewsComponent } from './news/news.component';
import { NewsblocksService } from './newsblocks.service';


@NgModule({
  declarations: [
    AppComponent,
    NewsComponent
  ],
  imports: [
    BrowserModule,
    MatButtonModule,
    MatCardModule
  ],
  providers: [NewsblocksService],
  bootstrap: [AppComponent]
})
export class AppModule { }
