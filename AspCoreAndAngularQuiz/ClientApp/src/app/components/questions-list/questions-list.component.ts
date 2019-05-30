import {
  Component,
  OnInit,
  SimpleChange,
  Input,
  OnChanges
} from "@angular/core";
import { ApiServiceService } from "src/app/services/api-service.service";

@Component({
  selector: "app-questions-list",
  templateUrl: "./questions-list.component.html",
  styleUrls: ["./questions-list.component.css"]
})
export class QuestionsListComponent implements OnInit {
  constructor(private service: ApiServiceService) {}

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
