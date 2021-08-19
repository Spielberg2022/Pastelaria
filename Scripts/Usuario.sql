
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[PSP_SelUsuarioPorEmaileSenha]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[PSP_SelUsuarioPorEmaileSenha]
GO

CREATE PROCEDURE [dbo].[PSP_SelUsuarioPorEmaileSenha]
	@email varchar(70),
	@senha varchar(30)
	AS

	/*
	Documentacao
	Arquivo Fonte.....: Login.sql
	Objetivo..........: Selecionar Usuário por email e senha
	Autor.............: SMN - Wesley Silveira
 	Data..............: 08/07/2021
	Ex................: EXEC [dbo].[PSP_SelUsuarioPorEmaileSenha]'oportunidade@smn.com.br','teste123'

	*/

	BEGIN;

		-- nolock em todas tabelas da proc
		SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;

		SELECT	Id,
				Nome,
				Email,
				Senha
			FROM [dbo].[Usuario]
			WHERE Email = @email and
				  Senha = @senha

	END;
GO



IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[PSP_InsUsuario]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[PSP_InsUsuario]
GO

CREATE PROCEDURE [dbo].[PSP_InsUsuario]
	@CodigoTipoUsuario tinyint,
	@Email varchar(70),
	@Senha varchar(30),
	@Nome varchar(80),
	@DataNascimento date = null,
	@TelefoneFixo varchar(10) = null,
	@TelefoneCelular varchar(11) = null,
	@Logradouro varchar(80) = null,
	@Bairro varchar(50) = null,
	@Cidade varchar(50) = null,
	@Uf varchar(2) = null,
	@Cep varchar(8) = null,
	@Foto varchar(30) = null
	AS

	/*
	Documentacao
	Arquivo Fonte.....: Usuario.sql
	Objetivo..........: Inserir um novo usuário no Cadastro
	Autor.............: SMN - Wesley Silveira
 	Data..............: 08/07/2021
	Ex................: EXEC [dbo].[PSP_InsUsuario]

	*/

	BEGIN;

		INSERT INTO [dbo].[Usuario] (CodigoTipoUsuario, Email, Senha, Nome, DataNascimento, 
							TelefoneFixo, TelefoneCelular, Logradouro, Bairro, Cidade, Uf, Cep, Foto)
			VALUES (@CodigoTipoUsuario,@Email,@Senha,@Nome,@DataNascimento,
					@TelefoneFixo,@TelefoneCelular,@Logradouro,@Bairro,@Cidade,@Uf,@Cep,@Foto)

	END;
GO


IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[PSP_SelUsuarioPorEmail]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[PSP_SelUsuarioPorEmail]
GO

CREATE PROCEDURE [dbo].[PSP_SelUsuarioPorEmail]
	@Email varchar(70)
	AS

	/*
	Documentacao
	Arquivo Fonte.....: Usuario.sql
	Objetivo..........: Buscar um usuário na tabela pelo código informado
	Autor.............: SMN - Wesley Silveira
 	Data..............: 08/07/2021
	Ex................: EXEC [dbo].[PSP_SelUsuarioPorEmail]

	*/

	BEGIN;

		-- nolock em todas tabelas da proc
		SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;

		SELECT  Id, 
				CodigoTipoUsuario, 
				Email, 
				Senha, 
				Nome, 
				DataNascimento, 
				TelefoneFixo, 
				TelefoneCelular, 
				Logradouro, 
				Bairro, 
				Cidade, 
				Uf, 
				Cep, 
				Foto
			FROM [dbo].[Usuario]
			WHERE Email = @Email

	END;
GO


IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[PSP_SelEmailUsuarioPorId]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[PSP_SelEmailUsuarioPorId]
GO

CREATE PROCEDURE [dbo].[PSP_SelEmailUsuarioPorId]
	@Id int
	AS

	/*
	Documentacao
	Arquivo Fonte.....: Usuario.sql
	Objetivo..........: Busca e-mail do usuário por Id
	Autor.............: SMN - Wesley Silveira
 	Data..............: 12/07/2021
	Ex................: EXEC [dbo].[PSP_SelEmailUsuarioPorId]

	*/

	BEGIN;

		-- nolock em todas tabelas da proc
		SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;

		SELECT Email
			FROM [dbo].[Usuario]
			WHERE Id = @Id

	END;
GO
				

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[PSP_SelUsuarioPorId]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[PSP_SelUsuarioPorId]
GO

CREATE PROCEDURE [dbo].[PSP_SelUsuarioPorId]
	@Id int
	AS

	/*
	Documentacao
	Arquivo Fonte.....: Usuario.sql
	Objetivo..........: Busca o usuário pelo Id informado
	Autor.............: SMN - Wesley Silveira
 	Data..............: 12/07/2021
	Ex................: EXEC [dbo].[PSP_SelUsuarioPorId]

	*/

	BEGIN;

		-- nolock em todas tabelas da proc
		SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;

		SELECT Id, 
				CodigoTipoUsuario, 
				Email, 
				Senha, 
				Nome, 
				DataNascimento, 
				TelefoneFixo, 
				TelefoneCelular, 
				Logradouro, 
				Bairro, 
				Cidade, 
				Uf, 
				Cep, 
				Foto
			FROM [dbo].[Usuario]
			WHERE Id = @Id

	END;
GO
								


IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[PSP_DeleteUsuarioPorId]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[PSP_DeleteUsuarioPorId]
GO

CREATE PROCEDURE [dbo].[PSP_DeleteUsuarioPorId]
@Id int
	AS

	/*
	Documentacao
	Arquivo Fonte.....: Usuario.sql
	Objetivo..........: Deleta o Usuário pelo Id informado
	Autor.............: SMN - Wesley Silveira
 	Data..............: 19/08/2021
	Ex................: EXEC [dbo].[PSP_DeleteUsuarioPorId]

	*/

	BEGIN;

		DELETE FROM [dbo].[Usuario] 
			WHERE Id = @Id;

	END;
GO
												