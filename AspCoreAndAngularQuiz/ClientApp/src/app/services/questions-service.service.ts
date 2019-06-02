import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Question } from "../Entities/Question";

@Injectable({
  providedIn: "root"
})
export class QuestionsService {
  constructor(private http: HttpClient) {}

  getQuestions() {
    return this.http.get("/api/questions/");
  }

  getQuestionById(id: number) {
    return this.http.get(`/api/questions/${id}`);
  }

  postQuestion(question: Question) {
    return this.http.post("/api/questions/", question);
  }

  putQuestion(question: Question) {
    return this.http.put("/api/questions/", question);
  }

  deleteQuestion(question: any) {
    const url = `/api/questions/${question.id}`;
    return this.http.delete(url);
  }
}
