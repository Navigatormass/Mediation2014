USE [Mediation2014]
GO

/****** Object:  StoredProcedure [dbo].[uspGetMorgagorDetails]    Script Date: 02/10/2015 12:07:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[uspGetMorgagorDetails]
	-- Add the parameters for the stored procedure here
	@MortgagorInformationID int
AS
Begin
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.


    -- Insert statements for procedure here
	SELECT * from MortgagorInformation where MortgagorInformationID=@MortgagorInformationID
	RETURN
END


GO
