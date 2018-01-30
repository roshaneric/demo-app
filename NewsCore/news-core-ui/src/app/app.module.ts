import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { MatCardModule, MatButtonModule, MatToolbar, MatToolbarModule } from '@angular/material';

import { AppComponent } from './app.component';
import { NewsComponent } from './news/news.component';
import { NewsblocksService } from './newsblocks.service';
import { ToolbarComponent } from './toolbar/toolbar.component';


@NgModule({
  declarations: [
    AppComponent,
    NewsComponent,
    ToolbarComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    MatButtonModule,
    MatCardModule,
    MatToolbarModule
  ],
  providers: [NewsblocksService],
  bootstrap: [AppComponent]
})
export class AppModule { }
