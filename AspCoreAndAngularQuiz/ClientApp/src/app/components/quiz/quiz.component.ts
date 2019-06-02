import { Component, OnInit } from "@angular/core";
import { QuizService } from "src/app/services/quiz-service.service";
import { ResponseQuiz } from "src/app/Entities/response-quiz";
import { PostQuiz } from 'src/app/Entities/post-quiz';
import { Ng4LoadingSpinnerService } from 'ng4-loading-spinner';

@Component({
  selector: "app-quiz",
  templateUrl: "./quiz.component.html",
  styleUrls: ["./quiz.component.css"]
})
export class QuizComponent implements OnInit {
  isFinished: boolean = true;
  question: string;

  answer1: string;

  answer2: string;

  answer3: string;

  answer4: string;

  questionId: number;

  constructor(private service: QuizService, private spinnerService: Ng4LoadingSpinnerService) {
    this.responseQuiz = new ResponseQuiz();
  }

  responseQuiz: ResponseQuiz;

  ngOnInit() {
    this.service.getFirstQuizDto().subscribe(response => {
      this.responseQuiz = <ResponseQuiz>response;

      this.isFinished = this.responseQuiz.isFinished;

      const quiz = this.responseQuiz.quiz;

      this.questionId = quiz.questionId;
      this.question = quiz.question;

      this.answer1 = quiz.answer1;
      this.answer2 = quiz.answer2;
      this.answer3 = quiz.answer3;
      this.answer4 = quiz.answer4;
    });
  }

  postQuiz(answer: string) {
    this.spinnerService.show();

    let postQuiz: PostQuiz = new PostQuiz(this.questionId, answer);
    //this.spinnerService.hide();
    /*
    this.service.postQuiz(postQuiz).subscribe(response => {
      console.log(response);
      
    });*/
  }
}
