#language: pt-br

Funcionalidade: Calculadora
	Para evitar erros tolos em matemática, 
	quero que me digam a soma de dois números

@mytag
Cenário: Somar dois números
	Dado Que eu informe o número 50 na calculadora
	E Que eu informe também o número 70 na calculadora
	Quando Eu clicar em Somar
	Então o resultado exibido deve ser 120
