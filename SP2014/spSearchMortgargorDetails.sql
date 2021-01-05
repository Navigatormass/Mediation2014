USE [Mediation2014]
GO

/****** Object:  StoredProcedure [dbo].[spSearchMortgargorDetails]    Script Date: 02/10/2015 12:02:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spSearchMortgargorDetails]

	-- Add the parameters for the stored procedure here
		@searchtext varchar(35),
        @MediationCaseId int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
if(@searchtext!='')
    select FirstName+' '+LastName as FullName,* from MortgagorInformation where upper(LastName) like '%'+IsNull(upper(@searchtext),upper(LastName))+'%' or ZipCode like '%'+IsNull(@searchtext,ZipCode)+'%' or upper(Address_1) like '%'+IsNull(upper(@searchtext),upper(Address_1))+'%' order by LastName
    else if(@MediationCaseId!=-1)
    select M.FirstName+' '+M.LastName as FullName,M.* from MortgagorInformation M,MediationCaseInformation O where O.MediationCaseInformationID=@MediationCaseId and M.MortgagorInformationID=O.MortgagorInformationID order by LastName
    else
    select FirstName+' '+LastName as FullName,* from MortgagorInformation order by LastName

    
    RETURN
    END

GO

