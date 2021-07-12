IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[PSP_InsDisparoEmail]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[PSP_InsDisparoEmail]
GO

CREATE PROCEDURE [dbo].[PSP_InsDisparoEmail]
	@IdTarefa int,
	@IdUsuarioDestinatario int,
	@CodigoTipoEmail tinyint,
	@Mensagem nvarchar(500),
	@Assunto varchar(80),
	@Email varchar(70)
	AS

	/*
	Documentacao
	Arquivo Fonte.....: DisparoEmail.sql
	Objetivo..........: Salvar o e-mail enviado
	Autor.............: SMN - Wesley Silveira
 	Data..............: 09/07/2021
	Ex................: EXEC [dbo].[PSP_InsDisparoEmail]

	*/

	BEGIN;

		INSERT INTO DisparoEmail (IdTarefa, IdUsuarioDestinatario, CodigoTipoEmail, Mensagem, Assunto, Email)
			VALUES (@IdTarefa,@IdUsuarioDestinatario,@CodigoTipoEmail,@Mensagem,@Assunto,@Email)

	END;
GO
				

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[PSP_SelDisparoEmailPorId]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[PSP_SelDisparoEmailPorId]
GO

CREATE PROCEDURE [dbo].[PSP_SelDisparoEmailPorId]
	@Id int
	AS

	/*
	Documentacao
	Arquivo Fonte.....: DisparoEmail.sql
	Objetivo..........: Buscar
	Autor.............: SMN - Wesley Silveira
 	Data..............: 01/01/2021
	Ex................: EXEC [dbo].[PSP_SelDisparoEmailPorId]

	*/

	BEGIN;

		-- nolock em todas tabelas da proc
		SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;

		SELECT Id, IdTarefa, IdUsuarioDestinatario, CodigoTipoEmail, Mensagem, Assunto
			FROM DisparoEmail
			WHERE Id = @Id

	END;
GO
		

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[PSP_SelDisparoEmailPorIdTarefa]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[PSP_SelDisparoEmailPorIdTarefa]
GO

CREATE PROCEDURE [dbo].[PSP_SelDisparoEmailPorIdTarefa]
	@IdTarefa int
	AS

	/*
	Documentacao
	Arquivo Fonte.....: DisparoEmail.sql
	Objetivo..........: Buscar e-mail enviado por IdTarefa
	Autor.............: SMN - Wesley Silveira
 	Data..............: 09/07/2021
	Ex................: EXEC [dbo].[PSP_SelDisparoEmailPorIdTarefa]23

	*/

	BEGIN;

		-- nolock em todas tabelas da proc
		SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;

		SELECT Id, IdTarefa, IdUsuarioDestinatario, CodigoTipoEmail, Mensagem, Assunto
			FROM DisparoEmail
			WHERE IdTarefa = @IdTarefa

	END;
GO
				