import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";

import { QuestionComponent } from './Components/question/question.component';
import { QuestionsListComponent } from './components/questions-list/questions-list.component';
import { QuestionEditComponent } from './components/question-edit/question-edit.component';
import { QuizComponent } from './components/quiz/quiz.component';

const routes: Routes = [
  { path: '', component: QuestionComponent },
  { path: 'all_questions', component: QuestionsListComponent },
  { path: 'question-edit/:id', component: QuestionEditComponent },
  { path: 'quiz', component: QuizComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
