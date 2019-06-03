import { Component, OnInit } from "@angular/core";
import { QuizService } from "src/app/services/quiz-service.service";
import { ResponseQuiz } from "src/app/Entities/response-quiz";
import { PostQuiz } from "src/app/Entities/post-quiz";
import { Ng4LoadingSpinnerService } from "ng4-loading-spinner";
import { ResultQuiz } from "src/app/Entities/result-quiz";

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

  isWinner: boolean;

  fullCountQuestion: number;

  successCountQuestion: number;

  constructor(
    private service: QuizService,
    private spinnerService: Ng4LoadingSpinnerService
  ) {}

  ngOnInit() {
    this.spinnerService.show();

    this.service.getFirstQuizDto().subscribe(response => {
      this.spinnerService.hide();
      const responseQuiz = <ResponseQuiz>response;

      this.setQuiz(responseQuiz);
    });
  }

  setQuiz(responseQuiz: ResponseQuiz) {
    this.isFinished = responseQuiz.isFinished;

    const quiz = responseQuiz.quiz;

    this.questionId = quiz.questionId;
    this.question = quiz.question;

    this.answer1 = quiz.answer1;
    this.answer2 = quiz.answer2;
    this.answer3 = quiz.answer3;
    this.answer4 = quiz.answer4;
  }

  postQuiz(answer: string) {
    this.spinnerService.show();

    let postQuiz: PostQuiz = new PostQuiz(this.questionId, answer);

    this.service.postQuiz(postQuiz).subscribe(
      success => {
        this.getNextQuizDto();
      },
      error => {
        this.spinnerService.hide();

        alert("Error from server");
      }
    );
  }

  getNextQuizDto() {
    this.service.getNextQuizDto(this.questionId).subscribe(
      success => {
        this.spinnerService.hide();

        const responseQuiz = <ResponseQuiz>success;

        if (responseQuiz.isFinished) {
          this.isFinished = true;
          this.getResultQuiz();
        } else {
          this.setQuiz(responseQuiz);
        }
      },
      error => {
        this.spinnerService.hide();

        alert("Error from server");
      }
    );
  }

  getResultQuiz() {
    this.service.getResultQuiz().subscribe(
      success => {
        this.spinnerService.hide();

        const result = <ResultQuiz>success;

        this.isWinner = result.isWinner;

        this.fullCountQuestion = result.fullCountQuestion;

        this.successCountQuestion = result.successCountQuestion;
      },
      error => {
        this.spinnerService.hide();

        alert("Error from server");
      }
    );
  }
}
