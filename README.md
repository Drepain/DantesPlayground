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

## Classes
### General.cs
Classe que armazena variáveis e conteúdos uteis a serem utilizados mais tarde em outras classes.

### GameManager.cs
Classe responsável pela inicialização e pelo update de todos os objetos do jogo. Nesta classe encontra-se também guardadas as funções responsáveis pelo movimento da câmera. 

### Input.cs
Como o próprio nome indica, esta classe é responsável pelo armazenameto das propriedades responsáveis pelo input do utilizador. Como já mencionado anteriormente, existe a possibilidade de utilizar Teclado e Comando como input.

### Map.cs
Classe responsável pela geração do mapa, certos objetos do mapa são gerados de forma aleatória. Após gerar os objetos de forma aleatória, é criado o fundo do mapa.

### Sprite.cs
Classe responsável pelo desenho das texturas dos objetos na tela.

### Player.cs e Player2.cs
Classes herdeiras de **Sprite.cs** responsáveis por colocar o Player no mapa, gere também as animações deste, bem como o próprio ataque acompanhado do som.

>[!Note]
> Estas classes responsáveis por ambos os players partilharam bastantes semelhanças, pelo que uma poderia ser herdeira da outra ou então encontrar-se as propriedades no interior da mesma classe.

# Considerações Finais
Apesar de o projeto encontra-se numa fase bastante primitiva, faltando várias implementações, como: Hitboxes, Menus e UI; trata-se de um projeto bastante interessante que poderá ser continuado o desenvolvimento num futuro muito próximo.




