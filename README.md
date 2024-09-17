# prowler
teste de ambiente angular
## Dotnet
```sh
dotnet new .gitignore
mkdir src
mkdir tests
cd tests
dotnet new xunit -n Prowler.IntegrationTests
```
## GIT
### Commit normal
```sh
git status
git add .
git commit -m "Commit inicial"  
git push
```

### Visualizar Log no Git
```sh
git log
git log --graph
git log --graph --oneline
git log --graph --oneline --all
```

### Rebase
```sh
git rebase -i HEAD~3
#ATENÇÃO!! (lembrar de deixar dar squash em 1 de 2, 2 de 3, e assim por diante, deixando 1 deles como Pick, e alterando a mensagem em "lst commit message")
#para cancelar o rebase
git push --abort
#Para confirmar alteração do Rebase
git push --force-with-lease
```

### Deletar branch local
```sh
git branch -D [nome_branch]
```

## Angular
### Criar novo projeto
```sh
ng new [nome_projeto]
#escolher stylesheet: CSS, Server-Side Rendering: NO
#Após a instalações do pacotes
cd [nome_projeto] #Você irá pro workspace do projeto
ng serve #Executará a aplicação na porta - 4200
#Se precisar utilizar uma porta diferente
ng serve --port [numero_porta]
#Se for parar a aplicação
[ctrl] + [C]
```
### Por onde começar
Vamos criar um CRUD
O Angular tem como premissa a ordem abaixo:
| Tipo | Comando | Descrição |
| ------ | ------ | ------ |
| Módulo | ng g m [nome_modulo] | |
| Componente | ng g	c [nome_componente] | Um componente é uma classe responsável por controlar a view. Nela definimos a lógica que será aplicada para controle e ações da view |
| Serviços | ng	g s [nome_servico] | |
| Classe | ng g	cl [nome_classe] | |
| Interface | ng g i [nome_interface] | |

### Componentes
Então devemos sempre começar pelo componente, caso ele não exista
Nesse crud, teremos os componentes de Formulário para Criação e edição, um filtro da listagem e uma lista com as entidades.

```sh
#Criaremos o componente de listagem de pessoas, nome: lista-pessoa
ng g c lista-pessoa
#O retorno será : 
#CREATE src/app/lista-pessoa/lista-pessoa.component.css
#CREATE src/app/lista-pessoa/lista-pessoa.component.html
#CREATE src/app/lista-pessoa/lista-pessoa.component.spec.ts
#CREATE src/app/lista-pessoa/lista-pessoa.component.ts
ng serve --port 4201
```
Após a criação/Alteração do componente devemos importa-lo, na classe que o chamará, se esse for um componente global, incluiremos o import na classe 'app.component.ts'.
incluindo a tag '<app-lista-pessoa></app-lista-pessoa>' em arquivo 'app.component.html'.

### Data binding
Interpolation - {{variavel}} - A	 interpolação	 (ou	interpolation)	 é	 usada	 quando	 queremos
passar	 dados	 que	 estão	 na	 classe	 do	 componente	 para	 serem
mostrados	no	template.	Ele	sempre	terá	esse	sentido	de	transporte
componente	para	template.

Property binding - [propriedade] - Este	segue	praticamente	o	mesmo	 sentido	do	interpolation.	 O
property	 binding	 é	 usado	 quando	 queremos	 passar	 informações
da	 classe	 do	 componente	 para	 alguma	 propriedade	 de	 tag	 do
template.

```ts
foto:	string	= 'favicon.ico';
```
```html
<img	[src]="foto">
```

Event binding - (click)= "ação" - O	 event	 binding	 segue	 o	 caminho	 inverso	 dos	 outros.	 Ele	 é
utilizado	 para	 passar	 dados	 do	 template	 para	 a	 classe	 do
componente.	É	muito	usado	para	eventos	de	tela,	como	um	clique
em	algum	botão	ou	alguma	entrada	de	dados	na	tela.
```html
<button	(click)="msgAlerta()">Enviar	Alerta</button>
```
```ts
msgAlerta():	void	{
				alert('Livro	Angular	2');
		}
```

Two-way data binding - [(ngModel)]="variável" - O	 último	 data	 binding	 é	 o	 two-way	 data	 binding	 que	 junta
tanto	 o	 binding	 de	 propriedade	 (property	 binding)	 quanto	 o
binding	 de	 evento	 (event	 binding).	 Representamos	 com
	[(ngModel)]="variável"	,	que	contempla	tanto	a	representação
de	propriedade	quanto	de	evento		[()]	.


```html
<input	type="text">
```
```ts
nome:	string	= "Thiago";
```
```html
<input	type="text"	[(ngModel)]="nome">
<p>{{nome}}</p>
```
Para que funcione precisamos importar: 
```ts
import { FormsModule } from '@angular/forms';
```
## Diretivas
### *ngFor
```html
<ul>
    <li	*ngFor="let	pessoa	of	pessoas">
		{{pessoa}}
    </li>
</ul>
```

## Serviços
### Criando Serviço Global

```sh
#Criaremos o componente de listagem de pessoas, nome: lista-pessoa
ng g s alerta
#O retorno será : 
#CREATE src/app/alerta.service.spec.ts
#CREATE src/app/alerta.service.ts
ng serve --port 4201
```
Importá-la no app.component.ts
```ts
import	{	AlertaService	}	from	'./alerta.service';
```
Adicionar no HTML de app.Component, mas diferente do componente não precisa de injeção nos imports de component
```html
<button	(click)="enviarMsg()">Enviar	Alerta</button>
```
### Criando Serviço de Componente
```sh
cd src/app/lista-pessoa
#Criaremos o componente de listagem de pessoas, nome: lista-pessoa
ng g s pessoa-service
#O retorno será : 
#CREATE src/app/lista-pessoa/pessoa-service.service.spec.ts
#CREATE src/app/pessoa-service.service.ts
ng serve --port 4201
```

## Criando Classe
```sh
cd src/app/lista-pessoa
#Criaremos o componente de listagem de pessoas, nome: lista-pessoa
ng g cl pessoa
#O retorno será : 
#CREATE src/app/pessoa.spec.ts
#CREATE src/app/pessoa.ts
ng serve --port 4201
```

## Criando Rota sem módulos
```js
            {
                path: 'teste',
                component: TesteComponent
            },
```