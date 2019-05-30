import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Pessoa } from '../_models/Pessoa';

@Injectable({
  providedIn: 'root'
})
export class PessoaService {
  baseURL = 'http://localhost:5000/api/pessoa';

  constructor(private http: HttpClient) { }

  getAllPessoa(): Observable<Pessoa[]> {
    return this.http.get<Pessoa[]>(this.baseURL);
  }

  getPessoaByNome(nome: string): Observable<Pessoa[]> {
    return this.http.get<Pessoa[]>(`${this.baseURL}/getByNome/${nome}`);
  }

  getPessoaByCpf(cpf: string): Observable<Pessoa[]> {
    return this.http.get<Pessoa[]>(`${this.baseURL}/getByCpf/${cpf}`);
  }

  getPessoaById(id: number): Observable<Pessoa> {
    return this.http.get<Pessoa>(`${this.baseURL}/${id}`);
  }

}
