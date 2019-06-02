import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { PostQuiz } from '../Entities/post-quiz';

@Injectable({
  providedIn: 'root'
})
export class QuizService {

  constructor(private http: HttpClient) { }

  getFirstQuizDto() {
    return this.http.get("/api/quiz/");
  }

  postQuiz(postQuiz: PostQuiz) {
    return this.http.post("/api/quiz/", postQuiz);
  }
}
