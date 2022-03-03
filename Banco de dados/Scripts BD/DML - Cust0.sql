USE Custo;
GO

INSERT INTO tipoUsuario(nomeTipoUsuario)
VALUES ('Empresa'),('Cliente'),('ONG')

INSERT INTO Usuario (idTipoUsuario,email,senha)
VALUES (1,'extra@hotmail.com','extra1234'),(1,'paodeacucar@gmail.com','pda@1234'),(1,'veran@email.com','veran4321'),(2,'gersin@gmail.com','vascocampeao3'),(2,'veraverao@hotmail.com','40028922'),(2,'vardo@email.com','brazil4all'),(3,'msf@hotmail.com','florence200'),(3,'spnsa@gmail.com','cjangelinavive2022'),(3,'esf@email.com','havaixd1')

INSERT INTO  Estado(nomeEstado)
VALUES ('Acre'),('Alagoas'),('Amapá'),('Amazonas'),('Bahia'),('Ceará'),('Distrito Federal'),('Espirito Santo'),('Goiás'),('Maranhão'),('Mato Grosso'),('Mato Grosso do Sul'),('Minas Gerais'),('Pará'),('Paraíba'),('Paraná'),('Pernambuco'),('Piauí'),('Rio de Janeiro'),('Rio Grande do Norte'),('Rio Grande do Sul'),('Rondônia'),('Roraima'),('Santa Catarina'),('São Paulo'),('Sergipe'),('Tocantins')

INSERT INTO Endereco(idEstado,cep,titulo)
VALUES (19,'12345-678','Rua 1'),(19,'87654-321','Avenida 2'),(25,'32451-098','Estrada 3'),(1,'67580-387','Rodovia 4'),(27,'43572-019','BR-005'),(4,'23260-965','Alameda 6'),(6,'52672-293','Lageado 7'),(16,'35463-0783','Caminho 8'),(20,'23456-987','Rota 9')

INSERT INTO Cliente(idUsuario,idEndereco,nome,documento)
VALUES (4,4,'Gerson Almeida Leite','123.456.789-10'),(5,5,'Vera Gioconda de Faria Melo','098.765.432-01'),(6,6,'Valdívia Ferreira Matos dos Santos e Silva','576.809.231-38'),(7,7,'Medicines Sans Frontiers','98.153.674/0001-57'),(8,8,'Serviço Promocional Nossa Senhora Aparecida','39.767.290/0001-27'),(9,9,'Engenheiro Sem Fronteiras','72.467.921/0001-37')

INSERT INTO Empresa(idUsuario,idEndereco,nomeFantasia,cnpj,imagemEmpresa)
VALUES (1,1,'Extra Hipermercado','12.345.678/0001-99',''),(2,2,'Grupo Pão de Açúcar','21.435.768/0001-99',''),(3,3,'Supermercado Veran','12.545.878/0001-89','')

INSERT INTO tipoProduto(titulo)
VALUES ('Limpeza & Higiene'),('Alimentação'),('Lazer'),('Eletrônicos'),('Eletrodomésticos'),('Estética')

INSERT INTO Produto(idTipoProduto,idEmpresa,preco,quantidade,titulo,descricao,imagemProduto,dataValidade)
VALUES (2,1,1.00,4000,'Paçoca Mococa Muriçoca','Paçoca caseira direto da fazenda','','20220309 23:45:00'),(2,1,7.45,5000,'ZielonySmaczny','Acelga polonesa','','20220307 10:00:00'),(2,2,5.79,7000,'Báh tchê!!!','Chá mate Leão sabor verde','','20220402 11:00:00'),(6,3,576.80,472,'Xêro Baum','Perfume aroma doce Puro Vodoo','','20220321 17:13:09'),(1,3,19.99,4520,'Gelzin','Alcóol em gel Natura','','20220527 00:00:00'),(1,2,0.99,9000,'Sabão Crá-crá','Sabonete líquido Ace Ventura','','20220602 00:00:00'),(3,3,15.60,7890,'Puxa, prende, passa','Maço de cigarros Marlboro','','20220330 01:10:01')

INSERT INTO situacaoReserva(tituloReserva)
VALUES ('Solicitada'),('Cancelada'),('Aceita'),('Recusada'),('Finalizada')

INSERT INTO Reserva(idSituacao,idProduto,idEmpresa,idCliente,quantidade,preco,dataSolicitacao)
VALUES (1,1,1,1,3,1.00,'20220303 08:46:57'),(2,2,2,2,1,7.45,'20220228 22:30:09'),(3,3,3,3,7,5.79,'20220302 09:07:58'),(4,2,1,3,9,576.80,'20220303 08:50:33'),(5,1,3,2,20,19.99,'20220126 10:11:12')
