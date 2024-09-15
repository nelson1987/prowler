# prowler
teste de ambiente angular
### Dotnet
```sh
dotnet new .gitignore
mkdir src
mkdir tests
cd tests
dotnet new xunit -n Prowler.IntegrationTests
```
### GIT
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
