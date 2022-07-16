# DesafioXP

Código feito para o teste técnico da XP

## Descrição 

App desenvolvido utilizando 
- WPF (Windows Presentation Foundation)
- ReactiveUI
- DynamicData
- Microsoft CommunityToolkit
- ModernWpfUI

## Mock
Foi desenvolvido um Mock para OrdensService, onde esta sendo gerado Ordens com valores aleatórios, apenas para simular a adição e atualização dos elementos da lista.

## Testes
Só foi desenvolvido o teste para a ViewModel de Histórico (Única tela requisitada para o teste).

O serviço real deveria buscar informações da bolsa, mas não foi implementado, apenas o Mock.

# Performance

Fiz um snapshot do uso de memória e do CPU, com a intenção de encontrar os pontos de possíveis gargalos, seja por processamento, ou leak de memória.

![CPU Profile](https://github.com/FelipeAvilaMachado/DesafioXP/DesafioXP_CPU_Usage.png?raw=true)
Conforme as imagens, o uso de CPU se manteve baixo, sem picos de processamento, e a maior parte do processamento foi devido a renderização da tela.

![Memory Snapshot](https://github.com/FelipeAvilaMachado/DesafioXP/DesafioXP_Memory_Usage.png?raw=true)
No lado da memória, a utilização se manteve constante, mesmo com a atualização dos itens realizadas constantemente, indicando que não houve leak de memoria.

## Observações
O teste foi desenvolvido em 3 dias no meu tempo livre, pois estava de ferias ao recebe-lo, e decidi iniciar somente ao terminar minha viagem.
Alguns detalhes do layout ficaram compromissados, como por exemplo o cabeçalho, que esta com o divisor padrão entre eles e a falta da seta indicando a direção da ordenação dos itens.

## License
[MIT](https://choosealicense.com/licenses/mit/)