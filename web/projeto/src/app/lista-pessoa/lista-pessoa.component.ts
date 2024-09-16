import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
//Adicionar Serviço
import { PessoaServiceService } from './pessoa-service.service';
import { Pessoa } from '../pessoa';
@Component({
  selector: 'app-lista-pessoa',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './lista-pessoa.component.html',
  styleUrl: './lista-pessoa.component.css'
})
export class ListaPessoaComponent implements OnInit {
  pessoas: Pessoa[];
  nome:	string	=	"Thiago";

constructor(private pessoaService: PessoaServiceService){
  this.pessoas = pessoaService.getPessoas();
}
ngOnInit(): void {
  
}
listar(){

}
}
