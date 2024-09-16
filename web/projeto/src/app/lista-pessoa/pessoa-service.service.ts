import { Injectable } from '@angular/core';

import { Pessoa } from '../pessoa';

@Injectable({
  providedIn: 'root'
})
export class PessoaServiceService {
  constructor() { }
  getPessoas(): Pessoa[]{
    //this.pessoas.push(new Pessoa())
    return [new Pessoa('João',1),	new Pessoa('Maria',2),	new Pessoa('Angular	2',3)];
  }
}
