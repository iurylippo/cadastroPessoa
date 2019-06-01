import { Component, OnInit, TemplateRef } from '@angular/core';
import { PessoaService } from '../_services/Pessoa.service';
import { Pessoa } from '../_models/Pessoa';
import { BsModalRef, BsModalService } from 'ngx-bootstrap';


@Component({
  selector: 'app-pessoas',
  templateUrl: './pessoas.component.html',
  styleUrls: ['./pessoas.component.css']
})
export class PessoasComponent implements OnInit {

  pessoasFiltradas: Pessoa[];
  pessoas: Pessoa[];
  modalRef: BsModalRef;

  _filtroLista: string;

  constructor(
     private pessoaService : PessoaService
   , private modalService : BsModalService
    ) { }

  get filtroLista(): string {
    return this._filtroLista;
  }
  set filtroLista(value: string) {
    this._filtroLista = value;
    this.pessoasFiltradas = this.filtroLista ? this.filtrarPessoas(this.filtroLista) : this.pessoas;
  }

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }

  ngOnInit() {
    this.getPessoas();
  }

  filtrarPessoas(filtrarPor: string) : Pessoa[] {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.pessoas.filter(
      pessoa => (pessoa.nome.toLocaleLowerCase().indexOf(filtrarPor)) !== -1  || (pessoa.cpf.toLocaleLowerCase().indexOf(filtrarPor)) !== -1 
    );
  }

  getPessoas() {
    this.pessoaService.getAllPessoa().subscribe(
      (_pessoas: Pessoa[]) => { 
      this.pessoas =_pessoas;
      this.pessoasFiltradas = this.pessoas;
      console.log(_pessoas);
    }, error => {
      console.log(error);
    });
  }

}
