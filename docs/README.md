# FIAP-TechChallenge1
Documentos referentes ao Tech Challenge

Tech Challenge - Etapa 1

## Entregável 1
 - Documentação do sistema (DDD) com Event Storming, incluindo todos os passos/tipos de diagrama mostrados na aula 6 do módulo de DDD, e utilizando a linguagem ubíqua, dos seguintes fluxos:
 - Realização do pedido e pagamento;
 - Preparação e entrega do pedido.
* É importante que os desenhos sigam os padrões utilizados na explicação.

---
# Linguagem Ubiqua

## Atores:
 - Cliente:
   - A pessoa que vai até a interface realiza pedido, faz o pagamento e faz a retirada do pedido. Pode fazer cadastro e acompanha status do pedido

 - Cozinha/ Administrativo:
   - Pessoa(s) que realiza o cadastro dos produtos, categorias, acompanha pedido, visualiza lista de clientes, realiza campanha promocional, executa o pedido, dá baixa no pedido, atualiza o status.

 - Sistema de Autoatendimento:
   - Recebe cadastro de cliente, recebe input de pedido, processa pedido (pagamento -> com sistema externo), envia pedido para a cozinha, apresenta status do pedido.

## Objetos de Trabalho
  - Tótem ou interface gráfica de autoatendimento;
  - Menu de produtos;
  - Gerador de QRCode;
  - Relatório de clientes cadastrados;
  - Disparador de e-mail;
  - Selecionador de produtos;
  - Botão para alterar status;
  - Linha de tempo do status;
  - Ticket do pedido;
  - Pedido em si;
---
# Event Storming - Eventos:

## Cliente:
  - Cliente escolheu produtos (colocou no carrinho de compras)
  - Cliente realizou o cadastro (CPF, nome e e-mail e são opcionais) 
  - Cliente finalizou o pedido (fechou o carrinho de compras)
  - Sistema gerou QRCode de pagamento 
  - Cliente realizou o pagamento
  - Cliente retirou ticket do pedido
  - Cliente retirou o pedido
  
## Sistema de autoatendimento (Gerenciador de pedido)
  - Aguardou resposta do Gateway de pagamento
  - Enviou o pedido para a cozinha
  - Solicitou novo pagamento (caso de falha do gateway)
  - Recebeu atualização de status
  - Apresentou atualização de status
  - Gerou tempo estimado do pedido
  - Gerou ticket do pedido
  
## Administrativo:
  - Deu baixa no pedido no sistema de autoatendimento
  - Cadastrou produto
  - Editou produto
  - Removeu produto
  - Alterou status do pedido
  - Listou clientes cadastrados
  - Disparou campanha promocional

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
# Documentação / Fluxos
 - Para Acessar a documentação completa:
   https://excalidraw.com/#room=bb1e2ff6f5c2be64c13c,1WxrLMV1WOehFQ93xijfkQ
 - Caso o link acima não funcione mais, abaixo seguem as imagens contendo o caminho trilhado 

![0 - Eventos](https://github.com/ralecsander/FIAP-TechChallenge1/assets/98660528/e3f85a6f-1b9a-402a-b5d7-a7b4e0d7b0fc)
![1 - Eventos e Pivotais](https://github.com/ralecsander/FIAP-TechChallenge1/assets/98660528/115793af-1cd2-4c27-9462-375c13325613)
![2 - PA](https://github.com/ralecsander/FIAP-TechChallenge1/assets/98660528/f33b8914-d20d-49cc-810c-f199d7fb076b)
![3 - Politicas e Comandos2](https://github.com/ralecsander/FIAP-TechChallenge1/assets/98660528/968cd8c7-ba27-48d2-a0f7-f6c7ab780167)
![4 - Modelos de Leitura e Sistemas Externos](https://github.com/ralecsander/FIAP-TechChallenge1/assets/98660528/deea28d6-4a7b-4213-bba1-5509c9f55f9a)
![5 - Contexto Delimitado](https://github.com/ralecsander/FIAP-TechChallenge1/assets/98660528/5ada7034-12bb-4076-9d1b-3933d349cb85)
![6 - Diagrama de Classes](https://github.com/ralecsander/FIAP-TechChallenge1/assets/98660528/ec59fcee-311a-4b50-85a5-17f5b0a39f9a)






