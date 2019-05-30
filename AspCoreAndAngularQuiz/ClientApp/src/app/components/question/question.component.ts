import { Component, OnInit } from "@angular/core";
import { ApiServiceService } from "../../services/api-service.service";
import { Question } from "src/app/Entities/Question";

@Component({
  selector: "app-question",
  templateUrl: "./question.component.html",
  styleUrls: ["./question.component.css"]
})
export class QuestionComponent implements OnInit {
  constructor(private service: ApiServiceService) {}

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
