import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { MatCardModule, MatButtonModule, MatToolbarModule, MatInputModule } from '@angular/material';

import { AppComponent } from './app.component';
import { NewsComponent } from './news/news.component';
import { NewsblocksService } from './newsblocks.service';
import { ToolbarComponent } from './toolbar/toolbar.component';
import { NewsEditorComponent } from './news-editor/news-editor.component';
import { AppRoutingModule } from './app-routing.module';


@NgModule({
  declarations: [
    AppComponent,
    ToolbarComponent,
    NewsComponent,
    NewsEditorComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    FormsModule,
    HttpClientModule,
    MatButtonModule,
    MatCardModule,
    MatToolbarModule,
    MatInputModule,
    AppRoutingModule
  ],
  providers: [NewsblocksService],
  bootstrap: [AppComponent]
})
export class AppModule { }
