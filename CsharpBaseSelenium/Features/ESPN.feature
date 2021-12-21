@Automate
Feature: ESPN

Poc de automação co CSharp e BDD 

Background: 
Given que esteja na URL da ESPN

Scenario Outline: Poc CSharp
	When salvo o titulo no arquivo
	And tiro um print da tela
	And seleciono um esporte <esporte>
	Then valido se estou na tela de <esporte>
Examples:
	|esporte|
	|Futebol|

	