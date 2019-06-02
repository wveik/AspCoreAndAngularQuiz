import { Component, OnInit } from "@angular/core";

import { QuestionsService } from "src/app/services/questions-service.service";

@Component({
  selector: "app-questions-list",
  templateUrl: "./questions-list.component.html",
  styleUrls: ["./questions-list.component.css"]
})
export class QuestionsListComponent implements OnInit {
  constructor(private service: QuestionsService) {}

  questions: any = [];

  ngOnInit() {
    this.updateQuestions();
  }

  updateQuestions() {
    this.service.getQuestions().subscribe(response => {
      this.questions = response;
    });
  }

  deleteQuestion(item) {
    console.log("deleteQuestion");
    this.service.deleteQuestion(item).subscribe(response => {
      this.updateQuestions();
    });
  }
}
