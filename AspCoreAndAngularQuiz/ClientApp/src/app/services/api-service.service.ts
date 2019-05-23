import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class ApiServiceService {

  constructor(private http: HttpClient) { }

  postQuestion(question: string) {
      /*this.http.post('', question).subscribe(response => {
          console.log(response);
      });*/

      this.http.get('https://jsonplaceholder.typicode.com/todos/' + question).subscribe(response => {
          console.log(response);
      });
  }
}
