import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { PostQuiz } from '../Entities/post-quiz';

@Injectable({
  providedIn: 'root'
})
export class QuizService {

  constructor(private http: HttpClient) { }

  getFirstQuizDto() {
    return this.http.get("/quiz/GetFirstQuizDto");
  }

  postQuiz(postQuiz: PostQuiz) {
    return this.http.post("/quiz/PostQuiz", postQuiz);
  }

  getNextQuizDto(id: number) {
    return this.http.get(`/quiz/GetNextQuizDto/${id}`);
  }

  getResultQuiz() {
    return this.http.get("/quiz/GetResultQuiz/");
  }
}
