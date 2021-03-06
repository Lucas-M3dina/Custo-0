CREATE DATABASE Custo
GO

USE Custo;
GO

CREATE TABLE tipoUsuario(
idTipoUsuario TINYINT PRIMARY KEY IDENTITY (1,1),
nomeTipoUsuario VARCHAR(12) NOT NULL
);
GO

CREATE TABLE Usuario(
idUsuario BIGINT PRIMARY KEY IDENTITY (1,1),
idTipoUsuario TINYINT FOREIGN KEY REFERENCES tipoUsuario(idTipoUsuario),
email VARCHAR(266) NOT NULL,
senha VARCHAR(70) NOT NULL
);
GO

CREATE TABLE Estado(
idEstado TINYINT PRIMARY KEY IDENTITY (1,1),
nomeEstado VARCHAR(40) NOT NULL
);
GO

CREATE TABLE Endereco(
idEndereco BIGINT PRIMARY KEY IDENTITY (1,1),
idEstado TINYINT FOREIGN KEY REFERENCES Estado(idEstado),
cep VARCHAR(10) NOT NULL,
titulo VARCHAR(74) NOT NULL
);

CREATE TABLE Cliente(
idCliente INT PRIMARY KEY IDENTITY (1,1),
idUsuario BIGINT FOREIGN KEY REFERENCES Usuario(idUsuario),
idEndereco BIGINT FOREIGN KEY REFERENCES Endereco(idEndereco),
nome VARCHAR(50) NOT NULL,
documento VARCHAR(24) NOT NULL
);
GO

CREATE TABLE Empresa(
idEmpresa SMALLINT PRIMARY KEY IDENTITY (1,1),
idUsuario BIGINT FOREIGN KEY REFERENCES Usuario(idUsuario),
idEndereco BIGINT FOREIGN KEY REFERENCES Endereco(idEndereco),
nomeFantasia VARCHAR(50) NOT NULL,
cnpj VARCHAR(24) NOT NULL,
imagemEmpresa VARCHAR(74) 
);
GO

CREATE TABLE tipoProduto(
idTipoProduto TINYINT PRIMARY KEY IDENTITY (1,1),
titulo VARCHAR(20) NOT NULL
);
GO

CREATE TABLE Produto(
idProduto INT PRIMARY KEY IDENTITY (1,1),
idTipoProduto TINYINT FOREIGN KEY REFERENCES tipoProduto(idTipoProduto),
idEmpresa SMALLINT FOREIGN KEY REFERENCES Empresa(idEmpresa),
preco FLOAT NOT NULL,
quantidade INT NOT NULL,
titulo VARCHAR(50) NOT NULL,
descricao VARCHAR(470) NOT NULL,
imagemProduto VARCHAR(74),
dataValidade SMALLDATETIME
);
GO

CREATE TABLE situacaoReserva(
idSituacaoReserva TINYINT PRIMARY KEY IDENTITY (1,1),
tituloReserva VARCHAR(20)
);
GO

CREATE TABLE Reserva(
idReserva INT PRIMARY KEY IDENTITY (1,1),
idSituacao TINYINT FOREIGN KEY REFERENCES situacaoReserva(idSituacaoReserva),
idProduto INT FOREIGN KEY REFERENCES Produto(idProduto),
idEmpresa SMALLINT FOREIGN KEY REFERENCES Empresa (idEmpresa),
idCliente INT FOREIGN KEY REFERENCES Cliente(idCliente),
quantidade INT,
preco FLOAT,
dataSolicitacao SMALLDATETIME
);
GO

