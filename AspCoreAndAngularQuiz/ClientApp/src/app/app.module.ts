import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { HttpClientModule } from '@angular/common/http'; 

import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatButtonModule, MatCheckboxModule } from '@angular/material';
import { QuestionComponent } from './Components/question/question.component';

import { QuestionsService } from './services/questions-service.service';
import { QuizService } from './services/quiz-service.service';

import { QuestionsListComponent } from './components/questions-list/questions-list.component';
import { QuestionEditComponent } from './components/question-edit/question-edit.component';
import { QuizComponent } from './components/quiz/quiz.component';

@NgModule({
  declarations: [
    AppComponent,
    QuestionComponent,
    QuestionsListComponent,
    QuestionEditComponent,
    QuizComponent,
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
    QuestionsService,
    QuizService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
