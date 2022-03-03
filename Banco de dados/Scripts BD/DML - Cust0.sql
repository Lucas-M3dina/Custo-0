USE Custo;
GO

INSERT INTO tipoUsuario(nomeTipoUsuario)
VALUES ('Empresa'),('Cliente'),('ONG')

INSERT INTO Usuario (idTipoUsuario,email,senha)
VALUES (1,'extra@hotmail.com','extra1234'),(1,'paodeacucar@gmail.com','pda@1234'),(1,'veran@email.com','veran4321'),(2,'gersin@gmail.com','vascocampeao3'),(2,'veraverao@hotmail.com','40028922'),(2,'vardo@email.com','brazil4all'),(3,'msf@hotmail.com','florence200'),(3,'spnsa@gmail.com','cjangelinavive2022'),(3,'esf@email.com','havaixd1')

INSERT INTO  Estado(nomeEstado)
VALUES ('Acre'),('Alagoas'),('Amap�'),('Amazonas'),('Bahia'),('Cear�'),('Distrito Federal'),('Espirito Santo'),('Goi�s'),('Maranh�o'),('Mato Grosso'),('Mato Grosso do Sul'),('Minas Gerais'),('Par�'),('Para�ba'),('Paran�'),('Pernambuco'),('Piau�'),('Rio de Janeiro'),('Rio Grande do Norte'),('Rio Grande do Sul'),('Rond�nia'),('Roraima'),('Santa Catarina'),('S�o Paulo'),('Sergipe'),('Tocantins')

INSERT INTO Endereco(idEstado,cep,titulo)
VALUES (19,'12345-678','Rua 1'),(19,'87654-321','Avenida 2'),(25,'32451-098','Estrada 3'),(1,'67580-387','Rodovia 4'),(27,'43572-019','BR-005'),(4,'23260-965','Alameda 6'),(6,'52672-293','Lageado 7'),(16,'35463-0783','Caminho 8'),(20,'23456-987','Rota 9')

INSERT INTO Cliente(idUsuario,idEndereco,nome,documento)
VALUES (4,4,'Gerson Almeida Leite','123.456.789-10'),(5,5,'Vera Gioconda de Faria Melo','098.765.432-01'),(6,6,'Vald�via Ferreira Matos dos Santos e Silva','576.809.231-38')

INSERT INTO Empresa(idUsuario,idEndereco,nomeFantasia,cnpj,imagemEmpresa)
VALUES (1,1,'Extra Hipermercado','12.345.678/0001-99',''),(2,2,'Grupo P�o de A��car','21.435.768/0001-99',''),(3,3,'Supermercado Veran','12.545.878/0001-89','')

INSERT INTO tipoProduto(titulo)
VALUES ('Limpeza & Higiene'),('Alimenta��o'),('Lazer'),('Eletr�nicos'),('Eletrodom�sticos'),('Est�tica')

INSERT INTO Produto(idTipoProduto,idEmpresa,preco,quantidade,promocao,descricao,imagemProduto,dataValidade)
VALUES (2,1,'','4000','','Pa�oca caseira direto da fazenda','',''),(2,1,'','5000','','Acelga polonesa','',''),(3,2,'','7000','','Ch� mate Le�o sabor verde','',''),(6,3,'','32','','Cal�ado casual de borracha Havaianas','',''),(5,3,'','320','','Geladeira 2 portas Electrolux','',''),(1,2,'','2000','','Sabonete �l�quido Ace','',''),(4,3,'200,27','320','','Bola esportiva basquete Spalding','','')

INSERT INTO situacaoReserva(tituloReserva)
VALUES ('Solicitada'),('Cancelada'),('Aceita'),('Recusada'),('Finalizada')

INSERT INTO Reserva(idSituacao,idProduto,idEmpresa,idCliente,descricao,dataSolicitacao)
VALUES (1,1,1,1,'Solicitada. Aguardando confirma��o da empresa!',''),(2,2,2,2,'Sua reserva foi cancelada, por tempo excedido/n�o retirada do produto',''),(3,3,3,3,'Aceito. Aguardando retirada no local',''),(4,2,1,3,'Reserva recusada pela empresa',''),5,1,3,2,'Produto retirado, reserva finalizada!!','')