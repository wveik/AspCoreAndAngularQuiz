import { Component, OnInit } from "@angular/core";
import { QuestionsService } from 'src/app/services/questions-service.service';
import { Question } from "src/app/Entities/question";

@Component({
  selector: "app-question",
  templateUrl: "./question.component.html",
  styleUrls: ["./question.component.css"]
})
export class QuestionComponent implements OnInit {
  constructor(private service: QuestionsService) {}

  question: Question;

  ngOnInit() {
    this.question = new Question();
  }

  post() {
    console.log(this.service);

    this.service.postQuestion(this.question).subscribe(response => {
      this.question = new Question();

      alert("data post to server");
    });
  }
}
