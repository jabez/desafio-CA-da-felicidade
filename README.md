## Sobre
Este repositório faz parte do desafio lançado pelo Career Advisor Felipe Pimentel com o intuíto de aprimorar os conhecimentos em .net

## O Desafio

- Criar uma API para fazer um CRUD (CRUD mais lindo da vida)
Deve haver os seguintes pre requisitos:
- Ter mais de 1 projeto na solution
- Utilizar os seguintes tipos primitivos (int, bool, datetime, string, arrays (Lista ou Coleções))
- Ter 1 exemplo de cada pilar de OOP
- Utilizar princípios SOLID
- Ter 1 exemplo de Design Pattern (Criação, Comportamento ou estrutura)
- Ter um relacionamento entre os objetos (1:1 ou 1:n ou n:n)
- Utilizar um ORM
- Ter um teste de unidade
- Utilizar o Swagger para documentar a API
- Criar um README.md

## Especificações
 - O Design Pattern escolhido foi o [Mediator](https://refactoring.guru/pt-br/design-patterns/mediator) 
 - ORM escolhido foi o [EntityFramework](https://learn.microsoft.com/en-us/ef/)
 
## Setup
 Para rodar o projeto basta baixar o repositório e executar o comando abaixo na pasta /docker-compose:</br>
 ``` docker-compose up --build ```

## Funcionalidades
A Api permite realizar a inclusão, consulta, alteração e exclusão de livros e autores.
