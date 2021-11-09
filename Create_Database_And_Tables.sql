CREATE DATABASE projetoAeroportoHotel
GO
USE projetoAeroportoHotel
GO
CREATE TABLE Cliente(
	Id INT IDENTITY,
	Nome VARCHAR(200) NOT NULL,
	CPF BIGINT NOT NULL UNIQUE,
	DataNasc DATE NOT NULL,
	Sexo VARCHAR(9)
	PRIMARY KEY (Id),
)
GO
CREATE TABLE Hotel
(
	Id int identity
	,Nome VARCHAR (200) NOT NULL
	,Endereco VARCHAR (200) NOT NULL
	,Cidade VARCHAR (50) NOT NULL
	,Estado VARCHAR (50) NOT NULL
	,CNPJ BIGINT UNIQUE NOT NULL
	,Classificacao INT
	PRIMARY KEY(Id)
)
GO
create table Quarto
(
	Id int identity
    ,IdHotel int not null
	,NumeroHospedes int not null
    ,NumeroQuarto int not null
	,TipoQuarto varchar(20)NOT NULL
	,Descrição varchar(300)NOT NULL
	,ValorDiaria decimal not null
    PRIMARY KEY (Id)  
	FOREIGN KEY (IdHotel) REFERENCES Hotel (Id)
)
GO
Create table ReservaHotel
(
     Id int identity(1,1)
	 ,IdCliente int not null
	 ,IdQuarto int not null
	 ,DtCheckin datetime not null
	 ,DtCheckout datetime not null
	 ,ValorTotal decimal not null
	 PRIMARY KEY (id)
	 FOREIGN KEY (IdCliente) REFERENCES Cliente (Id),
	 FOREIGN KEY (IdQuarto) REFERENCES Quarto (Id)
)
GO
Create table Aeroporto
(
     Id int identity(1,1)
	 ,Nome Varchar (200) NOT NULL
	 ,Estado Varchar (50) NOT NULL
	 ,Cidade varchar (200) NOT NULL	 
	 PRIMARY KEY (Id)
)
GO
CREATE TABLE Voo(
	Id INT IDENTITY,
	NumeroVoo INT NOT NULL,
	IdAeroportoOrigem INT NOT NULL,
	IdAeroportoDestino INT NOT NULL,
	DateTimePartida	DATETIME NOT NULL,
	DateTimeChegada DATETIME NOT NULL,
	Valor DECIMAL NOT NULL,
	PRIMARY KEY (Id),
	FOREIGN KEY (IdAeroportoOrigem) REFERENCES Aeroporto (Id),
	FOREIGN KEY (IdAeroportoDestino) REFERENCES Aeroporto (Id)
)
GO
CREATE TABLE ReservaPassagem(
	Id INT IDENTITY,
	IdVoo INT NOT NULL,
	IdCliente INT NOT NULL,
	NumeroAssento INT NOT NULL,
	BagagemExtra INT NOT NULL,
	PRIMARY KEY (Id),
	FOREIGN KEY (IdVoo) REFERENCES Voo (Id),
	FOREIGN KEY (IdCliente) REFERENCES Cliente (Id)
)
