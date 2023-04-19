#Criar api para VS Code

dotnet new webapi -o NOME-DA-SUA-API


# Modulo1-Semana9-Projeto-01
Modulo1-Semana9-Projeto-01


# VSCode Comands

dotnet ef migrations add InitialCreate
dotnet ef database update

## Instalar o EF

Caso o EF não estiver instalado na versão do vs code precisa instalar 

### .NET 7

dotnet tool install --global dotnet-ef

### .NET 6

dotnet tool install --global dotnet-ef --version 6.*

### .NET 5

dotnet tool install --global dotnet-ef --version 5.*

### .NET Core 3

dotnet tool install --global dotnet-ef --version 3.*




# VS 2022 Commands

Add-Migration InitialCreate

Update-Database




# Como montar um ToDo Exemplo

ToDo
- Criar Método Get do PacienteController - FEITO
- Criar DTO para Paciente no método Get - FEITO
- Retornar a PacienteGetDto no método GET - FEITO
- Montar meu Objeto PacienteGetDto e devolver no return Ok() - FEITO


ToDo Construtor com parametro
- Criar o Contrutor da Controller - Feito
- Adicionar o parametro do meu contexto - Feito
- Criar uma variavel chamada nome do seu contexto na classe controller - Feito
- Preciso passar o parametro do contrutor para minha variavel - Feito