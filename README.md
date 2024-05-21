# DantesPlayground

Projeto realizado no âmbito da UC TDV


## Membros 

Francisco Gomes - 27941
Jorge Costa - 27923


## Descrição do jogo

**DantesPlayground** é um jogo usando como base **C#** e [**MonoGame**](https://monogame.net).

Este jogo usou como inspiração titulos como "**Mortal Kombat**" e "**Street Fighter**"; Poderá ser jogado por duas pessoas, havendo a opção de usar __<ins>Teclado</ins>__ ou __<ins>Comando</ins>__ como input, em que o objetivo é derrotar o adversário através de ataques corpo-a-corpo até o HP chegar no valor **0**. Ambos os players estarão confinados a uma arena de pedra, sem possibilidade de abandonar a mesma.


## Plataformas

DantesPlayground é um jogo em que apenas foi testado a compatibilidade com Windows e Linux, acredita-se que também funcione em MacOS. 

>  *Não existe qualquer tipo de compatibilidade com Android e IOS*.


# Estrutura e Organização do Código

Este projeto apresenta uma organização muito simples, estando os objetos do jogo divididos por 2 pastas:
 - "**Assets**" - Dentro desta pasta encontra-se todos os `.png` utilizados para a criação de *Personagens*/*Mapa*/*etc*
 - "**Classes**" - Dentro desta pasta, como o próprio nome indica, encontram-se todas as classes do jogo, desde Criação do mapa, Movimentação do Player, Input, ...

Os restantes items presentes no repositório foram criados pelo **MonoGame** ou pelo próprio **IDE**.

