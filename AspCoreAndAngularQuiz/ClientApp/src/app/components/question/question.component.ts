import { Component, OnInit } from '@angular/core';
import { ApiServiceService } from '../../services/api-service.service';
import { Question } from 'src/app/Entities/Question';

@Component({
  selector: 'app-question',
  templateUrl: './question.component.html',
  styleUrls: ['./question.component.css']
})
export class QuestionComponent implements OnInit {
  
  constructor(private service: ApiServiceService) { }

  question: Question;

  public postNewQuestion: number = 0;

  ngOnInit() {
    this.question = new Question();
  }

  post() {
    this.service.postQuestion(this.question).subscribe(response => {
      this.postNewQuestion++;

      this.question = new Question();

      alert("data post to server");
    });
  }
}
