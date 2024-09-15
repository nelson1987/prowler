import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
// Imports de Componentes
import { ListaPessoaComponent } from './lista-pessoa/lista-pessoa.component';
import { AlertaService } from './alerta.service';
//
@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, ListaPessoaComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'Teste Nelson ';
  alerta = new AlertaService();
enviarMsg(){
  this.alerta.msgAlerta();
}
}
