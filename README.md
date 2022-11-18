# Trabalho-Engenharia-De-Software-II

## Linguagem de Programação C#, usando SQL pelo Microsoft SQL Manager 18
###### Comandos para criação do banco de dados no arquivo 'SQLQuery.sql'

###### Link Demostração 1º Sprint: Cadastrar Cliente: https://www.youtube.com/watch?v=VxEedqpYaBg&feature=emb_imp_woyt
###### Link Demonstração 2º Sprint: Cadastrar Funcionário/Produto/Compra: https://www.youtube.com/watch?v=OS2pHzgasvo
###### Link Demonstração 3º Sprint: Relatórios: https://www.youtube.com/watch?v=QqYb2Mn5LW0
###### Vídeo apresentação do projeto final, com todas as sprints juntas e funcionais:
https://www.youtube.com/watch?v=R05zTdb3vxs

# Cadastrar Cliente/Funcionário

###### Botão "Novo" - Habilita os campos para realizar o cadastro.
###### O usuário irá inserir o nome, telefone cpf e enfereço. Todos os campos são obrigatórios.
###### O id do Cliente e do Funcionário são gerados automaticamente pelo Banco de Dados, o mesmo vale para o salário do Funcionário.
###### Botão Salvar - Salva os dados cadastrais no banco de dados.
###### Ao salvar, os dados dos clientes e dos funcionários cadastrados serão exibidos no datagrid, e, ao clicar duas vezes em seus nomes, seus dados serão preenchidos nos campos
###### de cadastro para a edição, ou exclusão dos mesmos utilizando os botões "Editar" e "Excluir" respectivamente.


# Cadastrar Produto 

###### Botão "Novo" - Habilita os campos para realizar o cadastro do Produto.
###### O usuário irá inserir o nome, valor, quantidade, descrição, estoque mínimo e validade do produto.
###### Botão Salvar - Salva os dados cadastrais no banco de dados.
###### Ao salvar, os dados dos produtos cadastrados serão exibidos no datagrid, e, ao clicar duas vezes em seus nomes, seus dados serão preenchidos nos campos
###### de cadastro para a edição, ou exclusão dos mesmos utilizando os botões "Editar" e "Excluir" respectivamente.


# Cadastrar Compra

###### Botão "Novo" - Habilita os campos para realizar o cadastro da Compra.
###### O usuário irá selecionar um dos funcionários cadastrados no banco de dados para estabelecer qual foi o responsável pela venda.
###### O usuário irá selecionar um dos clientes cadastrados no banco de dados para estabelecer qual foi o responsável pela compra.
###### Ao clicar em "Cadastrar", o cliente e o vendedor são salvos no banco de dados.
###### Clicando duas vezes no datagrid da compra, o datagrid do carrinho será habilitado, onde o usuário irá selecionar os produtos que o cliente irá comprar, juntamente com a forma de pagamento, podendo ser no cartão de crédito, ou dinheiro.
###### Ao clicar em "Pagar", o valor total será exibido do datagrid da compra, juntamente com o id da venda, id do funcionário, id do cliente, valor total e forma de pagamento.
###### Se o valor total da compra for menor que R$ 1000,00 o cliente terá um desconto de 3%, mas se o valor total da compra for maior do que R$1000,0 , o cliente terá um desconto de 5%. 
###### Se o total vendido pelos funcionários for maior do que R$10.000,00 , o mesmo ganhará uma comissão de 7%. Se for menor, 5%.


# Relatórios

###### No botão "Relatórios" vôce pode realizar algumas pesquisas como:
###### Clientes que realizaram compra
###### Compras realizadas em período selecionado
###### Produtos abaixo do estoque mínimo
###### Folha de pagamento dos salários dos funcionários vendedores.
