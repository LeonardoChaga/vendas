create database trab

use trab

create table cliente(
id int primary key identity,
nome varchar (40) not null ,
telefone varchar (14) not null ,
cpf varchar (13) not null ,
endereco varchar (100) not null
)

select * from cliente


create table funcionarios (
id int primary key identity,
nome varchar(40) not null,
telefone varchar(14) unique not null,
cpf varchar(13) unique not null,
endereco varchar(100) not null,
salario int default 1500,

)

select * from funcionarios


create table produtos(
id int primary key identity,
nome varchar (40) not null ,
valor decimal not null ,
qtd int not null ,
descricao varchar (100) not null,
estoquemin int not null,
validade date not null
)

select * from produtos

create table compra(
id int primary key identity,
idcliente int,
idfuncionarios int,
valortotal int,
formapagamento varchar (40),
pago varchar (4) default 'Não',
datacompra date DEFAULT GETDATE()
FOREIGN KEY (idcliente) REFERENCES cliente(id),
FOREIGN KEY (idfuncionarios) REFERENCES funcionarios(id),

)

select * from compra


create table item (
id int primary key identity,
idproduto int,
idcompra int,
qtditem int not null,
valoritem decimal,
FOREIGN KEY (idcompra) REFERENCES compra(id),
CONSTRAINT fk_idproduto FOREIGN KEY (idproduto) REFERENCES produtos(id),
)


select * from item

select item.[id] as "ID Item", idproduto as "ID Produto", idcompra as "ID Compra", qtditem as "Quantidade", valoritem = [qtditem]*[valor] from item, produtos where idcompra like ('%" + idcompra + "%')
select qtditem,valor from item,produtos


SELECT CASE WHEN EXISTS(SELECT * FROM[compra] WHERE idcliente = " + id + ") THEN CAST(1 AS BIT) ELSE CAST(0 AS BIT) END

SELECT id as 'ID Produto', nome as 'Nome do Produto', qtd as 'Quantidade', estoquemin as 'Estoque Minimo' FROM produtos WHERE qtd < estoquemin  
SELECT * FROM compra WHERE datacompra BETWEEN '01-12-2021' AND '14-12-2021'
select id as 'ID Funcionario', nome as 'Nome do Funcionario', telefone as 'Telefone', cpf as 'CPF', salario as 'Salario Funcionario' from funcionarios
SELECT compra.id as 'ID Da Compra', compra.idcliente as 'ID do Cliente', cliente.nome as 'Nome do Cliente', cliente.telefone as 'Telefone', cliente.cpf as 'CPF', cliente.endereco as 'Endereço' FROM compra INNER JOIN cliente ON compra.idcliente = cliente.id