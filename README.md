🎮 Termo (WinForms Edition)

Uma implementação simples do jogo Termo, desenvolvida em C# com Windows Forms, com foco em prática de lógica de programação e manipulação de strings.

Projeto criado como exercício de lógica — não como produto comercial.

🧠 Objetivo

Este projeto foi desenvolvido para exercitar:

Comparação de strings

Controle de tentativas

Manipulação de listas

Lógica de letras repetidas

Sorteio aleatório de palavras

Atualização visual baseada em regras

A proposta foi reproduzir o comportamento central do jogo Termo de forma funcional e visual.

🛠 Tecnologias Utilizadas

C#

.NET

Windows Forms

Estrutura orientada a eventos

🎯 Regras do Jogo

O sistema sorteia uma palavra de 5 letras.

O jogador possui até 5 tentativas para acertar.

Cada tentativa gera um feedback visual:

Cor	Significado
🟩 Verde	Letra correta na posição correta
🟨 Amarelo	Letra existe na palavra, mas em posição diferente
⬛ Escuro	Letra não existe na palavra

Ao acertar, o jogo informa a linha da vitória.
Ao esgotar as tentativas, o jogo reinicia automaticamente.

🚀 Como Executar

Clone este repositório

Abra a solução no Visual Studio

Compile e execute o projeto

🎨 Interface

A interface foi estilizada com paleta inspirada no Wordle:

Tema escuro

Botões com bordas personalizadas

Feedback visual imediato

Layout fixo e centralizado

📌 Estrutura Atual

O projeto mantém:

Lógica de jogo integrada ao Form

Controle manual do teclado virtual

Verificação correta de letras repetidas

Por ser um projeto de prática, a arquitetura foi mantida simples.

📈 Possíveis Evoluções

Separar lógica da interface (camada de domínio)

Implementar dicionário real de palavras

Adicionar animações

Criar versão Web (ASP.NET / Blazor)

Implementar testes unitários

🧩 Motivação

Projeto criado como forma de aquecer lógica e reforçar fundamentos em C#.
Representa uma etapa de evolução prática e aprendizado contínuo.
