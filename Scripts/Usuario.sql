
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

		

		

	END;
GO
								