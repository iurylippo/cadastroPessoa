import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-pessoas',
  templateUrl: './pessoas.component.html',
  styleUrls: ['./pessoas.component.css']
})
export class PessoasComponent implements OnInit {

  pessoas: any;

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getPessoas();
  }

  getPessoas() {
    this.http.get('http://localhost:5000/site/values/').subscribe(response => { 
      this.pessoas = response;
    }, error => {
      console.log(error);
    });
  }

}
