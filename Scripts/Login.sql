
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[PSP_SelUsuarioPorEmaileSenha]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[PSP_SelUsuarioPorEmaileSenha]
GO

CREATE PROCEDURE [dbo].[PSP_SelUsuarioPorEmaileSenha]
	@email nvarchar(70),
	@senha nvarchar(30)
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


IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[PSP_NomeProcedure]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[PSP_NomeProcedure]
GO

CREATE PROCEDURE [dbo].[PSP_NomeProcedure]

	AS

	/*
	Documentacao
	Arquivo Fonte.....: ArquivoFonte.sql
	Objetivo..........: Objetivo
	Autor.............: SMN - Wesley Silveira
 	Data..............: 01/01/2021
	Ex................: EXEC [dbo].[PSP_NomeProcedure]

	*/

	BEGIN;

		-- nolock em todas tabelas da proc
		SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;

		

	END;
GO


IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[PSP_SelectNome]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[PSP_SelectNome]
GO

CREATE PROCEDURE [dbo].[PSP_SelectNome]

	AS

	/*
	Documentacao
	Arquivo Fonte.....: ArquivoFonte.sql
	Objetivo..........: Objetivo
	Autor.............: SMN - Wesley Silveira
 	Data..............: 01/01/2021
	Ex................: EXEC [dbo].[PSP_SelectNome]

	*/

	BEGIN;

		-- nolock em todas tabelas da proc
		SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;

		

	END;
GO
				
				