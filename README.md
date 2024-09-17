# prowler
teste de ambiente angular
## NVM
```sh
## Instalar NVM
sudo apt-get update
curl -o- https://raw.githubusercontent.com/nvm-sh/nvm/v0.40.1/install.sh | bash
export NVM_DIR="$([ -z "${XDG_CONFIG_HOME-}" ] && printf %s "${HOME}/.nvm" || printf %s "${XDG_CONFIG_HOME}/nvm")"
[ -s "$NVM_DIR/nvm.sh" ] && \. "$NVM_DIR/nvm.sh" # This loads nvm

### Listar versões do Node
nvm ls 
### Versão do Node para essa aplicação
nvm use 16
### Instalar Node
sudo apt-get install nodejs
node -v
### Instalar Node Package Manager
sudo apt-get install npm
npm -v 
### Versão do Angular para essa aplicação
npm install -g @angular/cli@1.7.3
### Instalar Versão do Angular
ng --version
### Rodar a aplicação
npm run start
```

### Docker
```sh
# Docker Start
docker compose up --build --remove-orphans --force-recreate -d
# Docker Stop
docker compose down -v
```

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


```sh

sudo apt-get install git

git config --global user.name "Fulano da Silva"
git config --global user.email fulanodasilva.git@gmail.com

git init

git status

git add filmes.txt

git commit -m "Arquivo inicial de citacoes"

git log
 
#Enviando as alterações para o Azure
git push origin master [branch de origem]
 
#Clonar de repositorio
git clone https://github.com/fulanodasilva/citacoes.git
 
git add .gitignore
 
#Commitar com nova mensagem e novos arquivos
git commit -a -m "Inserindo titulo e diminuindo tamanho da pagina"
 
#Visualização de log
git log --oneline
 
#Visualização de log com estatistica dos arquivos alterados
git log --stat
 
git diff
git diff --staged
git diff 222cccc..8877887
 
#Deletar Arquivo
git rm produtos.html 
#Renomear Arquivo-> de - para
git mv estilos.css principal.css 
#Movendo Arquivo-> de - para
git mv principal.js js/principal.js 
#emover de Stage
git reset -- index.html 
#Retornar ao status inicial do ultimo commit
git reset --hard 
#Desfazer commit 6111116
git revert --no-edit 6111116 
#Sincronizando com repositório
git pull master (Merge)
git pull master --rebase (Rebase) 
#Enviar os commits pro Git
git push 
#Listar branchs do Repo ( a branch com * é a branch utilizada)
git branch
#Listar branchs do Repo ( a branch com * é a branch utilizada)
git branch -v (listara a branch + ultimo commit) 
#Criando branch
git branch [nome_da_branchq]
git branch
git branch -v 
#Utilizando nova branch
git checkout [nome_da_branchq] 
#criando e utilizando nova branch
git checkout -b [nome_da_branch]
git branch
git branch -v 
#deletando branch
git branch -d [nome_da_branch]
git branch
git branch -v 
#Visualizando 3 últimos commits da branch
git log -n 3 --oneline --decorate --parents 
#Mesclando alterações-> oriundas da branch master
git merge master -m "Mesclando com a branch design"
git branch --no-merged 
#Mesclando alterações com rebase-> oriundas da branch master
git rebase design
git branch --no-merged 
#Log de git gráfico
git log --graph 
#baixar arquivos remotos da branch
git fetch master
git log 
#Resolvendo Conflitos
git mergetool
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