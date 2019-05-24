import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Question } from '../Entities/Question';

@Injectable({
  providedIn: 'root'
})
export class ApiServiceService {

  constructor(private http: HttpClient) { }

  postQuestion(question: Question) {
    this.http.post('/api/questions/', question).subscribe(response => {
          console.log(response);
      });

      
  }
}
