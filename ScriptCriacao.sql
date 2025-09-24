CREATE DATABASE SistemaHospedagem 
GO

USE SistemaHospedagem
GO

CREATE TABLE FuncionarioCargos(
	Id		TINYINT IDENTITY,
	Nome	VARCHAR(30) NOT NULL 

	CONSTRAINT PK_FuncionarioCargos PRIMARY KEY(Id)
);

CREATE TABLE FuncionarioStatus( 
	Id		TINYINT IDENTITY, 
	Nome	VARCHAR(30) NOT NULL,

	CONSTRAINT PK_FuncionarioStatus PRIMARY KEY(Id)
);

CREATE TABLE FuncionarioNiveisAcesso(
	Id		TINYINT IDENTITY,
	Nome	VARCHAR(30) NOT NULL 

	CONSTRAINT PK_FuncionarioNiveisAcesso PRIMARY KEY(Id)
);

CREATE TABLE Funcionarios(
	Id				INTEGER IDENTITY, 
	IdCargo			TINYINT				NOT NULL, 
	IdStatus		TINYINT				NOT NULL,
	Nome			VARCHAR(50)			NOT NULL,
	Cpf				VARCHAR(11)			NOT NULL UNIQUE, 
	DataAdmissao	DATE				NOT NULL, 

	CONSTRAINT PK_Funcionarios PRIMARY KEY(Id),
	CONSTRAINT FK_Funcionarios_Cargo FOREIGN KEY(IdCargo) REFERENCES FuncionarioCargos(Id),
	CONSTRAINT FK_Funcionarios_Status FOREIGN KEY(IdStatus) REFERENCES FuncionarioStatus(Id)
);

CREATE TABLE Perfil(
	Id				INTEGER IDENTITY,
	IdFuncionario	INTEGER			NOT NULL,
	NomeUsuario		VARCHAR(50)		NOT NULL,
	Email			VARCHAR(320)	NOT NULL UNIQUE, 
	Senha			CHAR(60)		NOT NULL,
	Salt			CHAR(32)		NOT NULL,
	IdNivelAcesso	TINYINT			NOT NULL,
	
	CONSTRAINT PK_Perfil PRIMARY KEY(Id),
	CONSTRAINT Fk_Perfil_Usuario FOREIGN KEY(IdFuncionario) REFERENCES Funcionarios(Id),
	CONSTRAINT FK_Funcionarios_NivelAcesso FOREIGN KEY(IdNivelAcesso) REFERENCES FuncionarioNiveisAcesso(Id)
);

CREATE TABLE Periodos(
	Id				SMALLINT IDENTITY, 
	Nome			VARCHAR(50)			NOT NULL, 
	DataInicio		DATE				NOT NULL, 
	DataFim			DATE				NOT NULL,
	Descricao		VARCHAR(300) 

	CONSTRAINT PK_Periodos PRIMARY KEY(Id)
);

CREATE TABLE TipoQuartos(
	Id TINYINT IDENTITY,
	Nome VARCHAR(50) NOT NULL,
	ValorDiaria DECIMAL(15,2) NOT NULL,

	CONSTRAINT PK_TipoQuartos PRIMARY KEY(Id)
);
	
CREATE TABLE TipoAjustes(
	Id TINYINT IDENTITY, 
	Nome VARCHAR(40) NOT NULL,

	CONSTRAINT PK_TipoAjustes PRIMARY KEY(Id)
); 

CREATE TABLE RegrasDeValores(
	Id				INTEGER IDENTITY, 
	IdPeriodo		SMALLINT NOT NULL,
	IdTipoQuarto	TINYINT NOT NULL, 
	IdTipoAjuste	TINYINT NOT NULL, 
	Nome			VARCHAR(50) NOT NULL, 
	Valor			DECIMAL(15,2) NOT NULL,
	DiasAtivos		VARCHAR(100),

	CONSTRAINT Pk_RegrasDeValores PRIMARY KEY(Id),
	CONSTRAINT FK_RegrasDeValores_Periodos FOREIGN KEY(IdPeriodo) REFERENCES Periodos(Id),
	CONSTRAINT FK_RegrasDeValores_TipoQuartos FOREIGN KEY(IdTipoQuarto) REFERENCES TipoQuartos(Id),
	CONSTRAINT FK_RegrasDeValores_TipoAjutes FOREIGN KEY(IdTipoAjuste) REFERENCES TipoAjustes(Id)
);

CREATE TABLE AcomodacaoStatus(
	Id TINYINT IDENTITY, 
	Nome VARCHAR(50) NOT NULL

	CONSTRAINT PK_AcomodacaoStatus PRIMARY KEY(Id)
);

CREATE TABLE Unidades(
	Id			SMALLINT IDENTITY , 
	Nome		VARCHAR(100)	NOT NULL,
	Cep			VARCHAR(8)		NOT NULL,
	Logradouro	VARCHAR(100)	NOT NULL, 
	Numero		VARCHAR(10)		NOT NULL, 
	Bairro		VARCHAR(150)	NOT NULL,
	Cidade		VARCHAR(100)	NOT NULL,
	Complemento VARCHAR(100),

	CONSTRAINT PK_Unidade PRIMARY KEY(Id)
);

CREATE TABLE Acomodacoes(
	 Id				INTEGER IDENTITY,
	 IdUnidade		SMALLINT		NOT NULL,
	 IdStatus		TINYINT			NOT NULL,
	 IdTipoQuarto	TINYINT			NOT NULL,
	 Capacidade		SMALLINT		NOT NULL,
	 Identificador	VARCHAR(100)	NOT NULL,

	 CONSTRAINT PK_Acomodacoes PRIMARY KEY(Id),
	 CONSTRAINT FK_Acomodacoes_Unidade FOREIGN KEY(IdUnidade) REFERENCES Unidades(Id),
	 CONSTRAINT FK_Acomodacoes_Status FOREIGN KEY(IdStatus) REFERENCES AcomodacaoStatus(Id),
	 CONSTRAINT FK_Acomodacoes_TipoQuarto FOREIGN KEY(IdTipoQuarto) REFERENCES TipoQuartos(Id)
);

CREATE TABLE ProdutoTipos(
	Id		SMALLINT IDENTITY,
	Nome	VARCHAR(30) NOT NULL, 

	CONSTRAINT PK_ProdutoTipo PRIMARY KEY(Id)
);

CREATE TABLE Produtos(	
	Id		INTEGER IDENTITY, 
	IdTipo	SMALLINT		NOT NULL,
	Nome	VARCHAR(40)		NOT NULL, 
	Valor	DECIMAL(15,2)	NOT NULL, 

	CONSTRAINT PK_Produto PRIMARY KEY(Id),
	CONSTRAINT FK_Produto_Tipo FOREIGN KEY(IdTipo) REFERENCES ProdutoTipos(Id)
);

CREATE TABLE ContaStatus(
	Id		TINYINT IDENTITY, 
	Nome	VARCHAR(30) NOT NULL,

	CONSTRAINT PK_ContaStatus PRIMARY KEY(Id)
);

CREATE TABLE FormaPagamento(
	Id		TINYINT IDENTITY, 
	Nome	VARCHAR(40) NOT NULL,

	CONSTRAINT PK_FormaPagamento PRIMARY KEY(Id)
);

CREATE TABLE LancamentoContas(
	Id						INTEGER IDENTITY, 
	IdConta					INTEGER				NOT NULL, 
	IdProduto				INTEGER				NOT NULL, 
	Quantidade				INTEGER				NOT NULL,
	ValorUnitarioHistorico	DECIMAL(10,2)		NOT NULL, 
	DataLancamento			DATE				NOT NULL, 
	Descricao				VARCHAR(300),

	CONSTRAINT PK_LancamentoContas PRIMARY KEY(Id),
	CONSTRAINT FK_LancamentoContas_Produtos FOREIGN KEY(IdProduto) REFERENCES Produtos(Id)
);

CREATE TABLE Contas(
	Id					INTEGER IDENTITY,
	IdStatus			TINYINT	NOT NULL, 
	IdLancamentoConta	INTEGER NOT NULL,

	CONSTRAINT PK_Contas PRIMARY KEY(Id),
	CONSTRAINT FK_Contas_LancamentoContas FOREIGN KEY(IdLancamentoConta) REFERENCES LancamentoContas(Id),
	CONSTRAINT FK_Contas_Status FOREIGN KEY(IdStatus) REFERENCES ContaStatus(Id)
);

CREATE TABLE ContaFormaPagamento(
	IdConta				INTEGER			NOT NULL,
	IdFormaPagamento	TINYINT			NOT NULL,
	Valor				DECIMAL(10,2)	NOT NULL,
	DataPagamento		DATE			NOT NULL,

	CONSTRAINT FK_ContaFormaPagamento_Contas FOREIGN KEY(IdConta) REFERENCES Contas(Id),
	CONSTRAINT FK_ContaFormaPagamento_FormaPagamento FOREIGN KEY(IdFormaPagamento) REFERENCES FormaPagamento(Id)
);

CREATE TABLE Hospedes(
	Id			INTEGER IDENTITY,
	Nome		VARCHAR(100)	NOT NULL,
	Cpf			VARCHAR(11)		NOT NULL UNIQUE, 
	Telefone	VARCHAR(11)		NOT NULL, 
	Email		VARCHAR(320)	NOT NULL UNIQUE,

	CONSTRAINT PK_Hospedes PRIMARY KEY(Id)
);

CREATE TABLE ReservaStatus( 
	Id		INTEGER IDENTITY, 
	Nome	VARCHAR(50) NOT NULL,

	CONSTRAINT PK_ReservaStatus PRIMARY KEY(Id)
);

CREATE TABLE Reservas(
	Id				INTEGER IDENTITY,  
	IdStatus		INTEGER NOT NULL, 
	IdAcomodacao	INTEGER NOT NULL,
	IdConta			INTEGER NOT NULL,
	IdFuncionario	INTEGER NOT NULL, 
	DataCheckin		DATE	NOT NULL, 
	DataCheckout	DATE	NOT NULL,

	CONSTRAINT PK_Reservas PRIMARY KEY(Id),
	CONSTRAINT FK_Reservas_ReservaStatus  FOREIGN KEY(IdStatus) REFERENCES ReservaStatus(Id), 
	CONSTRAINT FK_Reservas_Acomodacao FOREIGN KEY(IdAcomodacao) REFERENCES Acomodacoes(Id), 
	CONSTRAINT FK_Reservas_Contas FOREIGN KEY(IdConta) REFERENCES Contas(Id),
	CONSTRAINT FK_Reservas_Funcionarios FOREIGN KEY(IdFuncionario) REFERENCES Funcionarios(Id)
);

CREATE TABLE Dependentes( 
	Id			INTEGER IDENTITY, 
	IdReserva	INTEGER			NOT NULL, 
	Nome		VARCHAR(50)		NOT NULL, 
	Cpf			VARCHAR(11)		NOT NULL UNIQUE, 
	Telefone	VARCHAR(11)		NOT NULL,
	Email		VARCHAR(320)	NOT NULL UNIQUE, 
	
	CONSTRAINT PK_Dependentes PRIMARY KEY(Id),
	CONSTRAINT FK_Dependentes_Reservas FOREIGN KEY(IdReserva) REFERENCES Reservas(Id),
);

CREATE TABLE ReservaHospede(
	IdHospede INTEGER NOT NULL,
	IdReserva INTEGER NOT NULL,

	CONSTRAINT FK_ReservaHospede_Hospede FOREIGN KEY(IdHospede) REFERENCES Hospedes(Id),
	CONSTRAINT FK_ReservaHospede_Reserva FOREIGN KEY(IdReserva) REFERENCES Reservas(Id)
);

