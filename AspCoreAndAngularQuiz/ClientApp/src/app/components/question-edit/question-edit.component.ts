import { Component, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { QuestionsService } from 'src/app/services/questions-service.service';
import { Question } from 'src/app/Entities/Question';

@Component({
  selector: "app-question-edit",
  templateUrl: "./question-edit.component.html",
  styleUrls: ["./question-edit.component.css"]
})
export class QuestionEditComponent implements OnInit {
  id: number;

  question: Question = new Question();

  constructor(private route: ActivatedRoute, private service: QuestionsService) {}

  ngOnInit() {
    this.id = +this.route.snapshot.params["id"];

    this.service.getQuestionById(this.id).subscribe(response => {
      this.question = <Question>response;
    });
  }

  update() {
    console.log(this.question);
    this.service.putQuestion(this.question).subscribe(response => {
      alert("question is updated");
    }, err => {
      alert("ERROR");
    });
  }
}
