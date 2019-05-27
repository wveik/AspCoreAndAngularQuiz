import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { HttpClientModule } from '@angular/common/http'; 

import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatButtonModule, MatCheckboxModule } from '@angular/material';
import { QuestionComponent } from './Components/question/question.component';
import { ApiServiceService } from './services/api-service.service';
import { QuestionsListComponent } from './components/questions-list/questions-list.component';

@NgModule({
  declarations: [
    AppComponent,
    QuestionComponent,
    QuestionsListComponent,
  ],
  imports: [
    HttpClientModule, 

    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,

    MatButtonModule, 
    MatCheckboxModule,

    FormsModule,
    
  ],
  providers: [
    ApiServiceService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
