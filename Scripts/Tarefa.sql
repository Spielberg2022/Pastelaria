IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[PSP_InsTarefa]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[PSP_InsTarefa]
GO

CREATE PROCEDURE [dbo].[PSP_InsTarefa]
	@IdGestor int,
	@IdUsuario int,
	@TarefaDescricao varchar(200) = null,
	@DataAgendamento date = null,
	@DataLimiteExecucao date = null,
	@DataExecucao date = null
	AS

	/*
	Documentacao
	Arquivo Fonte.....: Tarefa.sql
	Objetivo..........: Insere uma nova Tarefa
	Autor.............: SMN - Wesley Silveira
 	Data..............: 08/07/2021
	Ex................: EXEC [dbo].[PSP_InsTarefa]

	*/

	BEGIN;

		INSERT INTO Tarefa (IdGestor, IdUsuario, TarefaDescricao, DataAgendamento, DataLimiteExecucao, DataExecucao)
			VALUES(@IdGestor,@IdUsuario,@TarefaDescricao,@DataAgendamento,@DataLimiteExecucao,@DataExecucao)

	END;
GO


IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[PSP_SelTarefaPorUsuario]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[PSP_SelTarefaPorUsuario]
GO

CREATE PROCEDURE [dbo].[PSP_SelTarefaPorUsuario]
	@IdUsuario int
	AS

	/*
	Documentacao
	Arquivo Fonte.....: Tarefa.sql
	Objetivo..........: Busca todas as tarefas de um usuário informado
	Autor.............: SMN - Wesley Silveira
 	Data..............: 08/07/2021
	Ex................: EXEC [dbo].[PSP_SelTarefaPorUsuario]

	*/

	BEGIN;

		-- nolock em todas tabelas da proc
		SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;

		SELECT Id, IdGestor, IdUsuario, TarefaDescricao, DataAgendamento, DataLimiteExecucao, DataExecucao
			FROM [dbo].[Tarefa]
			WHERE IdUsuario = @IdUsuario

	END;
GO
				

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[PSP_SelTarefaPorId]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[PSP_SelTarefaPorId]
GO

CREATE PROCEDURE [dbo].[PSP_SelTarefaPorId]
	@Id int
	AS

	/*
	Documentacao
	Arquivo Fonte.....: Tarefa.sql
	Objetivo..........: Busca a tarefa por um Id informado
	Autor.............: SMN - Wesley Silveira
 	Data..............: 08/07/2021
	Ex................: EXEC [dbo].[PSP_SelTarefaPorId]

	*/

	BEGIN;

		-- nolock em todas tabelas da proc
		SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
		
		SELECT Id, IdGestor, IdUsuario, TarefaDescricao, DataAgendamento, DataLimiteExecucao, DataExecucao
			FROM Tarefa
			WHERE Id = @Id

	END;
GO
				

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[PSP_UpdDataExecucaoTarefa]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[PSP_UpdDataExecucaoTarefa]
GO

CREATE PROCEDURE [dbo].[PSP_UpdDataExecucaoTarefa]
	@Id int
	AS

	/*
	Documentacao
	Arquivo Fonte.....: Tarefa.sql
	Objetivo..........: Atualiza a data da execução da tabela Tarefa.
	Autor.............: SMN - Wesley Silveira
 	Data..............: 12/07/2021
	Ex................: BEGIN TRANSACTION
							EXEC [dbo].[PSP_UpdDataExecucaoTarefa]30
							SELECT * FROM Tarefa 
						ROLLBACK TRANSACTION

	*/

	BEGIN;

		UPDATE Tarefa
			SET DataExecucao = CAST(GETDATE() AS DATE)
			WHERE Id = @Id

	END;
GO
				