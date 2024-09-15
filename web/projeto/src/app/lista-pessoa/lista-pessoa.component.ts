import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
@Component({
  selector: 'app-lista-pessoa',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './lista-pessoa.component.html',
  styleUrl: './lista-pessoa.component.css'
})
export class ListaPessoaComponent implements OnInit {
  pessoas: string[] = ['João',	'Maria',	'Angular	2'];
  nome:	string	=	"Thiago";

constructor(){
  
}
ngOnInit(): void {
  
}
listar(){

}
}
