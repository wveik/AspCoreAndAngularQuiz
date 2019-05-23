import { Component, OnInit } from '@angular/core';
import { ApiServiceService } from '../../services/api-service.service';

@Component({
  selector: 'app-question',
  templateUrl: './question.component.html',
  styleUrls: ['./question.component.css']
})
export class QuestionComponent implements OnInit {

  constructor(private service: ApiServiceService) { }

  ngOnInit() {
  }

  question: string = "";

  post() {
    console.log(this.question);
    this.service.postQuestion(this.question);
  }

}
