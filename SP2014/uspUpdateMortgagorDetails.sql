USE [Mediation2014]
GO

/****** Object:  StoredProcedure [dbo].[uspUpdateMortgagorDetails]    Script Date: 02/10/2015 12:16:50 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[uspUpdateMortgagorDetails]
	-- Add the parameters for the stored procedure here
	@MortgagorInformationID int,
    @FirstName varchar(35),
	@MiddleInitial varchar(4),
	@LastName varchar(35),
	@Co_FirstName varchar(35),
	@Co_MiddleInitial varchar(4),
	@Co_LastName varchar(35),
	@Address_1 varchar(40),
	@Address_2 varchar(40),
	@City varchar(28),
	@ZipCode char(5),
	@State char(2)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE MortgagorInformation SET FirstName= @FirstName,
									MiddleInitial=@MiddleInitial,
									LastName=@LastName,
									Co_FirstName=@Co_FirstName,
									Co_MiddleInitial=@Co_MiddleInitial,
									Co_LastName=@Co_LastName,
									Address_1=@Address_1,
									Address_2=@Address_2,
									City=@City,
									ZipCode=@ZipCode,
									State=@State
	WHERE MortgagorInformationID=@MortgagorInformationID
									
									
									
END

GO

