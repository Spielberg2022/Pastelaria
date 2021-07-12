CREATE TABLE [dbo].[TipoUsuario](
	Codigo tinyint not null, 
	Descricao varchar(25) not null,

	CONSTRAINT TipoUsuario_Pk PRIMARY KEY(Codigo)
)
GO
CREATE TABLE [dbo].[Usuario](
	Id int not null IDENTITY(1,1),
	CodigoTipoUsuario tinyint not null,
	Email varchar(70) not null,
	Senha varchar(30) not null,
	Nome varchar(80) not null,
	DataNascimento date,
	TelefoneFixo varchar(10),
	TelefoneCelular varchar(11),
	Logradouro varchar(80),
	Bairro varchar(50),
	Cidade varchar(50),
	Uf varchar(2),
	Cep varchar(8),
	Foto varchar(30),

	CONSTRAINT Usuario_Pk PRIMARY KEY(Id),
	CONSTRAINT TipoUsuario_Usuario_Fk FOREIGN KEY(CodigoTipoUsuario) REFERENCES [dbo].[TipoUsuario](Codigo)
)
GO
CREATE TABLE [dbo].[Tarefa](
	Id int not null IDENTITY(1,1),
	IdGestor int not null,
	IdUsuario int not null,
	TarefaDescricao varchar(200) not null,
	DataAgendamento date not null,
	DataLimiteExecucao date not null,
	DataExecucao date,

	CONSTRAINT Tarefa_Pk PRIMARY KEY(Id),
	CONSTRAINT Usuario_Tarefa_Fk FOREIGN KEY(IdGestor) REFERENCES [dbo].[Usuario](Id),
	CONSTRAINT Usuario_Tarefa_Fk1 FOREIGN KEY(IdUsuario) REFERENCES [dbo].[Usuario](Id)
)
GO
CREATE TABLE [dbo].[TipoEmail](
	Codigo tinyint not null,
	Descricao varchar(25) not null,

	CONSTRAINT TipoEmail_Pk PRIMARY KEY(Codigo)
)
GO
CREATE TABLE [dbo].[DisparoEmail](
	Id int not null IDENTITY(1,1),
	IdTarefa int not null,
	IdUsuarioDestinatario int not null,
	CodigoTipoEmail tinyint not null,
	Mensagem nvarchar(500) not null,
	Assunto varchar(80) not null,
	Email varchar(70) not null,

	CONSTRAINT DisparoEmail_Pk PRIMARY KEY(Id),
	CONSTRAINT Tarefa_DisparoEmail FOREIGN KEY(IdTarefa) REFERENCES [dbo].[Tarefa](Id),
	CONSTRAINT Usuario_DisparoEmail FOREIGN KEY(IdUsuarioDestinatario) REFERENCES [dbo].[Usuario](Id),
	CONSTRAINT TipoEmail_DisparoEmail FOREIGN KEY(CodigoTipoEmail) REFERENCES [dbo].[TipoEmail](Codigo),
)
GO
