import { Component, OnInit, TemplateRef } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Component({
  selector: 'app-pessoas',
  templateUrl: './pessoas.component.html',
  styleUrls: ['./pessoas.component.css']
})
export class PessoasComponent implements OnInit {

  pessoasFiltradas: any = [];
  pessoas: any = [];

  _filtroLista: string;
  get filtroLista(): string {
    return this._filtroLista;
  }
  set filtroLista(value: string) {
    this._filtroLista = value;
    this.pessoasFiltradas = this.filtroLista ? this.filtrarPessoas(this.filtroLista) : this.pessoas;
  }

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getPessoas();
  }

  filtrarPessoas(filtrarPor: string) : any {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.pessoas.filter(
      pessoa => (pessoa.nome.toLocaleLowerCase().indexOf(filtrarPor)) !== -1  || (pessoa.cpf.toLocaleLowerCase().indexOf(filtrarPor)) !== -1 
    );
  }

  getPessoas() {
    this.http.get('http://localhost:5000/site/values/').subscribe(response => { 
      this.pessoas = response;
      this.pessoasFiltradas = this.pessoas;
    }, error => {
      console.log(error);
    });
  }

}
