USE [Mediation2014]
GO

/****** Object:  StoredProcedure [dbo].[uspGetMediationCasebyID]    Script Date: 02/10/2015 12:05:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Jaheda Meman>
-- Update date: <11/12/14,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[uspGetMediationCasebyID]
@MediationCaseInformationID int
AS
select * from MediationCaseInformation where MediationCaseInformationID=@MediationCaseInformationID
	/* SET NOCOUNT ON */
	RETURN

GO

